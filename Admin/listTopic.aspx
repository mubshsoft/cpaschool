<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="listTopic.aspx.vb" Inherits="Admin_listTopic" Title="List Topic" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List Topic</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>

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
    <h1 class="heading-color">List of topics</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of topics</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate >
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
      <div class="well">
<div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course" AutoPostBack="true" CssClass="form-control"></asp:DropDownList></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlBatch" runat="server" ToolTip="Batch" AutoPostBack="true" CssClass="form-control"></asp:DropDownList></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlsem" runat="server" ToolTip="Semester" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"></div>
    </div> 
    </div>                                        
     </ContentTemplate>
    </asp:UpdatePanel>
     </div></div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:Button ID="ImgAddTopic" runat="server" Text="Post New Topic" CssClass="btn btn-large btn-success" /></span></div>
    </div>
                                            
                                               
    
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >                                       
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                          <ContentTemplate >
                                                <asp:GridView ID="GrdTopic" AutoGenerateColumns="False" DataKeyNames="subjectid" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                     runat="server" AllowPaging="True" OnPageIndexChanging="grdView_PageIndexChanging"
                                                    OnRowDataBound="Grdtopic_RowDataBound" Width="100%"  OnRowDeleting="GrdTopic_RowDeleting" PageSize="10">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hd12" Value='<%# Eval("Active") %>' runat="server" />
                                                                <asp:Label ID="lbl12" Text='' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hd1" Value='<%# Eval("SubjectId") %>' runat="server" />
                                                                <asp:Label ID="lbl" Text='' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField  HeaderText="Topic" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="300px" >
                                                            <ItemTemplate>
                                                                <a id="a1" href="../allTopic.aspx?id=<%#Eval("SubjectId")%>">
                                                                    <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "title"), "dq$", """"), "com$", ","), "q$", "'"), "amp$", "&")%>
                                                                </a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Posted by" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserName" Text='<%# Eval("Createdby") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>
                                                 <%--       <asp:TemplateField HeaderText="Topic" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTopic" Text='<%# Eval("title") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Total Replies">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblTotalReply" Text='<%# Eval("TPost") %>' runat="server" CssClass="left_padding"></asp:Label>--%>
                                                                <asp:Label ID="lblTotalReply" Text='<%# Eval("TPost") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Total Read" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalRead" Text='<%# Eval("totalread") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Post"   HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastPost" Text='<%# Eval("LastPost") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                          
                                                        </asp:TemplateField>
                                                
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a id="a3" href="AddTopic.aspx?id=<%#Container.DataItem("subjectID")%>&e=1">Edit 
                                                                Topic</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a id="ancEditReplies" href="../EditReplies.aspx?id=<%#Container.DataItem("subjectID")%>">
                                                                Edit Replies</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDeleteTopic" runat="server" CommandName="Delete" CommandArgument='<%# Eval("subjectId") %>'  OnClientClick="return confirm('Are you sure you want to delete?')">Delete 
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                    </Columns>
                                                      <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                                 </ContentTemplate>
    </asp:UpdatePanel>
                                            
    </div>
    </div>
    </div>
    </div></div>
    </section>
    </div>
    </form>
</asp:Content>
