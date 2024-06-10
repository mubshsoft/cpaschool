<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DetailsExamInfo.aspx.vb"
    Inherits="Admin_DetailsExamInfo" %>

<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Submit Exam</title>
     <script type="text/javascript" src="../stmenu.js"></script>
    <style type="text/css">
        .text1
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
        }
        .style2
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            font-weight: normal;
        }
    </style>

    <script type="text/JavaScript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
    </script>
<script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
                     }
    </script>
    <%--<script language="JavaScript">
                function window::onload()
                {
                 var timeAlloted = 20;

                 if ( document.getElementById('timeAllocated').value.length > 0 )
                  timeAlloted = parseFloat(document.getElementById('timeAllocated').value);
                 else
                  document.getElementById('timeAllocated').value = timeAlloted;

                 document.getElementById('timerDisplaySpan').innerHTML = 
                  '<b>Time Remaining: ' + timeAlloted + " Minutes.</b>";
                 
                 // 1000 = 1 second...
                 window.setInterval('decrementTimer()', 60000);
                }

                function decrementTimer()
                {
                 var timeAlloted = parseFloat(document.getElementById('timeAllocated').value);
                 timeAlloted--;
                 document.getElementById('timeAllocated').value = timeAlloted;

                 document.getElementById('timerDisplaySpan').innerHTML = 
                  '<b>Time Remaining: ' + timeAlloted + " Minutes.</b>";
                
                 
                 if(timeAlloted==0)
                 {
                alert("Your time is over");
                 window.location = 'EndExam.aspx';
                 }
                }

    </script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span id="timerDisplaySpan"></span>
        <input type="hidden" id="timeAllocated" name="timeAllocated" value="20" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="100%" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td height="127" align="center" valign="top">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">
                                                                <asp:Label ID="lblCaption" runat="server" />
                                                            </strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="StudentPanel.aspx"><font color="#4b4b4b">Back To 
                                                            Student Panel</font></a></strong>&nbsp; <strong class="style9_sec">
                                                                    <a href="../logout.aspx" class="part1"><font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color: #ffffff;" align="center" class="style9_sec" colspan="2">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color: #ffffff;" align="center" class="style9_sec" colspan="2">
                                                            <asp:Button ID="btnExportToWord" runat="server" Text="Export"/> </td>
                                                       
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="center" valign="top">
                                            <td colspan="2" align="center">
                                                <table width="100%" height="365" border="0" align="center" cellpadding="0" cellspacing="5"
                                                    style="border: solid 5px #0ebaec">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:DataList ID="LstUserExaminfo" runat="server"  RepeatLayout="Table"
                                                                Width="100%" >
                                                                <ItemTemplate>
                                                                    <br />
                                                                    <table cellpadding="5px" cellspacing="0" class="dlTable">
                                                                        <tr>
                                                                            <td valign="top" align="left" width="18%">Que  <br />Answer  <br /> Correct Answer </td>
                                                                            <td width="2%">:<br />:<br />:</td>
                                                                            <td valign="top" width="80%" align="left" >
                                                                                <asp:Label ID="lblQuestionText" Text='<%# Eval("QuestionText")%>' runat="server"></asp:Label>
                                                                                <br />
                                                                                
                                                                                 <asp:Label ID="lblAnsText" Text='<%# Eval("AnsText")%>' runat="server"></asp:Label>
                                                                                  <br />     
                                                                                 <asp:Label ID="lblAnswer" Text='<%# Eval("Answer")%>' runat="server"></asp:Label>
                                                                                  
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                    </table>
                                                                    <br />
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td align="center">
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnExamId" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <uc2:Footer ID="Footer1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
