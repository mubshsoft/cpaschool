<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="AddBatch.aspx.vb" Inherits="Admin_AddBatch" Title="Add Batch" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Batch</title>--%>

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
    <asp:Label ID="lblCaption" Visible="false" runat="server" />
    <h1 class="heading-color">Add New Batch</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add New Batch</li>
		</ul>
	</div>
    </section>
   
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div onkeypress="javascript:HideMessage()">

   
  
    <section class="container main m-tb">
                <div class="row">
                 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                         <div class="user-info media box" style="background-color:#fff;">  
                          <div class="row">
                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                          <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                           </div>
                           </div> 
                           <div class="row">
                           <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><asp:DropDownList ID="ddlCourse" AutoPostBack="true" ToolTip="Course Title"  runat="server" CssClass="form-control" /></div>
                           <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><asp:TextBox ID="txtBatchCode" runat="server" Placeholder="Batch Code" ToolTip="Batch Code" CssClass="form-control" MaxLength="48"></asp:TextBox></div>
                           </div>
                           <div class="row">&nbsp;</div>
                           <div class="row">
                           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                                <asp:button ID="btnSave" Text="Save" CssClass="btn btn-success btn-large" runat="server"/>
                                <asp:button ID="btnClose" Text="Close" CssClass="btn btn-warning btn-large" runat="server"/>
                                </div>
                                </div>
                                </div>
                                                 </ContentTemplate>
                                             </asp:UpdatePanel>
                                             
                                            </div>
                                            
                                            </section>
     </div>
    </form>


</asp:Content>

