<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartVC.aspx.cs" Inherits="StartVC" %>
<html>
<head><title>Start VC</title>

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
                    <h4><i class="fa fa-video-camera"></i>  Start Video Conference
                    <span class="pull-right"><a href="Default.aspx">Back</a></span>
                    </h4>
                </div>
            </div>
    </section>
   
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding-top:4px; margin:0 auto; padding:0px">
        
            <section class="container-fluid">
                <div class="panel-primary">
                    <div class="panel-heading" style="text-align:left">
                        Conference Detail
                    </div>
                    <div class="panel-body" style="background:#f5f5f5">
                        <div class="col-md-6">
                            <blockquote style="background: #ffffff;padding:16px;">
                                <p style="margin:0px"><b><i class="fa fa-user-secret"></i> Organiser: </b><asp:Label ID="lblOrganiser" runat="server"/></p>
                                <small><asp:Label ID="lblOrganiserEmail" runat="server"></asp:Label></small>
                           </blockquote>
                           <div class="card">
                                <div class="input-group"><span class="input-group-addon"><i class="fa fa-check-square-o"></i> Select Your Room</span>
                                <asp:DropDownList ID="ddlRooms" runat="server" AutoPostBack="true" CssClass="form-control" 
                                    onselectedindexchanged="ddlRooms_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="card">
                                <h4 class="card-title" style="border-bottom: solid 1px #f5f5f5;"><i class="fa fa-edit"></i> Conference Topic</h4>
                                <div class="card-body"><asp:Label ID="lblTopic" runat="server"></asp:Label></div>
                            </div>
                           
                        </div>
                        <div class="col-md-6">
                            <div class="card">
                                <h4 class="card-title"><i class="fa fa-group"></i> Active Room Members</h4>
                                <div class="card-body"><asp:Label ID="lblActiveMembers" runat="server"></asp:Label></div>
                            </div>
                            <div class="card">
                                <h4 class="card-title"><i class="fa fa-group"></i> Room Members</h4>
                                <div class="card-body"><asp:Label ID="lblRoomMembers" runat="server"></asp:Label></div>
                            </div>
                        </div>
                        
                        </div>

                    
                    <div class="panel-footer" style="padding: 14px 15px;">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" 
                            Text="Start Conference" onclick="btnSubmit_Click" Visible="false"/>
                        <asp:Label ID="lblMSG" runat="server" Visible="true">
                            <div class="alert alert-dismissible alert-warning">
                                <button class="close" type="button" data-dismiss="alert">×</button>
                                <h4>Alert!</h4>
                                <p>Room not found for you</p>
                            </div>
                        </asp:Label>
                    </div>
                 </div>
            </section>

        </div>
    </form>
</div>
</body>
</html>