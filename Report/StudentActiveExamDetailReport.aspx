<%@ Page Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="StudentActiveExamDetailReport.aspx.cs" Inherits="StudentActiveExamDetailReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Assign Student for Exam </title>
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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000;   font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828;   height:15px;  }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828;   height:15px;  }
      .style14
      {
      }
      .style15
      {
          width: 60%;
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
    <h1 class="heading-color">Student Active Exam Detail</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li><a href="ReportList.aspx">Report Panel</a></li>
<li>Student Active Exam Detail</li>
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
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                 <div id="print_grid" class="style5" runat="server">
                                    
                                         <table width="100%">
                                         <tr><td>
                                         <table width="100%">
                                         <tr>
                                         <td align="center" style="padding-right:10px; font-family:Tahoma; font-size:11px"; 
                                                 class="style14" colspan="2" >
                                             <table cellpadding="0" cellspacing="0" class="style15">
                                                 <tr>
                                                     <td width="45%" align="right">
                                                         <b>Course:&nbsp; </b></td>
                                                     <td width="5%">
                                                         &nbsp;</td>
                                                     <td width="50%" align="left">
                                                         <asp:Label ID="lblcourse" runat="server" Text="label"></asp:Label>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td align="right">
                                                         <b>Batch:&nbsp; </b></td>
                                                     <td>
                                                         &nbsp;</td>
                                                     <td align="left">
                                                         <asp:Label ID="lblBatch" runat="server" Text="label"></asp:Label>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td align="right">
                                                         <b>Student Name:&nbsp; </b></td>
                                                     <td>
                                                         &nbsp;</td>
                                                     <td align="left">
                                                         <asp:Label ID="lblStudentName" runat="server" Text="label"></asp:Label>
                                                     </td>
                                                 </tr>
                                             </table>
                                             
                                             
                                             </td>
                                         </tr>
                                         
                                          
                                         </table>
                                         </td></tr>
                                            <tr><td>
                                             <fieldset>
                                            <legend class="style9_sec"><b>Paper 
                                                Report</b></legend>
                                           <br />
                                                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%"  AllowPaging="false"   
                                                    HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff" EnableModelValidation="True" PageSize="20" onpageindexchanging="grdReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Paper" ItemStyle-CssClass="left_padding1"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Assignment Code/ Appeared Date " ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "AssignmentCode")%>'></asp:Label> /&nbsp;
                                                                     <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "asgndate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                               <asp:TemplateField HeaderText="Exam Code/ Appeared Date " ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "examCode")%>'></asp:Label> /&nbsp;
                                                                     <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "examdate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                  
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                </fieldset>
                                             </td></tr>
                                          
                                             <tr>
                                             <td>
                                              <fieldset>
                                            <legend class="style9_sec"><b> Last Login 
                                                Report</b></legend>
                                           <br />
                                             <asp:GridView ID="GridLoginReport" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%"  AllowPaging="True"   
                                                    HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff"  PageSize="20" onpageindexchanging="GridLoginReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student Log ID" ItemStyle-CssClass="left_padding1"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentLogId")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name" ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="Login From " ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginFrom")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Login Date " ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogindate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Logout Date " ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLogOutdate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginOut")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           
                                                        
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                   </fieldset>
                                             
                                             
                                             </td>
                                             
                                             </tr>
                                             
                                            
                                             
                                             
                                             
                                             <tr>
                                             <td>
                                              <fieldset>
                                            <legend class="style9_sec"><b>Query
                                                Report</b></legend>
                                           <br />
                                             
                                             <asp:GridView ID="grdQueryDetails" runat="server" AutoGenerateColumns="False" 
                                                Width="95%"
                                                    AlternatingRowStyle-BackColor="#eeeeee" 
                                                    EnableModelValidation="True"   
                                                    HeaderStyle-BackColor="#eeeeee" RowStyle-BackColor="#ffffff" RowStyle-HorizontalAlign="Center">                       
                                                                   
                                                    
                                                    
                                                   
                                                    <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />--%>
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center" style="padding-right: 10px" width="100%">
                                                                    <font color="#4b4b4b"><strong>No records </strong></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Number of Queries Posted" ItemStyle-CssClass="left_padding1"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                   <asp:Label ID="lblNoQuery" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "NumberofQueriesPosted")%>'></asp:Label>
                                                              
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Number of UnReplied Queries " ItemStyle-CssClass="left_padding1"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuery" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "NumberofUnRepliedQueries")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                    </Columns>
                                                    
                                                    <HeaderStyle BackColor="#EEEEEE" />
                                                           <AlternatingRowStyle BackColor="#EEEEEE" />
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                 </fieldset>
                                             
                                             </td>
                                             </tr>
                                         
                                             
                                             
                                             <tr>
                                             <td>
                                               <fieldset>
                                            <legend class="style9_sec"><b>Topic
                                                Report</b></legend>
                                           <br />
                                             <asp:GridView ID="grdQueryDetails2" runat="server" AutoGenerateColumns="False"
Width="95%"
AlternatingRowStyle-BackColor="#eeeeee" OnRowDataBound="grdQueryDetails2_OnRowDataBound"
EnableModelValidation="True"  
HeaderStyle-BackColor="#eeeeee" RowStyle-BackColor="#ffffff" RowStyle-HorizontalAlign="Center">




<EmptyDataTemplate>
<table width="100%">
<tr>
<td align="center" style="padding-right: 10px" width="100%">
<font color="#4b4b4b"><strong>No records </strong></font>
</td>
</tr>
</table>
</EmptyDataTemplate>
<Columns>
 <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                    <%# (grdQueryDetails2.PageSize * grdQueryDetails2.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                                   </ItemTemplate>
                                                                                                            </asp:TemplateField>
<asp:TemplateField HeaderText="Title" ItemStyle-CssClass="left_padding1">
<ItemTemplate>
<asp:Label ID="lblQuery" runat="server"
Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Created By" ItemStyle-CssClass="left_padding1"><%-- <ItemStyle Width="65px" />--%>
<ItemTemplate>
<asp:Label ID="lblQueryDate" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total read " ItemStyle-CssClass="left_padding1"><%-- <ItemStyle Width="55px" />--%>
<ItemTemplate>
<asp:HiddenField ID ="hdnSubjectid" runat="server" Value='<%# Eval("SUBJECTID") %>' />
<asp:Label ID="lblReplyDate" runat="server" Text='<%# Eval("totalread") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total Reply " ItemStyle-CssClass="left_padding1"><%-- <ItemStyle Width="55px" />--%>
<ItemTemplate>
<asp:Label ID="lblReply" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total Sub Topic " ItemStyle-CssClass="left_padding1"><%-- <ItemStyle Width="55px" />--%>
<ItemTemplate>

<asp:Label ID="lbltotal" runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<HeaderStyle BackColor="#EEEEEE" />
<AlternatingRowStyle BackColor="#EEEEEE" />
<%-- <HeaderStyle HorizontalAlign="Left" />
<ItemStyle HorizontalAlign="Center" />--%>
</asp:GridView>
</fieldset>
                                             
                                             
                                             </td>
                                             
                                             
                                             </tr>
                                             <tr>
                                             <td>
                                           
                                             </td>
                                             
                                             </tr>
                                             
                                             <tr>
                                             <td>
                                            
                                             <fieldset>
                                            <legend class="style9_sec"><b>Status
                                                Report</b></legend>
                                           <br />
                                             
                                             <asp:GridView ID="grdStatus" runat="server" AutoGenerateColumns="False"
Width="95%"
AlternatingRowStyle-BackColor="#eeeeee" 
EnableModelValidation="True"  
HeaderStyle-BackColor="#eeeeee" RowStyle-BackColor="#ffffff" RowStyle-HorizontalAlign="Center">




<EmptyDataTemplate>
<table width="100%">
<tr>
<td align="center" style="padding-right: 10px" width="100%">
<font color="#4b4b4b"><strong>No records </strong></font>
</td>
</tr>
</table>
</EmptyDataTemplate>
<Columns>

<asp:TemplateField HeaderText="Fee Status" ItemStyle-CssClass="left_padding1">
<ItemTemplate>
<asp:Label ID="lblfeeStatus" runat="server"
Text='<%#DataBinder.Eval(Container.DataItem, "feeStauts")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Course" ItemStyle-CssClass="left_padding1">
<ItemTemplate>
<asp:Label ID="lblfeeStatus" runat="server"
Text='<%#DataBinder.Eval(Container.DataItem, "Course")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>



<asp:TemplateField HeaderText="Semester" ItemStyle-CssClass="left_padding1">
<ItemTemplate>
<asp:Label ID="lblfeeStatus" runat="server"
Text='<%#DataBinder.Eval(Container.DataItem, "Semester")%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Course Status" ItemStyle-CssClass="left_padding1"><%-- <ItemStyle Width="65px" />--%>
<ItemTemplate>
<asp:Label ID="lblCourseStatus" runat="server" Text='<%# Eval("CourseStauts") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

</Columns>

<HeaderStyle BackColor="#EEEEEE" />
<AlternatingRowStyle BackColor="#EEEEEE" />
<%-- <HeaderStyle HorizontalAlign="Left" />
<ItemStyle HorizontalAlign="Center" />--%>
</asp:GridView>
                                             </fieldset>
                                             </td>
                                             </tr>
                                             
                                             
                                             
                                          </table> 
                                      
                                   </div>
                                   </div></div>
                                   <div class="row" >
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">         
                                            
                                                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/close.png" 
                                                   PostBackUrl="~/Report/ActiveStudentsReport.aspx"/> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" />
                                                  
                                                    
                                             </div>
                                             </div>
                                             </div>
                                             </section>
     </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    
                                                        
    </form>
    </asp:Content>
