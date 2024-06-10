<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="MainForumPage1.aspx.vb" Inherits="MainForumPage1" Title="Discussion Forum" %>

<%--<%@ Register Src="MainHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

<%@ Register Src="ForumTopic1.ascx" TagName="Forum" TagPrefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
    <h1 class="heading-color">List of Topics</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Faculty/FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">List of Topics</li>
		</ul>
	</div>
    </section>
 
    <form id="form1" runat="server">

    
  <section class="container main m-tb">


  <%--   <div onkeypress="javascript:HideMessage()">
       <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>
                                    </div>--%>
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
        <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <uc3:Forum ID="Forum" runat="server" />

                                                </div>
                                                </div>
                                                </div>
                                            
    </div>
    </div>
    </section>
    </form>


    </asp:Content>
