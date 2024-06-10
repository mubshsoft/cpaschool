<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AdminListExamSets.aspx.vb" Inherits="Admin_AdminListExamSets" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title></title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                  open(strOpen, "Info", "status=1, width=700, height=430, top=20, left=300");

              }
              function openPopuppage(exid, uid) {
                 
                  window.open("ExamFinalAnswerSheet.aspx?exid=" + exid + "&uid=" + uid + "", "Info", "status=1, width=700, height=450, top=200, left=300");
              }
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

<style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">List of batch for exam</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
      <li class="active">List of batch for exam</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div onkeypress="javascript:HideMessage()">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            
  <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label> </div></div>
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlListExamSet" runat="server" AutoPostBack="true" CssClass="input-block-level" ToolTip="Exam Set code">
                                                                    </asp:DropDownList>
                                                                    </div></div>
                                                           
         <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
             <asp:Button ID="btnAssign" runat="server" Text="Assign to Faculty" CssClass="btn btn-large btn-success" onclick="lnkbtnSubmit_Click" />&nbsp;
             <asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Admin/AdminListBatchExam.aspx" /></div></div>
         </div>
<div class="user-info media box" style="background-color:#fff;">
         <div class="row" style="overflow:auto"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                        <asp:GridView ID="GrdUserList" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True" OnRowDataBound="GrdUserList_RowDataBound" OnPageIndexChanging="GrdUserList_PageIndexChanging" PageSize="15">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                           <Columns>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (GrdUserList.PageSize * GrdUserList.PageIndex) + Container.DisplayIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstunam" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "stuname")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="User ID" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Userid")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date on which exam was taken" ItemStyle-HorizontalAlign="Center"
                                                                    ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblexamdt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "examDate")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Time at which exam was taken" ItemStyle-HorizontalAlign="Center"
                                                                    ItemStyle-Width="250px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltimetkn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "timetaken")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" HeaderText="Answer Sheet">
                                                                    <ItemTemplate>
                                                                        <a id="a1" href="InstructionAdmin.aspx?uid=<%#Eval("Userid")%>&Exid=<%#Container.DataItem("ExamId")%>&Batchid=<%=Request.QueryString("batchid")%>">
                                                                            Answer Sheet </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               <asp:TemplateField ItemStyle-HorizontalAlign="Left"  HeaderText="Paper Checked">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnstatus" Value='<%#DataBinder.Eval(Container.DataItem, "status")%>'
                                                                            runat="server" />
                                                                        <asp:HiddenField ID="hdnTotalMarks" Value='<%#DataBinder.Eval(Container.DataItem, "TotalMarks")%>'
                                                                            runat="server" />
                                                                        <asp:LinkButton ID="lnkbtnFacultyFeedback" OnClientClick=<%# "openPopuppage(" & Eval("examid") & ",'" & Eval("Userid") & "')" %> runat="server" ToolTip="Faculty has checked the paper."  >Answer Sheet (Faculty)
                                                                         </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField> 
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                        <%--<asp:HiddenField ID="hdnuploadanspath" runat="server" Value='<%#Eval("uploadanspath")%>' />--%>
                                                                        <asp:LinkButton ID="lnkbtnDesc" runat="server" Visible="false" OnCommand="lnkbtnDesc_Command"
                                                                            CommandName="descriptive" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserId")%>'> 
                                                                        Descriptive Answer(Uploaded File)
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" HeaderText="">
                                                                    <ItemTemplate>
                                                                        <a id="a1" href="AddExamDate.aspx?uid=<%#Eval("Userid")%>&Exid=<%#Container.DataItem("ExamId")%>&Batchid=<%=Request.QueryString("batchid")%>">
                                                                            Fill Date </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
          </div></div>
          <div class="row"  style="overflow:auto"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                        <asp:GridView ID="GrdDescAns" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True" PageSize="15">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ShowHeader="true">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <strong>Question No.&nbsp;<asp:Label ID="lblqueno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Queno")%>'></asp:Label>
                                                                            --</strong>&nbsp;&nbsp;<asp:Label ID="lblquetext" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtndownloadDesc" runat="server" CommandName="download" OnCommand="lnkbtndownload_Command"
                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UploadAnspath")%>'>Download </asp:LinkButton>
                                                                        <%-- <a href='Handler.ashx?FILE=<%#DataBinder.Eval(Container.DataItem, "UploadAnspath")%>'>
                                                                        Download </a>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div></div>
</div>
                                                    </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                
                   
    </div>
    </form>


</asp:Content>
