using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"(localdb)\v11.0";
            scsb.InitialCatalog = "StuInfoDB";
            scsb.IntegratedSecurity = true;
            scsb.AttachDBFilename = @"C:\Users\bunny\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0\StuInfoDB.mdf";
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID_No, Name, Gender, Major, Email_Address from WSStudent where ID_No=1201210522", con))
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}", reader[0], reader[1], reader[2], reader[3], reader[4]));
                    } 
                }
            }
            Console.ReadLine();
        }
    }
}
