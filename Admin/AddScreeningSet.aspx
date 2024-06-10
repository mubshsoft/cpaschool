<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AddScreeningSet.aspx.cs"
    Inherits="Admin_AddScreeningSet" Title="Add ScreeningSet" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add ScreeningSet</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

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
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
        }
    </style>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Add Screening Set</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Screening Set</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
    <section class="container main m-tb">
     
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                </div>
                                                                </div>
                                                         
                                                                    <fieldset>
                                                                    <div class="user-info media box" style="background-color:#fff;">
                                                                        <h4>Add new screening</h4>
                                                                        <div class="row">
                                                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtScreeningcode" runat="server" ToolTip="Screening Code" placeholder="Screening Code" CssClass="form-control"></asp:TextBox>
                                                                                    <asp:Label ID="lblreqScreeningcode" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                    </div>
                                                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" placeholder="Course Code" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
                                                                                    <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                        </div>
                                                                        </div>
                                                                        
                                                                            <%-- 
                                                      <tr>
                                                        <td align="right" style="padding-right:10px" class="style5">
                                                            Semester : </td>
                                                        <td align="center">
                                                            </td>
                                                        <td align="left" >
                                                          <asp:DropDownList ID="ddlSem" AutoPostBack="true"  runat="server" 
                                                                CssClass="DropDownStyle11" 
                                                                onselectedindexchanged="ddlSem_SelectedIndexChanged"/>
                                                                <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       
                                                       </td>
                                                    </tr>
                                                   
                                                 
                                                      <tr >
                                                        <td align="right" style="padding-right:10px" class="style5">
                                                            Module :</td>
                                                        <td align="center">
                                                            </td>
                                                        <td align="left" >
                                                          <asp:DropDownList ID="ddlModule" AutoPostBack="true"  runat="server" 
                                                                CssClass="DropDownStyle11" 
                                                                onselectedindexchanged="ddlModule_SelectedIndexChanged" /><asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       
                                                             </td>
                                                    </tr>
                                                   
                                                 
                                                      <tr>
                                                        <td align="right" style="padding-right:10px" class="style5">
                                                            Paper :</td>
                                                        <td align="center">
                                                            </td>
                                                        <td align="left" >
                                                          <asp:DropDownList ID="ddlPaper"  runat="server" 
                                                                CssClass="DropDownStyle11" />
                                                       <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                             </td>
                                                    </tr>--%>
                                                                            <%-- <tr>
                                                        <td align="right" style="padding-right:10px" class="style5">
                                                            Screening Type :</td>
                                                        <td align="center">
                                                            &nbsp;</td>
                                                        <td align="left" >
                                                          <asp:DropDownList ID="ddlScreeningType"  runat="server" 
                                                                CssClass="DropDownStyle11" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlScreeningType_SelectedIndexChanged" >
                                                              <asp:ListItem>Online</asp:ListItem>
                                                          
                                                            </asp:DropDownList>
                                                             </td>
                                                    </tr>--%>
                                                                        <div class="row">
                                                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="tronline" runat="server"><asp:TextBox ID="txtTimeAllowted" runat="server" ToolTip="Time alloted" placeholder="Time alloted" CssClass="form-control"></asp:TextBox>
                                                                        <asp:Label ID="Label1" runat="server" Text="(In Minutes)" ></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lblTimeReq" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="txtTimeAllowted"
                                                                                        ErrorMessage="<br>Please enter numeric values" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                                                          </div>
                                                                          <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="trmanual" runat="server" visible="false"><asp:FileUpload ID="FileUpload1" ToolTip="Upload Screening" runat="server"  />
                                                                                    <asp:Label ID="lblfileupload" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                    </div>
                                                                                    </div>
                                                                                <div class="row">
                                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                                    <asp:HiddenField ID="hdncoursecode" runat="server" />
                                                                                </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                                                    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" PostBackUrl="#" OnClick="btnSave_Click" />
                                                                                    <asp:Button ID="btnClose" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx" />
                                                                                </div>
                                                                                </div>
                                                                           <div class="row">
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                                    <asp:CheckBox ID="chkuseScreening" runat="server" Text="Use Existing Screening" Visible="false"
                                                                                        AutoPostBack="True" OnCheckedChanged="chkuseScreening_CheckedChanged" CssClass="Style5" />
                                                                               </div>
                                                                               </div>
                                                                               </div>
                                                                    </fieldset>
                                                                
                                                                    <fieldset>
                                                                    <div class="row">&nbsp;</div>
                                                                    <div class="user-info media box" style="background-color:#fff;">
                                                                        <h4>View existing screening</h4>
                                                                        <div class="row">
                                                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" ToolTip="Year" CssClass="form-control" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" >
                                                                                                    <asp:ListItem>--Select Year--</asp:ListItem>
                                                                                                    <asp:ListItem>2008</asp:ListItem>
                                                                                                    <asp:ListItem>2009</asp:ListItem>
                                                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                </div>
                                                                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
                                                                        </div>
                                                                         <div class="row">
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">              
                                                                                    <asp:GridView ID="grdScreeningSet" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                                                        DataKeyNames="ScrID" OnRowDataBound="grdScreeningSet_RowDataBound" OnRowEditing="grdScreeningSet_RowEditing"
                                                                                        OnRowUpdating="grdScreeningSet_RowUpdating" OnRowCancelingEdit="grdScreeningSet_RowCancelingEdit"
                                                                                        OnRowCommand="grdScreeningSet_RowCommand" OnRowDeleting="grdScreeningSet_RowDeleting"
                                                                                        PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                                                        PageSize="10" OnPageIndexChanging="grdExamSet_PageIndexChanging" AllowPaging="True">
                                                                                        <HeaderStyle CssClass="form_head" />
                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                                                        <EmptyDataTemplate>
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="100%" align="center" style="padding-right: 10px">
                                                                                                        <font color="#4b4b4b"><strong>No records </strong></font>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </EmptyDataTemplate>
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <%# (grdScreeningSet.PageSize * grdScreeningSet.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Screening Code">
                                                                                                <ItemStyle Width="50px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblScreeningcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ScreeningCode")%>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <a id="a1" href="ShowScreening.aspx?Scrid=<%#Eval ("ScrId")%>">
                                                                                                        <%#Eval("ScreeningCode")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Course Title">
                                                                                                <ItemStyle Width="210px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Time Alloted">
                                                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeAllowted" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "TimeAllowted")%>'></asp:Label>
                                                                                                    &nbsp;
                                                                                                </ItemTemplate>
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="txtTimeAllowted" runat="server" MaxLength="300" CssClass="NormalText"
                                                                                                        Text='<%# Bind("TimeAllowted") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Date of creation">
                                                                                                <ItemStyle Width="210px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcreateDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreateDate")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                                                ShowEditButton="True" ShowHeader="True" />
                                                                                            <%--   <asp:TemplateField HeaderText="Semester">
                                                        <ItemStyle Width="65px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle  Width="55px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Paper" >
                                                        <ItemStyle  Width="110px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>--%>
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:HiddenField ID="hdnScrId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ScrId")%>' />
                                                                                                    <asp:HiddenField ID="hdnScreeningType" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ScreeningType")%>' />
                                                                                                    <asp:LinkButton ID="lnkDetailsScreening" runat="server" Font-Underline="false" Text="Add Screening Details"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkCopyScreening" runat="server" Font-Underline="false" Text="Copy Questions"
                                                                                                        Visible="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEditDetailsScreening" runat="server" Font-Underline="false"
                                                                                                        Text="Edit Screening Details" CausesValidation="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDeleteScreeningSet" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ScrId") %>'>
                                                                     Delete</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                                    </asp:GridView>
                                                                              </div>
                                                                              </div> 
                                                                              </div> 
                                                                    </fieldset>
                                                                
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </section>
                
    </div>
    </form>
</asp:Content>
