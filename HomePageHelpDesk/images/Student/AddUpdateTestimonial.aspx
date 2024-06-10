<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="AddUpdateTestimonial.aspx.cs" Inherits="Student_AddUpdateTestimonial" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    
    

    <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper" onkeypress="javascript:HideMessage(),HideMessage2(),HideMessage3()">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            <asp:Label ID="lblCaption" runat="server" Text="Add Your Testimonial" />
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Add Your Testimonial</li>
          </ol>
        </section>
        
    <section class="content">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Testimonial</h4>  </div></div>
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><FCKeditorV2:FCKeditor ID="Editor1" runat="server" BasePath="~/fckeditor/" Height="300px" Width="100%" ></FCKeditorV2:FCKeditor></div></div>   
      
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click"/>
          <asp:Button ID="lnkEdit" Text="Edit Testimonial" runat="server" OnClick="lnkEdit_Click" Visible="false" CssClass="btn btn-large btn-primary" ></asp:Button>
                                                                </div></div>

      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:HiddenField ID="hdnid" runat="server" />
          <asp:HiddenField ID="hdnFilename" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
      <%--<div class="row" >
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
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
      </div>--%> 
                                                   </section>
                                    
    </div>

    
   
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>



