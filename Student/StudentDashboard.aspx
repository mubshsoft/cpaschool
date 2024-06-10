<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="StudentDashboard.aspx.cs" Inherits="Student_StudentDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--Start Added by wahid on 19 de 20 for calendar--%>
    <link href="../Calendar/fullcalendar.min.css" rel="stylesheet" />
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.css" rel="stylesheet" />--%>
<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.print.css" rel="stylesheet" media="print" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

   <style type="text/css">
   .box {border-top:0}
   .fc .fc-toolbar>*>:first-child {font-size:15px;font-weight: bold;}
        .fc-content{
            text-align: center;
            color: wheat;
            font-weight: bold;
        }

        #calendarNew {
            width: 150px;
            max-width: 200px;
            margin: 20px auto;
            
         }
       .fc td, .fc th {
           border-width:0;
       }
       .fc-toolbar {padding: 0 10px;}
    .fc-toolbar.fc-header-toolbar {margin:0;}
    .fc-day-number {font-size: 16px;}
    .fc-basic-view .fc-body .fc-row {height: 45px!important; min-height:2em!important;}
       .icon-space {text-align:center; padding:1.5em 0;}
       .fc-ltr .fc-basic-view .fc-day-top .fc-day-number {
    float: right;
    margin-right: 10px;
}
.box-border {border: solid 1px #e2e2e2;border-radius: 5px;}
.box-header1 {
    font-weight: 600;
    font-size: 14px;
    text-align: center;
    background: #0e245d;
    color: #fff;
    border-top-left-radius: 5px;
    border-top-right-radius: 5px;
}

   </style>
<%--END Added by wahid on 19 de 20 for calendar--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1 style="visibility:hidden">
            Dashboard
            <small>Student panel</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Dashboard</li>
          </ol>
        </section>

        <!-- Main content -->
        <section class="content">
          <!-- Small boxes (Stat box) -->
          <%--<div class="row">
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3>50</h3>
                  <p>Number of Courses</p>
                </div>
                <div class="icon">
                  <i class="ion ion-ios-bookmarks"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3>12</h3>
                  <p>Number of Faculties</p>
                </div>
                <div class="icon">
                  <i class="ion ion-android-people"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3>760</h3>
                  <p>Total Marks</p>
                </div>
                <div class="icon">
                  <i class="ion ion-android-clipboard"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>20</h3>
                  <p>Number of Post</p>
                </div>
                <div class="icon">
                  <i class="ion ion-android-chat"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->--%>
          <!-- Main row -->
          <div class="row">
            <!-- Left col -->
            <section class="col-lg-9 col-md-9 col-sm-12 col-xs-12 connectedSortable">
            <div class="row">
             <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Course Induction</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="btnInduction" runat="server" text="Induction Program" ImageUrl="../images/induction_program.png" PostBackUrl="~/Student/InductionProgramme.aspx" /></div>
            </div>
              </div>
              </div>
              </div>
              <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Course Curriculum</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="StudentListCourse.aspx" id="lnkCourseMeterial" runat="server" ><img src="../images/course_material.png"  style="border:0px" /></a></div>
            <div class="col-lg-3 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="../MainForumPage.aspx"><img src="../images/discussion_forum.png" style="border:0px"/></a></div>
            <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="StudentLectureListCourse.aspx"><img src="../Images/ViewLectures.png"  style="border:0px"/></a></div>
            <div class="col-lg-3 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="ListvideoConfrence.aspx"><img src="../Images/VideoConf.png" style="border:0px" /></a></div>
            <div class="col-lg-2 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="PostQueery.aspx?Post=1"><img src="../images/post_query.png"  style="border:0px"/></a></div>
            </div>
              </div>
              </div>
              </div>
             </div>

             <div class="row">
              <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Assignments and Case Studies</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" ImageUrl="../images/case_study.png" PostBackUrl="~/Student/casestudyset.aspx" /></div>
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="AssignmentSet.aspx"><img src="../images/assignment.png"  style="border:0px"/></a></div>
            </div>
              </div>
              </div>
              </div>
              
              <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Examination</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="SampleSet.aspx"><img src="../images/sample_paper.png"  style="border:0px"/></a></div>
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/online_exam.png" onclick="btnExamset_Click"  /></div>
            </div>
              </div>
              </div>
              </div>
              <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Progress and Performance</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 icon-space" ><a href="StudentPerformaneCourse.aspx"><img src="../images/performence_sheet.png"  style="border:0px" /></a></div>
           <%-- <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="StudentProgressCourse.aspx"><img src="../images/progress_report.png"  style="border:0px" /></a></div>--%>
            </div>
              </div>
              </div>
              </div>
              
              </div>

              <div class="row">
              
              <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Manage Profile</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="EditStudentProfile.aspx"><img src="../images/manage_profile.png"  style="border:0px"   /></a></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="ChangePassword.aspx?chstudent=1"><img src="../images/change_password2.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="btnIDCard" runat="server" Text="ID Card" OnClick="btnIDCard_Click" ImageUrl="../images/generate_id.png"  /></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="ListCourseForFee.aspx"><img src="../images/pay_your_fees.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="ApplyAnotherCourse.aspx"><img src="../Images/Register_for_another_course.png"  style="border:0px"/></a></div>
            </div>
              </div>
              </div>
              </div>
              <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12" >
              <div class="box box-border">
              <div class="box-header box-header1">Resources</div>
              <div class="box-body">
              <div class="row">
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="../DetailsNewsEvents.aspx"><img src="../Images/news.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="KnowledgeCenterDetails.aspx"><img src="../Images/knowledgecenter.png" style="border:0px" /></a></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="lnkTestimonial"  ToolTip="Add You Testimonial" runat="server" ImageUrl="../images/testimonial.png" PostBackUrl="~/Student/AddUpdateTestimonial.aspx" /></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" ><a href="FacultyList.aspx"><img src="../images/list_of_faculty.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-6 col-sm-12 col-xs-12 icon-space" style="display:none" ><a href="#" id="lnkNoticeBoard" class="Click here today see notice board" onclick="NoticeBoard()"> <img src="../Images/notice_board.png" style="border:0px" /></a>
                <div class="modal fade in" id="ModalPopupNotice" >
    <div class="modal-dialog" >
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">×</span></button>
        <h4><span class="align:center"> Notice Board</span></h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height:auto" width="100%">
        
        <div>
             
          <div class="row">
               
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  
                  <div class="row" style="height: 305px; overflow: auto;">
                      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                         <asp:Repeater ID="rptNotification" runat="server" >
                   <ItemTemplate>
                   <div class="item">
                        <div class="row-fluid">
                        <ul style="margin-left:0">
                        <li>
                            
                            <div class="media-body" style="padding-left: 10px; text-align: justify; font-size:14px;">
                                <span style="font-family: sans-serif;color: #3498db;" ><%#DataBinder.Eval(Container.DataItem, "mailtype")%> </span>
                               
                                <p style="border-top: solid 1px #cecdcd;padding-top: 6px;"><%#DataBinder.Eval(Container.DataItem, "descr")%></p>
                            
                            </div>
                         </li>
                        </ul>
                        </div>
                    </div>
                        </ItemTemplate>
                        </asp:Repeater>
                      </div>
                  </div> 
                 
               </div>
          </div>
         </div> 
            
        <%--</div> --%>
    </div>
        <div class="modal-footer" style="text-align:center" >
        
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>

                
            </div>
            
            </div>
              </div>
              </div>
              </div>
              </div>
            
          <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="box" runat="server" id="demoVid">
          <div class="box-header">
                  <i class="fa fa-video-camera"></i>
                  <h3 class="box-title">Video</h3>
                  <!-- tools box -->
                  
                </div><!-- /.box-header -->
              <div class="box-body" style="padding-bottom: 50px;">
              <div class="row">
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: center;">
     <%--<iframe id="IframeVideo" runat="server"  width="700" height="365" frameborder="0"  allowfullscreen></iframe>--%>
     <video width="450" height="250" controls id="IframeVideo">
     <source src="<%=VideoDemo %>" type="video/mp4"></source>
     <%--<source src="../KnowledgeCenter/1Part 6  ViewData and ViewBag in mvc(720p).MP4" type="video/mp4">--%>
     </video>
         </div>
         </div>
         </div>
          </div> 
          </div>
    </div>
          
          
          <!-- Main row -->
         
            </section><!-- /.Left col -->
            <!-- right col (We are only adding the ID to make the widgets sortable)-->
            <section class="col-lg-3 col-md-3 col-sm-12 col-xs-12 connectedSortable">

              <div class="box box-info" style="height: 370px; ">
                <div class="box-header">
                  <i class="fa fa-area-chart"></i>
                  <h3 class="box-title">Course Material Progress Report
                  </h3>
                  <!-- tools box -->
                 <%-- <div class="pull-left box-tools">
                    <button class="btn btn-info btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                  </div--%>
                  <!-- /. tools -->
                </div>
                <div class="box-body">
              <div class="box-title">   <asp:DropDownList ID="ddlPaper" runat="server"  CssClass="form-control" onchange=" bindpregres_change();"></asp:DropDownList></div>

               
                   <div id="chart" ></div>
                   <asp:HiddenField ID="hdnBid" runat="server" />
                </div>
               
              </div>
              <!-- Calendar -->
              <div class="box box-success " style="height: 260px;">
                <div class="box-header">
                  <i class="fa  fa-newspaper-o"></i>
                  <h3 class="box-title">News</h3>
                  <!-- tools box -->
                  
                </div><!-- /.box-header -->
                <div class="box-body chat" id="chat-box" style="overflow: auto; height: 200px;">

                    <asp:Repeater ID="dlnews" runat="server">
                   <ItemTemplate>
                   <%--<div class="item">
                        <div class="row-fluid">--%>
                        <ul>
                        <li>
                            <a href="#" class="title" onclick="openModalNews(<%#Eval("NewsId")%>)">
			
			<span><%# DataBinder.Eval(Container.DataItem, "descr")%></span>
		</a>
                           <%-- <div class="media-body" style="padding-left: 10px; text-align: justify; font-size:14px;">
                                <span style="font-family: sans-serif;color: #3498db;"><strong><i class="date"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%> </strong></span>
                                <p style="border-top: solid 1px #cecdcd;padding-top: 6px;"><%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%></p>
                            
                            </div>--%>
                            <div id="myModalNews<%#Eval("NewsId")%>" class="modal fade" aria-hidden="false" role="dialog" >
                                <div class="modal-dialog" >
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title"><small class="date"><i class="calenders"></i> <%#DataBinder.Eval(Container.DataItem, "ndate")%></small></h4>
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        </div>
                                        <div class="modal-body">
                                             <%# DataBinder.Eval(Container.DataItem, "descr")%><br /><br /><br /><br />
                                        <div class="row">

                                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right">
                                             <%--<a class="btn btn-primary" href="https://www.facebook.com/sharer/sharer.php?app_id=3548822928518556&sdk=joey&u=http://cleverjournal.net/Editorial.aspx&display=popup&ref=plugin&src=share_button" onclick="return !window.open(this.href, 'Facebook', 'width=640,height=580')">Facebook share</a>&nbsp;--%>
                                             Share: <a class="btn btn-facebook" href="http://www.facebook.com/share.php?u=<url>" onclick="return fbs_click()" target="_blank" title="Facebook Share"><i class="fa fa-facebook"></i></a> 
                                             <a class="btn btn-twitter" href="https://twitter.com/intent/tweet?text=<%# DataBinder.Eval(Container.DataItem, "descr")%>" data-size="large" title="Twitter Share"><i class="fa fa-twitter"></i></a>
                                             <a class="btn btn-instagram" href="https://www.instagram.com/?url=https://www.drdrop.co/" target="_blank" title="Instagram Share" ><i class="fa fa-instagram"></i></a> 
                                             <a class="btn btn-linkedin" onclick="return Linkedins_click()" title="Linkedin Share"><i class="fa fa-linkedin"></i></a>
                                             <a class="btn btn-google" href="https://google.com/share?url=http://http://fmsflearningsystems.org/" title="Google Plus Share"><i class="fa fa-google-plus"></i></a>
                                         </div>
                                         
                                        </div>
                                        
                                         </div>
                                            
                                            
                                        <div class="modal-footer" >
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </li>
                        </ul>
                       <%-- </div>
                    </div>--%>
                        </ItemTemplate>
                        </asp:Repeater>
              <!-- chat item -->
              <%--<div class="item">
                <img src="dist/img/user4-128x128.jpg" alt="user image" class="online">

                <p class="message">
                  <a href="#" class="name">
                    <small class="text-muted pull-right"><i class="fa fa-clock-o"></i> 2:15</small>
                    News
                  </a>
                  I would like to meet you to discuss the latest news about
                  the arrival of the new theme. They say it is going to be one the
                  best themes on the market
                </p>
                
                <!-- /.attachment -->
              </div>--%>
              <!-- /.item -->
              <!-- chat item -->
              <%--<div class="item">
                <img src="dist/img/user3-128x128.jpg" alt="user image" class="offline">

                <p class="message">
                  <a href="#" class="name">
                    <small class="text-muted pull-right"><i class="fa fa-clock-o"></i> 5:15</small>
                    News
                  </a>
                  I would like to meet you to discuss the latest news about
                  the arrival of the new theme. They say it is going to be one the
                  best themes on the market
                </p>
              </div>--%>
              <!-- /.item -->
              <!-- chat item -->
              <%--<div class="item">
                <img src="dist/img/user2-160x160.jpg" alt="user image" class="offline">

                <p class="message">
                  <a href="#" class="name">
                    <small class="text-muted pull-right"><i class="fa fa-clock-o"></i> 5:30</small>
                    News
                  </a>
                  I would like to meet you to discuss the latest news about
                  the arrival of the new theme. They say it is going to be one the
                  best themes on the market
                </p>
              </div>--%>
              <!-- /.item -->
            </div><!-- /.box-body -->
                
              </div><!-- /.box -->

<div class="box box-warning " style="height: 25em;">
                <div class="box-header">
                  <i class="fa fa-calendar"></i>
                  <h3 class="box-title">Calendar</h3>
                  <!-- tools box -->
                  
                  <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin-top:5px"><asp:DropDownList ID="ddlCourse" runat="server" Width="100%" CssClass="form-conrol" ></asp:DropDownList></div></div>
                  
                </div><!-- /.box-header -->
                
                 <div id="calenderNew"></div>
    <div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog" >
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title"><span id="eventTitle"></span></h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
              
                <p id="pDetails"></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
               <!-- /.box-body- ->
                
              </div>
            </section><!-- right col -->
            
          </div><!-- /.row (main row) -->
               
        </section><!-- /.content -->
      </div>
    
      <!-- /.content-wrapper -->

    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
      <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
    <%--<script src="bootstrap/js/bootstrap.min.js"></script>--%>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>-
    <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>
      <%--<script src="bootstrap/bootstrap.min.js"></script>--%>
    <%--<script src="../js/vendor/bootstrap.min.js"></script>--%>
    
    
    <script language="javascript" type="text/javascript">

        function openPopup(strOpen) {
            open(strOpen, "Info", "status=1, width=700, height=430,resizable=yes,scrollbars=yes, top=200, left=200");
        }
     
</script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $("#btnShow").click(function () {  // Show notification on button click
                $('#ModalPopupDiv').modal('show');
            });

            $("#lnkDemoVideo").click(function () {  // Show notification on button click
                alert("hi");
                $('#' + popupId).modal('show');
            });
        });
        function openmodalPopUp(popupId) {
            // alert(popupId + " hi wahid");
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

    <script language="javascript" type="text/javascript">
        //function myShareLink()
        //{
        //    var x = document.URL;
        //    //document.getElementById("sharelnk").src = 'https://www.facebook.com/plugins/share_button.php?href=' + x + '&layout=button&size=small&mobile_iframe=true&width=60&height=3548822928518556';
        //alert(x);
        //}

        function fbs_click() {
            u = document.URL;
            //location.href;
            t = document.title;

            window.open('https://www.facebook.com/sharer/sharer.php?app_id=3548822928518556&sdk=joey&?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t) + '&display=popup&ref=plugin&src=share_button', 'facebook', 'width=640,height=580');
            return false;
        }

        function Linkedins_click() {
            u = document.URL;
            //location.href;
            t = document.title;

            window.open('https://www.linkedin.com/shareArticle?mini=true&url=' + u + '&title=FMSF - News&source=MyTestLink', 'mywin', 'left=20,top=20,width=500,height=500,toolbar=1,resizable=0');
            return false;
        }
    </script>
     <script type="text/javascript">
         var gbldata = '';
         var coursees = [];
         $(document).ready(function () {
             var Courseid = "";

             //             BindGetCourseList();

             var events = [];
             var selectedEvent = null;
             FetchEventAndRenderCalendar();

             $("#<%=ddlCourse.ClientID %>").change(function () {
                 //alert($('option:selected', this).val());
                 Courseid = $('option:selected', this).val();

                 events = [];
                 $.ajax({
                     type: "POST",
                     url: "../Calendar.aspx/GetAutherbyID_j",
                     data: "{Courseid:'" + Courseid + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (data) {
                         data = JSON.parse(data.d);
                         $.each(data, function (i, v) {

                             events.push({
                                 eventID: v.ID,
                                 title: v.title,
                                 description: v.ParticipantsComposition,
                                 start: moment(v.start_date),
                                 end: v.end_date != null ? moment(v.end_date) : null,
                                 color: v.ThemeColor,
                                 allDay: v.IsFullDay

                             });
                         })
                         gbldata = events;

                         GenerateCalender(gbldata);
                     },
                     failure: function (response) {
                         alert("Error");
                     }
                 });
             });
             function FetchEventAndRenderCalendar() {
                 var Courseid = coursees;
                 events = [];
                 $.ajax({
                     type: "POST",
                     url: "../Calendar.aspx/GetAutherbyID_j",
                     data: "{Courseid:'" + Courseid + "'}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (data) {
                         data = JSON.parse(data.d);
                         $.each(data, function (i, v) {

                             events.push({
                                 eventID: v.ID,
                                 title: v.title,
                                 description: v.ParticipantsComposition,
                                 start: moment(v.start_date),
                                 end: v.end_date != null ? moment(v.end_date) : null,
                                 color: v.ThemeColor,
                                 allDay: v.IsFullDay

                             });
                         })
                         gbldata = events;

                         GenerateCalender(gbldata);
                     },
                     failure: function (response) {
                         alert("Error");
                     }
                 });
             }

             function GenerateCalender(gbldata) {


                 $('#calenderNew').fullCalendar('destroy');
                 $('#calenderNew').fullCalendar({
                     contentHeight: 350,
                     defaultDate: new Date(),
                     timeFormat: 'h(:mm)a',
                     //header: {
                     //    left: 'prev,next today',
                     //    center: 'title',
                     //    right: 'month,basicWeek,basicDay'
                     //},
                     eventLimit: true,
                     eventColor: '#378006',
                     events: gbldata,
                     eventClick: function (calEvent, jsEvent, view) {
                         selectedEvent = calEvent;
                         $('#myModal #eventTitle').text(calEvent.title);
                         var $description = $('<div/>');
                         $description.append($('<p/>').html('<b>Start: </b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
                         if (calEvent.end != null) {
                             $description.append($('<p/>').html('<b>End: </b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
                         }
                         $description.append($('<p/>').html('<b>Description: </b>' + calEvent.description));
                         $('#myModal #pDetails').empty().html($description);

                         //$('#myModal').css({
                         //    'position': 'absolute',
                         //    'width': '500px',
                         //    'heigth' : '400px',
                         //    'left': '10%',
                         //    'top':'30%',
                         //    'transform': 'translate(-30%, -30%)'
                         //})

                         $('#myModal').modal();
                     },
                     selectable: true,
                     select: function (start, end) {
                         selectedEvent = {
                             eventID: 0,
                             title: '',
                             description: '',
                             start: start,
                             end: end,
                             allDay: false,
                             color: ''

                         };
                         //openAddEditForm();
                         $('#calendar').fullCalendar('unselect');
                     },
                     editable: true,
                     eventDrop: function (event) {
                         var data = {
                             EventID: event.ID,
                             Subject: event.title,
                             Start: event.start.format('DD/MM/YYYY HH:mm A'),
                             End: event.end != null ? event.end.format('DD/MM/YYYY HH:mm A') : null,
                             Description: event.description,
                             ThemeColor: event.color,
                             IsFullDay: event.allDay

                         };

                     }
                 })

                 //alert("hi");
             }

             $('#btnEdit').click(function () {
                 //Open modal dialog for edit event
                 openAddEditForm();
             })
             $('#btnDelete').click(function () {
                 if (selectedEvent != null && confirm('Are you sure?')) {
                     $.ajax({
                         type: "POST",
                         url: '/home/DeleteEvent',
                         data: { 'eventID': selectedEvent.eventID },
                         success: function (data) {
                             if (data.status) {
                                 //Refresh the calender
                                 FetchEventAndRenderCalendar();
                                 $('#myModal').modal('hide');
                             }
                         },
                         error: function () {
                             alert('Failed');
                         }
                     })
                 }
             })

             $('#dtp1,#dtp2').datetimepicker({
                 format: 'DD/MM/YYYY HH:mm A'
             });

             $('#chkIsFullDay').change(function () {
                 if ($(this).is(':checked')) {
                     $('#divEndDate').hide();
                 }
                 else {
                     $('#divEndDate').show();
                 }
             });

             function openAddEditForm() {
                 if (selectedEvent != null) {
                     $('#hdEventID').val(selectedEvent.eventID);
                     $('#txtSubject').val(selectedEvent.title);
                     $('#txtStart').val(selectedEvent.start.format('DD/MM/YYYY HH:mm A'));
                     $('#chkIsFullDay').prop("checked", selectedEvent.allDay || false);
                     $('#chkIsFullDay').change();
                     $('#txtEnd').val(selectedEvent.end != null ? selectedEvent.end.format('DD/MM/YYYY HH:mm A') : '');
                     $('#txtDescription').val(selectedEvent.description);
                     $('#ddThemeColor').val(selectedEvent.color);
                 }
                 $('#myModal').modal('hide');
                 $('#myModalSave').modal();
             }

             $('#btnSave').click(function () {
                 //Validation/
                 if ($('#txtSubject').val().trim() == "") {
                     alert('Subject required');
                     return;
                 }
                 if ($('#txtStart').val().trim() == "") {
                     alert('Start date required');
                     return;
                 }
                 if ($('#chkIsFullDay').is(':checked') == false && $('#txtEnd').val().trim() == "") {
                     alert('End date required');
                     return;
                 }
                 else {
                     var startDate = moment($('#txtStart').val(), "DD/MM/YYYY HH:mm A").toDate();
                     var endDate = moment($('#txtEnd').val(), "DD/MM/YYYY HH:mm A").toDate();
                     if (startDate > endDate) {
                         alert('Invalid end date');
                         return;
                     }
                 }

                 var data = {
                     EventID: $('#hdEventID').val(),
                     Subject: $('#txtSubject').val().trim(),
                     Start: $('#txtStart').val().trim(),
                     End: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val().trim(),
                     Description: $('#txtDescription').val(),
                     ThemeColor: $('#ddThemeColor').val(),
                     IsFullDay: $('#chkIsFullDay').is(':checked')
                 }
                 SaveEvent(data);
                 // call function for submit data to the server
             })

             function SaveEvent(data) {
                 $.ajax({
                     type: "POST",
                     url: '/Calendar/SaveEvent',
                     data: data,
                     success: function (data) {
                         if (data.status) {
                             //Refresh the calender
                             FetchEventAndRenderCalendar();
                             $('#myModalSave').modal('hide');
                         }
                     },
                     error: function () {
                         alert('Failed');
                     }
                 })
             }
         });
   
</script>
<script type="text/javascript" language="javascript">

    function BindGetCourseList() {

        $.ajax({
            async: false,
            type: "POST",
            url: "StudentDashboard.aspx/GetCourse",
            data: "{}",
            contentType: "application/json;charset=utf-8 ",
            dataType: "json",
            success: OnSuccessCourse,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }

        });

        return false;
    }
  
    function OnSuccessCourse(response) {
        var xmlDoc = response.d;
           var customers = eval("(" + xmlDoc + ")");

        var CountRecord = customers.rows.length;

        $("#<%=ddlCourse.ClientID %>").empty().append($("<option></option>").val("[-]").html("Please Select Course"));
        for (var i = 0; i < CountRecord; i++) {
            var customer = customers.rows[i];

            $("#<%=ddlCourse.ClientID %>").append($("<option></option>").val(customer.CourseId).html(customer.CourseTitle));
        }

        $("#<%=ddlCourse.ClientID %> option:eq(1)").attr("selected", "selected");

        $("#<%=ddlCourse.ClientID %> option:eq(1)").attr("selected", "selected").val();
        var co = $("#<%=ddlCourse.ClientID %> option:eq(1)").attr("selected", "selected").val();
        //alert('bind course');
        coursees.push(co);

    }
    </script>

<!---- New code -->
<script type="text/javascript">
    function bindpregres() {
        
        var PaperID = $("#<%=ddlPaper.ClientID %>").val();
        $.ajax({
            type: "POST",
            url: "StudentDashboard.aspx/GetStudentCourseProgressPie",
            data: JSON.stringify({ PaperID: PaperID }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessPie,
            failure: function (response) {
                alert("Error");
            }
        });
    }

    $(document).ready(function () {
        
        bindpregres();
    });

    function bindpregres_change() {
       
        document.getElementById("chart").innerHTML = "";
        bindpregres();
    }

    function OnSuccessPie(response) {
        var donutData = JSON.parse(response.d);

        var data = donutData[0].data;
        var labels = donutData[1].label;

        var options = {
            series: data,
            chart: {
                width: 330,
                type: 'pie',
                events: {
                    dataPointSelection: function(event, chartContext, config) {
                        markReportAsRead();
                    }
                }
            },
            labels: labels,
            legend: {
                show: true,
                position: 'bottom',
                horizontalAlign: 'left',
                fontSize: '10px'
            },
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        show: false,
                        position: 'top',
                        horizontalAlign: 'right'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();
        markReportAsRead(); // Mark the report as read when chart is rendered
    }

    function markReportAsRead() {
        
        var PaperID = $("#<%=ddlPaper.ClientID %>").val();
        $.ajax({
            type: "POST",
            url: "StudentDashboard.aspx/MarkReportAsRead",
            data: JSON.stringify({ PaperID: PaperID }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
               
                console.log("Report marked as read");
            },
            failure: function (response) {
                console.log("Failed to mark report as read");
            }
        });
    }
</script>

<!---- New code end -->
<script type="text/javascript">
    function openModalNews(id) {
        $("#myModalNews" + id).modal();
        
    }
    
   </script>


    </div>
   
</asp:Content>

