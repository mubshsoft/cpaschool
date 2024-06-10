<%@ Page Language="C#" AutoEventWireup="true" CodeFile="closureletter.aspx.cs" Inherits="Admin_closureletter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        p.MsoNormal
        {
            margin-top: 0cm;
            margin-right: 0cm;
            margin-bottom: 10.0pt;
            margin-left: 0cm;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri" , "sans-serif";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                   <%--<asp:Image ID="Logo-fmsf" runat="server" />--%> 
                   <%--<img src="../images/add_course.png" style="border:0px"    />--%>
                   <img id="Logo-fmsf" alt="FMSF"
                        src="../Images/Logo-fmsf.jpg" align="right" />
                </td>
            </tr>
            <tr>
                <td>
                    <p class="MsoNormal" style="text-align: justify">
                        <span lang="EN-US">Date of Issue:
                            <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                            <br />
                            Batch Code:
                            <asp:Label ID="lblbatch" runat="server" Text="Label"></asp:Label>
                        </span>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                   <br /> 
                </td>
            </tr>
            <tr>
                <td>
                    <p class="MsoNormal" style="text-align: justify">
                        <span lang="EN-US">Dear
                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>, </span>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <p class="MsoNormal" style="text-align: justify">
                        <span lang="EN-US">
                            <%--You have successfully completed the online programme, Diploma in Financial management and Accountability (DFMA), a joint initiative of TISS and FMSF.--%>
                            You have successfully completed the online programme, <asp:Label ID="lblCourse" runat="server" Text=""></asp:Label>
                                , a joint initiative of TISS and FMSF.
                        </span>
                    </p>
                    <p class="MsoNormal" style="text-align: justify">
                        <span lang="EN-US">We wish you a successful career ahead.</span></p>
                    <%-- <br />
      You have completed Batch   <asp:Label ID="lblbatch" runat="server" Text="Label" Font-Bold="true"></asp:Label> 
     
    
    --%>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <p class="MsoNormal" style="text-align: justify">
                        <span lang="EN-US">Warm Regards,
                            <br />
                            <br />
                            <br />
                            Sanjay Patra 
                            <br />
                            Executive Director
                            </span>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
