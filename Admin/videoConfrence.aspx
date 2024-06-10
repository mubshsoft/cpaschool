<%@ Page Title="" Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="videoConfrence.aspx.vb" Inherits="Admin_videoConfrence" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Sending Mail</title>--%>

 <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
   
    
      <script language="javascript" type="text/javascript">
          function HideMessage() {

              if (document.all) {
                  document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
              }
              else {
                  document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
              }
          }
    </script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 0em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
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
        .icon-position
        {
        position: absolute;
        right: 20px;
        top: 10px;
        }
    </style>
     <script language="javascript" type="text/javascript" src="../datetimepicker.js"></script>
    </asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <section class="fullwidth banner-color">
    <h1 class="heading-color" style="margin-top: 1em;">Add Video Confrence</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
         <li><a href="ConferencePanel.aspx">Confrence Panel</a></li>
        <li class="active">Add Video Confrence</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">
        
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                
                                 
  
    <section class="container main m-tb">
                
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                                 
                                                               
                                       
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                                          <div class="user-info media box" style="background-color:#fff;">
                                          <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                                          </div>
                                          <div class="row">
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" placeholder="Course" ToolTip="Course" CssClass="form-control" AutoPostBack="true" ></asp:DropDownList></div>
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlBatch" runat="server" placeholder="Batch" ToolTip="Batch"  AutoPostBack="true" CssClass="form-control"></asp:DropDownList></div>
                                          </div>
                                          <div class="row">
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlSemester" runat="server" placeholder="Semester" ToolTip="Semester" CssClass="form-control" ></asp:DropDownList></div>
                                         
                                         <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtdt" runat="server" ToolTip="Activation Date" placeholder="Confrence Date" CssClass="form-control"></asp:TextBox>
                                               <a href="javascript:NewCal('<%= txtdt.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
                                               &nbsp;<asp:Label ID="lblactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                                          </div>
                                          <div class="row">
                                          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><asp:TextBox ID="txtSubject" placeholder="Subject" ToolTip="Subject" runat="server" CssClass="form-control"></asp:TextBox></div>
                                          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><asp:TextBox ID="txtLink" placeholder="Confrence Link" ToolTip="Confrence Link" runat="server" CssClass="form-control"></asp:TextBox></div>
                                          </div>
                                         
                                          <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Message</h4></div>
                                          </div>
                                                  
                                                  
                                                            </div>
                                                            <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtreply" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px" ></asp:TextBox>
                                                          </div></div>
                                                           
  </ContentTemplate>
    </asp:UpdatePanel> 
    
     <div class="user-info media box" style="background-color:#fff;">
                                                   
                                                            <div class="row">&nbsp;</div>
                                                    <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                             <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server"/>
                                                        </div>
                                                    </div>
                                                    </div>
                                               
                                                             
                                
                                           
        </section>       
    </div>
    </form>

</asp:Content>
