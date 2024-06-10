<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actvate_StudentList.aspx.cs" Inherits="Actvate_StudentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Activate Student Info</title>
   <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
   <link href="../css/main.css" type="text/css" rel="stylesheet" />
    <link href="../Stylesheet/gridStyle.css"type="text/css" rel="stylesheet" />
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
                                                        <td align="left" class="form_head">
                                                            Activate Student Info
                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;">
                                                <table width="700px">
                                               
                                                   
                                                    <tr>
                                                        <td width="260px" align="right" style="padding-right:20px">
                                                            </td>
                                                        <td width="40px" align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                 
                                                    <tr>
                                                        <td class="style5" align="center" style="padding-right:10px; " 
                                                            colspan="2">
                                           <fieldset> 
                                            <legend style="font-family: Verdana; font-size: 11px; font-weight: bold"><b>
                                                De-Activated Student List</b></legend>
                                           <br />
                                           
                                                               <asp:GridView ID="grdInActiveStudent" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%" AllowPaging="True" PageSize="10"    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                                        onpageindexchanging="grdInActiveStudent_PageIndexChanging" >
                                                        <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
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
                                                        
                                                          <asp:TemplateField HeaderText="ExamCode "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "examcode")%>'></asp:Label>
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
                                                       </fieldset> </td>
                                                    </tr>
                                                    <tr>
                                                    <td width="150px" align="right" style="padding-right:20px">
                                                            &nbsp;</td>
                                                        <td width="150px" style="width: 300px" align="left">&nbsp;
                                                            <asp:Imagebutton ID="btnSave" ImageUrl="../Images/save.png" runat="server" 
                                                                onclick="btnSave_Click"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:Imagebutton ID="btnClose" ImageUrl="../Images/close.png" runat="server"  />
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
                                           
                                                               <asp:GridView ID="grdActveStudent" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%"  AllowPaging="True" PageSize="10"    
                                                            PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                            onpageindexchanging="grdActveStudent_PageIndexChanging" 
                                                   onrowcommand="grdActveStudent_RowCommand" >
                                                    
                                                        <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                  
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
                                                        
                                                          <asp:TemplateField HeaderText="ExamCode "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode0" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "examcode")%>'></asp:Label>
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
