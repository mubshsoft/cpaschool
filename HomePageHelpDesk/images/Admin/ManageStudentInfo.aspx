<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ManageStudentInfo.aspx.vb" Inherits="Admin_ManageStudentInfo" Title="Student Info" %>

<%--<%@ Register src="../AdminHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../Footer.ascx" tagname="Footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Student Info</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Student Panel</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Student Panel</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">

   

    <section class="container main m-tb">
    <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="container item-container">
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="ListStudentForEditprofile.aspx"><img src="../images/edit_profile.png" style="border:0px"    /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="AdminListCourse.aspx"><img src="../images/promotion_criteria.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="ChangePwd.aspx"><img src="../images/password_info.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="ListStudentPromote.aspx"><img src="../images/promote_semester.png"  style="border:0px" /></a></div>
                </div>
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="listStudent.aspx"><img src="../images/approve_application.png"  style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="ApplyAnotherCourse.aspx"><img src="../Images/Register_for_another_course.png"  style="border:0px"/></a></div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="SelectExamSet.aspx"><img src="../images/update_marks.png"  style="border:0px" /></a>   </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="SelectStudentPerformance.aspx"><img src="../images/performence_sheet.png" style="border:0px" /></a></div>
               
                </div>
                    <div class="row" style="padding: 30px 0 30px 0;">
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="EditprofileForUnassignedStudent.aspx"><img src="../images/edit_profile_unassign.png" style="border:0px"    /></a></div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"><a href="GeneratestudentIDCard.aspx"><img src="../images/generate_id.png" style="border:0px"    /></a></div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"></div>
                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 center"></div>
                    </div>
                </div>
                </div>
                </div>
                </section>



    
    </form>


</asp:Content>
