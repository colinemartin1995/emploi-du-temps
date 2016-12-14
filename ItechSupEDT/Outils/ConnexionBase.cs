using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    public class ConnexionBase
    {
        private static ConnexionBase instance;

        private SqlConnection conn;
        public SqlConnection Conn
        {
            get { return this.conn; }
            private set { this.conn = value; }
        }

        public static ConnexionBase GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnexionBase();
            }

            return instance;
        }

        private ConnexionBase()
        {
            this.Conn = new SqlConnection();
            this.Conn.ConnectionString = "Data Source=DESKTOP-BBB5RFR\\SQLEXPRESS;Initial Catalog=edt;Integrated Security=True";
            this.Conn.Open();
        }
    }
}
