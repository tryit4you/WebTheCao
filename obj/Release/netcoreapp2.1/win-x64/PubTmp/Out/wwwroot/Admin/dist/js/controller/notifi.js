$('.make_is_read').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: '/admin/giaodich/makeallread',
        type: 'post',
        dataType: 'json',
        success: function (res) {
            if (res.status) {
                window.open('/admin/card/history', '_self');
            }
        }
    });
});
$('.view_item').off('click').on('click', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        url: '/admin/giaodich/makeitemread',
        type: 'post',
        data: { id: id },
        dataType: 'json',
        success: function (res) {
            if (res.status) {
                window.open('/admin/card/history', '_self');
            }
        }
    });
});
$('.isreadall').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: '/admin/account/makeallread',
        type: 'post',
        dataType: 'json',
        success: function (res) {
            if (res.status) {
                window.open('/admin/account/index', '_self');
            }
        }
    });
});
$('.isread').off('click').on('click', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        url: '/admin/account/makeitemread',
        type: 'post',
        data: { id: id },
        dataType: 'json',
        success: function (res) {
            if (res.status) {
                window.open('/admin/account/index', '_self');
            }
        }
    });
});
