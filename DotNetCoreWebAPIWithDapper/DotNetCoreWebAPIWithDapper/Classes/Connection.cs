using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithDapper.Classes
{
    public class Connection
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());

        public void open_connection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            con.Open();
        }
        //==================================================================================================================//
        public void OpenDBConnection()
        {
            if (con != null && con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
        }

        public void CloseDBConnection()
        {
            if (con != null && con.State != System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}
