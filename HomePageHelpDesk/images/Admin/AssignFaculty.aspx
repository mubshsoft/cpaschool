<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AssignFaculty.aspx.vb" Inherits="Admin_AssignFaculty" Title="Assign Faculty" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
     <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Assign Faculty</title>--%>
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
                     
                     
                     function openPopup(strOpen)
                         {
                          open(strOpen, "Info", "status=1, width=700, height=800, top=20, left=300,scrollbars=yes");
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
    <h1 class="heading-color">Assign Faculty</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Assign Faculty</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">
        
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
     </div>
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox id="txtName" runat="server" ToolTip="Faculty Name" CssClass="input-block-level"></asp:TextBox></div>
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="dllCourse" runat="server" ToolTip="Course" CssClass="input-block-level" AutoPostBack="true" ></asp:DropDownList></div>
     </div>
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="dllSemester" runat="server" ToolTip="Semester" CssClass="input-block-level" AutoPostBack="true" ></asp:DropDownList></div>
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="dllModule" runat="server" ToolTip="Module" CssClass="input-block-level" AutoPostBack="true"></asp:DropDownList></div>
     </div>
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="dllPaper" runat="server" ToolTip="Paper" CssClass="input-block-level" AutoPostBack="true"></asp:DropDownList></div>
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
     </div>
     <div class="row">&nbsp;</div>
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" />
     <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-large btn-warning" />
     </div>
     </div>
     </div>
     <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Course Already Associated With :</h4></div>
     </div>
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <asp:GridView ID="GrdFacultySub" AutoGenerateColumns="False" DataKeyNames="Fid" CssClass="table"
                                                    runat="server" AllowPaging="True" >
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
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("FacId") %>' OnClientClick="return confirm('Are you sure you want to delete?')" >Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                </div>
                                                </div>
                                                </div>
     </section>                                                  
                                                    
                                                  
                                                    
                                                  
                                                    
                                                   
                                       
                                         
                                           
                                    
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                
                           
                      
    </div>
    </form>
</asp:Content>
