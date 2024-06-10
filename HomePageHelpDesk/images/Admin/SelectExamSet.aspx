<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="SelectExamSet.aspx.cs" Inherits="SelectExamSet" Title="Course Evaluation Criteria" %>


<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Course Evaluation Criteria</title>--%>

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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-family:Verdana,Arial,Tahoma; font-size:10px; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}
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
    <h1 class="heading-color">Update Marks</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Update Marks</li>
		</ul>
	</div>
    </section>
    
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

  

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="user-info media box" style="background-color:#fff;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:button ID="btnback" runat="server" Text="Back" CssClass="btn btn-large btn-primary" onclick="btnback_Click" /></span></div>
    </div>
    <div class="row" >&nbsp;</div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" AutoPostBack="true"  runat="server" ToolTip="Course Code" CssClass="input-block-level" onselectedindexchanged="ddlCourse_SelectedIndexChanged" />
    <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlbatch" AutoPostBack="true"  runat="server" ToolTip="Batch Id" CssClass="input-block-level"  />
    <asp:Label ID="lblBatch" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
     <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlSem" AutoPostBack="true"  runat="server" ToolTip="Semester" CssClass="input-block-level" onselectedindexchanged="ddlSem_SelectedIndexChanged" />
                                                          <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlModule" AutoPostBack="true"  runat="server" ToolTip="Module" CssClass="input-block-level" onselectedindexchanged="ddlModule_SelectedIndexChanged" />
                                                          <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>  
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlPaper"  runat="server" ToolTip="Paper" CssClass="input-block-level" />
                                                       <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:HiddenField ID="hdncoursecode" runat="server" /></div>
    </div> 
    <div class="row" >&nbsp;</div>
    <div class="row" >
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="text-align:center">
    <asp:Button ID="lnkExam" runat="server" Enabled="false" onclick="lnkExam_Click" Text="Exam Marks" CssClass="btn btn-large btn-success" />
    </div>
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="text-align:center">
    <asp:Button ID="lnkAssign" runat="server" Enabled="false" onclick="lnkAssign_Click" Text="Assignment Marks" CssClass="btn btn-large btn-warning" />
     </div>
     <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="text-align:center">
    <asp:Button ID="lnkDiscussion" runat="server" Enabled="false" onclick="lnkDiscussion_Click" Text="Discussion Forum Marks" CssClass="btn btn-large btn-primary" />
     </div>
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="text-align:center">
    <asp:Button ID="lnkProject" runat="server" Enabled="false" onclick="lnkProject_Click" Text="Project Marks" CssClass="btn btn-large btn-danger" />
                                                            <div style="display:none"> &nbsp;
                                                            <asp:Button ID="lnkColumn1" runat="server" onclick="lnkColumn1_Click" Visible="false" />
                                                            &nbsp;
                                                            <asp:Button ID="lnkColumn2" runat="server" onclick="lnkColumn2_Click"  Visible="false" />
                                                            </div>
                                                            </div>
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="text-align:center">
    <asp:Button ID="btnCaseStudy" runat="server" Enabled="false" onclick="lnkCaseStudy_Click" Text="Case Study Marks" CssClass="btn btn-large btn-primary" />
     </div>
                                                            </div>
    </div>
    
    
                                                </ContentTemplate>
                                                </asp:UpdatePanel> 
                                                </div>
                                           
   
    </div>
    </div>
    </section>
    </div>
   
    </form>
</asp:Content>

