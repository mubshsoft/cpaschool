<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AddAssignmentSet.aspx.cs" Inherits="Admin_AddAssignmentSet" Title="Assignment Set"%>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Assignment Set</title>--%>

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
    <h1 class="heading-color">Assignment Set</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Assignment Set</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
         <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <fieldset>
    <legend>Add new assignment</legend>
     
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:TextBox ID="txtAssignmentcode" ToolTip="Assignment Code" PlaceHolder="Assignment Code" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lblreqAssignmentcode" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
    <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlSem" AutoPostBack="true" ToolTip="Semester" PlaceHolder="Semester" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" />
    <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlModule" AutoPostBack="true" runat="server" ToolTip="Module" PlaceHolder="Module" CssClass="form-control" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" />
    <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlPaper" runat="server" ToolTip="Paper" PlaceHolder="Paper" CssClass="form-control"  />
    <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label>                                                                       
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">                                                                        
     <asp:DropDownList ID="ddlAssignmentType" runat="server" ToolTip="Assignment Type" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlAssignmentType_SelectedIndexChanged">
                                                                                        <asp:ListItem>Online</asp:ListItem>
                                                                                        <asp:ListItem>Offline</asp:ListItem>
                                                                                        <asp:ListItem>Manual</asp:ListItem>
                                                                                    </asp:DropDownList>  
     </div>
    </div> 
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="tronline" runat="server">                                                                    
     <asp:TextBox ID="txtTimeAllowted" runat="server" ToolTip="Time Alloted" PlaceHolder="Time Alloted" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="(In Minutes)" ></asp:Label>
                                                                                    <br />
    <asp:Label ID="lblTimeReq" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTimeAllowted" Display="Dynamic" ErrorMessage="<br>Please enter numeric values" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
</div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="trmanual" runat="server" visible="false">Upload Assignment
<asp:FileUpload ID="FileUpload1" runat="server" Font-Names="Tahoma" Font-Size="11px" />
<asp:Label ID="lblfileupload" runat="server" Text="" ForeColor="Red"></asp:Label>
</div>
</div>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
    <asp:HiddenField ID="hdncoursecode" runat="server" />
    </div>
    </div>                                                                      
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" PostBackUrl="#" OnClick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnClose" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" OnClick="btnClose_Click" />
    </div>
    </div>                                                                       
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
     <asp:CheckBox ID="chkuseAssignment" runat="server" Text="Use Existing Assignment" Visible="false" AutoPostBack="True" OnCheckedChanged="chkuseAssignment_CheckedChanged" CssClass="Style5" />
</div>
</div>
  
                                                                    </fieldset>
    </div>
    </div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
   <fieldset>
    <legend><strong class="style9_sec">View existing assignment</strong></legend>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
 <asp:DropDownList ID="ddlcoursefillter" runat="server" AutoPostBack="True" ToolTip="Course" PlaceHolder="Course" CssClass="form-control" OnSelectedIndexChanged="ddlcoursefillter_SelectedIndexChanged"> </asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" ToolTip="Year" CssClass="form-control" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" >
                                                                                                    <asp:ListItem>--Select--</asp:ListItem>
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
    </div>
   
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
    <asp:GridView ID="grdAssignmentSet" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="AsgnID" OnRowDataBound="grdAssignmentSet_RowDataBound" OnRowEditing="grdAssignmentSet_RowEditing" CssClass="table" 
                                                    OnRowUpdating="grdAssignmentSet_RowUpdating" OnRowCancelingEdit="grdAssignmentSet_RowCancelingEdit"
                                                                                        OnRowCommand="grdAssignmentSet_RowCommand" OnRowDeleting="grdAssignmentSet_RowDeleting">
                                                                                        <HeaderStyle CssClass="form_head" />
                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                       <Columns>
                                                                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <%# (grdAssignmentSet.PageSize * grdAssignmentSet.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Assignment Code">
                                                                                                <ItemStyle Width="50px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkbtnAsgnCode" runat="server" Text='<%#Eval("AssignmentCode")%>'
                                                                                                        CommandArgument='<%#Eval("AssignmentPath")%>' CommandName="manual"></asp:LinkButton>
                                                                                                    <asp:Label ID="lblAssignmentcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AssignmentCode")%>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <%-- <a id="a1" href="ShowAssignment.aspx?asgnid=<%#Eval ("AsgnId")%>">
                                                                  <%#Eval("AssignmentCode")%>
                                                                </a>
                                                      --%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Type">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lbltype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AssignmentType")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Course">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Semester">
                                                                                                <ItemStyle Width="65px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Module">
                                                                                                <ItemStyle Width="55px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Paper">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Time Alloted">
                                                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
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
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcreatedate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreateDate")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                                                ShowEditButton="True" ShowHeader="True" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:HiddenField ID="hdnAsgnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AsgnId")%>' />
                                                                                                    <asp:HiddenField ID="hdnAssignmentType" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AssignmentType")%>' />
                                                                                                    <asp:LinkButton ID="lnkDetailsAssignment" runat="server" Font-Underline="false" Text="Add Assignment Details"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkCopyAssignment" runat="server" Font-Underline="false" Text="Copy Questions"
                                                                                                        Visible="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEditDetailsAssignment" runat="server" Font-Underline="false"
                                                                                                        Text="Edit Assignment Details" CausesValidation="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDeleteAssignmentSet" runat="server" CommandName="Delete" CommandArgument='<%# Eval("AsgnId") %>'>
                                                                     Delete</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                                    </asp:GridView>
                                                                                    </div>
                                                                                    </div>
     </fieldset>
     </div>
     </div>  
     </div>          
     </ContentTemplate>
     </asp:UpdatePanel>
                                            
                                </div>
                            
        </div>
        
        </section></div>
    
    </form>
</asp:Content>
