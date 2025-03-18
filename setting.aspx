<%@ Page Title="الاعددات" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="new_store.setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid p-0">
                <!-- Page Content -->
                <div class="panel panel-danger">
                    <div class="panel-heading">
                        الطباعة
                    </div>
                    <div class="panel-body">
                        <div class="grey-box">
                            
                                <div class="row">
                                       <div class="col-md-2 col-sm-6">
                                        <div class="form-label-group">
                                            <asp:TextBox ID="txt_name" class="form-control" placeholder="" runat="server"></asp:TextBox>
                                            <label for="">اسم الشركة</label>
                               <asp:RequiredFieldValidator Text="*" ForeColor="Red" ControlToValidate="txt_name" ID="RequiredFieldValidator3" ValidationGroup="a" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                       <div class="col-md-3 col-sm-6">
                                        <div class="form-label-group">
                                            <asp:TextBox ID="txt_details" class="form-control" placeholder="" runat="server"></asp:TextBox>
                               <asp:RequiredFieldValidator Text="*" ForeColor="Red" ControlToValidate="txt_details" ID="RequiredFieldValidator2" ValidationGroup="a" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

                                            <label for="">تفاصيل الشركة</label>
                                        </div>
                                    </div>
                                       <div class="col-md-3 col-sm-6">
                                        <div class="form-label-group">
                                            <asp:TextBox ID="txt_numbers" class="form-control" placeholder="" runat="server"></asp:TextBox>
                               <asp:RequiredFieldValidator Text="*" ForeColor="Red" ControlToValidate="txt_numbers" ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

                                            <label for="">الارقام</label>
                                        </div>
                                    </div>

                                       <div class="col-md-3 col-sm-6">
                                        <div class="form-label-group">
                                            <asp:FileUpload ID="FileUpload1" class="dropify" runat="server" />
                                            <label for="">لوجو</label>
                                        </div>
                                    </div>
                                  
                                     <div class="col-md-3 col-sm-6">
                                        <div class="form-label-group-custome">
                                            <asp:DropDownList class="form-control select2" ID="DropDownList3"  runat="server">
                                                <asp:ListItem Value="0">نوع الطباعة</asp:ListItem>
                                                    <asp:ListItem Value="pages_print">كاملة</asp:ListItem>
                                                    <asp:ListItem Value="pages_print2">ريسيت</asp:ListItem>
                                                    <asp:ListItem Value="pages_print3">نصف</asp:ListItem>
                                            </asp:DropDownList>
                                          
                               <asp:RequiredFieldValidator Text="*" ForeColor="Red" ControlToValidate="DropDownList3" InitialValue="0" ID="RequiredFieldValidator5" ValidationGroup="a" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

                                            <label for="">حجم الفاتورة</label>
                                        </div>
                                    </div>

                                   <%-- <div class="col-md-3 col-sm-6" runat="server" id="divsave">
                                        <asp:Button ID="btnsave" class="btn btn-block btn-danger" OnClick="btnsave_Click" ValidationGroup="a" runat="server" Text="حفظ" />
                                    </div>--%>
                                    <div class="col-md-3 col-sm-6" runat="server" visible="false" id="divedit">
                                        <asp:Button ID="btnedit" class="btn btn-block btn-danger" OnClick="btn_add_Click" ValidationGroup="a" runat="server" Text="حفظ" />
                                    </div>
                                    <asp:Label ID="Label1" style="color:red;font-weight:bold" runat="server"></asp:Label>

                               
                            </div>
                       
                        <div class="ribbon-wrapper-reverse">
                            <div class="grey-box">
                                <div class="ribbon ribbon-bookmark ribbon-right ribbon-danger">اعدادات الطباعة</div>
                                <div class="table-responsive">
                                        <asp:GridView  ID="GridView1" runat="server" Width="100%" CssClass="color_style" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False" HeaderText="كود">
                                                    <ItemTemplate >
                                                        <a href='<%# "/setting.aspx?id=" + Eval("id") %>'><%#Eval("name")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                  <asp:BoundField DataField="details" HeaderText="التفاصيل" SortExpression="details"></asp:BoundField>
                                                  <asp:BoundField DataField="numbers" HeaderText="الارقام" SortExpression="numbers"></asp:BoundField>
                                               <asp:TemplateField ShowHeader="False" HeaderText="لوجو">
                                                    <ItemTemplate >
                                                        <asp:Image ID="Image1" ImageUrl='<%# "/image_logo/" + Eval("image") %>' runat="server" style="width:100px;height:100px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 
                                            </Columns>
                                        </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ahmedStoreRConnectionString1 %>' SelectCommand="SELECT Id, bill, name, name_size, details, details_size, numbers, numbers_size, type_pill, image, Height, Width, show, pill_add_user, name_tabib, name_tabib_size, id_type_print, div_center, div_right FROM setting">
                                        <SelectParameters>
                                         </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Page Content end -->
            </div>
           </div>
</asp:Content>
