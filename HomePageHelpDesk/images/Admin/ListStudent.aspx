<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ListStudent.aspx.vb" Inherits="Admin_ListStudent" Title="List of students" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of students</title>--%>

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
    <h1 class="heading-color">List of Students</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of Students</li>
		</ul>
	</div>
    </section>
  
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
    

    <section class="container main m-tb">
    
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row">
    <div class="col-lg-11 col-md-11 col-sm-12 col-xs-12"><asp:TextBox ID="txtfirstname" runat="server" CssClass="input-block-level"></asp:TextBox></div>
    <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12"><asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-large arial" /></div>    
    </div> 
    <div class="row"> 
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row"> 
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" CssClass="input-block-level" ToolTip="Course Code">
                                                            </asp:DropDownList>
                                                            </ContentTemplate>
                                                         </asp:UpdatePanel></div>
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                          <ContentTemplate >
                                                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" CssClass="input-block-level" ToolTip="Year">
                                                            </asp:DropDownList>
                                                            </ContentTemplate>
                                                         </asp:UpdatePanel></div>
     </div> 
     <div class="row"> 
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                          <ContentTemplate >
                                                            <asp:DropDownList ID="ddlApproved" runat="server" AutoPostBack="true" CssClass="input-block-level" ToolTip="Status">
                                                             <asp:ListItem Text="SELECT"></asp:ListItem>
                                                            <asp:ListItem Text="Approved" Value="1" ></asp:ListItem>
                                                            <asp:ListItem Text="Not Approved" Value="0" ></asp:ListItem>
                                                            </asp:DropDownList>
                                                            </ContentTemplate>
                                                         </asp:UpdatePanel></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
    </div> 
    <div class="row">&nbsp;</div> 
    <div class="row"> 
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnback" Text="Back" CssClass="btn btn-warning btn-large arial" runat="server" 
                                                                /></div>
    </div> 
    </div>    
    <div class="user-info media box" style="background-color:#fff;">                                             
     <div class="row"> 
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">                                           
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                          <ContentTemplate >
                                                <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="stAid" CssClass="table"
                                                    runat="server" AllowPaging="True" OnPageIndexChanging="GrdStudent_PageIndexChanging">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hd1" Value='<%# Eval("Approve") %>' runat="server" />
                                                                <asp:Label ID="lbl" Text='' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Application ID" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstAid" Text='<%# Eval("stAid") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentFirstName" Text='<%# Eval("FirstName") %>' runat="server"
                                                                    ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentLastName" Text='<%# Eval("LastName") %>' runat="server"
                                                                   ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseCode") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Remark" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblremark" Text='<%# Eval("feeremark") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a id="a3" href="ApproveStudent.aspx?id=<%#Container.DataItem("aid")%>&staid=<%#Container.DataItem("stAid")%>&Cid=<%#Container.DataItem("courseID")%>">
                                                                    Details</a>
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


</asp:Content>
