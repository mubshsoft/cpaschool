<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ListQuery.aspx.vb" Inherits="Admin_ListQuery" Title="List Query" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List Query</title>--%>
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
               function openPopup(id)
                     {
                    open("../Student/QueryDetails.aspx?lstquerydetails=" + id, "Info", "status=1, width=510, height=650, top=20, left=300");
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
    <h1 class="heading-color">List Query</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List Query</li>
		</ul>
	</div>
    </section>
 
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            
                       
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course" CssClass="input-block-level" AutoPostBack="true"></asp:DropDownList></div></div>
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlBatch" runat="server" ToolTip="Batch" CssClass="input-block-level" AutoPostBack="true"></asp:DropDownList></div></div>
     </div>
     <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                                 <asp:GridView ID="GrdQuery" AutoGenerateColumns="false" runat="server" DataKeyNames="QueryId"
                                                                Width="100%" AllowPaging="false" CssClass="table">
                                                                <HeaderStyle CssClass="form_head" />
                                                                <RowStyle CssClass="grid-row-Overtime" />
                                                                <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                <Columns>
                                                                 <asp:TemplateField HeaderText="QueryId" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblfid" Text='<%# Eval("fId") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="QueryId" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQueryId" Text='<%# Eval("QueryId") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStName" Text='<%# Eval("studentName") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Login Id" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmailId" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   
                                                                    <asp:TemplateField HeaderText="Query For" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFacultyName" Text='<%# Eval("FacultyName") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subject" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server" CssClass="left_padding"></asp:LinkButton>
                                                                            <%-- <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                
                                                                    <asp:TemplateField HeaderText="Query Posted Date" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQueryDate" Text='<%# Eval("QueryDate") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" Text='<%#ReplaceStatus(Eval("Status"))%>' runat="server"
                                                                                CssClass="left_padding"></asp:Label>
                                                                            <%--<asp:LinkButton  ID="lblStatus" Text='<%#ReplaceStatus(Eval("Status"))%>' runat="server" ></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Query Replied Date" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblReplyDate" Text='<%# Eval("ReplyDate") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                       <asp:TemplateField HeaderText="Query" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQuery" Text='<%# Eval("Query") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblStatus1" Text='<%#ReplaceStatus(Eval("Status"))%>' runat="server"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                       </div></div>
                                                       </div>
                                                       </section>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                           
                        
                    
    </div>
    </form>

</asp:Content>
