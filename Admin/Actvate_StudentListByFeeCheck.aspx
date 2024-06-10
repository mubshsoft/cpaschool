<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actvate_StudentListByFeeCheck.aspx.cs"
    Inherits="Admin_Actvate_StudentListByFeeCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Activate Student Info</title>
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../Stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
    function closewin()
    {
    self.close();
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700" border="0" cellspacing="0" cellpadding="0">
            <tr align="left" valign="middle">
                <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                    <table width="100%">
                        <tr>
                            <td width="50%" align="left" style="padding-left: 10px">
                                <strong class="style9_sec">Activate Student Info</strong>
                            </td>
                            <td width="50%" align="right" style="padding-right: 10px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="left" valign="top">
                <td width="3" align="left">
                </td>
                <td height="100%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;">
                    <table width="700px">
                        <tr>
                            <td width="260px" align="right" style="padding-right: 20px">
                            </td>
                            <td width="40px" align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" align="center" style="padding-right: 10px;" colspan="2">
                                <fieldset>
                                    <legend style="font-family: Verdana; font-size: 11px; font-weight: bold"><b> Activated 
                                        Student (s) who&#39;s submitted Fee</b></legend>
                                    <br />
                                    
                                    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                        Width="100%" AllowPaging="True" PageSize="10" PagerSettings-FirstPageText="Fisrt"
                                        PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                        OnPageIndexChanging="grdInActiveStudent_PageIndexChanging">--%>
                                    
                                    <asp:GridView ID="grdInActiveStudent" runat="server" AutoGenerateColumns="False"
                                        Width="100%" AllowPaging="True" PageSize="10" PagerSettings-FirstPageText="Fisrt"
                                        PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                        OnPageIndexChanging="grdInActiveStudent_PageIndexChanging">
                                        <HeaderStyle CssClass="grid-header-Overtime" />
                                        <RowStyle CssClass="grid-row-Overtime" />
                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                        <HeaderStyle CssClass="grid-header-Overtime" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Student name">
                                                <%-- <ItemStyle  Width="50px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email ">
                                                <%--<ItemStyle Width="110px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbatch" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "userid")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ExamCode ">
                                                <%--<ItemStyle Width="110px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexamcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "examcode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Semester ">
                                                <%--<ItemStyle Width="110px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "semestertitle")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paper Title ">
                                                <%--<ItemStyle Width="110px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Activate ">
                                                <%--<ItemStyle Width="110px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblactvate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "activate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk" runat="server" />
                                                    <%--<asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("id") %>'>
                                                                     Deactivate</asp:LinkButton>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td width="150px" align="right" style="padding-right: 20px">
                                &nbsp;
                            </td>
                            <td width="150px" style="width: 300px" align="left">
                                &nbsp;
                                <asp:ImageButton ID="btnSave" ImageUrl="../Images/save.png" runat="server" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btnClose" ImageUrl="../Images/close.png" runat="server" OnClick="btnClose_Click" />
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
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
            <tr align="left" valign="top">
                <td>
                    &nbsp;
                </td>
                <td class="style5" align="center">
                    <fieldset>
                        <legend style="font-family: Verdana; font-size: 11px; font-weight: bold">List of 
                            Deactivated Student (s) who didn&#39;t submit Fee</legend>
                        <br />
                        <asp:GridView ID="grdActveStudent" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="True" PageSize="10" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last"
                            PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="grdActveStudent_PageIndexChanging"
                            OnRowCommand="grdActveStudent_RowCommand">

<PagerStyle HorizontalAlign="Center"></PagerStyle>

                            <HeaderStyle CssClass="grid-header-Overtime" />
<PagerSettings FirstPageText="Fisrt" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>

                            <RowStyle CssClass="grid-row-Overtime" />
                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                            <HeaderStyle CssClass="grid-header-Overtime" />
                            <Columns>
                                <asp:TemplateField HeaderText="Student name">
                                    <%-- <ItemStyle  Width="50px" />--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email ">
                                    <%--<ItemStyle Width="110px" />--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblbatch" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "userid")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExamCode ">
                                    <%--<ItemStyle Width="110px" />--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblexamcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "examcode")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semester ">
                                    <%--<ItemStyle Width="110px" />--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "semestertitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paper Title ">
                                    <%--<ItemStyle Width="110px" />--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activate ">
                                    <%--<ItemStyle Width="110px" />--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblactvate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "activate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("userid") %>'>Submitted 
                                        Fee</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                        </asp:GridView>
                    </fieldset>
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
