<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="KnowledgeCenterDetails.aspx.cs" Inherits="KnowledgeCenterDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <script language="javascript" type="text/javascript">
        function openmodalPopUp(popupId) {
           // $('#ModalPopupDiv').modal('show');
            //$('#' + popupId).modal('show');
            $('#' + popupId).show();
        }
        function CloseDiv(id) {
            $("#" + id).hide();
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
            border: solid 1px #fff;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 5px;
            border: solid 1px #eee!important;
        }
        body>section {margin-top: 0;}
.form-head {border: solid 1px #eee!important;}
       
    </style>
    
        

    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
       <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        
                        
                                 <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
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



      
    <section class="container main">
                                                     
     <div class="row">&nbsp;</div>                                              
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">


                                                        <asp:GridView ID="gvKnowledgecenterList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                            DataKeyNames="ID" OnRowDataBound="gvKnowledgecenterList_RowDataBound" PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                            PagerStyle-HorizontalAlign="Center" PageSize="20"
                                                            onpageindexchanging="gvKnowledgecenterList_PageIndexChanging" OnRowCommand="gvKnowledgecenterList_RowCommand" >
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                              
                                                                <asp:TemplateField HeaderText="Description">
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkdesc" CommandName="Description" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>' runat="server" CausesValidation="false" Font-Underline="false" Text='<%#DataBinder.Eval(Container.DataItem, "caption")%>' ToolTip="Click here to see details !"> 
                                                                        </asp:LinkButton>
                                                                       
                                                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Id")%>' />
                                                                        <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' />
                                                                        <asp:HiddenField ID="hdnsubjecttype" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "subjecttype")%>' />
                                                                        <asp:HiddenField ID="hdnFileMode" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "FileMode")%>' />
                                                                        <asp:HiddenField ID="hdnURLlink" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "URLlink")%>' />
                                                                    </ItemTemplate>
                                                                 
                                                                </asp:TemplateField>
                                                             
                                                                
                                                                <asp:TemplateField>
                                                                    <ItemStyle HorizontalAlign="center" Width="150px" />
                                                                    <ItemTemplate> 
                                                                        <asp:LinkButton ID="linkPlay" Visible="false" CommandName="PlayVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video |">  </asp:LinkButton>
                                                                        <asp:LinkButton ID="linkPlayOnline" Visible="false" CommandName="PlayOlineVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "urllink1")%>' runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video"> 
                                                                        </asp:LinkButton>&nbsp;
                                                                       
                                                                             <a href='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' runat="server" id="lnkDownload" visible="true" >Download</a>
                                                                      
                                                                       
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div></div>

     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                               
                                                        
      </div></div>
      </section>
                                        <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    
                                
    </div>
       
<div class="modal hide fade in" id="ModalPopupDiv" aria-hidden="false">
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

    <div class="modal fade in" id="ModalPopupDivPlayVideo" aria-hidden="false">
<%-- <div class="modal fade" id="ModalPopupDivPlayVideo" role="dialog">--%>
    <div class="modal-dialog" style="width:900px;height:500px; margin: -9em auto;">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" onclick="CloseDiv('ModalPopupDivPlayVideo');">&times;</button>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height: 500px;">
         <%-- <div class="scroller" data-height="900px">--%>
         <%--<iframe id="ifrm" runat="server"  style="width:100%;"></iframe>--%>
        <video width="840" height="420" controls id="IframeVideo">
     <source src="<%=DemoVideo %>" type="video/mp4"></source>
     
     </video>
               
    </div>
       <%-- <div class="modal-footer" style="text-align:center" >
        <asp:Label ID="lblDescription" runat="server" Text="Website functionality/ Demo video"></asp:Label>
        
    </div>--%>
        </div>
    </div>
    <!--/Modal Body-->
</div>       
        
     <div class="modal fade in" id="ModalPopupDivPlayOnlineVideo" aria-hidden="false">
<%-- <div class="modal fade" id="ModalPopupDivPlayVideo" role="dialog">--%>
    <div class="modal-dialog" style="width:900px;height:500px; margin: -9em auto;">
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" onclick="CloseDiv('ModalPopupDivPlayOnlineVideo');">&times;</button>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height: 500px;">
         <%-- <div class="scroller" data-height="900px">--%>
         <%--<iframe id="ifrm" runat="server"  style="width:100%;"></iframe>--%>
       <%-- <video width="840" height="420" controls id="IframeVideo">
     <source src="<%=DemoVideo %>" type="video/mp4"></source>
     
     </video>--%>
     <iframe width="420" height="400" src="<%=DemoVideo %>">
</iframe>
               
    </div>
       <%-- <div class="modal-footer" style="text-align:center" >
        <asp:Label ID="lblDescription" runat="server" Text="Website functionality/ Demo video"></asp:Label>
        
    </div>--%>
        </div>
    </div>
    <!--/Modal Body-->
</div> 
    
    </form>

</asp:Content>
