using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace TASKMANAGER.Models
{
    public class TaskActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public static void AddActivities(TaskActivity tasks)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into PanchayatActivities(Name, Description, Date) values(@Name, @Description, @Date)";
                cmd.Parameters.AddWithValue("@Name", tasks.Name);
                cmd.Parameters.AddWithValue("@Description", tasks.Description);
                cmd.Parameters.AddWithValue("@Date", tasks.Date);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
        }

        public static List<TaskActivity> GetAllActivities()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            List<TaskActivity> list = new List<TaskActivity>();
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from PanchayatActivities";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new TaskActivity { Id = (int)dr["Id"], Name = (string)dr["Name"], Description = (string)dr["Description"], Date = (string)dr["Date"] });
                }

                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }
        public static TaskActivity GetActivityById(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from PanchayatActivities where Id ={id}";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                TaskActivity activity = new TaskActivity();
                activity.Id = (int)dr["Id"];
                activity.Name = (string)dr["Name"];
                activity.Description = (string)dr["Description"];
                activity.Date = (string)dr["Date"];
                return activity;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
        }
        public static void UpdateActivity(int id, TaskActivity activity)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"update PanchayatActivities set Name = '{activity.Name}', Description = '{activity.Description}', Date = '{activity.Date}' where Id ={id}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally { conn.Close(); }

        }
        public static void DeleteActivity(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"delete from PanchayatActivities where Id ={id}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
        }
    }
}
