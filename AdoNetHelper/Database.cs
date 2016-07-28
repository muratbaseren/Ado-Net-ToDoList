using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetHelper
{
    public class Database
    {
        public string ConnectionString { get; private set; }


        public Database(string _connectionString)
        {
            ConnectionString = _connectionString;
        }


        public void RunQuery(string query, List<SqlParameter> parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());

                //foreach (SqlParameter param in parameters)
                //{
                //    cmd.Parameters.Add(param);
                //}
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable GetTable(string query, List<SqlParameter> parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Adaptor : otomatik bağlantı açar. Verileri çeker(sorguyu çalıştırır) ve bir datatable 'a doldurur ve bağlantıyı otomatik kapatır.

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

    }
}
