var config = {
    pageSize: 20,
    pageIndex: 1
};
var rolesScripts = {

    Init: function () {
        rolesScripts.registerEvent();
        rolesScripts.loadData(true);
    },
    registerEvent: function () {
        $('#frmAddNew').validate({
            rules: {
                DisplayName: {
                    required: true
                },
                UserName: {
                    required: true
                },
                PhoneNumber: {
                    required: true,
                    minlength: 10,
                    number: true
                }, Email: {
                    required: true
                },
                Password: {
                    required: true,
                    minlength:8
                },
                ConfirmPassword: {
                    required: true,
                    equalTo: '[name="Password"]'
                }

            }, messages: {
                DisplayName: {
                    required: "Yêu cầu nhập họ tên"
                },
                UserName: {
                    required: "Yêu cầu tên tài khoản"
                },
                PhoneNumber: {
                    required: "Yêu cầu số điện thoại",
                    minlength: "Số điện thoại ít nhất 10 ký tự",
                    number: "Số điện thoại không đúng"
                }, Email: {
                    required: "Yêu cầu nhập email"
                },
                Password: {
                    required: "Yêu cầu nhập mật khẩu",
                    minlength: "Mật khẩu phải chứa ít nhất 8 ký tự"
                },
                ConfirmPassword: {
                    required: "Yêu cầu nhập mật khẩu xác thực",
                    equalTo: "Mật khẩu xác thực không trùng khớp"
                }
            }
        });
        $('#frmUpdate').validate({
            rules: {
                editDisplayName: {
                    required: "Yêu cầu họ tên"
                },
                editUserName: {
                    required: "Yêu cầu tên tài khoản"
                },
                editPhoneNumber: {
                    required: "Yêu cầu số điện thoại",
                    minlength: "Số điện thoại ít nhất 10 ký tự",
                    number: "Số điện thoại không đúng"
                },
                editEmail: {
                    required: "Yêu cầu nhập email"
                }
            },
            messages: {
                editDisplayName: {
                    required: "Yêu cầu họ tên"
                },
                editUserName: {
                    required: "Yêu cầu tên tài khoản"
                },
                editPhoneNumber: {
                    required: "Yêu cầu số điện thoại",
                    minlength: "Số điện thoại ít nhất 10 ký tự",
                    number: "Số điện thoại không đúng"
                },
                editEmail: {
                    required: "Yêu cầu nhập email"
                }
            }
        });
        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                rolesScripts.Post();
            }
        });
        $('.btnEdit').off('click').on('click', function () {
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            rolesScripts.loadDetail(id);
        });
        $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                rolesScripts.Put();
            }
        });
        $('#btn-Feedback').on('click', function () {
            if ($('#frmFeedback').valid()) {
                rolesScripts.sendFeedback();
            }
        });
        $('.btnSave').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                rolesScripts.SaveChange();
            }
        });
    },
    checkExist: function (name) {
        var result = false;
        $.ajax({
            url: '/Books/CheckExist',
            data: {
                name: name
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.result === true) {
                    rolesScripts.Post();
                } else {
                    $('.validate').html('Tên ' + name + ' đã tồn tại!');
                }
            }
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/admin/account/GetDetail',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    var item = res.data.giaodich;
                    $('#EditId').val(item.id);
                    $('#editDisplayName').val(item.displayName);
                    $('#editUserName').val(item.userName);
                    $('#editPhoneNumber').val(item.phoneNumber);
                    $('#editEmail').val(item.email);
                    $('#editPassword').val(item.password);
                    $('#editConfirmPassword').val(item.password);
                }
                else {
                    toastr.error(res.message);
                    rolesScripts.loadData(true);
                }
            }
        });
    },
    Post: function () {
        var displayName = $('#txtName').val();
        var userName = $('#txtUserName').val();
        var phoneNumber = $('#txtPhone').val();
        var email = $('#txtEmail').val();
        var password = $('#txtPassword').val();
        var data = {
            DisplayName: displayName,
            UserName: userName,
            sdt: phoneNumber,
            Email: email
        };
        $.ajax({
            url: '/admin/account/create',
            data: {
                models: JSON.stringify(data),
                password: password
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    location.reload();
                    toastr.success(response.message);
                } else {
                    $.each(response.errors, function (i, item) {
                        toastr.error(item);
                    });
                }
            }
        });


    },
    Put: function () {
        var Id = $('#EditId').val();
        var displayName = $('#editDisplayName').val();
        var userName = $('#editUserName').val();
        var phoneNumber = $('#editPhoneNumber').val();
        var email = $('#editEmail').val();
        var password = $('#editPassword').val();
        var data = {
            Id: id,
            DisplayName: displayName,
            UserName: userName,
            sdt: phoneNumber,
            Email: email
        };
        $.ajax({
            url: '/admin/account/update',
            data: {
                models: JSON.stringify(data),
                password: password
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    location.reload();
                    toastr.success(response.message);
                } else {
                    $.each(response.errors, function (i, item) {
                        toastr.error(item);
                    });
                }
            }
        });


    },
    loadData: function (changePageSize) {
        var search = $('#txtSearch').val();
        $.ajax({
            url: '/admin/role/getdata',
            type: 'post',
            data: {
                filter: search,
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
                            Id:item.id,
                            DisplayName: item.displayName,
                            UserName: item.userName,
                            Email: item.email,
                            Point: item.points.toLocaleString('vi', { style: 'currency', currency: 'VND' }),
                            PhoneNumber: item.sdt,
                            TrangThai: item.trangThai ? " <a href='#' class='btn-active badge bg-green' data-id='" + item.id + "'><i class='fa fa-check' disabled>Đã nạp</i><\/a>" : "<a href='#' class='btn-active badge bg-red' data-id='" + item.id + "'><i class='fa fa-ban'>Chưa nạp</i><\/a>"
                        });
                    });
                    $('#tbData').html(html);
                    rolesScripts.registerEvent();
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    if (response.total <= config.pageSize) {
                        $('.paging-area').hide();
                    } else {
                        rolesScripts.paging(response.total, function () {
                            rolesScripts.loadData();
                            $('#currentpage').html(config.pageIndex);
                            $('#totalpage').html(totalPage);
                        }, changePageSize);
                    }
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
rolesScripts.Init();
