<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="StudentLectureListCourse.aspx.vb" Inherits="StudentLectureListCourse" Title="Download Lectures" %>
<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of course</title>
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

<div class="content-wrapper">
<!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Download Lecture
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Download Lecture</li>
          </ol>
        </section>

 <section class="content">
    <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
    
    <div onkeypress="javascript:HideMessage()">
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            
                                                   <asp:GridView ID="GrdCourseApply" AutoGenerateColumns="false" runat="server" DataKeyNames="stid"
                                                    Width="100%" AllowPaging="true" PageSize="10" CssClass="table form_body">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                               
                                                                    <%# Eval("CourseCode") %> 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Download Lecture" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <a id="a1" href="DownLoadLectureContent.aspx?id=<%#Container.DataItem("courseID")%>&sid=<%#Container.DataItem("stid")%>">
                                                                    view </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                    
                                                </asp:GridView>
                                            
                                            </div></div>

    </section>
</div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>