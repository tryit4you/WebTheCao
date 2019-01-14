var variant = {
    warenty: 0,
    price: 0,
    unitPrice: 0,
    required:0
};
var site = {
    init: function () {
        site.registerEvent();
        site.setDefaultText();
        site.getCard();
    },
    registerEvent: function () {
        $('.modal').modal();
        $('.slider').slider();
        $('.carousel-control-next').click(function (e) {
            e.preventDefault();
            e.stopPropagation();
            $('.slider').slider('next');
        });
        
        $('.carousel-control-prev').click(function (e) {
            e.preventDefault();
            e.stopPropagation();
            $('.slider').slider('prev');
        });
        $('.tabs').tabs();
        $('.sidenav').sidenav();
        $('.parallax').parallax();
        $('select').formSelect();
        $(".phone-format").keypress(function (e) {
            if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
            var curchr = this.value.length;
            var curval = $(this).val();
            if (curchr === 3 && curval.indexOf("(") <= -1) {
                $(this).val("(" + curval + ")" + "-");
            } else if (curchr === 4 && curval.indexOf("(") > -1) {
                $(this).val(curval + ")-");
            } else if (curchr === 5 && curval.indexOf(")") > -1) {
                $(this).val(curval + "-");
            } else if (curchr === 9) {
                $(this).val(curval + "-");
                $(this).attr('maxlength', '14');
            }
        });

        //validate form
        $('#frm-buy-card').validate({
            errorElement: "span",
            errorClass: "error",
            rules: {
                Warenty: {
                    required:true
                },
                Phone: {
                    required:true
                },
                Email: {
                    required: true,
                    email:true
                }
            },
            messages: {
                Warenty: {
                    required: 'Yêu cầu chọn số lượng thẻ!'
                },
                Phone: {
                    required: 'Yêu cầu nhập số điện thoại!'
                },
                Email: {
                    required: 'Yêu cầu nhập email ',
                    email: 'Địa chỉ email không hợp lệ'
                }
            }
        });
        $('#frm_feedback').validate({
            errorElement: "span",
            errorClass: "error",
            rules: {
                fullName: {
                    required:true
                },
                email: {
                    required: true,
                    email:true
                },
                Subject: {
                    required: true
                },
                content: {
                    minlength:10
                }
            },
            messages: {
                fullName: {
                    required: "Yêu cầu nhập tên bạn"
                },
                email: {
                    required: "Yêu cầu nhập email",
                    email: "Địa chỉ email không hợp lệ"
                },
                Subject: {
                    required:'Yêu cầu nhập tiêu đề'
                },
                content: {
                    minLength: "Nội dung phải tối thiểu 10 ký tự"
                }
            }
        });
        $('#btn_buy').off('click').on('click', function () {
            var userid = $('#userId').data('id');
            if (userid === '' || userid === undefined) {
                M.toast({ html: 'Opp! Bạn vui lòng đăng nhập hoặc đăng ký để tiếp tục', classes: 'rounded  orange lighten-1' });
            } else {
                var selectedCard = $('.list-card-items > .card-active').length;
                var selectedPrice = $('.list-price-items > .price-active').length;
                var warenty = $('#selectWarenty').val();
                status = false;
                if (selectedCard > 0) {
                    if (warenty === null) {
                        M.toast({ html: 'Chọn số lượng thẻ cào!', classes: 'rounded  orange lighten-1' });
                    } else {
                        status = true;
                    }
                    if (selectedPrice > 0) {
                        if ($('#frm-buy-card').valid() && status === "true") {
                            var menhgiaId = $('.list-price-items > .price-active').data('id');
                            var required = $('#selectRequired').val();
                            var sl = warenty;
                            site.checkTKAccount(menhgiaId, required, sl);
                           
                        }
                    } else {
                        M.toast({ html: 'Vui lòng chọn mệnh giá thẻ cào', classes: 'rounded  orange lighten-1' });
                    }
                } else {
                    M.toast({ html: 'Vui lòng chọn một nhà mạng', classes: 'rounded  orange lighten-1' });
                }
            }
          
        });
        //send feedback
        $('#frm_feedback').validate({
            errorElement: "span",
            errorClass: "error",
            rules: {
                fullName: {
                    required: true
                },
                email: {
                    required: true,
                    email: true
                },
                Subject: {
                    required: true
                },
                content: {
                    minlength: 10
                }
            },
            messages: {
                fullName: {
                    required: "Yêu cầu nhập tên bạn"
                },
                email: {
                    required: "Yêu cầu nhập email",
                    email: "Địa chỉ email không hợp lệ"
                },
                Subject: {
                    required: 'Yêu cầu nhập tiêu đề'
                },
                content: {
                    minLength: "Nội dung phải tối thiểu 10 ký tự"
                }
            }
        });
        //select card
        $('.list-card-items >img').on('click', function () {
            $('.list-card-items >img').removeClass('card-active');
            $(this).addClass('card-active');
            var id = $(this).data('id');
            var getname = $(this).attr('alt');
            $('#_nha_mang').empty();
            $('#_nha_mang').text(getname);
            site.getPrice(id);
        }); //select price
        $('.list-price-items >a').on('click', function (e) {
            e.preventDefault();
            $('.list-price-items >a').removeClass('price-active');
            $(this).addClass('price-active');
            var getPrice = $(this).text();
            $('#_menh_gia').empty();
            $('#_menh_gia').text(getPrice);
            variant.price = parseInt($(this).attr('title'));
            variant.unitPrice = parseInt($(this).children().val());
            variant.required = $('#selectRequired').val();
            site.getTotalPrice(variant.warenty, variant.unitPrice, variant.price);
        });
        $('#selectWarenty').on('change', function () {
            $('#_so_luong_the').empty();
            $('#_so_luong_the').text($(this).val());
            variant.warenty = $(this).val();
            variant.required = $('#selectRequired').val();
            site.getTotalPrice(variant.warenty, variant.unitPrice, variant.price);
        });
        $('#txtEmail').on('change', function () {
            $('#_email').empty();
            $('#_email').text($(this).val());
        });
        $('#selectRequired').on('change', function () {
            $('#_required').empty();
            variant.required = $(this).val();
            site.getTotalPrice(variant.warenty, variant.unitPrice, variant.price);
        });
        $('#txtPhone').on('change', function () {
            $('#_so_dien_thoai').empty();
            $('#_so_dien_thoai').text($(this).val());
        });
        $('.btn-feeback').off('click').on('click', function () {
            if ($('#frm_feedback').valid()) {
                site.sendFeedback();
            }
        });
    },
    verifyRecapcha: function () {
        var recaptcha = $("#g-recaptcha-response").val();
        if (recaptcha === "") {
            alert("Hãy xác thực Captcha");
        } else {
            $.ajax({
                async: false,
                url: "/api/captcha/verify",
                method: "POST",
                data: { "captchaResponse": recaptcha },

                success: function (response) {
                    if (response.success === true) {
                        site.addNopCard();
                    } else {
                        alert("Xác thực captcha không thành công \n" );
                    }
                },

                error: function (jqXHR, textStatus, errorThrown) {
                    alert("captcha verification NOT successful");
                }
            });
        }   
    },
    sendFeedback: function () {
        var feedback = {
            Name: $('#txtName').val(),
            Phone: $('#txtPhone').val(),
            Email: $('#txtemail').val(),
            Subject: $('#txtSubject').val(),
            Message: $('#txtContent').val()
        };
        $.ajax({
            url: '/page/PostFeedback',
            data: { feedback: JSON.stringify(feedback) },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    M.toast({ html: res.message, classes: 'rounded light-blue lighten-2' });
                    site.resetFeedback();
                }
            }

        });
    },
    addNopCard: function () {
        var recaptcha = $("#g-recaptcha-response").val();
        var getform = {
            cardId: $('.list-card-items >.card-active').data('id'),
            menhgiaId: $('.list-price-items > .price-active').data('id'),
            warenty: $('#selectWarenty').val(),
            email: $('#txtEmail').val(),
            required: $('#selectRequired').val(),
            phone: $('#txtPhone').val(),
            NoiDung: $('#txtDescription').val()
        };
        $.ajax({
            url: '/card/buycard',
            data: {
                form: JSON.stringify(getform),
                captchaResponse: recaptcha
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    M.toast({html: res.message, classes: 'rounded light-blue lighten-2' });
                } else {
                    M.toast({html: res.message, classes: 'rounded red' });
                }
            }
        });
    },
    getTotalPrice: function (warenty,unitPrice, price) {
        if (warenty !== 0 && price !== 0) {
            var totalPrice = warenty * price;
            var totalunitPrice = warenty * unitPrice;
            var requiredprice = totalPrice * variant.required;
            var total = totalunitPrice + requiredprice;
            $('#_totalPrice,#_totalUnitPrice').empty();
            $('#_required').html(requiredprice.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
            $('#_totalPrice').html(totalPrice.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
            $('#_totalUnitPrice').html(totalunitPrice.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
            $('#_total').html(total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
            $('#_total').attr('title',total);

        }
    },
    getCard: function () {
        $.ajax({
            url: '/card/getcard',
            type: 'get',
            dataType: 'json',
            success: function (res) {
                if (res.data !== null) {
            
                    $.each(res.data, function (i, item) {
                        var html = '<img src="' + item.thumbNail + '" class="img-responsive " alt="' + item.name + '" data-id="'+item.id+'" />';
                        $('.list-card-items').append(html);
                    });
                } else {
                    var html = '<p>Không có thẻ cào nào</p>';
                    $('.list-card-items').append(html);
                }
                site.registerEvent();
            }
        });
    },
    getPrice: function (cardId) {
        $.ajax({
            url: '/card/getPrice',
            data: { cardId: cardId },
            type: 'get',
            dataType: 'json',
            success: function (res) {
                if (res.data !== null) {
                    $('.list-price-items >a').remove();
                    $.each(res.data, function (i, item) {

                        var html = ' <a href="#" data-id=' + item.id + ' title=' + item.price + '>' +
                            item.price.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) +
                            "<input type='hidden' name = 'unitPrice' class='unitPrice' value = '" + item.unit_Price + "' />" + '</a>';
                        $('.list-price-items').append(html);
                    });
                    $('.price').removeClass('hidden');
                }
                site.registerEvent();
            }
        });
    },
    setDefaultText: function () {
        $('#_nha_mang').text('_____');
        $('#_so_luong_the').text('_____');
        $('#_so_luong_the').text('_____');
        $('#_menh_gia').text('_____');
        $('#_so_dien_thoai').text('_____');
        $('#_email').text('_____');
    },
    resetFeedback: function () {
        $('#txtName').val('');
        $('#txtemail').val('');
        $('#txtPhone').val('');
        $('#txtSubject').val('');
        $('#txtContent').val('');
    },
  
    checkTKAccount: function (menhgiaId,required,sl) {
        $.ajax({
            url: '/card/checkTKAccount',
            type: 'post',
            data: {
                menhgiaId: menhgiaId,
                required: required,
                soluong:sl
            },
            dataType: 'json',
            success: function (res) {
                if (res.result) {
                    //request recapcha
                    site.verifyRecapcha();
                } else {
                    M.toast({ html: 'Tài khoản không đủ để thực hiện giao dịch!', classes: 'rounded  orange lighten-1' });
                    window.open('/giao-dich/nap-tien', '_blank');
                }
            }
        });
    }
};
site.init();
