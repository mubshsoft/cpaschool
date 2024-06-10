<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="KnowledgeCenterDetailsNew.aspx.cs" Inherits="KnowledgeCenterDetailsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script src="https://use.fontawesome.com/1744f3f671.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.js"></script>
    <script language="javascript" type="text/javascript">

        function openmodalPopUp(popupId) {
           
           // $('#ModalPopupDiv').modal('show');
            $('#' + popupId).show();
        }
    </script>
    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 5px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 5px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #fff;
            color: #282828;
            height: 5px;
            
        }
        body>section {margin-top: 0;}
       .kc-box {background: #fff; padding:1em; margin:1em}
    </style>
    <form id="form1" runat="server">
<section class="fullwidth banner-color" style="padding: 40px;">
	<h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Knowledge Center" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="#" id="pnl" runat="server"  >
                <asp:Literal runat="server" ID="lblPanel"></asp:Literal>
			    </a></li> 
			
		</ul>
	</div>
</section>
    <!-- / .title -->


    <section id="about-us" class="container main">
        
        <div class="row">&nbsp;</div>  
                                                <asp:Repeater ID="gvKnowledgecenterList" runat="server" OnItemDataBound="gvKnowledgecenterList_OnItemDataBound" >
                                                    <HeaderTemplate>
                                                    <table class="table">
                                                        
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                    <div class="row kc-box">
     <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
         <asp:Image runat="server" id="img" style="margin-right:10px"></asp:Image>
          <%#DataBinder.Eval(Container.DataItem, "caption")%></div>
    
     <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><a href='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' runat="server" id="A1" visible="true" Tooltip="Download"><i class="icon icon-download" style="color: #0e245d; font-size: 2em;"></i></a> </div>
      <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
           <asp:LinkButton ID="linkdesc" CommandName="Description" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>' OnClick="Getdescription" runat="server" CausesValidation="false" Font-Underline="false" class="btn btn-primary" Text="Details" ToolTip="Click here to see details !"> 
                                                                        </asp:LinkButton>
      </div>
     </div>  
                                                        <asp:Label ID="hdnId" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                                                        <asp:Label ID="hdnfilepath" runat="server" Text='<%# Eval("filepath") %>' Visible="False" />
                                                        <asp:Label ID="hdnsubjecttype" runat="server" Text='<%# Eval("subjecttype") %>' Visible="False" />
                                                         <%--<asp:HiddenField ID="hdnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                                                        <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' />
                                                                        <asp:HiddenField ID="hdnsubjecttype" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "subjecttype")%>' />
                                                                        <asp:HiddenField ID="hdnFileMode" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "FileMode")%>' />
                                                                        <asp:HiddenField ID="hdnURLlink" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "URLlink")%>' />--%>

                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>

            
                                            </section>

     <div id="ModalPopupDiv" class="modal fade in" aria-hidden="false">
    
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Knowledge Center</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body">
        <asp:DataList ID="dlstKnowledgecenter" runat="server" Width="100%" >
                                             <ItemTemplate>
                                                                <table  width="100%" cellpadding="0" cellspacing="3">
                                                               
                                                                <tr>
                                                                        <td width="100%" style="padding-left:5px; padding-bottom:5px; padding-top:5px;" >
                                                                        <table cellpadding="0" cellspacing="0" width="100%" >
                                                                        <tr>
                                                                             <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                            Subject :
                                                                         </td>
                                                                          <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <asp:Label ID="Label2" ForeColor="black" Font-Bold="true" Font-Size="13px" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem, "subjecttype")%>'></asp:Label>
                                                                         </td>
                                                                       
                                                                        </tr>
                                                                         <tr>
                                                                             <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                            Caption :
                                                                         </td>
                                                                          <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <asp:Label ID="Label1" ForeColor="black" Font-Bold="true" Font-Size="13px" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem, "Caption")%>'></asp:Label>
                                                                         </td>
                                                                        </tr>
                                                                        <tr>
                                                                         <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                            Description :
                                                                         </td>
                                                                        <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <asp:Label ID="lbldesc" ForeColor="black" Font-Bold="true" Font-Size="13px" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem, "KnowledgecenterDescription")%>'></asp:Label>
                                                                        </td>
                                                                        </tr>
                                                                        <tr>
                                                                             <td width="30%" style="padding-bottom:5px; padding-top:5px;">
                                                                           &nbsp;
                                                                         </td>
                                                                          <td width="70%" style="padding-right:5px; padding-bottom:5px; padding-top:5px;">
                                                                            <a href='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' runat="server" >Click Here To Download</a>
                                                                         </td>
                                                                        </tr>
                                                                        </table>
                                                                         
                                                                        </td> 
                                                                    </tr>
                                                                   
                                                                </table>
                                                            </ItemTemplate>
                                            </asp:DataList>
    </div>
    <!--/Modal Body-->
</div>
        </form> 
</asp:Content>

