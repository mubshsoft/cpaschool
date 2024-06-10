<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="AssignExamToFaculty.aspx.cs" Inherits="Admin_AssignExamToFaculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
     <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
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
    <h1 class="heading-color">Submit Assignment</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a></li>
       <li class="active">Submit Assignment</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
     <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 <strong><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></strong>
                                         </div></div>
    
     <fieldset>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend>Exam Details</legend>
     </div></div>

    <div class="row" >
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Exam Code :</div>
    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblAssignCode" runat="server" Text=""></asp:Label></div>
    </div>
                                                    
    <div class="row" >
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Course Title :</div>
    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblCourseTitle" runat="server" Text=""></asp:Label></div>
    </div>
    <div class="row" >
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Paper Title :</div>
    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblPtitle" runat="server" Text=""></asp:Label></div>
    </div>
     
                                                               </fieldset> 
                                                        
                                                  
                                                    <div class="row" >
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Faculty :</div>
    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlFaculty" runat="server" CssClass="form-control"></asp:DropDownList></div>
    </div>
    <div class="row">&nbsp;</div>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" 
                                                                onclick="btnSave_Click"/>
                                                           <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server" 
                                                                onclick="btnClose_Click"/>
                                                        </div>
                                                        </div>
                                                        </div>
                                                        <div class="user-info media box" style="background-color:#fff;">
                                                        <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                           <fieldset>
                                                           <legend>De-Activate Assignment from faculty</legend>
                                                            
                                                                           <asp:GridView ID="grdActveFaculty" runat="server" AutoGenerateColumns="False"  CssClass="table"
                                                    Width="100%"  AllowPaging="True" PageSize="10"    
                                                            PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" 
                                                    PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center" 
                                                            onrowcommand="grdActveFaculty_RowCommand" >
                                                    
                                                        <HeaderStyle Font-Bold="true" BackColor="ActiveBorder" CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Student name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email ">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                           <asp:TemplateField HeaderText="Activate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactvate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "activate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                  
                                                       <asp:TemplateField>
                                                                 <ItemTemplate>
                                                                     <asp:LinkButton ID="lnkDeactivate" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("id") %>'>
                                                                     Deactivate</asp:LinkButton>
                                                                 </ItemTemplate>
                                                          </asp:TemplateField> 
                                                       
                                                    </Columns>
                                                    
                                                </asp:GridView>
                                                                      
                                                               </fieldset> 
                                                            </div>
                                                            </div></div>
     </div>      
    </form>
</asp:Content>
