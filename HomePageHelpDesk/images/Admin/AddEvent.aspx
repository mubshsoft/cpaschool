<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AddEvent.aspx.vb" Inherits="Admin_AddEvent" Title="List of Event" %>


<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of Event</title>--%>
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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Add Event</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Event</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">

    

    <section class="container main m-tb">
     
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <div class="user-info media box" style="background-color:#fff;">  
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                                 
                                                             
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       
        <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtDate" runat="server" PlaceHolder="Event Date" ToolTip="Event Date" CssClass="input-block-level" ></asp:TextBox></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtTitle" runat="server" PlaceHolder="Event Title" ToolTip="Event Title" CssClass="input-block-level"></asp:TextBox></div>
    </div>                                            
                                                                                                       
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesc"  MaxLength="250"  runat="server" PlaceHolder="Event description (Max Length:250 Characters)" ToolTip="Event description" TextMode="MultiLine" Rows="4" CssClass="input-block-level"></asp:TextBox></div>
    </div>
    <div class="row" >&nbsp;</div>                                                
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>
                        <asp:button ID="btnCancel" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server"/>
                        </div>
                        </div>
          </div>                                                 
       </div></div>
        </section>
    </div>
    </form>
</asp:Content>