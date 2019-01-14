var config = {
    pageSize: 12,
    pageIndex: 1,
    viewport: {
        width: 189,
        height: 245
    }
};
var giaodichController = {
    init: function () {
        giaodichController.loadData();
        giaodichController.registerEvent();
        giaodichController.loadAccount();
    },
    registerEvent: function () {
        $('.datepicker').datepicker({
            format: 'mm/dd/yyyy'
        });
        $('#txtAccountName,#txtNoiDung').select2();
        $('#frmAddNew').validate({
            rules: {
                AccountName: {
                    required: true
                },
                price: "required",
                Content: "required"
            },
            messages: {
                AccountName: {
                    required: "Chọn một tài khoản"
                },
                price: "Nhập số tiền cần giao dịch",
                Content: {
                    required: "Chọn một nội dung giao dịch"
                }
            }
        });

        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                giaodichController.Post();
            }
        });
        $('#txtPrice').autoNumeric("init", {  mDec: '' });
        $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmEditData').valid()) {
                giaodichController.Put();
            }
        });
        $('.btn-deleteAll').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc chắn muốn xóa các bản ghi được chọn không?", function (result) {
                if (result) {
                    giaodichController.deleteAll();
                }
            });
            
        });

        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    giaodichController.delete(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    giaodichController.deleteMul();
            });
        });
        $('.btn-clear').off('click').on('click', function () {
            $('#txtSearch').val('');
            giaodichController.loadData();
        });
        $('#txtSearch').keypress(function (event) {
            if (event.keyCode === 13) {
                giaodichController.loadData(true);
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
            url: '/admin/giaodich/Delete',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success("Xóa thành công");
                giaodichController.loadData(true);
            }
        });
    },
    deleteAll: function () {
        var listSelected = [];

        $("td input:checked").each(function () {
            listSelected.push($(this).data('id'));
        });
        if (listSelected.length === 0) {
            toastr.warning("Không có phần tử nào được chọn!");
        } else {
            $.ajax({
                url: '/admin/giaodich/DeleteMulti',  
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        toastr.success(response.message);
                        giaodichController.loadData(true);
                    } else {
                        toastr.error(response.message);
                        giaodichController.loadData(true);
                    }
                }
            });
        }
    },
    loadAccount: function () {
        var listOption = $('#txtAccountName');
        $.ajax({
            url: '/admin/giaodich/getaccount',
            type: 'post',
            dataType: 'json',
            success: function (res) {
                var data = res.data;
                $(data).each(function (i, item) {
                        listOption.append($('<option/>', { value: item.id, text: item.userName + " --Tk chính: " + item.taiKhoanChinh.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) }));
                });
            }
        });
    },

    Post: function () {
        var userId = $('#txtAccountName').val();
        var price = $('#txtPrice').val();
        var content = $('#txtNoiDung').val();
        var notes = $('#txtNotes').val();
        var e = {
            UserId: userId,
            Content: content,
            SoTien: price,
            Notes: notes
        };
        $.ajax({
            url: '/admin/giaodich/Post',
            data: {
                giaodich: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    location.reload();
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
            url: '/admin/giaodich/AllGiaoDich',
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
                            Id: item.id,
                            UserName: item.userName,
                            PhoneNumber: item.phoneNumber,
                            NoiDung: item.content?"Nạp tiền vào tài khoản":"Trừ tiền tài khoản",
                            NgayGiaoDich: item.createdDate,
                            TongGiaoDich: item.soTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }),
                            GhiChu: item.notes
                        });
                    });
                    if (data.length === 0) {
                        $('#tbData').append("<tr rowspan='8'>Khong co ban ghi nao!</tr>");
                    } else {
                        $('#tbData').html(html);
                    }
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    giaodichController.paging(response.total, function () {
                        giaodichController.loadData();
                        $('#currentpage').html(config.pageIndex);
                        $('#totalpage').html(totalPage);
                    }, changePageSize);
                    giaodichController.registerEvent();
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
giaodichController.init();
