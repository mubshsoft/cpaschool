<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="ListCourseHelp.aspx.vb" Inherits="Admin_ListCourseHelp" %>

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
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
    <h1 class="heading-color">List Course</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List Course</li>
		</ul>
	</div>
    </section>
   <form id="form1" runat="server">
    <div >
     
                        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
       <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                          <ContentTemplate >
                                                <asp:GridView ID="GrdCourse" AutoGenerateColumns="False" DataKeyNames="CourseId" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="True" OnPageIndexChanging="GrdCourse_PageIndexChanging">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hd1" Value='<%# Eval("CourseID") %>' runat="server" />
                                                                <asp:Label ID="lbl" Text='' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      <%--  <asp:TemplateField HeaderText="CourseCode" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstcode" Text='<%# Eval("CourseCode") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentFirstName" Text='<%# Eval("CourseName") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <asp:TemplateField>
                                                            <ItemTemplate>
                                                               <%-- <a id="a1" href="DeskBroucher.aspx?cid=<%#Container.DataItem("CourseID")%>&helpId=1">
                                                                    HelpDesk</a>--%>
                                                                     <asp:LinkButton ID="lblHelpDesk" CommandArgument='<%# Eval("CourseID") %>' CommandName="HelpDesk" runat="server" >FAQ</asp:LinkButton>
                                                                      <asp:HiddenField ID="hdHelpDesk" Value='<%# Eval("HelpDeskFilepath") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%--<a id="a2" href="DeskBroucher.aspx?cid=<%#Container.DataItem("CourseID")%>&helpId=2">
                                                                    Broucher</a>--%>
                                                                     <asp:LinkButton ID="lblBroucher" CommandArgument='<%# Eval("CourseID") %>' CommandName="Broucher" runat="server" >Brouchure</asp:LinkButton>
                                                                     <asp:HiddenField ID="hdHBroucher" Value='<%# Eval("BroucherFilepath") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%--<a id="a3" href="DeskBroucher.aspx?cid=<%#Container.DataItem("CourseID")%>&helpId=3">
                                                                    Calendar</a>--%>
                                                                    <asp:LinkButton ID="lblCalendar" CommandArgument='<%# Eval("CourseID") %>' CommandName="Calendar" runat="server" >Calendar</asp:LinkButton>
                                                                     <asp:HiddenField ID="hdHCalendar" Value='<%# Eval("CalendarFilepath") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      
                                                    </Columns>
                                                </asp:GridView>
                                                </ContentTemplate>
                                                         </asp:UpdatePanel>
                                                         </div>
                                                         </div>
                                                         </div>
                                            </section>
                        
                    
    </div>
    </form>

</asp:Content>