<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyBatchList.aspx.cs" Inherits="Admin_CaseStudyBatchList" %>

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
    <h1 class="heading-color">Case Study : List of Batch</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li><a href="CaseStudyPanel.aspx">Case Study</a></li>
        <li class="active">Case Study : List of Batch</li>
		</ul>
	</div>
    </section>
    
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
        

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
      <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
      </div>
      </div>
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"> 
     <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" ToolTip="Course" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                                    </asp:DropDownList>
     </div>
      
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="trbatch" runat="server"> 
     <asp:DropDownList ID="ddlbatch" runat="server" AutoPostBack="true" ToolTip="Batch" CssClass="form-control" onselectedindexchanged="ddlbatch_SelectedIndexChanged">
                                                            </asp:DropDownList>
     </div>
      </div>                                                     
       <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
     <asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server" onclick="btnback_Click" />
     </div>
     </div>
     </div>
     <div class="user-info media box" style="background-color:#fff;">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
     <asp:GridView ID="GrdBatch" AutoGenerateColumns="False" DataKeyNames="BatchId" Width="100%" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" PageSize="10"
                                                            runat="server" AllowPaging="True" OnPageIndexChanging="GrdBatch_PageIndexChanging"
                                                            OnSelectedIndexChanged="GrdBatch_SelectedIndexChanged">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                            <Columns>
                                                             <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                         <%# (GrdBatch.PageSize * GrdBatch.PageIndex) + Container.DisplayIndex + 1%>
                                                                        </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left" >
                                                                     <ItemTemplate>
                                                                        <a id="a1" href="AdminListCaseStudySet.aspx?batchid=<%#Eval("BatchId")%>">
                                                                            <%# Eval("BatchTitle") %>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Course Id" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCourseId" Text='<%# Eval("courseID") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    
                                            </div>
                                            </div></div>
                                            </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               
    </div>
    </form>

</asp:Content>


