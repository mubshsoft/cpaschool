<%@ Page Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="EditprofileForUnassignedStudent.aspx.vb" Inherits="Admin_EditprofileForUnassignedStudent" %>

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
    <h1 class="heading-color">List of students</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of students</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>



    <section class="container main m-tb">
    
    <div class="user-info media box" style="background-color:#fff;"> 
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                                              <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                  <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" CssClass="form-control" ToolTip="Course Code" ></asp:DropDownList>
                                                  
                                                  </ContentTemplate>
                                                  </asp:UpdatePanel>
    </div><div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

    </div></div>
        <div class="row">
    <div class="col-lg-11 col-md-11 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                          <ContentTemplate ><asp:TextBox ID="txtfirstname" runat="server" placeholder="Enter search contents" CssClass="form-control"></asp:TextBox>
                                                             </ContentTemplate> </asp:UpdatePanel>  </div>
    <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12" ><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                          <ContentTemplate ><asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-large"  />
                                                              </ContentTemplate> 
                                                              </asp:UpdatePanel> 
                                                              </div>
    </div>
</div>
<div class="row">&nbsp;</div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
<asp:button ID="btnback" Text="Back" CssClass="btn btn-warning btn-large" runat="server" />
    </div></div>
    
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            
                                       
  <div class="user-info media box" style="background-color:#fff;">                                       
                     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">                   
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                          <ContentTemplate>
                                                 <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="stid" runat="server" AllowPaging="True" OnPageIndexChanging="grdView_PageIndexChanging" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" PageSize="10">
                                                                                                            <HeaderStyle CssClass="form_head" />
                                                                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                                                                            <Columns>
                                                                                                         <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                    <%# (GrdStudent.PageSize * GrdStudent.PageIndex) + Container.DisplayIndex + 1 %>
                                                                                                                   </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                                 <asp:TemplateField HeaderText="courseid" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblcourseid" Text='<%# Eval("courseid") %>' runat="server" ></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                  
                                                                                                                 <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblStudentFirstName" Text='<%# Eval("FirstName") %>' runat="server" ></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                  <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblStudentLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                             <asp:TemplateField  HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server"></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemTemplate>
                                                                                                                        <%--<a id="a3" href="EditStudentProfile.aspx?id=<%#Container.DataItem("stid")%>&cid=<%#Container.DataItem("Courseid")%>">--%>
                                                                                                                        <a id="a3" href="EditStudentProfile.aspx?id=<%#Container.DataItem("stid")%>&cid=<%#Container.DataItem("courseid") %>&bid=0">
                                                                                                                           Details</a>
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
