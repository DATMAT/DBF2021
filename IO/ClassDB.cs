using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using System.Data;
using System.Data.SqlClient;

namespace IO
{ 
    public class ClassDB
    {
        private string connectionString;

        protected SqlConnection con;
        protected SqlCommand command;

        public ClassDB()
        {
            connectionString = @"Server=CVDB3,1455;Database=DanskBibliotekForening;Trusted_Connection=True;";
            con = new SqlConnection(connectionString);
        }
        public ClassDB (string inConnectionString)
        {
            connectionString = inConnectionString;
            con = new SqlConnection(connectionString);
        }
        protected void SetConnection(string inCon)
        {
            connectionString = inCon;
        }
        protected void OpenDB()
        {
            try
            {
                if (this.con != null && con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                else
                {
                    if (this.con == null)
                    {
                        con = new SqlConnection(connectionString);
                    }
                    CloseDB();
                    OpenDB();
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
        protected void CloseDB()
        {
            try
            {
                con.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
                throw;
            }
        }
        protected int ExecuteNonQuery(string sqlQuery)
        {
            int res = 0;
            command = new SqlCommand(sqlQuery, con);
            try
            {
                OpenDB();
                res = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }

        // står at den ikke behøver at være der meeeeen... ¯\_(ツ)_/¯.
        protected int DBExecuteScalar(string inSqlQuery)
        {
            int res = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(inSqlQuery, con))
                {
                    OpenDB();
                    res = (Int32)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }



            return res;
        }
        protected DataTable DbReturnDataTable(string sqlString)
        {
            DataTable dtRes = new DataTable();
            try
            {
                OpenDB();
                using (command = new SqlCommand(sqlString, con))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dtRes);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return dtRes;
        }

        protected string DbReturnString(string sqlString)
        {
            string sRes = "";
            try
            {
                OpenDB();
                using (command = new SqlCommand(sqlString, con))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    sRes = adapter.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return sRes;
        }
        protected List<string> DbReturnListString(string sqlString)
        {
            DataTable dttemp1 = new DataTable();
            List<string> lsRes = new List<string>();
            try
            {
                OpenDB();
                using (command = new SqlCommand(sqlString, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lsRes.Add(reader.GetString(0));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return lsRes;
        }
        protected bool DbReturnBool(string sqlString)
        {
            bool bRes = false;
            try
            {
                OpenDB();
                using (command = new SqlCommand(sqlString, con))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    bRes = Convert.ToBoolean(adapter);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseDB();
            }
            return bRes;
        }
    }
}
