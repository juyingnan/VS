using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace HW2_WS_StuInfo_Server
{
    public class StuInfoDBOperation
    {
        public StuInfoDBOperation()
        {
            scsb.DataSource = @"BUNNY-PC\SQLEXPRESS";
            scsb.InitialCatalog = "StuInfoDB";
            scsb.UserID = "sa";
            scsb.Password = "test";
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();


        public string GetInfo(String ReturnType, String Keyword)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT " + ReturnType + " from WSStudent where ID_No=" + Keyword, con))
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    try
                    {
                        return cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

        public string DelInfo(String Keyword)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE from WSStudent where ID_No=" + Keyword, con))
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery().ToString();
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

        public string InsInfo(String Info)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                string[] StuInfo = Info.Split(';');
                if (StuInfo.Length == 5)
                {
                    for (int i = 0; i < StuInfo.Length; i++)
                    {
                        StuInfo[i] = "'" + StuInfo[i] + "'";
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT into WSStudent(ID_No,Name,Gender,Major,Email_Address) VALUES ("
                            + StuInfo[0] + "," + StuInfo[1] + "," + StuInfo[2] + "," + StuInfo[3] + "," + StuInfo[4]
                            + ")", con))
                    {
                        if (con.State != ConnectionState.Open) con.Open();
                        try
                        {
                            return cmd.ExecuteNonQuery().ToString();
                        }
                        catch (Exception e)
                        {
                            return e.Message;
                        }
                    }
                }
                else
                {
                    return "illegal parameter.";
                }
            }
        }

        public string updInfo(String Info)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                string[] StuInfo = Info.Split(';');
                if (StuInfo.Length == 5)
                {
                    for (int i = 0; i < StuInfo.Length; i++)
                    {
                        StuInfo[i] = "'" + StuInfo[i] + "'";
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE WSStudent SET Name=" + StuInfo[1] + ",Gender=" + StuInfo[2]
                            + ",Major=" + StuInfo[3] + ",Email_Address=" + StuInfo[4] + "WHERE ID_No=" + StuInfo[0], con))
                    {
                        if (con.State != ConnectionState.Open) con.Open();
                        try
                        {
                            return cmd.ExecuteNonQuery().ToString();
                        }
                        catch (Exception e)
                        {
                            return e.Message;
                        }
                    }
                }
                else
                {
                    return "illegal parameter.";
                }
            }
        }        
    }
}