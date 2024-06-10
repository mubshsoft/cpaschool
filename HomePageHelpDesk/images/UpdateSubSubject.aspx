<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="UpdateSubSubject.aspx.vb" Inherits="UpdateSubSubject" ValidateRequest="false"  %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">



    <title>Discussion Forum</title>
<script type="text/javascript" src="stmenu.js"></script>
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
    <h1 class="heading-color">Discussion Forum</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        
        <%If Session("role") = "Admin" Then%>
        <li><a href="Admin/Adminlogin.aspx">Admin Panel</a></li>
        <% ElseIf Session("role") = "Faculty" Then %>
         <li><a href="faculty/Facultypanel.aspx">Faculty Panel</a></li>
         <% ElseIf Session("role") = "Student" Then%>
         <li><a href="Student/StudentPanel.aspx">Admin Panel</a></li>
         <%End If %>
        <li>Sub Subject</li>
         
		</ul>
	</div>
    </section> 
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        
                    
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                 <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">      
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                       
                                                                         
                                        
                                      <tr align="center" valign="top">
                                            
                                            <td>
                                                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text=""></asp:Label></td>
                                            
                                        </tr>
                                        <tr align="center" valign="top">
                                           
                                                  <td style="padding-left:40px; vertical-align:top">
                                                           <asp:ImageButton ID="img1"  ImageUrl="~/Emoticons/angel_smile.gif" runat="server"/>
                                                           &nbsp;&nbsp;<asp:ImageButton ID="img2"  ImageUrl="~/Emoticons/angry_smile.gif" runat="server"/>
                                                           &nbsp;&nbsp;<asp:ImageButton ID="img3"  ImageUrl="~/Emoticons/biggrin.gif" runat="server" 
                                                                   style="width: 16px"/>
                                                           &nbsp;&nbsp;<asp:ImageButton ID="img4"  ImageUrl="~/Emoticons/bowwow.gif" runat="server"/>
                                                           
                                                            &nbsp;&nbsp;<asp:ImageButton ID="img7"  ImageUrl="~/Emoticons/confused_smile.gif" runat="server"/>
                                                           
                                                             &nbsp;&nbsp;<asp:ImageButton ID="img9"  ImageUrl="~/Emoticons/cry_smile.gif" runat="server"/>
                                                              &nbsp;&nbsp;<asp:ImageButton ID="img10"  ImageUrl="~/Emoticons/devil_smile.gif" runat="server"/>
                                                              &nbsp;&nbsp;<asp:ImageButton ID="img12"  ImageUrl="~/Emoticons/embaressed_smile.gif" runat="server"/>
                                                             
                                                                 
                                                                  &nbsp;&nbsp;<asp:ImageButton ID="img17"  ImageUrl="~/Emoticons/regular_smile.gif" runat="server"/>
                                                                    &nbsp;&nbsp;<asp:ImageButton ID="img19"  ImageUrl="~/Emoticons/sad_smile.gif" runat="server"/>
                                                                    &nbsp;&nbsp;<asp:ImageButton ID="img20"  ImageUrl="~/Emoticons/shades_smile.gif" runat="server"/>
                                                                   
                                                                      &nbsp;&nbsp;<asp:ImageButton ID="img23"  ImageUrl="~/Emoticons/teeth_smile.gif" runat="server"/>
                                                                      
                                                                        &nbsp;&nbsp;<asp:ImageButton ID="img25"  ImageUrl="~/Emoticons/tounge_smile.gif" runat="server"/>
                                                                        &nbsp;&nbsp;<asp:ImageButton ID="img26"  ImageUrl="~/Emoticons/whatchutalkingabout_smile.gif" runat="server"/>
                                                                        
                                                                         &nbsp;&nbsp;<asp:ImageButton ID="img28"  ImageUrl="~/Emoticons/wink_smile.gif" runat="server"/>
                                                            </td>
                                       
                                        </tr>
                                        <tr align="left" valign="top">
                                            
                                            <td height="100%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 20px;">
                                                 <FTB:FreeTextBox ID="txtreply" runat="server">
                                                            </FTB:FreeTextBox></td>
                                           
                                        </tr>
                                         <tr>    <td style="width: 100%;" align="center" >
                                                                     <asp:Button ID="btnAdd" runat="server" text="Save" class="btn btn-success" />
                                                                     &nbsp;&nbsp;
                                                                     <asp:Button ID="btnCancel" runat="server" text="Cancel" class="btn btn-primary" />
                                                                     </td>
                                           
                                        </tr>
                                     
                                    
                                    </table>
                               
                                </ContentTemplate>
    </asp:UpdatePanel>
            </div>
            </div>
            </section>               
    </div>
    </form>
</asp:content>
