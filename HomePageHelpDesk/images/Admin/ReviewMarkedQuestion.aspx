<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewMarkedQuestion.aspx.cs" Inherits="SubmitExam" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Course Info</title>

   <script type="text/javascript" src="../stmenu.js"></script>
</head>
<body>
    <form id="form1" runat="server">
  
    <div >
  
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
                                                &nbsp;</td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 0px; padding-bottom: 20px;">
                                                &nbsp;</td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                               <asp:GridView ID="gvQuestionList" runat="server" AutoGenerateColumns="false" DataKeyNames="QuestionId"
                                                    GridLines="None" OnRowDataBound="gvQuestionList_RowDataBound" Style="margin-top: 0px;"
                                                    Width="550px" PagerSettings-Mode="NextPrevious" PagerSettings-NextPageImageUrl="~/images/next.png"
                                                    PagerStyle-HorizontalAlign="Right" PagerSettings-PreviousPageImageUrl="~/images/previous.png"
                                                    PagerStyle-ForeColor="Red" runat="server" PageSize="1" AllowPaging="true" OnPageIndexChanging="gvDisplayList_PageIndexChanging">
                                                    <Columns>
                                                  
                                                        <asp:TemplateField >
                                                            <ItemStyle  HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="padding-left: 10px; height:10px; margin-top:5px; padding-top:5px; ">
                                                                        
                                                                            <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                            <asp:HiddenField ID="hdnQUESTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>' />
                                                                            <asp:HiddenField ID="hdnOPTIONTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>' />
                                                                       
                                                                        <asp:Label ID="Label2" runat="server" Text="Question" VerticalAlign="Top"></asp:Label>
                                                                       
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                VerticalAlign="Top"></asp:Label>
                                                                            <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top"></asp:Label>
                                                                       
                                                                            <asp:Label ID="lblName" runat="server" Font-Size="13px" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                VerticalAlign="Top" Width="200PX"></asp:Label>
                                                                            <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                       
                                                                        <br />
                                                                        &nbsp; 
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height:0px;">
                                                                        
                                                                    </td>
                                                                <tr>
                                                                    <td style="padding-left: 20px;">
                                                                        <asp:Panel ID="panel" runat="server" Font-Bold="false" Font-Size="12px">
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td style="padding-left: 20px;">
                                                                        <asp:Panel ID="panel1" runat="server" Font-Bold="false" Font-Size="12px">
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblspace" runat="server" Width="85px"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 15px; padding-bottom: 10px; padding-top: 5px;">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField >
                                                            <ItemStyle  HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gvSubQuestionList" runat="server" AutoGenerateColumns="false" DataKeyNames="SubQuestionId"
                                                                            OnRowDataBound="gvSubQuestionList_RowDataBound" GridLines="None" Style="margin-top: 0px;"
                                                                            Width="550px" AllowPaging="false">
                                                                            <Columns>
                                                                                <asp:TemplateField >
                                                                                    <ItemStyle  HorizontalAlign="Left" />
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td style="padding-left: 10px;">
                                                                                                <span style="vertical-align: top">
                                                                                                    <asp:HiddenField ID="hdnSubQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>' />
                                                                                                </span><span style="vertical-align: top"></span><span style="vertical-align: top">
                                                                                                </span><span style="vertical-align: top"></span>
                                                                                                <asp:Label ID="Label2" runat="server" Text="Question" VerticalAlign="Top"></asp:Label>
                                                                                                </span><span style="vertical-align: top">
                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuesNo")%>'
                                                                                                        VerticalAlign="Top"></asp:Label>
                                                                                                    <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top"></asp:Label>
                                                                                                </span><span style="vertical-align: top">
                                                                                                    <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                        VerticalAlign="Top" Font-Size="13px" Width="200PX"></asp:Label>
                                                                                                    <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                </span>
                                                                                                <br />
                                                                                                &nbsp; </span>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="padding-left: 10px;">
                                                                                                <asp:Panel ID="panel" runat="server" Font-Bold="false" Font-Size="12px">
                                                                                                </asp:Panel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <ItemTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblspace" runat="server" Width="85px"></asp:Label>
                                                                                                </td>
                                                                                                <td align="left" style="padding-left: 15px; padding-bottom: 10px; padding-top: 5px;">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        
                                        <tr align="left" valign="top">
                                            <td align="center">
                                                            <asp:ImageButton ID="btnSave" runat="server"  
                                                                ImageUrl="../Images/SaveAndContinue.png" onclick="btnSave_Click" Visible="false"/>
                                                        </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                            &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="hdnExamId" runat="server" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
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
