<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="AddFeeAndSemesterDuration.aspx.vb" Inherits="Admin_AddFeeAndSemesterDuration" Title="Add Fee And Semester Duration" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Fee And Semester Duration</title>--%>

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
    <h1 class="heading-color">Course Fees</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Course Fees</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         
                                 
    <section class="container main m-tb">
    <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">&nbsp;</div></div>
    <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                       <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNoOfSem"
                                                                ErrorMessage="Please enter numeric values" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>--%>
                         </div></div>
                         <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                         <asp:DropDownList ID="ddlnationality" runat="server" ToolTip="Nationality" CssClass="form-control" AutoPostBack="True">
                                                                              <asp:ListItem>SELECT NATIONALITY</asp:ListItem>
                                                                              <asp:ListItem>Indian</asp:ListItem>
                                                                               <asp:ListItem>Others</asp:ListItem>
                                                                          </asp:DropDownList>
                                                                </div></div>
                        <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlapplicantCategory" runat="server" ToolTip="Category" CssClass="form-control" AutoPostBack="True"/>
                                                                           <%--   <asp:ListItem>SELECT</asp:ListItem>
                                                                              <asp:ListItem>Institutional Sponsored</asp:ListItem>
                                                                              <asp:ListItem>Individual Candidate</asp:ListItem>
                                                                              <asp:ListItem>Student</asp:ListItem>
                                                                              <asp:ListItem>Applicant from developed countries</asp:ListItem>
                                                                              <asp:ListItem>Applicant from SAARC and other developing countries</asp:ListItem>--%>
                                                              
                                                         
                                                                </div></div>
                        <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <asp:DropDownList ID="ddlFeetype" runat="server" ToolTip="Fee Type" AutoPostBack="true" CssClass="form-control">
                                                                         <asp:ListItem>SELECT FEE TYPE</asp:ListItem>
                                                                         <asp:ListItem>One Time Fee</asp:ListItem>
                                                                         <asp:ListItem>Semester wise</asp:ListItem>
                                                                  </asp:DropDownList>
                                                                </div></div>
                        <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <table>
                                                              <tr id="Row1" runat="server" visible="false" >
                                                                <td align="right" style="padding-right: 10PX;"><asp:Label ID="lblfeeMsg" runat="server" Text="Course fee :" Visible="false" ></asp:Label></td>
                                                                <td>&nbsp;</td>
                                                                <td align="left">
                                                                     <asp:TextBox ID="txtFee" runat="server" Visible="false" CssClass="form-control" ></asp:TextBox>
                                                                     &nbsp;
                                                                     <asp:label ID="lblonetimecur"  runat="server"></asp:label>
                                                                </td>
                                                                </tr>
                                                          </table>
                                                            
                                                        </div></div>
                       <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                          
                             <asp:Panel ID="Panel1" runat="server" >
                                                                <asp:Table CssClass="table" ID="MyTable"  runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </div></div>

                        <div class="row">
                       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                   <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-large" />
                                                        
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large" OnClientClick="return confirm('Are sure you want to save fees?');" />
                                                           <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary btn-large"  /> 
                                                        </div></div>
                                                        <div class="row">&nbsp;</div>
                                               </ContentTemplate>
                                             </asp:UpdatePanel>
                                             </div>
                                             </div>
                                             </div>
                                             </section>
                                             </div>
                                            
    </form>

</asp:Content>
