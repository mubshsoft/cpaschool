<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignmentAddSubQuestion.aspx.cs" Inherits="AssignmentAddSubQuestion" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Assignment Sub Option</title>
 <script type="text/javascript" src="../stmenu.js"></script>
   <%-- <script language="javascript" type="text/javascript">
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
    </script>--%>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-family:Verdana,Arial,Tahoma; font-size:10px; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
    <div >
   <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
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
                                
                                


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate >
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
                                                <table width="540px">
                                                <tr><td colspan="2">&nbsp;</td></tr>
                                                    <tr>
                                                        <td  colspan="2"  align="center">
                                                            <asp:Label ID="lblSection" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="250px" align="right" style="padding-right:10PX; " class="style5">
                                                             Question Number :</td>
                                                        <td width="350px" align="left" class="style9_sec" >
                                                           <asp:TextBox ID="txtquestionNo" runat="server" Width="120px" TabIndex="1" CssClass="style11" ></asp:TextBox>
                                                           <nobr> <asp:RequiredFieldValidator ID="rqdSurveyName" runat="server" 
                                                                ControlToValidate="txtquestionNo" ErrorMessage="Enter Question Number "></asp:RequiredFieldValidator>
                                                            </nobr>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="padding-right:10PX; " class="style5">
                                                            Question Type :</td>
                                                        <td width="350px" align="left" class="style9_sec">
                                                            <asp:DropDownList ID="ddlQuestionType" runat="server" AutoPostBack="true" CssClass="DropDownStyle11" 
                                                                TabIndex="2" 
                                                                Width="125px" 
                                                                onselectedindexchanged="ddlQuestionType_SelectedIndexChanged">
                                                                <asp:ListItem>-Select Type-</asp:ListItem>
                                                                 <asp:ListItem Value="Objective">Objective</asp:ListItem>
                                                                        <asp:ListItem Value="Subjective">Descriptive</asp:ListItem>
                                                             </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="padding-right:10PX; " class="style5" valign="top">
                                                            Question :                                                         </td>
                                                        <td width="350px" align="left" class="style9_sec">
                                                            <asp:TextBox ID="txtQuestion" runat="server" 
                TextMode="MultiLine" Width="350px" TabIndex="3" ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rqdSurveyQuestion" runat="server" 
                                                                ControlToValidate="txtQuestion" 
                                                                ErrorMessage="Enter  Question "></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="padding-right:10PX; " class="style5">
                                                            Answer :
                                                            </td>
                                                        <td width="350px" align="left" class="style9_sec">
                                                            <asp:TextBox ID="txtAnswer" runat="server" TabIndex="4" ></asp:TextBox>
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
                                                        <td width="350px" align="left" valign="middle">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="150px" align="right">
                                                            &nbsp;</td>
                                                        <td align="left" valign="left" width="350px">
                                                            <asp:ImageButton ID="btnBack" runat="server" 
                                                                ImageUrl="~/Images/back_button.jpg" onclick="btnBack_Click" CausesValidation="false"  />&nbsp;&nbsp;<asp:ImageButton ID="btnSave" runat="server"  
                                                                ImageUrl="../Images/SaveAndContinue.png" onclick="btnSave_Click"/></td>
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
                                                <asp:GridView ID="gvQuestionList" runat="server" AllowPaging="true" 
                                                    AutoGenerateColumns="false" DataKeyNames="QuestionId" 
                                                    HeaderStyle-BackColor="#E4E4E4" HeaderStyle-Font-Bold="true" 
                                                    OnPageIndexChanging="gvQuestionList_PageIndexChanging" 
                                                    OnRowCancelingEdit="gvQuestionList_RowCancelingEdit" 
                                                    OnRowDataBound="gvQuestionList_RowDataBound" 
                                                    OnRowDeleting="gvQuestionList_RowDeleting" 
                                                    OnRowEditing="gvQuestionList_RowEditing" 
                                                    OnRowUpdating="gvQuestionList_RowUpdating" PagerSettings-FirstPageText="Fisrt" 
                                                    PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" 
                                                    PagerStyle-HorizontalAlign="Center" PageSize="20" Width="650px">
                                                     <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Question No.">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="QuesNo" runat="server" CssClass="left_padding" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "QuesNo")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtQuestionNo" runat="server" MaxLength="100" 
                                                                    Text='<%# Bind("QuesNo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Question">
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" CssClass="left_padding" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:HiddenField ID="hdnDeleteQuestionId" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>' />
                                                                <asp:TextBox ID="txtQuestion" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("QuestionText") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Answer">
                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAnswer" runat="server" CssClass="left_padding" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "Answer")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                
                                                                <asp:TextBox ID="txtAnswer" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("Answer") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" 
                                                            HeaderStyle-Width="75px" ShowEditButton="True" ShowHeader="True" />
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" Width="75px" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnQuestionId" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>' />
                                                                <asp:LinkButton ID="linkDeleteQuestion" runat="server" CausesValidation="false" 
                                                                    CommandName="Delete" Font-Underline="false">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" Width="75px" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnAddQuestionId" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>' />
                                                                    <asp:HiddenField ID="hdnQUESTYPE" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>' />
                                                                <asp:LinkButton ID="linkAddOption" runat="server" CausesValidation="false" 
                                                                    Font-Underline="false">Add Options</asp:LinkButton>
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
                                                <asp:HiddenField ID="hdnQuestionId" runat="server" />
                                                <asp:HiddenField ID="hdnSectionId" runat="server" />
                                                <asp:HiddenField ID="hdnType" runat="server" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
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
