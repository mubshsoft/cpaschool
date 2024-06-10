<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AddEvaluationCriteria.aspx.cs" Inherits="AddEvaluationCriteria" Title="Add Evaluation Criteria" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Add Evaluation Criteria</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />--%>
    
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Evaluation Criteria" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Query</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="frame">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        

    <section class="container main m-tb">
     <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row" >
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:CheckBox ID="ChkExamM" runat="server" /> Exam Marks</div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:CheckBox ID="chkAssignM" runat="server" /> Assignment Marks</div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:CheckBox ID="chkDFM" runat="server" /> Discussion Forum Marks</div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:CheckBox ID="chkProjectM" runat="server" /> Project Marks</div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:CheckBox ID="chkCaseStudy" runat="server" /> Case Study Marks</div>
    </div>
                                                                    
                                                            
                                                            
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
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtColumn1" runat="server" placeholder="Marks1 Column Name" ToolTip="Marks1 Column Name" CssClass="form-control" ></asp:TextBox></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtColumn2" runat="server" placeholder="Marks2 Column Name" ToolTip="Marks2 Column Name" CssClass="form-control" ></asp:TextBox></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" PostBackUrl="~/Admin/CourseID.aspx" />
    <asp:Button ID="btnSave" runat="server" Text="Save & Continue" CssClass="btn btn-large btn-success" OnClick="btnSave_Click" ValidationGroup="1" />
    </div></div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdnCourseId" runat="server" /></div>
    </div>
    </div>
                                                   
                                            </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
   
    
    </div>
    </form>
</asp:Content>
