var config = {
    pageSize: 10,
    pageIndex: 1
};
var giaodichScript = {
    Init: function () {
        giaodichScript.loadData();
        giaodichScript.loadlichsu();
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

        $('.btn-cancel').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            giaodichScript.deleteRequest(id);
        });

    },
deleteRequest: function (id) {
    $.ajax({
        url: '/useraccount/delete',
        data: { id: id },
        type: 'post',
        dataType: 'json',
        success: function (res) {
            if (res.status) {
                M.toast({ html: 'Xóa thành công', classes: 'rounded  green lighten-1' });
                giaodichScript.loadlichsu();
                $('ul.nav.nav-tabs a:eq(1)').tab('show');
            } else {

                M.toast({ html: 'Xóa không thành công', classes: 'rounded  oranger lighten-1' });
            }
        }
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
                        Content: item.content ? "Nạp tiền vào tài khoản" : "Trừ tiền tài khoản",
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
loadlichsu: function (changePageSize) {
    var userId = $('#txtId').val();
    $.ajax({
        url: '/useraccount/lichsunapthe',
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
                var template = $('#history-template').html();
                $.each(data, function (i, item) {
                    html += Mustache.render(template, {
                        Id:item.id,
                        Time: item.ngayNopThe,
                        CardName: item.loaiThe,
                        Price: item.menhGia.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }),
                        UnitPrice: item.giaChietKhau.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }),
                        Wanranty: item.soLuong,
                        Required: item.requiredLabel,
                        TrangThai: item.trangThai === true ? "Đã nạp" : "Đang chờ",
                        Notes: item.notes
                    });
                });
                $('#lichsuRender').html(html);
                giaodichScript.registerEvent();
                if (response.total > config.pageSize) {
                    giaodichScript.paginghistory(response.total, response.page, function () {
                        giaodichScript.loadlichsu();
                    }, changePageSize);

                } else {
                    $('#hispagination').hide();
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
},
paginghistory: function (totalRow, page, callback) {

    $('#hispagination').pagination({
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