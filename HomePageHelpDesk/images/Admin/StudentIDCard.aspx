<%@ Page Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="StudentIDCard.aspx.cs" Inherits="Admin_StudentIDCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script language="javascript" type="text/javascript">
              
                        function CallPrint(strid)
                          {
                           var prtContent = document.getElementById(strid);
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
<style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
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
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right">
        <asp:Button ID="ImageButton1" runat="server"  CssClass="btn btn-large btn-warning" text="Print"  ToolTip="Print" 
                                                 /></div>
                                                 </div>
    <div class="row" id="IdCard" runat="server">
    <div class="col-lg-12 col-md-12  col-sm-12 col-xs-12">
    <asp:Label ID="lblCoursename" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblBactch" runat="server" Text=""></asp:Label>
    </div>
    </div>
    <div class="row">
     <div class="col-lg-5 col-md-5  col-sm-12 col-xs-12" style="text-align:right"><asp:Image ID="ProfilePhoto" runat="server" width="120px" Height="150px" /></div>   
     <div class="col-lg-7 col-md-7  col-sm-12 col-xs-12">
     Name :  <asp:Label ID="lblname" runat="server" Text=""></asp:Label><br /><br />
     Email : <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label><br /><br />
     DOB : <asp:Label ID="lblDob" runat="server" Text=""></asp:Label><br /><br />
     Address : <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
     </div>           
     </div>  <div class="row">&nbsp;</div>
              
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                   <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click" />
                    </div>
                    </div>
      </div>             
             
             </section>     
    </form>
    </asp:Content>
