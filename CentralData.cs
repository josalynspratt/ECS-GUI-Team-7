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
        public int RequestID { get; set; }
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

        // ADDED: tracks which employee currently has the equipment checked out
        public string AssignedEmployeeID { get; set; }

        // ADDED: expected return date for operational tracking and reporting
        public string ExpectedReturnDate { get; set; }

        public string LastUpdated { get; set; }
    }

    public static class CentralData
    {
        // SINGLE SOURCE OF TRUTH for database connection
        public static readonly string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\ECS GUI\ECSDatabase.mdf;Integrated Security=True";

        public static List<CheckoutRequest> RequestList { get; set; } = new List<CheckoutRequest>();
        public static List<AuditLog> AuditLogList { get; set; } = new List<AuditLog>();

        // ---------------- AUDIT LOGGING ----------------

        // CENTRAL LOG METHOD: ensures ALL actions are tracked consistently
        public static void AddAuditLog(string action, string details)
        {
            AuditLogList.Add(new AuditLog
            {
                LogID = Guid.NewGuid().ToString(),
                Action = action,
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Details = details
            });
        }

        // ---------------- EMPLOYEES ----------------

        public static List<Employee> GetEmployeesFromDatabase()
        {
            List<Employee> list = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT EmployeeID, FullName, BadgeNumber, Role, Skills FROM Employees",
                    conn);

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

        // ---------------- EQUIPMENT ----------------

        public static List<EquipmentItem> GetEquipmentFromDatabase()
        {
            List<EquipmentItem> list = new List<EquipmentItem>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT EquipmentID, EquipmentName, Model, RequiredSkill, Status, Location,
                             AssignedEmployeeID, ExpectedReturnDate, LastUpdated
                      FROM Equipment",
                    conn);

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
                            Location = reader["Location"].ToString(),

                            LastUpdated = reader["LastUpdated"] == DBNull.Value ? null : reader["LastUpdated"].ToString(),
                            AssignedEmployeeID = reader["AssignedEmployeeID"] == DBNull.Value ? null : reader["AssignedEmployeeID"].ToString(),
                            ExpectedReturnDate = reader["ExpectedReturnDate"] == DBNull.Value ? null : reader["ExpectedReturnDate"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        // ---------------- SKILLS ----------------

        public static List<string> GetSkillsFromDatabase()
        {
            List<string> list = new List<string>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT SkillName FROM Skills", conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(reader["SkillName"].ToString());
                }
            }

            return list;
        }

        // ---------------- ADD EQUIPMENT ----------------

        public static void AddEquipment(string name, string model, string skill, string location, int id)
        {
            string query =
                "INSERT INTO Equipment (EquipmentID, EquipmentName, Model, RequiredSkill, Status, Location, LastUpdated) " +
                "VALUES (@ID, @Name, @Model, @Skill, @Status, @Location, @LastUpdated)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Skill", skill);
                cmd.Parameters.AddWithValue("@Status", "Available");
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@LastUpdated", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------- DECOMMISSION EQUIPMENT ----------------

        public static void DecommissionEquipment(string equipmentId)
        {
            string query =
                @"UPDATE Equipment
                  SET Status = 'Decommissioned',
                      AssignedEmployeeID = NULL,
                      ExpectedReturnDate = NULL,
                      LastUpdated = @Updated
                  WHERE EquipmentID = @ID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", equipmentId);
                cmd.Parameters.AddWithValue("@Updated", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------- SKILLS ----------------

        public static void AddSkill(string skillName)
        {
            string query = "INSERT INTO Skills (SkillName) VALUES (@SkillName)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SkillName", skillName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------- REQUEST ID GENERATION ----------------

        public static int GenerateNextRequestID()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT ISNULL(MAX(RequestID), 100) + 1 FROM CheckoutRequests";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}