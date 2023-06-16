using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;
namespace TestMenuStrip
{
   static  public class DataBase
    {
        static SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-2FB2RPPB;Initial Catalog=Register;Integrated Security=True; Encrypt=True;TrustServerCertificate=Yes");

        static public void openSqlConnection()
        {
            if(sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        static public void closeSqlConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        static public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
