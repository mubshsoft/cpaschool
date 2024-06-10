<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIDCard.aspx.cs" Inherits="Student_StudentIDCard" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
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

   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>


    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.4/jspdf.debug.js"></script>

 <%--   <script >
        var pdfdoc = new jsPDF();
        var specialElementHandlers = {

'#ignoreContent': function (element, renderer) {

    return true;

}

        };

 

        $(document).ready(function(){

            $("#gpdf").click(function(){
                
                pdfdoc.fromHTML($('#dvmain').html(), 10, 10, {

                    'width': 110,
                    'elementHandlers': specialElementHandlers

                

                });

                pdfdoc.save('IdCard.pdf');

            });});

 

        
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div id="PDFcontent">
<h3>First PDF</h3>

 

<p>Content to be written in PDF can be placed in this DIV!</p>

</div>

<div id="ignoreContent">

<p>Only for display and not in pdf</p>

</div>

<button id="gpdf">Generate PDF</button>--%>
        <div class="row">
        <div class="col-lg-12 col-md-12 col-xs-12" style="background: #0e245d; color:#fff; padding: 1em; text-align:center">
        <img src="../images/CPA.jpg" style="width: 100px; position: absolute; left: 2em; border-radius: 5px;" /><h2>CPA School of Learning</h2>
        </div> 
        </div>
        <div style="border: solid 1px #0e245d" >
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right; margin: 10px 0; padding-right: 30px;" >
           <div id="editor"></div>
            
            <asp:LinkButton ID="lnkDownload" runat="server"  ToolTip="Download Manuscript title page" visible="false"><i class="icon-download"  >Download</i></asp:LinkButton> 
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png"  ToolTip="Print" />
            </div></div>
           <div id="IdCard" runat="server" clientidmode="Static">
            <div class="row" id="dvmain">
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"><asp:Image ID="ProfilePhoto" runat="server" style="border-radius: 10px; margin: 10px;" CssClass="img-responsive" /></div>
        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
        <table class="table" id="tbl">
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
      
    </form>
</body>
</html>