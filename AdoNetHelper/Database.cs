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


        public int RunQuery(string query, List<SqlParameter> parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            int result = 0;

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        public int RunQuery(string query, params SqlParameter[] parameters)
        {
            return RunQuery(query, new List<SqlParameter>(parameters));
        }


        public void RunProc(string procName, List<SqlParameter> parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            int result = 0;

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

            return result;
        }

        public void RunProc(string procName, params SqlParameter[] parameters)
        {
            return RunQuery(procName, new List<SqlParameter>(parameters));
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

        public DataTable GetTable(string query, params SqlParameter[] parameters)
        {
            return GetTable(query, new List<SqlParameter>(parameters));
        }

    }
}
