<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AdminListFeesstudent.aspx.vb" Inherits="Admin_AdminListFeesstudent" Title="List of Student" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />--%>

    <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
     <script type="text/javascript" src="../stmenu.js"></script>

    
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
    <h1 class="heading-color">List of Students</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of Students</li>
		</ul>
	</div>
    </section>
  
  
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <section class="container main m-tb">
    <div class="row">
    
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate >
                                   <div class="row">
                                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <span style="font-size:large;text-align:center "> <asp:Label ID="lblMsg" runat="server" Text="Promotion Criteria is not available for short term courses.."  ForeColor="Red" Visible="false" ></asp:Label></span>
                                     </div>
                                   </div>
                                  <div class="row">
                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:button ID="btnback" Text="Back" CssClass="btn btn-primary btn-large" runat="server" />
                                        </div>
                                        </div>
                                        
                                        <div class="row">
                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <asp:GridView ID="GrdBatch" AutoGenerateColumns="False" DataKeyNames="bid" CssClass="table"
                                                    runat="server" AllowPaging="True" OnPageIndexChanging="GrdBatch_PageIndexChanging">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20px" ItemStyle-Width="20px">
                                                                                                                    <ItemTemplate>
                                                                                                                  <%#Eval("ROWID")%> 
                                                                                                                      </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="left" ItemStyle-Width="250px">
                                                            <%--<ItemTemplate>
                                                                <asp:Label ID="lblBatchCode" Text='<%# Eval("BatchCode") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <a id="a1" href="Admin_ClearStatus.aspx?batchid=<%#trim(Eval("bid"))%>&stid=<%#trim(Eval("stid"))%>&courseid=<%#trim(Eval("courseid"))%>">
                                                                   <%#Eval("name")%>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="User ID" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseId" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                         <asp:TemplateField HeaderText="Course Id" ItemStyle-HorizontalAlign="Left" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseId" Text='<%# Eval("courseID") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         
                                                         <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("courseTitle") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                           </div>
                                           </div>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                    </div>
                
    </section>
    </form>

</asp:Content>