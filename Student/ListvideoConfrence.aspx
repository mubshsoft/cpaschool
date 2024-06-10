<%@ Page Title="" Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="ListvideoConfrence.aspx.vb" Inherits="Student_ListvideoConfrence" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Sending Mail</title>--%>

 <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
   
    
      <script language="javascript" type="text/javascript">
          function HideMessage() {

              if (document.all) {
                  document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
              }
              else {
                  document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
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
        .icon-position
        {
        position: absolute;
        right: 20px;
        top: 10px;
        }
    </style>
     <script language="javascript" type="text/javascript" src="../datetimepicker.js"></script>
     </asp:Content>
     <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="fullwidth banner-color" style="padding:40px">
    <h1 class="heading-color">Video Conferencing Notification</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="StudentDashboard.aspx">Student Panel</a></li>
        
        <li class="active">Video Conferencing Notification</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">
        
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                
                                 
  
    <section class="container main">
                
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                                 
                                                               
                                       
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                                          <div class="user-info media box" style="background-color:#fff;">
                                          <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                                          </div>
                                           <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" placeholder="Course" ToolTip="Course" CssClass="form-control" AutoPostBack="true" ></asp:DropDownList></div>
                                         <asp:DropDownList ID="ddlBatch" runat="server" placeholder="Batch" ToolTip="Batch"  AutoPostBack="true" CssClass="form-control" Visible="false"></asp:DropDownList>
                                          </div>
                                      
                                         
                                           <div class="row">
                                            
                                         <div class="col-lg-6 col-md-5 col-sm-12 col-xs-12"><asp:TextBox ID="txtfrom" runat="server" ToolTip="From Date" placeholder="from Date" CssClass="form-control"></asp:TextBox>
                                               <a href="javascript:NewCal('<%= txtfrom.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
                                               &nbsp;<asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                                         
                                         <div class="col-lg-6 col-md-5 col-sm-12 col-xs-12"><asp:TextBox ID="txtto" runat="server" ToolTip="To Date" placeholder="to Date" CssClass="form-control"></asp:TextBox>
                                               <a href="javascript:NewCal('<%= txtto.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
                                               &nbsp;<asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                             <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
             <asp:Button ID="btnSearch" runat="server" Text="Go" CssClass="btn btn-success btn-large arial" OnClick="btnGo_Click"/>
         </div>
                                          </div>
                                                  
                                                   
                                                            </div>
                                                           
                                                    <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                           <asp:GridView ID="GrdList" AutoGenerateColumns="False" DataKeyNames="bid" CssClass="table"
                                                    runat="server" AllowPaging="True" OnPageIndexChanging="GrdList_PageIndexChanging">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <EmptyDataTemplate>
                                                    No Record Found
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                          
                                                       <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                        
                                                            <ItemTemplate>
                                                            
                                                               
                                                                   <%# Eval("BatchCode") %>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                 
                                                    
                                                               
                                                       <asp:TemplateField HeaderText="Subject" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                               
                                                       <asp:TemplateField HeaderText="Confrence Link" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblConfrenceLink" Text='<%# Eval("ConfrenceLink") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                               
                                                       <asp:TemplateField HeaderText="Confrence Date" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblConfrenceDate" Text='<%# Eval("ConfreenceDate") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                          </div></div>
</ContentTemplate>
    </asp:UpdatePanel>
     <div class="user-info media box" style="background-color:#fff;">
                                                   
                                                            <div class="row">&nbsp;</div>
                                                    <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:Button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server"/>
                                                        </div>
                                                    </div>
                                                    </div>
                                               
                                            
                                           
        </section>       
    </div>
    </form>

</asp:Content>
