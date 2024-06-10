<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="AssignmentDownload.aspx.cs" Inherits="Faculty_AssignmentDownload" %>

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
            
            <div class="frame">
                <section class="title">
        <div class="container">
        <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <h2 style="color:#fff">List of assignment- Manual or Offline</h2>
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
                                                        <td width="45%" align="center">
                                                            <asp:LinkButton ID="lnkbtnAssignment" runat="server" 
                                                                onclick="lnkbtnAssignment_Click">
                                                       <img src="../images/submit_assignment.png" style="border:0px"/>Assignment from Admin </asp:LinkButton>
                                                        </td>
                                                         <td width="45%" align="center">
                                                              <asp:LinkButton ID="lnkbtnSubmitted" runat="server" 
                                                                onclick="lnkbtnSubmitted_Click">
                                                       <img src="../images/submit_assignment.png" style="border:0px"/> Submitted Assignment from student</asp:LinkButton>
                                                        </td>

              </tr>

          </table>                                                      
    </div> 
     </div>                                                            
    
                                            </section>
            </div>
         
        </div>

    </form>

</asp:Content>
