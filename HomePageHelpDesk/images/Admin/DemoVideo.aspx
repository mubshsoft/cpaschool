<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="DemoVideo.aspx.cs" Inherits="Admin_DemoVideo" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Course Details</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
        function openmodalPopUp(popupId) {
           // $('#ModalPopupDiv').modal('show');
            $('#' + popupId).modal('show');

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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Demo Video and PDF" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Course</li>--%>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        
                        
                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                        
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Demo file in :</div>
      <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlSubject" runat="server" width="100%" height="40px">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">Video</asp:ListItem>
              <asp:ListItem Value="2">PDF</asp:ListItem>
          </asp:DropDownList>
      </div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Caption :</div>
      <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" ><asp:TextBox ID="txtCaption" runat="server" CssClass="input-block-level" TabIndex="3"></asp:TextBox></div>
      </div>
     
      <%--<div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Description</h4></div></div>
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><FCKeditorV2:FCKeditor ID="Editor1" runat="server" BasePath="~/fckeditor/" Height="300px" Width="100%" ></FCKeditorV2:FCKeditor></div></div>--%>
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">File Upload :</div>
      <div class="span4" ><asp:FileUpload ID="FileUpload1" runat="server" /></div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Visible on Page :</div>
      <div class="span4" ><asp:CheckBox ID="chkchecked" runat="server" /></div>
      </div>
      
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click"/>
                                                                </div></div>

      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:HiddenField ID="hdnid" runat="server" />
          <asp:HiddenField ID="hdnFilename" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
                                                   </div>
                                                   <div class="user-info media box" style="background-color:#fff;">

      <div class="row" >
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" style="overflow:auto" >
              <asp:GridView ID="gvDemoList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="ID" OnRowDataBound="gvDemoList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20" OnRowDeleting="gvDemoList_RowDeleting"
                                                            onpageindexchanging="gvDemoList_PageIndexChanging" OnRowCommand="gvDemoList_RowCommand" >
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                              
                                                                <asp:TemplateField HeaderText="Caption">
                                                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCaption" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "Caption")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                   
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Subject Type">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSubjectType" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "Type")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                  
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="150px" />
                                                                    <ItemTemplate> 
                                                                        <asp:LinkButton ID="linkEditdata" runat="server"  CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>' CausesValidation="false" Font-Underline="false" Text="Edit Data"> 
                                                                        </asp:LinkButton>
                                                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                                                        <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' />
                                                                        <asp:HiddenField ID="type" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "type")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                   <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="75px" />
                                                                    <ItemTemplate>
                                                                       
                                                                        <asp:LinkButton ID="linkDelete" runat="server" CausesValidation="false" CommandName="Delete"  OnClientClick="return confirm('Are you sure you want to delete ?');"
                                                                            Font-Underline="false" > 
                                                                        Delete</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="150px" />
                                                                    <ItemTemplate> 
                                                                         <a href='<%#DataBinder.Eval(Container.DataItem, "fpath")%>' runat="server" target="_blank" title="Read the Website functionality/ Demo video"  >Download</a>&nbsp
                                                                        <asp:LinkButton ID="linkPlay" Visible="false" CommandName="PlayVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="Watch the Website functionality/ Demo video" runat="server" CausesValidation="false" Font-Underline="false" Text=" | Play Video"> 
                                                                        </asp:LinkButton>
                                                                       
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
           </div>
      </div> 
      </div>
                                                   </section>
                                    
    </div>

    <div class="modal hide fade in" id="ModalPopupDivPlayVideo" aria-hidden="false">
    <div class="modal-dialog" style="width:100%">
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="width:90%;height:auto">
         <%-- <div class="scroller" data-height="900px">--%>
         <iframe id="ifrm" runat="server"  style="width:100%;"></iframe>
               
    </div>
        <div class="modal-footer" style="text-align:center" >
        <asp:Label ID="lblDescription" runat="server" Text="Website functionality/ Demo video"></asp:Label>
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>
    </form>

</asp:Content>

