<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ForumTopic.ascx.vb" Inherits="ForumTopic" %>

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

<div class="row" style="margin-top:20px">
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <span class="pull-right"><asp:Button ID="ImgAddTopic" runat="server" Text="Post New Topic" CssClass="btn btn-success btn-large arial" /></span>
                        </div></div>
                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">&nbsp;</div></div>
 <div class="row">
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    
                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" CssClass="form-control">
                        </asp:DropDownList>
                        </div>
                        </div>
                        
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
      </div></div>         
  <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">      
    
  <asp:GridView ID="GrdTopic" AutoGenerateColumns="False" DataKeyNames="subjectid" CssClass="table"
                Width="100%" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="GrdTopic_PageIndexChanging">
                <HeaderStyle CssClass="form_head"/>
                <RowStyle CssClass="grid-row-Overtime" />
                
                
                <Columns>
                    <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:HiddenField ID="hd1" Value='<%# Eval("SubjectId") %>' runat="server" />
                       </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Topic" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <a id="a1" href="allTopic.aspx?id=<%#Eval("SubjectId")%>">
                                <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "title"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%>
                            </a>
                            <asp:HiddenField ID="hd1" Value='<%# Eval("SubjectId") %>' runat="server" />
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Posted By" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" Text='<%# Eval("Createdby") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Topic" Visible="false"   ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblTopic" Text='<%# Eval("title") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Course" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblcoursecode" Text='<%# Eval("coursecode") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Batch" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblbatchcode" Text='<%# Eval("batchcode") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Group Name" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupName" Text='<%# Eval("GroupName") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Replies" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalReply" Text='<%# Eval("TPost") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Read" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalRead" Text='<%# Eval("totalread") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Post" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblLastPost" Text='<%# Eval("LastPost") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      
                      <asp:TemplateField>
                             <ItemTemplate>
                             <asp:HiddenField ID="hdnsubid" runat="server" Value='<%#Container.DataItem("subjectID")%>'  />
                             <asp:LinkButton ID="lnkbtnreplies" runat="server"  >Edit Topic</asp:LinkButton>
                                 
                             </ItemTemplate>
                     </asp:TemplateField>
                </Columns>
            </asp:GridView>
       </div>
       </div>
