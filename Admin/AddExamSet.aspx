<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AddExamSet.aspx.cs" Inherits="Admin_AddExamSet" Title="Add ExamSet" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add ExamSet</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Add Exam Set</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Exam Set</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
   

    <section class="container main m-tb">
    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>  
         <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <fieldset>
     <legend>Add new exam</legend>
      <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:TextBox ID="txtexamcode" runat="server" ToolTip="Exam Code" PlaceHolder="Exam Code" CssClass="form-control"></asp:TextBox>
 <asp:Label ID="lblreqexamcode" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
   <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
   </div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlSem" AutoPostBack="true" runat="server" ToolTip="Semester" CssClass="form-control" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" />
     <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlModule" AutoPostBack="true" runat="server" ToolTip="Module" CssClass="form-control" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" />
      <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlPaper" runat="server" ToolTip="Paper" CssClass="form-control" />
     <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:TextBox ID="txtTimeAllowted" runat="server" ToolTip="Time alloted" PlaceHolder="Time alloted" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="(In Minutes)" ></asp:Label>
                                                                                    <br />
      <asp:Label ID="lblTimeReq" runat="server" Text="" ForeColor="Red"></asp:Label>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTimeAllowted" Display="Dynamic" ErrorMessage="<br>Please enter numeric values" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
    </div>
    </div>                                                                  <table width="100%">
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdncoursecode" runat="server" /></div>
    </div>                                                                      
     <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:CheckBox ID="chkuseexam" runat="server" AutoPostBack="True"  OnCheckedChanged="chkuseexam_CheckedChanged" /> Use Existing Exam</div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="button1" Text="Save" CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click" />
                               <asp:Button ID="Imagebutton2" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx" />
                               </div>
                               </div>
                               
                                                                    </fieldset>
     </div>
     
   <fieldset>
   <div class="user-info media box" style="background-color:#fff;">
       <legend>View existing exam</legend>
        <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlcoursefillter" runat="server" AutoPostBack="True" ToolTip="Course" CssClass="form-control" OnSelectedIndexChanged="ddlcoursefillter_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" ToolTip="Year" CssClass="form-control" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" >
                                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                                    <asp:ListItem>2008</asp:ListItem>
                                                                                                    <asp:ListItem>2009</asp:ListItem>
                                                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                                                </asp:DropDownList>
    </div>
    </div>   
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">                                                              
                                                                                    <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                                                        DataKeyNames="ExamID" OnRowDataBound="grdExamSet_RowDataBound" OnRowEditing="grdExamSet_RowEditing"
                                                                                        OnRowUpdating="grdExamSet_RowUpdating" OnRowCommand="grdExamSet_RowCommand" OnRowDeleting="grdExamSet_RowDeleting"
                                                                                        OnRowCancelingEdit="grdExamSet_RowCancelingEdit" PagerSettings-LastPageText="Last"
                                                                                        PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" PageSize="10"
                                                                                        OnPageIndexChanging="grdExamSet_PageIndexChanging" AllowPaging="True">
                                                                                        <HeaderStyle CssClass="form_head" />
                                                                                        <PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                       <PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
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
                                                                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <%# (grdExamSet.PageSize * grdExamSet.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Exam Code">
                                                                                                <ItemStyle Width="50px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblexamcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ExamCode")%>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <a id="a1" href="ShowExam1.aspx?Examid=<%#Eval ("ExamId")%>">
                                                                                                        <%#Eval("ExamCode")%>
                                                                                                    </a>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Course Title">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Semester">
                                                                                                <ItemStyle Width="65px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Module">
                                                                                                <ItemStyle Width="55px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Paper">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Time Allotted">
                                                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeAllowted" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "TimeAllowted")%>'></asp:Label>
                                                                                                    &nbsp;
                                                                                                </ItemTemplate>
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="txtTimeAllowted" runat="server" MaxLength="300" CssClass="NormalText"
                                                                                                        Text='<%# Bind("TimeAllowted") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Date of creation">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblCreatedate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreateDate")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                                                ShowEditButton="True" ShowHeader="True">
                                                                                                <HeaderStyle HorizontalAlign="Right" Width="75px" />
                                                                                            </asp:CommandField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:HiddenField ID="hdnExamID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ExamId")%>' />
                                                                                                    <asp:LinkButton ID="lnkDetailsExam" runat="server" Font-Underline="false" Text="Add Exam Details"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkCopyExam" runat="server" Font-Underline="false" Text="Copy Questions"
                                                                                                        Visible="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEditDetailsExam" runat="server" Font-Underline="false" Text="Edit Exam Details"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDeleteExamSet" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ExamID") %>'>
                                                                     Delete</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                                </div>
                                                                                </div>
                                                                    </fieldset>
                                                               
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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
                                </div>
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
    </section>
    </div>
    </form>

</asp:Content>
