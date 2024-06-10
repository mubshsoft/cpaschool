<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyPaperAssign.aspx.cs"
    Inherits="Admin_FacultyPaperAssign" %>

<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

   
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Faculty Report</title>

    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">


  function closepopup()
{    
    window.close();
}
function CallPrint(strid)
  {
   var prtContent = document.getElementById(strid);
   var strOldOne=prtContent.innerHTML;
   var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
   WinPrint.document.write(prtContent.innerHTML);
   WinPrint.document.close();
   WinPrint.focus();
   WinPrint.print();
   WinPrint.close();
   prtContent.innerHTML=strOldOne;
  }





    </script>

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
           
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
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
                                        <div class="frame">
                                         
                                            <table width="700" border="0" cellspacing="0" cellpadding="0">
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
                                                                    <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b">Back To Admin
                                                                        Panel</font></a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx"
                                                                            class="part1"><font color="#4b4b4b">Logout</font></a></strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="left" valign="top">
                                                    <td align="left" width="3">
                                                    </td>
                                                    <td align="center" class="style5" height="100%" style="padding-top: 0px; padding-bottom: 20px;">
                                                    </td>
                                                    <td width="3">
                                                    </td>
                                                </tr>
                                                <tr align="left" valign="top">
                                                    <td>
                                                    </td>
                                                    <td align="center">
                                                        <div id="print_grid" class="style5">
                                                            <fieldset>
                                                                <legend class="style9_sec"><b>Faculty Report</b></legend>
                                                                <br />
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <table width="420px">
                                                                                <tr>
                                                                                    <td align="right" class="style5" style="padding-right: 10PX" width="200px">
                                                                                        <b>Faculty Name :</b>
                                                                                    </td>
                                                                                    <td align="left" class="style9_sec" width="300px">
                                                                                        <asp:Label ID="lblFacultyName" align="left" runat="server" Visible="true"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="style5" style="padding-right: 10PX" width="200px">
                                                                                        <asp:Label ID="lbldate" runat="server" Text="Date :" Font-Names="Tahoma" Font-Size="11px"
                                                                                            Font-Bold></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="style9_sec" width="300px">
                                                                                        <asp:Label ID="lblShowDate" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grdFacultyDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                  HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee"
                                                                                RowStyle-BackColor="#ffffff" EnableModelValidation="True" AllowPaging="false"
                                                                                OnPageIndexChanging="grdFacultyDetails_PageIndexChanging" PageSize="20">
                                                                                <RowStyle BackColor="White"></RowStyle>
                                                                                <EmptyDataTemplate>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td width="100%" align="center" style="padding-right: 10px">
                                                                                                <font color="red"  ><strong>!!!No Records Found!!!</strong>
                                                                                                </font>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </EmptyDataTemplate>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                        <ItemTemplate>
                                                                                            <%# (grdFacultyDetails.PageSize * grdFacultyDetails.PageIndex) + Container.DisplayIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Course Title" ItemStyle-CssClass="left_padding1">
                                                                                       
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCourseTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="left_padding1" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Semester Title" ItemStyle-CssClass="left_padding1">
                                                                                       
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSemesterTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="left_padding1" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Module Title" ItemStyle-CssClass="left_padding1">
                                                                                      
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblModuleTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="left_padding1" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Paper Title" ItemStyle-CssClass="left_padding1">
                                                                                      
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPaperTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="left_padding1" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                               <HeaderStyle BackColor="#EEEEEE" />
                                                                                <AlternatingRowStyle BackColor="#EEEEEE" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr align="left" valign="top">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="center" valign="top">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/close.png" PostBackUrl="~/Report/FacultyReport.aspx"
                                                            Visible="False" />
                                                        &nbsp;&nbsp;
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png" tyle="text-align: left"
                                                            ToolTip="Print" Visible="false" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        &nbsp;
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
