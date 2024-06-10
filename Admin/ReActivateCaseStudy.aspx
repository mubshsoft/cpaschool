<%@ Page Title="" Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="ReActivateCaseStudy.aspx.vb" Inherits="Admin_ReActivateCaseStudy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
    <h1 class="heading-color">Re-Activate Case Study</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li><a href="CaseStudyPanel.aspx">Case Study</a></li>
        <li class="active">Re-Activate Case Study</li>
		</ul>
	</div>
    </section>
    

    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div onkeypress="javascript:HideMessage()">

    <div class="frame">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                 <ContentTemplate>
    

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
     </div>
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
      <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" ToolTip="Course Code" CssClass="form-control"></asp:DropDownList>
      </div>
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
     <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" ToolTip="Batch Code" CssClass="form-control" ></asp:DropDownList>
      </div></div>                                
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">                    
     <asp:DropDownList ID="ddlAssignmentset" runat="server" AutoPostBack="true" ToolTip="Assignment Code" CssClass="form-control"></asp:DropDownList>
     <asp:Label ID="lblBatchCode" runat="server" Visible="false" Text="Batch Code :" ></asp:Label> 
     </div></div>
     
      <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-large btn-warning" /></div>
     </div>
     </div>
     <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                                <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="id" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="True" PageSize="5" Visible="false" >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="form_head" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (GrdStudent.PageSize * GrdStudent.PageIndex) + Container.DisplayIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="AsgnId" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Case Study Id" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAsgnId" Text='<%# Eval("CSId") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="bid" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="UserId" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserId" Text='<%# Eval("UserId") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Activate Case Study">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkActivate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' OnClientClick ="return confirm('Are you sure you want to Re-Activate Case Study ?')">Activate</asp:LinkButton>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
       </div></div>  
       </div>                                   
      </section>                                
                                    
                   
                </ContentTemplate>
                                </asp:UpdatePanel>
    </div>
    </div>
    </form>


</asp:Content>


