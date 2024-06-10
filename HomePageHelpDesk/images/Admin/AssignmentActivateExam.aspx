<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="AssignmentActivateExam.aspx.cs" Inherits="Admin_AssignmentActivateAssignment" Title="Use Existing Assignment" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Use Existing Assignment</title>--%>
   
 <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server"> 
  <script language="javascript" type="text/javascript" src="../datetimepicker.js">
    </script>
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

    <script language="javascript" type="text/javascript">
  
function openPopup(strOpen)
    {
        open(strOpen, "Info", "status=1, width=700, height=430,resizable=yes, top=200, left=200");
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
       <%-- <li class="active">Section Detail</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id='popCal' style='position: absolute; visibility: hidden; border: 2px ridge;
        width: 10'>
        <iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152"
            height="147"></iframe>
    </div>
    <div onkeypress="HideMessage()">
        
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                           
  

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlAssignmentset" runat="server" ToolTip="Assignment Set" placeholder="Assignment Set" CssClass="input-block-level" AutoPostBack="True" OnSelectedIndexChanged="ddlAssignmentset_SelectedIndexChanged">
                                                                    </asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
 <asp:DropDownList ID="ddlbatch" runat="server" ToolTip="Batch Code" CssClass="input-block-level"></asp:DropDownList>
    </div>
    </div>                                                         
    <div class="row" >
    <div class="col-lg-5 col-md-5 col-sm-9 col-xs-9">
    <asp:TextBox ID="txtactivateDate" runat="server" ToolTip="Activation Date" placeholder="Activation Date" CssClass="input-block-level"></asp:TextBox></div>
    <div class="col-lg-1 col-md-1 col-sm-3 col-xs-3">
     <a href="javascript:NewCal('<%= txtactivateDate.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" style="vertical-align:bottom"></a>
      &nbsp;<asp:Label ID="lblactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-5 col-md-5 col-sm-9 col-xs-9">
    <asp:TextBox ID="txtDeactivateDate" runat="server" ToolTip="Deactivation Date" placeholder="Deactivation Date" CssClass="input-block-level"></asp:TextBox></div>
    <div class="col-lg-1 col-md-1 col-sm-3 col-xs-3"><a href="javascript:NewCal('<%= txtDeactivateDate.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" style="vertical-align:bottom"></a>&nbsp;<asp:Label ID="lblDeactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div> 
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdnNewAsgnId" runat="server" /></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"> 
     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click" />
     &nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" OnClick="btnBack_Click" />
                                                                </div>
                                                                </div>
    </div>                                                        <%-- <tr>
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
       <div class="user-info media box" style="background-color:#fff;">                                                    
     
                                                                
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                         <asp:GridView ID="grdAssignmentSet" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                            DataKeyNames="AsgnId" OnRowCancelingEdit="grdAssignmentSet_RowCancelingEdit"
                                                            OnRowEditing="grdAssignmentSet_RowEditing" OnRowUpdating="grdAssignmentSet_RowUpdating">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (grdAssignmentSet.PageSize * grdAssignmentSet.PageIndex) + Container.DisplayIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Assignment Code" ItemStyle-HorizontalAlign="Left">
                                                                    <%-- <ItemStyle  Width="50px" />--%>
                                                                    <ItemTemplate>
                                                                        <%--  <asp:Label ID="lblAssignmentcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AsgnCode")%>'></asp:Label>--%>
                                                                        <a id="a1" href="javascript:openPopup('ActvateAssignment_StudentList.aspx?AsgnId=<%#Eval("AsgnId")%>&bid=<%#Eval("bid")%>')">
                                                                            <%#Eval("AsgnCode") %></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left">
                                                                    <%--<ItemStyle Width="110px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnAsgnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AsgnId")%>' />
                                                                        <asp:HiddenField ID="hdnbid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "bid")%>' />
                                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "batchcode")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ActivateDate">
                                                                    <%-- <ItemStyle Width="65px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsem" runat="server" Text='<%# Eval("ActivateDate","{0:M-dd-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtActivateDate" runat="server" MaxLength="300" CssClass="NormalText"
                                                                            Text='<%# Bind("ActivateDate","{0:M-dd-yyyy}") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DeactivateDate">
                                                                    <%-- <ItemStyle  Width="55px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmodule" runat="server" Text='<%# Eval("DeactivateDate","{0:M-dd-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDeactivateDate" runat="server" MaxLength="300" CssClass="NormalText"
                                                                            Text='<%# Bind("DeactivateDate","{0:M-dd-yyyy}") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                    ShowEditButton="True" ShowHeader="True" />
                                                            </Columns>
                                                            <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                        </asp:GridView>
                                                        </div>
                                                        </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:HiddenField ID="hdnAsgnId" runat="server" />
    <asp:HiddenField ID="hdnSectionId" runat="server" />
    </div>
    </div>
    </div>
    </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            
    </form>

</asp:Content>