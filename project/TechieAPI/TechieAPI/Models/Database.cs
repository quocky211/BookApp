﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TechieAPI.Models
{
    public class Database
    {
        public static DataTable Read_Table(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            DataTable result = new DataTable("table1");
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(result);

                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }

        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                // Start a local transaction.

                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@CurrentID"].Value;
                    // Attempt to commit the transaction.

                }
                catch (Exception ex)
                {

                    result = null;
                }

            }
            return result;
        }
        public static DataTable ListProduct()
        {
            return Read_Table("ListProduct");
        }
        public static DataTable LstProductByType(int maloai)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("loai", maloai);
            return Read_Table("ListProductByType", param);
        }

        public static User ThemUser(User user)
        {
            Dictionary<string, object> param = new Dictionary<string , object>();
            param.Add("HOTEN", user.HOTEN);
            param.Add("TENDN", user.TENDN);
            param.Add("MATKHAU", user.MATKHAU);
            param.Add("EMAIL", user.EMAIL);
            int kq = int.Parse(Exec_Command("AddUser", param).ToString());
            if(kq>-1)
            {
                user.MA = kq;
            }
            return user;

        }

        public static User UserLogin(string TenDN, string Password)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TENDN", TenDN);
            param.Add("MATKHAU",Password);
            DataTable tb = Read_Table("DangNhap", param);
            User kq = new User();
            if (tb.Rows.Count > 0)
            {
                kq.MA = int.Parse(tb.Rows[0]["MA"].ToString());
                kq.HOTEN = tb.Rows[0]["HOTEN"].ToString();
                kq.TENDN = tb.Rows[0]["TENDN"].ToString();
                kq.EMAIL = tb.Rows[0]["EMAIL"].ToString();
                kq.MATKHAU = tb.Rows[0]["MATKHAU"].ToString();
            }
            else
                kq.MA = 0;
            return kq;


        }

    }
}