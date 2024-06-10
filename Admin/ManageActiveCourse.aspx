<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="ManageActiveCourse.aspx.cs" Inherits="Admin_ManageActiveCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    
   
      <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">List Of Course</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
       <li class="active">List Of Course</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">

    
  <section class="container main m-tb">


<div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row" align="center" > 
                 <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red" Visible="false" ></asp:Label>
                 </div>
                 
                     
                
                  <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                 
                 <asp:GridView ID="grdCourse" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdCourse_RowDataBound" class="table">
                 <HeaderStyle CssClass="form_head" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" ItemStyle-Width="250" />
                        <asp:BoundField DataField="CourseTitle" HeaderText="Course Title" ItemStyle-Width="250" />
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                             <asp:TextBox ID="txtseq" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "OrderNumber")%>' type="number" min="0" max="10"   />
                                <asp:HiddenField ID="hdnCourseId" Value='<%#DataBinder.Eval(Container.DataItem, "CourseId")%>' runat="server" />
                                <asp:HiddenField ID="hdnApprove" Value='<%#DataBinder.Eval(Container.DataItem, "Check")%>' runat="server" />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView> 
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                <asp:Button ID="Button1" Text="Update" OnClick="InsertRecord" CssClass="btn btn-large btn-success" runat="server" />
                
                 
                 </div>
                                                </div>
                                                                    
        
       
       </div>
       </div>             
    </div>                            
                
   </section>
    </form>

</asp:Content>






