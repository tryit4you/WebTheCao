"use strict";
var config = {
    pageSize: 20,
    pageIndex: 1
};
var slideController = {
    init: function () {
        slideController.loadData();
        slideController.registerEvent();
    },
    registerEvent: function () {
        $('#frmAddNew').validate({
            rules: {
                Name: "required",
                Image: "required",
                Content: "required",
                Captant: "required",
                Author: "required"
            },
            messages: {
                Name: "Tên là bắt buộc",
                Image: "Yêu cầu phải có hình ảnh",
                Content: "Yêu cầu nội dung",
                Captant: "Yêu cầu tiêu đề",
                Author: "Yêu cầu tác giả"
            }
        });
        $('#frmUpdate').validate({
            rules: {
                EditName: "required",
                EditImage: "required",
                EditContent: "required",
                Captant: "required",
                EditAuthor: "required"
            },
            messages: {
                EditName: "Tên là bắt buộc",
                EditImage: "Yêu cầu phải có hình ảnh",
                EditContent: "Yêu cầu nội dung",
                Captant: "Yêu cầu tiêu đề",
                EditAuthor: "Yêu cầu tác giả"
            }
        });
        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                var name = $('#txtName').val();
                slideController.checkExist(name);
            }
        }); $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                slideController.Put();
            }
        });

        $('.btn-edit').off('click').on('click', function () {
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            slideController.loadDetail(id);
        });

        $('#txtDisplayOrder').on('change', function () {
            var id = $(this).data('id');
            var order = $(this).val();
            if (parseInt(order) < 0) {
                toastr.warning("Gía trị không được nhỏ hơn 0");
                $(this).val('0');
            }
        });

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    slideController.delete(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    slideController.deleteMul();
            });
        });
        $('#txtSearch').change(function () {
            slideController.loadData(true);
        });
        $('#btn-Search').off('click').on('click', function () {
            slideController.loadData(true);
        });
        $('#btn-refresh').off('click').on('click', function () {
            $('#txtSearch').val('');
            slideController.loadData(true);
        });
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(this);
            $.ajax({
                url: '/admin/slide/ChangeStatus',
                data: { id: id },
                type: 'post',
                dataType: 'json',
                success: function (res) {
                    if (res.message === null) {
                        toastr.error(res.message);
                    } else {
                        if (res.status) {
                            target.removeClass('label-danger');
                            target.addClass('label-success');
                            toastr.remove();
                            toastr.info("Đã kích hoạt");
                            target.html("<i class='fa fa-check'></i>");
                        } else {
                            target.removeClass('label-success');
                            target.addClass('label-danger');
                            toastr.remove();
                            toastr.info("Đã hủy kích hoạt");
                            target.html("<i class='fa fa-ban'></i>");
                        }
                    }
                }
            });
        });
       
    },
    updateOrder: function (id, order) {
        $.ajax({
            url: '/admin/Slide/UpdateOrder',
            data: {
                id: id,
                DisplayOrder: order
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.result) {
                    toastr.success(res.message);
                } else {
                    toastr.error(res.message);
                }
            }
        });
    },
 
    delete: function (id) {
        $.ajax({
            url: '/admin/Slide/Delete',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success(res.message);
                slideController.loadData(true);
            }
        });
    },
    deleteMul: function () {
        var listSelected = [];

        $("td input:checked").each(function () {
            listSelected.push($(this).data('id'));
        });
        if (listSelected.length === 0) {
            toastr.warning("Không có phần tử nào được chọn!");
        } else {
            $.ajax({
                url: '/admin/Slide/DeleteMul',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    toastr.success(response.message);
                    slideController.loadData(true);
                }
            });
        }
    },

    checkExist: function (name) {
        var result = false;
        $.ajax({
            url: '/admin/Slide/CheckExist',
            data: {
                name: name
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.result === true) {
                    slideController.Post();
                } else {
                    $('.validate').html('Tên ' + name + ' đã tồn tại!');
                }
            }
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/admin/slide/GetDetail',
            data: {
                id: id
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    var item = res.data;
                    $('#EditId').val(item.id);
                    $('#EditName').val(item.name);
                    $('#EditImage').attr('src', item.image);
                    tinymce.get('EditContent').setContent(item.content);
                    $('#EditDisplayOrder').val(item.displayOrder);
                    $('#EditCaptant').val(item.captant);
                    $('#EditCaptantPos').val(item.captantPostion);
                    $('#EditStatus').prop('checked', item.status);
                }
                else {
                    toastr.error("Lỗi!");
                    slideController.loadData(true);
                }
            }
        });
    },
    Post: function () {
        var Name = $('#txtName').val();
        var Image = $('#txtImage').attr('src');
        var Captant = $('#txtCaptant').val();
        var Content = tinymce.get('txtContent').getContent();
        var DisplayOrder = $("#txtDisplayOrder").val();
        var CaptantPosition = $("#txtCaptantPos").val();
        var Status = $('#txtStatus').prop('checked');
        var e = {
            Name: Name,
            Captant: Captant,
            Image: Image,
            Content: Content,
            CaptantPostion: CaptantPosition,
            DisplayOrder: DisplayOrder,
            Status: Status
        };
        $.ajax({
            url: '/admin/Slide/Post',
            data: {
                slide: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    slideController.loadData();
                    toastr.success(response.message);
                    slideController.loadData(true);
                } else {
                    toastr.error(response.message);
                }
            }
        });
    },
    Put: function () {
        var id = $("#EditId").val();
        var Name = $('#EditName').val();
        var Image = $('#EditImage').attr('src');
        var Captant = $('#EditCaptant').val();
        var CaptantPostion = $('#EditCaptantPos').val();
        var Content = tinymce.get('EditContent').getContent();
        var DisplayOrder = $("#EditDisplayOrder").val();
        var Status = $('#EditStatus').prop('checked');
        var e = {
            Id: id,
            Name: Name,
            Image: Image,
            Content: Content,
            DisplayOrder: DisplayOrder,
            Captant: Captant,
            CaptantPostion: CaptantPostion,
            Status: Status
        };
        $.ajax({
            url: '/admin/Slide/Put',
            data: {
                slide: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    toastr.success(response.message);
                    slideController.loadData(true);
                } else {
                    toastr.error(response.message);
                }
            }
        });
    },
    loadData: function (changePageSize) {
        var search = $('#txtSearch').val();
        $.ajax({
            url: '/admin/Slide/GetAll',
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
                            ID: item.id,
                            Name: item.name,
                            Image: item.image,
                            Content: item.content,
                            DisplayOrder: item.displayOrder,
                            CaptantPosition: item.captantPostion,
                            Captant: item.captant,
                            Status: item.status ? " <a href='#' class='btn-active label-success' data-id='" + item.id + "'><i class='fa fa-check'></i><\/a>" : "<a href='#' class='btn-active label-danger' data-id='" + item.id + "'><i class='fa fa-ban'></i><\/a>"
                        });
                    });
                    $('#tbData').html(html);
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    slideController.paging(response.total, function () {
                        slideController.loadData();
                        $('#currentpage').html(config.pageIndex);
                        $('#totalpage').html(totalPage);
                        $('#row_item').html(response.total);
                    }, changePageSize);
                    slideController.registerEvent();
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
slideController.init();