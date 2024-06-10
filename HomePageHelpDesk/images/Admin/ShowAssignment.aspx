<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="ShowAssignment.aspx.cs" Inherits="Admin_ShowAssignment" EnableEventValidation="false" Title="Untitled Page" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
  
    

    <script language="javascript" type="text/javascript">
                         function CallPrint(strid)
                          {
                           var prtContent = document.getElementById(strid);
                           var strOldOne=prtContent.innerHTML;
                           var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
                           WinPrint.document.write(prtContent.innerHTML);
                           WinPrint.document.close();
                           WinPrint.focus();
                           WinPrint.print();
                           WinPrint.close();
                           prtContent.innerHTML=strOldOne;
                          }


    </script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Show Assignment</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Show Assignment</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div>
    

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right">
    <asp:Button ID="ImageButton1" runat="server" ToolTip="Print" Text="Print" CssClass="btn btn-large btn-success" />&nbsp;
    <asp:Button ID="ImgBack" runat="server" Text="Back" CssClass="btn btn-large btn-primary" ToolTip="Back" OnClick="ImgBack_Click" />
    </div>
    </div>
    <div class="row" >&nbsp;</div>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div id="print_grid" class="table" runat="server">
                                    <fieldset>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
<div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Name :</div>
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row">
                 <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Code</div>
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row">
                 <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Assignment</div>
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblAssignmentCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row">
                 <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Paper</div>
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 </div>
                 </div>
                 </div>
                 <div class="row" >&nbsp;</div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 <asp:Panel ID="pnlqueslist" runat="server">
                  <asp:DataList ID="dlsquestion" runat="server" OnItemDataBound="dlsquestion_ItemDataBound" CssClass="table">
                   <ItemTemplate>
                                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                                        <tr>
                                                                                                            <td align="left" valign="middle" class="text1">
                                                                                                                <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 80%; padding-left: 2px;" align="center" class="text1">
                                                                                                                            <asp:Label ID="lblSection" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'
                                                                                                                                VerticalAlign="Top" Font-Bold="true" ForeColor="Black" Font-Size="12px"></asp:Label>
                                                                                                                            <%-- <asp:Label ID="lblSectionInfo" runat="server" VerticalAlign="Top" Font-Bold="true" ForeColor="Black" Font-Size="12px" />--%>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <%-- <tr>
                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>--%>
                                                                                                        <tr>
                                                                                                            <td align="left" valign="top" class="text1" width="85%">
                                                                                                                <asp:Label ID="hdnQuestionId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>'
                                                                                                                    Visible="false" />
                                                                                                                <asp:Label ID="hdnQUESTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>'
                                                                                                                    Visible="false" />
                                                                                                                <asp:Label ID="hdnOPTIONTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>'
                                                                                                                    Visible="false" />
                                                                                                                <asp:Label ID="hdnAnswer" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Answer")%>'
                                                                                                                    Visible="false" />
                                                                                                                <asp:Label ID="hdnCategoryId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryId")%>'
                                                                                                                    Visible="false" />
                                                                                                                <span style="vertical-align: top">
                                                                                                                    <asp:Label ID="Label2" runat="server" Text="Question" Font-Bold="true" VerticalAlign="Top"></asp:Label>
                                                                                                                    <%-- <asp:Label ID="lblRowID" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "ROWID")%>'
                                                                                                                VerticalAlign="Top"></asp:Label>--%>
                                                                                                                    <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top" Font-Bold="true"></asp:Label></span>
                                                                                                                <asp:Label ID="lblName" runat="server" Font-Size="11px" Width="380px" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                                    VerticalAlign="Top"></asp:Label>
                                                                                                                <%-- <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                        <br />--%>
                                                                                                                &nbsp;
                                                                                                            </td>
                                                                                                            <td align="right" valign="top" style="font-size: 11px" width="85%">
                                                                                                                Marks:[<asp:Label ID="lblMarks" Font-Size="11px" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MaxQueMarks")%>' />]
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="trImage" runat="server">
                                                                                                            <td width="15%" align="left" valign="top">
                                                                                                                <asp:Image ID="imgUploadImage" runat="server" />
                                                                                                            </td>
                                                                                                            <td width="75%" align="left">
                                                                                                            </td>
                                                                                                            <td width="10%" align="left">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <asp:Panel ID="panel" runat="server">
                                                                                                                </asp:Panel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="padding-left: 10px;">
                                                                                                                <asp:Panel ID="panel1" runat="server" Font-Bold="false" Font-Size="11px">
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
                                                                                                            <table width="490" border="0" cellpadding="0" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                                        <span style="vertical-align: top">
                                                                                                                            <asp:Label ID="hdnSubQuestionId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>'
                                                                                                                                Visible="false" />
                                                                                                                            <asp:Label ID="hdnType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Type")%>'
                                                                                                                                Visible="false" />
                                                                                                                            <asp:Label ID="hdnSubAnswer" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Answer")%>'
                                                                                                                                Visible="false" />
                                                                                                                        </span><span style="vertical-align: top"></span><span style="vertical-align: top">
                                                                                                                        </span><span style="vertical-align: top"></span>
                                                                                                                        <asp:Label ID="Label2" runat="server" Text="Q" VerticalAlign="Top" Font-Bold="true"></asp:Label>
                                                                                                                        </span><span style="vertical-align: top">
                                                                                                                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "QuesNo")%>'
                                                                                                                                VerticalAlign="Top"></asp:Label>
                                                                                                                            <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top" Font-Bold="true"></asp:Label>
                                                                                                                        </span><span style="vertical-align: top">
                                                                                                                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                                                VerticalAlign="Top" Font-Size="11px" Width="400px" CssClass="style5"></asp:Label>
                                                                                                                            <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                                        </span>
                                                                                                                        <br />
                                                                                                                        &nbsp; </span>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                                        <asp:Panel ID="panel" runat="server" Width="600">
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
                                                                            
                                                    </asp:Panel>
     </div>
     </div>
<div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:HiddenField ID="hdnAsgnId" runat="server" />
                                                    <asp:HiddenField ID="hdnUserId" runat="server" />
                                                    <asp:HiddenField ID="hdnChk" Value="0" runat="server" />
                                                    <asp:Label ID="lblQues" runat="server" Visible="false" />
                                                    <asp:HiddenField ID="hdnNxtPrv" Value="" runat="server" />
                                                    <asp:Label ID="timerDisplaySpan" runat="server" ForeColor="Black"></asp:Label>
                                                    <asp:HiddenField ID="hdnBid" runat="server" />
                                                    <asp:HiddenField ID="hdnSectionNo" runat="server" />
    
    </div>
  </div>
                                    </fieldset>
                                </div>
                            
        </div>
        </div>
        </section>
    </div>
    </form>
</asp:Content>