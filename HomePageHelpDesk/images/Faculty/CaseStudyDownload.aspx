<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="CaseStudyDownload.aspx.cs" Inherits="Faculty_CaseStudyDownload" %>

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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    <form id="form1" runat="server">
        <div onkeypress="javascript:HideMessage()">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <div class="frame">
                <section class="title">
        <div class="container">
        <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <h2 style="color:#fff">List of batch for assignment</h2>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <ul class="breadcrumb pull-right">
                        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a> <span class="divider">|</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
       </div>
    </section>

                <section class="container main m-tb">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
       <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
       <asp:HiddenField ID="hdnAsgnId" runat="server" />
       </div>
       </div>
      <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">    
          <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
              <tr align="left" valign="top" style="height:100px; vertical-align:middle">
                  <td width="25%" align="center">
                                                            
                      <asp:LinkButton ID="lnkbtndownloadOrg" runat="server" 
                                                                onclick="lnkbtndownloadOrg_Click">
                                                       Case Study from Admin</asp:LinkButton>
                                                        </td>
                                                        <td width="25%" align="center">
                                                            <asp:LinkButton ID="lnkbtndownload" runat="server" 
                                                                onclick="lnkbtndownload_Click1">
                                                       Case Study from Student</asp:LinkButton>
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




