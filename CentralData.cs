using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ECS_GUI
{
    // Model classes representing the core business entities
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

    // Static data access layer to centralize database interactions
    public static class CentralData
    {
        // Connection string configured to the local database file path
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECSDatabase.mdf") + ";Integrated Security=True";

        // Global lists for in-memory tracking of requests and logs
        public static List<CheckoutRequest> RequestList { get; set; } = new List<CheckoutRequest>();
        public static List<AuditLog> AuditLogList { get; set; } = new List<AuditLog>();

        private static int nextIdSequence = 101; // Sequence tracker for generated IDs

        // Retrieves all employee records from the SQL database
        public static List<Employee> GetEmployeesFromDatabase()
        {
            List<Employee> list = new List<Employee>();
            string query = "SELECT EmployeeID, FullName, BadgeNumber, Role, Skills FROM Employees";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employees: " + ex.Message);
                    throw;
                }
            }
            return list;
        }

        // Retrieves all equipment inventory records from the SQL database
        public static List<EquipmentItem> GetEquipmentFromDatabase()
        {
            List<EquipmentItem> list = new List<EquipmentItem>();
            string query = "SELECT EquipmentID, EquipmentName, Model, RequiredSkill, Status, Location FROM Equipment";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading equipment: " + ex.Message);
                    throw;
                }
            }
            return list;
        }

        // Fetches available skill categories from the database for UI population
        public static List<string> GetSkillsFromDatabase()
        {
            List<string> list = new List<string>();
            string query = "SELECT SkillName FROM Skills";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader["SkillName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading skills: " + ex.Message);
                    throw;
                }
            }
            return list;
        }

        // Authenticates user via database lookup to ensure authorized access
        public static Employee ValidateLogin(string fullName, string badgeNumber)
        {
            string query = "SELECT EmployeeID, FullName, BadgeNumber, Role, Skills FROM Employees WHERE FullName = @Name AND BadgeNumber = @Badge";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                // Use parameters to prevent SQL injection during authentication
                cmd.Parameters.AddWithValue("@Name", fullName);
                cmd.Parameters.AddWithValue("@Badge", badgeNumber);

                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error during login: " + ex.Message);
                    throw;
                }
            }
            return null; // Return null if authentication fails
        }

        // Incremental ID generator for new checkout requests
        public static string GenerateNextRequestID()
        {
            string newId = $"R-{nextIdSequence}";
            nextIdSequence++;
            return newId;
        }
    }
}