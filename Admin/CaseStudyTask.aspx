<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyTask.aspx.cs" ValidateRequest="false" Inherits="Admin_CaseStudyTask" %>

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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Case Study Task</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li><a href="CaseStudyPanel.aspx">Case Study</a></li>
        <li class="active">Case Study Task</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div>
    

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:Button ID="ImageButton1" runat="server" ToolTip="Print" Text="Print" CssClass="btn btn-large btn-primary" />&nbsp;
                        <asp:Button ID="ImgBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" ToolTip="Back" OnClick="ImgBack_Click" /></span>
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
                 <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Case Study</div>
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCaseStudyCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 <div class="row">
                 <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Paper</div>
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                 </div>
                 </div>
                 </div>
                 </div>
                 <div class="row" >&nbsp;</div>
    

                                    </fieldset>
                                </div>
                            
        </div>
        </div>

        <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        

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
         <div class="row" >
    &nbsp;
    </div>
        <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click" />&nbsp;
        <asp:HiddenField ID="hdnid" runat="server" />
    </div>
            </div> 
        </section>
    </div>
    </form>
</asp:Content>
