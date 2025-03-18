<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="querybuilder.aspx.cs" Inherits="new_store.querybuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ahmedStoreRConnectionString1 %>' SelectCommand="SELECT customer_1.customer_name, bill_sale.id, stocks_1.name, stocks_1.Id AS Expr1, '0' AS cash_id, bill_sale.value - ISNULL((SELECT total FROM back_sale WHERE (id = bill_sale.back_id)), 0) AS value, bill_sale.payment, (SELECT SUM(debit) - SUM(borrower) AS Expr1 FROM customer_accounts AS sm WHERE (customer_id = customer_1.id)) AS acount_customer, bill_sale.date FROM bill_sale INNER JOIN customer AS customer_1 ON bill_sale.customer_id = customer_1.id INNER JOIN stocks AS stocks_1 ON bill_sale.stock_id = stocks_1.Id WHERE (bill_sale.date BETWEEN CONVERT (date, @first, 103) AND CONVERT (date, @end , 103)) AND (bill_sale.bill_type = 'فاتورة بيع') AND (stocks_1.Id = @stocks)">
            <SelectParameters>
                <asp:Parameter Name="first"></asp:Parameter>
                <asp:Parameter Name="end"></asp:Parameter>
                <asp:Parameter Name="stocks"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
