<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateVC.aspx.cs" Inherits="CreateVC" %>
<html>
<head><title>Organise Video Conference</title>
<link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="css/main.css">
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="Stylesheet" type="text/css" />
    <script src="js/jquery-2.1.4.min.js"></script>
</head>
<body>
  <div class="content-wrapper">
    <form id="form1" runat="server">
    <section style="padding:0px 30px">
        <div class="row">
                <div class="col-md-12">
                    <h4><i class="fa fa-video-camera"></i>  Organise Video Conference
                    <span class="pull-right"><a href="Default.aspx">Back</a></span>
                    </h4>
                </div>
            </div>
    </section>
    
    
        <div class="col-md-8 col-sm-12 col-xs-12" style="padding-top:4px; margin:0 auto;">
        
            <section class="container-fluid">
                <div class="panel-primary">
                    <div class="panel-heading" style="text-align:left">
                        Conference Detail
                    </div>
                    <div class="panel-body" style="background:#f5f5f5">
                        <div class="form-group">
                            <asp:TextBox ID="txtVCRoomCreator" runat="server" placeholder="Organiser Name" required class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtOrganiserEmail" runat="server" placeholder="Organiser Email" required class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtConfTopic" runat="server" placeholder="Topic for conferencing" required class="form-control" TextMode="MultiLine" Rows="7"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6" style="margin-left:0px; padding-left:0px">
                                <asp:TextBox ID="txtRoomName" runat="server" required placeholder="Room Name" class="form-control"></asp:TextBox>   
                            </div>
                            <div class="col-md-6" style="margin-right:0px; padding-right:0px">
                                <asp:TextBox ID="txtRoomDate" runat="server" class="form-control input-append date" placeholder="Conference Date Time"></asp:TextBox> 
                            </div>
                        </div>
                        <asp:Label ID="lblVCRoom" runat="server" class="text-warning"></asp:Label>
                    </div>
                    <div class="panel-footer" style="padding: 14px 15px;">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" 
                            Text="Save Details and Invite Members" onclick="btnSubmit_Click"/>
                    </div>
                </div>
            </section>

        </div>
        <div class="col-md-4 col-sm-12 col-xs-12" style="padding-top:4px; margin:0 auto;">
           
            <section class="container-fluid">
                <div class="panel-primary">
                    <div class="panel-heading" style="text-align:left">
                        Conference Members
                    </div>
                    <div class="panel-body" style="background:#f5f5f5">
                        Your Room ID is <b><asp:Label ID="lblRoomId" runat="server"></asp:Label></b>
                        <hr style="margin-top:12px" />
                        <div class="form-group has-feedback">
                            <asp:TextBox ID="txtMembers" runat="server" placeholder="Add email of members separated with commas(,)" required class="form-control" TextMode="MultiLine" Rows="12"></asp:TextBox>
                            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                        </div>
                        Your Created Rooms: <asp:DropDownList AutoPostBack="true" CssClass="form-control" ID="ddlRooms" 
                            runat="server" onselectedindexchanged="ddlRooms_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    
                </div>
            </section>
        </div>
    
    
    <script src="js/plugins/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
  <script type="text/javascript">
      $('#' + '<%=txtRoomDate.ClientID %>').datetimepicker({
        format: "yyyy-mm-dd hh:ii",
        showMeridian: true,
        autoclose: true,
        todayBtn: true,
        minuteStep: 30,
        pickerPosition: "top-right"
    });
    $('#' + '<%=txtRoomDate.ClientID %>').click(function () {
        document.getElementsByClassName('datetimepicker')[0].style.width = '220px';
    });
    $('#' + '<%=txtRoomDate.ClientID %>').focus(function () {
        document.getElementsByClassName('datetimepicker')[0].style.width = '220px';
    });
  </script>
    </form>
  </div>
  </body>
  </html>
  
