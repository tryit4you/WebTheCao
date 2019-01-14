var config = {
    pageSize: 20,
    pageIndex: 1
};
var giaodichScript = {
    Init: function () {
        giaodichScript.loadData();
        giaodichScript.registerEvent();
    },
    registerEvent: function () {
        $('.btn-search').off('click').on('click', function () {
            giaodichScript.loadData(true);
        });
        $('#txtSearch').keypress(function (event) {
            if (event.keyCode === 13) {
                giaodichScript.loadData(true);
            }
        });
        $('#txtSearch').on('click', function () {
            $('#txtSearch').val('');
        });

    },
    loadData: function (changePageSize) {
        var userId = $('#txtId').val();
        $.ajax({
            url: '/useraccount/lichsugiaodich',
            type: 'POST',
            data: {
                userId: userId,
                page: config.pageIndex,
                pageSize: config.pageSize
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;

                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            Time: item.createdDate,
                            SoTien: item.soTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }),
                            Content: item.content ? "Nộp tiền vào tài khoản" : "Trừ tiền tài khoản",
                            Notes: item.notes
                        });
                    });
                    $('#dataRender').html(html);
                    if (response.total > config.pageSize) {
                        giaodichScript.paging(response.total, response.page, function () {
                            giaodichScript.loadData();
                        }, changePageSize);

                    } else {
                        $('#pagination').hide();
                    }
                }
            }
        });
    },
    paging: function (totalRow, page, callback) {
      
        $('#pagination').pagination({
            items: totalRow,
            itemsOnPage: config.pageSize,
            currentPage: page,
            hrefTextPrefix: '#trang-',
            prevText: "&lt",
            nextText: "&gt;",
            cssStyle: 'light-theme',
            onPageClick: function (page, event) {
                config.pageIndex = page;
                currentPage = page;
                setTimeout(callback, 0);
            }
        });
    }
};
giaodichScript.Init();