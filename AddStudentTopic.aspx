<%@ Page Language="VB" MasterPageFile="~/Student/StudentMaster.master" Title="Topic Info" AutoEventWireup="false" CodeFile="AddStudentTopic.aspx.vb" Inherits="AddStudentTopic" ValidateRequest="false" %>

<%--<%@ Register Src="MainHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="stmenu.js"></script>

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

    <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            List of topics
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List of topics</li>
          </ol>
        </section>
    <section class="content">
    <%--<div onkeypress="javascript:HideMessage()"></div>--%>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        </div>
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <div class="box box-primary">
            
            <div class="box-body">
     
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:Label ID="lblCaption" runat="server" />
            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
            </div>
            <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtTopic" runat="server" Placeholder="Topic" ToolTip="Topic" CssClass="form-control"></asp:TextBox></div>
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtcreatedby" runat="server" Placeholder="Created By" ToolTip="Created By" CssClass="form-control" Enabled="false" ></asp:TextBox></div>
            </div>
             <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></div> 
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlSem" runat="server" CssClass="form-control"></asp:DropDownList></div>
            </div>
<div class="row">&nbsp;</div>
<div class="row">&nbsp;</div>
            <div class="row" runat="server" id="dvReply">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Reply</h4></div></div>
<div class="row">&nbsp;</div>                                          
              <div class="row" runat="server" id="dvReply1">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center" >                                        
                                                            
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="img1" ImageUrl="~/Emoticons/angel_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img2" ImageUrl="~/Emoticons/angry_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img3" ImageUrl="~/Emoticons/biggrin.gif" runat="server"
                                                                                    Style="width: 16px" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img4" ImageUrl="~/Emoticons/bowwow.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img7" ImageUrl="~/Emoticons/confused_smile.gif"
                                                                                    runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img9" ImageUrl="~/Emoticons/cry_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img10" ImageUrl="~/Emoticons/devil_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img12" ImageUrl="~/Emoticons/embaressed_smile.gif"
                                                                                    runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img17" ImageUrl="~/Emoticons/regular_smile.gif"
                                                                                    runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img19" ImageUrl="~/Emoticons/sad_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img20" ImageUrl="~/Emoticons/shades_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img23" ImageUrl="~/Emoticons/teeth_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img25" ImageUrl="~/Emoticons/tounge_smile.gif" runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img26" ImageUrl="~/Emoticons/whatchutalkingabout_smile.gif"
                                                                                    runat="server" />
                                                                                &nbsp;&nbsp;<asp:ImageButton ID="img28" ImageUrl="~/Emoticons/wink_smile.gif" runat="server" />
                                                                                <FTB:FreeTextBox ID="txtreply" runat="server">
                                                                                </FTB:FreeTextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div></div>
                                                        <div class="row">&nbsp;</div>
                                                        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large arial" />
                                                            &nbsp;
                                                            <asp:Button ID="btnCancel" Text="Cancel" CssClass="btn btn-warning btn-large arial" runat="server" />
                                                        </div>
                </div>
                
                </div>
                </div>
                </div></div>
                </section>
   </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    <script src="Student/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
