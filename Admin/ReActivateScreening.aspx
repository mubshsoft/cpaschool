<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="ReActivateScreening.aspx.vb" Inherits="Admin_ReActivateScreening" Title="Reactivate Screening" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Reactivate Screening</title>--%>

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
    <h1 class="heading-color">Re Activate Screening</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Re Activate Screening</li>
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
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
     </div>
      <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" ToolTip="Course" CssClass="form-control"></asp:DropDownList></div>
    </div>
      <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlScreeningset" runat="server" AutoPostBack="true"  ToolTip="Screening Code" CssClass="form-control"></asp:DropDownList></div>
        </div>
        <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" ToolTip="Year" CssClass="form-control">
                                                      <asp:ListItem>2008</asp:ListItem>
                                                      <asp:ListItem>2009</asp:ListItem>
                                                      <asp:ListItem>2010</asp:ListItem>
                                                      <asp:ListItem>2011</asp:ListItem>
                                                      <asp:ListItem>2012</asp:ListItem>
                                                      <asp:ListItem>2013</asp:ListItem>
                                                      <asp:ListItem>2014</asp:ListItem>
                                                      <asp:ListItem>2015</asp:ListItem>
                                                      <asp:ListItem>2016</asp:ListItem>
                                                      <asp:ListItem>2017</asp:ListItem>
                                                      <asp:ListItem>2018</asp:ListItem>
                                                      <asp:ListItem>2019</asp:ListItem>
                                                      <asp:ListItem>2020</asp:ListItem>
                                                </asp:DropDownList>
                                                </div>
            </div>
             <div class="row">&nbsp;</div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server"/></div>
                </div>
                </div>
                                     
                                        <%--<tr valign="top">
                                        <td>&nbsp;</td>
                                        <td colspan="2" align="center"  style="padding-top: 10px; padding-bottom: 10px;" 
                                                class="style16"><asp:Label ID="lblBatchCode" runat="server" Text="Batch Code :" Visible="false" ></asp:Label> 
                                                            <asp:DropDownList ID="ddlBatch" runat="server"  Visible="false"
                                                AutoPostBack="True" CssClass="DropDownStyle11">
                                                            </asp:DropDownList>
                                                </td>
                                                                 </tr>--%>
             <div class="user-info media box" style="background-color:#fff;">                                                     
            <div class="row" style="overflow:auto; height:400px">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">                                                    
                                                <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="id" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="False" PageSize="5" Visible="false" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="ScrId" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="ScrId" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScrId" Text='<%# Eval("ScrId") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="bid" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" Text='<%# Eval("courseid") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblname" Text='<%# Eval("stuname") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="UserId" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserId" Text='<%# Eval("UserId") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Date on which exam was taken" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltime" Text='<%# Eval("EndScreeningTime") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Time Taken(min)" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltimetaken" Text='<%# Eval("timetaken") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkActivate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' OnClientClick ="return confirm('Are you sure you want to Re-Activate Screening ?')">Activate 
                                                                Screening</asp:LinkButton>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                           <asp:TemplateField >
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClientClick ="return confirm('Are you sure you want to Delete Screening Answer?')">Delete 
                                                                Screening Answer</asp:LinkButton>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                            </div></div>
                                            </div>
                                            </section>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                   
                
               
    </div>
    </form>

</asp:Content>
