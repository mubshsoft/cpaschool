<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActvateScreening_StudentList.aspx.cs" Inherits="ActvateScreening_StudentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Activate Student Info</title>
   <link href="../Stylesheet/gridStyle.css"type="text/css" rel="stylesheet" />
   <link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="../css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../css/sl-slide.css"/>
    <link rel="stylesheet" href="../css/main.css"/>
    <script type="text/javascript">
    function closewin()
    {
    self.close();
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table width="700" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">Activate Student Info</strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;">
                                                <table width="650px">
                                               
                                                   
                                                    <tr>
                                                        <td width="300px" align="right">
                                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td width="200px" align="left" >
                                                              <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-large btn-primary" onclick="btnSearch_Click" /></td>
                                                    </tr>
                                               
                                                   
                                                    <tr>
                                                        <td colspan="2">
                                                           <asp:DropDownList ID="ddlYear" runat="server" ToolTip="Year" 
                                                                AutoPostBack="true" CssClass="form-control" 
                                                                onselectedindexchanged="ddlYear_SelectedIndexChanged">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                 
                                                    <tr>
                                                        <td class="style5" align="center" style="padding-right:10px; " 
                                                            colspan="2">
                                           <fieldset> 
                                            <legend style="font-family: Verdana; font-size: 11px; font-weight: bold"><b>
                                                List of students for screening</b></legend>
                                           <br />
                                                               <asp:GridView ID="grdInActiveStudent" runat="server" AutoGenerateColumns="False" CssClass="table" 
                                                    Width="100%" AllowPaging="True" PageSize="20"    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                                        onpageindexchanging="grdInActiveStudent_PageIndexChanging" >
                                                        <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No students for activate </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="3%">
                                                                                        <ItemTemplate>
                                                                                            <%# (grdInActiveStudent.PageSize * grdInActiveStudent.PageIndex) + Container.DisplayIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
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
                                                        
                                                          <asp:TemplateField HeaderText="ScreeningCode "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "ScrCode")%>'></asp:Label>
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
                                                       </fieldset> </td>
                                                    </tr>
                                                    <tr>
                                                    <td colspan="2" align="center">
                                                            <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" 
                                                                onclick="btnSave_Click"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server" 
                                                                onclick="btnClose_Click"  />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td class="style5" align="center">
                                           <fieldset> 
                                            <legend style="font-family: Verdana; font-size: 11px; font-weight: bold"><b>
                                                Activated Student List</b></legend>
                                           <br />
                                           
                                                               <asp:GridView ID="grdActveStudent" runat="server" AutoGenerateColumns="False" CssClass="table" 
                                                    Width="100%"  AllowPaging="True" PageSize="10"    
                                                            PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                            onpageindexchanging="grdActveStudent_PageIndexChanging" 
                                                            onrowcommand="grdActveStudent_RowCommand" >
                                                    
                                                        <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="3%">
                                                                                        <ItemTemplate>
                                                                                            <%# (grdActveStudent.PageSize * grdActveStudent.PageIndex) + Container.DisplayIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
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
                                                        
                                                          <asp:TemplateField HeaderText="ScreeningCode "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "scrcode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                               
                                                
                                                           <asp:TemplateField HeaderText="Activate "><%--<ItemStyle Width="110px" />--%>
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
                                              </fieldset>
                                                </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
    </div>
    </form>
</body>
</html>
