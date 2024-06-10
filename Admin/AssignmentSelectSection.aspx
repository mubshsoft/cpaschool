<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AssignmentSelectSection.aspx.cs" Inherits="Admin_AssignmentSelectSection" Title="Section Info" %>

<%--
<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Section Info</title>--%>
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
<section class="fullwidth banner-color">
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" text="Section Info"/></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a></li>
      <%-- <li class="active">List Of Assignment</li>--%>
		</ul>
	</div>
    </section>

   
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
  

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:TextBox ID="txtNoofSection" ToolTip="Number of Section" PlaceHolder="Number of Section" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    </div>   
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    
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
 <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" onclick="btnBack_Click" />&nbsp;
    <asp:Button ID="btnSave" runat="server" Text="Save & Continue" CssClass="btn btn-large btn-success" onclick="btnSave_Click"/>
    <%--<a href="javascript:history.go(-1)"><img src="../Images/back_button.jpg" border="0" ></a>--%>
    </div>
    </div>   
    </div>    
    <div class="user-info media box" style="background-color:#fff;">                                             
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                             <asp:GridView ID="gvCategoryList" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="CategoryID" OnRowDataBound="gvCategoryList_RowDataBound" onrowcommand="gvCategoryList_RowCommand" onrowdeleting="gvCategoryList_RowDeleting">
                                                  <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Section Type">
                                                            <ItemStyle HorizontalAlign="center"  />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnDeleteCategoryID" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>' />
                                                                <asp:Label ID="lblCategoryName" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CategoryName")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:HiddenField ID="hdnCategoryID" runat="server" 
                                                                    Value='<%#DataBinder.Eval(Container.DataItem, "CategoryID")%>' />
                                                                <asp:TextBox ID="txtCategoryName" runat="server" MaxLength="100" 
                                                                    Text='<%# Bind("CategoryName") %>' Width="100px"></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center"  />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkaddInstruction" runat="server" CommandName="add" 
                                                                    Font-Underline="false">Edit Instruction</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkaddcategoryquestion" runat="server" CommandName="add" 
                                                                    Font-Underline="false">Edit Question Limit in Section</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center"  />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkDeleteCategory" runat="server" CommandName="Delete" 
                                                                    Font-Underline="false">Edit Question</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                       
                                                       <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkDeleteSelection" runat="server" CommandName="Delete" CommandArgument='<%# Eval("CategoryID") %>'>
                                                                     Delete</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                    </Columns>
                                                </asp:GridView>
     </div>
     </div> 
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdnAsgnId" runat="server" /></div>
    </div>
    </div>
     </section>              
   
    </div>
    
   
    </form>
</asp:Content>

