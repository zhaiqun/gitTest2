using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace zhaiqunHeimaTest.Dal
{
    public static  class SqlHelper
    {
        static readonly string constr = ConfigurationManager.ConnectionStrings["Myconstr"].ConnectionString;

        public static int ExecuteNoneQuery(string sql,CommandType cmdType,params SqlParameter[] p ) 
        {
            using (SqlConnection conn=new SqlConnection(constr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    if (p!=null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cmd.CommandType = cmdType;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }       
        }
        public static int ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] p) {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cmd.CommandType = cmdType;
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }  
        }

        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] p)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (SqlCommand cmd=new SqlCommand(sql,conn))
            {
                if (p!=null)
                {
                    cmd.Parameters.AddRange(p);
                }
                cmd.CommandType = cmdType;
                try
                {
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch 
                {
                    conn.Close();
                    conn.Dispose();
                    throw;
                }
            }
        }
    }
}
