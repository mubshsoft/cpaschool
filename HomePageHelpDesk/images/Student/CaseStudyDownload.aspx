<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="CaseStudyDownload.aspx.cs" ValidateRequest="false" Inherits="Student_CaseStudyDownload" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script language="javascript" type="text/javascript">
   
function openPopup(strOpen)
    {
        window.open(strOpen, "Info", "status=1, width=400, height=130, top=300, left=300");
    }
    
   
        
    </script>
   

    <style>
td, th {
    padding: 5px;
}

</style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
            Case Study
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Case Study</li>
          </ol>
        </section>
        <section class="content">
            
  
       
   <div class="box">
   <div class="box-body">                                

 <div runat="server" id="tblonlie" visible="false" >
                                       
    <div class="row">
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                                                <fieldset>
    <legend>Case Study - Question</legend>
            <asp:Label ID="lblcaseStudy" runat="server" ></asp:Label>
          
        </fieldset>
          </div>
          </div>                                 
                                       
            <div class="row">
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >                                  
            
               <FTB:FreeTextBox ID="txtCasestudy" runat="server" Width="100%">
                                                            </FTB:FreeTextBox>
         </div></div>
         <div class="row">&nbsp;</div>
         <div class="row">
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center" ><asp:Button ID="btnSave" Text="Save" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" />
           </div></div>
      
                                          
                                    </div> 
                                    
<div runat="server" id="tbloffline" visible="false" >
                                       
                   <div class="row">
           <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center;" >                     
                                            
                                                    
                                                    
                                                    
                                                    
                                                            <asp:LinkButton ID="lnkbtndownload" runat="server" 
                                                                onclick="lnkbtndownload_Click1">
                                                       <img src="../images/download_case.png" style="border:0px"    /></asp:LinkButton>
                                                       </div>
                                                       <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center" >  
                                                             <asp:LinkButton ID="lnkbtnSubmit" runat="server" onclick="lnkbtnSubmit_Click">
                                                       <img src="../images/submit_case.png" style="border:0px"/></asp:LinkButton>
                                                        
                                           </div>
                                  </div>
                                  <div class="row"> <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center" >      
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" />
                                                </div>
                                     
                                     </div>      
                                    </div>
                             
  </div>
      </div>
   
    
    </section>
        <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    </asp:Content>

