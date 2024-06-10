<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignmentDownload.aspx.cs" Inherits="Admin_AssignmentDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">

    <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">

        function openPopup(strOpen) {

            window.open(strOpen, "Info", "status=1, width=700, height=450, top=200, left=300");
        }



    </script>

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


    <form id="form1" runat="server">
        <div onkeypress="javascript:HideMessage()">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <div class="frame">
                <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">List of batch for assignment</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">|</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
       </div>
    </section>

                <section class="container main">
    <div class="row-fluid">
     <div class="span12">
       <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
       <asp:HiddenField ID="hdnAsgnId" runat="server" />
       </div>
       </div>
      <div class="row-fluid">
     <div class="span12">    
          <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
              <tr align="left" valign="top" style="height:100px; vertical-align:middle">
                                                        <td width="25%" align="center">
                                                            <asp:LinkButton ID="lnkbtndownload" runat="server" 
                                                                onclick="lnkbtndownload_Click1">
                                                       <img src="../images/download_assignment.png" style="border:0px"    /></asp:LinkButton>
                                                        </td>
                                                         <td width="25%" align="center">
                                                             &nbsp;
                                                        </td>

              </tr>

          </table>                                                      
    </div> 
     </div>                                                            
    
                                            </section>
            </div>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

    </form>

</asp:Content>
