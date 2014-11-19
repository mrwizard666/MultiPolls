//$(document).ready(function () {

//    var options = {
//        chart: {
//            renderTo: 'container',
//            type: 'column'
//        },
//        title: {
//            text: 'Tiny Tool Monthly Sales'
//        },
//        subtitle: {
//            text: '2014 Q1-Q2'
//        },
//        xAxis: {
//            categories: []
//        },
//        yAxis: {
//            title: {
//                text: 'Sales'
//            }
//        },
//        series: []
//    };
//    // JQuery function to process the csv data
//    $.get('/Scripts/column-data.csv', function (data) {
//        // Split the lines
//        var lines = data.split('\n');
//        $.each(lines, function (lineNo, line) {
//            var items = line.split(',');

//            // header line contains names of categories
//            if (lineNo == 0) {
//                $.each(items, function (itemNo, item) {
//                    //skip first item of first line
//                    if (itemNo > 0) options.xAxis.categories.push(item);
//                });
//            }

//                // the rest of the lines contain data with their name in the first position
//            else {
//                var series = {
//                    data: []
//                };
//                $.each(items, function (itemNo, item) {
//                    if (itemNo == 0) {
//                        series.name = item;
//                    } else {
//                        series.data.push(parseFloat(item));
//                    }
//                });

//                options.series.push(series);

//            }

//        });
//        //putting all together and create the chart
//        var chart = new Highcharts.Chart(options);
//    });

//});
