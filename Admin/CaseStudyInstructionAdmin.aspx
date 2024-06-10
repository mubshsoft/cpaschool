<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyInstructionAdmin.aspx.cs" Inherits="Admin_CaseStudyInstructionAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

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
                        function CallPrint(strid)
                        {
                            
                           var prtContent = document.getElementById(strid);
                           var strOldOne = prtContent.innerHTML;
                           
                           var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
                           WinPrint.document.write(prtContent.innerHTML);
                           WinPrint.document.close();
                           WinPrint.focus();
                           WinPrint.print();
                           WinPrint.close();
                           prtContent.innerHTML=strOldOne;
                          }
    </script>

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
        }
        </style>
<style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
    .row-new 
    {
            border-bottom: dashed 1px #ccc;
    height: 25px;
    margin-bottom: 5px;
    margin-top: 5px;
    }
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Assignment Answer Sheet</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li><a href="CaseStudyPanel.aspx">Case Study</a></li>
        <li class="active">Assignment Answer Sheet</li>
		</ul>
	</div>
    </section>
   
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="frame">
        
    
    <section class="container main m-tb">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
       <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
      
       </div>
       </div>
      <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right"> 
                             <asp:Button ID="ImageButton1" runat="server"  ToolTip="Print" Text="Print" class="btn btn-primary" />&nbsp;&nbsp;
                                                 <asp:Button ID="ImgBack" runat="server" ToolTip="Back" onclick="ImgBack_Click" Text="Back" class="btn btn-warning" />
                                                 </div>
                                                 </div>
                                                 <div class="row">&nbsp;</div>
<div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" > 
                                                
                        
                               <div id="print_grid" class="style5" runat="server" >
                               <div class="user-info media box" style="background-color:#fff;">    
                                     <fieldset>
                                    
   
                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblCaption" runat="server" /></div></div>
                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="Label1" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:LinkButton ID="lnkbtnexport" runat="server" OnClick="lnkbtnexport_Click" Visible="false">Export To Word</asp:LinkButton></div></div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Name :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Code :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Case Study Code :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Paper :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Name of the Student :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Student Reference ID :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Total Time Allotted :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Time Taken by the Student :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblTimeTaken" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Case Study :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    </fieldset>
                                    
                                    </div>
                                    
                                    <div class="user-info media box" style="background-color:#fff;">       
                                    <fieldset>
                                    <legend>Case Study - Question</legend>
                                        <asp:Label ID="lblcaseStudy" runat="server" ></asp:Label>
                                    </fieldset>
                                    </div>
                                    <div class="user-info media box" style="background-color:#fff;">
                                    <fieldset>
                                    <legend>Case Study - Answer</legend>
                                        <asp:Label ID="lblAnswers" runat="server" ></asp:Label>
                                        </fieldset>
                                        </div>
        
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnSectionId" runat="server" Visible="false"/>
                                           
                                    
                                </div>
                            
                                                                    </div>
                                                                    </div>                                                            
     
                                            </section>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            
    </form>

</asp:Content>

