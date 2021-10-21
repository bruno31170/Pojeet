"use strict";
//--------------
//- marge brut -
//--------------
Chart.defaults.global.defaultFontSize = 13;
// Get context with jQuery - using jQuery's .get() method.
var areaChartCanvas = document.getElementById("areaChart");
Chart.defaults.global.defaultFontSize = 13;


var dataFirst = {
  label: "Marge brut 2021 (€)",
  borderColor: '#2e73a6',
  //backgroundColor: 'rgba(60, 141, 187, 0.6)',
  //lineTension: 0,
  fill: false,
  data: [28, 48, 40, 59, 86, 51, 90, 80, 46, 5, 0, 0]
};

var dataSecond = {
  label: 'Marge brut 2020 (€)',
  //backgroundColor: 'rgba(210, 214, 222, 0.6)',
  borderColor: 'rgba(215, 107, 117, 0.6)',
  // lineTension: 0,
  fill: false,
  data: [65, 59, 80, 81, 56, 55, 40, 56, 35, 60, 40, 55]
};


var areaChartData = {
  labels: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
  datasets: [dataFirst, dataSecond]
};

var areaChartOptions = {
  maintainAspectRatio: false,
  responsive: true,
  legend: {
    display: true,
    position: 'top',
    labels: {
      boxWidth: 20
    }
  },
  scales: {
    xAxes: [{
      gridLines: {
        display: true,
      }
    }],
    yAxes: [{
      gridLines: {
        display: true,
      }
    }]
  }
};


// This will get the first returned node in the jQuery collection.
new Chart(areaChartCanvas, {
  type: 'line',
  data: areaChartData,
  options: areaChartOptions
});

//--------------
//- End marge brut -
//--------------


//-------------
//- Nouveaux clients -
//--------------
var lineChartCanvas = document.getElementById("lineChart");

var lineChartData = {
  labels: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
  datasets: [{
    label: "Nouveaux clients",
    data: [62, 59, 75, 20, 20, 55, 40, 60, 39, 35, 58, 40],
    lineTension: 0,
    fill: false,
    borderColor: 'orange',
    // backgroundColor: 'transparent',
    // borderDash: [5, 5],
    // pointBorderColor: 'orange',
    // pointBackgroundColor: 'rgba(255,150,0,0.5)',
    // pointRadius: 5,
    // pointHoverRadius: 10,
    // pointHitRadius: 30,
    // pointBorderWidth: 2,
    // pointStyle: 'rectRounded'
  }]
};

var lineChartOptions = {
  legend: {
    display: true,
    position: 'top',
    labels: {
      boxWidth: 20
    }
  },
  scales: {
    xAxes: [{
      gridLines: {
        display: true,
      }
    }],
    yAxes: [{
      gridLines: {
        display: true,
      },
      ticks: {
        beginAtZero: true,
      }
    }]
  }
};

var lineChart = new Chart(lineChartCanvas, {
  type: 'line',
  data: lineChartData,
  options: lineChartOptions
});

//-------------
//- End Nouveaux clients -
//--------------


//-------------
//- Donut commandes -
//-------------
// Get context with jQuery - using jQuery's .get() method.
var donutChartCanvas = $('#donutChart').get(0).getContext('2d');

var donutData = {
  labels: [
    'En attante',
    'Validée',
    'Terminée',
    'Annulée',
  ],
  datasets: [{
    data: [50, 36, 15, 39],
    backgroundColor: ['#3c8dbc', '#00a65a', '#f39c12', '#f56954'],
  }]
}
var donutOptions = {
  maintainAspectRatio: false,
  responsive: true,
}
//Create pie or douhnut chart
// You can switch between pie and douhnut using the method below.
new Chart(donutChartCanvas, {
  type: 'doughnut',
  data: donutData,
  options: donutOptions
})

//-------------
//- End Donut commandes -
//-------------

//-------------
//- Chiffre d'affaire -
//-------------
var barChartCanvas = document.getElementById("barChart");

var dataFirstCA = {
  label: 'CA 2020 (€)',
  data: [3427, 5243, 4514, 3933, 1326, 687, 1271, 2638, 1948, 2684, 3210, 3187],
  backgroundColor: 'rgba(43, 103, 119, 0.6)',
  borderWidth: 0
};

var dataSecondCA = {
  label: 'CA 2021 (€)',
  data: [3625, 4638, 2948, 5684, 4210, 2687, 3261, 4638, 2948, 2684, 4210, 3487],
  backgroundColor: 'rgba(43, 103, 119, 0.9)',
  borderWidth: 0
};

var barChartData = {
  labels: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
  datasets: [dataFirstCA, dataSecondCA]
};

var barChartOptions = {
  scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
};


new Chart(barChartCanvas, {
  type: 'bar',
  data: barChartData,
  options: barChartOptions
});

//-------------
//- End Chiffre d'affaire -
//-------------
