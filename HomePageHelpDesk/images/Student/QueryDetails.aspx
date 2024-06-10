<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QueryDetails.aspx.vb" Inherits="Student_QueryDetails" %>

<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<title>Query Details</title>
<link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="../css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../css/sl-slide.css"/>
    <link rel="stylesheet" href="../css/main.css"/>
<script type="text/javascript" src="../stmenu.js"></script>
<script language="javascript" type="text/javascript">
    function openPopup(strOpen) {
        open(strOpen, "Info", "status=1, width=700, height=330, top=20, left=300");
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

    function openPopup(id) {
        open("QueryDetails.aspx?fid=" + id, "Info", "status=1, width=700, height=230, top=20, left=300");
    }
</script>
<form id="form1" runat="server">
<div onkeypress="javascript:HideMessage()" align="center">
   <div class="container main" style="padding:20px">
   <div class="row-fluid">
     <div class="span12">
   <div class="user-info media box" style="background-color:#fff;">
   <div class="row-fluid"><div class="span12 form_head">Query Details</div></div>
            <div class="row-fluid">
                <strong><asp:label id="lblMsgDetails" runat="server" text=""></asp:label></strong>
                        </div>
                        <div class="row-fluid">
                <asp:label id="lblMessage" runat="server"></asp:label></div>
                
                        
            <div class="row-fluid" style="margin-top: 20px;">
                <div class="span5 form_text field-label">Query Date:</div>
                <div class="span4"><asp:textbox id="lblQueryDate" runat="server" enabled="false" CssClass="input-block-level" ToolTip="Query Date" ></asp:textbox></div>
                </div>
                <div class="row-fluid">
                <div class="span5 form_text field-label">Query For:</div>
                <div class="span4"><asp:textbox id="lblQueryFor" runat="server" enabled="false" CssClass="input-block-level" ToolTip="Query For" ></asp:textbox></div>
                </div>
                <div class="row-fluid">
                <div class="span5 form_text field-label">Query Subject:</div>
                <div class="span4"><asp:textbox id="lblQuerySubject" runat="server" CssClass="input-block-level" enabled="false" ToolTip="Query Subject" ></asp:textbox></div>
                </div>
                <div class="row-fluid">
                <div class="span5 form_text field-label">Your Query:</div>
                <div class="span4"><asp:textbox id="lblYourQuery" textmode="MultiLine" CssClass="input-block-level" runat="server" ToolTip="Your Query" Rows="4"></asp:textbox></div>
                </div>
                <div class="row-fluid">
                <div class="span5 form_text field-label">Replied date:</div>
                <div class="span4"><asp:textbox id="lblReplyDate" runat="server" CssClass="input-block-level" ToolTip="Replied date" enabled="false" ></asp:textbox></div>
                </div>
                <div class="row-fluid">
                <div class="span5 form_text field-label">Query Reply:</div>
                <div class="span4"><asp:textbox id="lblQueryReply" runat="server" textmode="MultiLine" enabled="false" CssClass="input-block-level" ToolTip="Query Reply" Rows="4"></asp:textbox></div>
                </div>
                <div class="row-fluid">
                <div class="span4" align="left">Status: <asp:label id="lblQueryStatus" runat="server" font-bold="true"></asp:label></div>
                <div class="span4" align="center"><asp:button id="btnSave" Text="Save" CssClass="btn btn-success btn-large arial" visible="False" runat="server" />
                            &nbsp;&nbsp;
                            <asp:button id="btnClose" CssClass="btn btn-warning btn-large arial" Text="Close" runat="server" /></div>
                </div>
                 </div>    
    </div>
    </div>
    </div>              
                 
                  
                   
                   
</div>
</form>
