<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print1.aspx.cs" Inherits="Student_print1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <style>
.box-border {border: solid 1px #e2e2e2;border-radius: 5px;}
.box-header1 {
    font-weight: 600;
    font-size: 14px;
    text-align: center;
    background: #0e245d;
    color: #fff;
    border-top-left-radius: 5px;
    border-top-right-radius: 5px;
}
@media print {

    .header, .footer, .navigation{

    display: none !important; 

    } 
}
</style>
</head>
<body onload="javascript:printtest();">
    <form id="form1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right; margin: 10px 0; padding-right: 30px;" >
           <div id="editor"></div>
        <%--   <a onclick="" class="btn btn-warning">Print</a>
            --%>
            </div></div>
             <div class="row"  id="IdCard">
           
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin:5em 20em">
              <div class="box box-border" style="width:605px">
              <div class="box-header" style="font-weight: 600; font-size: 14px; text-align: center;  background: #0e245d!important;color: #fff;border-top-left-radius: 5px; border-top-right-radius: 5px;">
              <div class="row">
        <div class="col-lg-6 col-md-6 col-xs-12" >
        <img src="../images/CPA.jpg" style="width: 100px; position: absolute; left: 2em; border-radius: 5px;" /></div>
<div class="col-lg-6 col-md-6 col-xs-12" style="margin-left:75px" ><h2 style="color:#fff!important;">CPA School of Learning</h2>
        </div> 
        </div>
               </div>
              <div class="box-body">
              <div class="row">
          <div >
            <div class="row">
            
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4" style="margin-left:1em"><asp:Image ID="ProfilePhoto" runat="server" style="border-radius: 10px; margin: 10px; display: block;  max-width: 80%; height: auto;"  /></div>
        <div class="col-lg-7 col-md-7 col-sm-7 col-xs-7">
        <table class="table" style="width:90%">
        <tr><td>Name :</td><td><asp:Label ID="lblname" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Email :</td><td><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>DOB :</td><td><asp:Label ID="lblDob" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Address :</td><td><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Course :</td><td><asp:Label ID="lblCoursename" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Batch :</td><td><asp:Label ID="lblBactch" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </div>
        </div>
        
         
           </div>
            </div>
              </div>
              </div>
              </div>
               
              </div>
              <script>
                  function printtest() {
                   window.onafterprint = window.close;
         window.print();
                  }

              </script>
    </form>
</body>
</html>
