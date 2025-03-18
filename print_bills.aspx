<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print_bills.aspx.cs" Inherits="new_store.print_bills" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        th, td {
            padding: 5px;
        }
    </style>
    <style>
        body, table th, table tr, table td, input {
            font-family: "Times New Roman", Times, serif !important;
        }
    </style>
    <style type="text/css" media="print">
        .nonPrintable {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div dir="rtl" id="type_print" runat="server"
            style="border: thin solid #FF0000; height: auto; min-height: 29cm; width: 28cm; right: 0px; margin-right: auto; margin-bottom: 0; margin-left: auto;"
            align="right">

            <div style="width: 97%; padding: 10px; margin: auto; height: 68px; border-radius: 10px" runat="server" id="head1">
                <div id="div_right" runat="server" style="width: 20%; padding-top: 20px; padding-right: 10px; float: right; font-weight: bold; font-size: 24px">
                    01270300148:<asp:Image ID="Image1" runat="server" ImageUrl="~/image/1200px-WhatsApp.jpg" Width="22px" />
                    <br />
                    01270719145:<asp:Image ID="Image2" runat="server" ImageUrl="~/image/1200px-WhatsApp.jpg" Width="22px" />

                </div>
                <div id="div_center" runat="server" style="text-align: center; width: 60%; float: right">
                    <div style="width: 100%">
                        <span style="font-size: 80px; font-weight: bold">سنتر وش السعد</span>
                        <br />
                        <span style="font-size: 19px; font-weight: bold">لتجارة الملابس الجاهزه</span>
                        <input id="Button2" type="button" value="طباعة" class="nonPrintable" onclick="window.print();" />
                    </div>
                </div>


                <div style="float: left; font-weight: bold; font-size: 24px; padding-top: 20px">
                    م:01111588429
                    <br />
                    ت:0235407562
                </div>

            </div>
            <div style="width: 100%; text-align: center; clear: both; font-weight: bold"><span>البيان </span>
                <asp:Label ID="id_bill_sale" runat="server" ForeColor="Red" Text=""></asp:Label></div>

            <div style="width: 100%; font-weight: bold">
                <div id="div1" runat="server" style="width: 36%; padding-right: 10px; float: right">
                    <div style="width: 100%; padding-right: 10px;font-size:22px">
                        التاريخ : (<asp:Label ID="lbl_date" runat="server" Text="Label"></asp:Label>)
                    </div>
                </div>
                <div id="div5" runat="server" style="float: right; width: 46%">
                    <div style="width: 100%; font-size: 25px; font-weight: bold">
                        ادارة المعلم / مبروك وصفى
                    </div>

                </div>
                <div id="div2" runat="server" style="float: right; width: 15%">
                    <div style="width: 100%">
                        اسم البائع: (<asp:Label ID="lbl_buyer" runat="server" Text="Label"></asp:Label>)
                    </div>
                </div>
            </div>

            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:ahmedStoreRConnectionString1 %>' SelectCommand="SELECT TOP (1) date, cash_id, bill_id, customer_id FROM customer_accounts WHERE (bill_id < 8102) AND (cash_id <> 0) AND (customer_id = 190) ORDER BY id DESC"></asp:SqlDataSource>

            <div style="width: 100%; font-weight: bold">
                <div id="div3" runat="server" style="width: 82%; padding: 10px; float: right">
                    <div style="width: 50%; padding-right: 10px; float: right;font-size:23px">
                        العميل :          &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;(<asp:Label ID="lbl_customer" runat="server" Text="Label"></asp:Label>)
                        <div style="font-size:15px">
                        تاريخ اخر فاتورة :          &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;(<asp:Label ID="lbl_last_date" runat="server" AutoPostBack="True" Text="0"></asp:Label>)
                        عدد الايام :          &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;(<asp:Label ID="lbl_day_number_last_bill" runat="server" Text="222"></asp:Label>)
                        تاريخ اخر دفعة :          &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;(<asp:Label ID="lbl_last_date_cash" runat="server"></asp:Label>)
                        عدد الايام :          &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;(<asp:Label ID="lbl_day_number_last_cash" runat="server" ></asp:Label>)
                            </div>

                    </div>
                    <div style="width: 48%; padding-right: 10px; float: left; font-size: 20px; font-weight: bold"></div>
                    يامسهل الحال يارب
                </div>
                <div id="div4" runat="server" style="float: right; padding-top: 10px; width: 15%">
                    <div style="width: 100%">
                        الوقت : (<asp:Label ID="lbl_time" runat="server" Text="00:00"></asp:Label>)
                    </div>
                </div>
            </div>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server"></asp:SqlDataSource>






            <div style="width: 100%">
                <div id="bill_sale" runat="server" style="width: 52%; margin: 5px; padding: 5px; float: right; min-height: 17.5cm; border: solid">
                    <div style="width: 99%; text-align: center; font-weight: bold; border: solid; border-radius: 10px; font-size: 22px">بيان اسعار</div>

                    <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="25" Style="width: 100%; text-align: center; border: solid; border-radius: 10px; margin-top: 2px; font-size: 19px; font-weight: bold" HeaderStyle-BackColor="#999999" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="م">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="total_after" HeaderText="الاجمالى" SortExpression="total_after"></asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="العدد" SortExpression="amount"></asp:BoundField>
                            <asp:BoundField DataField="unit_price" HeaderText="فئة" SortExpression="unit_price"></asp:BoundField>
                            <asp:BoundField DataField="item_name" HeaderText="الصنف" SortExpression="item_name" ItemStyle-Font-Size="17px"></asp:BoundField>
                            <asp:BoundField DataField="id" HeaderText="الكود" SortExpression="id" ItemStyle-Font-Size="17px"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ahmedStoreRConnectionString1 %>' SelectCommand="SELECT item.item_name, report_sale.amount, report_sale.unit_price, report_sale.total_after FROM report_sale INNER JOIN item ON report_sale.item_id = item.id WHERE (report_sale.bill_id = @bill_id)">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id_bill" DefaultValue="0" Name="bill_id"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <div style="width: 99%; text-align: center; font-weight: bold;">
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">اجمالى العدد</div>
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">
                            <asp:Label ID="lbl_sales_amount" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                    <div style="width: 99%; text-align: center; font-weight: bold;">
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">اجمالى المبيعات</div>
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">
                            <asp:Label ID="lbl_sum_sale" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>

                <div id="bill_back" runat="server" style="width: 41%; margin: 5px; padding: 5px; float: right; min-height: 17.5cm; border: solid">
                    <div style="width: 99%; text-align: center; font-weight: bold; border: solid; border-radius: 10px; font-size: 22px">المرتجع </div>
                    <asp:GridView ID="GridView2" OnRowDataBound="GridView2_RowDataBound" AllowPaging="true"  PageSize="25" Style="width: 100%; text-align: center; border: solid; border-radius: 10px; margin-top: 2px; font-size: 19px; font-weight: bold" HeaderStyle-BackColor="#999999" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView2_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="total" HeaderText="الاجمالى" SortExpression="total"></asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="العدد" SortExpression="amount"></asp:BoundField>
                            <asp:BoundField DataField="price" HeaderText="فئة" SortExpression="price"></asp:BoundField>
                            <asp:BoundField DataField="item_name" HeaderText="الصنف" SortExpression="item_name" ItemStyle-Font-Size="17px"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ahmedStoreRConnectionString1 %>' SelectCommand="SELECT item.item_name, report_back_sale.amount, report_back_sale.price, report_back_sale.total FROM item INNER JOIN report_back_sale ON item.id = report_back_sale.item_id WHERE (report_back_sale.back_sale_id = @back_id)">
                        <SelectParameters>
                            <asp:SessionParameter SessionField="back_id" Name="back_id"></asp:SessionParameter>

                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <div style="width: 99%; text-align: center; font-weight: bold;">
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">اجمالى العدد</div>
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">
                            <asp:Label ID="lbl_back_amount" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                    <div style="width: 99%; text-align: center; font-weight: bold;">
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">اجمالى المرتجع</div>
                        <div style="width: 47%; border: solid; float: right; font-size: 20px">
                            <asp:Label ID="lbl_sum_back" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both">
                <hr />
                <table style="width: 98%; margin: auto; border: solid; border-radius: 10px">
                    <tr style="font-size: 24px">
                        <th>ما قبل</th>
                        <th>البيان الحالى</th>
                        <th>اجمالى الحساب</th>
                        <th>المبلغ المدفوع</th>
                        <th>الباقى</th>
                    </tr>
                    <tr style="font-size: 21px">
                        <th>
                            <asp:Label ID="last_dept" runat="server" Text="0"></asp:Label></th>
                        <th>
                            <asp:Label ID="lbl_buan_hala" runat="server" Text="0"></asp:Label></th>
                        <th>
                            <asp:Label ID="sum_aconut" runat="server" Text="0"></asp:Label></th>
                        <th>
                            <asp:Label ID="payment" runat="server" Text="0"></asp:Label></th>
                        <th>
                            <asp:Label ID="rest" runat="server" Text="0"></asp:Label></th>
                    </tr>
                </table>
                <hr />
                <table style="width: 98%; margin: auto; border: solid; border-radius: 10px">
                    <tr style="width: 100%; background-color: #999999">
                        <td style="font-size: 22px; text-align: center; font-weight: bold;">المرتجع خلال 15 يوم
                        </td>
                        <td style="font-size: 22px; text-align: center; font-weight: bold;">استلام المرتجع بالسعر الحالى
                        </td>
                        <td style="font-size: 22px; text-align: center; font-weight: bold;">لايتم استلام المرتجع بدون البيان
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
