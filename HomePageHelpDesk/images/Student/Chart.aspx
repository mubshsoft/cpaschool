<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="Student_Chart" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Performance Sheet
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List of Course</li>
          </ol>
        </section>
    <section class="content">
     <div class="row" >
    <div class="row-fluid">
                <div class="span6">
                 
                          <div id="chartContainer1" style="height: 300px; width: 100%;display:none;"></div>
<script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>     
                
   
    </div>
                 <div class="span6">
                    <div class="box box-info">
                <div class="box-header">
                  <i class="fa fa-area-chart"></i>
                  <h3 class="box-title">Progress Report
                  </h3>
                  
                  <div class="pull-right box-tools">
                    <asp:DropDownList ID="ddlPaper" runat="server" ></asp:DropDownList>
                    
                  </div><!-- /. tools -->
                </div>
                <div class="box-body">
                   <div id="chartContainer" style="height: 300px; width: 100%;"></div>
                    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
                   <asp:HiddenField ID="hdnBid" runat="server" />
                </div>
               
              </div>
                 </div>
    </div>
    </div>
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js" ></script>
    
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
            BindGetPaperList();
            $("#<%=ddlPaper.ClientID %>").change(function () {
                //alert($('option:selected', this).val());
                PaperID = $('option:selected', this).val();
                //alert(PaperID);
                $.ajax({
                    type: "POST",
                    url: "StudentDashboard.aspx/GetStudentProgressPie",
                    data: "{PaperID:'" + PaperID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessPie,
                    failure: function (response) {
                        alert("Error");
                    }
                });
            });

            $.ajax({
                type: "POST",
                url: "StudentDashboard.aspx/GetStudentProgressPie",
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
          
            var chart = new CanvasJS.Chart("chartContainer", {
                exportEnabled: true,
                animationEnabled: true,
                title:{
                    text: "Paper Marks"
                },
                legend:{
                    cursor: "pointer",
                    itemclick: explodePie
                },
                data: [{
                    type: "pie",
                    showInLegend: true,
                    toolTipContent: "{name}: <strong>{y}</strong>",
                    indexLabel: "{name} - {y}",
                    dataPoints:pdata[0]
                }]
            });
            chart.render();
        }

        function explodePie (e) {
            if(typeof (e.dataSeries.dataPoints[e.dataPointIndex].exploded) === "undefined" || !e.dataSeries.dataPoints[e.dataPointIndex].exploded) {
                e.dataSeries.dataPoints[e.dataPointIndex].exploded = true;
            } else {
                e.dataSeries.dataPoints[e.dataPointIndex].exploded = false;
            }
            e.chart.render();

        }
   
</script>
<script type="text/javascript">
    var data = [];
    var pdata = []
  
       
        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "Chart.aspx/GetStudentProgressRpt",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert("Error");
                }
            });
        });
        var res = "";
        function OnSuccess(response) {
            //res = response;
            var donutData = JSON.parse(response.d);
           // alert(response.d);
            res = donutData;
            pdata = donutData;
           
            //        var ctxp = $("#pieChartDemo").get(0).getContext("2d");
            //        var barChart = new Chart(ctxp).Pie(pdata);
       
        //data  = pdata;
            data=[ [
        			{ y: 243, label: "2017" },
        			{ y: 236, label: "2018" },
        			{ y: 243, label: "2019" },
        			{ y: 273, label: "2020" },
        			{ y: 269, label: "2021" },
        			{ y: 196, label: "2022" },
        			{ y: 1118, label: "2023" }
        		],
                [
        			{ y: 213, label: "2017" },
        			{ y: 336, label: "2018" },
        			{ y: 443, label: "2019" },
        			{ y: 233, label: "2020" },
        			{ y: 259, label: "2021" },
        			{ y: 296, label: "2022" },
        			{ y: 1128, label: "2023" }
        		],
                 [
        			{ y: 236, label: "2017" },
        			{ y: 172, label: "2018" },
        			{ y: 309, label: "2019" },
        			{ y: 302, label: "2020" },
        			{ y: 285, label: "2021" },
        			{ y: 188, label: "2022" },
        			{ y: 788, label: "2023" }
        		]];
            var chart = new CanvasJS.Chart("chartContainer1", {
                animationEnabled: true,
                theme: "light2",
            title: {
                text: "Progress Report of Student"
            },
            axisY: {
                title: "Marks per subjects"
            },
            legend: {
                cursor: "pointer",
                itemclick: toggleDataSeries
            },
            toolTip: {
                shared: true,
                content: toolTipFormatter
            },
            data: [{
                type: "column",
                showInLegend: true,
                name: "Paper 1",
                color: "#2196F3",
                dataPoints: pdata[0]
            },
            {
                type: "column",
                showInLegend: true,
                name: "Paper 2",
                color: "#FF9800",
                dataPoints: pdata[1]
            }]
        });
        chart.render();

        function toolTipFormatter(e) {
            var str = "";
            var total = 0;
            var str3;
            var str2;
            for (var i = 0; i < e.entries.length; i++) {
                var str1 = "<span style= \"color:" + e.entries[i].dataSeries.color + "\">" + e.entries[i].dataSeries.name + "</span>: <strong>" + e.entries[i].dataPoint.y + "</strong> <br/>";
                total = e.entries[i].dataPoint.y + total;
                str = str.concat(str1);
            }
            str2 = "<strong>" + e.entries[0].dataPoint.label + "</strong> <br/>";
            //str3 = "<span style = \"color:Tomato\">Total: </span><strong>" + total + "</strong><br/>";
            //return (str2.concat(str)).concat(str3);
            return (str2.concat(str));
        }

        function toggleDataSeries(e) {
            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                e.dataSeries.visible = false;
            }
            else {
                e.dataSeries.visible = true;
            }
            chart.render();
        }
    }
   
</script>
    </asp:Content>



