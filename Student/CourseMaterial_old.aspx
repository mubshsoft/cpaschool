<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="CourseMaterial_old.aspx.cs" Inherits="Student_CourseMaterial_old" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>

        .fade {
    opacity: 1;
    -webkit-transition: opacity 0.15s linear;
    -moz-transition: opacity 0.15s linear;
    -o-transition: opacity 0.15s linear;
    transition: opacity 0.15s linear;
}

        nav > .nav.nav-tabs{
            
  border: none;
    color:#fff;
    background:#272e38;
    border-radius:0;
    

}
nav > div a.nav-item.nav-link,
nav > div a.nav-item.nav-link.active
{
  border: none;
    padding: 18px 25px;
    color:#fff;
    background:#272e38;
    border-radius:0;

}

nav > div a.nav-item.nav-link.active:after
 {
  content: "";
  position: relative;
  bottom: -60px;
  left: -10%;
  border: 15px solid transparent;
  border-top-color: #e74c3c ;
}
.tab-content{
  background: #fdfdfd;
    line-height: 25px;
    border: 1px solid #ddd;
    border-top:5px solid #e74c3c;
    border-bottom:5px solid #e74c3c;
    padding:30px 25px;
    
}

nav > div a.nav-item.nav-link:hover,
nav > div a.nav-item.nav-link:focus
{
  border: none;
    background: #e74c3c;
    color:#fff;
    border-radius:0;
    transition:background 0.20s linear;
}

    </style>
    

  <%--  <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>--%>
<!------ Include the above in your HEAD tag ---------->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
            var statusmsg=""
                function hidestatus()
                    {
                        window.status=statusmsg
                        return true
                     }

    </script>
    <script>
       
        function ViewResourceFile(courseid, paperid, unitid, note)
        {
            
            if (note == '1') {
                $("#spnVideo").empty();
                $.ajax({
                    type: "POST",
                    url: "CourseMaterial.aspx/GetVideoPath",
                    data: "{PaperId: '" + paperid + "', UnitId: '" + unitid + "'}",
                    contentType: "application/json;charset=utf-8 ",
                    dataType: "json",
                    async: false,
                    success: function (responce) {
                        data = JSON.parse(responce.d);
                        var url =data.rows[0].FilePath;
                        
                         var vid="";
                         vid = vid + "<video width='520' height='440' controls id='IframeVideo'><source src='" + url + "' id='ifrm4addnote' type='video/mp4'></source></video>";
             
                         $("#spnVideo").append(vid);
                         var uid = unitid.toString();
                         var cid = courseid.toString();
                         $('#hdncid').val(cid);
                         $('#hdnUnitid').val(uid);
                         $('#hdnAccessMode').val("Add");
                         BindNote(cid, uid);
                         $("#ModalPopupDivPlayVideoWithAddnote").css("width", "100%");
                         $('#ModalPopupDivPlayVideoWithAddnote').modal('show');
                    },
                    error: function () {
                        alert("Error in adding record");
                    }

                });

               // var url = "../ViewDetail.aspx?paperid=" + paperid + "&unitid=" + unitid;
               // var uid = unitid.toString();
               // var cid = courseid.toString();
               // $('#hdncid').val(cid);
               // $('#hdnUnitid').val(uid);
               // $('#hdnAccessMode').val("Add");
               // BindNote(cid, uid);
               //// $('#ifrm4addnote').attr('src', url)
               // var vid="";
               // vid = vid + '<video width="320" height="240" controls id="IframeVideo"><source src=' + url + ' id="ifrm4addnote" type="video/mp4"></source></video>';
              
               // $("#spnVideo").append(vid)
               // $("#ModalPopupDivPlayVideoWithAddnote").css("width", "100%");
               // $('#ModalPopupDivPlayVideoWithAddnote').modal('show');
            }
            else
            {
                
                var url = "../ViewDetail.aspx?paperid=" + paperid + "&unitid=" + unitid;
               
                $('#ifrm').attr('src', url)
                $("#ModalPopupDivPlayVideo").css("width", "100%");
                $('#ModalPopupDivPlayVideo').modal('show');
            }
        }
        
        function ViewNote(courseid, unitid) {

            var uid = unitid.toString();
            var cid = courseid.toString();
            $('#hdnAccessMode').val("View");
            BindNote(cid, uid);
           
            //$("#ModalPopupDivnote").css("width", "500px");
            $('#ModalPopupDivnote').modal('show');
        }

        function ViewAssessmentSchapter(unitid) {

            var uid = unitid.toString();
            windows.location.href = "ViewAssessmentsChapter?id=" + uid;
        }
    </script>
   <script language="javascript" type="text/javascript">
       function openmodalPopUp(popupId) {
           
            $('#' + popupId).modal('show');

        }
    </script>
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Course Material
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Course Material</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">     

    <div style="margin-top:20px;">
    <div class="row">
        
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        
       
        <asp:DropDownList ID="dllSem" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="dllSem_SelectedIndexChanged" >
                                            </asp:DropDownList>
    
    </div></div>
      <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                       
                               
                    
                    
 <%--<div class="content-container-fluid">
              <div class="row">
                <div class="col-xs-12 ">
                  <nav>
                    <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                   
                      <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Video</a>
                      <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">PDF</a>
                      <a class="nav-item nav-link" id="nav-contact-tab" data-toggle="tab" href="#nav-contact" role="tab" aria-controls="nav-contact" aria-selected="false">PPT</a>
                      
                    </div>
                  </nav>
                  <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                    <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                     Video
                    </div>
                    <div class="tab-pane fade " id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                     PDF
                    </div>
                    <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                      PPT
                    </div>
                    
                  </div>
                
                </div>
              </div>
        </div>--%>
                    
                </div>
      </div>
       
        <div class="row">
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
               
               <div class="bs-example">
                 <div class="accordion" id="accordionExample">
                  <asp:PlaceHolder ID = "PlaceHolder1" runat="server"  />
    
       
                     </div>
    </div>

               <input type="hidden"  id="hdnAccessMode" name="hdnAccessMode" />
           </div>
       </div>                         
    </div>
    </div>
    </div>
     
    </section>
</div>
        <div class="modal fade in" id="ModalPopupDivPlayVideo" aria-hidden="false" style="align-content:flex-start;">
    <div class="modal-dialog" >
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>View</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height:auto">
        <%--<div class="scroller" data-height="900px">--%>
      <iframe id="ifrm" style="width:100%;height:900px;" ></iframe>
      
            
        <%--</div> --%>
    </div>
        <div class="modal-footer" style="text-align:center" >
        
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>

<div class="modal fade in" id="ModalPopupDivPlayVideoWithAddnote" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" >
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4><span class="align:center"> Add Note while watching video</span></h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height:auto">
        <%--<div class="scroller" data-height="900px">--%>
        <div class="container">
             
          <div class="row">
               <div class="span6">
                    <span id="spnVideo"></span>
                   <%--<iframe id="ifrm4addnote" style="width:100%" ></iframe>--%>
               </div>
              <div class="span6" >
                  
                  <div class="row">
                      <div class="span8">
                          <span id="spnNotes"></span>
                          <input type="hidden"  id="hdncid" name="hdncid" />
                          <input type="hidden"  id="hdnUnitid" name="hdnUnitid" />
        
                      </div>
                      <div class="span4">
                           <span id="spnNotesDt"></span>
                      </div>
                  </div> 
                  <div class="row">
                      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                          <div id="tbl"></div>
                      </div>
                  </div> 
                  <div class="row" >
                      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                          <input type="text" id="txtnote" name="txtnote" value="" />&nbsp;
                          <input type="button" id="addnote" name="addnote" value="Save" />
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


<div class="modal fade in" id="ModalPopupDivnote" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" >
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4><span class="align:center"> Notes</span></h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height:auto" width="100%">
        <%--<div class="scroller" data-height="900px">--%>
        <div class="container">
             
          <div class="row">
               
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  
                  <div class="row">
                      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                          <div id="tblNote"></div>
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

     <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    <script language="javascript" type="text/javascript">
    $(document).ready(function () {
       
        $("#addnote").click(function () {
         
            var Courseid = $('#hdncid').val();
            
            var UnitId = $('#hdnUnitid').val();
            var Note = $("#txtnote").val();
           
            if (Note == "") {
                alert('Enter Note');
            }
           
             $.ajax({
               type: "POST",
               url: "CourseMaterial.aspx/AddNote",
               data: "{Courseid: '" + Courseid + "', UnitId: '" + UnitId + "', Note: '" + Note + "'}",
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               success: function (data) {
                   var d = data.d;
                   BindNote(Courseid, UnitId);
                   if (d == "-1") {
                       alert("Error Inserting!");
                   }
                   
                   //else {
                   //    alert("Thank you for submitting the details.");
                   //    //$("#msg").html("Success!");
                   //    window.location.href = "default.aspx";
                   //}

               },
               failure: function (response) {
                   alert("Error");
               }
           });

           
        });
    });
    </script>

    <script type="text/javascript" language="javascript">

        function BindNote(Courseid, UnitId) {
            var retValue = {};
           
            $.ajax({
                type: "POST",
                url: "CourseMaterial.aspx/GetStudentNotes",
                data: "{Courseid: '" + Courseid + "', UnitId: '" + UnitId + "'}",
                contentType: "application/json;charset=utf-8 ",
                dataType: "json",
                async: false,
                success: OnSuccess4Notes,

                error: function () {
                    alert("Error in adding record");
                }

            });
            
        }

        function OnSuccess4Notes(response) {
          
            var xmlDoc = response.d;
            var customers = eval("(" + xmlDoc + ")");
           
            var CountRecord = customers.rows.length;
            var item="";
            Array.prototype.contains = function (obj) {
                var i = this.length;
                while (i--) {
                    if (this[i] === obj) {
                        return true;
                    }
                }
                return false;
            }

            $("#tbl").empty();
            $("#tblNote").empty();
            var arrRevised = new Array()
            var cou = 0;
            var d = "";
            var dt = "";

            var table = "<table width='80%' cellpadding='0' cellspacing='0'>";
            var tr;
            for (var i = 0; i < CountRecord; i++) {
                var customer = customers.rows[i];
                item = customer.Caption;
                d = customer.Note;
               
                if (!arrRevised.contains(customer.Caption)) {
                    
                    table = table + '<tr><td width="60%" style="padding-left:10px;padding-bottom:5px;padding-top:5px;">' + customer.Note + '</td>' + '<td width="40%" align="left" style="padding-left:20px;padding-bottom:5px;padding-top:5px;"><i class="icon-calendar"></i>&nbsp;' + customer.Caption + '</td></tr>';
                   
                   // $("#spnNotesDt").append(customer.Caption);
                   // $("#spnNotes").append("</br>" + customer.Note);
                    arrRevised[cou] = customer.Caption;
                    cou = cou + 1;
                }
                else {
                    table = table + '<tr><td width="60%" style="padding-left:10px;padding-bottom:5px;padding-top:5px;">' + customer.Note + '</td><td width="40%" style="padding-left:20px;">&nbsp;</td></tr>';

                   // $("#spnNotes").append("</br>"+d);
                }
            }
            table += "</table>";
            // alert(table);
            var hdnAccessMode = $('#hdnAccessMode').val();
            if (hdnAccessMode == "Add") {
             
                $('#tbl').append(table);
            }
            else
            {
               
                $('#tblNote').append(table);
            }


        }
        </script>

   
<%-- <script src="bootstrap/js/bootstrap.min.js"></script>--%>
</asp:Content>

