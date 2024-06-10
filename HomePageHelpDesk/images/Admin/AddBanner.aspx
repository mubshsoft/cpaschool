<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HomeMaster-new.master" CodeFile="AddBanner.aspx.cs" Inherits="Admin_AddBanner" %>
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Banner Details" /></h1> 
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
      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        
                        
                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                        
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
     <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Banner Heading <span style="color: Red">*</span>:</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtBannerHeading" runat="server" CssClass="input-block-level" TabIndex="1"></asp:TextBox></div>
      </div>
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Banner Descriptions  <span style="color: Red">*</span>:(Max Length-50 Characters)</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtBannerDesc" runat="server" CssClass="input-block-level" TextMode="MultiLine" TabIndex="2" MaxLength="50"></asp:TextBox></div>
      </div>
     
         <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Banner Data Orientation  <span style="color: Red">*</span>:</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
          <asp:DropDownList ID="ddlDataOrientation" runat="server">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="horizontal">horizontal</asp:ListItem>
              <asp:ListItem Value="vertical">vertical</asp:ListItem>
          </asp:DropDownList>
         
          
      </div>
      </div>
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Banner Slice 2 Rotation (<small>Add in number</small>) <span style="color: Red">*</span>:</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtdataslice1rotation" runat="server" CssClass="input-block-level" input type="number"  TabIndex="4" ></asp:TextBox>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="strategy" ErrorMessage="* Enter Rotation 1" ForeColor="Red" ControlToValidate = "txtdataslice1rotation" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator> 
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtdataslice1rotation" ErrorMessage="Only Numeric Allowed" ValidationExpression="^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$"></asp:RegularExpressionValidator>
      </div>
      </div>

        <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Banner Slice 2 Rotation (<small>Add in number</small>)<span style="color: Red">*</span>:</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtdataslice2rotation" runat="server" CssClass="input-block-level" TabIndex="5"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="strategy" ErrorMessage="* Enter Rotation 2" ForeColor="Red" ControlToValidate = "txtdataslice2rotation" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator> 
           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtdataslice2rotation" ErrorMessage="Only Numeric Allowed" ValidationExpression="^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$"></asp:RegularExpressionValidator>
      </div>
      </div>
      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Banner Slice 1 Scale (<small>Add in number</small>) <span style="color: Red">*</span>:</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtdataslice1scale" runat="server" CssClass="input-block-level" TabIndex="6" ></asp:TextBox>

           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="strategy" ErrorMessage="* Enter Slice 1 Scale" ForeColor="Red" ControlToValidate = "txtdataslice1scale" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator> 
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtdataslice1scale" ErrorMessage="Only Numeric Allowed" ValidationExpression="^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$"></asp:RegularExpressionValidator>
      </div>
      </div>

        <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Banner Slice 2 Scale (<small>Add in number</small>) <span style="color: Red">*</span>:</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtdataslice2scale" runat="server" CssClass="input-block-level" TabIndex="7"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="strategy" ErrorMessage="* Enter Slice 2 Scale" ForeColor="Red" ControlToValidate = "txtdataslice2scale" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator> 
          <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic" ForeColor="Red" ControlToValidate="txtdataslice2scale" ErrorMessage="Only Numeric Allowed" ValidationExpression="^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$"></asp:RegularExpressionValidator>
      </div>
      </div>

      <div class="row" >
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Image Upload :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:FileUpload ID="FileUpload1" runat="server" /><br />
          <small>Image Dimensions (Width 378 px * Height 250 px) </small>
      </div>
         
      </div>
      
      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false"   onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" ValidationGroup="strategy" OnClick="btnSave_Click" />

                                                                </div></div>

      <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:HiddenField ID="hdncourseId" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
                                                   </div>
                                                   </section>
                                       <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                
   
    
    </div>
    </form>

</asp:Content>
