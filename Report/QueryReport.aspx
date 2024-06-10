<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="QueryReport.aspx.cs" Inherits="Admin_QueryReport" Title="Query Report" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Query Report</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
     function myprint()
{   
    window.print();
}

  function closepopup()
{    
    window.close();
}



function CallPrint(strid)
  {
   var prtContent = document.getElementById(strid);
   var strOldOne=prtContent.innerHTML;
   var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
   WinPrint.document.write(prtContent.innerHTML);
   WinPrint.document.close();
   WinPrint.focus();
   WinPrint.print();
   WinPrint.close();
   prtContent.innerHTML=strOldOne;
  }

         

    </script>

    <%--<style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000;   font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828;   height:15px;  }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828;   height:15px;  }




    </style>--%>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Query Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li><a href="ReportList.aspx">Report Panel</a></li>
      <li class="active">Query Report</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
     <asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="ddlcourse_SelectedIndexChanged"></asp:DropDownList>
    </div> 
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlbatch" runat="server" ToolTip="Batch" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
    </div> 
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlTo" runat="server" ToolTip="Query To" CssClass="form-control" AutoPostBack="True">
                                                                        <asp:ListItem Value="-1">ALL</asp:ListItem>
                                                                        <asp:ListItem Value="0">Admin</asp:ListItem>
                                                                        <asp:ListItem Value="1">Faculty</asp:ListItem>
                                                                        <asp:ListItem Value="2">Course Coordinator</asp:ListItem>
                                                                    </asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlStauts" runat="server" ToolTip="Status" CssClass="form-control" AutoPostBack="True">
                                                                        <asp:ListItem Value="-1">ALL</asp:ListItem>
                                                                        <asp:ListItem Value="1">Replied</asp:ListItem>
                                                                        <asp:ListItem Value="0">Pending</asp:ListItem>
                                                                    </asp:DropDownList>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton4" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton3" runat="server" Text="Generate Report" CssClass="btn btn-large btn-success" OnClick="ImageButton3_Click" />
    </div>
    </div>
     </div>
                                                                    <%--<asp:Label ID="Label1" runat="server"  
                                                                        Text="Course :"></asp:Label>--%>
                                                               
                                                                    <%--<asp:Label ID="Label2" runat="server"  
                                                                        Text="Batch :"></asp:Label>--%>
                                                               
                                                           <%--<asp:Label ID="lblQueryToTop" runat="server"  
                                                                        Text="Query To :"></asp:Label>--%>
                                                            <%--<asp:Label ID="lblStatusoftop" runat="server"  
                                                                        Text="Status :"></asp:Label>--%>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                                          
                                                                
                                            <div id="print_grid">
                                                <fieldset>
                                                    <legend >Query Report</legend>
                                                    <div class="row" style="border-bottom: solid 1px #ccc;" >
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblcourse" runat="server" Font-Bold=""  Text="Course :" Visible="false"></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblcourse1" runat="server" align="left"  Visible="false"></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblbatch" runat="server" align="Right" Font-Bold=""  Text="Batch :" Visible="false"></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblbatch1" runat="server" align="left"  Text="" Visible="false"></asp:Label></div>
                                                    </div>
                                                    <div class="row" style="border-bottom: solid 1px #ccc;">
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblQueryTo" runat="server" Font-Bold=""   Text="Query To :"></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblQueryTo1" runat="server" align="left"  ></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lbldate" runat="server" align="Right" Font-Bold=""   Text="Date :"></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblshowdate" runat="server" align="left"   Text=""></asp:Label></div>
                                                    </div>
                                                    <div class="row" style="border-bottom: solid 1px #ccc;">
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblStatus" runat="server" Font-Bold=""   Text="Status :"></asp:Label></div>
                                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblStatus1" runat="server" align="left"  ></asp:Label></div>
                                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
                                                    </div>
                                                    <div class="row" >
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:GridView ID="grdQueryDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdQueryDetails_DataBound" CssClass="table"
                                                                    Width="100%"  EnableModelValidation="True"
                                                                     HeaderStyle-CssClass="form_head" 
                                                                    RowStyle-HorizontalAlign="Center" AllowPaging="false" OnPageIndexChanging="grdQueryDetails_PageIndexChanging"
                                                                    PageSize="20">
                                                                    <EmptyDataTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="center" style="padding-right: 10px" width="100%">
                                                                                    <font color="#4b4b4b"><strong>No records </strong></font>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                    <RowStyle HorizontalAlign="Center" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%# (grdQueryDetails.PageSize * grdQueryDetails.PageIndex) + Container.DisplayIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Query Subject" >
                                                                            
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkSubject" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Subject")%>'></asp:LinkButton>
                                                                                <asp:HiddenField ID="hdnQueryId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QueryId")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Query" >
                                                                           
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblQuery" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Query")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Query Date" >
                                                                           
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblQueryDate" runat="server" Text='<%# Eval("QueryDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Reply Date" >
                                                                           
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReplyDate" runat="server" Text='<%# Eval("ReplyDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Query Reply" >
                                                                           
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReply" runat="server" Text='<%# Eval("Reply") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <AlternatingRowStyle BackColor="#EEEEEE" />
                                                                   
                                                                </asp:GridView>
                                                       </div>
                                                       </div>
                                                        <div class="row" >
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                    <asp:Button ID="ImageButton2" runat="server" Text="Print" CssClass="btn btn-large btn-primary" tyle="text-align: left" ToolTip="Print" Visible="false" />
                                                    </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                    
                </div>
                </div>
                </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>

</asp:Content>
