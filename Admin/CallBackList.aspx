<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CallBackList.aspx.cs" Inherits="Admin_CallBackList" %>

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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Call Back List" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Course</li>--%>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
  
    <div>
      
       
    <section class="container main m-tb">
     
      <div class="user-info media box" style="background-color:#fff;">                                              
     <div class="row">
         <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12">
             <asp:TextBox ID="txtSearch"  ToolTip="Enter Search Contents" PlaceHolder="Search" CssClass="form-control" runat="server"  />
              
         </div>
         <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
             <asp:Button ID="btnSearch" runat="server" Text="Save" CssClass="btn btn-success btn-large arial" OnClick="btnSearch_Click"/>
         </div>
     </div>                   
     </div>         
     <div class="user-info media box" style="background-color:#fff;">                                      
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">


                                                        <asp:GridView ID="gvCallbackList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="ID" OnRowDataBound="gvCallbackList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20"
                                                            onpageindexchanging="gvCallbackList_PageIndexChanging" >
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                              
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>' > 
                                                                        </asp:Label>
                                                                       
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Email">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="linkemail"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email")%>' > 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mobile Number">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMobile"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Mobile")%>' > 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                               
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div></div>
         <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                               
                                            <asp:Label ID="lblMessage" runat="server" Text="No Records Found !" Visible="false" ForeColor="Red" ></asp:Label>
      </div></div>

     </div>
      </section>
                                        <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    
                                
    </div>
       


    
    </form>

</asp:Content>

