﻿<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="SampleAddOption.aspx.cs" Inherits="Admin_SampleAddOption" Title="Add Option" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Add Option</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px;}
    </style>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Option" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">Instruction Summary</li>--%>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div onkeypress="javascript:HideMessage()">
  <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>
      
  
    <section class="container main m-tb">
                <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                   <strong>Question:<asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label></strong>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                    </div>
                    <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <b> Answer:</b>&nbsp; <asp:Label ID="lblanswer" runat="server" Text=""></asp:Label>
                    </div>
                    </div>
                                                   <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                         <div class="row">
                 <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                            
                                                            Option Type :
                                                        </div>
                                                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                            <asp:DropDownList ID="ddlOptionType" runat="server" CssClass="input-block-level" TabIndex="2" >
                                                                <asp:ListItem>-Select-</asp:ListItem>
                                                                <asp:ListItem>Radio Button</asp:ListItem>
                                                                 <asp:ListItem>Check Box List</asp:ListItem>
                                                            </asp:DropDownList>
                                                         </div>
                                                         
                 <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                  Add Option :<font color="red">*</font></div>
                  <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                            <asp:TextBox ID="txtoption" runat="server" TabIndex="3" CssClass="input-block-level"></asp:TextBox><asp:LinkButton ID="lnkbtnans" runat="server" onclick="lnkbtnans_Click">Click here add answer as option</asp:LinkButton>
                                                            <asp:RequiredFieldValidator ID="rqdSurveyQuestion" runat="server" 
                                                                ControlToValidate="txtoption" ErrorMessage="&lt;/br&gt;Enter Option " ValidationGroup="1" CssClass="style11"></asp:RequiredFieldValidator>
                                                        </div>
                                                        </div>
                                                                                                    
                                                    <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" onclick="btnSave_Click" ValidationGroup="1"/>&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" onclick="btnBack_Click" CausesValidation="false" />
                                                        <%--    <a href="javascript:history.back()"><img src="../Images/back_button.jpg" border="0" ></a>--%>

                                                        </div>
                                                        </div>
                                                        <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:GridView ID="gvQuestionOptionList" runat="server" AllowPaging="true"  CssClass="table"
                                                    AutoGenerateColumns="false" DataKeyNames="OPTID" 
                                                     OnPageIndexChanging="gvQuestionOptionList_PageIndexChanging" 
                                                    OnRowCancelingEdit="gvQuestionOptionList_RowCancelingEdit" 
                                                    OnRowDeleting="gvQuestionOptionList_RowDeleting" 
                                                    OnRowEditing="gvQuestionOptionList_RowEditing" 
                                                    OnRowUpdating="gvQuestionOptionList_RowUpdating" 
                                                    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                    PageSize="5" >
                                                   <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="OPTIONS">
                                                            <ItemStyle HorizontalAlign="center" Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="OPTIONS" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "OPTIONS")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtOption" runat="server" MaxLength="100" 
                                                                    Text='<%# Bind("OPTIONS") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPTION TYPE">
                                                            <ItemStyle HorizontalAlign="center" Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" 
                                                            HeaderStyle-Width="125px" ShowEditButton="True" ShowHeader="True" />
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" Width="75px" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnOptId" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "OPTID")%>' />
                                                                <asp:LinkButton ID="linkDeleteQuestion" runat="server" CausesValidation="false" 
                                                                    CommandName="Delete" Font-Underline="false">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            </div>
                                                <asp:HiddenField ID="hdnSamId" runat="server" />
                                                <asp:HiddenField ID="hdnQuestionID" runat="server" />
                                            
                                   
                                    </section>
                                 </ContentTemplate></asp:UpdatePanel>
                               
                 
   
    </div>
   
    </form>
</asp:Content>
