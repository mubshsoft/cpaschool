<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="EndAssignment.aspx.cs" Inherits="EndAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
        }
    </script>

    <script language="javascript" type="text/javascript">
        <%--function HideMessage() {

            if (document.all) {
                document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
            }
            else {
                document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
            }
        }--%>
    </script>
    
<script type="text/JavaScript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
</script>
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
   <section class="content-header">
          <h1>
            End Assignment
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">End Assignment</li>
          </ol>
        </section>
  <section class="content">
        
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <strong><asp:Label ID="lblCaption" runat="server" /></strong>
                                                            <div class="box"><div class="box-body" style="text-align:center; padding: 10em 0">
                                                            <img src="../Images/thank_u.jpg" />
                                                            </div>
                                                            </div>
                                                             <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lbltxt" runat="server"  CssClass="style5"></asp:Label>  
                                                                                            </div>
                                                                                            </div>
                                                             <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" />
                                                 <asp:HiddenField ID="hdnusername" runat="server" />
                                </div>
                                </div>
                                </div>
    </div>
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
   </asp:Content>         
