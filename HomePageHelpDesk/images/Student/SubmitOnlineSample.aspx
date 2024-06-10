<%@ Page Language="C#" Title="Submit Sample" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master"  CodeFile="SubmitOnlineSample.aspx.cs" Inherits="SubmitOnlineSample" %>

<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Submit Sample</title>
    --%>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        .style14
        {
            color: #4b4b4b;
            font-size: 11px;
            font-family: tahoma;
            width: 0;
        }
        label
        {
            display: inline;
            margin-bottom: 5px;
            line-height: 25PX;
        }
        input[type="radio"]
        {
                margin: 0px 10px 0px 0px;
        }
       </style>
    
    <script type="text/JavaScript"> 
function confirmmsg()
{
//if(document.getElementById("lblconfirm").value="1")
//{
//confirm("r u suere?")
//return;
//}
var msg="You are now proceeding to Next Section click on OK to Continue";
if (confirm(msg)==true)
    return true;
  else
    history.go(-1);
}

function disableCtrlKeyCombination(e) {
        
            //list all CTRL + key combinations you want to disable
            var forbiddenKeys = new Array('a', 'n', 'c', 'x', 'v', 'j','s','p');
            var key;
            var isCtrl;
//mala for enter key  refresh problem
           if (window.event) 
            {
               if (e.keyCode == 13)
               return false;
            }
  

            if (window.event) 
            {
                key = window.event.keyCode; //IE
                if (window.event.ctrlKey)
                {
                    isCtrl = true;
                    alert('Ctrl key disable');
                    return false;
                }
                else
                {
                    isCtrl = false;
                }
            }
            else 
            {
                key = e.which; //firefox
                if (e.ctrlKey)
                {
                    isCtrl = true;
                      alert('Ctrl key disable');
                      return false;
                 }
                else
                    isCtrl = false;
            }
            
        }


            function textboxMultilineMaxNumber(w,e)
            {
                var y=w.value;
                var r = 0;
                a=y.replace(/\s/g,' ');
                a=a.split(' ');
                for (z=0; z<a.length; z++) {if (a[z].length >= 0 && r<600){r++;}else {if((e.keyCode==8)|| (e.keyCode>=46) || (e.keyCode>=36 && e.keyCode<=40)){return true;} else {return false;}}}
                //x.value=r;
            } 
            
            function textboxMultilineMaxNumberDes(w,e)
                {
                var y=w.value;
                var r = 0;
                a=y.replace(/\s/g,' ');
                a=a.split(' ');
                for (z=0; z<a.length; z++) {if (a[z].length >= 0 && r<1500){r++;}else {if((e.keyCode==8)|| (e.keyCode>=46) || (e.keyCode>=36 && e.keyCode<=40)){return true;} else {return false;}}}
                //x.value=r;
            } 
</script>

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

 
    <script type="text/javascript">
    function mySubmit() {
        document.getElementById("<%=timerDisplaySpan.ClientID%>").removeAttribute('disabled');
        if(getCookie("Count").length ==0)
        {
          createCookie("Count",document.getElementById("<%=timerDisplaySpan.ClientID%>").childNodes[0].nodeValue,1);
       }
        countdown_clock();
        setCookie("Count",null);
//        window.setInterval('countdown_clock()', 1000);
        
      }
    function countdown_clock() {
        var current_time;
        current_time = getCookie("Count"); //  document.getElementById("<%=timerDisplaySpan.ClientID%>").innerText;
       var hours = current_time.substring(0, 2);
        var minutes = current_time.substring(3, 5);
        var seconds = current_time.substring(6, 8);
        var n_seconds;
        var n_minutes = minutes;
        var n_hours = hours;
        if (seconds == 0) {
            n_seconds = 59;
            if (minutes == 0) {
                n_minutes = 59;
                if (hours == 0) {
                     alert("Your time is over");
                    window.location = 'EndSample.aspx';
                    //return;
                }
                else {

                    n_hours = hours - 1;
                    if (n_hours < 10)
                        n_hours = "0" + n_hours;
                }
            }
            else {
                n_minutes = minutes - 1;
                if (n_minutes < 10)
                    n_minutes = "0" + n_minutes;
            }
        }
        else {
            n_seconds = seconds - 1;
            if (n_seconds < 10)
                n_seconds = "0" + n_seconds;
        }
        document.getElementById("<%=timerDisplaySpan.ClientID%>").innerHTML = n_hours + ':' + n_minutes + ':' + n_seconds;
        createCookie("Count",n_hours + ':' + n_minutes + ':' + n_seconds,"1");
            setTimeout("countdown_clock()", 1000);
        //function call and delay by 1sec
        document.getElementById("<%=timerDisplaySpan.ClientID%>").setAttribute('disabled', 'disabled');
        
    }
    
    function createCookie(name,value,days) 
            {    
            if (days) 
            {        
            var date = new Date();        
            date.setTime(date.getTime()+(days*24*60*60*1000));        
            var expires = "; expires="+date.toGMTString();    
            }    
            else var expires = "";    
            document.cookie = name+"="+value+expires+"; path=/";
            }
            
              function getCookie(c_name)
            {
                if (document.cookie.length>0)
                  {
                      c_start=document.cookie.indexOf(c_name + "=");
                      if (c_start!=-1)
                        {
                            c_start=c_start + c_name.length+1;
                            c_end=document.cookie.indexOf(";",c_start);
                            if (c_end==-1) c_end=document.cookie.length;
                            return unescape(document.cookie.substring(c_start,c_end));
                        }
                  }
                return "";
            }
            
            function setCookie(c_name,expiredays)
            {
                var exdate=new Date();
                exdate.setDate(exdate.getDate()+expiredays);
              
                ((expiredays==null) ? "" : ";expires="+exdate.toGMTString());
            }
    </script>

<%--
<body onload="mySubmit();" oncontextmenu="return false;" onkeypress="disableCtrlKeyCombination(event);" onkeydown="disableCtrlKeyCombination(event);"
	onkeyup="disableCtrlKeyCombination(event);">--%>
      <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Sample Examination
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Sample Examination</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    
    <div onkeypress="disableCtrlKeyCombination(event);" onkeydown="disableCtrlKeyCombination(event);"
	onkeyup="disableCtrlKeyCombination(event);">
        <input type="hidden" id="timeAllocated" name="timeAllocated" runat="server" />
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                       
                       
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px" >
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr valign="middle">
                                            <td height="25" colspan="3" align="center" >
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong>
                                                                <asp:Label ID="lblCaption" runat="server" />
                                                            </strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align:right" colspan="2">
                                                            <blockquote class="pull-right" style="font-family: fantasy;font-size: 24px;">
                                                                <asp:Label ID="timerDisplaySpan" runat="server"  ForeColor="Black"></asp:Label> 
                                                                &nbsp;&nbsp;&nbsp;
                                                                <asp:Label ID="lblQues" runat="server" visible="false"/>
                                                                <asp:HiddenField ID="hdnChk" Value="0" runat="server" />
                                                                <asp:HiddenField ID="hdnNxtPrv" Value="" runat="server" />
                                                            </blockquote>
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="center" valign="top">
                                            <td colspan="2" align="center">
                                            <asp:Panel ID="pnlqueslist" runat="server">
                                                <table height="365" border="0" align="center" cellpadding="0" cellspacing="5">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <table width="100%" style="height: 300px;">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:DataList ID="dlsquestion" runat="server" OnItemDataBound="dlsquestion_ItemDataBound">
                                                                            <ItemTemplate>
                                                                                <table  border="0" cellpadding="0" cellspacing="10">
                                                                                    <tr>
                                                                                        <td align="center" valign="top">
                                                                                            <table  border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                    <table cellpadding="0" cellspacing="0" style="width:100%">
                                                                                                    <tr>
                                                                                                       <td style="width:80%; padding-left:2px;">  
                                                                                                           [<asp:Label ID="lblSection" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'
                                                                                                            VerticalAlign="Top" Font-Bold="true" ForeColor="Black" Font-Size="12px"></asp:Label>
                                                                                                           ]
                                                                                                            <asp:Label ID="lblSectionInfo" runat="server" VerticalAlign="Top" Font-Bold="true" ForeColor="Black" Font-Size="12px" />
                                                                                                            </td>
                                                                                                       <td style="width:20%;padding-right:2px;" align="right"> Marks:[<asp:Label ID="lblMarks" Font-Size="13px" CssClass="style5" runat="server"
                                                                                                            Text='<%#DataBinder.Eval(Container.DataItem, "MaxQueMarks")%>' />]</td>
                                                                                                      </tr>
                                                                                                    </table>
                                                                                                     
                                                                                                            
                                                                                                             
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" class="text1">
                                                                                                        <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                                                        <asp:HiddenField ID="hdnQUESTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>' />
                                                                                                        <asp:HiddenField ID="hdnOPTIONTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>' />
                                                                                                        <asp:HiddenField ID="hdnCategoryId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CategoryId")%>' />
                                                                                                        <span style="vertical-align: top">
                                                                                                            <asp:Label ID="Label2" runat="server" Text="Question" VerticalAlign="Top"></asp:Label>
                                                                                                            <asp:Label ID="lblRowID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ROWID")%>'
                                                                                                                VerticalAlign="Top"></asp:Label>
                                                                                                            <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top"></asp:Label></span>
                                                                                                        <asp:Label ID="lblName" runat="server" Font-Size="13px" Width="380px" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                            VerticalAlign="Top" CssClass="style5" Font-Bold="true"></asp:Label>
                                                                                                      
                                                                                                        <%-- <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                        <br />--%>
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                 <tr><td><%--<asp:Panel ID="Imagepanel" runat="server" Width="490px">
                                                                                                        </asp:Panel>--%><asp:Image runat="server" ID="imgQue" Visible="false"/>
                                                                                                        <asp:HiddenField ID="hdnImagepath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "UploadQuestionImagePath")%>' />
                                                                                                        </td>
                                                                                                        </tr>
                                                                                                  <tr>
                                                                                                        <td>&nbsp;</td>
                                                                                                        </tr>
                                                                                                       
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:Panel ID="panel" runat="server" Width="490px">
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="padding-left: 10px;">
                                                                                                        <asp:Panel ID="panel1" runat="server" Font-Bold="false" Font-Size="12px" Width="490px">
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="5">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:DataList ID="dlSubsquestion" runat="server" OnItemDataBound="dlSubsquestion_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <table width="500" border="0" cellpadding="0" cellspacing="10" bgcolor="#ffffff">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <table width="490" height="115" border="0" cellpadding="0" cellspacing="0">
                                                                                                        <tr>
                                                                                                            <td align="left" valign="middle" class="text1">
                                                                                                                <span style="vertical-align: top">
                                                                                                                    <asp:HiddenField ID="hdnSubQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>' />
                                                                                                                </span><span style="vertical-align: top"></span><span style="vertical-align: top">
                                                                                                                </span><span style="vertical-align: top"></span>
                                                                                                                <asp:Label ID="Label2" runat="server" Text="Q" VerticalAlign="Top"></asp:Label>
                                                                                                                </span><span style="vertical-align: top">
                                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuesNo")%>'
                                                                                                                        VerticalAlign="Top"></asp:Label>
                                                                                                                    <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top"></asp:Label>
                                                                                                                </span><span style="vertical-align: top">
                                                                                                                    <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                                        VerticalAlign="Top" Font-Size="13px" Width="400px" CssClass="style5" Font-Bold="true"></asp:Label>
                                                                                                                    <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                                </span>
                                                                                                                <br />
                                                                                                                &nbsp; </span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="height:5px">
                                                                                                        <td></td>
                                                                                                        </tr>
                                                                                                              <tr>
                                                                                                            <td align="left" valign="middle" class="text1">
                                                                                                                <asp:Panel ID="panel" runat="server" Width="490px">
                                                                                                                </asp:Panel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="5">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                    <td align="left" valign="top" width="150px">
                                                                       
                                                                     <asp:DataList ID="DLSTSECTION" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                                                                            Width="148px" OnItemDataBound="DLSTSECTION_ItemDataBound" ShowHeader="true">
                                                                            <HeaderTemplate>
                                                                          <span class="style5"><%=secname %></span>
                                                                    
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                            
                                                                                <asp:Panel ID="panel" runat="server">
                                                                                    <asp:HiddenField ID="hdncatgno" runat="server" />
                                                                                    <asp:HiddenField ID="hdnhead" runat="server" Value='<%# Eval("Categoryname") %>' />
                                                                                    <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%# Eval("QuestionId") %>' />
                                                                                      <asp:HiddenField ID="hdnSecQueno" runat="server" Value='<%# Eval("ROWID") %>' /> 
                                                                                                                                                                 </asp:Panel>
                                                                                <table bgcolor="#FFFFFF" width="100%">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="23" align="left" valign="middle" class="text1">
                                                                                                        <asp:LinkButton ID="lnkbtncatgno" runat="server" CommandName="pageno" Text='<%# Eval("QuesNo") %>'
                                                                                                            CommandArgument='<%# Eval("QuesNo") %>' OnCommand="lnkbtncatgno_Command"></asp:LinkButton>
                                                                                    
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <table width="100%" border="0" cellpadding="5" cellspacing="0" id="tbl" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" height="80" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="100%" align="left" valign="middle">
                                                                                    <table width="100%" height="60" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td width="70%" align="left" valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                                                                                    <tr>
                                                                                                        <td width="30%" align="right" valign="middle">
                                                                                                            <label>
                                                                                                                &nbsp;</label><asp:CheckBox ID="ChkReview" runat="server" Text="Mark for review"
                                                                                                                    Visible="false" CssClass="style5" ForeColor="Black" />
                                                                                                        </td>
                                                                                                        <td width="70%" align="left" valign="middle" class="text1">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                             <td align="center" valign="middle" width="30%" style="padding-top:7px;">
                                                                                                <table width="100%" height="50" border="0" cellpadding="5" cellspacing="5">
                                                                                                    <tr>
                                                                                                        <td width="45%" align="center" valign="middle">
                                                                                                            <asp:Button ID="btnprev" runat="server" border="0" CssClass="btn btn-primary" style="width:160px" Text="Previous" OnClick="btnprev_Click1" />
                                                                                                            <%--<asp:ImageButton ID="btnprev" runat="server" ImageUrl="../Images/previous_button.jpg"
                                                                                                                border="0" OnClick="btnprev_Click1" />--%>
                                                                                                        </td>
                                                                                                        <td width="10%" align="center" valign="middle">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                        <td width="45%" align="center" valign="middle">
                                                                                                            <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="btn btn-primary" OnClick="btnnext_Click"  style="width:160px" />
                                                                                                            <%--<asp:ImageButton ID="btnnext" runat="server" ImageUrl="~/Images/next_button.jpg" 
                                                                                                                border="0" OnClick="btnnext_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('this','','../Images/next_button_roll.jpg',1)" />--%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" valign="middle">
                                                                                                            <asp:Button ID="btnClear" runat="server" Text="Clear Answer" CssClass="btn btn-warning" onclick="btnClear_Click"  style="width:160px"/>
                                                                                                            <%--<asp:ImageButton ID="btnClear" runat="server" border="0" 
                                                                                                                ImageUrl="~/Images/clear_answer_button.jpg" onclick="btnClear_Click"/>--%>
                                                                                                        </td>
                                                                                                        <td align="center" valign="middle">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                        <td align="center" valign="middle">
                                                                                                            <asp:Button ID="btnEndSample" runat="server" Text="End Exam" CssClass="btn btn-danger" OnClick="btnEndSample_Click"   OnClientClick="return confirm('You are about to end the exam click OK to end the exam.');" Visible="false"  style="width:160px" />
                                                                                                           <%--<asp:ImageButton ID="btnEndSample" runat="server" ImageUrl="~/Images/end_exam_button.jpg"
                                                                                                                border="0" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image4','','../Images/end_exam_button_roll.jpg',1)"
                                                                                                                OnClick="btnEndSample_Click" 
                                                                                                                OnClientClick="return confirm('You are about to end the Sample exam click OK to end the Sample exam');" 
                                                                                                                Visible="False" />--%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="20" align="left" valign="bottom" class="style2" style="color: Black">
                                                                                    Question:
                                                                                    <asp:Label ID="lblqueno" runat="server" CssClass="style2" ForeColor="Black"></asp:Label>
                                                                                    <asp:ImageButton ID="btnReview" runat="server" border="0" 
                                                                                        ImageUrl="~/Images/review_marked_button.jpg" OnClick="btnReview_Click" 
                                                                                        onmouseout="MM_swapImgRestore()" 
                                                                                        onmouseover="MM_swapImage('Image3','','../Images/review_marked_button_roll.jpg',1)" 
                                                                                        Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table></asp:Panel>
                                             <asp:Panel ID="pnlinstruction" runat="server" Visible="false">
                                                <table width="100%" height="365" border="0" align="center" cellpadding="0" cellspacing="5">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <table width="650px" style="height: 300px;">
                                                                <tr>
                                                                    <td valign="top" align="center" >
                                                                 
                                                    <asp:Label ID="lblSection" runat="server" Text="Label" Visible="false"></asp:Label> 
                                                                    </td>
                                                                    
                                                                </tr>
                                                                 <tr>
                                                                    <td valign="top" align="left">
                                                                    
                                                    <%  
                                                        if (dsInstruction != null)
          {
              if (dsInstruction.Tables != null)
              {
                  if (dsInstruction.Tables[0].Rows != null)
                  {
                      if (dsInstruction.Tables[0].Rows.Count > 0)
                      {
                          secText=dsInstruction.Tables[0].Rows[0]["instructiontext"].ToString();
                      }
                  }
              }
          }
                                                     %>
                                                     <%=secText %>
                                                                    </td>
                                                                 </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="650" border="0" cellpadding="5" cellspacing="0" id="Table1" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" height="80" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="100%" align="left" valign="middle" >
                                                                                    <table width="100%" height="60" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td width="70%" align="left" valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                                                                                    <tr>
                                                                                                        <td width="30%" align="right" valign="middle">
                                                                                                            <label>
                                                                                                                &nbsp;</label></td>
                                                                                                        <td width="70%" align="left" valign="middle" class="text1">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td align="center" valign="middle" width="30%" style="padding-top:7px;">
                                                                                                <table width="100%" height="50" border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="45%" align="center" valign="middle">
                                                                                                            &nbsp;</td>
                                                                                                        <td width="10%" align="center" valign="middle">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                        <td width="45%" align="center" valign="middle">
                                                                                                            <asp:ImageButton ID="imgbtnNext" runat="server" ImageUrl="~/Images/Next_section.png" 
                                                                                                                onclick="imgbtnNext_Click" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" valign="middle">
                                                                                                            &nbsp;</td>
                                                                                                        <td align="center" valign="middle">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                        <td align="center" valign="middle">
                                                                                                            &nbsp;</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="20" align="left" valign="bottom" class="style2" style="color: Black">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table></asp:Panel>
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
                                            </td>
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
                                            <td>  <asp:HiddenField ID="hdnFileName" runat="server" />
                                                <asp:HiddenField ID="hdnSamId" runat="server" />
                                                <asp:HiddenField ID="hdnUserId" runat="server" />
                                                 <asp:HiddenField ID="hdnBid" runat="server" />
                                                  <asp:HiddenField ID="hdnSectionNo" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
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
    
    </div>
    </div>
</section>
</div>
<script type="text/javascript">
    //call all required functions
    mySubmit();
    if (document.addEventListener) { // IE >= 9; other browsers
        document.addEventListener('contextmenu', function (e) {
            alert("Right click is desabled"); //here you draw your own menu
            e.preventDefault();
        }, false);
    } else { // IE < 9
        document.attachEvent('oncontextmenu', function () {
            alert("Right click is desabled");
            window.event.returnValue = false;
        });
    }
    document.onselectstart = new Function("return false");
    //disableCtrlKeyCombination(event); 
    
</script>
 <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
 <script language="javascript" type="text/javascript">

     $(document).ready(function () {
         alert('hi');
     });
     </script>
</asp:Content>