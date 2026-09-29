$(function() {
	"use strict";

   
// chart 1
var options = {
    series: [{
        name: "Messages",
        data: [25, 66, 41, 59, 25, 44, 12, 36, 9, 21]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "area",
        //width: 130,
        height: 50,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#3461ff"
        },
        sparkline: {
            enabled: !0
        }
    },
    markers: {
        size: 0,
        colors: ["#3461ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "35%",
            endingShape: "rounded"
        }
    },
    dataLabels: {
        enabled: !1
    },
    stroke: {
        show: !0,
        width: 2.5,
        curve: "smooth"
    },
    colors: ["#3461ff"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart1"), options);
  chart.render();



  
// chart 2
var options = {
    series: [{
        name: "Members",
        data: [25, 35, 20, 47, 32, 44, 14, 55, 41, 69]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "bar",
       // width: 130,
        height: 50,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#12bf24"
        },
        sparkline: {
            enabled: !0
        }
    },
    markers: {
        size: 0,
        colors: ["#12bf24"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "35%",
            endingShape: "rounded"
        }
    },
    dataLabels: {
        enabled: !1
    },
    stroke: {
        show: !0,
        width: 2.5,
        curve: "smooth"
    },
    colors: ["#12bf24"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart2"), options);
  chart.render();



// chart 3
var options = {
    series: [{
        name: "New Tasks",
        data: [20, 15, 74, 32, 56, 31, 44, 33, 45, 19]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "area",
       // width: 130,
        height: 50,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#8932ff"
        },
        sparkline: {
            enabled: !0
        }
    },
    markers: {
        size: 0,
        colors: ["#8932ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "35%",
            endingShape: "rounded"
        }
    },
    dataLabels: {
        enabled: !1
    },
    stroke: {
        show: !0,
        width: 2.5,
        curve: "smooth"
    },
    colors: ["#8932ff"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart3"), options);
  chart.render();




// chart 4
var options = {
    series: [{
        name: "New Tasks",
        data: [15, 75, 47, 65, 14, 32, 19, 54, 44, 61]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "bar",
       // width: 130,
        height: 50,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#ff6632"
        },
        sparkline: {
            enabled: !0
        }
    },
    markers: {
        size: 0,
        colors: ["#ff6632"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "35%",
            endingShape: "rounded"
        }
    },
    dataLabels: {
        enabled: !1
    },
    stroke: {
        show: !0,
        width: 2.5,
        curve: "smooth"
    },
    colors: ["#ff6632"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart4"), options);
  chart.render();



  // chart 5
  var options = {
    chart: {
        foreColor: '#9a9797',
        type: 'bar',
        height: 360,
        stacked: false,
        toolbar: {
            show: false
        },
    },
    series: [{
        name: 'New Visitors',
        data: [25, 23, 27, 35, 27, 23, 31, 41, 31, 25, 35, 22]
    },{
        name: 'Old Visitors',
        data: [15, 13, 17, 20, 17, 13, 21, 30, 20, 15, 25, 17]
    },{
        name: 'Clicks',
        data: [10, 8, 12, 15, 12, 8, 16, 25, 15, 10, 20, 12]
    }],
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    legend: {
        show: false,
        position: 'top',
        horizontalAlign: 'left',
        offsetX: -20
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 5,
        colors: ['transparent']
    },
    colors: ["#3461ff", "#12bf24", "#ff6632"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
    },
    grid: {
        show: true,
        borderColor: '#ededed',
        strokeDashArray: 4,
    },
    responsive: [{
        breakpoint: 480,
        options: {
            chart: {
                height: 310,
            },
            plotOptions: {
                bar: {
                    columnWidth: '30%'
                }
            }
        }
    }]
};
var chart = new ApexCharts(document.querySelector("#chart5"), options);
chart.render();


   

   
// chart 6
var options = {
    series: [{
        name: "Messages",
        data: [450, 650, 440, 360, 671, 414, 555, 901, 555]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "bar",
        //width: 130,
        height: 280,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#8932ff"
        },
        sparkline: {
            enabled: 0
        }
    },
    markers: {
        size: 0,
        colors: ["#8932ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    grid: {
        show: true,
        borderColor: '#ededed',
        strokeDashArray: 4,
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "25%",
            distributed: true,
            endingShape: "rounded"
        }
    },
    dataLabels: {
        enabled: !1
    },
    legend: {
        show: false
      },
    stroke: {
        show: !0,
        width: 0,
        curve: "smooth"
    },
    colors: ["#8932ff"],
    xaxis: {
        categories: ["0-10", "10-20", "20-30", "30-40", "40-50", "50-60", "60-70", "70-80", "80-95"]
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart6"), options);
  chart.render();


   
// chart 7
var options = {
    series: [{
        name: "Messages",
        data: [450, 650, 440, 160, 671, 414, 555, 901, 555]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "line",
        //width: 130,
        height: 280,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 1,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#3461ff"
        },
        sparkline: {
            enabled: 0
        }
    },
    markers: {
        size: 0,
        colors: ["#3461ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "55%",
            distributed: true,
            //endingShape: "rounded"
        }
    },
    grid: {
        show: true,
        borderColor: '#ededed',
        strokeDashArray: 4,
    },
    dataLabels: {
        enabled: !1
    },
    legend: {
        show: false
      },
    stroke: {
        show: !0,
        width: 4,
        curve: "smooth"
    },
    colors: ["#3461ff"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep"]
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart7"), options);
  chart.render();



// chart 8
var options = {
    series: [{
        name: "New Tasks",
        data: [171, 514, 455, 857, 300, 450, 684]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "area",
       // width: 130,
        height: 370,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#32bfff"
        },
        sparkline: {
            enabled: !1
        }
    },
    markers: {
        size: 0,
        colors: ["#32bfff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    grid: {
        show: true,
        borderColor: '#ededed',
        strokeDashArray: 4,
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "35%",
            endingShape: "rounded"
        }
    },
    dataLabels: {
        enabled: !1
    },
    stroke: {
        show: !0,
        width: 2.5,
        curve: "smooth"
    },
    colors: ["#32bfff"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul"]
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: "dark",
        fixed: {
            enabled: !1
        },
        x: {
            show: !1
        },
        y: {
            title: {
                formatter: function(e) {
                    return ""
                }
            }
        },
        marker: {
            show: !1
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart8"), options);
  chart.render();




// chart 9
  
var options = {
    series: [160, 60, 35],
    chart: {
     height: 270,
     type: 'pie',
  },
  labels: [ 'Mobile', 'Desktop', 'Tablet'],
  colors: ["#3461ff", "#ff6632", "#0c971a"],
  legend: {
    show: false,
    position: 'top',
    horizontalAlign: 'left',
    offsetX: -20
  },
  responsive: [{
    breakpoint: 480,
    options: {
      chart: {
        height: 270
      },
      legend: {
        position: 'bottom'
      }
    }
  }]
  };

  var chart = new ApexCharts(document.querySelector("#chart9"), options);
  chart.render();







});