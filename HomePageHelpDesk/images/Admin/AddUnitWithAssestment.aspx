<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HomeMaster-new.master" CodeFile="AddUnitWithAssestment.aspx.cs" Inherits="Admin_AddUnitWithAssestment" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
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

    <script>
        function ViewResourceFile(fn) {
            //var url = "../ViewDetail.aspx?fnm=" + fn + "&paperid=" + paperid + "&unitid=" + unitid;
            var url = "../" + fn;
            var ext = fn.split('.').pop();
            // alert(ext);
            if (ext.toLowerCase() == "pdf") {
                $("#ifrm").css("display", "inherit");
                $('#ifrm').attr('src', url);
            }
            else {
                var vid = "";
                vid = vid + "<video width='520' height='440' controls id='IframeVideo'><source src='" + url + "' id='ifrm4addnote' type='video/mp4'></source></video>";

                $("#spnVideo").css("display", "inherit");
                $("#spnVideo").append(vid);
            }

            $("#ModalPopupDiv").css("width", "1000px");
            $('#ModalPopupDiv').modal('show');

            //$('.modal-dialog').draggable();


            // window.open("../ViewDetail.aspx?fnm=" + fn + "&paperid=" + paperid + "&unitid=" + unitid, '_blank', 'toolbar=0, location=0, menubar=0');
        }
        

            </script>
            <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color"><asp:Label ID="lblChapter" runat="server" Text="Add Unit Chapter Wise" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a></li>
      <%-- <li class="active">List Of Assignment</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    
    <div>
     
                                        
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    
       
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">Type :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"  CssClass="input-block-level" >
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">PDF File</asp:ListItem>
              <asp:ListItem Value="2">Assessments Question</asp:ListItem>
              <asp:ListItem Value="3">Key Learining Points</asp:ListItem>
              <asp:ListItem Value="4">Video</asp:ListItem>
              
          </asp:DropDownList>
          
      </div>
     
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">Chapter Name :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtChapter" runat="server" CssClass="input-block-level" TabIndex="3"></asp:TextBox></div>
      </div>
     
      <div class="row" runat="server" id="dvFile" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">File Upload :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:FileUpload ID="FileUpload1" runat="server" /></div>
      </div>
        <div class="row" runat="server" id="dvKeyLearning" visible="false" >
      <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Key Learning</div>
      <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12" >
          
          <FCKeditorV2:FCKeditor ID="Editor1" runat="server" BasePath="~/fckeditor/" Height="300px" Width="100%" ></FCKeditorV2:FCKeditor>

      </div>
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Visible With Unit :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:CheckBox ID="chkchecked" runat="server" /></div>
      </div>
      
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click"/>
                                                                </div></div>
</div>
<div class="user-info media box" style="background-color:#fff;">
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:HiddenField ID="hdnkcid" runat="server" />
          <asp:HiddenField ID="hdnFilename" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
     
        <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"></div>
         </div>
        <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:GridView ID="gvChapterList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                    DataKeyNames="ID" 
                                                    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                    PagerStyle-HorizontalAlign="Center" PageSize="20"
                                                    OnRowDataBound="gvChapterList_RowDataBound" OnRowDeleting="gvChapterList_RowDeleting" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Chapter No.">
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="QuesNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Chapter">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ChapterText")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Type">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Type")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Assessments Question">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkQuestion" runat="server" CausesValidation="false" Font-Underline="false">Add 
                                                                        Assessments Question</asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Chapter File">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkFiledownload" runat="server" CausesValidation="false" Font-Underline="false" Visible="false"> 
                                                                         <a href="#" onclick="ViewResourceFile('<%#DataBinder.Eval(Container.DataItem, "FilePath")%>')" >View</a>
                                                                </asp:LinkButton>
                                                                &nbsp;
                                                               
                                                                <asp:HiddenField ID="hdnFile" Value='<%#DataBinder.Eval(Container.DataItem, "FilePath")%>' runat="server" />
                                                                 <asp:HiddenField ID="hdnChapterID" Value='<%#DataBinder.Eval(Container.DataItem, "ChapterID")%>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ChapterID")%>'  CausesValidation="false" Font-Underline="false"> 
                                                                        Edit</asp:LinkButton>
                                                              
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkdelete" runat="server" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID")%>' OnClientClick="javascript:return confirm('Are you sure? Do you want to remove.')"  CausesValidation="false" Font-Underline="false"> 
                                                                        Delete</asp:LinkButton>
                                                              <asp:HiddenField ID="hdnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ID")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                           </div></div>
                                           </div>
         </section>
                                
    
    </div>


        <div class="modal hide fade in" id="ModalPopupDiv" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" >
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>View</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height:auto">
       <span id="spnVideo" style="display:none"></span>
         <iframe id="ifrm" style="width:1000px;height:900px;" style="display:none"></iframe>
    </div>
        <div class="modal-footer" style="text-align:center" >
        
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>
    </form>

</asp:Content>