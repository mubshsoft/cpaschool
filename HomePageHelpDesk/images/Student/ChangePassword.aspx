<%@ Page MasterPageFile="~/Student/StudentMaster.master" Language="VB" AutoEventWireup="false"
    CodeFile="ChangePassword.aspx.vb" Inherits="Student_ChangePassword" Title="Change Password" %>

<%--
<%@ Register Src="../AdminHeader.ascx" TagName="AHeader" TagPrefix="uc1" %>
<%@ Register Src="../StudentHeader.ascx" TagName="SHeader" TagPrefix="uc1" %>
<%@ Register src="../FacultyHeader.ascx" tagname="FHeader" tagprefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
   <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
    <section class="content-header">
       <h1>
            Change Password
          </h1>
          <ol class="breadcrumb">
          <%--<a href="StudentPanel.aspx" id="lnkBackToPannel" runat="server" ><font color="#4b4b4b">Back To 
                                                            Student Panel</font></a></strong>&nbsp; <a href="../logout.aspx" class="part1"><strong class="style9_sec">
                                                                    <font color="#4b4b4b">Logout</font></strong></a>--%>
                         <%If Session("role") = "Admin" Then%>
                         <li><a href="../admin/AdminLogin.aspx"><i class="fa fa-user"></i> Admin</a></li>
                         <li class="active">Change Password</li>
                          <% ElseIf Session("role") = "Faculty" Then%>
                           <li><a href="../faculty/Facultypanel.aspx"><i class="fa fa-user"></i> Faculty</a></li>
                           <li class="active">Change Password</li>
                            <% ElseIf Session("role") = "Student" Then%>
                             <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
                             <li class="active">Change Password</li>
                               <%End If%>
            
          </ol>
            
           
               
                        

</section>
    <!-- / .title -->
    <section class="content">
    <div class="row">
    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">&nbsp;</div>
                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"> 
                <div class="box box-primary">
        <fieldset class="registration-form" style="margin-top: 20px; ">
        <div class="box-body">
        <div class="row">
                <div class="span12" ><asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager></div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
<div class="row">
            <div class="controls">
            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div></div>
<div class="row">
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb">
            <asp:TextBox ID="txtOld" runat="server" Title="Old Password" ToolTip="Old Password" CssClass="form-control" placeholder="Old Password" TextMode="Password"></asp:TextBox>
</div>
</div>
<div class="row">
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb">
            <asp:TextBox ID="txtNew"  runat="server" CssClass="form-control" Title="New Password" ToolTip="New Password" placeholder="New Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNew" ErrorMessage="Enter Password" Display="Dynamic"></asp:RequiredFieldValidator>
</div>
</div>
<div class="row">
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb">
                    <asp:TextBox ID="txtConfirm" runat="server" CssClass="form-control" Title="Confirm Password" ToolTip="Confirm Password" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Enter Password" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="New and confirm password should be same" ControlToCompare="txtNew" Display="Dynamic" ControlToValidate="txtConfirm"></asp:CompareValidator>
                                                                </div>
</div>
<div class="row">&nbsp;</div>
<div class="row">
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb" style="text-align:center">
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large arial" />&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-warning btn-large arial" CausesValidation="false"/>

                                </div>
                                </div>
                                



    <%--<div onkeypress="HideMessage()">
        
                                    
                                        
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                             
                                        
                                           
                                            </ContentTemplate>
    </asp:UpdatePanel>

    </div>
    </fieldset>
    </div>
    </div>
    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">&nbsp;</div>
    </div>
    </section>
   </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>
