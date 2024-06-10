<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QueryDetails.aspx.vb" Inherits="Report_QueryDetails" %>


<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="../css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../css/sl-slide.css"/>
    <link rel="stylesheet" href="../css/main.css"/>
    <title>Query Details</title>
<script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
      function myprint()
{   
    window.print();
}

              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=700, height=330, top=20, left=300");
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
                     
                      function openPopup(id)
                     {
                    open("QueryDetails.aspx?fid=" + id, "Info", "status=1, width=700, height=230, top=20, left=300");
                      }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()" align="center">
    <section class="container main">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">
    Quesry Details
    </div></div>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:Label ID="lblMsgDetails" runat="server" Text=""></asp:Label>
    </div>
    </div>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:Label ID="lblMessage" runat="server" ></asp:Label>
    </div>
    </div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="lblQueryDate" ToolTip="Query Date" placeholder="Query Date" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="lblQueryFor" ToolTip="Query For" placeholder="Query For" CssClass="form-control" runat="server" Enabled="false"  ></asp:TextBox></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="lblQuerySubject" ToolTip="Query Subject" placeholder="Query Subject" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="lblYourQuery" TextMode="MultiLine" Rows="4" ToolTip="Your Query" placeholder="Your Query" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="lblReplyDate" runat="server" ToolTip="Replied date" placeholder="Replied date" CssClass="form-control" Enabled="false"></asp:TextBox></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="lblQueryReply" runat="server" ToolTip="Query Reply" placeholder="Query Reply" CssClass="form-control" Rows="4" TextMode="MultiLine" Enabled="false" ></asp:TextBox></div></div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblQueryStatus" runat="server" ToolTip="Status" placeholder="Status" CssClass="form-control" Font-Bold="true"  ></asp:Label></div></div>
    <div class="row">&nbsp;</div>
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
<asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" OnClientClick= "myprint()"/>
<asp:Button ID="btnClose" Text="Close" ToolTip="Close" CssClass="btn btn-large btn-warning" runat="server" />
    </div></div>
     </section>                                                      
     
    </div>
    </form>
</body>
</html>
