<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ForumTopic1.ascx.vb"
    Inherits="ForumTopic1" %>

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

<div class="well">
<div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Width="100%" CssClass="input-block-level">
                        </asp:DropDownList>
                    </div>
                    
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" >
                        <asp:DropDownList ID="ddlBatch" runat="server" Width="100%" AutoPostBack="true" CssClass="input-block-level">
                        </asp:DropDownList>
                        </div>
                    </div>
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">                
            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"
                CssClass="arial"></asp:Label><br />
            <asp:Button ID="ImgAddTopic" runat="server" Text="Post New Topic" CssClass="btn btn-primary btn-large arial" />
            </div>
                    </div>
                    </div>
        <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto; height:400px">    
            <asp:GridView ID="GrdTopic" AutoGenerateColumns="False" DataKeyNames="subjectid" HeaderStyle-CssClass="form_head"
                Width="97%" runat="server" AllowPaging="True" PageSize="25" OnPageIndexChanging="GrdTopic_PageIndexChanging" CssClass="table">
                <HeaderStyle CssClass="form_head" />
                <RowStyle Font-Names="arial" />
                <AlternatingRowStyle CssClass="grid-altrow-Overtime"  />
                <HeaderStyle CssClass="form_head"  />
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hd1" Value='<%# Eval("SubjectId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Topic" ItemStyle-HorizontalAlign="Left" >
                        <ItemTemplate>
                            <a id="a1" href="allTopic.aspx?id=<%#Eval("SubjectId")%>">
                                <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "title"), "dq$", """"), "com$", ","), "q$", "'"), "amp$", "&")%>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Topic" Visible="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblTopic" Text='<%# Eval("title") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Reply" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalReply" Text='<%# Eval("TPost") %>' runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Post" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblLastPost" Text='<%# Eval("LastPost") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UserName" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" Text='<%# Eval("Createdby") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Read" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalRead" Text='<%# Eval("totalread") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnsubid" runat="server" Value='<%#Container.DataItem("subjectID")%>' />
                            <asp:LinkButton ID="lnkbtnTopics" runat="server" >Edit Topic</asp:LinkButton>
                             <asp:LinkButton ID="lnkbtnreplies" runat="server" Visible="false">Edit Replies</asp:LinkButton>
                          <%--  <a id="ancEditReplies" href="EditReplies.aspx?id=<%#Container.DataItem("subjectID")%>">
                                Edit Replies</a>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
                    </div>
