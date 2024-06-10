<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AddClosure.aspx.cs" Inherits="Admin_AddClosure" Title="Closure Entry" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Closure Entry</title>--%>
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
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
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
    <h1 class="heading-color">Closure Entry</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Closure Entry</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;"> 
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
      <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
     
    <fieldset>
<div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
      <legend><strong class="style9_sec">Add Date</strong></legend></div></div>
<div class="row" >
    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">Testimonial recvd from TISS:</div>
    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6"><asp:TextBox ID="txtTestimonialsDate" runat="server" Width="110px" CssClass="form-control" ></asp:TextBox>&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="(mm/dd/yy)"></asp:Label>
    <asp:Label ID="lblTestimonialsDateReq" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                                    </div>
                                                                                    
    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">Testimonial sent to student:</div>
    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6"><asp:TextBox ID="txtTestiomonialStudent" runat="server" Width="110px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="(mm/dd/yy)"></asp:Label>
    <asp:Label ID="lblTestiomonialStudent" runat="server" ForeColor="Red" Text=""></asp:Label></div>
    </div>
<div class="row" >
    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">Certificate and Grade Card recvd from TISS:</div>
    <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6"><asp:TextBox ID="txtDispatchedDate" runat="server" Width="110px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="(mm/dd/yy)"></asp:Label>
    <asp:Label ID="lblDispatchedDateReq" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                                   </div>
                                                                                   
    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6">Certificate and Grade Card sent to student:</div>
<div class="col-lg-2 col-md-2 col-sm-6 col-xs-6"><asp:TextBox ID="txtCertificateStudent" runat="server" Width="110px" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;
<asp:Label ID="Label5" runat="server" Text="(mm/dd/yy)"></asp:Label>
<asp:Label ID="lblCertificateStudent" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                                   </div>
                                                                                   </div>
<div class="row" >&nbsp;</div>
<div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center"><asp:Button ID="Imagebutton1" Text="Save"  CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click" />
                        <asp:Button ID="Imagebutton2" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx" /></div>
                        </div>
   </fieldset>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div></div>
                                            </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnCourseId" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnBatchId" runat="server" Visible="false" />
                                           
                                </div>
                            
        </div>
       </section>
    </div>
    </form>
</asp:Content>
