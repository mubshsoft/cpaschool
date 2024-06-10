<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="FacultyPanel.aspx.vb" Inherits="FacultyPanel" Title="Faculty Panel" %>

<%--<%@ Register src="../FacultyHeader.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Faculty Panel</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       
		</ul>
	</div>
    </section>
<form id="form1" runat="server">

    <!-- / .title -->
    <section class="container main m-tb">
        <marquee onmouseover="scrollAmount=0" direction="left" onmouseout="scrollAmount=2"
                                                                                    scrollamount="2" width="100%">
                                                                                               
                                                                                                 <%  
                                                                                                        Try
                                                                                                            Dim strq As String = "select NewsDesc as descr,newsdate as ndate from News where NewsType='Faculty'"
                                                                                                            Dim dsfacNews As New DataSet()
                                                                                                            dsFacNews = CLS.fnQuerySelectDs(strq)
                                                                                                                                                                                                                       
                                                                                                            Dim i As Integer
                                                                                                            Dim dcOunt As Integer
                                                                                                            If dsFacNews IsNot Nothing Then
                                                                                                                If dsFacNews.Tables IsNot Nothing Then
                                                                                                                    If dsFacNews.Tables(0).Rows IsNot Nothing Then
                                                                                                                        If dsFacNews.Tables(0).Rows.Count > 0 Then
                                                                                                                            dcOunt = dsFacNews.Tables(0).Rows.Count
                                                                                                                            For i = 0 To dcOunt - 1
                                                                                                                             Dim sNewDesc As String = dsfacNews.Tables(0).Rows(i)("descr").ToString & " . "
                                                                                                                                sNewDesc = sNewDesc.Replace("dq$", """")
                                                                                                                                sNewDesc = sNewDesc.Replace("com$", ",")
                                                                                                                                sNewDesc = sNewDesc.Replace("q$", "'")
                                                                                                                                sNewDesc = sNewDesc.Replace("amp$", "&")
                                                                                                                                 strnews = strnews & sNewDesc 
                                                                                                                            
                                                                                                                           
                                                                                                                                                                                                                                                          
                                                                                                                       
                                                                                                      Next
                                                                                                      End If
                                                                                                     End If
                                                                                                 End If
                                                                                             End If
                                                                                         Catch ex As Exception

                                                                                         End Try  %>
                                                                                                         
                                                                                                       
                                                                                            
                                                                                         <div style="font-family: tahoma;font-size: 11px;color: #808080;">   <%=strnews%></div></marquee>  
                                                    
         <div class="row" style="margin-top: 20px;">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="user-info media box" style="background-color:#fff">
                        <div class="row" style="padding: 30px 0 30px 0;">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="../Admin/FacultyRegistration.aspx?fid=1"><img src="../images/manage_profile.png"  style="border:0px"  /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="../Student/ChangePassword.aspx?chfaculty=1"><img src="../images/change_password2.png" style="border:0px"  /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="ListQuery.aspx"><img src="../images/student_queries.png" style="border:0px"  /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="../MainForumPage1.aspx"><img src="../images/discussion_forum.png" style="border:0px"/></a></div>
                        </div>
                        <div class="row" style="padding: 30px 0 30px 0; ">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="Facultylistcontent.aspx"><img src="../Images/download_course_contents.png" style="border:0px" /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="ReportPage.aspx"><img src="../images/report.png" style="border:0px"/></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="../admin/BulkMail.aspx?facmail=1"><img src="../images/mass_mail.png"  style="border:0px"/></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="AddPaperFile.aspx"><img src="../Images/upload_lecture.png"  style="border:0px"/></a></div>
                        </div>
                        <div class="row" style="padding: 30px 0 30px 0; ">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="../chat/Default.aspx"><img src="../Images/VideoConf.png" style="border:0px" /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="FacultyListAssignment.aspx"><img src="../images/assignment.png" style="border:0px" /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="FacultyListExam.aspx"><img src="../images/manage_exam.png" style="border:0px" /></a></div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="ProgressReport.aspx"><img src="../images/progress_report.png" style="border:0px" /></a></div>
                        </div>
                         <div class="row" style="padding: 30px 0 30px 0; ">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><asp:LinkButton ID="LinkButton2" ToolTip="Add Group" runat="server" PostBackUrl="~/Faculty/AddGroup.aspx"><img src="../images/add_group.png" style="border:0px" /></asp:LinkButton> </div>
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"><a href="FacultyListCaseStudy.aspx"><img src="../images/case_study.png" style="border:0px" /></a></div>
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"></div>
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="center"></div>
                             </div> 
                        
                     </div>
              <%--</div>--%>
          </div>                                          

</div>
                                                                                                 
    
    </section>
    </form>



</asp:Content>
