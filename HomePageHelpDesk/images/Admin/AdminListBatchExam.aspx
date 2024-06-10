<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AdminListBatchExam.aspx.vb" Inherits="Admin_AdminListBatchExam" Title="List of Batch for Exam" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of Batch for Exam</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<script type="text/javascript" src="../stmenu.js"></script>
 <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
      <ContentTemplate >
      
  <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>

        <div class="row"><div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" ToolTip="Course" CssClass="input-block-level">
                                                            </asp:DropDownList></div>
                               <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="trbatch" runat="server"><asp:DropDownList ID="ddlbatch" runat="server" AutoPostBack="true" ToolTip="Batch" CssClass="input-block-level">
                                                            </asp:DropDownList></div>
        </div>
         
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server" /></div></div>
         
                                               </div>
                                               <div class="user-info media box" style="background-color:#fff;">
         <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                        
                                                <asp:GridView ID="GrdBatch" AutoGenerateColumns="False" DataKeyNames="bid" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="True" OnPageIndexChanging="GrdBatch_PageIndexChanging">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <%# (GrdBatch.PageSize * GrdBatch.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                            <%--<ItemTemplate>
                                                                <asp:Label ID="lblBatchCode" Text='<%# Eval("BatchCode") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <a id="a1" href="AdminListExamSets.aspx?batchid=<%#Eval("bid")%>">
                                                                   <%# Eval("BatchCode") %>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Course Id" ItemStyle-HorizontalAlign="Left" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseId" Text='<%# Eval("courseID") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Exam Status" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20px">
                                                           
                                                            <ItemTemplate>
                                                                <a id="a1" href="Examstatus.aspx?batchid=<%#Eval("bid")%>">
                                                                   select
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                         <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px">
                                                            <%--<ItemTemplate>
                                                                <asp:Label ID="lblBatchCode" Text='<%# Eval("BatchCode") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <a id="a1" href="AnswersheetDateList.aspx?batchid=<%#Eval("bid")%>">
                                                                    Date Information
                                                                </a>
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