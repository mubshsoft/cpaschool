<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="InductionProgramme.aspx.cs" Inherits="Student_InductionProgramme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>

 
    <div class="content-wrapper">
<!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Induction Programme
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List of Course</li>
          </ol>
        </section>
    <section class="content">
        <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
                </div>
            </div>
        <div class="row">&nbsp;</div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">     
   
                          
                    <asp:GridView ID="gvInductionList" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10" CssClass="table form_body"
                                                            DataKeyNames="ID" OnRowDataBound="gvInductionList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            onpageindexchanging="gvInductionList_PageIndexChanging" OnRowCommand="gvInductionList_RowCommand" >
                                                            <HeaderStyle CssClass="form_head" />
                                                             <RowStyle />
                                                    
                                                             <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                             <HeaderStyle CssClass="form_head" />
                                                             <EmptyDataTemplate>
                                                            <h4>No Induction Found</h4>
                                                             </EmptyDataTemplate>
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
                                                                         <%--<a href='<%#DataBinder.Eval(Container.DataItem, "fpath")%>' runat="server" target="_blank" title="Read the Website functionality/ Demo video"  >Download</a>&nbsp--%>
                                                                        <asp:LinkButton ID="linkPlay" Visible="false" CommandName="PlayVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="Play Induction Video" runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video"> 
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="linkPPT" Visible="false" CommandName="PPT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="View File" runat="server" CausesValidation="false" Font-Underline="false" Text="View PPT"> 
                                                                        </asp:LinkButton>
                                                                         <asp:LinkButton ID="LinkPDF" Visible="false" CommandName="PDF" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="View File" runat="server" CausesValidation="false" Font-Underline="false" Text="View PDF"> 
                                                                        </asp:LinkButton>
                                                                       <asp:HiddenField ID="hdnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                                                        <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' />
                                                                        <asp:HiddenField ID="type" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "type")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                    
                     </div>
            </div>
    </section>
    </div>

    
   
    <div class="modal fade in" id="ModalPopupDivPlayVideo" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" style="width:620px;">
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="width:70%;height:auto">
         <%-- <div class="scroller" data-height="900px">--%>
         <video width = "600" height = "420" controls id = "Video">
             <source src ="<%=inductionVideo %>" id ="vidSource" type = "video/mp4" ></ source >
         </video>      
    </div>
        <div class="modal-footer" style="text-align:center" >
        <asp:Label ID="lblDescription" runat="server" Text="Website functionality/ Demo video"></asp:Label>
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>
    <div class="modal fade in" id="ModalPopupDivPPT" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" style="width:900px;height:500px;">
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4><asp:Label ID="lblHeding" runat="server" Text="Induction PPT"></asp:Label></h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="width:100%;height:600px;">
         
         <iframe id="ifrm" runat="server"  style="width:100%;height:600px;"></iframe>
               
    </div>
        <div class="modal-footer" style="text-align:center" >
        <asp:Label ID="lblCaptionppt" runat="server" Text="Induction PPT"></asp:Label>
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>
    
    <script language="javascript" type="text/javascript">
        function openmodalPopUp(popupId) {
            $('#' + popupId).modal();
           
        }
    </script>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
   
</asp:Content>
