<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="AddTopic.aspx.vb" Inherits="Admin_AddTopic" ValidateRequest="false" Title="Topic Info" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Topic Info</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
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
                     
                         function writeImgTag(code)
                        {
                        var cache = document.getElementById("txtreply").value;
                        this.code = code;
                        cache =  cache + "<img src='../emoticons/" + code + ".gif'> ";
                        //document.getElementById("txtreply").innerHTML =cache;
                       // document.forms[0]["txtreply"].value =cache;
                       //  document.getElementById("txtreply");
                       var textBox1 = document.getElementById('<%= txtreply.ClientID %>');
                       textBox1.value = cache;

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
    <h1 class="heading-color">Add Topic<asp:Label ID="lblCaption" runat="server" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add topic</li>
		</ul>
	</div>
    </section>        


    <form id="form1" runat="server">
  
    <div onkeypress="javascript:HideMessage()">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 
    

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row" >
    <div class="user-info media box" style="background-color:#fff;">
    <div class="well">
    <div class="row">
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtTopic" runat="server" ToolTip="Topic" CssClass="form-control" ></asp:TextBox></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtcreatedby" runat="server" ToolTip="Created by" CssClass="form-control"  Enabled="false" ></asp:TextBox></div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                          <ContentTemplate >
                                                            <asp:Dropdownlist ID="ddlCourse" runat="server" CssClass="form-control" ToolTip="Course" AutoPostBack="true"></asp:Dropdownlist>
                                                        </ContentTemplate>
    </asp:UpdatePanel></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                          <ContentTemplate >
                                                            <asp:Dropdownlist ID="ddlBatch" runat="server" CssClass="form-control" ToolTip="Batch"></asp:Dropdownlist>
                                                              </ContentTemplate>
    </asp:UpdatePanel></div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                          <ContentTemplate >
                                                            <asp:Dropdownlist ID="ddlSem" runat="server" CssClass="form-control" ToolTip="Semester"></asp:Dropdownlist>
                                                              </ContentTemplate>
    </asp:UpdatePanel></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display: inline-flex;"><asp:CheckBox ID="chkActive" runat="server" Text="Active"></asp:CheckBox></div>
    </div>
    </div>
   
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4><asp:Label ID="lblReply" Text="Reply" runat="server"></asp:Label></h4></div>
    </div>
                                                            
                                                            <%--<FTB:FreeTextBox ID="txtreply" runat="server">
                                                            </FTB:FreeTextBox>--%>
    <div class="row" align="center" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                                           
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
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
                                                                         <FTB:FreeTextBox ID="txtreply" runat="server">
                                                            </FTB:FreeTextBox>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                             </div>
                                                             </div>
                                                             <div class="row" >&nbsp;</div>
   <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success"/>
                                <asp:button ID="btnCancel" Text="Back" CssClass="btn btn-large btn-warning" runat="server"/>
                                                       
   </div>
   </div>
   </div>
   </div>
   </section>
    </div>
   
    </form>
</asp:Content>
