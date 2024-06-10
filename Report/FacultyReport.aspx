<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="FacultyReport.aspx.cs" Inherits="Admin_FacultyReport" Title="Faculty Report" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Faculty Report</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">


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


//}


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
    <h1 class="heading-color">Faculty Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li><a href="ReportList.aspx">Report Panel</a></li>
      <li class="active">Faculty Report</li>
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
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <div id="print_grid">
     <fieldset>
     <legend>Faculty Report</legend>
      <asp:GridView ID="grdFacultyDetails" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table" 
                                                                                OnRowDataBound="grdFacultyDetails_DataBound" AllowPaging="false"
                                                                               HeaderStyle-CssClass="form_head"
                                                                                 EnableModelValidation="True" PageSize="20" OnPageIndexChanging="grdFacultyDetails_PageIndexChanging1">
                                                                                 <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                <EmptyDataTemplate>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td width="100%" align="center" style="padding-right: 10px">
                                                                                                <font color="#4b4b4b"  ><strong>!!!No Records Found!!!</strong>
                                                                                                </font>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </EmptyDataTemplate>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="3%">
                                                                                        <ItemTemplate>
                                                                                            <%# (grdFacultyDetails.PageSize * grdFacultyDetails.PageIndex) + Container.DisplayIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Faculty Name"  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="15%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblFacultyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FacultyName")%>'></asp:Label>
                                                                                            <asp:HiddenField ID="hdnFid" runat="server" Value='<%# Eval("Fid") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Course" ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="15%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                     <asp:TemplateField HeaderText="Address " ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="15%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbladdress" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "address1")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    <asp:TemplateField HeaderText="User ID "  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUserId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Email")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                     <asp:TemplateField HeaderText="Contact No."  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblContactno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "contactnumber1")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Paper Assign" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="5%">
                                                                                        <ItemTemplate>
                                                                                            <%--<asp:LinkButton ID="lnkPaperAssign" runat="server" Text="Papers Assign Details"></asp:LinkButton>--%>
                                                                                            <asp:Label ID="lblPaperAssign" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Papertitle")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText=""  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="5%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkRegisterDetails" runat="server" Text="Complete Faculty Details"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                            </asp:GridView>
                                                                       
                                                            </fieldset>
                                                        </div>
                                                        </div>
                                                        </div>
                                                    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton2" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" tyle="text-align: left" ToolTip="Print" Visible="false" />
     </div></div>
     </div>
     </section>
                           
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>

</asp:Content>
