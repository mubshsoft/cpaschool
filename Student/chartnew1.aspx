<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chartnew1.aspx.cs" Inherits="Student_chartnew1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
     <style>
 
#chart {
  max-width: 400px;
  margin: 10px auto;
}

 </style>
</head>
<body>
    <form id="form1" runat="server">
    
       

    <!-- Content Header (Page header) -->

   
     <div class="row" >
   
              
              <div class="box box-info">
                <div class="box-header">
                 
               
                  
                  <div class="pull-right box-tools" style="display:none">
                    <asp:DropDownList ID="ddlPaper" runat="server" ></asp:DropDownList>
                    
                  </div><!-- /. tools -->
                </div>
                <div class="box-body">
                  
                   <asp:HiddenField ID="hdnBid" runat="server" />
                    <div id="chart" ></div>

                      
                </div>
               
              </div>
    </div>

    
  
   

     <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
     <script src="../js/echarts.js"></script>
      <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
<script type="text/javascript" language="javascript">

    function BindGetPaperList() {

        $.ajax({
            type: "POST",
            url: "StudentDashboard.aspx/GetPaperList",
            data: "{}",
            contentType: "application/json;charset=utf-8 ",
            dataType: "json",
            success: OnSuccessSalute,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }

        });

        return false;
    }

    function OnSuccessSalute(response) {
        var xmlDoc = response.d;
        var customers = eval("(" + xmlDoc + ")");

        var CountRecord = customers.rows.length;

        $("#<%=ddlPaper.ClientID %>").empty().append($("<option></option>").val("[-]").html("Please select"));
        for (var i = 0; i < CountRecord; i++) {
            var customer = customers.rows[i];
            //alert(customer.PaperTitle);
            $("#<%=ddlPaper.ClientID %>").append($("<option></option>").val(customer.paperId).html(customer.PaperTitle));
        }
    }
    </script>
<script type="text/javascript">
    var data = [];
    var pdata = []
    var PaperID = 0;

    $(document).ready(function () {
    
      

        $.ajax({
            type: "POST",
            url: "StudentDashboard.aspx/GetStudentProgressPie1",
            //data: '{}',
            data: "{PaperID:'" + PaperID + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessPie,
            failure: function (response) {
                alert("Error");
            }
        });
    });
    var res = "";
    function OnSuccessPie(response) {
        //res = response;
        var donutData = JSON.parse(response.d);

        res = donutData;
        pdata = donutData;
        var dates = pdata[0];

        //res = response;
        // var ResponeData1 = JSON.stringify(response.d);
        var options = {
          series: pdata[0][0].data,
          chart: {
          width: 400,
          type: 'pie',
        },
        labels: pdata[0][1].label,
         legend: {
          show: true,
          
             
      },
        responsive: [{
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: 'top',
              horizontalAlign: 'right',
            }
          }
        }]
        };

        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();



    }


   
</script>


   
    </form>
</body>
</html>
