using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
namespace new_store
{
    public partial class print_bills : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_bill = Request.QueryString["id_bill"].ToString();
            id_bill_sale.Text = id_bill;
            ds = datamanger.getdataset("select payment,total,value, last_dept,date,final_account,date_add,emp_id,customer_id,back_id from bill_sale where id=" + Convert.ToInt32(id_bill), "table");
            Session["back_id"] = ds.Tables["table"].Rows[0]["back_id"].ToString();
            GridView2.DataBind();
            lbl_sum_sale.Text = ds.Tables["table"].Rows[0]["value"].ToString();
            payment.Text = ds.Tables["table"].Rows[0]["payment"].ToString();
            last_dept.Text = ds.Tables["table"].Rows[0]["last_dept"].ToString();
            lbl_sales_amount.Text = ds.Tables["table"].Rows[0]["final_account"].ToString();
            lbl_date.Text = Convert.ToDateTime(ds.Tables["table"].Rows[0]["date"]).ToShortDateString();
            lbl_time.Text = Convert.ToDateTime(ds.Tables["table"].Rows[0]["date_add"]).ToShortTimeString();
            string emp_id = ds.Tables["table"].Rows[0]["emp_id"].ToString();

            string customer_id = ds.Tables["table"].Rows[0]["customer_id"].ToString();

            try
            {

                lbl_last_date.Text = datamanger.executescalar1("SELECT TOP (1) date FROM bill_sale WHERE (date <= convert(date, '" + lbl_date.Text + "',103)) AND (customer_id = " + customer_id + ") and id<>" + id_bill + " ORDER BY id DESC").ToString();
                lbl_last_date.Text = Convert.ToDateTime(lbl_last_date.Text).ToShortDateString();
                lbl_day_number_last_bill.Text = (Convert.ToDateTime(lbl_date.Text) - Convert.ToDateTime(lbl_last_date.Text)).TotalDays.ToString();
            }
            catch
            {
            }
            try
            {
                lbl_last_date_cash.Text = datamanger.executescalar1("SELECT TOP (1) date FROM customer_accounts WHERE (date <= convert(date, '" + lbl_date.Text + "',103)) AND (cash_id <> 0) AND (customer_id = " + customer_id + ") ORDER BY id DESC").ToString();
                lbl_last_date_cash.Text = Convert.ToDateTime(lbl_last_date_cash.Text).ToShortDateString();
                lbl_day_number_last_cash.Text = (Convert.ToDateTime(lbl_date.Text) - Convert.ToDateTime(lbl_last_date_cash.Text)).TotalDays.ToString();
            }
            catch
            {
            }

            try
            {
                lbl_back_amount.Text = datamanger.executescalar1("select final_account from back_sale where id=" + ds.Tables["table"].Rows[0]["back_id"].ToString()).ToString();
            }
            catch
            {


            }



            try
            {
                lbl_sum_back.Text = datamanger.executescalar1(" select total from back_sale where id =" + Convert.ToInt32(Session["back_id"].ToString())).ToString();

            }
            catch (Exception)
            {
                lbl_sum_back.Text = "0";

            }
            lbl_buan_hala.Text = (Convert.ToDouble(lbl_sum_sale.Text) - Convert.ToDouble(lbl_sum_back.Text)).ToString();
            sum_aconut.Text = (Convert.ToDouble(last_dept.Text) + Convert.ToDouble(lbl_buan_hala.Text)).ToString();
            rest.Text = (Convert.ToDouble(sum_aconut.Text) - Convert.ToDouble(payment.Text)).ToString();

            lbl_buyer.Text = datamanger.executescalar1("select name from employees where id=" + Convert.ToInt32(emp_id)).ToString();
            lbl_customer.Text = datamanger.executescalar1("select customer_name from customer where id=" + Convert.ToInt32(customer_id)).ToString();

            DataSet ds1 = datamanger.getdataset("SELECT item.id,item.item_name, report_sale.amount, report_sale.unit_price, report_sale.total_after FROM report_sale INNER JOIN item ON report_sale.item_id = item.id WHERE report_sale.bill_id =" + Request.QueryString["id_bill"].ToString(), "table");
            ViewState["ds"] = ds1;

            int rest_1 = ds1.Tables[0].Rows.Count % 25;
            if (rest_1 != 0)
            {
                for (int i = rest_1; i < 25; i++)
                {
                    DataRow newrow = ds1.Tables["table"].NewRow();
                    newrow["item_name"] = " ";
                    newrow["amount"] = "0";
                    newrow["unit_price"] = "0";
                    newrow["total_after"] = "0";
                    ds1.Tables["table"].Rows.Add(newrow);
                    ViewState["ds"] = ds1;
                }
            }

            DataSet ds2 = datamanger.getdataset("SELECT item.item_name, report_back_sale.amount, report_back_sale.price, report_back_sale.total FROM report_back_sale INNER JOIN item ON report_back_sale.item_id = item.id WHERE report_back_sale.back_sale_id =" + Session["back_id"].ToString(), "table2");
            ViewState["ds2"] = ds2;


            for (int i = ds2.Tables[0].Rows.Count; i < ds1.Tables[0].Rows.Count; i++)
            {
                DataRow newrow = ds2.Tables["table2"].NewRow();
                newrow["item_name"] = " ";
                newrow["amount"] = "0";
                newrow["price"] = "0";
                newrow["total"] = "0";
                ds2.Tables["table2"].Rows.Add(newrow);
                ViewState["ds2"] = ds2;
            }


            GridView1.DataSource = ds1;
            GridView1.DataBind();
            //if (GridView1.PageCount > 1)
            //{
            //    head1.Visible = true;

            //}
            GridView2.DataSource = ds2;
            GridView2.DataBind();


            if (GridView2.Rows.Count < 1)
            {
                bill_sale.Visible = true;
                bill_sale.Style["width"] = "50%";
                bill_back.Visible = false;
            }
            if (GridView1.Rows.Count < 1)
            {
                bill_back.Visible = true;
                bill_back.Style["width"] = "50%";
                bill_sale.Visible = false;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "0")
                {              
                    e.Row.Cells[1].Text = " ";
                    e.Row.Cells[2].Text = " ";
                    e.Row.Cells[3].Text = " ";                                
                }
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "0")
                {
                    e.Row.Cells[1].Text = " ";
                    e.Row.Cells[2].Text = " ";
                    e.Row.Cells[3].Text = " ";
                }
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.PageIndex = e.NewSelectedIndex;
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
          // GridView1_PageIndexChanging(sender, e);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            GridView2_PageIndexChanging(sender, e);
           
        }

    }
}