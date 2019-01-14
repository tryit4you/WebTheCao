var color = {
    background: [
        'rgba(255, 99, 132, 0.2)',
        'rgba(54, 162, 235, 0.2)',
        'rgba(255, 206, 86, 0.2)',
        'rgba(75, 192, 192, 0.2)',
        'rgba(153, 102, 255, 0.2)',
        'rgba(255, 159, 64, 0.2)'
    ],
    border: [
        'rgba(255,99,132,1)',
        'rgba(54, 162, 235, 1)',
        'rgba(255, 206, 86, 1)',
        'rgba(75, 192, 192, 1)',
        'rgba(153, 102, 255, 1)',
        'rgba(255, 159, 64, 1)'
    ]
};
var homechartController = {
    init: function () {
        homechartController.loadChart();
        homechartController.loadStatusChart();
        homechartController.doanhthuChart();
        homechartController.registerEvent();
    },
    registerEvent: function () {


    },
    loadChart: function () {

        var labels = [];
        var datas = [];
        $.ajax({
            url: '/admin/home/LoadChartCart',
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $.each(data, function (i, item) {
                        labels.push(item.label);
                        datas.push(item.data);
                    });


                    var ctx = document.getElementById("colChartCardCount").getContext('2d');
                    var myChart = new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'Lần nạp thẻ',
                                data: datas,
                                backgroundColor: color.background,
                                borderColor: color.border,
                                borderWidth: 1
                            }]
                        },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                }
            }
        });
    },
    loadStatusChart: function () {

        var labels = [];
        var datas = [];
        $.ajax({
            url: '/admin/home/LoadStatusChartCart',
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $.each(data, function (i, item) {
                        labels.push(item.label);
                        datas.push(item.data);
                    });


                    var ctx = document.getElementById("statusChartCardCount").getContext('2d');
                    var myChart = new Chart(ctx, {
                        type: 'pie',
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'Trạng thái nạp',
                                data: datas,
                                backgroundColor: color.background,
                                borderColor: color.border,
                                borderWidth: 1
                            }]
                        },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });
                }
            }
        });
    },
    doanhthuChart: function () {

        var labels = [];
        var datas = [];
        $.ajax({
            url: '/admin/home/DoanhThuChartCart',
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $.each(data, function (i, item) {
                        labels.push(item.labelDate);
                        datas.push(item.doanhThuNgay);
                    });
                    var ctx = document.getElementById("thunhapChartCard").getContext('2d');
                    var myChart = new Chart(ctx, {
                        type: 'line',
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'Doanh thu ngày',
                                data: datas,
                                backgroundColor: color.background,
                                borderColor: color.border,
                                borderWidth: 1
                            }]
                        },
                        options: {
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true,
                                        callback: function (value) {
                                            return value.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                                        }
                                    }
                                }]
                            }, tooltips: {
                                callbacks: {
                                    label: function (tooltipItem, chart) {
                                        var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                                        return datasetLabel  + tooltipItem.yLabel.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                                    }
                                }
                            }
                        }
                    });
                }
            }
        });
    }
};
homechartController.init();