<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="EditReplies.aspx.vb" Inherits="EditReplies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    
    <script type="text/javascript" src="stmenu.js"></script>
     <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Discussion Forum</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        
        <%If Session("role") = "Admin" Then%>
        <li><a href="Admin/Adminlogin.aspx">Admin Panel</a></li>
        <% ElseIf Session("role") = "Faculty" Then %>
         <li><a href="faculty/Facultypanel.aspx">Faculty Panel</a></li>
         <% ElseIf Session("role") = "Student" Then%>
         <li><a href="Student/StudentPanel.aspx">Admin Panel</a></li>
         <%End If %>
        <li>List of Topics</li>
         
		</ul>
	</div>
    </section>  

    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
     
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                       
                                 <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12"><b>Topic :-&nbsp;&nbsp;
                                        <asp:Label ID="lblmainTopic" runat="server" ForeColor="#666666" Text="">
                                        </asp:Label></b>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><asp:Button ID="imgBack" runat="server" cssclass="btn btn-warning" text="Back to Topics" /></div>
                                        </div>
                                    <div class="row">&nbsp;</div>
                                          
                                                     
              <div class="row" >                                           
              <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                        
                                            <div class="user-info media box" style="background-color:#fff;">       
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                            <asp:GridView ID="grdTopic" runat="server" AutoGenerateColumns="False" CssClass="table"
                AllowPaging="false" CellPadding="1" Width="100%" ShowHeader="false">
                <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="15%" ItemStyle-HorizontalAlign=Center >
                        <ItemTemplate>
                            <b>
                                <asp:Image ID="imgIcon11" ImageUrl="Images/icon1.gif" runat="server" Height="20px"
                                    Visible="false" />
                                <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("email") %>'></asp:Label></b>
                            <br />
                            <asp:Image ID="imgIcon1" ImageUrl="Images/profile.jpg" runat="server" Height="20px" />
                            <br />
                            <asp:Label ID="lblDateOfPosting" runat="server" Text='<%# Bind("dateofposting","{0:dd-MM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                            <asp:Image ID="imgIcon12" ImageUrl="Images/icon1.gif" runat="server" Height="10px" />
                            <br />
                            <br />
                           
                                <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "subjecttext"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%>
                            
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="subject id" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubjectId" runat="server" Text='<%# Bind("subjectid") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubjectID" runat="server" Text='<%# Bind("subjectid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="subsubjectid" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSubSubjectID" runat="server" Text='<%# Bind("subsubjectid") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="txtSubSubjectID" runat="server" Text='<%# Bind("subsubjectid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <a id="a3" class="btn btn-success" href="UpdateSubSubject.aspx?tid=<%#Container.DataItem("subjectID")%>&sid=<%#Container.DataItem("subsubjectid")%>&email=<%# Container.DataItem("email") %>">
                           Edit</a>
                       </ItemTemplate>
                     </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                          <asp:Button ID="lnkDelete" runat="server" CommandName="Delete" CssClass="btn btn-warning" CommandArgument='<%# Eval("subsubjectid") %>' OnClientClick ="return confirm('Are you sure you want to delete?')" text="Delete" />
                       </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </ContentTemplate>
    </asp:UpdatePanel>
    </div>
         </div>
         </div>
         </section>  
         </div>                                    
    </form>
</asp:content>
