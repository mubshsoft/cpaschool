<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignmentAddSubOption.aspx.cs" Inherits="Admin_AssignmentAddSubOption" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" src="../stmenu.js"></script>

    <title>Assignment Sub Option</title>

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
    
    <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-family:Verdana,Arial,Tahoma; font-size:10px; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                                     <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>
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
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b">Back To 
                                                            Admin Panel</font></a></strong>&nbsp; <strong class="style9_sec">
                                                                    <a href="../logout.aspx" class="part1"><font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 0px; padding-bottom: 20px;">
                                                
                                                <table width="600px" align="center">
                                                   <tr>
                                                        <td >
                                                            &nbsp;</td>
                                                        <td  align="left" valign="middle">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td  colspan="2"  align="left" class="style5">
                                                            <b>Question:</b>&nbsp;
                                                            <asp:Label ID="lblSubQuestion" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td  colspan="2"  align="center">
                                                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td  colspan="2"  align="left">
                                                            &nbsp;  <b> Answer:</b>&nbsp; <asp:Label ID="lblanswer" runat="server" Text=""></asp:Label></td>
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
                                                     <tr style="height:30px" align="center">
                                                        <td align="right"  valign="middle" style="padding-right:10PX; " class="style5">
                                                           
                                                            Option Type :
                                                        </td>
                                                        <td  align="left" valign="middle"  class="style5">
                                                            <asp:DropDownList ID="ddlOptionType" runat="server" Height="25px" TabIndex="2" CssClass="DropDownStyle11" 
                                                                Width="125px">
                                                            <asp:ListItem>Radio Button</asp:ListItem>
                                                            </asp:DropDownList>
                                                         </td>
                                                    </tr>
                                                     <tr>
                                                        <td  align="right"  valign="top" style="padding-right:10PX; " class="style5">
                                                            Add Option :
                                                            <font color="red">*</font></td>
                                                        <td  align="left" valign="top"  class="style5">
                                                            <asp:TextBox ID="txtoption" runat="server" TabIndex="3" Width="120"></asp:TextBox><asp:LinkButton ID="lnkbtnans" runat="server" onclick="lnkbtnans_Click"  CausesValidation="false">Click here add answer as option</asp:LinkButton>
                                                            <asp:RequiredFieldValidator ID="rqdSurveyQuestion" runat="server" 
                                                                ControlToValidate="txtoption" ErrorMessage="&lt;/br&gt;Enter Option "></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                     
                                                    <tr>
                                                        <td width="150px" align="right">
                                                            &nbsp;</td>
                                                        <td width="200px" align="left" valign="middle">
                                                            <asp:ImageButton ID="btnBack" runat="server" CausesValidation="false" 
                                                                ImageUrl="~/Images/back_button.jpg" onclick="btnBack_Click" />
&nbsp; <asp:ImageButton ID="btnSave" runat="server"  
                                                                ImageUrl="../Images/Save.png" onclick="btnSave_Click"/>
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
                                                <asp:GridView ID="gvQuestionOptionList" runat="server" AllowPaging="true" 
                                                    AutoGenerateColumns="false" DataKeyNames="OPTID" 
                                                    HeaderStyle-BackColor="#E4E4E4" HeaderStyle-Font-Bold="true" 
                                                    OnPageIndexChanging="gvQuestionOptionList_PageIndexChanging" 
                                                    OnRowCancelingEdit="gvQuestionOptionList_RowCancelingEdit" 
                                                    OnRowDeleting="gvQuestionOptionList_RowDeleting" 
                                                    OnRowEditing="gvQuestionOptionList_RowEditing" 
                                                    OnRowUpdating="gvQuestionOptionList_RowUpdating" 
                                                    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                    PageSize="5" Width="500px">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="OPTIONS">
                                                            <ItemStyle HorizontalAlign="center" Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="OPTIONS" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "OPTIONS")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtOption" runat="server" MaxLength="100" 
                                                                    Text='<%# Bind("OPTIONS") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPTION TYPE">
                                                            <ItemStyle HorizontalAlign="center" Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" 
                                                            HeaderStyle-Width="125px" ShowEditButton="True" ShowHeader="True" />
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" Width="75px" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnOptId" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "OPTID")%>' />
                                                                <asp:LinkButton ID="linkDeleteQuestion" runat="server" CausesValidation="false" 
                                                                    CommandName="Delete" Font-Underline="false">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" />
                                                <asp:HiddenField ID="hdnQuestionID" runat="server" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                  </ContentTemplate></asp:UpdatePanel>
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
