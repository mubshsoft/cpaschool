<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="CourseID.aspx.cs" Inherits="Admin_CourseID" Title="Course ID" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Course ID</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
   <%--<script language="javascript" type="text/javascript">
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
    </script>--%>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
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
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Query</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <div id='popCal' style='POSITION:absolute;visibility:hidden;border:2px ridge;width:10'>
<iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152" height="147"></iframe>
</div>
    <div onkeypress="HideMessage()">
    
  
        
                                <div class="frame">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>

    

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    
                                      
                                                
                                                 <asp:GridView ID="grdCourseID" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                    DataKeyNames="ExamID" OnRowDataBound="grdCourseID_DataBound" 
                                                     AllowPaging="true" PageSize="10" 
                                                     onpageindexchanging="grdCourseID_PageIndexChanging" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                       
                                                       <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                       <%-- <ItemStyle  Width="50px" />--%>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblCourseTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      <asp:HiddenField ID="hdnCourseId" Value='<%#DataBinder.Eval(Container.DataItem, "CourseId")%>' runat="server" />
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="">
                                                       <%-- <ItemStyle  Width="50px" />--%>
                                                       <ItemTemplate>
                                                       <asp:LinkButton ID="lnkEdit" runat="server" class="btn btn-primary" Text="Evaluation Marks Criteria" ></asp:LinkButton>
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="">
                                                       <ItemTemplate>
                                                       <asp:LinkButton ID="lnkSignup" runat="server" class="btn btn-primary" Text="Signup Criteria" ></asp:LinkButton>
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                     
                                                       
                                                            
                                                          
                                                            
                                                             
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView><br /><br /><br />
                                            </div>
                                            </div>
                                            </div>
                                            </section>
                                      </ContentTemplate>
                                                            </asp:UpdatePanel>
                                </div>
                                                                
    </form>
</asp:Content>