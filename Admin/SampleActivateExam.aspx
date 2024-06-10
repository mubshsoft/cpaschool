<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SampleActivateExam.aspx.cs" Inherits="Admin_SampleActivateExam" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Use Existing Sample</title>
<script type="text/javascript" src="../stmenu.js"></script>
 <script language="javascript" type="text/javascript" src="../datetimepicker.js">
    </script>
   <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
                     }
    </script>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-family:Verdana,Arial,Tahoma; font-size:10px; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <div id='popCal' style='POSITION:absolute;visibility:hidden;border:2px ridge;width:10'>
<iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152" height="147"></iframe>
</div>
    <div onkeypress="HideMessage()">
  
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
                                <div class="frame" style="width:701px">
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b">Back To 
                                                            Admin Panel</font></a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx" class="part1">
                                                                    <font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 0px; padding-bottom: 20px;">
                                             
                                                <table width="550px">
                                                   
                                                    <tr>
                                                        <td colspan="2" align="center" > <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td width="250px" align="right" style="padding-right:5PX; " class="style9_sec">
                                                             &nbsp;</td>
                                                        <td width="300px" align="left" class="style9_sec" >
                                                            &nbsp;</td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td width="250px" align="right" style="padding-right:10PX; " class="style5">
                                                             SampleSet :</td>
                                                        <td width="300px" align="left" class="style9_sec" >
                                                     
                                                            <asp:DropDownList ID="ddlSampleset" runat="server"   CssClass="DropDownStyle11" 
                                                                AutoPostBack="True" 
                                                                onselectedindexchanged="ddlSampleset_SelectedIndexChanged"  >
                                                            </asp:DropDownList>
                                                       
                                                        </td>
                                                    </tr>
                                                  
                                               <%--     <tr>
                                                        <td width="250px" align="right" style="padding-right:5PX; " class="style9_sec">
                                                             &nbsp;</td>
                                                        <td width="300px" align="left" class="style9_sec" >
                                                            &nbsp;</td>
                                                    </tr>--%>
                                                  
                                            
                                                
                                                  
                                                 
                                                
                                                  
                                                  <%--  <tr>
                                                        <td width="250px" align="right" style="padding-right:10PX" class="style9_sec">
                                                            Batch Code :</td>
                                                        <td width="300px" align="left" class="style9_sec">
                                                       
                                                            <asp:DropDownList ID="ddlbatch" runat="server"   
                                                                CssClass="DropDownStyle11"
                                                               >
                                                            </asp:DropDownList>
                                                             
                                                           
                                                        </td>
                                                    </tr>--%>
                                                
                                                  
                                                   <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                                                                                                       
                                                    <tr>
                                                        <td width="250px" align="right" style="padding-right:5PX" class="style9_sec">
                                                            &nbsp;</td>
                                                        <td width="300px" align="left" class="style9_sec">
                                                            &nbsp;</td>
                                                    </tr>
                                                
                                                  
                                                    <tr>
                                                        <td align="right" class="style5" style="padding-right:10PX" width="250px">
                                                            Batch Code :</td>
                                                        <td align="left" class="style9_sec" width="300px">
                                                            <asp:DropDownList ID="ddlbatch" runat="server" CssClass="DropDownStyle11">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="style9_sec" style="padding-right:5PX" width="250px">
                                                            &nbsp;</td>
                                                        <td align="left" class="style9_sec" width="300px">
                                                            &nbsp;</td>
                                                    </tr>
                                                
                                                  
                                                    <tr>
                                                        <td width="250px" valign="top" align="right" style="padding-right:10PX" class="style5">
                                                            Activation Date :</td>
                                                        <td width="300px" align="left" class="style9_sec">
                                                            <asp:TextBox ID="txtactivateDate" runat="server" CssClass="style11"></asp:TextBox>
                                                            <input id="calimg" runat="server" onclick="popFrame.fPopCalendar(txtactivateDate,txtactivateDate,popCal);return false" type="image"  src="~/Images/cal.jpg" style="vertical-align: bottom; width: 22px; height: 22px" />&nbsp;<asp:Label ID="lblactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                
                                                  
                                                     <tr>
                                                        <td width="150px">
                                                            &nbsp;
                                                        </td>
                                                        <td width="350px" align="left" valign="middle">
                                                            &nbsp;</td>
                                                    </tr>
                                                     <tr>
                                                        <td width="250px" valign="top" align="right" style="padding-right:10PX" class="style5">
                                                            Deactivation Date :</td>
                                                        <td width="300px" align="left" class="style9_sec">
                                                            <asp:TextBox ID="txtDeactivateDate" runat="server" CssClass="style11"></asp:TextBox><input id="Image1" runat="server" onclick="popFrame.fPopCalendar(txtDeactivateDate,txtDeactivateDate,popCal);return false" type="image"  src="~/Images/cal.jpg" style="vertical-align: bottom; width: 22px; height: 22px" />&nbsp;<asp:Label ID="lblDeactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                
                                                    <tr>
                                                        <td width="150px">
                                                            <asp:HiddenField ID="hdnNewSamId" runat="server" />
                                                        </td>
                                                        <td width="350px" align="left" valign="middle" style="padding-top:10px;">
                                                            <asp:ImageButton ID="btnSave" runat="server"  
                                                                ImageUrl="../Images/save.png" onclick="btnSave_Click"/> &nbsp;<asp:ImageButton ID="btnBack" runat="server" 
                                                                ImageUrl="~/Images/back_button.jpg" onclick="btnBack_Click" />
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
                                                
                                                 <asp:GridView ID="grdSampleSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="SamId" onrowcancelingedit="grdSampleSet_RowCancelingEdit" 
                                                     onrowediting="grdSampleSet_RowEditing" onrowupdating="grdSampleSet_RowUpdating"  >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                       
                                                       <asp:TemplateField HeaderText="Sample Code">
                                                       <%-- <ItemStyle  Width="50px" />--%>
                                                       <ItemTemplate>
                                              <asp:Label ID="lblSamplecodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SamCode")%>'></asp:Label>
                                                         <%-- <a id="a1" href="javascript:openPopup('ActvateScreening_StudentList.aspx?scrid=<%#Eval("ExamId")%>&Courseid=<%#Eval("courseid")%>')">
                                                                <%#Eval("ExamCode") %></a>--%>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="Course Code">
                                                        <%--<ItemStyle Width="110px" />--%>
                                                       <ItemTemplate>
                                                       <asp:HiddenField ID="hdnSamId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SamId")%>' />
                                                                                               <asp:HiddenField ID="hdnbid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "courseid")%>' />
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "coursecode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="ActivateDate">
                                                       <%-- <ItemStyle Width="65px" />--%>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%# Eval("ActivateDate","{0:M-dd-yyyy}") %>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       <EditItemTemplate>
                                                         <asp:TextBox ID="txtActivateDate" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("ActivateDate","{0:M-dd-yyyy}") %>'></asp:TextBox>
                                                       </EditItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="DeactivateDate">
                                                       <%-- <ItemStyle  Width="55px" />--%>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%# Eval("DeactivateDate","{0:M-dd-yyyy}") %>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                        <EditItemTemplate>
                                                         <asp:TextBox ID="txtDeactivateDate" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("DeactivateDate","{0:M-dd-yyyy}") %>'></asp:TextBox>
                                                       </EditItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" 
                                                            HeaderStyle-Width="75px" ShowEditButton="True" ShowHeader="True" />
                                                       
                                                            
                                                          
                                                            
                                                             
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                
                                             </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="hdnSamId" runat="server" />
                                                <asp:HiddenField ID="hdnSectionId" runat="server" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        
                                    </table>
                                     </ContentTemplate>
                                                            </asp:UpdatePanel>
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
   
    </div>
   
    </form>
</body>
</html>
