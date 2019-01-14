var config = {
    pageSize: 20,
    pageIndex: 1
};
var emailRegisterController = {
    init: function () {
        emailRegisterController.loadData();
        emailRegisterController.registerEvent();
    },
    registerEvent: function () {
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    emailRegisterController.deleteMul();
            });
        });
        $('#btn-SendMail').off('click').on('click', function () {
            var listSelected = [];
            $("td input:checked").each(function () {
                listSelected.push($(this).data('id'));
            });
            if (listSelected.length === 0) {
                toastr.error("bạn vui lòng chọn ít nhất một email!");
            } else {
                $.ajax({
                    url: '/admin/Feedback/sendemails',
                    data: {
                        ids: listSelected
                    },
                    type: 'get',
                    dataType: 'json',
                    success: function (res) {
                        console.log(res.message);
                    }
                });
            }
        });

        $('#selectAll').change(function () {
            $('.selectedItem').prop('checked', $(this).prop('checked'));
        });
    },
    deleteMul: function () {
        var listSelected = [];

        $("td input:checked").each(function () {
            listSelected.push($(this).data('id'));
        });
        if (listSelected.length === 0) {
            toastr.error("Không có phần tử nào được chọn!");
        } else {
            $.ajax({
                url: '/admin/Feedback/DeleteEmail',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    toastr.success(response.message);
                    emailRegisterController.loadData(true);
                }
            });
        }
    },

    loadData: function (changePageSize) {
        $.ajax({
            url: '/admin/Feedback/GetEmailRegister',
            type: 'post',
            data: {
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
                            ID: item.id,
                            Email: item.email
                        });
                    });
                    $('#tbData').html(html);
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    emailRegisterController.paging(response.total, function () {
                        emailRegisterController.loadData();
                        $('#currentpage').html(config.pageIndex);
                        $('#totalpage').html(totalPage);
                    }, changePageSize);
                    emailRegisterController.registerEvent();
                }
            }
        });
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / config.pageSize);
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp ',
            last: 'Cuối',
            visiblePages: 10,
            onPageClick: function (event, page) {
                config.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
};
emailRegisterController.init();