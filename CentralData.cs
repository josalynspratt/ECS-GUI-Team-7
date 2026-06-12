using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ECS_GUI
{
    public class AuditLog
    {
        public string LogID { get; set; }
        public string Action { get; set; }
        public string Timestamp { get; set; }
        public string Details { get; set; }
    }

    public class CheckoutRequest
    {
        public string RequestID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string CheckoutDate { get; set; }
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public string ExpectedReturnDate { get; set; }
        public string ActualReturnDate { get; set; }
    }

    public class Employee
    {
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string BadgeNumber { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
    }

    public class EquipmentItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string RequiredSkill { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
    }

    public static class CentralData
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS_GUI\ECSDatabase.mdf;Integrated Security=True";

        public static List<CheckoutRequest> RequestList { get; set; } = new List<CheckoutRequest>();
        public static List<AuditLog> AuditLogList { get; set; } = new List<AuditLog>();

        private static int nextIdSequence = 101;

        public static List<Employee> GetEmployeesFromDatabase()
        {
            List<Employee> list = new List<Employee>();
            string query = "SELECT EmployeeID, FullName, BadgeNumber, Role, Skills FROM Employees";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            EmployeeID = reader["EmployeeID"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            BadgeNumber = reader["BadgeNumber"].ToString(),
                            Role = reader["Role"].ToString(),
                            Skills = reader["Skills"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static List<EquipmentItem> GetEquipmentFromDatabase()
        {
            List<EquipmentItem> list = new List<EquipmentItem>();
            string query = "SELECT EquipmentID, EquipmentName, Model, RequiredSkill, Status, Location FROM Equipment";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EquipmentItem
                        {
                            Id = reader["EquipmentID"].ToString(),
                            Name = reader["EquipmentName"].ToString(),
                            Model = reader["Model"].ToString(),
                            RequiredSkill = reader["RequiredSkill"].ToString(),
                            Status = reader["Status"].ToString(),
                            Location = reader["Location"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static List<string> GetSkillsFromDatabase()
        {
            List<string> list = new List<string>();
            string query = "SELECT SkillName FROM Skills";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["SkillName"].ToString());
                    }
                }
            }
            return list;
        }

        public static Employee ValidateLogin(string fullName, string badgeNumber)
        {
            string query = "SELECT EmployeeID, FullName, BadgeNumber, Role, Skills FROM Employees WHERE FullName = @Name AND BadgeNumber = @Badge";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", fullName);
                cmd.Parameters.AddWithValue("@Badge", badgeNumber);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employee
                        {
                            EmployeeID = reader["EmployeeID"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            BadgeNumber = reader["BadgeNumber"].ToString(),
                            Role = reader["Role"].ToString(),
                            Skills = reader["Skills"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public static string GenerateNextRequestID()
        {
            string newId = $"R-{nextIdSequence}";
            nextIdSequence++;
            return newId;
        }
    }
}