<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="DownLoadLectureContent.aspx.cs" Inherits="DownLoadLectureContent" Title="Download lectures" %>

<%--
<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
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




.grid-altrow-Overtime	{background-color:#eeeeee; border: solid 1px #e2e2e2; }
    </style>

    <div class="content-wrapper">
<!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Download Lectures
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Download Lectures</li>
          </ol>
        </section>

 <section class="content">
     
    
     <div onkeypress="javascript:HideMessage()">
  
      <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                            
                                               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                                <div class="box box-primary"><div class="box-header">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                          
                                                        <fieldset><h3 class="box-title">View Existing Lectures</h3></div>
                                                        <div class="box-body">
                                                                   <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                   
                                                                 PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" 
                                                    PagerStyle-HorizontalAlign="Center" PageSize="10"  
                                                                AllowPaging="True" onrowcommand="grdExamSet_RowCommand" 
                                                                >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    
                                                                          <PagerStyle HorizontalAlign="Center" />
                                                    
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
                                                       
                                                      
                                                       
                                                      
                                                       <asp:TemplateField HeaderText="Semester">
                                                        <ItemStyle Width="10%" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle  Width="10%" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Paper" >
                                                        <ItemStyle  Width="30%" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                         <asp:TemplateField HeaderText="FileCaption">
                                                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTimeAllowted" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "FileCaption")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                  
                                                                </asp:TemplateField>
                                                       
                                                    
                                                       
                                                  
                                                     
                                                            
                                                        
                                                            
                                                  <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkDeleteExamSet" runat="server" CommandName="download" CommandArgument='<%# Eval("UploadFilePath") %>'>
                                                                     Download</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                            
                                                             
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView></td>
                                                            </fieldset>
                                                        </div>
                                                        </div>
                                                </div>
                                                </div>
                                              <%--  </ContentTemplate>
                                                </asp:UpdatePanel> --%>
        </div>                                    
    
   
</section>
</div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>
