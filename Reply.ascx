<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Reply.ascx.vb" Inherits="Reply" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
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


    <div class="row-fluid">
     <div class="span12"> 

     <div class="user-info media box" style="background-color:#fff;">
     <div class="row-fluid">
     <div class="span12">
<h3>Please Post Your reply Here</h3>
     </div>
     </div>
     <div class="row-fluid">
     <div class="span12 left">
<b>Topic :-</b>&nbsp;&nbsp;<asp:Label ID="lblmainTopic" runat="server"  Text=""></asp:Label>
     </div>
     </div>
     <div class="row-fluid">
     <div class="span12">
     <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text=""></asp:Label>
     </div>
     </div>
     <div class="row-fluid">
     <div class="span12">
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

     </div>
     </div>
     <div class="row-fluid">
     <div class="span12"><%--  <asp:TextBox ID="txtreply" runat="server" Height="192px" TextMode="MultiLine" Width="100%"></asp:TextBox>--%>
                                                                   <FTB:FreeTextBox ID="txtreply" runat="server">
                                                            </FTB:FreeTextBox>
                                                            </div>
                                                            </div>
                                                            <div class="row-fluid">&nbsp;</div>
      <div class="row-fluid">
     <div class="span12">                                                      <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success btn-large arial"  />
                                                                     &nbsp;&nbsp;
                                                                <%--<asp:Button ID="ImgCancel" runat="server" AlternateText="" Text="Cancel" CssClass="btn btn-warning btn-large arial" />--%>
                                                                <input type="button" value="Cancel" class="btn btn-warning btn-large arial" onclick="history.back()" />
                                                                </div>
                                                                </div>
     </div>

     </div>
     </div>

                                                           
                                                           
                                                                
                                                                 
                                                                
                                                           