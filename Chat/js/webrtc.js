// ......................................................
// .......................UI Code........................
// ......................................................


var username = "";
var usertype = "";
var chatstyle;
//function OpenRoom() {
//    disableInputButtons();
//    connection.open(document.getElementById('room-id').value, function () {
//        showRoomURL(connection.sessionid);
//    });
//    document.getElementById('open-room').style.display = "none";
//};
//function JoinRoom() {
//    disableInputButtons();
//    connection.join(document.getElementById('room-id').value);
//    document.getElementById('join-room').style.display = "none";
//};
//document.getElementById('open-or-join-room').onclick = function () {
//    disableInputButtons();
//    connection.openOrJoin(document.getElementById('room-id').value, function (isRoomExists, roomid) {
//        if (!isRoomExists) {
//            showRoomURL(roomid);
//        }
//    });
//};
//document.getElementById('btn-leave-room').onclick = function () {
//    this.disabled = true;
//    if (connection.isInitiator) {
//        // use this method if you did NOT set "autoCloseEntireSession===true"
//        // for more info: https://github.com/muaz-khan/RTCMultiConnection#closeentiresession
//        connection.closeEntireSession(function () {
//            //document.getElementById('alert').innerHTML = 'Entire session has been closed.';
//        });
//    }
//    else {
//        connection.leave();
//    }
//};
// ......................................................
// ................FileSharing/TextChat Code.............
// ......................................................
document.getElementById('sharefile').onclick = function () {
    var fileSelector = new FileSelector();
    fileSelector.selectSingleFile(function (file) {
        connection.send(file);
    });
};
function leave() {
    if (document.getElementById("userType").value == "Organiser") {
        // use this method if you did NOT set "autoCloseEntireSession===true"
        // for more info: https://github.com/muaz-khan/RTCMultiConnection#closeentiresession
//        connection.closeEntireSession(function () {
//            deleteRoomMember("All", document.getElementById("roomid").value);
//            //document.getElementById('alert').innerHTML = 'Entire session has been closed.';
        //        });
        deleteRoomMember("All", document.getElementById("roomid").value);
        connection.leave();
    }
    else {
        deleteRoomMember(document.getElementById("userEmail").value, document.getElementById("roomid").value);
        connection.leave();
    }
}
document.getElementById('input-text-chat').onkeyup = function (e) {

    if (e.keyCode != 13) return;
    // removing trailing/leading whitespace
    this.value = this.value.replace(/^\s+|\s+$/g, '');
    //    this.value = "<b style='" + chatstyle + "'>" + username + "</b> : " + this.value;
    var usershortname = document.getElementById('userEmail').value.substring(0, document.getElementById('userEmail').value.indexOf("@"));
    var msgcontainer;
    if (document.getElementById('userType').value == "Organiser") {
        msgcontainer = '<div class="message me"><span class="info">'+ usershortname +' </span><p>' + this.value + '</p></div>';
    }
    else {
        var msgcontainer = '<div class="message you"><span class="info">' + usershortname + ' </span><p>' + this.value + '</p></div>';
    }
    this.value = msgcontainer;
    if (!this.value.length) return;
    connection.send(this.value);
    appendDIV(this.value);
    this.value = '';
};
var chatContainer = document.querySelector('.messages');
function appendDIV(event) {
    var div = document.createElement('div');
    //div.innerHTML = event.data || event;
    var eventdata = event.data || event;
    //chatContainer.insertBefore(div, chatContainer.firstChild);

    
    document.getElementById('ChatText').innerHTML = document.getElementById('ChatText').innerHTML + eventdata;
    document.getElementById('ChatText').parentNode.parentNode.scrollTop = document.getElementById('ChatText').scrollHeight;
    div.tabIndex = 0;
    div.focus();
    document.getElementById('input-text-chat').focus();
}
// ......................................................
// ..................RTCMultiConnection Code.............
// ......................................................
var connection = new RTCMultiConnection();
// by default, socket.io server is assumed to be deployed on your own URL
connection.socketURL = '/';
// comment-out below line if you do not have your own socket.io server
connection.socketURL = 'https://rtcmulticonnection.herokuapp.com:443/';
connection.socketMessageEvent = 'audio-video-file-chat-demo';
//connection.enableFileSharing = true; // by default, it is "false".
connection.session = {
    audio: true,
    video: true,
    data: true
};
connection.sdpConstraints.mandatory = {
    OfferToReceiveAudio: true,
    OfferToReceiveVideo: true
};
connection.videosContainer = document.getElementById('videos-container');
connection.onstream = function (event) {
    var width = parseInt(connection.videosContainer.clientWidth / 3) - 20;
    var mediaElement = getMediaElement(event.mediaElement, {
        title: event.userid,
        buttons: ['full-screen', 'record-video'],
        width: width,
        showOnMouseEnter: true,
        onRecordingStarted: function (video) {
            //www.RTCMultiConnection.org/docs/startRecording/
            connection.streams[event.streamid].startRecording({
                audio: true,
                video: true,
                data:true
            });
            //alert("Recording Started");
        },
        onRecordingStopped: function (type) {
            // www.RTCMultiConnection.org/docs/stopRecording/
//            connection.streams[event.streamid].stopRecording(function (blob) {
//                if (blob.audio) connection.saveToDisk(blob.audio);
//                else if (blob.video) connection.saveToDisk(blob.audio);
//                else connection.saveToDisk(blob);
            //            }, type);
           // alert("Recording Stoped");

            var stream = connection.streams[event.streamid];
            stream.stopRecording(function (blob) {
                var spanPlay;
                if (blob.audio && !(connection.UA.Chrome && stream.type == 'remote')) {
                    spanPlay = document.createElement('span');
                    spanPlay.innerHTML = '<a href="' + URL.createObjectURL(blob.audio) + '" target="_blank">View recorded ' + blob.audio.type + '</a>';
                    document.getElementById(event.streamid).appendChild(spanPlay);
                    invokeSaveAsDialog(blob.video);
                }
                if (blob.video) {
                    spanPlay = document.createElement('span');
                    spanPlay.innerHTML = '<a href="' + URL.createObjectURL(blob.video) + '" target="_blank"><i class="play-recorded fa fa-play"></i></a>';
                    document.getElementById(event.streamid).appendChild(spanPlay);
                    var filename = event.extra.userEmail.substring(0, event.extra.userEmail.indexOf('.'));
                    invokeSaveAsDialog(blob.video, filename);
                }
            });

        }
    });
    connection.videosContainer.appendChild(mediaElement);
    setTimeout(function () {
        mediaElement.media.play();
    }, 5000);
    mediaElement.id = event.streamid;
    //updateRoomMembers(mediaElement.id);
    //getActiveMembers(document.getElementById('roomid').value);
    //new element append with emailid from memberid
    createVideoCaption(event.streamid, event.extra.userEmail);
};
connection.onstreamended = function (event) {
    var mediaElement = document.getElementById(event.streamid);
    if (mediaElement) {
        mediaElement.parentNode.removeChild(mediaElement);
        //getActiveMembers(document.getElementById("roomid").value);
        updateMemberList();
    }
};

connection.onmessage = appendDIV;
connection.filesContainer = document.getElementById('file-container');
connection.onopen = function () {
    
    //document.getElementById('input-text-chat').disabled = false;
    //document.getElementById('btn-leave-room').disabled = false;
    //alert(connection.name);
    
};
connection.onclose = function () {
    if (connection.getAllParticipants().length) {
        //document.getElementById('alert').innerHTML = 'You are still connected with: ' + connection.getAllParticipants().join(', ');
    }
    else {
        deleteRoomMember(document.getElementById("userEmail").value, document.getElementById("roomid").value);
        //document.getElementById('alert').innerHTML = 'Seems session has been closed or all participants left.';
    }
};
connection.onEntireSessionClosed = function (event) {
    
    //deleteRoomMember("All", document.getElementById("roomid").value);
    
    connection.attachStreams.forEach(function (stream) {
        stream.stop();
    });
    // don't display alert for moderator
    if (connection.userid === event.userid) return;
    //document.getElementById('alert').innerHTML = 'Entire session has been closed by the moderator: ' + event.userid;
};
connection.onUserIdAlreadyTaken = function (useridAlreadyTaken, yourNewUserId) {
    // seems room is already opened
    connection.join(useridAlreadyTaken);
};
function disableInputButtons() {

}
// ......................................................
// ......................Handling roomid................
// ......................................................
function showRoomURL(roomid) {
    var roomHashURL = '#' + roomid;
    var roomQueryStringURL = '?roomid=' + roomid;
    var html = '<h2>Unique URL for your room:</h2>';
    html += 'Hash URL: <a href="' + roomHashURL + '" target="_blank">' + roomHashURL + '</a>';
    html += '<br>';
    html += 'QueryString URL: <a href="' + roomQueryStringURL + '" target="_blank">' + roomQueryStringURL + '</a>';
    var roomURLsDiv = document.getElementById('room-urls');
    roomURLsDiv.innerHTML = html;
    roomURLsDiv.style.display = 'block';
}
(function () {
    var params = {},
                    r = /([^&=]+)=?([^&]*)/g;
    function d(s) {
        return decodeURIComponent(s.replace(/\+/g, ' '));
    }
    var match, search = window.location.search;
    while (match = r.exec(search.substring(1)))
        params[d(match[1])] = d(match[2]);
    window.params = params;
})();

var hashString = location.hash.replace('#', '');
if (hashString.length && hashString.indexOf('comment-') == 0) {
    hashString = '';
}
var roomid = params.roomid;
if (!roomid && hashString.length) {
    roomid = hashString;
}
if (roomid && roomid.length) {
    //document.getElementById('room-id').value = roomid;
    localStorage.setItem(connection.socketMessageEvent, roomid);
    // auto-join-room
    (function reCheckRoomPresence() {
        connection.checkPresence(roomid, function (isRoomExists) {
            if (isRoomExists) {
                connection.join(roomid);
                return;
            }
            setTimeout(reCheckRoomPresence, 5000);
        });
    })();
    disableInputButtons();
}

var roomusers="";
function updateRoomMembers(MembId) {
    //alert("Going to update memberid: userEmail = " + userEmail + " MemberId = " + MembId);
    $.post("WebService.asmx/updateRoomMember",
    {
        userEmail: document.getElementById('userEmail').value,
        MemberId: MembId
    },
    function (data, status) {
    });
    //document.getElementById(document.getElementById('userEmail').value).style.background = "#47f50f";
}
function updateMemberPresence(userEmail, MemberId) {
    MemberIds = "";
    for (i = 0; i < document.getElementsByClassName("media-container").length; i++) {
        MemberIds = MemberIds + document.getElementsByClassName("media-container")[i].id + ", ";
    }
    alert(MemberIds);
    
}

function deleteRoomMember(useremail, rid) {
    $.post("WebService.asmx/deleteRoomMember",
    {
        userEmail: document.getElementById('userEmail').value,
        RoomId: rid
    },
    function (data, status) {
    });
}

function createVideoCaption(memberId,userEmail) {
    var newElement = document.createElement("div");
    newElement.setAttribute("class", "videoCaption");
    newElement.innerHTML = userEmail;
    document.getElementById(memberId).appendChild(newElement);
    updateMemberList();
}
function updateMemberList() {
    for (i = 0; i < document.getElementsByClassName("badge").length; i++) {
        document.getElementsByClassName("badge")[i].style.background = "red";
    }
        for (i = 0; i < document.getElementsByClassName('videoCaption').length; i++) {
            //alert("Chaing Color of " + document.getElementsByClassName('videoCaption')[i].innerHTML);
            elementId = document.getElementsByClassName('videoCaption')[i].innerHTML.trim();
            document.getElementById(elementId).style.background = "lime";
        }
}