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
using System.Web.UI;

/// <summary>
/// Summary description for Permissions
/// </summary>
///
namespace new_store
{
    public class Permissions
    {
        public static void set_permession(Page page1)
        {


            bool b = false;


            if (page1.Session["group_id"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                page1.Session["page"] = url;
                page1.Response.Redirect("/login.aspx?url=" + url);
            }
            else
            {
                string name = page1.Page.ToString().Substring(4, page1.Page.ToString().Substring(4).Length - 5);
                string[] s = name.Split('_');
                name = name.Remove(0, s[0].Length + 1);
                b = Convert.ToBoolean(datamanger.executescalar1("select " + name + " from [Groups] where GroupID =" + page1.Session["group_id"]));


            }

            if (!b)
            {
                page1.Response.Redirect("/not_allowed.aspx");

            }



        }
    }
}