<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="ScreeningAddSectionQue.aspx.cs" Inherits="ScreeningAddSectionQue" Title="Section Detail" %>


<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Section Detail</title>--%>
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

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px;}

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
    <h1 class="heading-color">Section Detail</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Section Detail</li>
		</ul>
	</div>
    </section>

   
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
  
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
      <div class="row">
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
       </div>
       <div class="row">
       <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtmax_sec" runat="server" CssClass="input-block-level" ToolTip="Maximum Question" value='0' onfocus="if(this.value=='0')this.value=''" onblur="if(this.value=='')this.value='0'"></asp:TextBox>
                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmax_sec"  Display="Dynamic"
                                                                ErrorMessage="Please enter numeric values " ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>                                                     
                                                        </div>
        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtmaxattempt" runat="server" CssClass="input-block-level" ToolTip="Compulsory Question" 
                                                                onblur="if(this.value=='')this.value='0'" 
                                                                onfocus="if(this.value=='0')this.value=''" value="0"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" 
                                                                ControlToValidate="txtmaxattempt" 
                                                                ErrorMessage="Please enter numeric values " 
                                                                ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                                        </div>
        </div>
                                                  
        
       <div class="row">
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
       <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" onclick="btnBack_Click" />
       <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" onclick="btnSave_Click"/>
       <asp:Button ID="btnSaveContinue" Text="Save & Continue" CssClass="btn btn-large btn-success" runat="server" onclick="btnSaveContinue_Click"/>
                   <%--<a href="javascript:history.go(-1)"><img src="../Images/back_button.jpg" border="0" ></a>--%>
                   </div>
                   </div>
                                                             
      <div class="row">
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdnScrId" runat="server" /> <asp:HiddenField ID="hdnCategoryId" runat="server" /></div>
       </div>
       </div>
       </section>
                      
    </div>
    
   
    </form>
</asp:Content>

