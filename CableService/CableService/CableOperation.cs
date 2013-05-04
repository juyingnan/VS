using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace CableService
{
    public class CableOperation
    {
        public CableOperation()
        {
            scsb.DataSource = @"BUNNY-PC\SQLEXPRESS";
            scsb.InitialCatalog = "CableDatabase";
            scsb.UserID = "sa";
            scsb.Password = "test";
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        public string GetCableInfo(String CustomerID, String EventID)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT " + EventID + " from CustomerCableInfo where CustomerID='" + CustomerID + "'", con))
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

        public string updCableInfo(String CustomerID, String EventID, bool b)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                if (b)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE CableDatabase.dbo.CustomerCableInfo SET " + EventID
                            + "='True' WHERE CustomerID='" + CustomerID + "'", con))
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
                    using (SqlCommand cmd = new SqlCommand("UPDATE CableDatabase.dbo.CustomerCableInfo SET " + EventID
                                + "='False' WHERE CustomerID='" + CustomerID + "'", con))
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
        }
    }
}