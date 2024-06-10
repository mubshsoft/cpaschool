<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="DetailsNewsEvents.aspx.vb" Inherits="DetailsNewsEvents" Title="Details News/Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color" style="padding: 40px;">
	<h1 class="heading-color">News &amp; Events</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<li>
                <ul>
                <%If Session("role") = "Admin" Then%>
                            <li><a href="admin/AdminLogin.aspx"><i class="fa fa-user"></i> Admin Panel</a></li>
            <li class="active">List of topics</li>
                        <% ElseIf Session("role") = "Faculty" Then %>
                            <li><a href="faculty/Facultypanel.aspx"><i class="fa fa-user"></i> Faculty Panel</a></li>
            <li class="active">List of topics</li>
                        <% ElseIf Session("role") = "Student" Then%>
                            <li><a href="Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">News</li>
                        <%End If %>
                    </ul>
			</li>
		</ul>

	</div>
</section>
    <!-- / .title -->


    <section id="about-us" class="container main">
<div class="row">&nbsp;</div>  
        <div class="row" style="margin-top: 20px;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                <asp:Repeater ID="rptNews" runat="server">
                                                    <HeaderTemplate>
                                                    <table class="table">
                                                        <tr><td colspan="3" class="form_head">
                                                            <h4 style="color:#fff">News</h4>
                                                          </td>
                                                            </tr>
                                                            <tr style="background-color: #F5FCFF;">
                                                                <th align="left" style="padding: 5px;">
                                                                   <h5>Description</h5>
                                                                </th>
                                                                <th>&nbsp;</th>
                                                                <th align="left" style="padding: 5px;">
                                                                    <h5>Date</h5>
                                                                </th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td width="80%" align="left" valign="top" style="padding:5px; background-color:#fff" >
                                                                <%#DataBinder.Eval(Container.DataItem, "NewsDesc")%>
                                                            </td>
                                                            <td width="5%" style="background-color:#fff">&nbsp;</td>
                                                            <td width="15%" align="left" valign="top" style="padding:5px; background-color:#fff">
                                                                <%# FormatDateTime(DataBinder.Eval(Container.DataItem, "NewsDate"),2) %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                           </div>
                                           </div>
         <div class="row-fluid" style="margin-top: 20px;">
            <div class="span12">
                                                <asp:Repeater ID="rptEvents" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table">
                                                        <tr><td colspan="3" class="form_head">
                                                            <h4 style="color:#fff">Events</h4>
                                                          </td>
                                                            </tr>
                                                             <tr style="background-color: #F5FCFF;">
                                                                <th align="left" style="padding: 5px;">
                                                                    Title
                                                                </th>
                                                                <th align="left" style="padding: 5px;">
                                                                   Description
                                                                </th>
                                                                <th align="left" style="padding: 5px;">
                                                                    Date
                                                                </th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="left" valign="top" class="no-margin">
                                                                <%#DataBinder.Eval(Container.DataItem, "EventTitle")%>
                                                            </td>
                                                            <td align="left" valign="top" class="no-margin">
                                                                <%#DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                            </td>
                                                            <td align="left" valign="top" class="no-margin">
                                                                <%# FormatDateTime(DataBinder.Eval(Container.DataItem, "EventDate"),2) %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            

                                            
                                            </div>
                                            </section>



</asp:Content>