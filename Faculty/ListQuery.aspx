<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="ListQuery.aspx.vb" Inherits="Faculty_ListQuery" Title="List Query" %>

<%--<%@ Register src="../FacultyHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    
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
    <h1 class="heading-color">List Query</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">List Query</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">

    
  <section class="container main m-tb">

    <%--<div onkeypress="javascript:HideMessage()">
      <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath> 
                                    </div>--%>

<div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row"> 
                 <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                 </div>
                 <div class="well">
                 <div class="row">
                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" align="right"><asp:DropDownList ID="ddlCourse" runat="server" Width="100%" CssClass="input-block-level" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    </div>
                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" align="left"><asp:DropDownList ID="ddlBatch" runat="server" Width="100%" CssClass="input-block-level" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    </div>
                                                                    </div></div>
                                                                    <div class="row-fluid">&nbsp;</div>

                  <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center" style="overflow:auto; height:600px">
                 <asp:GridView ID="GrdQuery" AutoGenerateColumns="false" runat="server" DataKeyNames="QueryId"
                                                    Width="100%" AllowPaging="True" PageSize="10" CssClass="table">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle  Font-Names="arial" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="form_head" />
                                                    <EmptyDataTemplate>
                                                      <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                      </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="QueryId" ItemStyle-HorizontalAlign="Left" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQueryId" Text='<%# Eval("QueryId") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    
                                                                    <asp:TemplateField HeaderText="Student Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStName" Text='<%# Eval("studentName") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                       <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%" >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCode" Text='<%# Eval("coursecode") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%"  >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBatchCode" Text='<%# Eval("batchcode") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                        <asp:TemplateField HeaderText="Posted on" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostedOn" Text='<%# Eval("QueryDate") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Query" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45%"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuery" Text='<%# Eval("Query") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%"  >
                                                            <ItemTemplate>
                                                               <asp:LinkButton  ID="lblStatus" Text='<%#ReplaceStatus(Eval("Status"))%>'  runat="server"  ></asp:LinkButton>
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
