<%@ Page MasterPageFile="~/MasterPage.master" Language="VB" AutoEventWireup="false" CodeFile="Admin_ClearStatus.aspx.vb" Inherits="Admin_ClearStatus" Title="List of Student" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />--%>
    <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script type="text/javascript" src="stmenu.js"></script>
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
                   
                   
                   
                     
                     function openPopup(strOpen)
                         {
                          open(strOpen, "Info", "status=1, width=700, height=800, top=20, left=300,scrollbars=yes");
                         }
    </script>

   

    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div onkeypress="HideMessage()">
    <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>
    <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">List of Students</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active">List of students&nbsp;&nbsp; | &nbsp;&nbsp;<a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>
        <section class="container main">
        <div class="row-fluid">
                <div class="span12">(select semester only if you want to change previous semester marks and fee status)</div>
                </div>
     <div class="row-fluid">
                <div class="span12"><span class="pull-right"><asp:Button ID="imgBack" Text="Back" CssClass="btn btn-large btn-primary" runat="server"/></span></div>
                </div>
      <div class="row-fluid">
                <div class="span12"><asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Red" Text=""></asp:Label></div>
                </div>
    <div class="row-fluid">
                <div class="span12"><asp:DropDownList ID="ddlSem" runat="server" ToolTip="Select Semester" AutoPostBack="true" CssClass="input-block-level"></asp:DropDownList></div>
                </div>
    <div class="row-fluid">
                <div class="span12"><b><%=semTitle%></b>&nbsp; || &nbsp;<%=stEmail%></div>
            </div>
    <div class="row-fluid">
                <div class="span12 form_head">Marks</div>
                </div>
    <div class="row-fluid">
    <div class="user-info media box" style="background-color:#fff;">
                <div class="span4 center"><asp:ImageButton ID="imgDetail" runat="server" ImageUrl="../Images/marks_detail.png" /></div>
                <div class="span4 center"><asp:ImageButton ID="imgMarksComplete" runat="server" ImageUrl="../Images/completed.png" OnClientClick="return confirm('Are you sure to set marks completed of current semester? Click OK to Completed Marks of current semester.');" ToolTip="Click here to Marks Completed of current semester"/></div>
                <div class="span4 center"><asp:ImageButton ID="imgMarksnotComplete" runat="server" ImageUrl="../Images/incompleted.png" OnClientClick="return confirm('Are you sure to set marks incompleted of current semester? Click OK to Incompleted Marks of current semester.');" ToolTip="Click here to Marks Incompleted of current semester"/></div>
                </div>
                </div>
                <div class="row-fluid">&nbsp;</div>
     <div class="row-fluid">
                <div class="span12 form_head">Fees</div>
                </div>            
     <div class="row-fluid">
     <div class="user-info media box" style="background-color:#fff;">
                <div class="span4 center"><asp:ImageButton ID="imgFeesDetail" runat="server" ImageUrl="../Images/fees_detail.png" />
                                                            <%--  <asp:ImageButton ID="imgFeesDetail" runat="server"  ImageUrl="../Images/fees_detail.png"/>--%>
                                                        </div>
                <div class="span4 center"><asp:ImageButton ID="ImgFeesPaid" runat="server" ImageUrl="../Images/fees_paid.png" OnClientClick="return confirm('Are you sure to set Fees Paid of current semester? Click OK to Fees Paid of current semester.');" ToolTip="Click here to Fees Paid of current semester"/></div>
                <div class="span4 center"><asp:ImageButton ID="ImgFeesUnpaid" runat="server" ImageUrl="../Images/unpaid.png" OnClientClick="return confirm('Are you sure to set Fees Unpaid of current semester? Click OK to Fees Unpaid of current semester.');" ToolTip="Click here to Fees Unpaid of current semester"/></div>
               </div>  
               </div>                                       
      <div class="row-fluid">
       <div class="span12">
       
       <table width="80%" style="border: solid 1px #cccccc;" id="table1" runat="server"
                                                    visible="false">
                                                    
                                                    <tr id="tr1" runat="server">
                                                        <td align="center" style="border: solid 1px #cccccc;">
                                                            <b>
                                                                <asp:Label ID="lblExam" runat="server" Text="Exam and Assignment Marks" Visible="false"></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr2" runat="server">
                                                        <td align="center" style="border: solid 1px #cccccc;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="tr3" runat="server">
                                                        <td style="border: solid 1px #cccccc;" align="center">
                                                            <asp:GridView ID="GrdPaperMarks" AutoGenerateColumns="False" DataKeyNames="stid"
                                                                Width="97%" runat="server" AllowPaging="True">
                                                                <HeaderStyle CssClass="grid-header-Overtime" />
                                                                <RowStyle CssClass="grid-row-Overtime" />
                                                                <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                <HeaderStyle CssClass="grid-header-Overtime" />
                                                                <EmptyDataTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="padding-right: 10px">
                                                                                <font color="#4b4b4b"><strong>No records </strong></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Paper Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpaperid" Text='<%# Eval("paperid") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="stid" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblstid" Text='<%# Eval("stid") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SemId" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSemId" Text='<%# Eval("SemId") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="bid" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblfullname" Text='<%# Eval("fullname") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderText="E mail" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemail" Text='<%# Eval("email") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Paper Title" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPaperTitle" Text='<%# Eval("PaperTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ExamMarks" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblExamMarks" Text='<%# Eval("ExamMarks") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="AssignmentMarks" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAssignmentMarks" Text='<%# Eval("AssignmentMarks") %>' runat="server"
                                                                                CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="forum" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblforum1" Text='<%# Eval("forum") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr4" runat="server">
                                                        <td align="center" style="border: solid 1px #cccccc;">
                                                            <b>
                                                                <asp:Label ID="lblDisscussion" runat="server" Text="Other Marks" Visible="false"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr5" runat="server">
                                                        <td align="center" style="border: solid 1px #cccccc;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="tr6" runat="server">
                                                        <td style="border: solid 1px #cccccc;" align="center">
                                                            <asp:GridView ID="GrdDisscussionMarks" AutoGenerateColumns="False" DataKeyNames="stid"
                                                                Width="97%" runat="server" AllowPaging="True">
                                                                <HeaderStyle CssClass="grid-header-Overtime" />
                                                                <RowStyle CssClass="grid-row-Overtime" />
                                                                <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                <HeaderStyle CssClass="grid-header-Overtime" />
                                                                <EmptyDataTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="padding-right: 10px">
                                                                                <font color="#4b4b4b"><strong>No records </strong></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="stid" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblstid" Text='<%# Eval("stid") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SemId" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSemId" Text='<%# Eval("SemId") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="bid" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblfullname" Text='<%# Eval("fullname") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderText="E mail" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemail" Text='<%# Eval("email") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                    <%-- <asp:TemplateField HeaderText="Disscussion Marks" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblforum" Text='<%# Eval("forum") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Project Marks" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProject" Text='<%# Eval("Project") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Marks 1" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmarks1" Text='<%# Eval("marks1") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Marks 2" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmarks2" Text='<%# Eval("marks2") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                                
                                            </td>
                                        </tr>
                                        <tr id="tr7" runat="server">
                                            <td align="center">
                                                <table width="80%" id="tblpayment" visible="false" runat="server" style="border: solid 1px #cccccc;">
                                                    <tr id="tr8" runat="server">
                                                        <td align="center" style="border: solid 1px #cccccc;">
                                                        </td>
                                                    </tr>
                                                    <tr id="tr9" runat="server">
                                                        <td align="center" style="border: solid 1px #cccccc;">
                                                            <b>
                                                                <asp:Label ID="Label1" runat="server" Text="Payment Details"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: solid 1px #cccccc;" align="center">
                                                            <asp:GridView ID="Grdpayment" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                DataKeyNames="Id" Width="97%">
                                                                <HeaderStyle CssClass="grid-header-Overtime" />
                                                                <RowStyle CssClass="grid-row-Overtime" />
                                                                <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                <HeaderStyle CssClass="grid-header-Overtime" />
                                                                <EmptyDataTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="padding-right: 10px">
                                                                                <font color="#4b4b4b"><strong>No records </strong></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="DD NO" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDDNo" runat="server" CssClass="left_padding" Text='<%# Eval("DDNo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAmount" runat="server" CssClass="left_padding" Text='<%# Eval("Amount") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DD date" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDDdate" runat="server" CssClass="left_padding" Text='<%# Eval("DDdate") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCourseTitle" runat="server" CssClass="left_padding" Text='<%# Eval("CourseTitle") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderText="SemId" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSemId" Text='<%# Eval("SemId") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                     </ContentTemplate></asp:UpdatePanel>
                           </div>
                            </td>
                            <td width="3">
                            </td>
                        </tr>
                        <tr align="left" valign="top">
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
   
    </td> </tr>
    
    </table> </td>
    <td>
              &nbsp;
    </td>
    </tr> </table> </div>
     </div></form>
</asp:Content>
