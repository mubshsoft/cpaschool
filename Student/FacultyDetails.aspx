<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FacultyDetails.aspx.vb" Inherits="FacultyDetails" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Faculty Registration Form</title>
 <script type="text/javascript" src="../stmenu.js"></script>
  <%--  <script language="javascript" type="text/javascript">
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
<link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="../css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../css/sl-slide.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
    <link rel="stylesheet" href="../css/main.css"/>

    <style>
    .row {margin-left:0}
    .fac-text 
    {
    font-size: 1.15em;
    color: #4c4c4c;
    width: 80%;
    margin: auto;
    text-align: justify;
    }
    .fac-name 
    {
        color: #ea830e;
    font-size: 25px;
    margin: 15px 0;
    }
    .fac-label 
    {
    color: #ea830e;
    font-size: 15px;
    margin: 15px 0;
    font-weight:bold;
    }
    img 
    {
    border-radius: 50%;
    border: solid 1px #e8e8e8;
    width: 100px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager></div></div>
                        <div class="container">
                            <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">    
                                    
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                               <ContentTemplate >
                                               <div class="user-info media box" style="background-color:#fff;">
                                                <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Faculty Details</div></div>
                                                <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">&nbsp;</div></div>
                                                        <div class="row">
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="text-align:center"><img src="dist/img/user2-160x160.jpg" /></div>
                                                        <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 fac-text">
                                                        <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                                            <h2 class="fac-name"><asp:Label ID="lblname" runat="server" Text=""></asp:Label></h2></div></div>
                                                        
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
                                                    
                                                           <span class="fac-label">Profile :</span> <asp:Label ID="lblProfile" runat="server" Text=""></asp:Label>
                                                          
                                                 <br /><br />
                                                    
                                                            <span class="fac-label">Course :</span> <asp:Label ID="lblcourse" runat="server" Text=""></asp:Label>
                                                       
                                                 
                                                    <br /><br />
                                                            <span class="fac-label">Paper :</span> <asp:Label ID="lblPaper" runat="server" Text=""></asp:Label>
                                                       <br /><br />
                                                            <span class="fac-label">E-mail ID :</span> <asp:Label ID="lblmail" runat="server" Text=""></asp:Label>
                                                       
                                                        </div>
                                                        </div>
                                                   
                                                    
                                                    
                                                    
                                                    <%--                                                  <tr>
                                                   <td  >
                                                            &nbsp;</td>
                                                            
                                                  <td>
                                                        &nbsp;</td>
                                                  <td align="left"> 
                                                  <div style="width:210px; overflow-x:auto">
                                                      <asp:ListBox ID="lst" runat="server" CssClass="NormalText"  
                                                          SelectionMode="Multiple"  Height="100px" width="310px"></asp:ListBox>
                                                   </div>
                                                      </td>
                                                  </tr>--%>
                                                   <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">&nbsp;</div></div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                                                            <asp:Button ID="btnSave" runat="server" Text="Cancel" CssClass="btn btn-warning"/>
                                                        </div>
                                                        </div>
                                                        </div>
                                                </ContentTemplate>
    </asp:UpdatePanel>

    </div>
    </div>
    </div>
                                                   
    
    </form>
</body>
</html>
