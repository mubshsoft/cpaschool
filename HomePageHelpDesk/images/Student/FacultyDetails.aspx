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
    <link rel="stylesheet" href="../css/main.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row-fluid">
    <div class="span12">
        
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager></div></div>
                        
                            <div class="row-fluid">
    <div class="span12">    
                                    
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                               <ContentTemplate >
                                               <div class="user-info media box" style="background-color:#fff;">
                                                <div class="row-fluid">
    <div class="span12 form_head">
                                                            Faculty Details
                                                        </div></div>
                                                   <div class="row-fluid">
                                                        <div class="span12">
                                                            <strong><asp:Label ID="lblname" runat="server" Text=""></asp:Label></strong>
                                                        </div>
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
                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <strong>Profile :</strong> <asp:Label ID="lblProfile" runat="server" Text=""></asp:Label>
                                                            </div>
                                                            </div>
                                                 
                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <strong>Course :</strong> <asp:Label ID="lblcourse" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        </div>
                                                 
                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <strong>Paper :</strong>  <asp:Label ID="lblPaper" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        </div>
                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <strong>E-mail ID :</strong> <asp:Label ID="lblmail" runat="server" Text=""></asp:Label>
                                                       </div></div>
                                                    
                                                    
                                                    
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
                                                    <div class="row-fluid">
                                                        <div class="span12" align="center">
                                                            <asp:Button ID="btnSave" runat="server" Text="Cancel" CssClass="btn btn-success btn-large arial"/>
                                                        </div>
                                                        </div>
                                                        </div>
                                                </ContentTemplate>
    </asp:UpdatePanel>


    </div>
    </div>
                                                   
    
    </form>
</body>
</html>
