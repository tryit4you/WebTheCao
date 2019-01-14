var config = {
    pageSize: 12,
    pageIndex: 1,
    viewport: {
        width: 189,
        height: 245
    }
};

//lich su nop card
var lichsuController = {
    init: function () {
        lichsuController.loadData(true);
    },
    registerEvent: function () {


        $('#btnThanhToan').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $("#hiddenId").val();
            $.ajax({
                url: '/admin/giaodich/ThanhToanThe',
                data: { id: id },
                type: 'post',
                dataType: 'json',
                success: function (res) {

                    if (res.status) {
                        toastr.remove();
                        toastr.success(res.message);

                        $('#naptheModal').modal('hide');
                    } else {
                        toastr.info(res.message);
                        $('#naptheModal').modal('hide');
                    }
                }
            });
        });
        $('.btn-checkInfor').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/admin/giaodich/getcardinfor',
                data: { id: id },
                type: 'post',
                dataType: 'json',
                success: function (res) {
                    if (res.message !== "") {
                        toastr.error(res.message);
                    } else {
                        if (res.status) {
                            var data = res.data;
                            var phidichvu = data.menhGia * data.soLuong * data.required;
                            var totals = data.giaChietKhau * data.soLuong + phidichvu;
                            $('#hiddenId').val(data.id);
                            $('#userName').html(data.userName);
                            $('#phoneNumber').html(data.soDienThoai);
                            $('#phidichvu').html(phidichvu.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
                            $('#waranty').html(data.soLuong);
                            $('#unit_price').html(data.giaChietKhau.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
                            $('#createdDate').html(data.ngayNopThe);
                            $('#typeCard').html(data.loaiThe);
                            $('#totals').html(totals.toLocaleString('vi', { style: 'currency', currency: 'VND' }));
                            if (data.trangThai) {
                                $('#btnThanhToan').attr('disabled','disabled');
                            }
                            $('#naptheModal').modal('show');
                        } else {
                            toastr.remove();
                            toastr.error("Không tìm thấy giao dịch này!");
                        }
                    }
                }
            });
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    lichsuController.delete(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    lichsuController.deleteMul();
            });
        });

        $('#selectAll').change(function () {
            $('.selectedItem').prop('checked', $(this).prop('checked'));
            $('#btn-Deletemulti').removeAttr('disabled');
        });
        $('.selectedItem').on('click', function () {
            $(this).attr('checked', this.checked ? '' : 'checked');
        });

        $('.selectedItem:first').on('change', function () {
            var selectedItem = $('.selectedItem').attr('checked').length;
            if (selectedItem > 1) {
                $('#btn-Deletemulti').removeAttr('disabled');
            } else {
                $('#btn-Deletemulti').add('disabled');
            }
        });
        $('.timeRad').on('change', function () {
            lichsuController.loadData(true);
        }); $('.statusRad').on('change', function () {
            lichsuController.loadData(true);
        });
        $('.btn-search').off('click').on('click', function () {
            lichsuController.loadData(true);
        });
    },
    delete: function (id) {
        $.ajax({
            url: '/admin/lichsu/deletehistory',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success("Xóa thành công");
                lichsuController.loadData(true);
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
                url: '/admin/giaodich/deleteAllHistory',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        toastr.success(response.message);
                        lichsuController.loadData(true);
                    } else {
                        toastr.error(response.message);
                        lichsuController.loadData(true);
                    }
                }
            });
        }
    },
    loadData: function (changePageSize) {
        var search = $('#txtSearch').val();
        var status = $('input[name=trangthainap]:checked').val();
        $.ajax({
            url: '/admin/giaodich/GetAll',
            type: 'post',
            data: {
                filter: search,
                page: config.pageIndex,
                pageSize: config.pageSize,
                statusRad: status
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            UserName: item.userName,
                            LoaiThe: item.loaiThe,
                            MenhGia: item.menhGia.toLocaleString('vi', { style: 'currency', currency: 'VND' }),
                            NgayNopThe: item.ngayNopThe,
                            SoDienThoai: item.soDienThoai.toLocaleString(),
                            SoLuong: item.soLuong,
                            TrangThai: item.trangThai ? " <a href='#' class='btn-checkInfor badge bg-green' data-id='" + item.id + "'><i class='fa fa-check' >Đã nạp</i><\/a>" : "<a href='#' class='btn-checkInfor badge bg-red' data-id='" + item.id + "'><i class='fa fa-ban'>Chưa nạp</i><\/a>"
                        });
                    });
                    $('#tbData').html(html);
                    lichsuController.registerEvent();
                    var totalPage = Math.ceil(response.total / config.pageSize);
                    if (response.total <= config.pageSize) {
                        $('.paging-area').hide();
                    } else {
                        lichsuController.paging(response.total, function () {
                            lichsuController.loadData();
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
lichsuController.init();