<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="TestimonialList.aspx.cs" Inherits="Admin_TestimonialList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script language="javascript" type="text/javascript">
        function openmodalPopUp(popupId) {
            // $('#' + popupId).modal('show');
            $('#' + popupId).show();

        }

        function CloseTestimonial(id) {
            $("#" + id).hide();
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Testimonial List" /></h1> 
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
                                                  
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">


                                                        <asp:GridView ID="gvTestimonialList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="stid" OnRowDataBound="gvTestimonialList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20"
                                                            onpageindexchanging="gvTestimonialList_PageIndexChanging" OnRowCommand="gvTestimonialList_RowCommand" >
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                              
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkname" CommandName="Testimonial" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "stid")%>' runat="server" CausesValidation="false" Font-Underline="false" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>' ToolTip="Click here to see the student testimonial !" class="btn btn-primary"> 
                                                                        </asp:LinkButton>
                                                                       
                                                                        <asp:HiddenField ID="hdnstid" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "stid")%>' />
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Email">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="linkemail"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email")%>' > 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                            <%--    <asp:TemplateField HeaderText="Batch">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="linkbatchcode"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "batchcode")%>' > 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>--%>
                                                               
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="linkstatus"  runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "fstatus")%>' > 
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div></div>
                                                    </div>

     
      </section>
                                        <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    
                                
    </div>
  


 
<div class="modal fade in" id="ModalPopupDiv" aria-hidden="false">

    <div class="modal-dialog" style="width:900px;height:500px; margin: -9em auto;">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" onclick="CloseTestimonial('ModalPopupDiv');">&times;</button>
        <h4>Testimonial</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height: 300px;">
        <table cellpadding="0" cellspacing="0" width="100%" >
            <tr>
                                                                             <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                            Email :
                                                                         </td>
                                                                          <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <asp:Label ID="lblEmail" runat="server" Text=""  ></asp:Label>
                                                                         </td>
                                                                       
                                                                        </tr>

                                                                        <tr>
                                                                             <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                            Testimonial :
                                                                         </td>
                                                                          <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <asp:Label ID="lblTestimonial" runat="server" Text=""  ></asp:Label>
                                                                         </td>
                                                                       
                                                                        </tr>
            <tr>
                                                                             <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                            Approve :
                                                                         </td>
                                                                          <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <asp:CheckBox ID="chkchecked" runat="server" />
                                                                         </td>

                                                                        </tr>
            <tr>
                <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                           &nbsp;
                                                                         </td>
               <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                           <asp:Button ID="btnSave" runat="server" Text="Approve Testimonial" CssClass="btn btn-large btn-success" OnClick="btnSave_Click"/>
                   <asp:HiddenField ID="hdnStid" runat="server" Value="" />
                                                                         </td>
            </tr>
           
            </table> 
    </div>
      <%--  <div class="modal-footer" style="text-align:center" >
      
    </div>--%>
        </div>
    </div>
    <!--/Modal Body-->
</div>

    </form>

</asp:Content>
