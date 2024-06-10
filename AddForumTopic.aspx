<%@ Page Title="" Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="AddForumTopic.aspx.vb" Inherits="AddForumTopic" %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
   <script type="text/javascript" src="stmenu.js"></script>
 <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                  open(strOpen, "Info", "status=1, width=700, height=430, top=20, left=300");

              }
           
    </script>
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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Add Forum Topic</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Faculty/FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">List of Topics</li>
		</ul>
	</div>
    </section>
 
    <form id="form1" runat="server">

    
  <section class="container main m-tb">

     
    <div class="row-fluid" >
    <div class="span12"><strong><asp:Label ID="lblCaption" runat="server" /></strong></div>
    </div>
    <div class="row-fluid" >
    <div class="user-info media box" style="background-color:#fff;">
    <div class="well">
            <div class="row-fluid"><div class="span12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
            <div class="row-fluid">
            <div class="span6" align="right"><asp:TextBox ID="txtTopic" runat="server" placeholder="Topic" ToolTip="Topic" Height="40px" CssClass="input-xlarge arial" Width="100%"></asp:TextBox></div>
            <div class="span6" align="left"><asp:TextBox ID="txtcreatedby" runat="server" CssClass="input-xlarge arial" ToolTip="Created By" Height="40px" Width="100%"  Enabled="false"  ></asp:TextBox></div>
            </div>
            <div class="row-fluid">
            <div class="span6" align="right"><asp:Dropdownlist ID="ddlCourse" runat="server" CssClass="input-xlarge arial" ToolTip="Course" Height="40px" Width="100%" AutoPostBack="true"></asp:Dropdownlist></div>
            <div class="span6" align="left"><asp:Dropdownlist ID="ddlbatch" runat="server" CssClass="input-xlarge arial" placeholder="Batch" ToolTip="Batch" Height="40px" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlbatch_SelectedIndexChanged"></asp:Dropdownlist></div>
            </div>
            <div class="row-fluid">
            <div class="span6" align="right"><asp:Dropdownlist ID="ddlSem" runat="server"  CssClass="input-xlarge arial" placeholder="Semester" ToolTip="Semester" Height="40px" Width="100%"></asp:Dropdownlist></div>
            <div class="span6" align="left"><asp:Dropdownlist ID="ddlGroup" runat="server"  CssClass="input-xlarge arial" placeholder="Semester" ToolTip="Semester" Height="40px" Width="100%"></asp:Dropdownlist></div>
            </div>
            <div class="row-fluid" runat="server" >
            <div class="span6">
                 <asp:FileUpload ID="FileUpload1" Multiple="Multiple" runat="server" Visible="false" /><br />
                <asp:Button ID="btnUpload" runat="server" Text="upload" CssClass="btn btn-success btn-large" Visible="false"   /><br /><br />
                <asp:Repeater ID="dlstFileUpload" runat="server" >
                                                    <HeaderTemplate>  <table class="table table-striped table-bordered table-advance table-hover">
                                        <thead>
                                        <tr>
                                        <th><i class="icon-leaf"></i> <span class="hidden-phone">Sno.</span></th>
                                            <th><i class="icon-leaf"></i> <span class="hidden-phone">File Name</span></th>
                                            <th><i class="icon-remove"> </i><span class="hidden-phone">Delete</span></th>
                                            
                                        </tr>
                                        </thead>
                                        <tbody></HeaderTemplate>
                                                    <ItemTemplate>
     
            <tr>
            <td><%# Container.ItemIndex + 1 %></td>
                <td align = "center">
                    <%# Eval("Filename")%>
                </td>
                
                <td> <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Filepath") %>' runat = "server" OnClick = "DeleteFile" CssClass="btn btn-danger"  OnClientClick="javascript:return confirm('Are you sure you want to delete the file ?')"/>
                 <asp:HiddenField ID="hdnfilename" runat="server" Value='<%# Eval("Filename") %>' />
                <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%# Eval("Filepath") %>' />
                 <asp:HiddenField ID="hdnFilesize" runat="server" Value='<%# Eval("Filesize") %>' />
                </td>
            </tr>
       
    </ItemTemplate>
    <FooterTemplate> </tbody>
                                    </table></FooterTemplate></asp:Repeater>
            </div>
            <div class="span6" align="right"></div>
            </div> 
                 </div>
                 <div class="row-fluid" align="left" id="dvReply" runat="server"  ><h4>Reply:</h4></div>
                 <div class="row-fluid" align="center" id="dvReply1" runat="server" >
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                                                                <asp:ImageButton ID="img1"  ImageUrl="~/Emoticons/angel_smile.gif" runat="server"/>
                                                           &nbsp;&nbsp;<asp:ImageButton ID="img2"  ImageUrl="~/Emoticons/angry_smile.gif" runat="server"/>
                                                           &nbsp;&nbsp;<asp:ImageButton ID="img3"  ImageUrl="~/Emoticons/biggrin.gif" runat="server" 
                                                                   style="width: 16px"/>
                                                           &nbsp;&nbsp;<asp:ImageButton ID="img4"  ImageUrl="~/Emoticons/bowwow.gif" runat="server"/>
                                                           
                                                            &nbsp;&nbsp;<asp:ImageButton ID="img7"  ImageUrl="~/Emoticons/confused_smile.gif" 
                                                                    runat="server" style="width: 19px"/>
                                                           
                                                             &nbsp;&nbsp;<asp:ImageButton ID="img9"  ImageUrl="~/Emoticons/cry_smile.gif" 
                                                                    runat="server" style="width: 19px"/>
                                                              &nbsp;&nbsp;<asp:ImageButton ID="img10"  ImageUrl="~/Emoticons/devil_smile.gif" runat="server"/>
                                                              &nbsp;&nbsp;<asp:ImageButton ID="img12"  ImageUrl="~/Emoticons/embaressed_smile.gif" runat="server"/>
                                                             
                                                                 
                                                                  &nbsp;&nbsp;<asp:ImageButton ID="img17"  ImageUrl="~/Emoticons/regular_smile.gif" runat="server"/>
                                                                    &nbsp;&nbsp;<asp:ImageButton ID="img19"  ImageUrl="~/Emoticons/sad_smile.gif" runat="server"/>
                                                                    &nbsp;&nbsp;<asp:ImageButton ID="img20"  ImageUrl="~/Emoticons/shades_smile.gif" runat="server"/>
                                                                   
                                                                      &nbsp;&nbsp;<asp:ImageButton ID="img23"  ImageUrl="~/Emoticons/teeth_smile.gif" runat="server"/>
                                                                      
                                                                        &nbsp;&nbsp;<asp:ImageButton ID="img25"  ImageUrl="~/Emoticons/tounge_smile.gif" runat="server"/>
                                                                        &nbsp;&nbsp;<asp:ImageButton ID="img26"  ImageUrl="~/Emoticons/whatchutalkingabout_smile.gif" runat="server"/>
                                                                        
                                                                         &nbsp;&nbsp;<asp:ImageButton ID="img28"  ImageUrl="~/Emoticons/wink_smile.gif" runat="server"/>
                                                                         <FTB:FreeTextBox ID="txtreply" runat="server">
                                                            </FTB:FreeTextBox>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel>
                 </div>
                 <div class="row-fluid">&nbsp;</div>
                 <div class="row-fluid" align="center" ><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large" />
                     <asp:HiddenField ID="hdnFiles" runat="server" />
                     <asp:HiddenField ID="hdnFilename" runat="server" />
                     <asp:HiddenField ID="hdnSubjectid" runat="server" />

                  
                                                             &nbsp;
                                                           <asp:button ID="btnCancel" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server"/>
                                                           </div>
                 </div>
                 </div>
                 
    </section>
    </form>


    </asp:Content>

