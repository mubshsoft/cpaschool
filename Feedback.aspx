<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="Feedback.aspx.vb" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

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

    <style type="text/css">
        .style14
        {
            height: 1px;
        }
        body>section {
    margin-top: 0;
}
    </style>

<section class="fullwidth banner-color">
	<h1 class="heading-color">Feedback Form</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Feedback Form</li>
		</ul>
	</div>
</section>
    <form id="form1" runat="server">
  
    <div onkeypress="javascript:HideMessage()">
   <section class="container main"> 
   <div class="row">&nbsp;</div>  
         <div class="row" >
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
        
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                           
                                                       </div>
                                                       </div>
                                                       <div class="row">&nbsp;</div>  
             <div class="row" >
             <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Name :<asp:Label ID="Label1" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
             <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox></div>
             <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Address :</div>
              <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox></div>
              </div>
              <div class="row">&nbsp;</div>  
                                                        <div class="row" >
             <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Organization :</div>
             <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtOrganization" runat="server" CssClass="form-control"></asp:TextBox></div>
             <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Contact Number :<asp:Label ID="Label3" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
             <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div></div>
                                                        <div class="row">&nbsp;</div>  
                                                        <div class="row" >
             <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Email Id :<asp:Label ID="Label2" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
             <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                  
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
                                                   
             <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Feedback<asp:Label ID="Label4" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
             <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control" 
                                                                TextMode="MultiLine" Height="80px"></asp:TextBox>
                                                        </div></div>
                                                        <div class="row">&nbsp;</div>  
                                                        <div class="row" >
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center"><asp:ImageButton ID="btnSave" runat="server"  ImageUrl="Images/Send.png" 
                                                                onclick="btnSave_Click"/>&nbsp;&nbsp;<asp:ImageButton ID="btnCancel" runat="server"  ImageUrl="Images/cancel.png"/>
                                                        </div>
                                                        </div>
                                                       
                                                        
    
</section>
</form>
</asp:content>
