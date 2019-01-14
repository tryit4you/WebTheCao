"use strict"
var pageController = {
    init: function () {
        pageController.loadData();
        pageController.registerEvent();
    },
    registerEvent: function () {
        $('#frmAddNew').validate({
            rules: {
                Name: "required",
                Content: "required"
            },
            messages: {
                Name: "Yêu cầu nhập tên liên hệ",
                Content: "Yêu cầu mã html"
            }
        });
        $('#frmUpdate').validate({
            rules: {
                Name: "required",
                EditContent: "required"
            },
            messages: {
                Name: "Yêu cầu nhập tên liên hệ",
                EditContent: "Yêu cầu mã html"
            }
        });

        $('#SaveEdit').off('click').on('click', function () {
            var id = $('#EditId').val();
            if ($('#frmUpdate').valid()) {
                pageController.Put(id);
            }
        });

        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                var name = $('#txtName').val();
                pageController.checkExist(name);
            }
        });
        $('.btn-view').off('click').on('click', function () {
            var id = $(this).data('id');
            pageController.getDetail(id);
        });

        $('.btn-edit').off('click').on('click', function () {
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            pageController.loadDetail(id);
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    pageController.delete(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    pageController.deleteMul();
            });
        });
        $('#txtSearch').change(function () {
            pageController.loadData(true);
        });
        $('#btn-Search').off('click').on('click', function () {
            pageController.loadData(true);
        });
        $('#btn-refresh').off('click').on('click', function () {
            $('#txtSearch').val('');
            pageController.loadData(true);
        });
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(this);
            $.ajax({
                url: '/admin/page/ChangeStatus',
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
    delete: function (id) {
        $.ajax({
            url: '/admin/page/Delete',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success(res.message);
                pageController.loadData(true);
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
                url: '/admin/page/DeleteMul',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    toastr.success(response.message);
                    pageController.loadData(true);
                }
            });
        }
    },
    checkExist: function (name) {
        var result = false;
        $.ajax({
            url: '/admin/page/CheckExist',
            data: {
                name: name
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.result === true) {
                    pageController.Post();
                } else {
                    $('.validate').html('Tên ' + name + ' đã tồn tại!');
                }
            }
        });
    },
    Post: function () {
        var Name = $('#txtName').val();
        var Content = $('#pageContent').val();
        var Status = $('#txtStatus').prop('checked');
        var e = {
            Name: Name,
            Content: Content,
            Status: Status
        };
        $.ajax({
            url: '/admin/Page/Post',
            data: {
                page: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    location.reload();
                    toastr.success(response.message);
                    pageController.loadData(true);
                } else {
                    toastr.error(response.message);
                }
            }
        });
    },
    Put: function () {
        var id = $("#EditId").val();
        var Name = $('#EditName').val();
        var Content = $('#EditpageContent').val();
        var Status = $('#EditStatus').prop('checked');
        var e = {
            ID: id,
            Name: Name,
            Content: Content,
            Status: Status
        };
        $.ajax({
            url: '/admin/page/Put',
            data: {
                page: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    location.reload();
                    toastr.success(response.message);
                    pageController.loadData(true);
                } else {
                    toastr.error(response.message);
                }
            }
        });
    },

    loadDetail: function (id) {
        $.ajax({
            url: '/admin/Page/GetDetail',
            data: {
                id: id
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('#EditId').val(data.id);
                    $('#EditName').val(data.name);
                    $('#EditpageContent').val(data.content);
                    $('#EditStatus').prop('checked', data.status);
                }
            }
        });
    },
    getDetail: function (id) {
        $.ajax({
            url: '/admin/Page/GetDetail',
            data: {
                id: id
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('.btnBrowser').attr('data-id', data.id);
                    $('#modal-title').html(data.name);
                    $('#content').html(data.content);
                    $('#pageViewModel').modal('show');
                }
            }
        });
    }
    ,
    loadData: function () {
        $.ajax({
            url: '/admin/Page/GetAll',
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.id,
                            Name: item.name,
                            Content: item.content,

                            Status: item.status ? "<a href='#' style='margin-top: 0%' class='btn-active badge bg-green' data-id='" + item.id + "'><i class='fa fa-check'></i>Active<\/a>" : "<a href='#' style='margin-top: 0%' class='btn-active badge bg-red' data-id='" + item.id + "'>< i class='fa fa-ban'></i>NotActive<\/a>"
                        });
                    });
                    $('#tbData').html(html);
                    pageController.registerEvent();
                }
            }
        });
    }
};
pageController.init();