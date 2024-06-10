<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="AssignStudentinGroup.aspx.cs" Inherits="Faculty_AssignStudentinGroup" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    
   <script language="javascript" type="text/javascript">
       function openPopuppage(asgnid, uid) {
           window.open("../Admin/AssignmentFinalAnswerSheet.aspx?AssignmentType=Manual" + "&AsgnId=" + asgnid + "&uid=" + uid + "", "Info", "status=1, width=700, height=450, top=200, left=300");
           
       }
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
               function openPopup(id)
                     {
                    open("../Student/QueryDetails.aspx?lstquerydetails=" + id, "Info", "status=1, width=510, height=650, top=20, left=300");
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
    <h1 class="heading-color">List Of Student</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">List Of Student</li>
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
                 
                 <asp:GridView ID="grdStudent" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdStudent_RowDataBound" class="table">
                 <HeaderStyle CssClass="form_head" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="250" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email" ItemStyle-Width="250" />
                        <asp:BoundField DataField="batchcode" HeaderText="Batch" ItemStyle-Width="250" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnstid" Value='<%#DataBinder.Eval(Container.DataItem, "stid")%>' runat="server" />
                                <asp:HiddenField ID="hdnbid" Value='<%#DataBinder.Eval(Container.DataItem, "bid")%>' runat="server" />
                                <asp:HiddenField ID="hdnApprove" Value='<%#DataBinder.Eval(Container.DataItem, "Approve")%>' runat="server" />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView> 
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" >
                <asp:Button ID="Button1" Text="Assign" OnClick="Bulk_Insert" CssClass="btn btn-large btn-success" runat="server" />
                
                  <asp:HiddenField ID="hdnGroupid" runat="server" Value="" />
                  <asp:HiddenField ID="hdnBid" runat="server" Value="" />
                 </div>
                                                </div>
                                                                    
        
       
       </div>
       </div>             
                                
                
   </section>
    </form>

</asp:Content>




