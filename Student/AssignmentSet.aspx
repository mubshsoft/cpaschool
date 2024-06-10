<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master"
    CodeFile="AssignmentSet.aspx.cs" Inherits="AssignmentSet" Title="Assignment Set" %>

<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Assignment Set</title>
<script type="text/javascript" src="../stmenu.js"></script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td, th
        {
            padding: 5px;
        }
        .form_head
        {
            background: #0e245d;
            color: #fff;
            border: 0;
        }
        .form_body
        {
            border: solid 1px #e2e2e2;
            background: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function HideMessage() {

            if (document.all) {
                document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
            }
            else {
                document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
            }
        }
    </script>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Assignment Set
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Assignment Set</li>
          </ol>
        </section>
        <section class="content">
            
    
     <div onkeypress="javascript:HideMessage()">
  <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                                   
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                     </div>
                                                     </div>
                                                     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                 <div class="box"><div class="box-body">    
                                                <asp:GridView ID="grdAssignmentSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="AsgnID" AllowPaging="true" PageSize="10" 
                                                                onrowdatabound="grdAssignmentSet_RowDataBound" 
                                                                onpageindexchanging="grdAssignmentSet_PageIndexChanging" >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                        <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                           <asp:TemplateField HeaderText="Paper No." >
                                                        <ItemStyle HorizontalAlign="center" Width="200px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      <asp:HiddenField ID="hdPaperTitle" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>' />
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Name">
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblAssignmentcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AssignmentCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="Course" Visible="false">
                                                        <ItemStyle HorizontalAlign="center" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Semester">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                    
                                                         <asp:TemplateField>
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnAssignmentID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AsgnId")%>' />
                           <asp:HiddenField ID="hdnAssignmenttype" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Assignmenttype")%>' />
                            <%--<asp:HiddenField ID="hdnAssignmentPath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AssignmentPath")%>' />--%>
                          <asp:LinkButton ID="lnkDetailsAssignment" runat="server" Font-Underline="false"  Font-Bold="true"
                                Text="Start"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                 </div></div>     
   
    </div>
    
   
    </div>
    </div>
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"></script>
</asp:Content>
