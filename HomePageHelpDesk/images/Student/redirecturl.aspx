<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="redirecturl.aspx.cs" Inherits="Student_redirecturl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    
<script type="text/javascript" src="../stmenu.js"></script>
    <style type="text/css">
       
    .RadioButtonWidth label {  margin-left:20px;vertical-align:top; }  
    .style1
    {
        width: 15%;
    }
    .style2
    {
        width: 40%;
    }
    .style3
    {
        width: 45%;
    }
    </style>
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
    

<section class="title">
        <div class="container">
            <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Payment</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="StudentPanel.aspx"><font color="#fff">Student Panel</font></a><span class="divider">|</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
 <section class="container main" style="margin-top:20px">
     
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="80%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;border:solid 1px #cccccc; ">
                                <asp:LinkButton ID="lnkhome" runat="server" onclick="lnkhome_Click">Go to Main List</asp:LinkButton>
                                <asp:HiddenField ID="hdnWebUrl" runat="server" />
                            </td>
                        </tr>
                       
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>                  
    </form>
        
</section>
</asp:Content>
