<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="AddPaperFile.aspx.cs" Inherits="AddPaperFile" Title="Upload lectures" %>


<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Upload lectures</title>--%>
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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px;}

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
    <h1 class="heading-color">Upload Lectures</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Upload Lectures</li>
		</ul>
	</div>
    </section>
   
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
  
        
    <section class="container main m-tb"> 
   
       <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                </div>                  
                            
                                               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                                
           
                <fieldset>
                <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend ><strong class="style9_sec">Add New </strong></legend></div>
                </div>
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" AutoPostBack="true" ToolTip="Course Code" runat="server" CssClass="form-control" onselectedindexchanged="ddlCourse_SelectedIndexChanged" />
                                   <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlSem" AutoPostBack="true" ToolTip="Semester" runat="server" CssClass="form-control" onselectedindexchanged="ddlSem_SelectedIndexChanged" />
                                   <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                </div>
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlModule" ToolTip="Module" AutoPostBack="true"  runat="server" CssClass="form-control" onselectedindexchanged="ddlModule_SelectedIndexChanged" />
                <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlPaper" ToolTip="Paper" runat="server" CssClass="form-control" />
                                   <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label></div> 
                </div>
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtfilecaption" runat="server" ToolTip="File Caption" placeholder="File Caption" CssClass="form-control" ></asp:TextBox>
                                    <asp:Label ID="lblpapercaption" runat="server" ForeColor="Red" Text=""></asp:Label></div>
<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlBatch" runat="server" ToolTip="Batch" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
  <asp:Label ID="lblreqbatch" runat="server" Text="" ForeColor="Red"></asp:Label>
</div>
</div>

    <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                                   <asp:Label ID="lblfileupload" runat="server" Text="" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hdncoursecode" runat="server" /></div>
                </div>
                        
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" onclick="btnSave_Click"/>
                <asp:button ID="Imagebutton2" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx"/>
                                                    </div>
                                                    </div>
                                                    </div>
                                                    </fieldset>

      
                <fieldset>
                <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend ><strong class="style9_sec">View existing lectures</strong></legend></div>
                </div>
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                   
                                                                 PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" 
                                                    PagerStyle-HorizontalAlign="Center" PageSize="10"  
                                                                AllowPaging="True" OnPageIndexChanging="grdExamSet_PageIndexChanging" onrowcommand="grdExamSet_RowCommand" 
                                                                        onrowdatabound="grdExamSet_RowDataBound" 
                                                                        onrowdeleting="grdExamSet_RowDeleting" 
                                                                        onrowcancelingedit="grdExamSet_RowCancelingEdit" 
                                                                        onrowediting="grdExamSet_RowEditing" onrowupdating="grdExamSet_RowUpdating" 
                                                                >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    
                                                                          <PagerStyle HorizontalAlign="Center" />
                                                    
                                                                          <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                       
                                                      
                                                       
                                                       <asp:TemplateField HeaderText="Course Title">
                                                        <ItemStyle  />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Semester">
                                                        <ItemStyle  />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle   />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Batch">
                                                        <ItemStyle   />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblbatch" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BatchCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Paper" >
                                                        <ItemStyle   HorizontalAlign="Left"/>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                         <asp:TemplateField HeaderText="FileCaption">
                                                                    <ItemStyle HorizontalAlign="Left"  />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTimeAllowted" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "FileCaption")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtFileCaption" runat="server" MaxLength="300" CssClass="NormalText"
                                                                            Text='<%# Bind("FileCaption") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                       
                                                    
                                                         <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px"
                                                                    ShowEditButton="True" ShowHeader="True" >
                                                            <HeaderStyle HorizontalAlign="Center"  />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:CommandField>
                                                  
                                                            
                                            <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                 <asp:HiddenField ID="hdnupaloadimagepath" runat="server" Value='<%# Eval("UploadFilePath") %>' />
                                                                  <asp:HiddenField ID="hdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                                     <asp:LinkButton ID="lnkDeletePaper" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'>
                                                                     Delete</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                            
                                                             
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                 </div>
                 </div>
                                                
                                              <%--  </ContentTemplate>
                                                </asp:UpdatePanel> --%>
                                                </div>
                                            </fieldset>
                                           
                                            </section>
                    
   
    </div>
    
   
    </form>
</asp:Content>

