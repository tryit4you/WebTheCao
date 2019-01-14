var config = {
    pageSize: 12,
    pageIndex: 1
};
var userAccountScripts = {
    Init: function () {
        userAccountScripts.registerEvent();

    },
    registerEvent: function () {
        $('.modal').modal();
        $('#emailRegister').keypress(function (event) {
            if ($('registerEmailForm').valid()) {
                if (event.keyCode === 13) {
                    var email = $('#emailRegister').val();
                    userAccountScripts.UploadEmailRegister(email);
                }
            }
        });
        $('#register-form').validate({
            errorElement: "span",
            errorClass: "error",
            rules: {
                register_username: {
                    required: true,
                    minlength: 4
                },
                register_email: {
                    required: true,
                    email: true
                },
                register_phone: {
                    required: true
                },
                register_password: {
                    required: true,
                    minlength: 8
                }
            }, messages: {
                register_username: {
                    required: "Tên tài khoản không được trống",
                    minlength: "Tên tài khoản phải ít nhất 4 ký tự"
                },
                register_email: {
                    required: "Yêu cầu nhập email",
                    email: "Địa chỉ email không hợp lệ"
                },
                register_phone: {
                    required: "Yêu cầu nhập số điện thoại"
                },
                register_password: {
                    required: "Yêu cầu nhập mật khẩu",
                    minlength: "Mật khẩu ít nhất 8 ký tự"
                }
            }
        });
        $('#registerEmailForm').validate({
            rules: {
                EMAIL: {
                    required: true,
                    email: true
                }
            }, messages: {
                EMAIL: {
                    required: "Yêu cầu nhập email",
                    email: "Địa chỉ email không hợp lệ"
                }
            }
        });
        
        $('#frmEditAccount').validate({
            errorElement: "span",
            errorClass: "error",
            rules: {
                Name: {
                    required: true,
                    minlength: 8
                },
                Phone: {
                    required:true
                },
                Email: {
                    required: true,
                    email: true
                }
            },
            messages: {
                Name: {
                    required: "Vui lòng điền tên",
                    minlength: "Tên phải chứa ít nhất 8 ký tự"
                },Phone: {
                    required: "Vui lòng điền số điện thoại"
                },Email: {
                    required: "Vui lòng điền email",
                    email: "Địa chỉ email không hợp lệ"
                }
            }
        });
        $('.btnUpdate').off('click').on('click', function () {
            if ($('#frmEditAccount').valid()) {
                userAccountScripts.updateAccount();
            }
        });
        $('#lost-form').validate({
            errorElement: "span",
            errorClass: "error",
            rules: {
                lost_email: {
                    required: true,
                    email: true
                }
            },
            messages: {
                lost_email: {
                    required: "Yêu cầu nhập email",
                    email: "Địa chỉ email không hợp lệ"
                }
            }
        });
        $('#btn-login').on('click', function (e) {
            e.preventDefault();
            var userName = $('#login_username').val();
            var passWord = $('#login_password').val();
            var rememberMe = $('#rememberMe').prop('checked');
            userAccountScripts.login(userName, passWord, rememberMe);
        });

        $('#btn-register').off('click').on('click', function (e) {
            e.preventDefault();
            if ($('#register-form').valid()) {
                var userName = $('#register_username').val();
                var email = $('#register_email').val();
                var phoneNumber = $('#register_phone').val();
                var password = $('#register_password').val();
                var param = {
                    UserName: userName,
                    Email: email,
                    PhoneNumber: phoneNumber,
                    Password: password
                };
                userAccountScripts.register(param);
            }
        });
        $('#forgot-password-btn').off('click').on('click', function (e) {
            var email = $('#lost_email').val();
            if ($('#lost-form').valid()) {
                userAccountScripts.resetPassword(email);
            }
        });

        $('.btnUpload').off('click').on('click', function () {
            if ($('#frmEbook').valid()) {
                userAccountScripts.Post();
            }
        });
        $('.btnEdit').off('click').on('click', function () {
            $('#editModal').modal('show');
        });
        $('#btn-Feedback').on('click', function () {
            if ($('#frmFeedback').valid()) {
                userAccountScripts.sendFeedback();
            }
        });
        $('.btnSave').off('click').on('click', function () {
            if ($('#frmEdit').valid()) {
                userAccountScripts.SaveChange();
            }
        });
    

        var $uploadCrop,
            tempFilename,
            rawImg,
            imageId;
        function readFile(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#upload-demo').addClass('ready');
                    rawImg = e.target.result;
                    $uploadCrop.croppie('bind', {
                        url: rawImg
                    }).then(function () {
                        console.log('jQuery bind complete');
                        $('.crop-avatar').removeClass('hidden');
                    });
                };
                reader.readAsDataURL(input.files[0]);
            }
            else {
                swal("Sorry - you're browser doesn't support the FileReader API");
            }
        }

        $uploadCrop = $('#upload-demo').croppie({
            viewport: {
                width: 200,
                height: 200,
                type: 'circle'
            },
            boundary: {
                width: 300,
                height: 300
            },
            enforceBoundary: false,
            enableExif: true
        });
        $('.upload-avatar').on('change', function () {
            imageId = $(this).data('id'); tempFilename = $(this).val();
            $('#cancelCropBtn').data('id', imageId); readFile(this);

        });
        $('#cropImageBtn').on('click', function (ev) {
            $uploadCrop.croppie('result', {
                type: 'base64'
            }).then(function (resp) {
                $('#item-img-output').attr('src', resp);
                var id = $('#txtId').val();
                $.ajax({
                    url: '/useraccount/uploadAvatar',
                    data: { "image": resp, userid: id },
                    type: 'post',
                    dataType: 'json',
                    success: function (res) {
                        if (res.status) {
                            location.reload();
                            M.toast({ html: 'Cập nhật hình đại diện thành công', classes: 'rounded light-blue accent-2' });
                        }
                    }
                });

            });
        });

        $(function () {
            var $formLogin = $('#login-form');
            var $formLost = $('#lost-form');
            var $formRegister = $('#register-form');
            var $divForms = $('#div-forms');
            var $modalAnimateTime = 300;
            var $msgAnimateTime = 150;
            var $msgShowTime = 2000;

            $('#login_register_btn').click(function () { modalAnimate($formLogin, $formRegister); });
            $('#register_login_btn').click(function () { modalAnimate($formRegister, $formLogin); });
            $('#login_lost_btn').click(function () { modalAnimate($formLogin, $formLost); });
            $('#lost_login_btn').click(function () { modalAnimate($formLost, $formLogin); });
            $('#lost_register_btn').click(function () { modalAnimate($formLost, $formRegister); });
            $('#register_lost_btn').click(function () { modalAnimate($formRegister, $formLost); });

            function modalAnimate($oldForm, $newForm) {
                var $oldH = $oldForm.height() + 20;
                var $newH = $newForm.height() + 60;
                $('#register_username').val('');
                $('#register_email').val('');
                $('#register_password').val('');
                $divForms.css("height", $oldH);
                $oldForm.fadeToggle($modalAnimateTime, function () {
                    $divForms.animate({ height: $newH }, $modalAnimateTime, function () {
                        $newForm.fadeToggle($modalAnimateTime);
                    });
                });
            }

            function msgFade($msgId, $msgText) {
                $msgId.fadeOut($msgAnimateTime, function () {
                    $(this).text($msgText).fadeIn($msgAnimateTime);
                });
            }

            function msgChange($divTag, $iconTag, $textTag, $divClass, $iconClass, $msgText) {
                var $msgOld = $divTag.text();
                msgFade($textTag, $msgText);
                $divTag.addClass($divClass);
                $iconTag.removeClass("glyphicon-chevron-right");
                $iconTag.addClass($iconClass + " " + $divClass);
                setTimeout(function () {
                    msgFade($textTag, $msgOld);
                    $divTag.removeClass($divClass);
                    $iconTag.addClass("glyphicon-chevron-right");
                    $iconTag.removeClass($iconClass + " " + $divClass);
                }, $msgShowTime);
            }
        });
    },
    UploadEmailRegister: function (email) {
        $.ajax({
            url: '/emailregister/upload',
            data: { email: email },
            type: 'post',
            dataType: 'json',
            success: function (res) {
            }
        });
    },
    SaveChange: function () {
        var id = $('#txtId').val();
        var displayName = $('#txtName').val();
        var address = $('#txtAddress').val();
        var phone = $('#txtPhoneNumber').val();
        var e = {
            Id: id,
            DisplayName: displayName,
            Address: address,
            PhoneNumber: phone
        };
        $.ajax({
            url: '/UserAccount/UpdateUser',
            data: {
                user: JSON.stringify(e)
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    $('#editModal').modal('hide');
                    location.reload();
                    console.log(res.message);
                } else {
                    console.log("lỗi cập nhật!!!");
                }
            }
        });
    },
    resetPassword: function (email) {
        $.ajax({
            url: '/UserAccount/SendPasswordResetLink',
            data: { email: email },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (status) {
                    $('#error-rs').html(res.message);
                    $('#error-rs').delay(500).fadeIn();
                    $('#error-rs').delay(2000).fadeOut();
                } else {
                    $('#error-rs').html(res.message);
                }
            }
        });
    },
    register: function (param) {
        var data = JSON.stringify(param);
        $.ajax({
            url: '/UserAccount/Register',
            data: {
                models: data
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                var errorlist = $('#validate-register');
                errorlist.html('');
                if (res.status === true) {
                    M.toast({ html: res.message, classes: 'rounded light-blue accent-2' });
                } else {
                    var data = res.message;
                    $.each(data, function (i, item) {
                        M.toast({ html: data[i], classes: 'rounded deep-orange lighten-2' });
                    });
                }
            }
        });
    },
    login: function (userName, password, rememberMe) {
        $.ajax({
            url: '/UserAccount/Login',
            data: {
                userName: userName,
                password: password,
                rememberMe: rememberMe
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status === true) {
                    M.toast({ html: res.message, classes: 'rounded light-blue accent-2' });
                    setTimeout(2000, location.reload());
                } else {
                    M.toast({ html: res.message, classes: 'rounded deep-orange lighten-2' });
                }
            }
        });
    },
    updateAccount: function () {
        var id = $('#txtId').val();
        var name = $('#displayName').val();
        var phoneNumber = $('#phoneNumber').val();
        var address = $('#address').val();
        var email = $('#Email').val();
        var data = {
            Id: id,
            DisplayName: name,
            Address: address,
            Email: email,
            PhoneNumber: phoneNumber
        };
        $.ajax({
            url: '/UserAccount/UpdateUser',
            data: {
                user: JSON.stringify(data)
            },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    M.toast({ html: res.message, classes: 'rounded light-blue accent-2' });
                    setTimeout(2000, location.reload());
                } else {
                    M.toast({ html: res.message, classes: 'rounded deep-orange lighten-2' });
                }
            }
        });
    }

};
userAccountScripts.Init();