using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
namespace new_store
{
    public static class datamanger
    {
        static string constr = ConfigurationManager.ConnectionStrings["ahmedStoreRConnectionString1"].ToString();
        static DataSet ds;
        static SqlDataAdapter da;


        public static SqlParameter createparameter(string name, SqlDbType type, object value)
        {
            SqlParameter prm = new SqlParameter(name, value);
            prm.SqlDbType = type;
            return prm;
        }
        public static SqlParameter createparameter(string name, SqlDbType type, ParameterDirection dir)
        {
            SqlParameter prm = new SqlParameter(name, type);
            prm.Direction = dir;
            return prm;
        }
        public static DataSet getdataset(string query, string table)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, table);
            return ds;
        }
        public static DataSet getdatasetstored(string stored, string table, params SqlParameter[] prmarr)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter prm in prmarr)
            {
                cmd.Parameters.Add(prm);
            }
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, table);
            return ds;
        }
        public static void savedataset(string query, DataSet dsnew)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            SqlCommandBuilder sc = new SqlCommandBuilder(da);
            da.Update(dsnew, dsnew.Tables[0].TableName);
        }

        public static SqlDataReader getdatareader(string query, out SqlConnection con1)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            con1 = con;
           return cmd.ExecuteReader();

        }
        public static void exexutenonquery(string query)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static SqlDataReader getdatareaderstored(string stored, out SqlConnection con1, params SqlParameter[] prmarr)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter prm in prmarr)
            {
                cmd.Parameters.Add(prm);
            }
            con.Open();
            con1 = con;
            return cmd.ExecuteReader();

        }
        public static void exexutenonquerystored(string stored, params SqlParameter[] prmarr)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter prm in prmarr)
            {
                cmd.Parameters.Add(prm);
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static object executescalar(string stored, params SqlParameter[] prmarr)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter prm in prmarr)
            {
                cmd.Parameters.Add(prm);
            }
            con.Open();
            object o = cmd.ExecuteScalar();
            con.Close();
            return o;
        }
        public static object executescalar1(string query)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;

            con.Open();
            object o = cmd.ExecuteScalar();
            con.Close();
            return o;
        }
        public static Hashtable exexutenonquerystoredoutput(string stored, params SqlParameter[] prmarr)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(stored, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter prm in prmarr)
            {
                cmd.Parameters.Add(prm);
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Hashtable ht = new Hashtable();
            foreach (SqlParameter prm in prmarr)
            {
                if (prm.Direction == ParameterDirection.Output)
                    ht.Add(prm.ParameterName, prm.Value);
            }
            return ht;
        }
        public static double item_amount(string item_id, string store_id)
        {

            double amount = 0;
            string command = string.Format("select isnull(sum(amount_in,0))-isnull(sum(amount_out),0) where item_id={0} and store_id={1}", item_id, store_id);
            amount = Convert.ToDouble(datamanger.executescalar1(command));
            return amount;

        }
    }
}