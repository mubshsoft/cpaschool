<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VC.aspx.cs" Inherits="VC" %>
<html>
<head><title></title>
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/getMediaElement.css">
    <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    
    
    <link href="css/font-awesome.min.css" rel="Stylesheet" type="text/css" />
    <script src="js/jquery-2.1.4.min.js"></script>
</head>
<body>
<div class="wrapper">
    <form id="form1" runat="server">
    <input type="text" runat="server" id="txtRoomId" style="display:none" />
    <input type="text" runat="server" id="txtUserEmail" style="display:none" />
   <section class="container-fluid">
       <div class="row">
                <div class="col-md-9">
                    <div id="videos-container" style="width:100%"></div>
                </div>
                <div class="col-md-3" id="chat-container">
                 <div class="panel-primary">
                    <div class="panel-heading" style="text-align:left">
                        
                        <ul class="nav nav-tabs">
                        <li class="active"><a href="#Chat" data-toggle="tab" style="color:#ffffff"><i class="fa fa-comments"></i> </a></li>
                        <li><a href="#Members" data-toggle="tab"  style="color:#ffffff"><i class="fa fa-users"></i> </a></li>
                        <li class="pull-right"><a id="demoSwal" href="javascript:void(0)" data-toggle="tab"  style="color:red"><i class="fa fa-power-off"></i> </a></li>
                      </ul>
                    </div>
                    <div class="panel-body" style="padding:0px;">      
                      <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade active in" id="Chat">
                          <div id="chatbox" class="messanger" style="background:#ffffff; height:392px">
                    <div id="ChatText" class="messages" style="height: 360px; padding:4px 6px; margin:0px; overflow:auto;background:#a9a9a9">
                    </div>
                    <div class="sender" style="background: #a9a9a9;padding-top: 10px;">
                      <input type="text" id="input-text-chat" onkeypress="blockEnter()" placeholder="Send Message" style="border:1px solid #f1f1f1;"/>
                      <%--<button class="btn btn-primary" type="button"><i class="fa fa-lg fa-fw fa-paper-plane"></i></button>--%>
                    </div>
                  </div>
                        </div>
                        <div class="tab-pane fade" id="Members">
                          <div style="max-height: 360px; padding:4px 6px; margin:0px">
                            <ul class="list-group" id="RoomMembers">
                             <asp:Repeater ID="rptrVCMembers" runat="server">
                                <ItemTemplate>
                                    <li class='list-group-item'><%# Container.DataItem %><span class='badge' style='background:red' id='<%# Container.DataItem.ToString().Trim() %>'><i class='fa fa-user'></i></span></li>
                                </ItemTemplate>
                             </asp:Repeater>

                            </ul>
                          </div>
                        </div>
                       
                       
                      </div>
                    </div>
                </div>

                <br />
                <div class="panel-primary">
                    <div class="panel-heading" style="text-align:left">
                        File Sharing
                        <span class="pull-right"><a href="javascript:void()" class="btn btn-primary" id="sharefile" type="file" title="Share File"><i class="fa fa-lg fa-fw fa-paper-plane"></i></a></span>
                    </div>
                    <div class="panel-body" style="padding:0px;">
                      <div id="file-container"></div>
                    </div>
                </div>
               
                </div> 
            </div>
    </section>
    <input type="hidden" id="userEmail" runat="server" />
    <input type="hidden" id="roomid" runat="server"/>
    <input type="hidden" id="userType" runat="server"/>
    <input type="hidden" id="roomUsers" runat="server"/>
    <input type="hidden" id="roomOrganiser" runat="server"/>
    <input type="hidden" id="roomTopic" runat="server"/>
    </form>
</div>
         
    <%--<script src="dist/RTCMultiConnection.min.js"></script>--%>
    <script src="js/RTCMultiConnection.js"></script>
        <script src="socket/socket.js"></script>
        <!-- custom layout for HTML5 audio/video elements -->
        <script src="js/getMediaElement.js"></script>
        <script src="https://cdn.webrtc-experiment.com:443/FileBufferReader.js"></script>
        <script src="js/webrtc.js"></script>
        <script src="js/commits.js" async></script>
        <script type="text/javascript" src="js/plugins/bootstrap-notify.min.js"></script>
        <script type="text/javascript" src="js/plugins/sweetalert.min.js"></script>
        <script type="text/javascript">
            
            var roomid = document.getElementById('<%=txtRoomId.ClientID %>').value;
            document.getElementById('userEmail').value = document.getElementById('<%=txtUserEmail.ClientID %>').value;
            document.getElementById('roomid').value = roomid;
            var roomdetaildata = "";
                    
            connection.extra = { userEmail: document.getElementById('userEmail').value };
            if (document.getElementById('userEmail').value == document.getElementById('roomOrganiser').value) {
                document.getElementById("userType").value = "Organiser";
                connection.open(roomid, function () {
                    });
            }
            else {
                connection.join(roomid);
                document.getElementById("userType").value = "Members";
            }
                

            $('#demoSwal').click(function () {
                swal({
                    title: "Are you want to disconnect?",
                    text: "You will no longer able to see others!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonText: "Yes, disconnect!",
                    cancelButtonText: "No, cancel plx!",
                    closeOnConfirm: false,
                    closeOnCancel: false
                }, function (isConfirm) {
                    if (isConfirm) {
                        leave();
                        swal("Disconnected!", "You are now disconnected.", "error");
                        setTimeout("location.href='../logout.aspx'", 1000);
                    } else {
                        swal("Cancelled", "Yet Connected :)", "success");
                    }
                });
            });
            function blockEnter() {
               if (window.event.keyCode == 13) {
                        event.returnValue = false;
                        event.cancel = true;
                    }
                }     
        </script>

       
        <script src="js/bootstrap.min.js"></script>
       
      
    </body>
    </html>