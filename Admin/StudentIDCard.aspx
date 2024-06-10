<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="StudentIDCard.aspx.cs" Inherits="Admin_StudentIDCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script language="javascript" type="text/javascript">
              
                        function CallPrint(strid)
                          {
                           var prtContent = document.getElementById("IdCard");
                           var strOldOne=prtContent.innerHTML;
                           var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
                           WinPrint.document.write(prtContent.innerHTML);
                           WinPrint.document.close();
                           WinPrint.focus();
                           WinPrint.print();
                           WinPrint.close();
                           prtContent.innerHTML=strOldOne;
                          }
    </script>
<style>
    body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
    .id-card 
    {
        background: #0e245d;
    color: #fff!important;
    padding: 1em;
    text-align: center;
    height: 6em;
    border-top-left-radius: 1em;
    border-top-right-radius: 1em;
    }
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Student ID Card</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a></li>
       <li class="active">Student ID Card</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right; margin:10px 0">
        <asp:Button ID="ImageButton1" runat="server"  CssClass="btn btn-large btn-warning" text="Print"  ToolTip="Print" Visible="false" />
             <a href="#" id="lnkprint" runat="server"  class="btn btn-large btn-warning">Print</a>                                    
                                                 </div>
                                                 </div>
    <div class="row" id="IdCard" clientidmode="Static">
        <div class="col-lg-12 col-md-12 col-xs-12 id-card">
        <img src="../images/CPA.jpg" style="width: 100px; position: absolute; left: 2em; border-radius: 5px;" /><h2 style="color:#fff">CPA School of Learning</h2>
        </div> 
        </div>
        <div class="row" style="border: solid 1px #fff; background:#fff">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    
    <div class="row" >
    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="text-align:center"><asp:Image ID="ProfilePhoto" runat="server" width="120px" Height="150px" /></div>
    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
    <table class="table">
        <tr><td>Name :</td><td><asp:Label ID="lblname" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Email :</td><td><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>DOB :</td><td><asp:Label ID="lblDob" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Address :</td><td><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Course :</td><td><asp:Label ID="lblCoursename" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Batch :</td><td><asp:Label ID="lblBactch" runat="server" Text=""></asp:Label></td></tr>
    </table>

    <div class="col-lg-12 col-md-12  col-sm-12 col-xs-12">
    
    
    </div>
    </div>
     
     </div>
     </div></div>
      <div class="row">&nbsp;</div>
              
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                   <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click" />
                    </div>
                    </div>
               
             
             </section>     
    </form>
    </asp:Content>
