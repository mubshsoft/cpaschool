<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="EditUnitWithAssestment.aspx.cs" Inherits="Admin_EditUnitWithAssestment" %>
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
        function ViewResourceFile(fn)
        {
            //var url = "../ViewDetail.aspx?fnm=" + fn + "&paperid=" + paperid + "&unitid=" + unitid;
            var url = "/" + fn;
            $('#ifrm').attr('src', url)

            
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
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Type :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" CssClass="input-block-level">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">PDF File</asp:ListItem>
              <asp:ListItem Value="2">Assessments Question</asp:ListItem>
              <asp:ListItem Value="3">Key Learining Points</asp:ListItem>
              <asp:ListItem Value="4">Video</asp:ListItem>
          </asp:DropDownList>
          
      </div>
     
      </div>
       <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Chapter Name :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtChapter" runat="server" CssClass="input-block-level" TabIndex="3"></asp:TextBox></div>
      </div>
     
      <div class="row" runat="server" id="dvFile" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">File Upload :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:FileUpload ID="FileUpload1" runat="server" /></div>
      </div>
        <div class="row" runat="server" id="dvKeyLearning" visible="false" >
      <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form_text field-label">Key Learning</div>
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

      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:HiddenField ID="hdnkcid" runat="server" />
          <asp:HiddenField ID="hdnFilename" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
     
        <div class="row" >
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"></div>
         </div>
        </div>
         </section>
                                
    
    </div>


        
    </form>

</asp:Content>

