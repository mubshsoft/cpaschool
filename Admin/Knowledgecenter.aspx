<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="Knowledgecenter.aspx.cs" Inherits="Admin_Knowledgecenter" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Course Details</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Knowledge Center" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Course</li>--%>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        
                        
                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                        
    <section class="container main m-tb">

    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    
        <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlCourse" AutoPostBack="true"  runat="server" ToolTip="Course Code" CssClass="form-control"  />
      </div>
      </div>

      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Subject Type :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" CssClass="form-control">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">Magazine and Article</asp:ListItem>
              <asp:ListItem Value="2">Video Pods</asp:ListItem>
               <asp:ListItem Value="3">Audio Pods</asp:ListItem>
          </asp:DropDownList>
          &nbsp;&nbsp;
          <asp:DropDownList ID="ddlSourceType" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlSourceType_SelectedIndexChanged" Visible="false">
              <asp:ListItem Value="0">--Select Source--</asp:ListItem>
              <asp:ListItem Value="1">Online</asp:ListItem>
              <asp:ListItem Value="2">Offline</asp:ListItem>
              
          </asp:DropDownList>
      </div>
      <div class="row" id="dvURL" runat="server" visible="false"   >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">URL :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtURL" runat="server" CssClass="form-control" placeholder="https://www.youtube.com/" TabIndex="3"></asp:TextBox></div>
      </div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Caption :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtCaption" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox></div>
      </div>
     
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Description</h4></div></div>
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><FCKeditorV2:FCKeditor ID="Editor1" runat="server" BasePath="~/fckeditor/" Height="300px" Width="100%" ></FCKeditorV2:FCKeditor></div></div>
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">File Upload :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:FileUpload ID="FileUpload1" runat="server" /></div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Visible on Page :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:CheckBox ID="chkchecked" runat="server" /></div>
      </div>
      
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click"/>
                                                                </div></div>

      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:HiddenField ID="hdnkcid" runat="server" />
          <asp:HiddenField ID="hdnFilename" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
                                                   </div>
                                                   </section>
                                       <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                
   
    
    </div>
    </form>

</asp:Content>
