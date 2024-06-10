<%@ Page Language="VB" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="false" CodeFile="NotificationList.aspx.vb" Inherits="NotificationList" Title="Notification List" %>




 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
    .date {
    font-size: 15px;
    font-weight: 400;
    margin-bottom: 15px;
}
.date span {
    padding-right: 15px;
    display: inline-block;
    min-width: 32%;
}
</style>
</asp:Content>

     <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

 
    <div class="content-wrapper">
<!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Notification List
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active"> Notification List</li>
          </ol>
        </section>
    <section class="content">
     
        <div class="row">&nbsp;</div>
         <div class="row">
                 <asp:Repeater ID="rptNews" runat="server">
                                                   
                                                    <ItemTemplate>
                                                      <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" >
              <div class="box box-border">
               <div class="box-header ">
    <h3 class="box-title"><%# DataBinder.Eval(Container.DataItem, "mailtype")%></h3>
    <div class="box-tools pull-right">
      <!-- Buttons, labels, and many other things can be placed here! -->
      <!-- Here is a label for example -->
     <div class="date"><span><i class="ion ion-android-calendar"></i> <%# FormatDateTime(DataBinder.Eval(Container.DataItem, "ndate"), 2)%></span> </div>
    </div>
    <!-- /.box-tools -->
  </div>
  <!-- /.box-header -->
          <h4></h4>
              <div class="box-body">
           
		<!--  -->
	
	
 
		<div >
			<p><%#DataBinder.Eval(Container.DataItem, "descr")%></p>
			</div>
	
              </div>
              </div>
              </div>
                                                    




                                                        
                                                    </ItemTemplate>
                                                  
                                                </asp:Repeater>
                    </div>                       
       </section>
    </div>

    
  

</asp:Content>