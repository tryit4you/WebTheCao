var config = {
    pageSize: 12,
    pageIndex: 1,
    viewport: {
        width: 189,
        height: 245
    }
};
var cardController = {
    init: function () {

        cardController.registerEvent();
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
                Image: "required",

                Price: {
                    required: true,
                    min: 0,
                    number: true
                },
                UnitPrice: {
                    required: true,
                    min: 0,
                    number: true
                },
                Point: {
                    required: true,
                    min: 0,
                    max: 1000000,
                    number: true
                }
            },
            messages: {
                Name: {
                    required: "Tên là bắt buộc"
                },
                Image: "Yêu cầu có ảnh đại diện",
                Price: {
                    required: "Yêu cầu mệnh giá thẻ cào",
                    min: "Giá trị nhỏ nhất là 0!",
                    number: "Mệnh giá thẻ không hợp lệ!"
                },
                UnitPrice: {
                    required: "Nhập dung lượng",
                    min: "Số trang phải ít nhất là 0!",
                    number: "Dung lượng không hợp lệ!"
                },
                Point: {
                    required: "Yêu cầu nhập điểm",
                    min: "Giá trị nhỏ nhất là 0",
                    max: "Giá trị lớn nhất là 1000000",
                    number: "Không đúng định dạng"
                }
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
                cardController.Post();
            }
        });
        $('.btn-save-mg-false').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var menhgiaId = $('#MenhGiaId-' + id+"-false").val();
            var price = $('#txtPrice-' + id + "-false").val();
            var unitPrice = $('#txtUnit_Price-' + id + "-false").val();
            var point = $('#txtPoints-' + id).val();
            if (price === "" || unitPrice === "" || point === "") {
                toastr.info('Điền thông tin đầy đủ vào các trường!');
            } else {
                if (menhgiaId !== "") {
                    cardController.PutMg(id,false);
                } else {
                    cardController.ThemMenhGia(id,false);
                }

            }

        });
        $('.btn-save-mg-true').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var menhgiaId = $('#MenhGiaId-' + id+"-true").val();
            var price = $('#txtPrice-' + id + "-true").val();
            var unitPrice = $('#txtUnit_Price-' + id + "-true").val();
            var point = $('#txtPoints-' + id).val();
            if (price === "" || unitPrice === "" || point === "") {
                toastr.info('Điền thông tin đầy đủ vào các trường!');
            } else {
                if (menhgiaId !== "") {
                    cardController.PutMg(id,true);
                } else {
                    cardController.ThemMenhGia(id,true);
                }

            }

        });

        $('#SaveEdit').off('click').on('click', function () {
            if ($('#frmUpdate').valid()) {
                cardController.Put();
            }
        });

        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var target = $(this);
            $.ajax({
                url: '/admin/card/ChangeStatus',
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
        $('.btn-edit').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            cardController.loadDetail(id);
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa danh mục này không?", function (result) {
                if (result) {
                    cardController.delete(id);
                }
            });
        });
        $('.btnDelete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm("Bạn có chắc chắn muốn xóa loại thẻ này không? ", function (result) {
                if (result) {
                    cardController.deleteCard(id);
                }
            });
        });
        $('#btn-Deletemulti').off('click').on('click', function () {
            bootbox.confirm("Bạn có chắc muốn xóa các bản ghi được chọn không?", function (result) {
                if (result)
                    cardController.deleteMul();
            });
        });
        $('.format_number').autoNumeric("init");
        $('.btnEditCard').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('ul.nav.nav-tabs a:eq(2)').tab('show');
            cardController.loadCardDetail(id);

        });
        $('#dailyCheckbox').on('change', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            cardController.loadCardDetail(id);

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
            url: '/admin/card/DeleteMg',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success("Xóa thành công");
                cardController.refreshContent();
            }
        });
    }, deleteCard: function (id) {
        $.ajax({
            url: '/admin/card/DeleteCard',
            data: { id: id },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                toastr.success("Xóa thành công");
                cardController.loadData(true);
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
                url: '/admin/card/DeleteMul',
                data: {
                    ids: listSelected
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        toastr.success(response.message);
                        cardController.loadData(true);
                    } else {
                        toastr.error(response.message);
                        cardController.loadData(true);
                    }
                }
            });
        }
    },

    loadDetail: function (id) {
        $.ajax({
            url: '/admin/card/GetMgDetail',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    var item = res.data;
                    $('#MenhGiaId-' + item.cardId+"-"+item.daiLy).val(item.id);
                    $('#txtPrice-' + item.cardId + "-" + item.daiLy).val(item.price);
                    $('#txtUnit_Price-' + item.cardId + "-" + item.daiLy).val(item.unit_Price);
                    $('#txtPoints-' + item.cardId + "-" + item.daiLy).val(item.point);
                }
                else {
                    toastr.error(res.message);
                    cardController.loadData(true);
                }
            }
        });
    }, loadCardDetail: function (id) {
        $.ajax({
            url: '/admin/card/GetCardDetail',
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
                    $('#EditImage').attr('src', item.thumbNail);
                    $('#EditStatus').prop('checked', item.status);
                }
                else {
                    toastr.error(res.message);
                    cardController.loadData(true);
                }
            }
        });
    },
    ThemMenhGia: function (id, daily) {
        var cardId = $('#txtCardId-' + id + "-" + daily).data('id');
        var price = $('#txtPrice-' + id + "-" + daily).val();
        var unitPrice = $('#txtUnit_Price-' + id + "-" + daily).val();
        var points = $('#txtPoints-' + id + "-" + daily).val();
        var mg = {
            cardId: cardId,
            Price: price,
            unit_Price: unitPrice,
            Point: points,
            DaiLy: daily
        };
        $.ajax({
            url: '/admin/card/AddMenhGia',
            data: {
                mg: JSON.stringify(mg)
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    toastr.success(res.message);
                    cardController.refreshContent();
                }
            }
        });
    },
    Post: function () {
        var Name = $('#txtName').val();
        var thumbNail = $('#txtImage').attr('src');
        var status = $('#txtStatus').prop('checked');

        var e = {
            Name: Name,
            thumbNail: thumbNail,
            Status: status
        };

        $.ajax({
            url: '/admin/card/post',
            data: {
                card: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cardController.refreshContent();
                    toastr.success(response.message);
                } else {
                    toastr.error(response.message);
                }
            }
        });

    },
    PutMg: function (cid, daily) {
        var id = $("#MenhGiaId-" + cid + "-" + daily).val();
        var cardId = $('#txtCardId-' + cid + "-" + daily).data('id');
        var price = $('#txtPrice-' + cid + "-" + daily).val();
        var unitPrice = $('#txtUnit_Price-' + cid + "-" + daily).val();
        var point = $('#txtPoints-' + cid + "-" + daily).val();
            
        var e = {
            Id: id,
            CardId: cardId,
            Price: price,
            unit_Price: unitPrice,
            Point: point,
            DaiLy: daily
        };
        $.ajax({
            url: '/admin/card/PutMg',
            data: {
                mg: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cardController.refreshContent();
                    toastr.success(response.message);
                } else {
                    toastr.error(response.message);
                }
            }
        });

    },
    Put: function () {
        var id = $('#EditId').val();
        var name = $('#EditName').val();
        var thumbNail = $('#EditImage').attr('src');
        var status = $('#EditStatus').prop('checked');
        
        var e = {
            Id: id,
            Name: name,
            thumbNail: thumbNail,
            status: status
        };
        $.ajax({
            url: '/admin/card/putcard',
            data: {
                card: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cardController.refreshContent();
                    toastr.success(response.message);
                } else {
                    toastr.error(response.message);
                }
            }
        });

    }
    , refreshContent() {
        var content = $('#accordion');
        $.get('/admin/card/index', content);
    }
};
cardController.init();