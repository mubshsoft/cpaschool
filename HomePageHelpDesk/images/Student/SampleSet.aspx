<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="SampleSet.aspx.cs" Inherits="SampleSet" Title="Sample Set"%>

<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
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

    <style type="text/css">




.grid-row-Overtime		{background-color:#ffffff;}

.grid-altrow-Overtime	{background-color:#fafafa; border: solid 1px #e2e2e2;}
    </style>

    <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Sample Set
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Dashboard</a></li>
            <li class="active">Sample Set</li>
          </ol>
        </section>
    <section class="content">
     <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    
     <div onkeypress="javascript:HideMessage()">
  
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                       
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px" >
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 10px; padding-bottom: 20px;">
                                                <table width="680px">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="center"  >
                                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                    </tr>
                                                 
                                                    <tr>
                                                        <td align="center"  >
                                                <asp:GridView ID="grdSampleSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="SamId" AllowPaging="true" PageSize="10" onrowdatabound="grdSampleSet_RowDataBound" >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                           <%--<asp:TemplateField HeaderText="Paper No."  Visible="false">
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      <asp:HiddenField ID="hdPaperTitle" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>' />
                                                       </ItemTemplate>
                                                       </asp:TemplateField>--%>
                                                       <asp:TemplateField HeaderText="Name">
                                                        <ItemStyle HorizontalAlign="center" Width="250px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblSamplecodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SampleCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="Course" Visible="false">
                                                        <ItemStyle HorizontalAlign="center" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Semester"  Visible="false">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module"  Visible="false">
                                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                    
                                                         <asp:TemplateField>
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnSampleID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SamId")%>' />
                           <asp:HiddenField ID="hdnSampletype" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Sampletype")%>' />
                            <%--<asp:HiddenField ID="hdnSamplePath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SamplePath")%>' />--%>
                          <asp:LinkButton ID="lnkDetailsSample" runat="server" Font-Underline="false"  Font-Bold="true"
                                Text="Start"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
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
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
   
    </div>
    
   
    
    </div>
    </div>
   
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    </asp:Content>