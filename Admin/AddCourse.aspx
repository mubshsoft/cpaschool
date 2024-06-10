<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="AddCourse.aspx.vb" Inherits="Admin_AddCourse" Title="Course Info" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Course Info</title>--%>

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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

   <section class="fullwidth banner-color">
   <asp:Label ID="lblCaption" Visible="false" runat="server" />
	<h1 class="heading-color">Add Course</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Course</li>
		</ul>
	</div>
</section>

    <form id="form1" runat="server">
  
    <div onkeypress="javascript:HideMessage()">
  
    
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNoOfSem"
                                                                ErrorMessage="<br>Please enter numeric values in No of semester" Display="Dynamic" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                                                </div>
                                                                </div>
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><asp:TextBox ID="txtCourseCode" runat="server" Placeholder="Course Code" ToolTip="Course Code" CssClass="form-control"></asp:TextBox></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><asp:TextBox ID="txtCourseTitle" runat="server" Placeholder="Course Title" ToolTip="Course Title" CssClass="form-control"></asp:TextBox></div>
                </div>
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><asp:TextBox ID="txtCourseStartDate" runat="server" Placeholder="Course Start Date" ToolTip="Course Start Date" CssClass="form-control"></asp:TextBox></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><asp:TextBox ID="txtCourseEndDate" runat="server" Placeholder="Course End Date" ToolTip="Course End Date" CssClass="form-control"></asp:TextBox></div>
                </div>
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><asp:TextBox ID="txtNoOfSem" runat="server" Placeholder="No Of Semesters" ToolTip="No Of Semesters" CssClass="form-control"></asp:TextBox></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center">&nbsp;</div>
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
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" style="display:inline-flex"><asp:checkbox ID="chkCourse" runat="server" Text=" Screening Exam" /></div>
                </div>
                <div class="row">&nbsp;</div>
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" align="center"><asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-warning btn-large"   /> <asp:Button ID="btnSave" runat="server"  Text="Save & Continue" CssClass="btn btn-success btn-large" /></div>
                </div>
               </div>
                                                     
                                                   
                  
                    </section>
         
   
    </div>
   
    </form>

  </asp:Content>
