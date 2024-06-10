<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="AddEventManagement.aspx.cs" Inherits="Admin_AddEventManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
 <script language="javascript" type="text/javascript" src="../datetimepicker.js"></script>
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
    <h1 class="heading-color">Add Event</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Event</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">

    

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
      <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       </div></div>
    <div class="row" >
      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course Code" CssClass="input-block-level"  /></div>
      
      </div>
        <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtTitle" runat="server" PlaceHolder="Event Title" ToolTip="Event Title" CssClass="input-block-level"></asp:TextBox></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
        <asp:DropDownList ID="ddlColor" runat="server" CssClass="input-block-level">
            <asp:ListItem Value="0">--Select--</asp:ListItem>
            <asp:ListItem>Red</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Blue</asp:ListItem>
            <asp:ListItem>Black</asp:ListItem>
            <asp:ListItem>Orange</asp:ListItem>
        </asp:DropDownList>
    </div>
    </div>                                            
      
     <div class="row" >
    <div class="col-lg-5 col-md-5 col-sm-9 col-xs-9">
        <asp:TextBox ID="txtStartDate" runat="server" ToolTip="Start Event Date" placeholder="Start Event Date" CssClass="input-block-level" ></asp:TextBox>
       
     </div>
    <div class="col-lg-1 col-md-1 col-sm-3 col-xs-3">
         <a href="javascript:NewCal('<%= txtStartDate.ClientID %>','mmddyyyy')"> 
            <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" style="vertical-align:bottom;margin-left:-20px;">
        </a>
    </div>
    <div class="col-lg-5 col-md-5 col-sm-9 col-xs-9">
        <asp:TextBox ID="txtEnddate" runat="server" ToolTip="End Event Date" placeholder="End Event Date" CssClass="input-block-level" ></asp:TextBox>
       
     </div>
    <div class="col-lg-1 col-md-1 col-sm-3 col-xs-3" style="text-align:left">
         <a href="javascript:NewCal('<%= txtEnddate.ClientID %>','mmddyyyy')"> 
            <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" style="vertical-align:bottom;margin-left:-20px;">
        </a>
    </div>
    </div>                                                                                                 
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesc"  MaxLength="250"  runat="server" PlaceHolder="Event description (Max Length:250 Characters)" ToolTip="Event description" TextMode="MultiLine" Rows="4" CssClass="input-block-level"></asp:TextBox></div>
    </div>
    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
       <asp:CheckBox ID="chkchecked" runat="server" Visible="false" /> &nbsp;Visible at Calander (Active or De-Active)
    </div>
    </div>

    <div class="row" >&nbsp;</div>                                                
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click"/>
                        <asp:button ID="btnCancel" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" OnClick="btnCancel_Click" />
        <asp:HiddenField ID="hdnEventid" runat="server" />
                        </div>
                        </div>
       </div>                                                    
       
        </section>
    </div>
    </form>
</asp:Content>

