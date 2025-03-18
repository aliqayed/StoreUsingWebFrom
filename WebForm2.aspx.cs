using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace new_store
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DateTime d = DateTime.Now;
            //string dd = d.Month.ToString();
            //string servername = "";
            //string db_name="";
            ////string aaa= @"Data Source=.\SQLEXPRESS;Integrated Security=True;;AttachDbFilename=|DataDirectory|\store.mdf"
            //string aaa = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\store.mdf;Integrated Security=True; user instance = True;";
            //SqlConnection con = new SqlConnection(aaa);
            //con.Open();
            //string str = "USE" +db_name+";"    ;
            //string str1 = "BACKUP DATABASE" + db_name + "TO DISK=D:\\new\\" + db_name + ".BAK";
            datamanger.exexutenonquery("BACKUP DATABASE [store.mdf] TO  DISK = 'D:\\new\\store.mdf.bak'");
        }
    }
}