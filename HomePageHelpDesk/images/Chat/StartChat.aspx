<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartChat.aspx.cs" Inherits="Chat_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Video Chat</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/main.css"/>
    <style>
        .media
        {
            margin-top:4px;
        }
       
    </style>
</head>
<body style="margin:0px;padding:0px;background:#383838; color:#8a8a8a">
    <form id="form1" runat="server">
    <section class="title"  style="margin:0px;padding:0px">
        <div class="container"  style="margin-top:0px;padding-top:0px">
            <div class="row-fluid">
                <div class="span12">
                    <h2 style="color:#fff">Video Confrencing</h2>
                </div>
            </div>
        </div>
    </section>


    <section id="about-us" class="container main" >
    <div class="row-fluid">
        <div class="span8">
            <div id="videos-container" style="width:100%"></div>
        </div>
        <div class="span4">
            <div class="box text-center" style="background: #fff;margin-bottom: 10px;">
                <input type="text" id="room-id" value="abcdef" style="display:none"/>
                <button id="open-room" class="btn btn-primary" style="font-size: 12px;">Open Room</button>
                <button id="join-room" class="btn btn-success"  style="font-size: 12px;">Join Room</button>
                <button id="open-or-join-room" style="display:none">Auto Open Or Join Room</button>
                <button id="btn-leave-room" disabled class="btn btn-danger"  style="padding:4px;font-size: 12px;">Leave /or close the room</button>
            </div>
            <div class="blog">
                <div class="user-info media box" style="background:#fff;">
                    <div style="overflow: auto;height: 360px;padding: 4px 0px 10px 4px;margin: 0 0 1px 0;">
                    <div id="chat-container">
                        <div id="file-container"></div>
                        <div class="chat-output"></div>
                    </div>
                  </div>
                  <input type="text" class="input-block-level" id="input-text-chat" placeholder="Enter Text Chat" disabled>
                  <button class="btn btn-default" id="share-file" disabled type="button" style="display:none" >IMG!</button>
                </div>    
                <h5 class="text-center">Common chat room for all users</h5>
            </div>
                </div>
        </div>
            
            
            <div class="span1 well" style="display:none">
                <div id="room-urls" style="text-align: center;display: none;background: #F1EDED;margin: 15px -10px;border: 1px solid rgb(189, 189, 189);border-left: 0;border-right: 0;"></div>
            </div>
           
        
    </div>
    </section>
    </form>
        <script src="dist/RTCMultiConnection.min.js"></script>
        <script src="socket/socket.js"></script>

        <!-- custom layout for HTML5 audio/video elements -->
        <script src="https://cdn.webrtc-experiment.com/getMediaElement.js"></script>
        <script src="https://cdn.webrtc-experiment.com:443/FileBufferReader.js"></script>
        <script src="js/main.js"></script>
        <script src="https://cdn.webrtc-experiment.com/commits.js" async></script>
</body>
</html>
