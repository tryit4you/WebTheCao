var config = {
    pageSize: 20,
    pageIndex: 1
};
var userAccountScripts = {

    Init: function () {
        userAccountScripts.registerEvent();
        userAccountScripts.loadData(true);
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
                },
                Password: {
                    required: true,
                    minlength: 8
                },
                ConfirmPassword: {
                    equalTo: "#editPassword"
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
                }, Password: {
                    required: "Yêu cầu nhập mật khẩu",
                    minlength: "Mật khẩu ít nhất 8 ký tự"
                },
                ConfirmPassword: {
                    equalTo: "Mật khẩu xác thực không trùng khớp"
                }
            }
        });
        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                userAccountScripts.Post();
            }
        });
        $('.btnEdit').off('click').on('click', function () {
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            userAccountScripts.loadDetail(id);
        });
        $('.btn-band').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(".row_item_" + id);
            $.ajax({
                url: '/admin/account/ChangeStatus',
                data: { id: id },
                type: 'post',
                dataType: 'json',
                success: function (res) {
                    if (res.status) {
                        target.addClass('band');

                    } else {
                        target.removeClass('band');

                    }
                    userAccountScripts.loadData(true);
                }
            });
        });
        $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                userAccountScripts.Put();
            }
        });
        $('#btn-Feedback').on('click', function () {
            if ($('#frmFeedback').valid()) {
                userAccountScripts.sendFeedback();
            }
        });
        $('.btnActive').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            bootbox.confirm("Kích hoạt email cho tài khoản này?", function (result) {
                if (result) {
                    userAccountScripts.ActiveEmail(id);
                }
            });
           
        });
        $('.btnDelete').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa tài khoản này không?", function (result) {
                if (result) {
                    userAccountScripts.delete(id);
                }
            });
           
        });
        $('.btnSave').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                userAccountScripts.SaveChange();
            }
        });
    },
    delete: function (id) {
        $.ajax({
            url: '/admin/account/delete',
            data: {
                id: id
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status === true) {
                    toastr.success(response.message);
                    userAccountScripts.loadData(true);
                } else {
                    $.each(response.errors, function (i, item) {
                        toastr.error(item);
                    });
                }
            }
        });
    },
    ActiveEmail: function (id) {
        $.ajax({
            url: '/admin/account/ActiveEmail',
            data: {
                id: id
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status === true) {
                    toastr.success(response.message);
                    userAccountScripts.loadData();
                } else {
                    toastr.error(response.message);    
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
                    var item = res.data;
                    $('#EditId').val(item.id);
                    $('#editName').val(item.displayName);
                    $('#editUserName').val(item.userName);
                    $('#editPhone').val(item.sdt);
                    $('#editEmail').val(item.email);
                }
                else {
                    toastr.error(res.message);
                    userAccountScripts.loadData(true);
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
                    userAccountScripts.loadData(true);
                    toastr.success(response.message);
                } else {
                    $.each(response.data, function (i, item) {
                        toastr.error(item);
                    });
                }
            }
        });


    },
    Put: function () {
        var Id = $('#EditId').val();
        var displayName = $('#editName').val();
        var userName = $('#editUserName').val();
        var phoneNumber = $('#editPhone').val();
        var email = $('#editEmail').val();
        var password = $('#editPassword').val();
        var data = {
            Id: Id,
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
                    userAccountScripts.loadData();
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
            url: '/admin/account/getdata',
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
                        if (item.status === false) {
                            $('.row_item_' + item.id).addClass('band');
                        }
                        html += Mustache.render(template, {
                            Id:item.id,
                            DisplayName: item.displayName,
                            UserName: item.userName,
                            Email: item.emailConfirmed ? "<a class='col-green ' href='#' data-id='" + item.id + "'> " + item.email + "</a>" : "<a class='col-pink btnActive' href='#' data-id='" + item.id + "'>" + item.email + "</a>",
                            Point: item.points.toLocaleString('vi', { style: 'currency', currency: 'VND' }),
                            PhoneNumber: item.sdt,
                            Status: item.status ? "<a class='col-green btn-band' href='#' data-id='" + item.id + "'> <i class='fa fa-check'></i></a>" : "<a class='col-pink btn-band' href='#' data-id='" + item.id + "'><i class='fa fa-ban'></i></a>"

                        });
                    });
                    $('#tbData').html(html);
                    userAccountScripts.registerEvent();
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    if (response.total <= config.pageSize) {
                        $('.paging-area').hide();
                    } else {
                        userAccountScripts.paging(response.total, function () {
                            userAccountScripts.loadData();
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
userAccountScripts.Init();
