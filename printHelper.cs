using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.SessionState;

/// <summary>
/// Summary description for PrintHelper
/// </summary>
/// 
public class PrintHelper
{
    public PrintHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void PrintWebControl(Control ctrl)
    {
        // امر طباعة للكنترول
        PrintWebControl(ctrl, "<script type=\"text/javascript\" src=\"/js/jquery.js\"></script><script type=\"text/jscript\">$(\"#gdRows tr td\").each(function (){var cell = $.trim($(this).text());if (cell.length == 0) {$(this).parent().hide();} });</script>");
    }

    public static void PrintWebControl(Control ctrl, string Script)
    {
        // نسخة من الكلاس سترينج رايتر النصي 
        // ثم نكون الكونترول المراد طباعته لاننا نضع اي شئ نريد طباعته في كونترول مثل جدول او ديف او اي شئ اخر
        StringWriter stringWrite = new StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        if (ctrl is WebControl)
        {
            Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
        }
        // هنا نكون الصفحة 
        Page pg = new Page();
        pg.EnableEventValidation = false;
        if (Script != string.Empty)
        {
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
        }
        // ثم نكون الفورم الذي يحوي كل ذلك
        HtmlForm frm = new HtmlForm();
        //HtmlHead hd = new HtmlHead();
        //pg.Controls.Add(hd);
        //hd.Attributes.Add("runat", "server");
        //hd.InnerHtml="<script type=\"text/javascript\" src=\"../../ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js\"></script>";

        pg.Controls.Add(frm);
        frm.Attributes.Add("runat", "server");
        frm.Attributes["dir"] = "rtl";

        frm.Controls.Add(ctrl);
        //frm.InnerHtml += " <script type=\"text/javascript\" src=\"../../ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js\"></script>";
        //frm.InnerHtml += "<script type=\"text/jscript\">$(\"#gdRows tr td\").each(function (){var cell = $.trim($(this).text());if (cell.length == 0) {$(this).parent().hide();} });</script>";
        pg.DesignerInitialize();
        pg.RenderControl(htmlWrite);
        string strHTML = stringWrite.ToString();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(strHTML);
        //HttpContext.Current.Response.Write(" <script type=\"text/javascript\" src=\"Scripts/jquery-1.6.4.min.js\"></script>");

        // HttpContext.Current.Response.Write("<script type=\"text/jscript\">$(\".visits tr td \").each(function () {var cell = $.trim($(this).text());if (cell.length == 0) {$(this).parent().hide()}});$(\"#gdRows tr td\").each(function (){var cell = $.trim($(this).text());if (cell.length == 0) {$(this).parent().hide();} });</script>");

        HttpContext.Current.Response.Write("<script>window.print();</script>");
        HttpContext.Current.Response.Write("<style> .tbl_style, .tbl_style th, .tbl_style tr, .tbl_style td{ border: 1px solid black; color:black; text-align:center !important;}</style>");
        HttpContext.Current.Response.End();



    }
}
