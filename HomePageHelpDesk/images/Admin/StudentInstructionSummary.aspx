<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="StudentInstructionSummary.aspx.cs" Inherits="Admin_StudentInstructionSummary" ValidateRequest="false" Title="Instruction Summary"  %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Instruction Summary</title>--%>

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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
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
    <h1 class="heading-color">Instruction Summary</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Instruction Summary</li>
		</ul>
	</div>
    </section>
  
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
   

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div></div>                                                    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <FTB:FreeTextBox ID="txtInstruction" runat="server" Width="100%">
                                                            </FTB:FreeTextBox>
                                                            </div></div>
                                                            <div class="row" >&nbsp;</div>
   <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:button ID="btnClose" Text="Back" CssClass="btn btn-large btn-warning" runat="server" onclick="btnClose_Click"/>
<asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" onclick="btnSave_Click"/>
<asp:button ID="btnSaveContinue" Text="Save and Continue" CssClass="btn btn-large btn-success" runat="server" onclick="btnSaveContinue_Click"/>
</div></div>
                                                  </section>
    </div>
    
   
    </form>

</asp:Content>

