<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="BulkMail.aspx.vb" Inherits="Admin_BulkMail" Title="Sending Mail" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">

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
        <li><a href="adminlogin.aspx" id="lnk" runat="server" ><font color="#fff">Admin Panel</font></a></li>
       <li class="active">Send Mail</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">

   
  <section class="container main m-tb">
    <%--<div onkeypress="HideMessage()"></div>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                        
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                    
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                           
      <div class="user-info media box" style="background-color:#fff;">
                 <div class="row"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="left">
                 <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" CssClass="input-block-level" ToolTip="Select Batch"   ></asp:DropDownList>
                  </div>
                  </div>
                  <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="left">
                  <asp:TextBox ID="txtSubject" runat="server" CssClass="input-block-level" ToolTip="Subject" Placeholder="Subject"  ></asp:TextBox>
                   </div>  
                   </div>  
                   <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="left">                        
                      <asp:TextBox ID="txtMessage"  runat="server" CssClass="input-block-level" ToolTip="Message" Placeholder="Message.." TextMode="MultiLine" Rows="6" ></asp:TextBox>
                         </div>
                         </div>
                         <div class="row"> &nbsp;</div>
                         <div class="row"> 
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">  
                    <asp:button ID="btnSave" Text="Save" CssClass="btn btn-success btn-large " runat="server"/>&nbsp;
                    <asp:button ID="btnClose" Text="Close" CssClass="btn btn-warning btn-large " runat="server"/>
                    </div>
                    </div>
                                                        
                                            </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>
      
    </section>
    </form>



    </asp:Content>
