using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace new_store
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ahmedStoreRConnectionString1"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "tabibsoft_login";
            con.Open();
            if (!IsPostBack)
            {
                Session.Clear();
                try
                {
                    DataSet ds = datamanger.getdataset("select * from backup_path", "path");
                    string path1 = "", path2 = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        path1 = ds.Tables[0].Rows[0]["path1"].ToString();
                        path2 = ds.Tables[0].Rows[0]["path2"].ToString();
                    }

                    string file_name = string.Format("{0:dd_MM_yyyy_HH_mm_ss}", DateTime.Now);
                    file_name = file_name + ".bak";

                    string physicalPath = Server.MapPath("~/App_Data/store.mdf");

                    string path = file_name;
                    string database = physicalPath;
                    string command = string.Format("BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT, NOINIT,  NAME = N'clinic-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", database, path);
                    string str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|datadirectory|\back_restore.mdf;Integrated Security=True;User Instance=True";
                    SqlConnection con1 = new SqlConnection(str);

                    SqlCommand cmd = new SqlCommand(command, con1);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    System.IO.File.Copy(@"C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\Backup\" + file_name, Server.MapPath("~/backup/" + file_name));
                    if (path1 != "")
                    {
                        System.IO.File.Copy(@"C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\Backup\" + file_name, path1 + "\\" + file_name);

                    }
                    if (path2 != "")
                    {
                        System.IO.File.Copy(@"C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\Backup\" + file_name, path2 + "\\" + file_name);

                    }

                    System.IO.File.Delete(@"C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\Backup\" + file_name);
                }
                catch (Exception c)
                {

                }
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            DataSet ds = datamanger.getdatasetstored("select_users", "user", new SqlParameter("@user_name", txt_name.Text),
                                                             new SqlParameter("@pass", txt_pass.Text));
            DataTable dt = ds.Tables["user"];
            if (dt.Rows.Count > 0)
            {
                Session["group_id"] = ds.Tables[0].Rows[0]["groupid"].ToString();
                Session["user_name"] = txt_name.Text;
                Session["emp_id"] = ds.Tables[0].Rows[0]["emp_id"].ToString();
                Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                //Session["store_id"] = datamanger.executescalar1("select store_id from employees where id=" + ds.Tables[0].Rows[0]["emp_id"].ToString());

                if (Request.QueryString["url"] != null)
                {
                    Response.Redirect(Request.QueryString["url"]);
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
            else
            {
                lbl_result.Text = "تأكد من كلمة المرور والاسم";
            }


        }
    }
}