var config = {
    pageSize: 12,
    pageIndex: 1,
    viewport: {
        width: 189,
        height: 245
    }
};
var postController = {
    init: function () {
        postController.loadData();
        postController.registerEvent();
    },
    registerEvent: function () {
        $('.datepicker').datepicker({
            format: 'mm/dd/yyyy'
        });

        jQuery.validator.setDefaults({
            debug: true,
            success: "valid"
        });
        $('#frmAddNew').validate({
            rules: {
                Name: {
                    required: true
                },
                Image: "required"
                
            },
            messages: {
                Name: {
                    required: "Tên là bắt buộc"
                },
                Image: "Yêu cầu có ảnh đại diện"
            }
        });
        $('#frmUpdate').validate({
            rules: {
                EditName: {
                    required: true
                },
                EditImage: "required"
               
               
            },
            messages: {
                EditName: {
                    required: "Tên là bắt buộc"
                },
                EditImage: "Yêu cầu có ảnh đại diện"
             
            }
        });
       
        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                var name = $('#txtName').val();
                postController.checkExist(name);
            }
        });

        $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                postController.Put();
            }
        });
        $('.btn-showTable').off('click').on('click', function () {
            $('.show-Table').removeClass('hidden');
            $('.show-Table').show(3000);
            $('.show-Colapse').addClass('hidden');
            $('.show-Colapse').hide(2000);
        });
        $('.btn-showCollapse').off('click').on('click', function () {
            $('.show-Colapse').removeClass('hidden');
            $('.show-Colapse').show(2000);
            $('.show-Table').addClass('hidden');
            $('.show-Table').hide(3000);
        });
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(this);
            $.ajax({
                url: '/admin/post/ChangeStatus',
                data: { id: id },
                type: 'post',
                dataType: 'json',
                success: function (res) {
                    if (res.message === null) {
                        toastr.error(res.message);
                    } else {
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
                }
            });
        });
        $('.btn-edit').off('click').on('click', function () {
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            $('#editTab').toggleClass('disabledTab');
            postController.loadDetail(id);
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    postController.delete(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    postController.deleteMul();
            });
        });
        $('.btn-clear').off('click').on('click', function () {
            $('#txtSearch').val('');
            postController.loadData();
        });
        $('#txtSearch').keypress(function (event) {
            if (event.keyCode === 13) {
                postController.loadData(true);
            }
        });
        $('#selectAll').change(function () {
            $('.selectedItem').prop('checked', $(this).prop('checked'));
            $('#btn-Deletemulti').removeAttr('disabled');
        });
        $('.selectedItem').on('click', function () {
            $(this).attr('checked', this.checked ? '' : 'checked');
        });

        $('.selectedItem').on('change', function () {
            var selectedItem = $('.selectedItem').attr('checked').length;
            if (selectedItem > 1) {
                $('#btn-Deletemulti').removeAttr('disabled');
            } else {
                $('#btn-Deletemulti').add('disabled');
            }
        });
    },
    delete: function (id) {
        $.ajax({
            url: '/admin/post/Delete',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success("Xóa thành công");
                postController.loadData(true);
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
                url: '/admin/post/DeleteMul',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        toastr.success(response.message);
                        postController.loadData(true);
                    } else {
                        toastr.error(response.message);
                        postController.loadData(true);
                    }
                }
            });
        }
    },
    checkExist: function (name) {
        $.ajax({
            url: '/admin/post/CheckExist',
            data: {
                name: name
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.result === true) {
                    postController.Post();
                } else {
                    $('.validate').html('Tên ' + name + ' đã tồn tại!');
                    toastr.error('Tên ' + name + ' đã tồn tại!');
                }
            }
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/admin/post/GetDetail',
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
                    tinymce.get('EditContent').setContent(item.content);
                    $('#EditThumbnail').attr('src', item.avatar);
                    $('#EditVia').val(item.via);
                    $('#EditLinkVia').val(item.linkVia);
                    $('#EditStatus').prop('checked', item.status);
                    }
                else {
                    toastr.error(res.message);
                    postController.loadData(true);
                }
            }
        });
    },
    Post: function () {
        var Name = $('#txtName').val();
        var MetaName = commonController.getSeoTitle(Name);
        var thumbNail = $('#ImgThumbnail').attr('src');
        var Content = tinymce.get('txtContent').getContent();
        var Via = $('#txtVia').val();
        var LinkVia = $('#txtLinkVia').val();
        var status = $('#txtStatus').prop('checked');

        var e = {
            Name: Name,
            MetaName: MetaName,
            Avatar: thumbNail,
            Content: Content,
            Via: Via,
            LinkVia: LinkVia,
            Status: status
        };

        $.ajax({
            url: '/admin/post/Post',
            data: {
                post: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    postController.loadData(true);
                    toastr.success(response.message);
                } else {
                    toastr.error(response.message);
                }
            }
        });

    },
    Put: function () {
        var id = $("#EditId").val();
        var Name = $('#EditName').val();
        var thumbNail = $('#EditImage').attr('src');
        var Content = tinymce.get('EditContent').getContent();
        var via = $('#EditVia').val();
        var LinkVia = $('#EditLinkVia').val();
        var status = $('#EditStatus').prop('checked');

        var e = {
            Id: id,
            Name: Name,
            MetaName: commonController.getSeoTitle(Name),
            Avatar: thumbNail,
            Content: Content,
            Via: via,
            LinkVia: LinkVia,
            Status: status
        };
        $.ajax({
            url: '/admin/post/Put',
            data: {
                post: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    postController.loadData(true);
                    toastr.success(response.message);
                } else {
                    toastr.error(response.message);
                }
            }
        });

    },
    loadData: function (changePageSize) {
        var search = $('#txtSearch').val();
        $.ajax({
            url: '/admin/post/GetAll',
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
                            Image: item.avatar,
                            CreatedDate: $.datepicker.formatDate('dd-mm-yy', new Date(item.createdDate)),
                            Via: item.via,
                            LinkVia: item.linkVia,
                            Status: item.status ? "<a href='#' class='btn-active badge bg-green' data-id='" + item.id + "'><i class='fa fa-check'>Active</i><\/a>" : "<a href='#' class='btn-active badge bg-red' data-id='" + item.id + "'><i class='fa fa-ban'>NotActive</i><\/a>"
                        });
                    });
                    $('#tbData').html(html);
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    postController.paging(response.total, function () {
                        postController.loadData();
                        $('#currentpage').html(config.pageIndex);
                        $('#totalpage').html(totalPage);
                    }, changePageSize);
                    postController.registerEvent();
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
postController.init();