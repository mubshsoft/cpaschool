<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="DetailsNewsEvents.aspx.vb" Inherits="DetailsNewsEvents" Title="Details News/Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
.newsbox .contents {
    height: 150px;
    min-height:150px;
    background: #fff;
    border: none;
    padding: 30px;
}
.contents {
    width: 100%;}
    .contents .title {
    font-size: 17px;
    color: #1a2950;
    position: relative;
    display: block;
    overflow: hidden;
    text-overflow: ellipsis;
    display: -webkit-box;
    -webkit-line-clamp: 2;
    -webkit-box-orient: vertical;
    padding-right: 30px;
}
.title {
    font-size: 14px;
    font-weight: 600;
    min-height: 40px;
    margin-bottom: 10px;
}
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

.attachlink {
    margin-right: 15px;
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


                                                <asp:Repeater ID="rptNews" runat="server">
                                                    <HeaderTemplate>
                                                    <table class="table">
                                                        
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="padding:1em">
<div class="newsbox">
	
	<div class="contents">
		<!--  -->
	<%--<a href="https://www.incometaxforngos.org/news/extension-of-due-date-for-revalidation-under-income-tax?cat=news"><div class="title">Extension of Due Date for Revalidation under Income Tax</div></a>--%>
	<div class="date"><span><i class="calenders"></i> <%# FormatDateTime(DataBinder.Eval(Container.DataItem, "NewsDate"),2) %></span> </div>
 
		<div class="content">
			<p><%#DataBinder.Eval(Container.DataItem, "NewsDesc")%></p>
			</div>
	</div>
</div>
</div>




                                                        
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                           
         <div class="row-fluid" style="margin-top: 20px;">
            <div class="span12">
                                                <asp:Repeater ID="rptEvents" runat="server" Visible="False">
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