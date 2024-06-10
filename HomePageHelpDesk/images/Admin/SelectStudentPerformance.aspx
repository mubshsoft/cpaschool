<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="SelectStudentPerformance.aspx.vb" Inherits="Admin_SelectStudentPerformance" Title="List Student" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List Student</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=550, height=450, top=20, left=300");
                }
    </script>
     <script type="text/javascript">
         function openPopUp1(popupId) {
             alert(popupId);
         // $('#' + popupId).modal('show');
      }
     
</script>
    <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
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
    <h1 class="heading-color">Performance Sheet</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Performance Sheet</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;"> 
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                          
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate >
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
     <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course" AutoPostBack="true" CssClass="input-block-level"></asp:DropDownList></div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlBatch" runat="server" ToolTip="Batch" AutoPostBack="true" CssClass="input-block-level"></asp:DropDownList></div>
    </div>                                                   </td>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblBatch" runat="server"  ></asp:Label>
    <asp:LinkButton ID="imgBatchClose" Text="Click to Close" runat="server" Visible="false"></asp:LinkButton> </div>     
      </div>                                      
      
     </ContentTemplate>
    </asp:UpdatePanel>
    
    </div>
    </div>
    </div>
    <div class="row" >&nbsp;</div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-primary" runat="server" /></div>
    </div>
    <div class="user-info media box" style="background-color:#fff;"> 
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                          <ContentTemplate >
                                                <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" OnRowDataBound="grdExamSet_RowDataBound" DataKeyNames="stid" Width="100%"
                                                    runat="server" AllowPaging="false" OnRowCommand="GrdStudent_RowCommand" CssClass="table" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                       
                                                        <asp:TemplateField HeaderText="stid" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStid" Text='<%# Eval("stid") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Bid" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBid" Text='<%# Eval("bid") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                             <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                     
                                                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfullname" Text='<%# Eval("fullname") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                            <asp:HiddenField ID="hdnUserId" runat="server" Value='<%# Eval("stid") %>' /> 
                                                                <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>                                                      
                                                        
                                                         <asp:TemplateField HeaderText="Marks" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkMarks" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                             <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Testimonials" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                              <asp:CheckBox ID="chkTestimonials" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                             <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Certificate" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                               <asp:CheckBox ID="chkCertificate" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                             <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a id="a3" href="PerformanceSheet.aspx?stid=<%#Container.DataItem("stid")%>&Cid=<%#Container.DataItem("courseID")%>&bt=<%#Container.DataItem("bid")%>">
                                                                    Details</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a id="a3" href="AddClosure.aspx?stid=<%#Container.DataItem("stid")%>&Cid=<%#Container.DataItem("courseID")%>&bt=<%#Container.DataItem("bid")%>">
                                                                    Closure Entry</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                         <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%--<asp:LinkButton ID="btnCloserLetter" runat="server" Visible="false" Text="Closure Letter" CommandName="BatchID" CommandArgument='<%#Eval("bid") %>'></asp:LinkButton>--%>
                                                                <asp:LinkButton ID="btnCloserLetter" runat="server" Visible="false" Text="Closure Letter" CommandName="BatchID" CommandArgument='<%#Eval("BatchCode") %>'></asp:LinkButton>
                                                                <%--<a id="a3" href="closureletter.aspx?stid=<%#Container.DataItem("fullname")%>&bt=<%#Container.DataItem("bid")%>">
                                                                    Closure Letter</a>--%>
                                                                <%--<asp:Label ID="lblCloserLetter" runat="server" Text='<%#Eval("fullname") %>' Visible="false"></asp:Label>--%>
                                                                
                                                                <%--<asp:LinkButton ID="LinkButton1" runat="server" Visible="false" Text="Closure Letter" CommandName="FullName" CommandArgument='<%#Eval("fullname") %>'></asp:LinkButton>
                                                                <asp:HiddenField ID="hdfCloserLetter" runat="server" Value='<%#Eval("fullname") %>' />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                 <asp:LinkButton ID="btnGenerateCertificate" runat="server" Visible="false" Text="Certificate" CommandName="Certificate" CommandArgument='<%#Eval("BatchCode") %>'></asp:LinkButton>
                                                                <asp:HiddenField ID="hdncStartDate" runat="server" Value='<%#Eval("cStartDate") %>' />
                                                                <asp:HiddenField ID="hdncEndDate" runat="server" Value='<%#Eval("cEndDate") %>' />
                                                                <asp:HiddenField ID="hdnDuration" runat="server" Value='<%#Eval("cmonth") %>' />
                                                                <asp:HiddenField ID="hdnCoursetype" runat="server" Value='<%#Eval("Coursetype") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                   

                                                    </Columns>
                                                </asp:GridView>
                                                 </ContentTemplate>
    </asp:UpdatePanel>
     
        </div>
        </div>
     </div>   
        <div class="modal hide fade in" id="CertificateForm" aria-hidden="false">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>Certificate Form</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body">
        <form class="form-inline" action="index.html" method="post" id="form-login">
            
        </form>
        
    </div>
    <!--/Modal Body-->
</div>

        </section>
    </div>
    </form>
</asp:Content>
