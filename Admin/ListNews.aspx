<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="ListNews.aspx.vb" Inherits="Admin_ListNews" Title="List of News" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
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
    <h1 class="heading-color">List of news</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of news</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()" onclick="javascript:HideMessage()">
        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        
    <section class="container main m-tb">
     <div class="user-info media box" style="background-color:#fff;">                  
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                                 
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:Button ID="add" runat="server" Text="Add News" CssClass="btn btn-large btn-success" PostBackUrl="~/Admin/Addnews.aspx" /></span></div>
    </div>
                                                              
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red" ></asp:Label></div></div>
     
      <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">

                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                  <ContentTemplate >
                                                <asp:GridView ID="GrdNews" AutoGenerateColumns="False" DataKeyNames="NewsId" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="True" OnPageIndexChanging="GrdNews_PageIndexChanging" OnRowCommand="GrdNews_RowCommand" OnRowDeleting="GrdNews_RowDeleting">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="NewsType" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                             <ItemTemplate>
                                                              <a id="a1" href="addnews.aspx?id=<%#Eval("Newsid")%>">
                                                                 <%#Eval("NewsType")%>
                                                                   <%-- <asp:Label ID="lblNewsType" Text='<%#Eval("NewsType")%>' runat="server" CssClass="left_padding"></asp:Label>--%>
                                                               </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="News Description" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNewsDesc" Text='<%# Eval("NewsDesc") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Newsid") %>'  OnClientClick="return confirm('Are you sure you want to delete this news?');">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="News Posted On" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNewsPostdate" Text='<%# Eval("NewsDate") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                                 </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </div></div>
                                            </div>
                                            </section>
                
                
    </div>
    </form>

    </asp:Content>
