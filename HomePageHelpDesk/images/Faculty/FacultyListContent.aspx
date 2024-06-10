<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="FacultyListContent.aspx.vb" Inherits="Faculty_FacultyListContent" Title="List of Course" %>

<%--<%@ Register Src="../facultyHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
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
    <h1 class="heading-color">Faculty List Content</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Faculty List Content</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    
  <section class="container main m-tb" >
    <%--<div onkeypress="javascript:HideMessage()">
    </div>--%>
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">     
                                                   <asp:GridView ID="GrdCourseApply" AutoGenerateColumns="false" runat="server" DataKeyNames="Fid" CssClass="table"
                                                    Width="97%" AllowPaging="true" PageSize="10">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle Font-Names="arial"  />
                                                    
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="form_head" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseTitle") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                               
                                                                    <%# Eval("CourseCode") %> 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="View Material" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <a id="a1" href="ListFacContent.aspx?id=<%#Container.DataItem("courseID")%>">
                                                                    view </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                    
                                                </asp:GridView>
                                                </div>
                                                </div>
                                                </div>

                                                </div>
                                                </div>
                                            
    </section>
    </form>


    </asp:Content>