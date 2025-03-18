<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="query.aspx.cs" Inherits="new_store.query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div dir="ltr">
     <asp:TextBox ID="TextBox1" runat="server" Height="182px" TextMode="MultiLine" 
        Width="751px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Button1" runat="server" Height="72px" onclick="Button1_Click" 
        Text="excute" Width="168px" />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="25pt"></asp:Label>
</p>
<p>
    &nbsp;</p>
</div>
    
</asp:Content>
