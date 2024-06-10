<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="StudentDashboard.aspx.cs" Inherits="Student_StudentDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--Start Added by wahid on 19 de 20 for calendar--%>
    <link href="../Calendar/fullcalendar.min.css" rel="stylesheet" />
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.css" rel="stylesheet" />--%>
<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.print.css" rel="stylesheet" media="print" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

   <style type="text/css">

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
       .icon-space {text-align:center; padding:1em 0;}
   </style>
<%--END Added by wahid on 19 de 20 for calendar--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
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
            <section class="col-lg-8 connectedSortable">
             
<div class="box">
              <div class="box-body">
                <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="EditStudentProfile.aspx"><img src="../images/manage_profile.png"  style="border:0px"   /></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="ChangePassword.aspx?chstudent=1"><img src="../images/change_password2.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="PostQueery.aspx?Post=1"><img src="../images/post_query.png"  style="border:0px"/></a></div>
            
            </div><!-- /.row -->
            <div class="row">&nbsp;</div>
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="StudentListCourse.aspx" id="lnkCourseMeterial" runat="server" ><img src="../images/course_material.png"  style="border:0px" /></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="../MainForumPage.aspx"><img src="../images/discussion_forum.png" style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="StudentPerformaneCourse.aspx"><img src="../images/performence_sheet.png"  style="border:0px" /></a></div>
            
            </div><!-- /.row -->
            <div class="row">&nbsp;</div>
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="FacultyList.aspx"><img src="../images/list_of_faculty.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="AssignmentSet.aspx"><img src="../images/assignment.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="ListCourseForFee.aspx"><img src="../images/pay_your_fees.png"  style="border:0px"/></a></div>
            
            </div><!-- /.row -->
            <div class="row">&nbsp;</div>
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" >
                <asp:ImageButton ID="btnExamset" runat="server" 
                    ImageUrl="../images/online_exam.png" onclick="btnExamset_Click"  /></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><img src="../images/virtual_class_room.png"  style="border:0px"/></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="SampleSet.aspx">
                                                         <img src="../images/sample_paper.png"  style="border:0px"/></a></div>
            
            </div>
            <div class="row">&nbsp;</div>
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="ApplyAnotherCourse.aspx"><img src="../Images/Register_for_another_course.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="StudentLectureListCourse.aspx"><img src="../Images/ViewLectures.png"  style="border:0px"/></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="../DetailsNewsEvents.aspx"><img src="../Images/news.png"  style="border:0px"/></a></div>
            </div>
            <div class="row">&nbsp;</div>
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><a href="../chat/Default.aspx"><img src="../Images/VideoConf.png" style="border:0px" /></a></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="btnIDCard" runat="server" Text="ID Card" OnClick="btnIDCard_Click" ImageUrl="../images/generate_id.png"  /></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" >
                
                <asp:ImageButton ID="lnkCaseStudy" runat="server" CausesValidation="false"   
                    ImageUrl="../images/case_study.png" PostBackUrl="~/Student/casestudyset.aspx" />
                
            </div>
            </div>
            <div class="row">&nbsp;</div>
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="lnkTestimonial"  ToolTip="Add You Testimonial" runat="server" ImageUrl="../images/testimonial.png" PostBackUrl="~/Student/AddUpdateTestimonial.aspx" /></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" ><asp:ImageButton ID="btnInduction" runat="server" text="Induction Program" ImageUrl="../images/induction_program.png" PostBackUrl="~/Student/InductionProgramme.aspx" /></div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 icon-space" >&nbsp;</div>
            </div>
            </div>
          </div>
          <div class="box box-info">
                <div class="box-header">
                  <i class="fa fa-area-chart"></i>
                  <h3 class="box-title">Progress Report
                  </h3>
                  <!-- tools box -->
                 <%-- <div class="pull-left box-tools">
                    <button class="btn btn-info btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                  </div--%>
                  <div class="pull-right box-tools">
                    <asp:DropDownList ID="ddlPaper" runat="server" ></asp:DropDownList>
                    
                  </div><!-- /. tools -->
                </div>
                <div class="box-body">
                 <div id="dvPie" style="display:none;">
                 <img src="../images/result_await.png" class="img-responsive" />
                 </div>
                   <div id="chartContainer" style="height: 300px; width: 100%;"></div>
                    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
                   <asp:HiddenField ID="hdnBid" runat="server" />
                </div>
               
              </div>
          
          <!-- Main row -->
         
            </section><!-- /.Left col -->
            <!-- right col (We are only adding the ID to make the widgets sortable)-->
            <section class="col-lg-4 connectedSortable">

              
              <!-- Calendar -->
              <div class="box box-success ">
                <div class="box-header">
                  <i class="fa  fa-newspaper-o"></i>
                  <h3 class="box-title">News</h3>
                  <!-- tools box -->
                  
                </div><!-- /.box-header -->
                <div class="box-body chat" id="chat-box" style="overflow: hidden; width: auto; height: 250px;">

                    <asp:Repeater ID="dlnews" runat="server">
                   <ItemTemplate>
                   <%--<div class="item">
                        <div class="row-fluid">--%>
                        <ul>
                        <li>
                            <a href="#" class="title" onclick="openModalNews(<%#Eval("NewsId")%>)">
			
			<span><%# DataBinder.Eval(Container.DataItem, "descr")%></span>
		</a><hr />
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

<div class="box box-warning ">
                <div class="box-header">
                  <i class="fa fa-calendar"></i>
                  <h3 class="box-title">Calendar</h3>
                  <!-- tools box -->
                  <div class="row">&nbsp;</div>
                  <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" Width="100%" CssClass="form-conrol" ></asp:DropDownList></div></div>
                  
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
          <div class="box" runat="server" id="demoVid">
          <div class="box-header">
                  <i class="fa fa-video-camera"></i>
                  <h3 class="box-title">Video</h3>
                  <!-- tools box -->
                  
                </div><!-- /.box-header -->
              <div class="box-body">
              <div class="row">
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: center;">
     <%--<iframe id="IframeVideo" runat="server"  width="700" height="365" frameborder="0"  allowfullscreen></iframe>--%>
     <video width="320" height="175" controls id="IframeVideo">
     <source src="<%=VideoDemo %>" type="video/mp4"></source>
     <%--<source src="../KnowledgeCenter/1Part 6  ViewData and ViewBag in mvc(720p).MP4" type="video/mp4">--%>
     </video>
         </div>
         </div>
         </div>
                
        </section><!-- /.content -->
      </div>
    
      <!-- /.content-wrapper -->

    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    <%--<script src="bootstrap/js/bootstrap.min.js"></script>--%>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>-
    <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>
      <%--<script src="bootstrap/bootstrap.min.js"></script>--%>
    <%--<script src="../js/vendor/bootstrap.min.js"></script>--%>
    
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

             BindGetCourseList();

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

<script type="text/javascript" language="javascript">
        
        function BindGetPaperList() {

            $.ajax({
                type: "POST",
                url: "StudentDashboard.aspx/GetPaperList",
                data: "{}",
                contentType: "application/json;charset=utf-8 ",
                dataType: "json",
                success: OnSuccessSalute,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }

            });

            return false;
        }

        function OnSuccessSalute(response) {
            var xmlDoc = response.d;
            var customers = eval("(" + xmlDoc + ")");

            var CountRecord = customers.rows.length;
            
            $("#<%=ddlPaper.ClientID %>").empty().append($("<option></option>").val("[-]").html("Please select"));
            for (var i = 0; i < CountRecord; i++) {
                var customer = customers.rows[i];
                //alert(customer.PaperTitle);
                $("#<%=ddlPaper.ClientID %>").append($("<option></option>").val(customer.paperId).html(customer.PaperTitle));
            }
        }
    </script>
<script type="text/javascript">
    var data = [];
    var pdata = []
    var PaperID = 0;
       
        $(document).ready(function () {
            BindGetPaperList();
            $("#<%=ddlPaper.ClientID %>").change(function () {
                //alert($('option:selected', this).val());
                PaperID = $('option:selected', this).val();
                //alert(PaperID);
                $.ajax({
                    type: "POST",
                    url: "StudentDashboard.aspx/GetStudentProgressPie",
                    data: "{PaperID:'" + PaperID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessPie,
                    failure: function (response) {
                        alert("Error");
                    }
                });
            });

            $.ajax({
                type: "POST",
                url: "StudentDashboard.aspx/GetStudentProgressPie",
                //data: '{}',
                data: "{PaperID:'" + PaperID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessPie,
                failure: function (response) {
                    alert("Error");
                }
            });
        });
        var res = "";
        function OnSuccessPie(response) {
            //res = response;
            var donutData = JSON.parse(response.d);
            
            res = donutData;
            pdata = donutData;
          
            var chart = new CanvasJS.Chart("chartContainer", {
                exportEnabled: true,
                animationEnabled: true,
                title:{
                    text: "Paper Marks"
                },
                legend:{
                    cursor: "pointer",
                    itemclick: explodePie
                },
                data: [{
                    type: "pie",
                    showInLegend: true,
                    toolTipContent: "{name}: <strong>{y}</strong>",
                    indexLabel: "{name} - {y}",
                    dataPoints:pdata[0]
                }]
            });
            chart.render();
            var ln = pdata.length;

            if (ln == 0) {

                $("#dvPie").show();
               $("#chartContainer").hide();
            }
        }

        function explodePie (e) {
            if(typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
                e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
            } else {
                e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
            }
            e.chart.render();

        }
   
</script>
<script >  
      //$(document).ready(function () {                 
      //    $.ajax({  
      //        type: "POST",  
      //        contentType: "/json; charset=utf-8",  
      //        url: "StudentDashboard.aspx/LoadPaper",
      //        data: "{}",  
      //        dataType: "json",  
      //        success: function (Result) {  
      //            $.each(Result.d, function (key, value) {  
      //                $("#ddlPaper").append($("<option></option>").val(value.PaperId).html(value.papertitle));
      //            });  
      //        },  
      //        error: function (Result) {  
      //            alert("Error");  
      //        }  
      //    });  
      //});
    </script>
<script type="text/javascript">
     function openModalNews(id)
    {    
         $("#myModalNews"+id).modal();
    
    }
    
   </script>

    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>

