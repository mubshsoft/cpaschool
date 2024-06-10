<%@ Page MasterPageFile="~/InnerMaster.master" Language="C#" AutoEventWireup="true" CodeFile="CourseList.aspx.cs" Inherits="CourseList" Title="Course List" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Course List</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Course Details" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Query</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
                        
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
        
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
          <span class="pull-right"><asp:Button ID="add" runat="server" Text="Add Course Detail" CssClass="btn btn-large btn-success" PostBackUrl="~/Admin/AddCourseDetails.aspx" /></span>
          </div></div>
    <div class="row">&nbsp;</div>                                         
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                                        <asp:GridView ID="gvQuestionList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="CourseId" OnRowDataBound="gvQuestionList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20" OnRowDeleting="gvQuestionList_RowDeleting"
                                                            onpageindexchanging="gvQuestionList_PageIndexChanging" OnRowCancelingEdit="gvQuestionList_RowCancelingEdit" OnRowEditing="gvQuestionList_RowEditing" OnRowUpdating="gvQuestionList_RowUpdating">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                              
                                                                <asp:TemplateField HeaderText="SNo.">
                                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblOrderNumber" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "OrderNumber")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>  
                                                                        <asp:TextBox ID="txt_OrderNumber" runat="server" Text='<%#Eval("OrderNumber") %>'></asp:TextBox>  
                                                                     </EditItemTemplate>  
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Course">
                                                                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblName" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "CourseName")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                   
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Text1" Visible="false">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblText1" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "Text1")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                  
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Text2"  Visible="false">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblText2" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "Text2")%>'></asp:Label>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                             
                                                                
                                                                <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="150px" />
                                                                    <ItemTemplate>
                                                                       
                                                                        <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CourseId")%>' />
                                                                        <asp:LinkButton ID="linkAddOption" runat="server" CausesValidation="false" Font-Underline="false" Text="Edit Details"> 
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="150px" />
                                                                    <ItemTemplate>
                                                                       
                                                                       
                                                                        <asp:LinkButton ID="linkEditBanner" runat="server" CausesValidation="false" Font-Underline="false" Text="Edit Banner Details"> 
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                   <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="75px" />
                                                                    <ItemTemplate>
                                                                       
                                                                        <asp:LinkButton ID="linkDeleteQuestion" runat="server" CausesValidation="false" CommandName="Delete"
                                                                            Font-Underline="false" > 
                                                                        Delete</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:CommandField ShowEditButton="true" /> 
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div></div>

     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                               
                                                        <asp:HiddenField ID="hdnExamId" runat="server" />
                                                        <asp:HiddenField ID="hdnSectionId" runat="server" />
      </div></div>
      </div>
      </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                
    </div>
    </form>

</asp:Content>
