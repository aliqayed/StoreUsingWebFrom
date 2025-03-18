using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;


namespace new_store
{
    public partial class query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                datamanger.exexutenonquery(TextBox1.Text);
                Label1.Text = "success";
            }
            catch (Exception l)
            {

                Label1.Text = l.Message;
            }
        }
    }
}