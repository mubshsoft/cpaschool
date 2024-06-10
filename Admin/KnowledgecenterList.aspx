<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="KnowledgecenterList.aspx.cs" Inherits="Admin_KnowledgecenterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Knowledge Center" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Course</li>--%>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
                        
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
        
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
          <span class="pull-right"><asp:Button ID="add" runat="server" Text="Add Knowledge Center" CssClass="btn btn-large btn-success" PostBackUrl="~/Admin/Knowledgecenter.aspx" /></span>
          </div></div>
                                                              
     <div class="row">&nbsp;</div>                                              
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">


                                                        <asp:GridView ID="gvKnowledgecenterList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="ID" OnRowDataBound="gvKnowledgecenterList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20" OnRowDeleting="gvKnowledgecenterList_RowDeleting"
                                                            onpageindexchanging="gvKnowledgecenterList_PageIndexChanging" >
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                              
                                                                <asp:TemplateField HeaderText="Caption">
                                                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCaption" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "Caption")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                   
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Subject Type">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSubjectType" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "SubjectType")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                  
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblKnowledgeCenterDescription" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "KnowledgeCenterDescription")%>'></asp:Label>
                                                                        &nbsp;
                                                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                                                        <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' />
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                             
                                                                
                                                                <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="150px" />
                                                                    <ItemTemplate> 
                                                                        <asp:LinkButton ID="linkEdit" runat="server" CausesValidation="false" Font-Underline="false" Text="Edit"> 
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                   <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="75px" />
                                                                    <ItemTemplate>
                                                                       
                                                                        <asp:LinkButton ID="linkDelete" runat="server" CausesValidation="false" CommandName="Delete"  OnClientClick="return confirm('Are you sure you want to delete ?');"
                                                                            Font-Underline="false" > 
                                                                        Delete</asp:LinkButton>
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
    </form>

</asp:Content>

