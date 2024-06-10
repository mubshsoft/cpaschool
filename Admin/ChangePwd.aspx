<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Admin_ChangePwd" Title="Change Password" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
<title>Change Password</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<script type="text/javascript" src="../stmenu.js"></script>  
<style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000;font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828;  height:15px;}
    .style14
    {
        width: 140px;
    }
    .style15
    {
        color: #4b4b4b;
        font-size: 11px;
        font-family: tahoma;
        width: 140px;
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
    <h1 class="heading-color">Change Password</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Change Password</li>
		</ul>
	</div>
    </section>

<form id="form1" runat="server">
<div>


 <section class="container main m-tb">
   
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server" onclick="btnback_Click" /></span></div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" ToolTip="Course" AutoPostBack="True" onselectedindexchanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <asp:DropDownList ID="ddlbatch" runat="server" CssClass="form-control" ToolTip="Batch Code" AutoPostBack="True" onselectedindexchanged="ddlbatch_SelectedIndexChanged" meta:resourcekey="ddlbatchResource1"></asp:DropDownList></div>
    </div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
<asp:GridView ID="GridView1" runat="server" align="center" AutoGenerateColumns="False" CssClass="table"  Width="100%" onrowcancelingedit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" >
   <HeaderStyle CssClass="form_head" />
    <RowStyle CssClass="grid-row-Overtime" />
    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
    <%--<HeaderStyle CssClass="grid-header-Overtime" />--%>
   
   
    <Columns>
<asp:TemplateField HeaderText="First Name" 
    meta:resourcekey="TemplateFieldResource1">
    <ItemTemplate>
    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' 
            meta:resourcekey="lblFirstNameResource1"></asp:Label>
        
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Text='<%# Bind("FirstName") %>' 
            meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
      <asp:HiddenField ID="hdnemail" runat="server" Value='<%# Eval("StudentEmail") %>' />
        <asp:HiddenField ID="hdnstid" runat="server" Value='<%# Eval("stid") %>' />
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Last Name" 
    meta:resourcekey="TemplateFieldResource2">
    <ItemTemplate>
    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' 
            meta:resourcekey="lblLastNameResource1"></asp:Label>
       
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Text='<%# Bind("LastName") %>' 
            meta:resourcekey="txtLastNameResource1"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Password" 
    meta:resourcekey="TemplateFieldResource3">
    <ItemTemplate>
    <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>' 
            meta:resourcekey="lblPasswordResource1"></asp:Label>
       
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" Text='<%# Bind("Password") %>' 
            meta:resourcekey="txtPasswordResource1"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="E-Mail">
 <ItemTemplate>
    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("StudentEmail") %>' 
            meta:resourcekey="lblEMail"></asp:Label>
        
    </ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource4">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
            CommandName="Edit" Text="Edit" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            CommandName="Update" Text="Update" meta:resourcekey="LinkButton1Resource2"></asp:LinkButton>
        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
            CommandName="Cancel" Text="Cancel" meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
    </EditItemTemplate>
</asp:TemplateField>
</Columns>
   
                <AlternatingRowStyle 
                    BorderStyle="None" />
            </asp:GridView>
    </div>
    </div>
    </div>
 </section>


 </div>

</form>

</asp:Content>
