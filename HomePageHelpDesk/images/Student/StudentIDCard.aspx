<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIDCard.aspx.cs" Inherits="Student_StudentIDCard" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <table >
                <tr>
                    <td> <div id="editor"></div>
                        <asp:LinkButton ID="lnkDownload" runat="server"  ToolTip="Download Manuscript title page" visible="false"><i class="icon-download"  >Download</i></asp:LinkButton> 

                    </td>
                    <td style="text-align:right;"><asp:ImageButton ID="ImageButton1" runat="server"   
                                                ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" 
                                                 />&nbsp;&nbsp;</td>
                </tr>
                <tr>

               <td colspan="2">
            <table width="700" border="0" cellspacing="0" cellpadding="0" id="IdCard" runat="server" >
                <tr align="left" valign="middle">
                    <td align="center" colspan="4">
                        <asp:Label ID="lblCoursename" runat="server" Text=""></asp:Label>
                    </td>
                    <td> &nbsp;</td>
                </tr>
                <tr align="left" valign="middle">
                    <td align="center" colspan="4">
                        <asp:Label ID="lblBactch" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <hr style="lighting-color:green;line-height:1px;" /> 
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td rowspan="4" style="width:150px; padding-left:20px;padding-right:5px;" >
                        <asp:Image ID="ProfilePhoto" runat="server" width="120px" Height="150px" />
                    </td>
                    <td style="width:10%">Name :</td>
                    <td colspan="2" style="text-align:left;">
                          <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%">Email :</td>
                    <td colspan="2">
                       <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%">DOB :</td>
                    <td colspan="2">
                       <asp:Label ID="lblDob" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td style="width:10%">Address :</td>
                    <td colspan="2">
                      <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2" style="text-align:left;padding-top:10px; ">
                   <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
                   </td>
                    </tr> 
                </table> 
        </div>
    </form>
</body>
</html>