<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyDownload.aspx.cs" Inherits="Faculty_CaseStudyDownload" %>

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
 <section class="fullwidth banner-color">
    <h1 class="heading-color">Download Case Study</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Download Case Study</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
        <div onkeypress="javascript:HideMessage()">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <div class="frame">
              

                <section class="container main m-tb">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
       <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
       <asp:HiddenField ID="hdnAsgnId" runat="server" />
       </div>
       </div>
      <div class="row" style="padding:3em 0">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center">  &nbsp;</div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center">              
                      <asp:LinkButton ID="lnkbtndownloadOrg" runat="server" onclick="lnkbtndownloadOrg_Click">
                                              <img src="../images/case_study_Admin.png" /> </asp:LinkButton> 
                                                       
                           </div>
          <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center">                                 <asp:LinkButton ID="lnkbtndownload" runat="server"  onclick="lnkbtndownload_Click1">
                                                       <img src="../images/case_study_student.png" /> </asp:LinkButton></div>
          <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center">&nbsp;</div>
                                                                                                           
    </div> 
     </div>                                                            
    
                                            </section>
            </div>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

    </form>

</asp:Content>




