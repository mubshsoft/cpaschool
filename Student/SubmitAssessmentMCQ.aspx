<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitAssessmentMCQ.aspx.cs" Inherits="Student_SubmitAssessmentMCQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <%--  <script src="../js/vendor/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        
        $(document).ready(function () {

        });

        function ReadingChapter(UnitId, ChapterID) {

            $.ajax({
                type: "POST",
                url: "SubmitAssessmentMCQ.aspx/CallReadingChapter",
                data: "{UnitId: '" + UnitId + "', ChapterID: '" + ChapterID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var d = data.d;
                  //  window.parent.setProgress();
                    if (d == "-1") {
                        alert("Error Inserting!");
                    }
                },
                failure: function (response) {
                    alert("Error");
                }
            });
        }
        

</script>--%>
<style>
.btn-blue 
{
    background: #0ba1b5;
    color: #fff;
    border: 0;
    padding: 15px;
    border-radius: 5px;
    font-size: 16px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 well" style="background:#fff">
                                                                <asp:DataList ID="dlsquestion" Width="100%" runat="server" OnItemDataBound="dlsquestion_ItemDataBound">
                                                                    <ItemTemplate>
                                                                                
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border-bottom: solid 1px #f3f1f1; margin-bottom :10px;">
                                                                                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                                                                        <div style="font-size: 14px;font-weight: 100;font-variant: small-caps;">
                                                                                           <asp:Label ID="lblSection" runat="server" Text=""
                                                                                            VerticalAlign="Top"></asp:Label>
                                                                                            
                                                                                            <asp:Label ID="lblSectionInfo" runat="server" VerticalAlign="Top" />
                                                                                           
                                                                                            </div>
                                                                                      </div>
                                                                                      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="font-size: 14px;font-weight: 100;font-variant: small-caps; display:none">
                                                                                      <span class="pull-right">
                                                                                        Marks:[<asp:Label ID="lblMarks" Font-Size="13px" CssClass="style5" runat="server"
                                                                                            Text='<%#DataBinder.Eval(Container.DataItem, "MaxQueMarks")%>' />]
                                                                                        </span>
                                                                                       </div>
                                                                                    
                                                                                 </div>
                                                                                
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="background: #e8e8e8; padding: 10px; border-radius: 5px; font-family: arial;">
                                                                                   
                                                                                        <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                                        <asp:HiddenField ID="hdnQUESTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>' />
                                                                                        <asp:HiddenField ID="hdnOPTIONTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "OPTIONTYPE")%>' />
                                                                                        <%--<asp:HiddenField ID="hdnCategoryId" runat="server"  />--%>
                                                                                        <span style="vertical-align: top">
                                                                                            <asp:Label ID="Label2" runat="server" Text="Question" Font-Bold="true" VerticalAlign="Top"></asp:Label>
                                                                                            <asp:Label ID="lblRowID" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "ROWID")%>'
                                                                                                VerticalAlign="Top"></asp:Label>
                                                                                            <asp:Label ID="Label3" runat="server" Text=":" VerticalAlign="Top" Font-Bold="true"></asp:Label></span>
                                                                                        <asp:Label ID="lblName" runat="server" Font-Size="13px" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'
                                                                                            VerticalAlign="Top" CssClass="style5" Font-Bold="true"></asp:Label>
                                                                                                            
                                                                                                      
                                                                                        <%-- <asp:Label ID="lblspacetext" runat="server" Width="10px"></asp:Label>
                                                                                        <br />--%>
                                                                                        &nbsp;
                                                                                   
                                                                                </div>
                                                                                                
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                                                                                    <asp:Image runat="server" ID="imgQue" Visible="false"/>
                                                                                    <asp:HiddenField ID="hdnImagepath" runat="server" Value="" />
                                                                                </div>
                                                                                                       
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="font-family: arial; line-height: 30px; padding: 10px; background: #f1f1f1;">
                                                                                        <asp:Panel ID="panel4" runat="server">
                                                                                        </asp:Panel>
                                                                                </div>
                                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                                        <asp:Panel ID="panel5" runat="server" Font-Bold="false" Font-Size="12px">
                                                                                        </asp:Panel>
                                                                                </div>
                                                                                
                                                                                
                                                                            </ItemTemplate>
                                                                </asp:DataList> 
                                                              
                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="row">&nbsp;</div>
                                                                <div class="row" id="tbl" runat="server">
                                                               
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblAnsMsg" Text="" runat="server" style="font-family: arial;" ></asp:Label></div>
                                                               </div>
                                                                <div class="row">
                                                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                        <label>&nbsp;</label><asp:CheckBox ID="ChkReview" runat="server" Text="Mark for review"
                                                                                                                    Visible="false" CssClass="style5" ForeColor="Black" />
                                                                                                        
                                                                                                            <asp:HiddenField ID="hdnFileName" runat="server" />
                                                                                                    </div>
                                                                                                    </div>
                                                                                                    <div class="row">&nbsp;</div>
                                                                <div class="row">
                                                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">                                          
                                                                                            <asp:Button ID="btnchkAnswer" runat="server" Text="Check Answer" CssClass="btn-blue" onclick="btnchkAnswer_Click"  />
                                                                                            <asp:Button ID="btnprev" runat="server" border="0" CssClass="btn-blue"  Text="Previous" OnClick="btnprev_Click1" />
                                                                                            <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="btn-blue"  OnClick="btnnext_Click"  style="width:160px" />
                                                                                            <asp:Button ID="btnEndExam" runat="server" Text="End Exam" CssClass="btn-blue"  OnClick="btnEndExam_Click"   OnClientClick="return confirm('You are about to end the Assessment. Click OK to end.');" Visible="false"  style="width:160px" />
                                                                </div>
                                                                </div>
                                                                <div class="row">
                                                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                                                                            
                                                                                                            <asp:HiddenField ID="hdnUserId" runat="server" />
                                                                                                            <asp:HiddenField ID="hdnBid" runat="server" />
                                                                                                            <asp:HiddenField ID="hdnUnitid" runat="server" />
                                                                                                            <asp:HiddenField ID="hdnChapter" runat="server" />
                                                                                                        </div>
                                                                                                        </div>
                                                               </div>
                                                            </div>
  </div>
                                                    
    </form>
</body>
</html>
