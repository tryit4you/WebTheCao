"use strict";
var config = {
    pageSize: 20,
    pageIndex: 1
};
var contactController = {
    init: function () {
        contactController.loadData();
        contactController.registerEvent();
    },
    registerEvent: function () {
        $('#frmAddNew').validate({
            rules: {
                Name: "required",
                Phone: "required",
                Email: "required",
                Address: "required",
                Facebook: "required",
                FacebookLink:"required"
            },
            messages: {
                Name: "Yêu cầu nhập tên liên hệ",
                Phone: "Yêu cầu nhập số điện thoại",
                Email: "Yêu cầu nhập Email",
                Address: "Yêu cầu nhập địa chỉ",
                Facebook: "Yêu cầu nhập tên fb",
                FacebookLink: "Yêu cầu đường dẫn đến trang cá nhân"
            }
        });
        $('#frmUpdate').validate({
            rules: {
                Name: "required",
                Phone: "required",
                Email: "required",
                Address: "required",
                Facebook: "required",
                FacebookLink: "required"
            },
            messages: {
                Name: "Yêu cầu nhập tên liên hệ",
                Phone: "Yêu cầu nhập số điện thoại",
                Email: "Yêu cầu nhập Email",
                Address: "Yêu cầu nhập địa chỉ",
                Facebook: "Yêu cầu nhập tên fb",
                FacebookLink: "Yêu cầu đường dẫn đến trang cá nhân"
            }
        });

        $('#SaveEdit').off('click').on('click', function () {
            var id = $('#txtId').val();
            if ($('#frmUpdate').valid()) {
                contactController.Put();
            }
        });

        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                contactController.Post();
            }
        });

        $('.btn-edit').off('click').on('click', function () {
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            contactController.resetForm();
            contactController.loadDetail(id);
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    contactController.delete(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    contactController.deleteMul();
            });
        });
        $('#txtSearch').change(function () {
            contactController.loadData(true);
        });
        $('#btn-Search').off('click').on('click', function () {
            contactController.loadData(true);
        });
        $('#btn-refresh').off('click').on('click', function () {
            $('#txtSearch').val('');
            contactController.loadData(true);
        });
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(this);
            $.ajax({
                url: '/admin/contact/ChangeStatus',
                data: { id: id },
                type: 'post',
                dataType: 'json',
                success: function (res) {
                    if (res.status) {
                        target.removeClass('bg-red');
                        target.addClass('bg-green');
                        toastr.remove();
                        toastr.info("Đã kích hoạt");
                        target.html("<i class='fa fa-check'>Active</i>");
                    } else {
                        target.removeClass('bg-green');
                        target.addClass('bg-red');
                        toastr.remove();
                        toastr.info("Đã hủy kích hoạt");
                        target.html("<i class='fa fa-ban'>NotActive</i>");
                    }
                }
            });
        });
        $('#selectAll').change(function () {
            $('.selectedItem').prop('checked', $(this).prop('checked'));
        });
    },
    resetForm: function () {
        $('.validate').html('');
        $('#txtId').val('');
        $('#txtPhone').val('');
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtWebsite').val('');

        $('#txtAddress').val('');
        $('#ckStatus').prop('checked', 'true');
    },
    delete: function (id) {
        $.ajax({
            url: '/admin/Contact/Delete',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success(res.message);
                contactController.loadData(true);
            }
        });
    },
    deleteMul: function () {
        var listSelected = [];

        $("td input:checked").each(function () {
            listSelected.push($(this).data('id'));
        });
        if (listSelected.length === 0) {
            toastr.info("Không có phần tử nào được chọn!");
        } else {
            $.ajax({
                url: '/admin/contact/DeleteMul',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    toastr.success(response.message);
                    contactController.loadData(true);
                }
            });
        }
    },
  
    loadDetail: function (id) {
        $.ajax({
            url: '/admin/Contact/GetDetail',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    var item = res.data;
                    $('#EditId').val(item.id);
                    $('#EditName').val(item.name);
                    $('#EditPhone').val(item.phoneNumber);
                    $('#editFacebookName').val(item.facebook);
                    $('#editFacebookLink').val(item.facebookLink);
                    $('#editZaloName').val(item.zalo);
                    $('#EditEmail').val(item.email);
                    $('#EditAddress').val(item.address);
                    $('#EditStatus').prop('checked', item.status);
                }
                else {
                    toastr.error("Lỗi!");
                    contactController.loadData(true);
                }
            }
        });
    },
    Post: function () {
        var Phone = $('#txtPhone').val();
        var Email = $("#txtEmail").val();
        var Facebook = $("#txtFacebookName").val();
        var FacebookLink = $("#txtFacebookLink").val();
        var Zalo = $("#txtZaloName").val();
        var Address = $("#txtAddress").val();
        var Status = $('#txtStatus').prop('checked');
        var e = {
            PhoneNumber: Phone,
            Email: Email,
            Facebook: Facebook,
            FacebookLink: FacebookLink,
            Zalo: Zalo,
            Address: Address,
            Status: Status
        };
        $.ajax({
            url: '/admin/Contact/Post',
            data: {
                contact: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    toastr.success(response.message);
                    contactController.loadData(true);
                    location.reload();
                } else {
                    toastr.error(response.message);
                }
            }
        });
    },
    Put: function () {
        var id = $("#EditId").val();
        var Phone = $('#EditPhone').val();
        var Email = $("#EditEmail").val();
        var Facebook = $("#editFacebookName").val();
        var FacebookLink = $("#editFacebookLink").val();
        var Zalo = $("#editZaloName").val();
        var Address = $("#EditAddress").val();
        var Status = $('#EditStatus').prop('checked');
        var e = {
            ID: id,
            PhoneNumber: Phone,
            Email: Email,
            Facebook: Facebook,
            FacebookLink: FacebookLink,
            Zalo: Zalo,
            Address: Address,
            Status: Status
        };
        $.ajax({
            url: '/admin/Contact/Put',
            data: {
                contact: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    location.reload();
                    toastr.success(response.message);
                    contactController.loadData(true);
                } else {
                    toastr.error(response.message);
                }
            }
        });
    },

    loadData: function (changePageSize) {
        var search = $('#txtSearch').val();
        $.ajax({
            url: '/admin/Contact/GetAll',
            type: 'POST',
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
                            ID: item.id,
                            Phone: item.phoneNumber,
                            Email: item.email,
                            Facebook: item.facebook,
                            FacebookLink: item.facebookLink,
                            Zalo: item.zalo,
                            Address: item.address,
                            Status: item.status ? "<a href='#' class='btn-active badge bg-green' data-id='" + item.id + "'><i class='fa fa-check'>Active</i><\/a>" : "<a href='#' class='btn-active badge bg-red' data-id='" + item.id + "'>< i class='fa fa-ban'>NotActive</i><\/a>"
                        });
                    });
                    $('#tbData').html(html);
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    contactController.paging(response.total, function () {
                        contactController.loadData();
                        $('#currentpage').html(config.pageIndex);
                        $('#totalpage').html(totalPage);
                    }, changePageSize);
                    contactController.registerEvent();
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
contactController.init();