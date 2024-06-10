<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActiveAssignmentReport.aspx.cs" Inherits="Report_ActiveAssignmentReport" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

   
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Assign Assignment Report</title>
    <script type="text/javascript" src="../stmenu.js"></script>
  <script language="javascript" type="text/javascript">


  function closepopup()
{    
    window.close();
}
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


//}


    </script>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000;   font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828;   height:15px;  }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828;   height:15px;  }
    </style>
</head>
<body>
 <div id='popCal' style='POSITION:absolute;visibility:hidden;border:2px ridge;width:10'>
<iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152" height="147"></iframe>
</div>
    <form id="form1" runat="server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <div>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
      
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td height="127" align="left" valign="top">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame">
                           
                                    <table width="700" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">
                                                            <asp:Label ID="lblCaption" runat="server" />
                                                            </strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="../Admin/Adminlogin.aspx"><font color="#4b4b4b">
                                                            Back To Admin Panel</font></a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx" class="part1">
                                                                    <font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td align="left" width="3">
                                            </td>
                                            <td align="center" class="style5" height="100%" 
                                                style="padding-top: 0px; padding-bottom: 20px;">
                                                <table width="420px">
                                                    <tr>
                                                        <td align="right" class="style5" style="padding-right:10PX; " width="250px">
                                                            Course : </td>
                                                        <td align="left" class="style9_sec" width="300px">
                                                              <asp:DropDownList ID="ddlCourse" AutoPostBack="true"  runat="server" 
                                                                    CssClass="DropDownStyle11" 
                                                                    onselectedindexchanged="ddlCourse_SelectedIndexChanged" /><asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="right" class="style5" style="padding-right:10PX; " width="250px">
                                                            Batch :</td>
                                                        <td align="left" class="style9_sec" width="300px">
                                                              <asp:DropDownList ID="ddlbatch" AutoPostBack="true"  runat="server" 
                                                                    CssClass="DropDownStyle11" 
                                                                     /></td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="right" class="style5" style="padding-right:10PX; " width="250px">
                                                            From Activate Date :</td>
                                                        <td align="left" class="style5" width="300px">
                                                            <asp:TextBox ID="txtfrmdt" runat="server"></asp:TextBox><input id="calimg" runat="server" onclick="popFrame.fPopCalendar(txtfrmdt,txtfrmdt,popCal);return false" type="image"  src="~/Images/cal.jpg" style="vertical-align: bottom; width: 22px; height: 22px" />
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="right" class="style5" style="padding-right:10PX; " width="250px">
                                                            To actvate Date :</td>
                                                        <td align="left" class="style5" width="300px">
                                                             <asp:TextBox ID="txttodt" runat="server"></asp:TextBox><input id="Image1" runat="server" onclick="popFrame.fPopCalendar(txttodt,txttodt,popCal);return false" type="image"  src="~/Images/cal.jpg" style="vertical-align: bottom; width: 22px; height: 22px" /></td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="right" class="style9_sec" style="padding-right:10PX; " width="250px">
                                                            &nbsp;</td>
                                                        <td align="left" class="style9_sec" width="300px">
                                                            <asp:Button ID="Button1" runat="server" Text="GetReport" 
                                                                onclick="Button1_Click" />
                                                        </td>
                                                    </tr>
                                                   
                                                </table>
                                                
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td align="center">
                                 <div id="print_grid" class="style5" runat="server" visible="false">
                                     <fieldset>
                                            <legend class="style9_sec"><b>Assign Assignment list</b></legend>
                                           <br />
                                         <table width="100%">
                                         <tr><td>
                                         <table width="100%">
                                         <tr>
                                         <td  Width="30%" align="right" style="padding-right:10px; font-family:Tahoma; font-size:11px">
                                         <b>Course :</b>
                                         </td>
                                          <td Width="20%" align="left" style=" font-family:Tahoma; font-size:11px">
                                        <asp:Label ID="lblcourse" runat="server" ></asp:Label>
                                         </td>
                                          <td Width="20%" align="right" style="padding-right:10px; font-family:Tahoma; font-size:11px">
                                         <b>Batch :</b>
                                         </td>
                                          <td Width="30%" align="left" style=" font-family:Tahoma; font-size:11px">
                                        <asp:Label ID="lblbatch" runat="server" ></asp:Label>
                                         </td>
                                         </tr>
                                          <tr>
                                         <td  align="right" style="padding-right:10px; font-family:Tahoma; font-size:11px">
                                         <b>Activate From&nbsp; Date :</b>
                                         </td>
                                          <td align="left" style=" font-family:Tahoma; font-size:11px">
                                        <asp:Label ID="lblactivatedt" runat="server" ></asp:Label>
                                         </td>
                                          <td align="right" style="padding-right:10px; font-family:Tahoma; font-size:11px">
                                             <b> Activate To Date :</b>
                                         </td>
                                          <td align="left" style=" font-family:Tahoma; font-size:11px">
                                         <asp:Label ID="lbltoactivatedt" runat="server" ></asp:Label>
                                         </td>
                                         </tr>
                                          <tr>
                                         <td align="right" style="padding-right:10px; font-family:Tahoma; font-size:11px" 
                                                  colspan="4">
                                             &nbsp;</td>
                                         </tr>
                                         </table>
                                         </td></tr>
                                            <tr><td>
                                                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%"  AllowPaging="false"   
                                                    HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff" EnableModelValidation="True" PageSize="20" onpageindexchanging="grdReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Title"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "coursetitle")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "batchcode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="Assignment Code "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "AsgnCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Semester "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsem" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "semestertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Paper Title "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpaper" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Activate Date "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactvate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "activatedate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Deactivate Date "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldeactivate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "deactivatedate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                             </td></tr>
                                          </table> 
                                       </fieldset>
                                   </div>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                          <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td align="center">
                                            
                                                      &nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/close.png" 
                                                   PostBackUrl="~/Report/ReportList.aspx"  />
                                                      &nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" />
                                                  
                                                    
                                             
                                               
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                     
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <uc2:Footer ID="Footer1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
   </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    
                                                        
    </form>
</body>
</html>
