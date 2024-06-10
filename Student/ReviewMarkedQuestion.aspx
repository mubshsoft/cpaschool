<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="ReviewMarkedQuestion.aspx.cs" Inherits="ReviewMarkedQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
   

.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
   <style type="text/css">
.text1 {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-style: normal;
	font-weight: normal;
}
.style2 {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; font-style: normal; font-weight: normal; }
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
    <script type="text/javascript" src="../stmenu.js"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
   
 <section class="content-header">
          <h1>
            Review Marked Question
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active"> Review Marked Question</li>
          </ol>
        </section>
        <section class="content">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
  
    <div >
  
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%; ">
                        
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background:#fff">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">
                                                            <asp:Label ID="lblCaption" runat="server" />
                                                            </strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"> <a href="StudentPanel.aspx"><font color="#4b4b4b">Back To 
                                                            Student Panel</font> </a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx" class="part1">
                                                                    <font color="#4b4b4b">Logout</font> </a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left" colspan="2">
                                                &nbsp;</td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="center" valign="top">
                                            <td colspan="2">
                                                <asp:DataList ID="dlsquestion" runat="server" OnItemDataBound="dlsquestion_ItemDataBound" Width="100%">
                                                    <ItemTemplate>
                                                        <table width="640" height="365" border="0" align="center" cellpadding="0" cellspacing="5"
                                                            bgcolor="#0ebaec">
                                                            <tr>
                                                                <td align="center" valign="top">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <table width="620" height="300" border="0" cellpadding="0" cellspacing="10" bgcolor="#F7FDFD">
                                                                                    <tr>
                                                                                        <td height="300" align="center" valign="top">
                                                                                            <table width="490" height="115" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                        <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                            <asp:HiddenField ID="hdnQUESTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>' />
                                                                            <asp:HiddenField ID="hdnOPTIONTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>' />
                                                                       <asp:Label ID="Label2" runat="server" Text="Question" VerticalAlign="Top"></asp:Label>
                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ROWID")%>'
                                                                                                            VerticalAlign="Top"></asp:Label>
                                                                                                        <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top"></asp:Label>
                                                                                                        <asp:Label ID="lblName" runat="server" Font-Size="13px" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                            VerticalAlign="Top" Width="200PX"></asp:Label>
                                                                                                       <%-- <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                        <br />--%>
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" >
                                                                                                        <asp:Panel ID="panel" runat="server">
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="padding-left: 20px;">
                                                                                                        <asp:Panel ID="panel1" runat="server" Font-Bold="false" Font-Size="12px">
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
                                                                            </td>
                                                                           
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:DataList ID="dlsquestion" runat="server" OnItemDataBound="dlsquestion_ItemDataBound">
                                                            <ItemTemplate>
                                                                <table width="640" height="365" border="0" align="center" cellpadding="0" cellspacing="5"
                                                                    bgcolor="#0ebaec">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table width="620" height="300" border="0" cellpadding="0" cellspacing="10" bgcolor="#F7FDFD">
                                                                                            <tr>
                                                                                                <td height="300" align="center" valign="top">
                                                                                                    <table width="490" height="115" border="0" cellpadding="0" cellspacing="0">
                                                                                                        <tr>
                                                                                                            <td align="left" valign="middle" class="text1">
                                                                                                                <span style="vertical-align: top">
                                                                                                                    <asp:HiddenField ID="hdnSubQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>' />
                                                                                                                </span><span style="vertical-align: top"></span><span style="vertical-align: top">
                                                                                                                </span><span style="vertical-align: top"></span>
                                                                                                                <asp:Label ID="Label2" runat="server" Text="Question" VerticalAlign="Top"></asp:Label>
                                                                                                                </span><span style="vertical-align: top">
                                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuesNo")%>'
                                                                                                                        VerticalAlign="Top"></asp:Label>
                                                                                                                    <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top"></asp:Label>
                                                                                                                </span><span style="vertical-align: top">
                                                                                                                    <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                                        VerticalAlign="Top" Font-Size="13px" Width="200PX"></asp:Label>
                                                                                                                    <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                                </span>
                                                                                                                <br />
                                                                                                                &nbsp; </span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" valign="middle" class="text1">
                                                                                                                <asp:Panel ID="panel" runat="server">
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
                                                                                    </td>
                                                                                    
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                         <table width="620" border="0"  cellpadding="5" cellspacing="0" bgcolor="#0ebaec" id="tbl" runat="server">
                                               <tr><td>
      <table width="640" height="80" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="445" align="left" valign="middle" background="../Images/panel.jpg" bgcolor="#EBFAFA"><table width="640" height="60" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td width="417" align="left" valign="top"><table width="400" border="0" cellspacing="0" cellpadding="5">
                <tr>
                  <td width="43" align="right" valign="middle">
                      <asp:CheckBox ID="ChkReview" runat="server" />
                    <label>
                      &nbsp;</label><%--<asp:CheckBox 
                          ID="ChkReview" runat="server" />--%>
                                                                                                </td>
                  <td width="337" align="left" valign="middle" class="text1">UnMark for Review</td>
                </tr>
              </table>              </td>
              <td width="223" align="center" valign="middle"><table width="211" height="50" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="113" align="left" valign="middle"><asp:ImageButton ID="btnprev" 
                          runat="server" ImageUrl="../Images/previous_button.jpg"  
                          border="0" onclick="btnprev_Click1" /></td>
                  <td width="10" align="center" valign="middle">&nbsp;</td>
                  <td width="81" align="right" valign="middle"> <asp:ImageButton ID="btnnext" runat="server" ImageUrl="~/Images/next_button.jpg"   onclick="btnnext_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('this','','../Images/next_button_roll.jpg',1)"/></td>
                </tr>
                <tr>
                  <td align="left" valign="middle"><asp:ImageButton ID="btnBackToExam" runat="server" 
                          ImageUrl="~/Images/back_to_exam_button.jpg"  border="0" 
                          onmouseout="MM_swapImgRestore()" 
                          
                          onmouseover="MM_swapImage('Image3','','../Images/review_marked_button_roll.jpg',1)" onclick="btnBackToExam_Click" 
                           /></td>
                  <td align="center" valign="middle">&nbsp;</td>
                  <td align="right" valign="middle"><asp:ImageButton ID="btnEndReview" runat="server" 
                          ImageUrl="~/Images/end_review.jpg" border="0" 
                          onmouseout="MM_swapImgRestore()" 
                          
                          onmouseover="MM_swapImage('Image4','','../Images/end_exam_button_roll.jpg',1)" onclick="btnEndReview_Click" 
                          /></td>
                </tr>
              </table></td>
            </tr>
          </table></td>
        </tr>
		<tr>
		  <td height="20" align="left" valign="bottom" class="style2">Question: <asp:Label ID="lblqueno" runat="server" CssClass="style2"></asp:Label></td>
		</tr>
      </table></td>
  </tr> 
  </table>
                                            </td>
                                        </tr>
                                  
                                        <tr align="left" valign="top">
                                            <td colspan="2">
                                           
  </td>
                                        </tr>
                                  
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="hdnExamId" runat="server" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
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
   </asp:Content>