<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="BatchReport.aspx.cs" Inherits="Admin_BatchReport" Title="Batch Report" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Batch Report</title>--%>

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
//function CallPrint(strid)

//{


//var prtContent = document.getElementById(strid);


//var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=1000,status=0');

////WinPrint.document.write("<STYLE><!-- body{width:100%;margin:0;float:none;color: #000000;font-size: 11px;font-family: tahoma;word-spacing:0.5mm;} --></STYLE>");

//WinPrint.document.write(prtContent.innerHTML );

//WinPrint.document.close();

//WinPrint.focus(); 


//WinPrint.print();


////WinPrint.print();

//WinPrint.close();

// prtContent.innerHTML=strOldOne;

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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px;}
      #form1
      {
          text-align: left;
      }
      .style14
      {
          width: 100%;
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
    <h1 class="heading-color">Batch Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
<li><a href="ReportList.aspx">Report Panel</a></li>
      <li class="active">Batch Report</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
    
                              
                             <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>--%>
       
       

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlbatch" runat="server" AutoPostBack="True" ToolTip="Batch" CssClass="form-control" onselectedindexchanged="ddlbatch_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            </div></div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True"  ToolTip="Gender" CssClass="form-control">
                                                                   <asp:ListItem>All</asp:ListItem>
                                                                   <asp:ListItem>Male</asp:ListItem>
                                                                   <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" ToolTip="Category" CssClass="form-control">
                                                                   <asp:ListItem>All</asp:ListItem>
                                                                   <asp:ListItem>General</asp:ListItem>
                                                                <asp:ListItem>SC/ST</asp:ListItem>
                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                <asp:ListItem>Others</asp:ListItem>
                                                                <asp:ListItem>not given</asp:ListItem>
                                                            </asp:DropDownList>
    </div>
    </div>                    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"> 
    <asp:Button ID="ImageButton2" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton3" runat="server" Text="Generate Report" CssClass="btn btn-large btn-success" onclick="ImageButton3_Click" />
    </div></div>  
    </div>
    <div class="user-info media box" style="background-color:#fff;">                                               
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            
                                            <div id="print_grid" class="style5">
                                            <fieldset>
                                            <legend>Batch Report</legend>
                                            <table width="100%">
                                                   <tr>
                                                        <td width="30%">&nbsp;</td>
                                                        <td width="20%" align="left">
                                                            &nbsp;</td>
                                                        <td width="20%">
                                                            &nbsp;</td>
                                                        <td width="30%" align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                   <tr>
                                                        <td align="right" style="padding-right:10px"><b><asp:Label ID="lblBatch1" runat="server" align="right" Text="BATCH :"  ></asp:Label></b>
                                                           </td>
                                                        <td align="left">
                                                           <asp:Label ID="lblBatchCode" runat="server" align="left" 
                                                                  ></asp:Label>
                                                        </td>
                                                        <td align="right" style="padding-right:10px">
                                                            <b> <asp:Label ID="lbldate" runat="server" align="Right" Text="Date :" 
                                                                 Font-Bold ></asp:Label></b></td>
                                                        <td align="left">
                                                            &nbsp;
                                                            <asp:Label ID="lblshowdate" runat="server" align="left" Text=""  
                                                                ></asp:Label>
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    
                                                    <tr>
                                                        <td align="right" style="padding-right:10px"><b><asp:Label ID="lblGender" runat="server" align="right" Text="Gender :"  Font-Bold  Visible="false" ></asp:Label></b>
                                                           </td>
                                                        <td align="left">
                                                           <asp:Label ID="lblGender1" runat="server" align="left"  Visible="false"  ></asp:Label>
                                                        </td>
                                                        <td align="right" style="padding-right:10px">
                                                            <b>  <asp:Label ID="lblCategory" runat="server" align="Right" Text="Category :"  Font-Bold Visible="false"></asp:Label></b></td>
                                                        <td align="left">
                                                            &nbsp;
                                                            <asp:Label ID="lblCategory1" runat="server" align="left" Text=""  Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                   <tr>
                                                        <td colspan="4">&nbsp;</td>
                                                    </tr>
                                            <tr><td colspan="4">
                                                <asp:GridView ID="grdBatchDetails" runat="server" AutoGenerateColumns="False" CssClass="table"
                                                    Width="100%" AllowPaging="false" EnableModelValidation="True" PageSize="30" 
                                                         onpageindexchanging="grdBatchDetails_PageIndexChanging1" >
                                             <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />--%>
                                                    <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    
                                                      <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="red"   ><strong>  !!!No Records 
                                                            Found!!!</strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    
                                                    
                                                    <Columns>
                                                    
                                                      <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                    <%# (grdBatchDetails.PageSize * grdBatchDetails.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                                   </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentName" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Course"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CourseCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Batch" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "BatchCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Gender"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGender" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "Gender")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Category"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "category")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstatus" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "curprofession")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Email ID" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmailId" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Semester"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSemID" runat="server" 
                                                                    Text='<%# Eval("SemesterTitle") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>




                                                </asp:GridView>
                                                </td></tr></table></fieldset></div>
                                            </div></div>
                                            <div class="row" >&nbsp;</div>
                                                
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">                                               
     <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" tyle="text-align: left" ToolTip="Print" Visible="false" />
     </div></div>
                                                  
      </div>
                                  <%--    </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
   </section>
                      
   </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    
                                                        
    </form>


</asp:Content>
