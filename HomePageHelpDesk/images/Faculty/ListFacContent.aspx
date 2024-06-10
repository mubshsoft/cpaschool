<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ListFacContent.aspx.vb" Inherits="Faculty_ListFacContent" Title="List of Course" %>

<%--<%@ Register Src="../facultyHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

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
    <h1 class="heading-color">Faculty List Content</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Faculty List Content</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">

   

   <section class="container main m-tb">
   <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                 <asp:DropDownList ID="dllSem" runat="server" AutoPostBack="true" CssClass="input-block-level"></asp:DropDownList>
                 <asp:Label ID="lblSem" runat="server" style="font-weight:bold"></asp:Label>
                 </div></div>
                 </div>
                 <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
<asp:DataList ID="dlModules" runat="server" width="100%">
                                                    <ItemTemplate>
                                                        
                                                            <div class="row">
                                                                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">
                                                                    <asp:Label ID="lblModuleid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "moduleid")%>'
                                                                            Visible="false" />
                                                                        <b><asp:Label ID="lblModule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "moduletitle")%>' /></b>
                                                                        </div>
                                                                        </div>
                                                                
                                                        <asp:DataList ID="dlPaper" runat="server" OnItemDataBound="dlPaper_ItemDataBound" Width="100%">
                                                            <ItemTemplate>
                                                                
                                                                     <div class="row">
                                                                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center" style="background-color:#EBEBEB">
                                                                                <asp:Label ID="lblPaperid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "paperid")%>'
                                                                                    Visible="false" />
                                                                               <h4><b> <asp:Label ID="lblPaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>' /></b></h4>
                                                                               </div>
                                                                               </div>
                                                                        
                                                                   <div class="row">
                                                                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 arial"><h4>Units</h4></div>
                                                                   </div>
                                                                 
                                                                <asp:DataList ID="dlunit" runat="server" Width="100%">
                                                                    <ItemTemplate>
                                                                    <div class="row">
                                                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10" style="border-bottom:solid 1px #ccc" >
                                                                                    <%#DataBinder.Eval(Container.DataItem, "unittitle")%>
                                                                                </div>
                                                                                
                                                                                 <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2" >
                                                                                                  <a id="a1" href="../facultyDownLoadDetails.aspx?uid=<%#Container.DataItem("UnitId")%>" >

                                                                                                       Download
                                                                                                  </a>
                                                                                                     
                                                                                                       
                                                                                 </div>
                                                                            </div>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </ItemTemplate>
                                                </asp:DataList>
     </div>
     </div>

    </div>
    </div>


</section>

    
                                                
                                            
    
    </form>

</asp:Content>