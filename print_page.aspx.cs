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

namespace clinic
{
    public partial class print_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // وضعت الكونترول المراد طباعته في سشن بكامل ما يحتوية من معلومات
            Control ctrl = (Control)Session["print"];
            // ثم اخبرت الكلاس الخاص بالطباعة بان ما سيطبعه هو الكونترول المرسل في سشن 
            PrintHelper.PrintWebControl(ctrl);


        }
    }
}