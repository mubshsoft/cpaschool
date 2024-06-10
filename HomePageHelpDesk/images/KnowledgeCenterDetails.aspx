<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="KnowledgeCenterDetails.aspx.cs" Inherits="KnowledgeCenterDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
        function openmodalPopUp(popupId) {
           // $('#ModalPopupDiv').modal('show');
            $('#' + popupId).modal('show');

        }
    </script>
    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 5px;
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
            height: 5px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 5px;
            font-family: Verdana,Arial,Tahoma;
        }
        body>section {margin-top: 0;}
       
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
			<li><a href="Adminlogin.aspx">Admin Panel</a></li> 
			<li><a href="../logout.aspx">Logout</a></li>
			<li></li>
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
                                                              
                                                                <asp:TemplateField HeaderText="Caption">
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
                                                                        <asp:LinkButton ID="linkPlayOnline" Visible="false" CommandName="PlayOlineVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "urllink")%>' runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video"> 
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
        <%--<iframe width="560" height="315" src="https://www.youtube.com/embed/NDKIb_PlHH4" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>
                  <%-- <p id="player1"  style="width:600px; height:320;" runat="server" visible="false">
    <embed type="application/x-shockwave-flash" 
    src="flvplayer.swf" width="600" height="320" style="undefined" id="single" name="single" quality="high" allowfullscreen="true" 
    flashvars="height=320&amp;width=600&amp;file=<%=video %>&amp;image=<%=thumb %>"></embed></p>
                             
--%>
                           
     <%--</div> --%>
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>  
    
    </form>

</asp:Content>
