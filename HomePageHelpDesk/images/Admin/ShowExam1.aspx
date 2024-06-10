<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="ShowExam1.aspx.cs" Inherits="Admin_ShowExam1" EnableEventValidation="false" Title="Show Exam" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    
    <style type="text/css">
        .text1
        {
            font-style: normal;
            font-weight: normal;
        }
      
    </style>
    
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
    <h1 class="heading-color">Add Exam Set</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Exam Set</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">

   

    <section class="container main m-tb">

    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right">
    <input type="button" value="Print" class="btn btn-large btn-success" onclick="CallPrint('<%= print_grid.ClientID %>')"/>
    <asp:Button ID="ImgBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" ToolTip="Back" OnClick="ImgBack_Click" /></span>
                                    </div>
                                    </div>
                                    <div class="user-info media box" style="background-color:#fff;">
                                    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="print_grid" runat="server"> 
    <fieldset>
          <legend>Exam Questions</legend>
          <div class="user-info media box" style="background-color:#fff;">
          <div class="row">  
          <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Name</div>
          <div class="col-lg-4 col-md-4col-sm-12 col-xs-12"><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
          </div>
          <div class="row">  
          <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Code</div>
          <div class="col-lg-4 col-md-4col-sm-12 col-xs-12"><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
          </div>
          <div class="row">  
          <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Examination</div>
          <div class="col-lg-4 col-md-4col-sm-12 col-xs-12"><asp:Label ID="lblExamCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
          </div>
          <div class="row">  
          <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Paper</div>
          <div class="col-lg-4 col-md-4col-sm-12 col-xs-12"><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
          </div>
          </div>
          <div class="row"> 
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:Panel ID="pnlqueslist" runat="server" >
                                                        
                                                                                <asp:DataList ID="dlsquestion" runat="server" OnItemDataBound="dlsquestion_ItemDataBound" Width="100%">
                                                                                    <ItemTemplate>
                                                                                        <div class="row"> <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                                                                            <asp:Label ID="lblSection" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'
                                                                                                                                VerticalAlign="Top" Font-Bold="true" CssClass="form_head" width="100%" ></asp:Label>
                                                                                                                                </div></div>
                                                                                                                            <%-- <asp:Label ID="lblSectionInfo" runat="server" VerticalAlign="Top" Font-Bold="true" ForeColor="Black" Font-Size="12px" />--%>
                                                                                                                       
                                                                                                        <%-- <tr>
                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>--%>
                                                                                                       <div class="row"> <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
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
                                                                                                                <span style="vertical-align: top; display:inline">
                                                                                                                    <asp:Label ID="Label2" runat="server" Text="Question" Font-Bold="true" VerticalAlign="Top"></asp:Label>
                                                                                                                    <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top" Font-Bold="true"></asp:Label></span>
                                                                                                                <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                                    VerticalAlign="Top"></asp:Label>
                                                                                                            </div><div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                                                                                                Marks:[<asp:Label ID="lblMarks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MaxQueMarks")%>' />]
                                                                                                           </div></div>

                                                                                                        <tr id="trImage" runat="server">
                                                                                                            <td width="15%" align="left" valign="top">
                                                                                                                <strong class="style9_sec">
                                                                                                                    <asp:Image ID="imgUploadImage" runat="server" />
                                                                                                            </td>
                                                                                                            <td width="75%" align="left">
                                                                                                            </td>
                                                                                                            <td width="10%" align="left">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left" class="text1">
                                                                                                                <asp:Panel ID="panel" runat="server">
                                                                                                                </asp:Panel>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="padding-left: 10px;" class="text1">
                                                                                                                <asp:Panel ID="panel1" runat="server">
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
                                                                                        <asp:DataList ID="dlSubsquestion" runat="server" OnItemDataBound="dlSubsquestion_ItemDataBound" Width="100%">
                                                                                            <ItemTemplate>
                                                                                                <table width="500" border="0" cellpadding="0" cellspacing="10" bgcolor="#ffffff">
                                                                                                    <tr>
                                                                                                        <td align="center" valign="top">
                                                                                                            <table width="490" border="0" cellpadding="0" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td align="left" valign="middle" class="text1">
                                                                                                                        <asp:Label ID="hdnSubQuestionId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SubQuestionId")%>'
                                                                                                                            Visible="false" />
                                                                                                                        <asp:Label ID="hdnType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Type")%>'
                                                                                                                            Visible="false" />
                                                                                                                        <asp:Label ID="hdnSubAnswer" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Answer")%>'
                                                                                                                            Visible="false" />
                                                                                                                        <asp:Label ID="Label2" runat="server" Text="Q" VerticalAlign="Top" Font-Bold="true"></asp:Label>
                                                                                                                        <span style="vertical-align: top">
                                                                                                                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "QuesNo")%>'
                                                                                                                                VerticalAlign="Top"></asp:Label>
                                                                                                                            <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top" Font-Bold="true"></asp:Label>
                                                                                                                        </span><span style="vertical-align: top">
                                                                                                                            <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                                                                VerticalAlign="Top" Width="400px"></asp:Label>
                                                                                                                            <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                                                        </span>
                                                                                                                        <br />
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
       <div class="row"> 
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:HiddenField ID="hdnExamId" runat="server" />
                                                    <asp:HiddenField ID="hdnUserId" runat="server" />
                                                    <asp:HiddenField ID="hdnChk" Value="0" runat="server" />
                                                    <asp:Label ID="lblQues" runat="server" Visible="false" />
                                                    <asp:HiddenField ID="hdnNxtPrv" Value="" runat="server" />
                                                    <asp:Label ID="timerDisplaySpan" runat="server" ForeColor="Black"></asp:Label>
                                                    <asp:HiddenField ID="hdnBid" runat="server" />
                                                    <asp:HiddenField ID="hdnSectionNo" runat="server" />
                                                </div></div>
                                    </fieldset>
                               </div></div> 
</div>
               </section>
    </div>
    </form>

</asp:Content>