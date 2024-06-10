<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ListFaculty.aspx.vb" Inherits="Admin_ListFaculty" Title="List of faculty" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of faculty</title>--%>
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
    <h1 class="heading-color">List of Faculty</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of Faculty</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                           
        
  
    <section class="container main m-tb">                
                                        
                                                <%-- <table style="width: 50%">
                                                    <tr>
                                                        <td colspan="2">
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>--%>
                              <div class="user-info media box" style="background-color:#fff;">                 
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:button ID="btnAddFaculty" runat="server" Text="Add Faculty" CssClass="btn btn-large btn-success" /></span></div>
                            </div>
                           </div>
                           <div class="user-info media box" style="background-color:#fff;">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                           <asp:GridView ID="GrdFaculty" AutoGenerateColumns="False" DataKeyNames="Fid" CssClass="table"
                                                    runat="server" AllowPaging="True">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20px"
                                                            ItemStyle-Width="20px">
                                                            <ItemTemplate>
                                                                <%#Eval("ROWID")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentFirstName" Text='<%# Eval("FirstName") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentLastName" Text='<%# Eval("LastName") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblStudentFullName" Text='<%# Eval("FullName") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>--%>
                                                                    
                                                                    <asp:LinkButton ID="lnkFacName" runat="server"  Text='<%# Eval("FullName") %>' CommandName="List" CommandArgument='<%#Container.DataItem("Fid")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email Id" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a id="a3" href="FacultyRegistration.aspx?facultyid=<%#Container.DataItem("Fid")%>">
                                                                    Details</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField>
                                                            <ItemTemplate>
                                                                   <a id="a4" href="AssignFaculty.aspx?facultyid=<%#Container.DataItem("Fid")%>">
                                                                    Assign Faculty</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div></div>
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4><asp:label ID="lblCap" runat="server" Text="" Visible="false"  Font-Bold="true">  </asp:label></h4></div>
                            </div>
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                               <asp:GridView ID="GrdFacultySub" AutoGenerateColumns="False" DataKeyNames="Fid" CssClass="table" 
                                                    runat="server" AllowPaging="True" Visible="false" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="FacId" ItemStyle-HorizontalAlign="Left" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFacId" Text='<%# Eval("FacId") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourse" Text='<%# Eval("CourseTitle") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                                                                            
                                                        <asp:TemplateField HeaderText="Paper" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaper" Text='<%# Eval("PaperTitle") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      
                                                    </Columns>
                                                </asp:GridView>
                                            
                              </div></div>
                              </div>
                              </section>
                              </div>
    </form>
</asp:Content>
