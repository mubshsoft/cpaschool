<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AddNews.aspx.vb" Inherits="Admin_AddNews" Title="List of News" %>

<%--
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of News</title>--%>
 
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
    <h1 class="heading-color">Add news</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add news</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div onkeypress="HideMessage()">
        
           
    <section class="container main m-tb">             
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                  
                                        
                                            
                                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                     <div class="user-info media box" style="background-color:#fff;">
                                                  <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
                                                   <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlNewsType" runat="server" ToolTip="News Type" CssClass="input-block-level" AutoPostBack="True">
                                                        <asp:ListItem Value="Select"></asp:ListItem>
                                                        <asp:ListItem Value="General"></asp:ListItem>
                                                        <asp:ListItem Value="Course"></asp:ListItem>
                                                        <asp:ListItem Value="Batch"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div></div>
                                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="DdlCourse" runat="server" ToolTip="Course" CssClass="input-block-level" AutoPostBack="True"></asp:DropDownList>
                                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="DdlBatch" runat="server" ToolTip="Batch" CssClass="input-block-level"></asp:DropDownList></div></div>
                                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtNews" CssClass="input-block-level" MaxLength="250" placeholder="News (Max Length:250 Characters)" Rows="4" ToolTip="News" runat="server" TextMode="MultiLine"></asp:TextBox>   
                                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server"/>
                                                        </div></div>
                                                        </div>
                                                  </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </section> 
                
                
    </div>
    </form>

</asp:Content>
