<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="ApplyAnotherCourse.aspx.vb" Inherits="Student_ApplyAnotherCourse" Title="List of Courses" %>

<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title></title>
<script type="text/javascript" src="../stmenu.js"></script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->

<section class="content-header">
          <h1>
            List of Course
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List of Course</li>
          </ol>
        </section>
    <section class="content">
     
   
    <div onkeypress="javascript:HideMessage()">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            
                                                           
                                                        </div></div>
                                                        <div class="box box-primary">
                                                        <div class="box-header"><h3 class="box-title with-border">Courses Offered by FMSF</h3></div>
                                                        <div class="box-body">
                                                             <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            <asp:GridView ID="GrdCourse" AutoGenerateColumns="false" runat="server" Width="100%"
                                                                AllowPaging="True" PageSize="10" OnPageIndexChanging="GrdCourse_PageIndexChanging" CssClass="table form_body">
                                                                <HeaderStyle CssClass="form_head" />
                                                                <Columns>
                                                                    <asp:TemplateField Visible="false" ItemStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCourseid" Text='<%# Eval("courseID") %>' runat="server" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="courseID" HeaderText="courseID" InsertVisible="False"
                                                                        ReadOnly="True" SortExpression="courseID" Visible="false" />
                                                                    <asp:BoundField DataField="CourseCode" HeaderText="Course Code" SortExpression="CourseCode"
                                                                        ItemStyle-HorizontalAlign="center" />
                                                                    <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" SortExpression="CourseTitle"
                                                                        ItemStyle-HorizontalAlign="center"  />
                                                                    <asp:BoundField DataField="cStartDate" HeaderText="Start Date" SortExpression="cStartDate"
                                                                        ItemStyle-HorizontalAlign="center" ItemStyle-CssClass="left_padding"  Visible="false"/>
                                                                    <asp:BoundField DataField="cEndDate" HeaderText="End Date" SortExpression="cEndDate"
                                                                        ItemStyle-HorizontalAlign="center" ItemStyle-CssClass="left_padding" Visible="false"/>
                                                                   <asp:TemplateField  HeaderText="Apply" ItemStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                           
                                                                            <a id="a1" href="ApplyCourse.aspx?Cid=<%#Container.DataItem("courseID")%>">
                                                                                                                          Apply</a>
                                                                        </ItemTemplate>
                                                                   </asp:TemplateField>
                                                                   <%--<asp:TemplateField >
                                                                        <ItemTemplate>
                                                                           
                                                                            <a id="a1" href="PrintStudentAppForm.aspx?Cid=<%#Container.DataItem("courseID")%>">
                                                                                                                          Print</a>
                                                                        </ItemTemplate>
                                                                   </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                            
                                                    </div></div>
                                                    
                                                <hr />
                                                <div class="box box-primary">
                                                        <div class="box-header"><h3 class="box-title with-border">Course Registered for</h3></div>
                                                        <div class="box-body">
                                            
                                                        
                                                <asp:GridView ID="GrdCourseApply" AutoGenerateColumns="false" runat="server" DataKeyNames="stid"
                                                    Width="100%" AllowPaging="True" PageSize="10" CssClass="table form_body">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <Columns>
                                                      
                                                        <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left"  Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentlastName" Text='<%# Eval("lastname") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseCode") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Start Date" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstartDate" Text='<%# Eval("startdate") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Login ID" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                                </div></div>
                                            </div>
   
    
</section>
</div>

     <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>