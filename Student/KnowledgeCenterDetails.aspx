<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="KnowledgeCenterDetails.aspx.cs" Inherits="Student_KnowledgeCenterDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    
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
            background-color: #eeeeee;
            color: #282828;
            height: 5px;
            border: solid 1px #eee!important;
        }
        body>section {margin-top: 0;}
        .form_head{background: #0e245d;
    color: #fff;
    border: solid 1px #eee!important;}
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Knowledge Center
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Knowledge Center</li>
          </ol>
        </section>
        <section class="content">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                   
    
   
     <div style="margin-top:20px;">
    <div class="row">
        
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
  
        
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            
                                                       </div>
                                                       </div>
                                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
         <div class="box box-primary"><div class="box-body">
         <div class="row" >
      <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 form_text field-label">Subject Type :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" CssClass="form-control">
              <asp:ListItem Value="0">--Select--</asp:ListItem>
              <asp:ListItem Value="1">Magazine and Article</asp:ListItem>
              <asp:ListItem Value="2">Video Pods</asp:ListItem>
               <asp:ListItem Value="3">Audio Pods</asp:ListItem>
          </asp:DropDownList>
          </div> 
             <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 form_text field-label">Course :</div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
           <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" CssClass="form-control">
            
          </asp:DropDownList>
          </div>
             </div> 
             </div></div>
         <div class="box box-primary">
         <div class="box-body">
                                                       <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
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
                                                                        <asp:LinkButton ID="linkdesc" CommandName="Description"  CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>' runat="server" UseSubmitBehavior="true" CausesValidation="false" Font-Underline="false" Text='<%#DataBinder.Eval(Container.DataItem, "caption")%>' ToolTip="Click here to see details !"> 
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
                                                                        <asp:LinkButton ID="linkPlay" Visible="false" CommandName="PlayVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "fpath")%>' runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video |">  </asp:LinkButton>
                                                                        <asp:LinkButton ID="linkPlayOnline" Visible="false" CommandName="PlayOlineVideo" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "urllink")%>' runat="server" CausesValidation="false" Font-Underline="false" Text="Play Video"> 
                                                                        </asp:LinkButton>&nbsp;
                                                                       
                                                                             <a href='<%#DataBinder.Eval(Container.DataItem, "fpath")%>' runat="server" id="lnkDownload" visible="true" >Download</a>
                                                                      
                                                                       
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                
                                                       
   
    </div>
    
    </div>
             </div>
    </div>
       <a data-toggle="modal" href="#ModalPopupDiv" style="display:none" id="hrf1" >Open Modal</a>
          <div class="modal fade" id="ModalPopupDiv" role="dialog">
        <div class="modal-dialog">

      <!-- Modal content-->
      <div class="modal-content">
    <div class="modal-header">
     <button type="button" class="close" data-dismiss="modal">&times;</button>
       <h4 class="modal-title">Knowledge Center</h4>
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
                                                                            <a id="A1" href='<%#DataBinder.Eval(Container.DataItem, "filepath")%>' runat="server" >Click Here To Download</a>
                                                                         </td>
                                                                        </tr>
                                                                        </table>
                                                                         
                                                                        </td> 
                                                                    </tr>
                                                                   
                                                                </table>
                                                            </ItemTemplate>
                                            </asp:DataList>
                                         
    </div>
    </div>
    </div>
    <!--/Modal Body-->
</div>

           
        
    <div class="modal fade" id="ModalPopupDivPlayVideo"  role="dialog">
    <div class="modal-dialog" style="width:880px">
    <div class="modal-content">
    <div class="modal-header">
        
        <button type="button" class="close" data-dismiss="modal" id="btnClose" onclick="Close();">&times;</button>
        <h4>Play Video</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="width:90%;height:auto">
         <video width="840" height="420" controls id="IframeVideo">
     <source src="<%=PlayVideo %>" type="video/mp4"></source>
     
     </video>
        <%-- <iframe id="ifrm" runat="server"  style="width:100%;"></iframe>--%>
       
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>  
       </ContentTemplate>
       </asp:UpdatePanel>
       
   
    </div>
    </section>
        </div>
    
        <script src="../Calendar/jquery-1.10.2.min.js"></script>
        <script language="javascript" type="text/javascript">
            function Close(id) {
                $("#ModalPopupDivPlayVideo").hide();
            }
            function openmodalPopUp1(popupId) {
                // $('#ModalPopupDiv').modal('show');
                $('#' + popupId).show();
            }
    </script>
</asp:Content>
