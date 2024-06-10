<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="AddGroup.aspx.cs" Inherits="Faculty_AddGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
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

    <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
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
    <h1 class="heading-color">Add Group for Batch</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Add Group for Batch</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
  
     
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
            
  
    <section class="container main m-tb">  
    <div class="user-info media box" style="background-color:#fff;">
       <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                </div>                  
                        
                <fieldset>
                
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlCourse" AutoPostBack="true" ToolTip="Course Code" runat="server" CssClass="input-block-level" onselectedindexchanged="ddlCourse_SelectedIndexChanged" />
                                   <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlBatch" AutoPostBack="true" ToolTip="Batch" runat="server" CssClass="input-block-level" onselectedindexchanged="ddlBatch_SelectedIndexChanged"/>
                                   <asp:Label ID="lblreqBatch" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                </div>
                
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtGroupName" runat="server" ToolTip="Group Name" placeholder="Group Name" CssClass="input-block-level" ></asp:TextBox>
                                    <asp:Label ID="lblGroupName" runat="server" ForeColor="Red" Text=""></asp:Label></div>
<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"></div>
</div>

    <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdncoursecode" runat="server" /></div>
                </div>
                        
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" onclick="btnSave_Click"/>
                <asp:button ID="Imagebutton2" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx"/>
                                                    </div>
                                                    </div>
                                                    </fieldset>

      
                <fieldset>
                </div>
                <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend ><strong class="style9_sec">View existing Group</strong></legend></div>
                </div>
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" Width="100%" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" 
                                                    PagerStyle-HorizontalAlign="Center" PageSize="10"  class="table"
                                                                AllowPaging="True" onrowcommand="grdExamSet_RowCommand" 
                                                                        onrowdatabound="grdExamSet_RowDataBound" 
                                                                        onrowdeleting="grdExamSet_RowDeleting" 
                                                                        onrowcancelingedit="grdExamSet_RowCancelingEdit" 
                                                                        onrowediting="grdExamSet_RowEditing" onrowupdating="grdExamSet_RowUpdating" 
                                                                >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                   
                                                    
                                                                          <PagerStyle HorizontalAlign="Center" />
                                                    
                                                                          <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                       
                                                      
                                                       
                                                       <asp:TemplateField HeaderText="Group Name">
                                                        <ItemStyle Width="150px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblGroupName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GroupName")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                        <EditItemTemplate>
                                                                        <asp:TextBox ID="txtGroupName" runat="server" MaxLength="300" CssClass="NormalText"
                                                                            Text='<%# Bind("GroupName") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Batch Code">
                                                        <ItemStyle  Width="250px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblBatchCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BatchCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px"
                                                                    ShowEditButton="True" ShowHeader="True" >
                                                            <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:CommandField>
                                                            
                                                         <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkDeletePaper" runat="server" CommandName="Delete" CommandArgument='<%# Eval("GroupId") %>'>
                                                                     Delete</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                         <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkAssign" runat="server" CommandName="Assign" CommandArgument='<%# Eval("GroupId") %>'>
                                                                     Assign Student in Group</asp:LinkButton>
                                                                     <asp:HiddenField ID="hdnId" runat="server" Value='<%# Eval("GroupId") %>' />
                                                                     <asp:HiddenField ID="hdnBid" runat="server" Value='<%# Eval("bid") %>' />
                                                                     
                                                                 </ItemTemplate>
                                                          </asp:TemplateField>    
                                                             
                                                    </Columns>
                                                 
                                                </asp:GridView>
                 </div>
                 </div> 
                                                
                              
                                            </fieldset>
                                            </div>
                                            </section>
                    
   
    </div>
    
   
    </form>
</asp:Content>



