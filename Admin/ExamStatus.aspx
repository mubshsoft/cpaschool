﻿<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="ExamStatus.aspx.vb" Inherits="Admin_ExamStatus" Title="Exam Status" %>

<%--%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title></title>--%>
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
    <h1 class="heading-color">List of students</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
       <li class="active">List of students</li>
		</ul>
	</div>
    </section>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div onkeypress="javascript:HideMessage()">
        
                        
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        
    <section class="container main m-tb">
<div class="user-info media box" style="background-color:#fff;">
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlListExamSet" runat="server" AutoPostBack="true" ToolTip="ExamSet code" CssClass="form-control">
                                                                    </asp:DropDownList></div></div>
                                                               
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
     <asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Admin/AdminListBatchExam.aspx" />
     </div></div>
      </div>
<div class="user-info media box" style="background-color:#fff;">
                                                    
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Attempted</h4></div></div>
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:GridView ID="GrdUserList" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True" OnPageIndexChanging="GrdUserList_PageIndexChanging" PageSize="15">
                                                            <HeaderStyle CssClass="from_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <emptydatarowstyle backcolor="LightBlue" forecolor="Red"/>
                                                            <Columns>
                                                            
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (GrdUserList.PageSize * GrdUserList.PageIndex) + Container.DisplayIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstunam" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "stuname")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="User ID" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Userid")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
     </div></div>
                                                        <hr />
                                                    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Not Attempted</h4></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:GridView ID="GrdUserList1" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True" OnPageIndexChanging="GrdUserList1_PageIndexChanging" PageSize="15">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <emptydatarowstyle backcolor="LightBlue" forecolor="Red"/>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#(GrdUserList1.PageSize * GrdUserList1.PageIndex) + Container.DisplayIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstunam" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "stuname")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="User ID" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Userid")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div></div>
</div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                
                   
    </div>
    </form>

    </asp:Content>
