<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CaseStudyTask.aspx.cs" ValidateRequest="false" Inherits="Admin_CaseStudyTask" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

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


    <form id="form1" runat="server">
    <div>
    <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Case Study Task</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
    <div class="row-fluid" >
    <div class="span12"><span class="pull-right"><asp:Button ID="ImageButton1" runat="server" ToolTip="Print" Text="Print" CssClass="btn btn-large btn-primary" />&nbsp;
                        <asp:Button ID="ImgBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" ToolTip="Back" OnClick="ImgBack_Click" /></span>
    </div>
    </div>
    <div class="row-fluid" >&nbsp;</div>
     <div class="row-fluid" >
    <div class="span12">

                                <div id="print_grid" class="table" runat="server">
                                    <fieldset>
    <div class="row-fluid" >
    <div class="span12">
<div class="user-info media box" style="background-color:#fff;">
                 <div class="row-fluid">
                 <div class="span5 form_text field-label">Course Name :</div>
                 <div class="span4" ><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row-fluid">
                 <div class="span5 form_text field-label">Course Code</div>
                 <div class="span4" ><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row-fluid">
                 <div class="span5 form_text field-label">Case Study</div>
                 <div class="span4" ><asp:Label ID="lblCaseStudyCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row-fluid">
                 <div class="span5 form_text field-label">Paper</div>
                 <div class="span4" ><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 </div>
                 </div>
                 </div>
                 <div class="row-fluid" >&nbsp;</div>
    

                                    </fieldset>
                                </div>
                            
        </div>
        </div>

        <div class="row-fluid" >
    <div class="span12">
        

                   <FTB:FreeTextBox ID="txtCasestudy" runat="server" Width="100%">
                                                            </FTB:FreeTextBox>
        <fieldset runat="server" id="fcasestudy" visible="false" >
    <legend>Case Study</legend>
            <div class="user-info media box" style="background-color:#fff;">
                <asp:Label ID="lblcaseStudy" runat="server" ></asp:Label>
          </div>
        </fieldset>
        
     </div>
     </div>
         <div class="row-fluid" >
    <div class="span12">
        </div> 
    </div>
        <div class="row-fluid" >
    <div class="span12">
        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click" />&nbsp;
        <asp:HiddenField ID="hdnid" runat="server" />
    </div>
            </div> 
        </section>
    </div>
    </form>
</asp:Content>
