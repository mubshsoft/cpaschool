<%@ Page Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="ApplyAnotherCourse.aspx.vb" Inherits="Admin_ApplyAnotherCourse" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
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
    <h1 class="heading-color">Register for another course</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Register for another course</li>
		</ul>
	</div>
    </section>
 <section class="container main m-tb">
     
    <form id="form1" runat="server" onkeypress="javascript:HideMessage();" onkeydown="javascript:HideMessage();">
    <div >
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <fieldset> 
                     <legend style="font-family: Verdana; font-size: 15px; font-weight: bold">
                         <b>Search the Student by Firstname, Lastname or Email </b>

                     </legend>
                </fieldset> 
            </div>
        </div>
         <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
        <div class="row">
    <div class="col-lg-11 col-md-11 col-sm-12 col-xs-12"><asp:TextBox ID="txtfirstname" runat="server" placeHolder="Type Name or Email" CssClass="form-control"></asp:TextBox></div>
    <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12"><asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-large"  /></div>
    </div>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        &nbsp;
    </div>
    </div> 
            <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:Label ID="lblSearchWith" EnableViewState="false" runat="server" Text="" ForeColor="green" Visible="true"></asp:Label><br />
        <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="stid" runat="server" AllowPaging="True" CssClass="table" >
                                                                                                            <HeaderStyle CssClass="form_head" />
                                                                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
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
                                                                                                                  <%--<asp:TemplateField HeaderText="bid" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server" ></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>--%>
                                                                                                                <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblcoursecode" Text='<%# Eval("coursecode") %>' runat="server" ></asp:Label>
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
                                                                                                               <asp:TemplateField  HeaderText="Apply" ItemStyle-HorizontalAlign="center">
                                                                                                                     <ItemTemplate>
                                                                           
                                                                                                                              <a id="a1" href="ApplyCourse.aspx?stid=<%#Container.DataItem("stid")%>&email=<%#Container.DataItem("email")%>" class="btn btn-primary">
                                                                                                                          Apply Another Course</a>
                                                                                                                      </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                          
                                                                                                              
                                                                                                            </Columns>
                                                                                                        </asp:GridView>
        </div> 
                </div>
  
    
                                            </div>
    </form>
    
</section>
</asp:Content>

