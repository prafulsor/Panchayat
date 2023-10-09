using Microsoft.Data.SqlClient;
using System.Data;

namespace Panchayat.Models
{
    public class RaiseFund
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }


        public static void AddFund(RaiseFund fund)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            conn.Open();
            fund.Status = "Donated";
            try
            {
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = $"insert into RaiseFunds(Name, Phone, Amount, Status) values('{fund.Name}', '{fund.Phone}', {fund.Amount}, '{fund.Status}')";
                cmd1.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
        }
        public static List<RaiseFund> GetAllDonations()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cdac;Integrated Security=True";
            List<RaiseFund> list = new List<RaiseFund>();
            conn.Open();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from RaiseFunds";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new RaiseFund { Id = (int)dr["Id"], Name = (string)dr["Name"], Phone = (string)dr["Phone"], Amount = (string)dr["Amount"], Status = (string)dr["Status"] });
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
    }
}
