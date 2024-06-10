<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSection.aspx.cs" Inherits="Admin_AddQuestion" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Section</title>
 <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
                     }
    </script>
    
     <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
  
    <div onkeypress="javascript:HideMessage()">
  
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td height="127" align="left" valign="top">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">
                                                            <asp:Label ID="lblCaption" runat="server" />
                                                            </strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b"><b>Back To 
                                                            Admin Panel</b></font></a></strong>&nbsp; <strong class="style9_sec">
                                                                    <a href="../logout.aspx" class="part1"><font color="#4b4b4b"><b>Logout</b></font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 0px; padding-bottom: 20px;">
                                                <table width="280px" align="center">
                                                <tr>
                                                        <td width="150px">
                                                            &nbsp;
                                                        </td>
                                                        <td width="150px" align="left" valign="middle">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td  colspan="2" align="center">
                                                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td align="right" style="padding-right:10px">
                                                            <asp:Label ID="lblImage" runat="server" Text="New Section : "></asp:Label>
                                                        </td>
                                                        <td  width="60%" align="left">
                                                            <asp:TextBox ID="txtCategory" runat="server" Width="120px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                  
                                                   <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                                                     <tr>
                                                        <td width="150px">
                                                            &nbsp;
                                                        </td>
                                                        <td width="150px" align="left" valign="middle">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            &nbsp;
                                                        </td>
                                                        <td  align="left" valign="middle" style="padding-right:36px">
                                                            <asp:ImageButton ID="btnSave" runat="server"  
                                                                ImageUrl="../Images/SaveAndContinue.png" onclick="btnSave_Click"/>
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
                                            <td align="center">
                                                <asp:GridView ID="gvCategoryList" runat="server" AllowPaging="true" 
                                                    AutoGenerateColumns="false" DataKeyNames="CategoryID" 
                                                    OnPageIndexChanging="gvCategoryList_PageIndexChanging" 
                                                    OnRowCancelingEdit="gvCategoryList_RowCancelingEdit" 
                                                    OnRowDataBound="gvCategoryList_RowDataBound" 
                                                    OnRowDeleting="gvCategoryList_RowDeleting" 
                                                    OnRowEditing="gvCategoryList_RowEditing" 
                                                    OnRowUpdating="gvCategoryList_RowUpdating" PagerSettings-FirstPageText="Fisrt" 
                                                    PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" 
                                                    PagerStyle-HorizontalAlign="Center" PageSize="5" Width="550px">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Section Type">
                                                            <ItemStyle HorizontalAlign="center" Width="200px" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnDeleteCategoryID" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>' />
                                                                <asp:Label ID="lblCategoryName" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:HiddenField ID="hdnCategoryID" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>' />
                                                                <asp:TextBox ID="txtCategoryName" runat="server" MaxLength="100" 
                                                                    Text='<%# Bind("CategoryName") %>' Width="100px"></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="200px" 
                                                            ShowEditButton="True" ShowHeader="True" />
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkDeleteCategory" runat="server" CommandName="Delete" 
                                                                    Font-Underline="false">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <uc2:Footer ID="Footer1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
   
    </div>
   
    </form>
</body>
</html>
