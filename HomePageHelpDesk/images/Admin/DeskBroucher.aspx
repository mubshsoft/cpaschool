<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="DeskBroucher.aspx.vb" Inherits="Admin_DeskBroucher" Title="FAQ" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
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
<%--    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>
--%>
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
    <h1 class="heading-color"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Course</li>--%>
		</ul>
	</div>
    </section>
 <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        
                        
                        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
       
       
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                    
                        <span class="pull-right"><asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server" /></span>
                        </div></div>
                                            
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
      <div class="row">
      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtTitle" runat="server" ToolTip="Course Title" CssClass="input-block-level"></asp:TextBox></div>
      </div>
      <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:FileUpload ID="FileUpload1" ToolTip="Upload File" runat="server" /></div>
      </div>
      <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>
                                                           <asp:button ID="btnCancel" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server"/>
                            </div></div>
                                                    
        </div>
        <div class="user-info media box" style="background-color:#fff;">
                                            
       <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">                                    
                                                <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="CourseId" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="True" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                       
                                                         <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="FAQ" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHelpDeskFilepath" Text='<%# Eval("HelpDeskFilepath") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Brouchure" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHelpDeskFilepath" Text='<%# Eval("BroucherFilepath") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Calendar" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCalendarFilepath" Text='<%# Eval("CalendarFilepath") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                               
         </div></div>
         </div>
         </section>
                   
    </div>
    </form>

</asp:Content>
