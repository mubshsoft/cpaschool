<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="SignupCriteria.aspx.cs" Inherits="Admin_SignupCriteria" %>

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
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Evaluation Criteria" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Query</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="frame">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        

    <section class="container main m-tb">
     <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row">
         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Personal Details</div>
     </div>
    <div class="row" style="margin-top: 20px;">
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">Applicant Category</div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:CheckBox ID="chkApplicantCategory" runat="server" /> Applicant Category</div>
     </div>
     <div class="row" >
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">Current Profession</div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:CheckBox ID="chkCurrentProfession" runat="server" /> Current Profession</div>
     </div>
   <div class="row" >
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">Category</div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:CheckBox ID="chkEvaluationCategory" runat="server" /> Category</div>
     </div>
    <div class="row" style="margin-top: 20px;">
         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Educational Details</div>
     </div>
    <div class="row" style="margin-top: 20px;">
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:CheckBox ID="ChkEduDetails" runat="server" /> Educational Details</div>
     </div>

   <div class="row" style="margin-top: 20px;">
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Educational Details</div>
     </div>
   <div class="row" style="margin-top: 20px;">
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:CheckBox ID="chkWorkExp" runat="server" /> Work Experience</div>
     </div>
   
     <div class="row" style="margin-top: 20px;">
    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center">
    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" PostBackUrl="~/Admin/CourseID.aspx" />
    <asp:Button ID="btnSave" runat="server" Text="Save & Continue" CssClass="btn btn-large btn-success" OnClick="btnSave_Click" ValidationGroup="1" />
    </div></div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdnCourseId" runat="server" /></div>
    </div>
    </div>
                                                   
                                            </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
   
    
    </div>
    </form>
</asp:Content>


