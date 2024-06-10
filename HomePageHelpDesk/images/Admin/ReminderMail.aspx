<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ReminderMail.aspx.vb" Inherits="Admin_ReminderMail" ValidateRequest="false" Title="Sending Mail" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
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
    <h1 class="heading-color">Send Mail</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Send Mail</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">
        
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                
                                 
  
    <section class="container main m-tb">
                
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
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" placeholder="Course" ToolTip="Course" CssClass="input-block-level" AutoPostBack="true" ></asp:DropDownList></div>
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlBatch" runat="server" placeholder="Batch" ToolTip="Batch"  AutoPostBack="true" CssClass="input-block-level"></asp:DropDownList></div>
                                          </div>
                                          <div class="row">
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlSemester" runat="server" placeholder="Semester" ToolTip="Semester" CssClass="input-block-level" AutoPostBack="true"></asp:DropDownList></div>
                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlStd" runat="server" placeholder="Student" ToolTip="Student" CssClass="input-block-level"></asp:DropDownList></div>
                                          </div>
                                          <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtSubject" placeholder="Subject" ToolTip="Subject" runat="server" CssClass="input-block-level"></asp:TextBox></div>
                                          </div>
                                         
                                          <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Message</h4></div>
                                          </div>
                                                  
                                                    <div id="trRow1" runat="server" >
                                                        
                                                            <asp:TextBox ID="txtMessage"  MaxLength="400"  runat="server" TextMode="MultiLine" ></asp:TextBox>
                                                            </div>
                                                            </div>
                                                           
                                                    <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <FTB:FreeTextBox ID="txtreply" runat="server" width="100%">
                                                            </FTB:FreeTextBox></div></div>
</ContentTemplate>
    </asp:UpdatePanel>
     <div class="user-info media box" style="background-color:#fff;">
                                                    <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                              <asp:FileUpload ID="Fupd" runat="server" CssClass="btn btn-primary"  />
                                          </div>
                                         </div>

                                                            <div class="row">&nbsp;</div>
                                                    <div class="row">
                                          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-primary" runat="server"/>
                                                        </div>
                                                    </div>
                                                    </div>
                                               
                                            
                                           
        </section>       
    </div>
    </form>

</asp:Content>
