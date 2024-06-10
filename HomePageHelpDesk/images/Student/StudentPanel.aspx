<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="StudentPanel.aspx.vb" Inherits="StudentPanel" Title="Student Panel" %>
<%--<%@ Register src="../StudentHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../Footer.ascx" tagname="Footer" tagprefix="uc2" %>--%>


<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Student Panel</title>
       <script type="text/javascript" src="../stmenu.js"></script>
</head>
<body>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style>
    .notification
{
    background-color:#006699;
    min-height:40px;
    width:30%;
    margin:0 auto;
    text-align:center;
    line-height:50px;
    color:#fff;
    font-size:18px;
    box-shadow: 10px 10px 5px #888888;
}
</style>
<script type="text/javascript" src="../stmenu.js"></script>
<script language="javascript" type="text/javascript">
  
function openPopup(strOpen)
    {
        open(strOpen, "Info", "status=1, width=700, height=430,resizable=yes,scrollbars=yes, top=200, left=200");
    }
     
</script>
<script language="javascript" type="text/javascript">

    $(document).ready(function () {
        $("#btnShow").click(function () {  // Show notification on button click
            $('#ModalPopupDiv').modal('show');
        });

        $("#lnkDemoVideo").click(function () {  // Show notification on button click
            $('#' + popupId).modal('show');
        });
    });
    function openmodalPopUp(popupId) {
        // $('#ModalPopupDiv').modal('show');
        $('#' + popupId).modal('show');
    }
    function openPopUp1(popupId) {
        $('#' + popupId).modal('show');
        document.getElementById('tab2').firstChild.click();
    }
    function openPegePopUp(popupId, pageurl, ifrmaid) {
        $('#' + popupId).modal('show');
        var strifrmae = document.getElementById(ifrmaid);
        strifrmae.src = pageurl;
    }
    function openPege1PopUp(popupId, pageurl) {
        alert('hi');
        $('#myModal .modal-body').load("https://fiddle.jshell.net/");
        $('#' + popupId).modal('show');


    }
    </script>
   
    <form id="form1" runat="server">

    <section class="title">
        <div class="container">
            <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Student Panel</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li class="active">Student Panel</li>&nbsp;&nbsp; | &nbsp;&nbsp;<li class="active"><a href="../logout.aspx"><font color="#fff">Logout</font></a>&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1"
                        runat="server" Visible="False">Session LogOut</asp:LinkButton></li>
                    </ul>
                </div>
            </div>
           
        </div>
    </section>
    <section class="container main">
            <div class="row-fluid">
                <div class="span12">                   
                    <%  
                    Try
                        Dim strq As String = "select * from news inner join studentregbatch st on (st.bid=news.batch or st.courseid=news.course) where st.stid=" & Session("stid")
                        Dim dsNews As New DataSet()
                        dsNews = CLS.fnQuerySelectDs(strq)
                                                                                                            
                        Dim i As Integer
                        Dim dcOunt As Integer
                        If dsNews IsNot Nothing Then
                            If dsNews.Tables IsNot Nothing Then
                                If dsNews.Tables(0).Rows IsNot Nothing Then
                                    If dsNews.Tables(0).Rows.Count > 0 Then
                                        dcOunt = dsNews.Tables(0).Rows.Count
                                        For i = 0 To dcOunt - 1
                                                                         
                                                                         
                                            sNewDesc = sNewDesc & dsNews.Tables(0).Rows(i)("Newsdesc").ToString & ".&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                            sNewDesc = sNewDesc.Replace("dq$", """")
                                            sNewDesc = sNewDesc.Replace("com$", ",")
                                            sNewDesc = sNewDesc.Replace("q$", "'")
                                            sNewDesc = sNewDesc.Replace("amp$", "&")
                                        %>
                                        <% Next%>
                                                <marquee onmouseover="scrollAmount=0" direction="left" onmouseout="scrollAmount=2"
                                                                                    scrollamount="2">
                                                <%=sNewDesc%>                                                                             
                                    <%  End If
                                                    End If
                                                End If
                                            End If

                                        Catch ex As Exception
                                        End Try

                                                  %></marquee>
                                                
                                                        <div class="container item-container">
                                                             <div id="dvMsg" class="notification" runat="server" visible="false">
                                                                            <asp:Label ID="lblMsg" runat="server" Text="This is notification message.."></asp:Label>
                                                                      </div>
                                                        <div class="row-fluid" style="padding: 30px 0 30px 0;">

                                                        <div class="span3"><a href="EditStudentProfile.aspx"><img src="../images/manage_profile.png"  style="border:0px"   /></a></div>
                                                        <div class="span3"><a href="ChangePassword.aspx?chstudent=1"><img src="../images/change_password2.png"  style="border:0px"/></a></div>
                                                        <div class="span3"><a href="PostQueery.aspx?Post=1"><img src="../images/post_query.png"  style="border:0px"/></a> </div>
                                                         <div class="span3"><a href="StudentListCourse.aspx" id="lnkCourseMeterial" runat="server" >
                                                         <img src="../images/course_material.png"  style="border:0px" /></a></div>
                                                        </div>
                                                        <div class="row-fluid" style="padding: 30px 0 30px 0;">
                                                        <div class="span3"><a href="../MainForumPage.aspx">
                                                            <img src="../images/discussion_forum.png" style="border:0px"/>
                                                        </a></div>
                                                        <div class="span3"><a href="StudentPerformaneCourse.aspx"><img src="../images/performence_sheet.png"  style="border:0px" /></a></div>
                                                        
                                                        <div class="span3"><a href="FacultyList.aspx"><img src="../images/list_of_faculty.png"  style="border:0px"/></a></div>
                                                        <div class="span3"><a href="AssignmentSet.aspx"><img src="../images/assignment.png"  style="border:0px"/></a></div>
                                                        </div>
                                                        <div class="row-fluid" style="padding: 30px 0 30px 0;">
                                                        <div class="span3"><a href="ListCourseForFee.aspx">
                                                        <img src="../images/pay_your_fees.png"  style="border:0px"/></a>
                                                        </div>
                                                        <div class="span3">
                                                            <%--<a href="ExamSet.aspx"><img src="../images/online_exam.png"  style="border:0px"/></a>--%>
                                                             <asp:ImageButton ID="btnExamset" runat="server" ImageUrl="../images/online_exam.png" OnClick="btnExamset_Click" />
                                                          </div>
                                                        <div class="span3">
                                                        <img src="../images/virtual_class_room.png"  style="border:0px"/></div>

                                                        <div class="span3"> <a href="SampleSet.aspx">
                                                         <img src="../images/sample_paper.png"  style="border:0px"/></a>
                                                        </div>
                                                        </div>
                                                        <div class="row-fluid" style="padding: 30px 0 30px 0;">
                                                         <div class="span3"><a href="ApplyAnotherCourse.aspx"><img src="../Images/Register_for_another_course.png"  style="border:0px"/></a></div>
                                                        
                                                        
                                                        <div class="span3"><a href="StudentLectureListCourse.aspx"><img src="../Images/ViewLectures.png"  style="border:0px"/></a></div>
                                                        <div class="span3"><a href="../DetailsNewsEvents.aspx"><img src="../Images/news.png"  style="border:0px"/></a></div>
                                                        <div class="span3"><a href="../chat/Default.aspx"><img src="../Images/VideoConf.png" style="border:0px" /></a></div>                                                        
                                                        </div>
                                                            <div class="row-fluid" style="padding: 30px 0 30px 0;">
                                                         <div class="span3"> <asp:ImageButton ID="btnIDCard" runat="server" Text="ID Card" ImageUrl="./images/online_exam.png" OnClick="btnIDCard_Click" /></div>
                                                                <div class="span3">
                                                                    
                                                                 <input type="button" id="btnShow" value="Notification" />
                                                                    <div id="dialog" style="display: none" align = "center">
                                                                       
                                                                        <%--<asp:Repeater ID="rptNotification" runat="server" >
                   <ItemTemplate>
                   <div class="item">
                        <div class="row-fluid">
                        <ul style="margin-left:0">
                        <li>
                            
                            <div class="media-body" style="padding-left: 10px; text-align: justify; font-size:14px;">
                                <span style="font-family: sans-serif;color: #3498db;"><strong><i class="icon-calendar"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%> </strong></span>
                                <span style="font-family: sans-serif;color: #3498db;" class="pull-right"><%#DataBinder.Eval(Container.DataItem, "mailtype")%> </span>
                                <p style="border-top: solid 1px #cecdcd;padding-top: 6px;"><%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%></p>
                            
                            </div>
                         </li>
                        </ul>
                        </div>
                    </div>
                        </ItemTemplate>
                        </asp:Repeater>--%>
                                                                    </div>
                                                                </div>
                                                                 <div class="span3"><asp:LinkButton ID="lnkDemoVideo" Text="Demo video" runat="server" OnClick="lnkDemoVideo_Click"></asp:LinkButton> </div>
                                                                <div class="span3"><asp:LinkButton ID="lnkTestimonial" Text="Testimonial" ToolTip="Add You Testimonial" runat="server" PostBackUrl="~/Student/AddUpdateTestimonial.aspx"></asp:LinkButton></div>
                                                        </div>
                                                       
                </div>
            </div>
                                             
    </section>    
   
        <div class="modal hide fade in" id="ModalPopupDiv" aria-hidden="false">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Notification</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body">
        <asp:Repeater ID="rptNotification" runat="server" >
                   <ItemTemplate>
                   <div class="item">
                        <div class="row-fluid">
                        <ul style="margin-left:0">
                        <li>
                            
                            <div class="media-body" style="padding-left: 10px; text-align: justify; font-size:14px;">
                                <span style="font-family: sans-serif;color: #3498db;" ><%#DataBinder.Eval(Container.DataItem, "mailtype")%> </span>
                                <span style="font-family: sans-serif;color: #3498db;" class="pull-right"><strong><i class="icon-calendar"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%> </strong></span>
                                
                                <p style="border-top: solid 1px #cecdcd;padding-top: 6px;"><%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%></p>
                            
                            </div>
                         </li>
                        </ul>
                        </div>
                    </div>
                        </ItemTemplate>
                        </asp:Repeater>
    </div>
    <!--/Modal Body-->
</div>

        <div class="modal hide fade in" id="ModalPopupDivPlayVideo" aria-hidden="false">
    <div class="modal-dialog" style="width:100%">
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="width:90%;height:auto">
        
         <iframe id="ifrm" runat="server"  style="width:100%;"></iframe>
               
    </div>
    <div class="modal-footer" style="text-align:center" >
        <asp:Label ID="lblCaption" runat="server" Text="Website functionality/ Demo video"></asp:Label>
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>
    <%--<script language="javascript" type="text/javascript">
        $(document).ready(function () {

            $("#dialog").dialog({
                modal: true,
                autoOpen: false,
                title: "Notification Message !",
                width: 600,
                height: 400
            });

            $('#dialog').dialog('open');    // By default notification message
            

           
            $("#btnShow").click(function () {  // when click notification button
                $('#dialog').dialog('open');
            });

        });
    </script>  
        
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/blitzer/jquery-ui.css" rel="stylesheet" type="text/css" />
  --%>   
    </form>
</asp:Content>
<%--</body>
</html>
--%>