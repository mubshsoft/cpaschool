<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="ActivateExam.aspx.cs" Inherits="ActivateExam" Title="Activate Exam" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Activate Exam</title>--%>
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

    <script language="javascript" type="text/javascript">
  
function openPopup(strOpen)
    {
        open(strOpen, "Info", "status=1, width=700, height=430,resizable=yes,scrollbars=yes, top=200, left=200");
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
        .icon-position
        {
        position: absolute;
        right: 20px;
        top: 10px;
        }
    </style>
     <script language="javascript" type="text/javascript" src="../datetimepicker.js">
    </script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Activate Exam" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
       <%-- <li class="active">Instruction Summary</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div onkeypress="HideMessage()">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend>Assign New Exam</legend></div></div>
    <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Red" Text=""></asp:Label></div></div>
    <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">For Supplementary Exam : <asp:CheckBox ID="chbSupply" runat="server" /></div></div>
    <div class="row" ><div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlexamset" runat="server" ToolTip="Exam Set" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlexamset_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlbatch" runat="server" ToolTip="Batch Code" CssClass="form-control"></asp:DropDownList>
                            </div>
     </div>                            
    <div class="row" ><div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtactivateDate" runat="server" ToolTip="Activation Date" placeholder="Activation Date" CssClass="form-control"></asp:TextBox>
                                               <a href="javascript:NewCal('<%= txtactivateDate.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
                                               &nbsp;<asp:Label ID="lblactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtDeactivateDate" runat="server" ToolTip="Deactivation Date" placeholder="Deactivation Date" CssClass="form-control"></asp:TextBox>
                            <a href="javascript:NewCal('<%= txtDeactivateDate.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date"  class="icon-position"></a>
                            <asp:Label ID="lblDeactivateDate" runat="server" Text="" ForeColor="Red"></asp:Label></div>
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
                                                            
     <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:HiddenField ID="hdnNewexamid" runat="server" /></div></div>
     <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click" />
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" OnClick="btnBack_Click" />
     </div></div>
     </div>
     <div class="user-info media box" style="background-color:#fff;">
     <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend>Exams already assigned</legend></div></div>
     
     <div class="row" ><div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlcoursefillter" runat="server" AutoPostBack="True" placeholder="Course" CssClass="form-control" OnSelectedIndexChanged="ddlcoursefillter_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" placeholder="Year" CssClass="form-control" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" >
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
</div></div>
<div class="user-info media box" style="background-color:#fff;">
 <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto"> 
                                                        <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" PageSize="10" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                            AllowPaging="true" DataKeyNames="ExamID" OnRowCancelingEdit="grdExamSet_RowCancelingEdit"
                                                            OnRowEditing="grdExamSet_RowEditing" OnRowUpdating="grdExamSet_RowUpdating" Width="100%"
                                                            OnPageIndexChanging="grdExamSet_PageIndexChanging" OnRowDataBound="grdExamSet_RowDataBound" OnRowCommand="grdExamSet_RowCommand">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (grdExamSet.PageSize * grdExamSet.PageIndex) + Container.DisplayIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="For SupplyMentry Exam" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSupplyMentryExam" runat="server">
                                                                        </asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Exam Code" ItemStyle-HorizontalAlign="Left">
                                                                    <%-- <ItemStyle  Width="50px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnb_NormalStudent" runat="server" Text='<%#Eval("ExamCode") %>' CommandName="ExamCodeNormal" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                                                        <%--<asp:HyperLink ID="href_NormalStudent" runat="server" NavigateUrl="javascript:openPopup('Actvate_StudentList.aspx?Examid=<%#Eval("ExamId")%>&bid=<%#Eval("bid")%>')" Text='<%#Eval("ExamCode") %>'></asp:HyperLink>--%>
                                                                        <%--<asp:HyperLink ID="href_SupplyStudent" runat="server" NavigateUrl="javascript:openPopup('Actvate_StudentListByFeeCheck.aspx?Examid=<%#Eval("ExamId")%>&bid=<%#Eval("bid")%>')" Visible="false"  Text='<%#Eval("ExamCode") %>'></asp:HyperLink>--%>
                                                                        <%--<a id="a1" href="javascript:openPopup('Actvate_StudentList.aspx?Examid=<%#Eval("ExamId")%>&bid=<%#Eval("bid")%>')">
                                                                            <%#Eval("ExamCode") %></a>--%>
                                                                            <%--<a id="a1" href="javascript:openPopup('Actvate_StudentListByFeeCheck.aspx?Examid=<%#Eval("ExamId")%>&bid=<%#Eval("bid")%>')">
                                                                            <%#Eval("ExamCode") %></a>--%>
                                                                        <%--  <asp:Label ID="lblexamcodeNo" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "ExamCode")%>'></asp:Label>--%>
                                                                        <%--<asp:LinkButton ID="lnb_SupplyStudent" runat="server" Text='<%#Eval("ExamCode") %>' Visible="false" CommandName="ExamCodeSupply" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left">
                                                                    <%--<ItemStyle Width="110px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnexamid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "examid")%>' />
                                                                        <asp:HiddenField ID="hdnbid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "bid")%>' />
                                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "batchcode")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ActivateDate">
                                                                    <%-- <ItemStyle Width="65px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsem" runat="server" Text='<%# Eval("ActivateDate","{0:M-dd-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtActivateDate" runat="server" CssClass="NormalText" MaxLength="300"
                                                                            Text='<%# Bind("ActivateDate","{0:M-dd-yyyy}") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DeactivateDate">
                                                                    <%-- <ItemStyle  Width="55px" />--%>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmodule" runat="server" Text='<%# Eval("DeactivateDate","{0:M-dd-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDeactivateDate" runat="server" CssClass="NormalText" MaxLength="300"
                                                                            Text='<%# Bind("DeactivateDate","{0:M-dd-yyyy}") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                    ShowEditButton="True" ShowHeader="True" />
                                                            </Columns>
                                                            <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                        </asp:GridView>
 </div></div>
  
  <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                        <asp:HiddenField ID="hdnExamId" runat="server" />
                                                        <asp:HiddenField ID="hdnSectionId" runat="server" />
                                                   
                                        
                                </div>
                            </div>
                            </div>
                            </section>
                            </ContentTemplate>
                                    </asp:UpdatePanel>
                   
    </div>
    </form>


</asp:Content>
