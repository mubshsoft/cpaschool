<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false"  CodeFile="ListCourse.aspx.vb" Inherits="ListCourse" Title="Edit Course" %>

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
   <script language="javascript" type="text/javascript">

        function OpenDiv(obj) {
            
          var div = document.getElementById(obj.id);
            if (div.style.display == "none") {
                div.style.display = "block";
            }
            else {
                div.style.display = "none";
            }
        }

        function OpenDivOnServer(obj) {

            var div = document.getElementById(obj.id);
                   if (div.style.display == "none") {
                div.style.display = "block";
            }
            else {
                div.style.display = "none";
            }
        }
        function expandcollapse(obj, row) {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") {
                div.style.display = "block";

                if (row == 'alt') {
                    img.src = "../images/minus.gif";
                }
                else {
                    img.src = "../images/minus.gif";
                }
                img.alt = "Close to view other Customers";
            }
            else {
                div.style.display = "none";
                if (row == 'alt') {
                    img.src = "../images/plus.gif";
                }
                else {
                    img.src = "../images/plus.gif";
                }
                img.alt = "Expand to show Orders";
            }
        }
        function openPopup(strOpen) {
            open(strOpen, "Info", "status=1, width=300, height=130, top=20, left=300");
        }

        function openPopup1(strOpen) {
            open(strOpen, "Info", "status=1, width=350, height=130, top=20, left=300");
        }
   
        
    </script>

    <script language="javascript" type="text/javascript">
        function HideMessage() {

            if (document.all) {
                document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
            }
            else {
                document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
            }
        }
    </script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <asp:Label ID="lblCaption" Visible="false" runat="server" />
    <h1 class="heading-color">Edit Course</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Edit Course</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()" onclick="javascript:HideMessage()">
       
   

    <section class="container main m-tb">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right">
                    <a href="ManageActiveCourse.aspx" class="btn btn-info" >Manage Active Course</a>
                    
                                                                     </span>
                </div> 
                </div> 
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red" ></asp:Label></div>
                </div>
                <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <asp:GridView ID="GrdCourse" AutoGenerateColumns="False" ShowFooter="true" CssClass="table" runat="server" GridLines="None" BorderStyle="none"
                                                    DataKeyNames="courseID" OnRowDataBound="GrdCourse_RowDataBound" OnRowCommand="GrdCourse_RowCommand" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <a href="javascript:expandcollapse('divMainParent<%# Eval("courseID") %>', 'one');">
                                                                    <img id="imgdivMainParent<%# Eval("courseID") %>" alt="Click to show/hide course for student <%# Eval("courseID") %>"
                                                                        width="9px" border="0" src="../images/plus.gif" />
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseid" Text='<%# Eval("courseID") %>' runat="server" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="courseID" HeaderText="courseID" InsertVisible="False"
                                                            ReadOnly="True" SortExpression="courseID" Visible="false" />
                                                        <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" SortExpression="CourseCode"  ItemStyle-HorizontalAlign="Left" />
                                                        <asp:BoundField DataField="CourseTitle" HeaderText="CourseTitle" SortExpression="CourseTitle" ItemStyle-HorizontalAlign="Left" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                               <%-- <asp:LinkButton ID="lnkAdd" runat="server" CommandName="Add" CommandArgument='<%# Eval("courseID") %>'>Add 
                                                                New Semester</asp:LinkButton>--%>
                                                                 <%--<a id="aAddNewSemester" href="javascript:openPopup('AddNewSemester.aspx?Courseid=<%#Container.DataItem("courseID")%>')">
                                                                                                Add New Semester </a>--%>
                                                                  <a id="ancAddModule" onclick='OpenDiv(divNSem<%#Container.DataItem("courseID")%>);'>
                                                                            Add New Semester</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                               <%-- <asp:LinkButton ID="lnkAdd" runat="server" CommandName="Add" CommandArgument='<%# Eval("courseID") %>'>Add 
                                                                New Semester</asp:LinkButton>--%>
                                                                 <a id="aEditSemester"  href="AddFeeAndSemesterDuration.aspx?cid=<%#Container.DataItem("courseID")%>&feedit=1&backlist=2">
                                                                                                Edit Course Fees </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                               <%-- <asp:LinkButton ID="lnkAdd" runat="server" CommandName="Add" CommandArgument='<%# Eval("courseID") %>'>Add 
                                                                New Semester</asp:LinkButton>--%>
                                                                 <a id="amailContent"  href="AddCourseEmail.aspx?courseid=<%#Container.DataItem("courseID")%>&dt=0">
                                                                                               Email Content </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("courseID") %>'>Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("courseID") %>' Visible="false">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                                                                                <ItemTemplate>
                                                                                                                  <%--<asp:HiddenField ID="id" runat="server" Value='<%# Container.DisplayIndex+1 %>' />--%>
                                                                                                                <%--<asp:HiddenField ID="hdnSemID" runat="server" Value='<%#Container.DataItem("SemID")%>' />--%>
                                                                                                                <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#Container.DataItem("courseID")%>' />
                                                                                                                                                                      
                                                                                                                </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                    <tr>
                                                                                                        <td colspan="100%">
                                                                                                            <div id='divNSem<%#Container.DataItem("courseID")%>' 
                                                                                                                style="display: none; position: relative; left: 5px; " >
                                                                                                                <table>
                                                                                                                    <tr>
                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                            Semester
                                                                                                                        </td>
                                                                                                                        <td width="100px" align="left">
                                                                                                                            <asp:TextBox ID="txtSemesterName" runat="server"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                       
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="2">
                                                                                                                            &nbsp;
                                                                                                                          </td>
                                                                                                                        <td>
                                                                                                                            &nbsp;
                                                                                                                        </td>
                                                                                                                        <td align="right">
                                                                                                                            <asp:ImageButton ID="btnSave" ImageUrl="../Images/save.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                CommandName="FileSave" runat="server" />
                                                                                                                            &nbsp; &nbsp;
                                                                                                                            <asp:ImageButton ID="btnClose" ImageUrl="../Images/close.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                CommandName="FileCancel" runat="server" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td colspan="100%">
                                                                        <div id="divMainParent<%# Eval("courseID") %>" style="display: none; position: relative;
                                                                            left: 15px;">
                                                                            <asp:GridView ID="grdSemester" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                                                DataKeyNames="SemID" OnRowDataBound="grdSemester_RowDataBound" OnRowCommand="grdSemester_RowCommand"
                                                                                OnRowDeleting="grdSemester_RowDeleting">
                                                                                <HeaderStyle CssClass="table_subhead" />
                                                                                <RowStyle CssClass="grid-row-Overtime" />
                                                                                <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                <HeaderStyle  />
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <a href="javascript:expandcollapse('divParent<%# Eval("SemID") %>', 'one');">
                                                                                                <img id="imgdivParent<%# Eval("SemID") %>" alt="Click to show/hide course for student <%# Eval("SemID") %>"
                                                                                                    width="9px" border="0" src="../images/plus.gif" />
                                                                                            </a>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCourseID" Text='<%# Eval("CourseID") %>' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSemID" Text='<%# Eval("SemID") %>' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Semester">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTitle" Text='<%# Eval("SemesterTitle") %>' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkDeleteSemester" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex+1 %>' OnClientClick="return confirm('Are you sure you want to delete this semester?');">Delete 
                                                                                            Semester</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <%--<a id="a1" href="javascript:openPopup('AddModule.aspx?id=<%#Container.DataItem("courseID")%>&Semid=<%#Container.DataItem("SemID")%>')">
                                                                                                Add Module </a>--%>
                                                                                                 <a id="ancAddModule" onclick='OpenDiv(divNMod<%#Container.DataItem("SemID")%>);'>
                                                                                                                                                        Add Module </a>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                      <asp:TemplateField>
                                                                                                                <ItemTemplate>
                                                                                                                  <%--<asp:HiddenField ID="id" runat="server" Value='<%# Container.DisplayIndex+1 %>' />--%>
                                                                                                                <asp:HiddenField ID="hdnSemID" runat="server" Value='<%#Container.DataItem("SemID")%>' />
                                                                                                                <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#Container.DataItem("courseID")%>' />
                                                                                                                                                                      
                                                                                                                </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                      <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                    <tr>
                                                                                                        <td colspan="100%">
                                                                                                            <div id='divNMod<%#Container.DataItem("SemID")%>' Class="table"
                                                                                                                style="display: none; position: relative; left: 5px; ">
                                                                                                                <table style="background-color: #5984b0;">
                                                                                                                    <tr>
                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                            Module
                                                                                                                        </td>
                                                                                                                        <td width="100px" align="left">
                                                                                                                            <asp:TextBox ID="txtModuleName" runat="server"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                       
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="2">
                                                                                                                            &nbsp;
                                                                                                                          </td>
                                                                                                                        <td>
                                                                                                                            &nbsp;
                                                                                                                        </td>
                                                                                                                        <td align="right">
                                                                                                                            <asp:ImageButton ID="btnSave" ImageUrl="../Images/save.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                CommandName="FileSave" runat="server" />
                                                                                                                            &nbsp; &nbsp;
                                                                                                                            <asp:ImageButton ID="btnClose" ImageUrl="../Images/close.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                CommandName="FileCancel" runat="server" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                        </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td colspan="100%">
                                                                                                    <div id="divParent<%# Eval("SemID") %>" style="display: none; position: relative;
                                                                                                        left: 15px; width: 97%">
                                                                                                        <asp:GridView ID="GrdModule" AutoGenerateColumns="False" DataKeyNames="ModuleID" CssClass="table"
                                                                                                            Width="97%" runat="server" OnRowDataBound="GrdModule_RowDataBound" OnRowCommand="GrdModule_RowCommand"
                                                                                                            OnRowDeleting="GrdModule_RowDeleting">
                                                                                                            <HeaderStyle CssClass="grid-header-Overtime" />
                                                                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                                            <HeaderStyle CssClass="grid-header-Overtime" />
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <a href="javascript:expandcollapse('divChild<%# Eval("ModuleId") %>', 'one');">
                                                                                                                            <img id="imgdivChild<%# Eval("ModuleID") %>" alt="Click to show/hide Semester <%# Eval("SemID") %>"
                                                                                                                                width="9px" border="0" src="../images/plus.gif" />
                                                                                                                        </a>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblModuleID" Text='<%# Eval("ModuleId") %>' runat="server"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblModuleTitle" Text='<%# Eval("ModuleTitle") %>' runat="server"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="lnkDeleteModule" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex+1 %>' OnClientClick="return confirm('Are you sure you want to delete this Module?');">Delete 
                                                                                                                        Module</asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                       <%-- <a id="a3" href="javascript:openPopup('AddPaper.aspx?Mid=<%#Container.DataItem("ModuleID")%>&Semid=<%#Container.DataItem("SemID")%>')">
                                                                                                                            Add Paper </a>--%>
                                                                                                                              <a id="ancAddPaper" onclick='OpenDiv(divNPap<%#Container.DataItem("ModuleID")%><%#Container.DataItem("SemID")%>);'>
                                                                                                                                                        Add Paper </a>
                                                                                                                    </ItemTemplate>
                                                                                                                   
                                                                                                                    
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                <ItemTemplate>
                                                                                                                <%-- <asp:HiddenField ID="id" runat="server" Value='<%# Container.DisplayIndex+1 %>' />--%>
                                                                                                                 <asp:HiddenField ID="hdnModuleID" runat="server" Value='<%#Container.DataItem("ModuleID")%>' />
                                                                                                                <asp:HiddenField ID="hdnSemID" runat="server" Value='<%#Container.DataItem("SemID")%>' />
                                                                                                                <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#Container.DataItem("courseID")%>' />
                                                                                                                                                                      
                                                                                                                </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                     <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <tr>
                                                                                                                                                        <td colspan="100%">
                                                                                                                                                            <div id='divNPap<%#Container.DataItem("ModuleID")%><%#Container.DataItem("SemID")%>'
                                                                                                                                                                style="display: none; position: relative; left: 5px; " Class="table">
                                                                                                                                                                <table style="background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                                                                            Paper
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="100px" align="left">
                                                                                                                                                                            <asp:TextBox ID="txtPaperName" runat="server"></asp:TextBox>
                                                                                                                                                                        </td>
                                                                                                                                                                       
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;
                                                                                                                                                                           <%-- <asp:HiddenField ID="hdnParentId" runat="server" Value='<%#Container.DataItem("paperID")%>' />--%>
                                                                                                                                                                             </td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="right">
                                                                                                                                                                            <asp:ImageButton ID="btnSave" ImageUrl="../Images/save.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="FileSave" runat="server" />
                                                                                                                                                                            &nbsp; &nbsp;
                                                                                                                                                                            <asp:ImageButton ID="btnClose" ImageUrl="../Images/close.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="FileCancel" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </table>
                                                                                                                                                            </div>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <tr>
                                                                                                                            <td colspan="100%">
                                                                                                                                <div id="divChild<%# Eval("ModuleID") %>" style="display: none; position: relative;
                                                                                                                                    left: 25px; ">
                                                                                                                                    <asp:GridView ID="GrdPaper" OnRowDataBound="GrdPaper_RowDataBound" AutoGenerateColumns="false"
                                                                                                                                        DataKeyNames="paperID" Width="97%" runat="server" OnRowCommand="GrdPaper_RowCommand" CssClass="table"
                                                                                                                                        OnRowDeleting="GrdPaper_RowDeleting">
                                                                                                                                        <HeaderStyle CssClass="grid-header-Overtime" />
                                                                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                                                                        <HeaderStyle CssClass="grid-header-Overtime" />
                                                                                                                                        <Columns>
                                                                                                                                            <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <a href="javascript:expandcollapse('divGrandChild<%# Eval("paperID") %>', 'one');">
                                                                                                                                                        <img id="imgdivGrandChild<%# Eval("paperID") %>" alt="Click to show/hide Module <%# Eval("paperID") %>"
                                                                                                                                                            width="9px" border="0" src="../images/plus.gif" />
                                                                                                                                                    </a>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField Visible="false">
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Label ID="lblSid" Text='<%# Eval("SemID") %>' runat="server"></asp:Label>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField Visible="false">
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Label ID="lblMID" Text='<%# Eval("ModuleID") %>' runat="server"></asp:Label>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField Visible="false">
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Label ID="lblpaperID" Text='<%# Eval("paperID") %>' runat="server"></asp:Label>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField HeaderText="Paper" ItemStyle-HorizontalAlign="Left">
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:Label ID="lblPaperTitle" Text='<%# Eval("PaperTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                   <%-- <a id="ancEditPaper" href="javascript:openPopup1('AddPaper.aspx?paperID=<%#Container.DataItem("paperID")%>&ModuleId=<%#Container.DataItem("ModuleID")%>')">
                                                                                                                                                                                    Edit Paper </a>--%>
                                                                                                                                               <a id="ancEditUnit" onclick='OpenDiv(divEditPap<%#Container.DataItem("PaperID")%>);'>
                                                                                                                                                        Edit Paper </a>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <asp:LinkButton ID="lnkDeletePaper" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex+1 %>' OnClientClick="return confirm('Are you sure you want to delete this paper?');">Delete 
                                                                                                                                                    Paper</asp:LinkButton>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                               <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                  <%--  <a id="ancAddUnit" href="javascript:openPopup1('AddUnit.aspx?pid=<%#Container.DataItem("paperID")%>&Mid=<%#Container.DataItem("ModuleID")%>&sid=<%#Container.DataItem("SemID")%>')">
                                                                                                                                                        Add Unit </a>--%>
                                                                                                                                                    <a id="ancAddUnit" onclick='OpenDiv(divAUnit<%#Container.DataItem("paperID")%><%#Container.DataItem("ModuleID")%><%#Container.DataItem("SemID")%>);'>
                                                                                                                                                        Add Unit </a>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                             <asp:TemplateField>
                                                                                                                                             <ItemTemplate>
                                                                                                                                            <%--  <asp:HiddenField ID="id" runat="server" Value='<%# Container.DisplayIndex+1 %>' />--%>
                                                                                                                                              <asp:HiddenField ID="hdnParentId" runat="server" Value='<%#Container.DataItem("paperID")%>' />
                                                                                                                                                                            <asp:HiddenField ID="hdnModuleID" runat="server" Value='<%#Container.DataItem("ModuleID")%>' />
                                                                                                                                                                            <asp:HiddenField ID="hdnSemID" runat="server" Value='<%#Container.DataItem("SemID")%>' />
                                                                                                                                                                            <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#Container.DataItem("courseID")%>' />
                                                                                                                                                                       
                                                                                                                                             </ItemTemplate>
                                                                                                                                             </asp:TemplateField>
                                                                                                                                                 <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <tr>
                                                                                                                                                        <td colspan="100%">
                                                                                                                                                            <div id='divEditPap<%#Container.DataItem("PaperID")%>'
                                                                                                                                                                style="display: none; position: relative; left: 5px; ">
                                                                                                                                                                <table style="width: 480px; background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                                                                            Paper
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="100px" align="left">
                                                                                                                                                                            <asp:TextBox ID="txtEditPaperName" Text='<%# Eval("PaperTitle") %>' runat="server"></asp:TextBox>
                                                                                                                                                                        </td>
                                                                                                                                                                        
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;
                                                                                                                                                                            
                                                                                                                                                                                                                                                                                                
                                                                                                                                                                        </td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="right">
                                                                                                                                                                            <asp:ImageButton ID="btnEditSave" ImageUrl="../Images/save.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="EditPaper" runat="server" />
                                                                                                                                                                            &nbsp; &nbsp;
                                                                                                                                                                            <asp:ImageButton ID="btnEditClose" ImageUrl="../Images/close.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="PaperCancel" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </table>
                                                                                                                                                            </div>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                         
                                                                                                                                              <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <tr>
                                                                                                                                                        <td colspan="100%">
                                                                                                                                                            <div id='divAUnit<%#Container.DataItem("paperID")%><%#Container.DataItem("ModuleID")%><%#Container.DataItem("SemID")%>'
                                                                                                                                                                style="display: none; position: relative; left: 5px; ">
                                                                                                                                                                <table style="width: 480px; background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                                                                            Unit
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="100px" align="left">
                                                                                                                                                                            <asp:TextBox ID="txtUnitName" runat="server"></asp:TextBox>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="150px" align="left" style="padding-right: 0px">
                                                                                                                                                                            Upload File
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="150px" align="left">
                                                                                                                                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                                                                            View Mode
                                                                                                                                                                        </td>
                                                                                                                                                                         <td width="50px" align="left" style="padding-right: 0px" colspan="3">
                                                                                                                                                                            <asp:DropDownList ID="ddlViewMode" runat="server">
                                                                                                                                                                                 <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                                                                                                 <asp:ListItem Value="1">Download</asp:ListItem>
                                                                                                                                                                                 <asp:ListItem Value="2">View</asp:ListItem>
                                                                                                                                                                            </asp:DropDownList>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr> 
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px;">
                                                                                                                                                                           Note -
                                                                                                                                                                        </td>
                                                                                                                                                                         <td width="50px" align="left" style="padding-right: 0px" colspan="3">
                                                                                                                                                                         Please upload Doc, PDF, Videos file only.
                                                                                                                                                                         </td>
                                                                                                                                                                         </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;
                                                                                                                                                                            </td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="right">
                                                                                                                                                                            <asp:ImageButton ID="btnSave" ImageUrl="../Images/save.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="AddUnit" runat="server" />
                                                                                                                                                                            &nbsp; &nbsp;
                                                                                                                                                                            <asp:ImageButton ID="btnClose" ImageUrl="../Images/close.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="FileCancel" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </table>
                                                                                                                                                            </div>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                            <asp:TemplateField>
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <tr>
                                                                                                                                                        <td colspan="100%">
                                                                                                                                                            <div id="divGrandChild<%# Eval("paperID") %>" style="display: none; position: relative;
                                                                                                                                                                left: 25px; ">
                                                                                                                                                                <asp:GridView ID="grdUnit" AutoGenerateColumns="false" DataKeyNames="UnitId" Width="97%" CssClass="table"
                                                                                                                                                                    OnRowCommand="grdUnit_RowCommand" OnRowDeleting="grdUnit_RowDeleting" runat="server">
                                                                                                                                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                                                                                                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                                                                                                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                                                                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                                                                                                                                    <Columns>
                                                                                                                                                                        <asp:TemplateField Visible="false">
                                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                                <asp:Label ID="lblUnitId" Text='<%# Eval("UnitId") %>' runat="server"></asp:Label>
                                                                                                                                                                            </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                                        <asp:TemplateField HeaderText="Unit" ItemStyle-HorizontalAlign="Left">
                                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                                <asp:Label ID="lblUnitTitle" Text='<%# Eval("UnitTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                                                                                                                            </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>

                                                                                                                                                                         <asp:TemplateField>
                                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                              <a href="AddUnitWithAssestment.aspx?pid=<%#Container.DataItem("paperID")%>&Mid=<%#Container.DataItem("ModuleID")%>&sid=<%#Container.DataItem("SemID")%>&unitid=<%#Container.DataItem("UnitID")%>">Add Unit With Assetment</a>                                                                                                                                                                            </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                                        <asp:TemplateField>
                                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                               <%-- <a id="ancEditUnit" href="javascript:openPopup1('AddUnit.aspx?paperID=<%#Container.DataItem("paperID")%>&UnitId=<%#Container.DataItem("UnitId")%>&Moduleid=<%#Container.DataItem("ModuleID")%>')">
                                                                                                                                                                                    Edit Unit </a>--%>
                                                                                                                                                                                        <a id="ancEditUnit" onclick='OpenDiv(divEditUnit<%#Container.DataItem("UnitID")%>);'>
                                                                                                                                                                                                Edit Unit </a>
                                                                                                                                                                            </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                                        <asp:TemplateField>
                                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                                <asp:LinkButton ID="lnkDeleteUnit" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex+1 %>' OnClientClick="return confirm('Are you sure you want to delete this unit?');">Delete 
                                                                                                                                                                                Unit</asp:LinkButton>
                                                                                                                                                                            </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                                        <asp:TemplateField>
                                                                                                                                                                       <ItemTemplate>
                                                                                                                                                                         <%-- <asp:HiddenField ID="id" runat="server" Value='<%# Container.DisplayIndex+1 %>' />--%>
                                                                                                                                                                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%#Container.DataItem("UnitId")%>' />
                                                                                                                                                                              <asp:HiddenField ID="hdnParentId" runat="server" Value='<%#Container.DataItem("paperID")%>' />
                                                                                                                                                                            <asp:HiddenField ID="hdnModuleID" runat="server" Value='<%#Container.DataItem("ModuleID")%>' />
                                                                                                                                                                            <asp:HiddenField ID="hdnSemID" runat="server" Value='<%#Container.DataItem("SemID")%>' />
                                                                                                                                                                            <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#Container.DataItem("courseID")%>' />
                                                                                                                                                                             <asp:HiddenField ID="hdnUploadFilePath" runat="server" Value='<%#Container.DataItem("UploadFilePath")%>' />     
                                                                                                                                                                       </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                                           <asp:TemplateField>
                                                                                                                                                                          
                                                                                                                                                <ItemTemplate>
                                                                                                                                                    <tr>
                                                                                                                                                        <td colspan="100%">
                                                                                                                                                            <div id='divEditUnit<%#Container.DataItem("UnitId")%>'
                                                                                                                                                                style="display: none; position: relative; left: 5px; ">
                                                                                                                                                                <table style="background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                                                                            Unit
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="100px" align="left">
                                                                                                                                                                            <asp:TextBox ID="txtEditUnitName" Text='<%# Eval("UnitTitle") %>' runat="server"></asp:TextBox>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="150px" align="left" style="padding-right: 0px">
                                                                                                                                                                            Upload File
                                                                                                                                                                        </td>
                                                                                                                                                                        <td width="150px" align="left">
                                                                                                                                                                            <asp:FileUpload ID="FileEditUpload1" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                     <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px">
                                                                                                                                                                            View Mode
                                                                                                                                                                        </td>
                                                                                                                                                                         <td width="50px" align="left" style="padding-right: 0px" colspan="3">
                                                                                                                                                                            <asp:DropDownList ID="ddlViewMode" runat="server">
                                                                                                                                                                                 <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                                                                                                 <asp:ListItem Value="1">Download</asp:ListItem>
                                                                                                                                                                                 <asp:ListItem Value="2">View</asp:ListItem>
                                                                                                                                                                            </asp:DropDownList>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr> 
                                                                                                                                                                     <tr>
                                                                                                                                                                        <td width="50px" align="left" style="padding-right: 0px;">
                                                                                                                                                                           Note -
                                                                                                                                                                        </td>
                                                                                                                                                                         <td width="50px" align="left" style="padding-right: 0px" colspan="3">
                                                                                                                                                                         Please upload Doc, PDF, Videos file only.
                                                                                                                                                                         </td>
                                                                                                                                                                         </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            &nbsp;
                                                                                                                                                                                                                                                                                                        
                                                                                                                                                                        </td>
                                                                                                                                                                        <td>
                                                                                                                                                                            &nbsp;
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="right">
                                                                                                                                                                            <asp:ImageButton ID="btnEditSave" ImageUrl="../Images/save.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="FileSave" runat="server" />
                                                                                                                                                                            &nbsp; &nbsp;
                                                                                                                                                                            <asp:ImageButton ID="btnEditClose" ImageUrl="../Images/close.png" CommandArgument='<%# Container.DisplayIndex+1 %>'
                                                                                                                                                                                CommandName="FileCancel" runat="server" />
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </table>
                                                                                                                                                            </div>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                                                    </Columns>
                                                                                                                                                                </asp:GridView>
                                                                                                                                                            </div>
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </ItemTemplate>
                                                                                                                                            </asp:TemplateField>
                                                                                                                                        </Columns>
                                                                                                                                    </asp:GridView>
                                                                                                                                </div>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <%--   <HeaderStyle HorizontalAlign="Left" />
                                                                                   <ItemStyle HorizontalAlign="Center" />--%>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                </div>
                </div>
                </div>
                    
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            
                               
    </section>
                
    </div>
    </form>


</asp:Content>
