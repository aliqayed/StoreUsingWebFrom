using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace new_store
{
    public partial class setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    DataSet ds = datamanger.getdataset("select * from setting where id=" + Convert.ToInt32(Request.QueryString["id"].ToString()), "table");
                    txt_name.Text = ds.Tables["table"].Rows[0]["name"].ToString();

                    txt_details.Text = ds.Tables["table"].Rows[0]["details"].ToString();
                    txt_numbers.Text = ds.Tables["table"].Rows[0]["numbers"].ToString();
                    DropDownList3.SelectedValue = ds.Tables["table"].Rows[0]["main_print"].ToString();
                    divedit.Visible = true;
                }
               
            }

            DataSet ds1 = datamanger.getdataset("select * from setting ", "table");
            if (ds1.Tables[0].Rows.Count == 0)
            {
                divedit.Visible = true;
            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string image;
                if (FileUpload1.FileName == "")
                {
                    image = "";
                    datamanger.exexutenonquery("update setting set name=N'" + txt_name.Text + "',details=N'" + txt_details.Text + "',numbers=N'" + txt_numbers.Text + "',main_print='" + DropDownList3.SelectedValue + "' where id =" + Request.QueryString["id"]);

                }
                else
                {
                    image = FileUpload1.FileName;
                    string tmpPath = Server.MapPath("image_logo/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(tmpPath);
                    datamanger.exexutenonquery("update setting set name=N'" + txt_name.Text + "',details=N'" + txt_details.Text + "',numbers=N'" + txt_numbers.Text + "',image=N'" + image + "',main_print='" + DropDownList3.SelectedValue + "' where id =" + Request.QueryString["id"]);

                }
                GridView1.DataBind();
                Response.Redirect("setting.aspx");

            }
            else
            {
                string image;
                if (FileUpload1.FileName == "")
                {
                    image = "";
                    datamanger.exexutenonquery("insert into  setting (name,details,numbers,main_print) values ('" + txt_name.Text + "','" + txt_details.Text + "','" + txt_numbers.Text + "','" + DropDownList3.SelectedValue + "')");

                }
                else
                {
                    image = FileUpload1.FileName;
                    string tmpPath = Server.MapPath("image_logo/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(tmpPath);
                    datamanger.exexutenonquery("insert into  setting (name,details,numbers,main_print,image) values ('" + txt_name.Text + "','" + txt_details.Text + "','" + txt_numbers.Text + "','" + DropDownList3.SelectedValue + "','" + image + "')");

                }
                GridView1.DataBind();    
                Response.Redirect("setting.aspx");
            }
           

        }

    }
}