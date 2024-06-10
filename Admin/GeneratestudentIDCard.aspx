<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="GeneratestudentIDCard.aspx.cs" Inherits="Admin_GeneratestudentIDCard" %>

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

    <script language="javascript" type="text/javascript">
  
function openPopup(strOpen)
    {
        open(strOpen, "Info", "status=1, width=700, height=430,resizable=yes,scrollbars=yes, top=200, left=200");
    }
    
 
   
        
    </script>

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
     <script language="javascript" type="text/javascript" src="../datetimepicker.js">
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Generate ID Card - Student" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Generate ID Card - Student</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div onkeypress="HideMessage()">
      
       

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;"> 
    <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend>Generate ID Card - Student</legend></div></div>
    <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Red" Text=""></asp:Label></div></div>
    
        <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlcoursefillter" runat="server" AutoPostBack="True" placeholder="Course" CssClass="form-control" OnSelectedIndexChanged="ddlcoursefillter_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                            </div>
                           </div> 
         <div class="row" >
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                 <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                     <ContentTemplate>--%>
                                <asp:DropDownList ID="ddlbatch" runat="server" ToolTip="Batch Code" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlbatch_SelectedIndexChanged"></asp:DropDownList>
                                       <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                            </div>
            </div>
    
       
     </div>                            
         <div class="row" >&nbsp;</div>                                            
     
     <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" OnClick="btnBack_Click" />
     </div></div>
     <div class="user-info media box" style="background-color:#fff;"> 
 <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto"> 
                                                        <asp:GridView ID="grdStudent" runat="server" AutoGenerateColumns="False" PageSize="20" CssClass="table"
                                                            AllowPaging="true" DataKeyNames="stid" 
                                                            OnPageIndexChanging="grdStudent_PageIndexChanging" OnRowDataBound="grdStudent_RowDataBound" OnRowCommand="grdStudent_RowCommand">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (grdStudent.PageSize * grdStudent.PageIndex) + Container.DisplayIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email ID" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblemailid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "emailid")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DOB" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldob" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "dob")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Exam Code" ItemStyle-HorizontalAlign="Left">
                                                                  
                                                                    <ItemTemplate>
                                                                    <a href='StudentIDCard.aspx?stid=<%#Eval("stid") %>&bid=<%#Eval("bid") %>' target="_blank" >Generate ID Card</a>
                                                                        <%--<asp:LinkButton ID="lnb_NormalStudent" runat="server" Text='Generate ID Card' CommandName="Student" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>--%>
                                                                       
                                                                        <asp:HiddenField ID="hdncourseid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "courseid")%>' />
                                                                        <asp:HiddenField ID="hdnbid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "bid")%>' />
                                                                        <asp:HiddenField ID="hdnStid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "stid")%>' />
                                                                        <asp:HiddenField ID="hdnicardStatus" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "icard")%>' />
                                                                       
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                             </Columns>
                                                           
                                                        </asp:GridView>
 </div></div>
  
  <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                        
                                                        <asp:HiddenField ID="hdnSectionId" runat="server" />
                                                   
                                        
                                </div>
                            </div>
                            </div>
                            </section>
                            

    </form>


</asp:Content>

