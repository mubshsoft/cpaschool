<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActvateAssignment_StudentList.aspx.cs" Inherits="ActvateAssignment_StudentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Activate Student Info</title>
   <link rel="stylesheet" href="~/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="~/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="~/css/sl-slide.css"/>
    <link rel="stylesheet" href="~/css/main.css"/>
    <script type="text/javascript">
    function closewin()
    {
    self.close();
    }
    </script>
    <style>.btn-success {background:#0e245d!important;}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row-fluid">
    <div class="span12 form_head">
    Activate Student Info
    </div>
    </div>
    <div class="row-fluid">
    <div class="span12">
     <fieldset> 
      <div class="row-fluid">
    <div class="span12 center"><h4>De-Activated Student List</h4>
    </div>
    </div>
    <div class="row-fluid">
    <div class="span12">
                                                               <asp:GridView ID="grdInActiveStudent" runat="server" AutoGenerateColumns="False"  CssClass="table"
                                                    Width="100%" AllowPaging="True" PageSize="10"    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                                        onpageindexchanging="grdInActiveStudent_PageIndexChanging" >
                                                        <HeaderStyle Font-Bold="true" BackColor="ActiveBorder" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                      <EmptyDataTemplate>
                                                     <h4>No students for activate</h4>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student name"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblname" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbluserid" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "userid")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="AssignmentCode "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "AsgnCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Semester "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsemtitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "semestertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField>
                                                        <ItemTemplate>
                                                        <asp:CheckBox id="chk" runat="server"/>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                  
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                </div></div>
                                                       </fieldset>
    </div></div>
    <div class="row-fluid">
    <div class="span12 center">
    <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" onclick="btnSave_Click"/>&nbsp;
    <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server" onclick="btnClose_Click"  />
     </div>
    </div>
    <div class="row-fluid">&nbsp;</div>
     <div class="row-fluid">
    <div class="span12">
    <fieldset> 
      <div class="row-fluid">
    <div class="span12 center"><h4>Activated Student List</h4>
    </div>
    </div>
    <div class="row-fluid">
    <div class="span12">                                       
                       <asp:GridView ID="grdActveStudent" runat="server" AutoGenerateColumns="False"  CssClass="table"
                                                    Width="100%"  AllowPaging="True" PageSize="10"    
                                                            PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                            onpageindexchanging="grdActveStudent_PageIndexChanging" 
                                                            onrowcommand="grdActveStudent_RowCommand" >
                                                    
                                                        <HeaderStyle Font-Bold="true" BackColor="ActiveBorder" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student name"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "userid")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="AssignmentCode "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "Asgncode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Semester "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsem" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "semestertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Paper Title "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpaper" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Activate"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactvate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "activate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                  
                                                       <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("id") %>'>
                                                                     Deactivate</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                        
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
   </div>
    </div>
                                              </fieldset>
                                                </div>
                                                </div>
    
    </form>
</body>
</html>
