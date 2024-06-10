<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Certificate.aspx.cs" Inherits="Admin_Certificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 <table width="80%">
        <tr><td align="left" valign="bottom" width="10%"><img id="Logo-fmsf" alt="FMSF" src="../images/Logo-fmsf.jpg" align="right" /> </td>
            <td align="center" valign="bottom" width="80%"><img id="Logo-cpa" alt="CPA" src="../../images/CPA.jpg"  /></td>
            <td width="10%">&nbsp;</td>
        </tr>
        <tr> <td colspan="3" align="center">&nbsp;</td></tr>
        <tr>
            <td colspan="3" align="center">
                CERTIFICATE OF COMPLETION<br /><br />
                AWARDED TO<br /><br />

                MR. <asp:Label ID="lblname" runat="server" Text=""></asp:Label> <br />
                 <p class="MsoNormal">
                        <span lang="EN-US">
                on successfully completing <asp:Label ID="lblCourse" runat="server" Text=""></asp:Label> <br /><br />
                <asp:Label ID="lblStartdate" runat="server" Text=""></asp:Label> &nbsp-&nbsp <asp:Label ID="lblEndtdate" runat="server" Text=""></asp:Label>
                    </span> 
                     </p> 
                </td>
                </tr>
     <tr>
            <td colspan="3">&nbsp;</td> 
                </tr>
            
             <tr>
            <td colspan="3" align="center" style="padding-top:20px;padding-bottom:10px;">
                <p class="MsoNormal">
                 <span lang="EN-US"><u><b>Course Faculty </b></u>
                <br />
                            DR. SANJAY PATRA<br />
                            MR. SANDEEP SHARMA<br />
                            MR. RAJESH BALANI
                     </span>
                    </p>
              
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
