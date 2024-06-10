<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAssessmentsChapter.aspx.cs" Inherits="Student_ViewAssessmentsChapter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    
    <style>

   
.container{
    width: 800px;
    border: 1px solid #ddd;
    border-radius: 5px; 
    overflow: hidden;
    display:inline-block;
    margin:10px 40px 10px 150px;
    vertical-align:top;
    text-align:center;
}

.progressbar {
    color: #fff;
    text-align: right;
    height: 25px;
    width: 0;
    background-color: #0ba1b5; 
    border-radius: 3px; 
}
 </style>

   

     <link type="text/css" rel="stylesheet" href="../css/easy-responsive-tabs.css" />
      <script src="../js/vendor/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../js/easyResponsiveTabs.js" type="text/javascript"></script>
     <script>
        function setProgress(progress) {
            var progressBarWidth = progress * $(".container").width() / 100;
            $(".progressbar").width(progressBarWidth).html(progress + "% ");
        }
    </script>

    <script type="text/javascript">
        function abc()
        {
            alert('hi');
        }
        $(document).ready(function () {
            //var tot = parseInt($("#hdnTotalCount").val());
            //var tothit = parseInt($("#hdnHitCount").val());
            //var per = Math.round(tothit / tot * 100);
            //setProgress(per);

            $('#verticalTab').easyResponsiveTabs({
                type: 'vertical',
                width: 'auto',
                fit: true
            });
            var id = $("ul#chapterlist li:first").attr("id");
            if (id != null)
            {
                var TypeName = $(this).attr('name');
                if (TypeName != "Assessments Question") {
                    ReadingChapter(id);
                }
                
            }
           
           
            $('ul#chapterlist li').click(function (e) {
                var TypeName = $(this).attr('name');
                if (TypeName != "Assessments Question") {
                    ReadingChapter(this.id);
                }
            });
        });

        function ReadingChapter(id)
        {
            var UnitId = $("#hdnUnitId").val();
            var ChapterID = id;

            $.ajax({
                type: "POST",
                url: "ViewAssessmentsChapter.aspx/CallReadingChapter",


                data: "{UnitId: '" + UnitId + "', ChapterID: '" + ChapterID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var d = data.d;
                    
                    var tot = parseInt($("#hdnTotalCount").val());
                    var tothit = parseInt(d);
                    var per = Math.round(tothit / tot * 100);
                   // alert("total -" + tothit);
                    setProgress(per);
                   
                    if (d == "-1") {
                        alert("Error Inserting!");
                    }

                    else {
                        //alert("Thank you for submitting the details.");
                        //window.location.href = "default.aspx";
                    }

                },
                failure: function (response) {
                    alert("Error");
                }
            });
        }
</script>

    
    </head>
<body>
    <form id="form1" runat="server">    
   <%--<div id="verticalTab1">
            <ul class="resp-tabs-list">
                <li>Tab Panel 1</li>
                <li>Tab Panel 2</li>
                <li>Tab Panel 3</li>
                <li>Tab Panel 4</li>               
            </ul>
            <div class="resp-tabs-container" style="width:800px;min-height: 600px">
                <div>
                  Tab Panel-1 content
                </div>
                <div>
                    
                    <iframe id="f" src="test.html" style="width:780px;min-height: 600px" ></iframe>
                    
                </div>
                <div>
                     <iframe id="fpdf" src="Upload/09042020/Semester 1/Module 1/FCRA Concepts and Practice/9789390020508 (6)-2.pdf" toolbar="0" disableprint="true"  style="width:780px;min-height: 600px" ></iframe>
                </div>
                <div>
                    Tab Panel-4 content
                </div>
                 
            </div>
        </div>  --%>
        <table width="100%">
            <tr>
                <td width="5%"></td>
                <td width="95%" align="left">
                    <div class="container"><div class="progressbar"></div></div>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td width="5%"></td>
                <td width="95%" align="center">
                    <asp:PlaceHolder ID = "PlaceHolder1" runat="server"  />  
                    <asp:HiddenField ID="hdnUnitId" runat="server" />
                    <asp:HiddenField ID="hdnTotalCount" runat="server" />
                    <asp:HiddenField ID="hdnHitCount" runat="server" Value="0" />
                    
                    
                </td>
            </tr>
            <tr>
                 <td width="5%">
                    
                 </td>
                <td width="95%">
                     
                    <br /><br />
                </td>
            </tr>
        </table>
        
    </form>
    
</body>
</html>
