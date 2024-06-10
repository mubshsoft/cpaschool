<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true"
    CodeFile="AddSampleSet.aspx.cs" Inherits="Admin_AddSampleSet" Title="Add SampleSet" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add SampleSet</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
        function HideMessage() {

            if (document.all) {
                document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
            }
            else {
                document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
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
    <h1 class="heading-color">Add Sample Set</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Sample Set</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <section class="container main m-tb">
        
                <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                  <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                  <fieldset>
                  <div class="user-info media box" style="background-color:#fff;">
                  <legend>Add new sample</legend>
                  <div class="row" >
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <asp:TextBox ID="txtSamplecode" runat="server" ToolTip="Sample Code" placeholder="Sample Code" CssClass="input-block-level"></asp:TextBox>
                  <asp:Label ID="lblreqSamplecode" runat="server" Text="" ForeColor="Red"></asp:Label>
                  </div>
                  </div>
                  <div class="row" >
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" CssClass="input-block-level" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
                  <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
                  </div>
                  </div>
                  <div class="row" >
                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                  <asp:TextBox ID="txtTimeAllowted" runat="server" ToolTip="Time alloted" placeholder="Time alloted" CssClass="input-block-level"></asp:TextBox>&nbsp;&nbsp;
                  <asp:Label ID="Label1" runat="server" Text="(In Minutes)" ></asp:Label>
                                                                                    <br />
                  <asp:Label ID="lblTimeReq" runat="server" Text="" ForeColor="Red"></asp:Label>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ControlToValidate="txtTimeAllowted" ErrorMessage="<br>Please enter numeric values" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
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
                                                    
                            <div class="row" >
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trmanual" runat="server" visible="false">
                           Upload Sample : <asp:FileUpload ID="FileUpload1" runat="server" />
                           <asp:Label ID="lblfileupload" runat="server" Text="" ForeColor="Red"></asp:Label>
                           </div>
                           </div>
                           <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdncoursecode" runat="server" /></div></div>
                           <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                           <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" 
                                   runat="server" PostBackUrl="#" onclick="btnSave_Click" />
                           <asp:Button ID="btnClose" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" />
                           </div></div>
                            <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:CheckBox ID="chkuseSample" runat="server" Text="Use Existing Sample" Visible="false" AutoPostBack="True" OnCheckedChanged="chkuseSample_CheckedChanged" />
                                                                                </div></div>
                                                                                </div>
                   </fieldset>
                    
                    <fieldset>
                    <div class="user-info media box" style="background-color:#fff;">
                    
                                                                        <legend>View existing sample</legend>
                                                                        <div class="row" >
                                                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlcoursefillter" runat="server" AutoPostBack="True" CssClass="input-block-level" ToolTip="Course"
                                                                                                    OnSelectedIndexChanged="ddlcoursefillter_SelectedIndexChanged">
                                                                                                </asp:DropDownList></div>
                                                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" CssClass="input-block-level" ToolTip="Year"
                                                                                                    OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" >
                                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                                    <asp:ListItem>2008</asp:ListItem>
                                                                                                    <asp:ListItem>2009</asp:ListItem>
                                                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                                                </asp:DropDownList></div>
                                                                        </div>
                                                                        </div>
                                                                        <div class="user-info media box" style="background-color:#fff;">
                                                                       <div class="row" >
                                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        
                                                                                    <asp:GridView ID="grdSampleSet" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                                                        DataKeyNames="SamId" OnRowDataBound="grdSampleSet_RowDataBound" OnRowEditing="grdSampleSet_RowEditing"
                                                                                        OnRowUpdating="grdSampleSet_RowUpdating" OnRowCancelingEdit="grdSampleSet_RowCancelingEdit"
                                                                                        OnRowCommand="grdSampleSet_RowCommand" OnRowDeleting="grdSampleSet_RowDeleting"
                                                                                        PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                                                        PageSize="10" OnPageIndexChanging="grdExamSet_PageIndexChanging" AllowPaging="True">
                                                                                        <HeaderStyle CssClass="form_head" />
                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <%# (grdSampleSet.PageSize * grdSampleSet.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Sample Code">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSamplecodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SampleCode")%>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <a id="a1" href="ShowSample.aspx?Samid=<%#Eval ("SamId")%>">
                                                                                                        <%#Eval("SampleCode")%>
                                                                                                    </a>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Course">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
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
                                                                                            <asp:TemplateField HeaderText="Time Allotted">
                                                                                                <ItemStyle HorizontalAlign="Left"  />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeAllowted" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem, "TimeAllowted")%>'></asp:Label>
                                                                                                    &nbsp;
                                                                                                </ItemTemplate>
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="txtTimeAllowted" runat="server" MaxLength="300" CssClass="NormalText"
                                                                                                        Text='<%# Bind("TimeAllowted") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                                                ShowEditButton="True" ShowHeader="True" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:HiddenField ID="hdnSamId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SamId")%>' />
                                                                                                    <asp:HiddenField ID="hdnSampleType" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "SampleType")%>' />
                                                                                                    <asp:LinkButton ID="lnkDetailsSample" runat="server" Font-Underline="false" Text="Add Sample Details"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkCopySample" runat="server" Font-Underline="false" Text="Copy Questions"
                                                                                                        Visible="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEditDetailsSample" runat="server" Font-Underline="false" Text="Edit Sample Details"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDeleteSampleSet" runat="server" CommandName="Delete" CommandArgument='<%# Eval("SamId") %>'>
                                                                     Delete</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                                    </asp:GridView>
                                                                               
                    
                    </ContentTemplate>
                    </asp:UpdatePanel>
                                           

                        </div>
                        </div>
                        </section>
    </div>
    </form>
</asp:Content>
