<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="Adminlogin.aspx.vb" Inherits="AdminLogin" Title="Admin Panel" %>

<%--<%@ Register src="../AdminHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../Footer.ascx" tagname="Footer" tagprefix="uc2" %>--%>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../stmenu.js"></script>

    <title>Admin Panel</title>
     
</head>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<script type="text/javascript" src="../stmenu.js"></script>
<style>body>section {
    margin-top: 0;
}
</style>

   <section class="fullwidth banner-color">
	<h1 class="heading-color">Administrator Panel</h1> 
   <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        
		</ul>
	</div>
</section>
    <form id="form1" runat="server">
  

    <section class="container main" style="margin-top:10em;">
    <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="container item-container">
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddCourse.aspx"><img src="../images/add_course.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListCourse.aspx"><img src="../images/manage_course.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddBatch.aspx"><img src="../images/add_batch.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListBatch.aspx"><img src="../images/manage_batch.png"  style="border:0px" /></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="../Registration1.aspx"><img src="../images/add_student.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ManageStudentInfo.aspx"><img src="../images/mange_students.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListTopic.aspx"><img src="../images/discussion_forum.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListEvent.aspx"><img src="../images/events.png"  style="border:0px" /></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddAssignmentSet.aspx"><img src="../images/add_assignment.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AssignmentActivateExam.aspx"><img src="../images/assign_assignment.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AssignmentPanel.aspx"><img src="../images/manage_assignment.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddExamSet.aspx"><img src="../images/add_exam.png"  style="border:0px" /></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="activateExam.aspx"><img src="../images/assign_exam.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ExamPanel.aspx"><img src="../images/manage_exam.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="../Report/ReportList.aspx"><img src="../images/report.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddSampleSet.aspx"><img src="../images/sample_paper.png"  style="border:0px" /></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ReminderMail.aspx"><img src="../images/mass_mail.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListFaculty.aspx"><img src="../images/list_of_faculty.png" style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="addpaperfile.aspx"><img src="../Images/upload_lecture.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="../Student/ChangePassword.aspx?chadmin=1"><img src="../images/change_password2.png" style="border:0px"/></a></div>
                </div>
                
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddScreeningSet.aspx"><img src="../images/add_screening.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ScreeningActivateExam.aspx"><img src="../images/assign_screening.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ScreeningPanel.aspx"><img src="../images/manage_screening.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListNews.aspx"><img src="../images/news.png"  style="border:0px"/></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListQuery.aspx"><img src="../images/student_queries.png" style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="courseID.aspx"><img src="../Images/evaluation_criteria.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><%-- <a href="AddSampleSet.aspx"> add sample</a> --%><%--<a href="FacultyLoginReport.aspx" visible="false"></a>--%>
                                                   <%--         <a href="SampleActivateExam.aspx">Assign Sample</a>--%>
                                                            <a href="courselist.aspx"><img src="../Images/course_details.png" style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="addaboutus.aspx"><img src="../Images/about_us.png" style="border:0px"/></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="addcontactus.aspx"><img src="../images/contact_us.png" style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ListCourseHelp.aspx" ><img src="../Images/Calendar_helpDesk_Brouchure.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="../chat/Default.aspx"><img src="../Images/VideoConf.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="KnowledgecenterList.aspx"><img src="../Images/KnowledgeCenter.png" style="border:0px" /></a></div>
                </div>

                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="DemoVideo.aspx"><img src="../Images/DemoVideo.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="TestimonialList.aspx"><img src="../Images/TestiList.png" style="border:0px" /></a></div> 
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="CallBackList.aspx"><img src="../Images/CallbackList.png" style="border:0px" /></a></div> 
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="EventManagementList.aspx"><img src="../Images/event_management.png" style="border:0px" /></a></div> 
                </div> 

                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddInduction.aspx"><img src="../Images/induction_list.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"></div>
                </div> 
                </div>
                                                   
                </div>
                    </div>
                    
                    </section>
                
    </form>

</asp:Content>
