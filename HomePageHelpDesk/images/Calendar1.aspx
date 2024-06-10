<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar1.aspx.cs" Inherits="Calendar1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../stmenu.js"></script>
    <link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.css" rel="stylesheet" />
<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.print.css" rel="stylesheet" media="print" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

   <style type="text/css">

        .fc-content{
            text-align: center;
            color: wheat;
            font-weight: bold;
        }

        #calendar {
            width: 200px;
            max-width: 300px;
            margin: 40px auto;
            
         }
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="calender"></div>
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
       <div id="myModalSave" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Save Event</h4>
            </div>
            <div class="modal-body">
                <form class="col-md-12 form-horizontal">
                    <input type="hidden" id="hdEventID" value="0" />
                    <div class="form-group">
                        <label>Subject</label>
                        <input type="text" id="txtSubject" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label>Start</label>
                        <div class="input-group date" id="dtp1">
                            <input type="text" id="txtStart" class="form-control" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="checkbox">
                            <label><input type="checkbox" id="chkIsFullDay" checked="checked" />  Is Full Day event</label>
                        </div>
                    </div>
                    <div class="form-group" id="divEndDate" style="display:none">
                        <label>End</label>
                        <div class="input-group date" id="dtp2">
                            <input type="text" id="txtEnd" class="form-control" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <textarea id="txtDescription" rows="3" class="form-control"></textarea>
                    </div>
                    <div class="form-group">
                        <label>Theme Color</label>
                        <select id="ddThemeColor" class="form-control">
                            <option value="">Default</option>
                            <option value="red">Red</option>
                            <option value="blue">Blue</option>
                            <option value="black">Black</option>
                            <option value="green">Green</option>
                        </select>
                    </div>
                    <button type="button" id="btnSave" class="btn btn-success">Save</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </form>
            </div>
        </div>
    </div>
</div>
    </div>
    </form>

     <script src="Calendar/jquery-1.10.2.min.js"  ></script>
       <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>
      <%--<script src="bootstrap/bootstrap.min.js"></script>--%>
    <script src="js/vendor/bootstrap.min.js"></script>
    <script type="text/javascript">
        var gbldata = '';
        $(document).ready(function () {
           // $('.spinner-wrapper').hide();
            var events = [];
            var selectedEvent = null;
            FetchEventAndRenderCalendar();
            function FetchEventAndRenderCalendar() {
                events = [];
                $.ajax({
                    type: "POST",
                    url: "Calendar1.aspx/GetAutherbyID_j",
                    data: '{}',
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
               
                
                $('#calender').fullCalendar('destroy');
                $('#calender').fullCalendar({
                    contentHeight: 400,
                    defaultDate: new Date(),
                    timeFormat: 'h(:mm)a',
                    header: {
                        left: 'prev,next today',
                        center: 'title'
                        //right: 'month,basicWeek,basicDay'
                    },
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
</body>
</html>
