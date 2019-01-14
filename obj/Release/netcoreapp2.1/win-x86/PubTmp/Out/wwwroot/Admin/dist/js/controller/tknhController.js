var config = {
    pageSize: 12,
    pageIndex: 1,
    viewport: {
        width: 189,
        height: 245
    }
};
var tknhController = {
    init: function () {

        tknhController.registerEvent();
    },
    registerEvent: function () {
        jQuery.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $('#frmAddNew').validate({
            rules: {
                Name: {
                    required: true
                },
                SoTK: {
                    required: true,
                    number: true
                },

                NguoiThuHuong: {
                    required: true
                   
                },
                TenChiNhanh: {
                    required: true
                }
            },
            messages: {
                Name: {
                    required: "Tên là bắt buộc"
                },
                SoTK: {
                    required: "Yêu cầu nhập số tài khoản",
                    number: "Số tài khoản không đúng định dạng"
                },

                NguoiThuHuong: {
                    required: "Yêu cầu nhập người thụ hưởng"

                },
                TenChiNhanh: {
                    required: "Yêu cầu nhập tên chi nhánh"
                }
            }
        });
        $('#frmUpdate').validate({
            rules: {
                EditName: {
                    required: true
                },
                EditSoTK: {
                    required: true,
                    number: true
                },

                EditNguoiThuHuong: {
                    required: true

                },
                EditTenChiNhanh: {
                    required: true
                }
            },
            messages: {
                EditName: {
                    required: "Yêu cầu nhập tên ngân hàng"
                },
                EditSoTK: {
                    required: "Yêu cầu số tài khoản",
                    number: "Số tài khoản không đúng định dạng"
                },

                EditNguoiThuHuong: {
                    required: "Yêu cầu tên người thụ hưởng"

                },
                EditTenChiNhanh: {
                    required: "Yêu cầu tên chi nhánh"
                }
            }
        });

        $('#btnAdd').off('click').on('click', function () {
            if ($('#frmAddNew').valid()) {
                tknhController.Post();
            }
        });


        $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                tknhController.Put();
            }
        });

        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(this);
            $.ajax({
                url: '/admin/taikhoanthe/ChangeStatus',
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
 

        $('.btnDelete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa loại thẻ này không? ", function (result) {
                if (result) {
                    tknhController.delete(id);
                }
            });
        });
   
        $('.format_number').autoNumeric("init");
        $('.btnEdit').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            tknhController.loadDetail(id);

        });

     
       
    },
    delete: function (id) {
        $.ajax({
            url: '/admin/taikhoanthe/Delete',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success("Xóa thành công");
                tknhController.loadData(true);
            }
        });
    }, 
    loadDetail: function (id) {
        $.ajax({
            url: '/admin/taikhoanthe/GetDetail',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    var item = res.data;
                    $('#EditId').val(item.id);
                    $('#EditName').val(item.tenNH);
                    $('#EditSoTK').val(item.soTK);
                    $('#EditNguoiThuHuong').val(item.nguoiThuHuong);
                    $('#EditTenChiNhanh').val(item.tenChiNhanh);
                    $('#EditStatus').prop('checked', item.status);
                }
                else {
                    toastr.error(res.message);
                    location.reload();
                }
            }
        });
    },
    Post: function () {
        var Name = $('#txtName').val();
        var SoTk = $('#txtSoTK').val();
        var NguoiThuHuong = $('#txtNguoiThuHuong').val();
        var TenChiNhanh = $('#txtTenChiNhanh').val();
        var Status = $('#txtStatus').prop('checked');


        var e = {
            TenNH: Name,
            SoTK: SoTk,
            NguoiThuHuong: NguoiThuHuong,
            TenChiNhanh: TenChiNhanh,
            Status:Status
        };

        $.ajax({
            url: '/admin/taikhoanthe/post',
            data: {
                tknh: JSON.stringify(e)
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
    Put: function () {
        var id = $('#EditId').val();
        var Name = $('#EditName').val();
        var SoTk = $('#EditSoTK').val();
        var NguoiThuHuong = $('#EditNguoiThuHuong').val();
        var TenChiNhanh = $('#EditTenChiNhanh').val();
        var Status = $('#EditStatus').prop('checked');
        var e = {
            Id: id,
            TenNH: Name,
            SoTk: SoTk,
            NguoiThuHuong: NguoiThuHuong,
            TenChiNhanh: TenChiNhanh,
            Status: Status
        };
        $.ajax({
            url: '/admin/taikhoanthe/put',
            data: {
                tknh: JSON.stringify(e)
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

    }
};
tknhController.init();