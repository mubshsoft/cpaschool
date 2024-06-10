<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="FacultyCompleteFormReport.aspx.cs" Inherits="Admin_FacultyCompleteFormReport" Title="Faculty Complete Report Form" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Faculty Complete Report Form</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
  <script language="javascript" type="text/javascript">
  function myprint()
{   
    window.print();
}

  function closepopup()
{    
    window.close();
}
//function CallPrint(strid)

//{


//var prtContent = document.getElementById(strid);


//var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=1000,status=0');

////WinPrint.document.write("<STYLE><!-- body{width:100%;margin:0;float:none;color: #000000;font-size: 11px;font-family: tahoma;word-spacing:0.5mm;} --></STYLE>");

//WinPrint.document.write(prtContent.innerHTML );

//WinPrint.document.close();

//WinPrint.focus(); 


//WinPrint.print();


////WinPrint.print();

//WinPrint.close();

// prtContent.innerHTML=strOldOne;

//function CallPrint(strid)
//  {
//   var prtContent = document.getElementById(strid);
//   var strOldOne=prtContent.innerHTML;
//   var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
//   WinPrint.document.write(prtContent.innerHTML);
//   WinPrint.document.close();
//   WinPrint.focus();
//   WinPrint.print();
//   WinPrint.close();
//   prtContent.innerHTML=strOldOne;
//  }


//}


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
    <h1 class="heading-color">Faculty Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
<li><a href="ReportList.aspx">Report Panel</a></li>
       <li class="active">Faculty Report</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
       

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:Label ID="lbldate" runat="server"  Text="DATE :" Font-Names="Tahoma" Font-Size="11px" Font-Bold ></asp:Label> <asp:Label ID="lblShowDate" runat="server" ></asp:Label></span></div></div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Account Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Email Address (will be the user id) : <asp:Label ID="Label1" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" MaxLength="49" Enabled="false"></asp:TextBox></div>
                 </div>
     </div>
     <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Contact Details</div>
                </div>
                <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">First Name :<asp:Label ID="Label4" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox></div>
                                                        
                 </div>
                 <div class="row">            
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Middle Name :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox></div>
                 </div>
                 <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Last Name :<asp:Label ID="Label5" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Birth :<asp:Label ID="Label6" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" MaxLength="10" Enabled="false"></asp:TextBox></div>
                </div>
                                                   
                                                    <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
               <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Permanent Address :<asp:Label ID="Label7" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Enabled="false"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Correspondence Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Enabled="false"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Contact Number :<asp:Label ID="Label8" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" MaxLength="15" Enabled="false"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Mobile Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" MaxLength="15" Enabled="false"></asp:TextBox></div>
                </div>
      </div> 
      <div class="user-info media box" style="background-color:#fff;">
      <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Personal Details</div>
                </div>
                <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Gender :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtGender" runat="server" CssClass="form-control" MaxLength="15" Enabled="false"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" MaxLength="15" Enabled="false"></asp:TextBox></div>
                </div>
                 <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" MaxLength="15" Enabled="false"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Profile :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtprofile" CssClass="form-control" MaxLength="1000" runat="server" Rows="4" TextMode="MultiLine" Enabled="false"></asp:TextBox></div>
                </div>
     </div>                                           
     </div>
     </div>  
     <div class="row" >&nbsp;</div>                                             
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton2" runat="server" Text="Close" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/FacultyReport.aspx" Visible="False" onclick="ImageButton2_Click" />
<asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" style="text-align: left" ToolTip="Print" OnClientClick= "myprint()"/>
</div>
</div>
                                                  
                                                    
                                                    
                                                    
                                                    <%--                                                  <tr>
                                                   <td  >
                                                            &nbsp;</td>
                                                            
                                                  <td>
                                                        &nbsp;</td>
                                                  <td align="left"> 
                                                  <div style="width:210px; overflow-x:auto">
                                                      <asp:ListBox ID="lst" runat="server" CssClass="NormalText"  
                                                          SelectionMode="Multiple"  Height="100px" width="310px"></asp:ListBox>
                                                   </div>
                                                      </td>
                                                  </tr>--%>
                                                   
                        </section>
                   
      </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    </form>
</asp:Content>

