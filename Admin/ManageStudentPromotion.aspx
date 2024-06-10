<%@ Page MasterPageFile="~/InnerMaster.master"Language="VB" AutoEventWireup="false" CodeFile="ManageStudentPromotion.aspx.vb"
    Inherits="Admin_ManageStudentPromotion" Title="Manage Batch" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Manage Batch</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
                     
                     
             function SelectAllCheckboxes(spanChk)
                 {

                    var oItem = spanChk.children;
                    var theBox= (spanChk.type=="checkbox") ? 
                    spanChk : spanChk.children.item[0];
                    xState=theBox.checked;
                    elm=theBox.form.elements;

                        for(i=0;i<elm.length;i++)
                            if(elm[i].type=="checkbox" && 
                                elm[i].id!=theBox.id)
                                {
                                  //elm[i].click();
                                   if(elm[i].checked!=xState)
                                    elm[i].click();
                                   //elm[i].checked=xState;
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
    <h1 class="heading-color">List of batch</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of batch</li>
		</ul>
	</div>
    </section>
   
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    

    <section class="container main m-tb">

    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display:none"><span class="pull-right"><asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server" /></span></div>
    </div>
    <div class="row">  &nbsp;</div>
    <div class="row">   
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red" ></asp:Label>
                                                                </div></div>
                                                                <div class="row">
                                  <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlSemListStudent" runat="server" CssClass="form-control" ToolTip="Select Semester to list student" AutoPostBack=true>
                                                                    </asp:DropDownList></div>
                                  <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlsem" runat="server" CssClass="form-control" ToolTip="Select Semester to Promote">
                                                                    </asp:DropDownList></div>
                                  </div>
                                                            
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            
                                            <div class="row">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                            runat="server" AllowPaging="True" PageSize="5" OnPageIndexChanging="GrdStudent_PageIndexChanging"
                                                            OnRowCommand="GrdStudent_RowCommand">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                            <Columns>
                                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20px" ItemStyle-Width="20px">
                                                                                                                    <ItemTemplate>
                                                                                                                  <%#Eval("ROWID")%> 
                                                                                                                      </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="student Batch Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBatchId" Text='<%# Eval("Id") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="student Batch Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Student Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstid" Text='<%# Eval("stid") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                 <asp:TemplateField HeaderText="Course Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcourseID" Text='<%# Eval("courseid") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStudentFirstName" Text='<%# Eval("firstName") %>' runat="server"
                                                                            ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStudentLastName" Text='<%# Eval("lastName") %>' runat="server"
                                                                           ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkHeader" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                                                        Select All</HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk" Checked='<%# Eval("Promotestatus") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            
                                            <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" />
                                                <asp:Button ID="btncancel" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" />
                                            </div>
                                            <div class="row">&nbsp;</div>
                                            <hr />
                                            </div>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <asp:GridView ID="GrdBatchStatus" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                            runat="server" AllowPaging="True" PageSize="5" 
                                                            OnRowCommand="GrdStudent_RowCommand">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
                                                           <Columns>
                                                                <asp:TemplateField HeaderText="student Batch Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBatchId" Text='<%# Eval("Id") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="student Batch Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Student Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstid" Text='<%# Eval("stid") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                 <asp:TemplateField HeaderText="Course Id" Visible="false" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcourseID" Text='<%# Eval("courseid") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="20px" ItemStyle-Width="20px">
                                                                                                                    <ItemTemplate>
                                                                                                                  <%#Eval("ROWID")%> 
                                                                                                                      </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStudentFirstName" Text='<%# Eval("firstName") %>' runat="server"
                                                                            ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStudentLastName" Text='<%# Eval("lastName") %>' runat="server"
                                                                            ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmail" Text='<%# Eval("semesterTitle") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                              
                                              </div>
                                              </div>
                                              </section>
                                              </div>
                                              
    </form>


</asp:Content>