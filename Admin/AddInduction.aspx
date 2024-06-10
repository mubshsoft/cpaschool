<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="AddInduction.aspx.cs" Inherits="Admin_AddInduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <%--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />--%>
    <script language="javascript" type="text/javascript">
        function openmodalPopUp(popupId) {
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Induction" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">List Course</li>--%>
		</ul>
	</div>
    </section>


    <form id="form1" runat="server">
    
    <div>
    
     
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course Code" CssClass="form-control"  />
      </div>
      </div>
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Type :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" CssClass="form-control">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">Video</asp:ListItem>
              <asp:ListItem Value="2">PDF</asp:ListItem>
              <asp:ListItem Value="3">PPT</asp:ListItem>
          </asp:DropDownList>
      </div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Caption :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtCaption" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox></div>
      </div>
     
      <div class="row" id="dvFile" runat="server"  >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">File Upload :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:FileUpload ID="FileUpload1" runat="server" /></div>
      </div>
        <div class="row" id="dvPPT" runat="server" visible="false"  >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">URL :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtURL" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox></div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Visible on Page :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:CheckBox ID="chkchecked" runat="server" /></div>
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
              <asp:GridView ID="gvInductionList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="ID" OnRowDataBound="gvInductionList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20" OnRowDeleting="gvInductionList_RowDeleting"
                                                            onpageindexchanging="gvInductionList_PageIndexChanging" OnRowCommand="gvInductionList_RowCommand" >
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
                                                                         <%--<a href='<%#DataBinder.Eval(Container.DataItem, "fpath")%>' runat="server" target="_blank" title="Read the Website functionality/ Demo video"  >Download</a>&nbsp--%>
                                                                        <asp:LinkButton ID="linkPlay" Visible="false" CommandName="PlayVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="Play video" runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video"> 
                                                                        </asp:LinkButton>
                                                                       <asp:LinkButton ID="linkPPT" Visible="false" CommandName="PPT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="View File" runat="server" CausesValidation="false" Font-Underline="false" Text="View PPT"> 
                                                                        </asp:LinkButton>
                                                                         <asp:LinkButton ID="LinkPDF" Visible="false" CommandName="PDF" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="View File" runat="server" CausesValidation="false" Font-Underline="false" Text="View PDF"> 
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

    <div class="modal fade in" id="ModalPopupDivPlayVideo" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" style="width:900px;height:500px; margin: -9em auto;">
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height: 500px;">
         <%-- <div class="scroller" data-height="900px">--%>
         <video width = "840" height = "420" controls id = "Video">
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
    <%--<div class="modal hide fade in" id="ModalPopupDivPPT" aria-hidden="false" style="align-content:flex-start">--%>
        <div class="modal fade in" id="ModalPopupDivPPT" aria-hidden="false">
    <div class="modal-dialog" style="width:900px;height:500px; margin: -9em auto;">
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4><asp:Label ID="lblHeding" runat="server" Text="Induction PPT"></asp:Label></h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="width:100%; height: 500px;">
         
         <iframe id="ifrm" runat="server"  style="width:100%; height: 500px;"></iframe>
               
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
            //$('#' + popupId).modal();
            $('#' + popupId).modal('show');
        }
    </script>
    </form>

</asp:Content>



