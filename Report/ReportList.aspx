<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="ReportList.aspx.cs" Inherits="Admin_ReportList" Title="Report List" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Report List </title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
 <script language="javascript" type="text/javascript">
                                   
//    function openPopup()
//                     {
//                    open("BatchReport.aspx", "Info", "status=1, width=910, height=650, top=20, left=100");
//                      }                 
//                     
//     function openPopup1()
//                     {
//                    open("StudentReport.aspx", "Info", "status=1, width=910, height=650, top=20, left=300");
//                      }                                     
                     
    </script>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
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
    <h1 class="heading-color">Report Panel<asp:Label ID="lblCaption" runat="server" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li class="active">Report Panel</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
        

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                            
    <div class="container item-container">
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="BatchReport.aspx"><img src="../images/batch_report.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="FacultyReport.aspx"><img src="../images/faculty_report.png"   style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="QueryReport.aspx"><img src="../images/query_report.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="StudentNewReport.aspx"><img src="../images/student_report.png"  style="border:0px" /></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="TopicReport.aspx"><img src="../images/topic_report.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="CurrentBatchStatus.aspx"><img src="../images/current_batch_status_report.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="SuccessfullyCompletedCourseReport.aspx"><img src="../images/successfully_completed_course_report.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="StudentInMutipleCourseReport.aspx"><img src="../images/student_in_multiple_courses_report.png"  style="border:0px" /></a> </div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ActiveExamReport.aspx"><img src="../images/activate_exam_list.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="StudentActiveExamReport.aspx"><img src="../images/activate_student_for_exam_set.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="FacultyLoginRepot1.aspx"><img src="../images/faculty_login_report.png" style="border:0px" /></a> </div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="StudentLoginReport.aspx"><img src="../images/student_login_report.png"  style="border:0px" /></a></div>
                </div>                                        
                  <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ActiveStudentsReport.aspx"><img src="../images/active_student_report.png"  style="border:0px"/></a></div>                                 
                
                </div>
                </div>
                </div>
                </div>
                            </section>
                                      </ContentTemplate>
                                      </asp:UpdatePanel>
                                
                            
                  
                                             
    </form>

</asp:Content>

