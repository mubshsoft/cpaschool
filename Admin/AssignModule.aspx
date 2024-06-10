<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AssignModule.aspx.cs" Inherits="Admin_AssignModule" Title="Assign Module" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add ExamSet</title>--%>

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
    </script>

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
        }
    </style>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
  </asp:Content>
     <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="fullwidth banner-color" style="margin-top:-121px">
    <h1 class="heading-color">Assign Module to Batch</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Assign Module to Batch</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
   

    <section class="container main m-tb">
    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>  
         <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <fieldset>
     <legend>Assign Module to Batch</legend>
      <div class="row" >
    
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
   <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
   </div>
    </div>
    <div class="row" >
    
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlModule"  runat="server" ToolTip="Module" CssClass="form-control"  />
      <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
        <div class="row" >
    
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control" />
      <asp:Label ID="lblreqbatch" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>      
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="button1" Text="Save" CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click" />
                               <asp:Button ID="Imagebutton2" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx" />
                               </div>
                               </div>                 
                                                                    </fieldset>
                                                                    <fieldset>
   <div class="user-info media box" style="background-color:#fff;">
       <legend>View assigned module</legend>
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">                                                              
                                                                                    <asp:GridView ID="grdlist" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table"  OnRowCommand="grdExamSet_RowCommand">
                                                                                    <HeaderStyle CssClass="form_head" />
                                                                                        <PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                       <PagerStyle HorizontalAlign="Center" />
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
                                                                                    <asp:BoundField DataField="courseTitle" HeaderText="Course" />
                                                                                     <asp:BoundField DataField="batchcode" HeaderText="Batch" />
                                                                                      <asp:BoundField DataField="Moduletitle" HeaderText="Module" />
                                                                                      <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDeleteExamSet" runat="server" CommandName="Delete"  CommandArgument='<%# Eval("id") %>'>
                                                                     Delete</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                    </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
    </div>
    
                                                                    </fieldset>
     </div>
     </div>
     </div>
 
                                                               
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                           
                                </div>
                          
    </div>
    </section>
    </div>
    </form>

</asp:Content>
