<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="ExamSet.aspx.cs" Inherits="ExamSet" Title="Exam Set" %>

<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Exam Set</title>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
    </style>
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
<script type="text/javascript" src="../stmenu.js"></script>
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
            Exam Set
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Exam Set</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
           

    
    <div onkeypress="javascript:HideMessage()">
               
                    
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 10px; padding-bottom: 20px;">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                DataKeyNames="ExamID" AllowPaging="true" PageSize="10" OnRowDataBound="grdExamSet_RowDataBound"
                                                                OnPageIndexChanging="grdExamSet_PageIndexChanging" Visible="False" CssClass="table">
                                                                <EmptyDataTemplate>
                                                                    <table  width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="padding-right: 10px">
                                                                                <font color="#4b4b4b"><strong>No records </strong></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Paper No.">
                                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdPaperTitle" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="center" Width="250px" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblexamcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ExamCode")%>'></asp:Label>
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
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Module">
                                                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnExamID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ExamId")%>' />
                                                                            <asp:LinkButton ID="lnkDetailsExam" runat="server" Font-Underline="false" Font-Bold="true"
                                                                                Text="Start Exam"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <%--<td align="center">
                                                <asp:GridView ID="grdExamSet_1" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="ExamID" AllowPaging="true" PageSize="10" OnRowDataBound="grdExamSet_1_RowDataBound"
                                                    OnPageIndexChanging="grdExamSet_1_PageIndexChanging" Visible="False">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="100%" align="center" style="padding-right: 10px">
                                                                    <font color="#4b4b4b"><strong>No records </strong></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Paper No.">
                                                            <ItemStyle HorizontalAlign="center" Width="50px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdPaperTitle" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemStyle HorizontalAlign="center" Width="250px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ExamCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course" Visible="false">
                                                            <ItemStyle HorizontalAlign="center" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdnExamID" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "ExamId")%>' />
                                                                <asp:LinkButton ID="lnkDetailsExam" runat="server" Font-Underline="false" Font-Bold="true"
                                                                    Text="Start Exam"></asp:LinkButton>
                                                            
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Semester">
                                                            <ItemStyle HorizontalAlign="center" Width="70px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Module">
                                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" Width="70px" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnExamID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ExamId")%>' />
                                                                <asp:LinkButton ID="lnkDetailsExam" runat="server" Font-Underline="false" Font-Bold="true"
                                                                    Text="Start Exam"></asp:LinkButton>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                            
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </td>--%>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                               
                           
    </div>
    </div>
    </div>
    
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>