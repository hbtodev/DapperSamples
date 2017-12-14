using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DapperSample.Infrastructure
{
    public class DataBase
    {
        private SqlConnection sqlCon;
        private string strConnection = string.Empty;

        public DataBase()
        {
            try
            {
                this.strConnection = ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SqlConnection Connect()
        {
            try
            {
                if (this.strConnection != string.Empty)
                {
                    sqlCon = new SqlConnection(this.strConnection);
                    sqlCon.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            
            return sqlCon;
        }

        public bool Disconect()
        {
            bool ret = false;

            try
            {
                if (this.sqlCon.State == System.Data.ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return ret;
        }
    }
}
