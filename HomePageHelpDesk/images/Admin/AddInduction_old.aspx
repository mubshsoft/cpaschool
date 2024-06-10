<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddInduction_old.aspx.cs" Inherits="Admin_AddInduction_old" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
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

    <form id="form1" runat="server">
    
    <div>
    
     <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff"><asp:Label ID="lblCaption" runat="server" Text="Add Induction" /></h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>
    <section class="container main">
     <div class="row-fluid"><div class="span12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
    
       <div class="row-fluid" >
      <div class="span5 form_text field-label">Course :</div>
      <div class="span4" >
           <asp:DropDownList ID="ddlCourse" AutoPostBack="true"  runat="server" ToolTip="Course Code" CssClass="input-block-level"  />
      </div>
      </div>
      <div class="row-fluid" >
      <div class="span5 form_text field-label">Type :</div>
      <div class="span4" >
           <asp:DropDownList ID="ddlSubject" runat="server">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">Video</asp:ListItem>
              <asp:ListItem Value="2">PDF</asp:ListItem>
              <asp:ListItem Value="3">PPT</asp:ListItem>
          </asp:DropDownList>
      </div>
      </div>
       <div class="row-fluid" >
      <div class="span5 form_text field-label">Caption :</div>
      <div class="span4" ><asp:TextBox ID="txtCaption" runat="server" CssClass="input-block-level" TabIndex="3"></asp:TextBox></div>
      </div>
     
      <div class="row-fluid" >
      <div class="span5 form_text field-label">File Upload :</div>
      <div class="span4" ><asp:FileUpload ID="FileUpload1" runat="server" /></div>
      </div>
       <div class="row-fluid" >
      <div class="span5 form_text field-label">Visible on Page :</div>
      <div class="span4" ><asp:CheckBox ID="chkchecked" runat="server" /></div>
      </div>
      
      <div class="row-fluid" ><div class="span12 center" >
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" CausesValidation="false" onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" OnClick="btnSave_Click"/>
                                                                </div></div>

      <div class="row-fluid" ><div class="span12" ><asp:HiddenField ID="hdnid" runat="server" />
          <asp:HiddenField ID="hdnFilename" runat="server" />
                                                        <asp:HiddenField ID="hdnimage" runat="server" />
                                                   </div></div>
      <div class="row-fluid" >
          <div class="span12 center" >
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
                                                                         <a href='<%#DataBinder.Eval(Container.DataItem, "fpath")%>' runat="server" target="_blank" title="Read the Website functionality/ Demo video"  >Download</a>&nbsp
                                                                        <asp:LinkButton ID="linkPlay" Visible="false" CommandName="PlayVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' ToolTip="Watch the Website functionality/ Demo video" runat="server" CausesValidation="false" Font-Underline="false" Text=" | Play Video"> 
                                                                        </asp:LinkButton>
                                                                       
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
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



