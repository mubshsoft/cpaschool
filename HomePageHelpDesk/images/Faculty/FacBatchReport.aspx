<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="FacBatchReport.aspx.cs" Inherits="Fac_BatchReport" Title="Batch Report" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">


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

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }

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
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Batch Report</li>
		</ul>
	</div>
    </section>
<form id="form1" runat="server">


  <section class="container main m-tb">
  <asp:Label ID="lblCaption" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
    <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" align="center">
                 <asp:DropDownList ID="ddlbatch" runat="server" AutoPostBack="True" CssClass="input-block-level" onselectedindexchanged="ddlbatch_SelectedIndexChanged"></asp:DropDownList>
                 </div>
                 
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" align="center">
                 <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" CssClass="input-block-level">
                                                                   <asp:ListItem>--Select Gender--</asp:ListItem>
                                                                   <asp:ListItem>Male</asp:ListItem>
                                                                   <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList>
                 </div>
                 
                 <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" align="center">
                 <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" Width="400px" CssClass="input-block-level">
                                                                   <asp:ListItem>--Select Category--</asp:ListItem>
                                                                   <asp:ListItem>General</asp:ListItem>
                                                                <asp:ListItem>SC/ST</asp:ListItem>
                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                <asp:ListItem>Others</asp:ListItem>
                                                                <asp:ListItem>not given</asp:ListItem>
                                                            </asp:DropDownList>
                 </div>
                 </div>
                 <div class="row">&nbsp;</div>
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                 <asp:Button ID="ImageButton2" runat="server" PostBackUrl="~/Report/ReportList.aspx" Text="Back" CssClass="btn btn-warning btn-large" onclick="ImageButton2_Click" />
                 <asp:Button ID="ImageButton3" runat="server" Text="Generate Report" CssClass="btn btn-success btn-large " onclick="ImageButton3_Click" />
    </div>
  
        </div>
        </div>
      <div class="user-info media box" style="background-color:#fff;">                    
                             <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>--%>
                                                        <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                   
                                            <div id="print_grid" class="table">
                                            <fieldset>
                                            <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Batch Report</div></div>
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
                                                        <td align="right" style="padding-right:10px"><asp:Label ID="lblBatch1" runat="server" Text="Batch :"  Font-Bold Font-Names="Tahoma" 
                                                                Font-Size="11px" ></asp:Label>
                                                           </td>
                                                        <td align="left">
                                                           <asp:Label ID="lblBatchCode" runat="server" align="left" Font-Names="Tahoma" 
                                                                Font-Size="11px"  ></asp:Label>
                                                        </td>
                                                        <td align="Right" style="padding-right:10px">
                                                            <asp:Label ID="lbldate" runat="server" Text="Date :" Font-Names="Tahoma" 
                                                                Font-Size="11px" Font-Bold ></asp:Label></td>
                                                        <td align="left">
                                                            &nbsp;
                                                            <asp:Label ID="lblshowdate" runat="server" align="left" Text="" Font-Names="Tahoma" 
                                                                Font-Size="11px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    
                                                    <tr>
                                                        <td align="right" style="padding-right:10px"><asp:Label ID="lblGender" runat="server"  Text="Gender :"  Font-Bold Font-Names="Tahoma" 
                                                                Font-Size="11px" Visible="false" ></asp:Label>
                                                           </td>
                                                        <td align="left">
                                                           <asp:Label ID="lblGender1" runat="server" align="left" Font-Names="Tahoma" 
                                                                Font-Size="11px" Visible="false"  ></asp:Label>
                                                        </td>
                                                        <td align="Right" style="padding-right:10px">
                                                            <asp:Label ID="lblCategory" runat="server"  Text="Category :" Font-Names="Tahoma" 
                                                                Font-Size="11px" Font-Bold Visible="false"></asp:Label></td>
                                                        <td align="left">
                                                            &nbsp;
                                                            <asp:Label ID="lblCategory1" runat="server" align="left" Text="" Font-Names="Tahoma" 
                                                                Font-Size="11px" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                    
                                                   <tr>
                                                        <td colspan="4">&nbsp;</td>
                                                    </tr>
                                            <tr><td colspan="4" >
                                                <asp:GridView ID="grdBatchDetails" runat="server" AutoGenerateColumns="False"  CssClass="table"
                                                    Width="100%" AllowPaging="false" Font-Names="Verdana" Font-Size="10px"  onpageindexchanging="grdBatchDetails_PageIndexChanging1" >
                                             <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />--%>
                                                    
                                                    <HeaderStyle  />
                                                      <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="red"  Font-Names="Verdana" Font-Size="10px"><strong>  !!!No Records 
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
                                                        <asp:TemplateField HeaderText="Student Name" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentName" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Course" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CourseCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Batch" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "BatchCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Gender" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGender" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "Gender")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Category" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategory" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "category")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstatus" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "curprofession")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Email ID" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmailId" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Semester" ItemStyle-CssClass="left_padding1" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSemID" runat="server" 
                                                                    Text='<%# Eval("SemesterTitle") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>

<HeaderStyle BackColor="#EEEEEE"></HeaderStyle>

<AlternatingRowStyle BackColor="#EEEEEE"></AlternatingRowStyle>
                                                </asp:GridView>
                                                </td></tr></table></fieldset></div>
                                            
                                                    
                                                <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-info btn-large"  ToolTip="Print" Visible="false" />
                                                
                                      </div>
                                      </div>      
                                  <%--    </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                           
   </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    </div>
       </section>                                                 
    </form>



</asp:Content>
