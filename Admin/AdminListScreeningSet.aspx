<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AdminListScreeningSet.aspx.cs" Inherits="AdminListScreeningSet" %>
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
    <h1 class="heading-color">Evaluation of Screening Exam</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Evaluation of Screening Exam</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        
                        
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                   
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlListCourse" runat="server" AutoPostBack="true" ToolTip="Course" CssClass="form-control" onselectedindexchanged="ddlListCourse_SelectedIndexChanged" ></asp:DropDownList></div></div>
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlListExamSet" runat="server" AutoPostBack="true" ToolTip="Screening Set code" CssClass="form-control" onselectedindexchanged="ddlListExamSet_SelectedIndexChanged1"></asp:DropDownList></div></div>
      <div class="row">&nbsp;</div>                                                      
      <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnBack" Text="Back" CssClass="btn btn-large btn-warning" runat="server" onclick="btnback_Click"/></div></div>
      </div>
      <div class="user-info media box" style="background-color:#fff;">
      <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                              <asp:GridView ID="GrdUserList" AutoGenerateColumns="False"  Width="100%" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                    runat="server" AllowPaging="True" 
                                                    OnPageIndexChanging="GrdUserList_PageIndexChanging" PageSize="10" 
                                                    onrowdatabound="GrdUserList_RowDataBound1">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="Sr. No" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (GrdUserList.PageSize * GrdUserList.PageIndex) + Container.DisplayIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                           
                                                            <ItemTemplate>
                                                       
                                                              <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserId")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Activation of the Screening Exam" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                           
                                                            <ItemTemplate>
                                                       
                                                              <asp:Label ID="lblActDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Screeningdate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Date on which Exam was Taken" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                           
                                                            <ItemTemplate>
                                                       
                                                              <asp:Label ID="lblExamTakenDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CREATDDT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" HeaderText="Answer Sheet">
                                                              <ItemTemplate>
                                                               <asp:HiddenField ID="hdnScrID" Value='<%#DataBinder.Eval(Container.DataItem, "ScrId")%>' runat="server" />
                                                                  <asp:HiddenField ID="hdnUserID" Value='<%#DataBinder.Eval(Container.DataItem, "Userid")%>' runat="server" />
                                                            
                                                              <asp:LinkButton ID="lnkbtntype" runat="server" >Answer Sheet </asp:LinkButton>
                                                               
                                                           
                                                         
                                                            </ItemTemplate>
                                                        </asp:TemplateField>  
                                                        
                                                               <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                      
                                                                        <asp:LinkButton ID="lnkbtnDesc" runat="server" Visible="false" OnCommand="lnkbtnDesc_Command"
                                                                            CommandName="descriptive" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserId")%>'> 
                                                                         Descriptive Answer(Uploaded File)
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                              
                                                    </Columns>
                                                </asp:GridView>
                                            </div></div>
       <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <asp:GridView ID="GrdDescAns" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True"  PageSize="15" >
                                                            <PagerStyle Font-Names="Tahoma" Font-Size="8pt" />
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
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px">
                                                                    <ItemTemplate>
                                                           <asp:LinkButton ID="lnkbtndownloadDesc" runat="server" CommandName="download" OnCommand="lnkbtndownloadDesc_Command"
                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UploadAnspath")%>'>Download </asp:LinkButton>
                                                            
                                                            
                                                          <%--   <a href='Handler.ashx?FILE=<%#DataBinder.Eval(Container.DataItem, "UploadAnspath")%>'>Download </a>--%>
                                                            
                                                             </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        </div></div>
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:HiddenField ID="hdnbatchid" runat="server" />
                                                <asp:HiddenField ID="hdmScrid" runat="server" />
                                           </div></div>
                                           </div>
                                           </section>

                                     </ContentTemplate>
                                    </asp:UpdatePanel>
                   
                
                
    </div>
    </form>


</asp:Content>

