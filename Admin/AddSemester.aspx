<%@ Page Language="VB" MasterPageFile="~/InnerMaster.master"  AutoEventWireup="false" CodeFile="AddSemester.aspx.vb" Inherits="Admin_AddSemester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

    <%--<link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />--%>
    <title>Edit Course</title>
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

            var div = document.getElementById(obj);
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
    <h1 class="heading-color">Add Semester</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Semester</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()" onclick="javascript:HideMessage()">
       
                              
       <section class="container main m-tb">

                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">             
                                       
                                        
                                                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            </div></div>
                                            <div class="user-info media box" style="background-color:#fff;">
<div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:GridView ID="grdSemester" runat="server" CssClass="table" AutoGenerateColumns="False" Width="100%"
                                                                                DataKeyNames="SemID" OnRowDataBound="grdSemester_RowDataBound" OnRowCommand="grdSemester_RowCommand"
                                                                                OnRowDeleting="grdSemester_RowDeleting">
                                                                                <HeaderStyle CssClass="form_head" />
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
                                                                                                            <div id='divNMod<%#Container.DataItem("SemID")%>'
                                                                                                                style="display: none; position: relative; left: 5px; width: 500px">
                                                                                                                <table style="width: 480px; background-color: #5984b0;">
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
                                                                                                        left: 15px;">
                                                                                                        <asp:GridView ID="GrdModule" CssClass="table" AutoGenerateColumns="False" DataKeyNames="ModuleID"
                                                                                                            Width="100%" runat="server" OnRowDataBound="GrdModule_RowDataBound" OnRowCommand="GrdModule_RowCommand"
                                                                                                            OnRowDeleting="GrdModule_RowDeleting">
                                                                                                            <HeaderStyle CssClass="table_subhead" />
                                                                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
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
                                                                                                                        <asp:LinkButton ID="lnkDeleteModule" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex+1 %>' OnClientClick="return confirm('Are you sure you want to delete this module ?');">Delete 
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
                                                                                                                                                                style="display: none; position: relative; left: 5px; ">
                                                                                                                                                                <table style="width: 480px; background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td  align="left" style="padding-right: 0px">
                                                                                                                                                                            Paper
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="left">
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
                                                                                                                                    <asp:GridView ID="GrdPaper" CssClass="table" OnRowDataBound="GrdPaper_RowDataBound" AutoGenerateColumns="false"
                                                                                                                                        DataKeyNames="paperID" Width="97%" runat="server" OnRowCommand="GrdPaper_RowCommand"
                                                                                                                                        OnRowDeleting="GrdPaper_RowDeleting">
                                                                                                                                        <HeaderStyle CssClass="table_subhead" />
                                                                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
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
                                                                                                                                               <a id="ancEditUnit" onclick='OpenDiv(divEdit<%#Container.DataItem("PaperID")%>);'>
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
                                                                                                                                                            <div id='divEdit<%#Container.DataItem("PaperID")%>'
                                                                                                                                                                style="display: none; position: relative; left: 5px; width: 500px">
                                                                                                                                                                <table style="background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="left" style="padding-right: 0px">
                                                                                                                                                                            Paper
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="left">
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
                                                                                                                                                                <table style="background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="left" style="padding-right: 0px">
                                                                                                                                                                            Unit
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="left">
                                                                                                                                                                            <asp:TextBox ID="txtUnitName" runat="server"></asp:TextBox>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td  align="left" style="padding-right: 0px">
                                                                                                                                                                            Upload File
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="left">
                                                                                                                                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
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
                                                                                                                                                            <div id="divGrandChild<%# Eval("paperID") %>" style="display: none; position: relative;
                                                                                                                                                                left: 25px; ">
                                                                                                                                                                <asp:GridView ID="grdUnit" CssClass="table" AutoGenerateColumns="false" DataKeyNames="UnitId" Width="97%"
                                                                                                                                                                    OnRowCommand="grdUnit_RowCommand" OnRowDeleting="grdUnit_RowDeleting" runat="server">
                                                                                                                                                                    <HeaderStyle CssClass="table_subhead" />
                                                                                                                                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                                                                                                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
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
                                                                                                                                                                               <%-- <a id="ancEditUnit" href="javascript:openPopup1('AddUnit.aspx?paperID=<%#Container.DataItem("paperID")%>&UnitId=<%#Container.DataItem("UnitId")%>&Moduleid=<%#Container.DataItem("ModuleID")%>')">
                                                                                                                                                                                    Edit Unit </a>--%>
                                                                                                                                                                                        <a id="ancEditUnit" onclick='OpenDiv(divEditUnit<%#Container.DataItem("UnitID")%>);'>
                                                                                                                                                                                                Edit Unit </a>
                                                                                                                                                                            </ItemTemplate>
                                                                                                                                                                        </asp:TemplateField>
                                                                                                                                                                        <asp:TemplateField>
                                                                                                                                                                            <ItemTemplate>
                                                                                                                                                                                <asp:LinkButton ID="lnkDeleteUnit" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex+1 %>' OnClientClick="return confirm('Are you sure you want to delete this unit ?');">Delete 
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
                                                                                                                                                                <table style=" background-color: #5984b0;">
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td  align="left" style="padding-right: 0px">
                                                                                                                                                                            Unit
                                                                                                                                                                        </td>
                                                                                                                                                                        <td  align="left">
                                                                                                                                                                            <asp:TextBox ID="txtEditUnitName" Text='<%# Eval("UnitTitle") %>' runat="server"></asp:TextBox>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td  align="left" style="padding-right: 0px">
                                                                                                                                                                            Upload File
                                                                                                                                                                        </td>
                                                                                                                                                                        <td align="left">
                                                                                                                                                                            <asp:FileUpload ID="FileEditUpload1" runat="server" />
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
                                                                            </div></div>
                                                                            </div>
                                                                            </section>
                      
    </div>
    </form>
    </asp:content>

