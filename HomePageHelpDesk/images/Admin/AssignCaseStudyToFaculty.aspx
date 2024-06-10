<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="AssignCaseStudyToFaculty.aspx.cs" Inherits="Admin_AssignCaseStudyToFaculty" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Submit Case Study</title>
     <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
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
</head>
<body>
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
                                    <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="padding-top:20px;padding-bottom:20px;padding-left:10px; font-size:large; text-align:center  "><strong> Assign Case Study to faculty</strong></td>
                                        </tr>
                                         <tr>
                                            <td style="padding-top:10px;padding-bottom:10px;padding-left:10px; font-size:large; text-align:center  ">
                                                <strong>  <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></strong>

                                            </td>
                                        </tr>
                                        <tr valign="top">
                                           
                                            <td style="padding-top: 2px;padding-left:10px; padding-bottom: 2px;">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                               
                                                    <tr>
                                                        <td colspan="2"> 
                                                           <fieldset>
                                                             <legend>Case Study Details</legend>
                                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                                  <tr>
                                                        <td width="30%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                            Case Study Type :</td>
                                                        <td width="70%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                           <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td width="30%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                            Case Study Code :</td>
                                                        <td width="70%"style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                           <asp:Label ID="lblAssignCode" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td width="30%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                            Course Title :</td>
                                                        <td width="70%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                           <asp:Label ID="lblCourseTitle" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                            Paper Title :</td>
                                                        <td width="70%" style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                           <asp:Label ID="lblPtitle" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                            </table>
                                                               </fieldset> 
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                            Faculty :</td>
                                                        <td style="padding-top:10px;padding-bottom:10px;padding-left:10px;">
                                                            <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td style="padding-left:10px;">
                                                            <asp:Imagebutton ID="btnSave" ImageUrl="../Images/save.png" runat="server" 
                                                                onclick="btnSave_Click"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:Imagebutton ID="btnClose" ImageUrl="../Images/close.png" runat="server" 
                                                                onclick="btnClose_Click"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            
                                        </tr>
                                       
                                    </table>
     <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                      
         <tr>
                                                        <td colspan="2"> 
                                                           <fieldset>
                                                             <legend>De-Activate Case Study from faculty</legend>
                                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                                  <tr>
                                                                      <td>
                                                                           <asp:GridView ID="grdActveFaculty" runat="server" AutoGenerateColumns="False"  CssClass="table"
                                                    Width="100%"  AllowPaging="True" PageSize="10"    
                                                            PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                            onrowcommand="grdActveFaculty_RowCommand" >
                                                    
                                                        <HeaderStyle Font-Bold="true" BackColor="ActiveBorder" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email ">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                           <asp:TemplateField HeaderText="Activate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactvate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "activate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                  
                                                       <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("id") %>'>
                                                                     Deactivate</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                       
                                                    </Columns>
                                                    
                                                </asp:GridView>
                                                                      </td>
                                                                      </tr>
                                                                </table> 
                                                               </fieldset> 
                                                            </td> 
             </tr> 
         </table> 
     </div>      
    </form>
</body>
</html>

