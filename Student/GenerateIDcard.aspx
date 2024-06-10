<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="GenerateIDcard.aspx.cs" Inherits="Student_GenerateIDcard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript">

    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var strOldOne = prtContent.innerHTML;
        var WinPrint = window.open('', '', 'left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
    
    </script>
   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>

    <script language="javascript" type="text/javascript" >



        $("body").on("click", "#lnkDownload", function () {
            alert('hi');
            html2canvas($('#IdCard')[0], {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("Table.pdf");
                }
            });
        });

        
</script>
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
.id-header-logo {text-align:left;}
.id-header {text-align: left; padding-left: 5em;}

@media only screen and (max-width: 1440px) {
.id-header-logo {text-align:left;}
.id-header {text-align: left; padding-left: 5em;}
}
@media only screen and (max-width: 768px) {
.id-header-logo {text-align:center;}
.id-header {text-align: center; padding:0; }
}
@media only screen and (max-width: 425px) {

}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Generate ID Card
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Generate ID Card</li>
          </ol>
        </section>
        <section class="content">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right; margin: 10px 0; padding-right: 30px;" >
           <div id="editor"></div>
            <asp:LinkButton ID="lnkDownload" runat="server"  ToolTip="Download Manuscript title page" visible="false"><i class="icon-download"  >Download</i></asp:LinkButton> 
            <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png"  ToolTip="Print" />--%>
                        <a ID="ImageButton1" runat="server" ToolTip="Print" class="btn btn-warning" target="_blank" >Print</a>
            </div></div>
             <div class="row"  id="IdCard">
             <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" >
             &nbsp;
             </div>
<div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
              <div class="box box-border">
              <div class="box-header " style="font-weight: 600; font-size: 14px; text-align: center;  background: #0e245d!important;color: #fff;border-top-left-radius: 5px; border-top-right-radius: 5px;">
              <div class="row">
        <div class="col-lg-3 col-md-2 col-sm-12 col-xs-12 id-header-logo" >
        <img src="../images/CPA.jpg" style="width: 100px; border-radius: 5px; margin-left: 1em;" /></div>
<div class="col-lg-9 col-md-10 col-sm-12 col-xs-12 id-header"  ><h2>CPA School of Learning</h2>
        </div> 
        </div>
               </div>
              <div class="box-body">
              <div class="row">
          <div >
            <div class="row">
        <div class="col-lg-4 col-md-3 col-sm-3 col-xs-12" style="padding-left:2em"><asp:Image ID="ProfilePhoto" runat="server"  style="border-radius: 10px; margin: 10px; display: block;  max-width: 80%; height: auto;" /></div>
        <div class="col-lg-8 col-md-9 col-sm-9 col-xs-12">
        <table class="table">
        <tr><td>Name :</td><td><asp:Label ID="lblname" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Email :</td><td><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>DOB :</td><td><asp:Label ID="lblDob" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Address :</td><td><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Course :</td><td><asp:Label ID="lblCoursename" runat="server" Text=""></asp:Label></td></tr>
        <tr><td>Batch :</td><td><asp:Label ID="lblBactch" runat="server" Text=""></asp:Label></td></tr>
        </table>
        </div>
        </div>
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" />
        </div>
        </div>
         
           </div>
            </div>
              </div>
              </div>
              </div>
                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" >
             &nbsp;
             </div>
              </div>
         
            

       </section>
       </div>



</asp:Content>

