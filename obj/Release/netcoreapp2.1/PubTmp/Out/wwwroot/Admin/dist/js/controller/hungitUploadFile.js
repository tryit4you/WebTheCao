"use strict";
var hungitUploadFile = {
    Init: function () {
        hungitUploadFile.GetImgLib();
        hungitUploadFile.RegisterEvent();
    },
    RegisterEvent: function () {
        $('.selectImg').dblclick(function (e) {
            e.preventDefault();
            var ImgUrl = $(this).attr('src');
            $('#txtImage').attr('src', ImgUrl);
            $('#EditImage').attr('src',ImgUrl);
            $('#EditImg').attr('src', ImgUrl);
            $('#uploadFileModal').modal('hide');
        });
        $('.UploadModal').off('click').on('click', function () {
            hungitUploadFile.GetImgLib();
            $('#uploadFileModal').modal('show');
        });
        $('.remove').off('click').on('click', function () {
            var imageUrl = $(this).data('html');
            hungitUploadFile.removeImg(imageUrl);
        });
        $('#btn-search').off('click').on('click', function () {
            var filter = $('.txtSearch').val();
            hungitUploadFile.GetImgLib(filter);
        });
        $('#search-remove').on('click', function () {
            $('.txtSearch').val('');
            hungitUploadFile.GetImgLib();
        });
        $('#sort-bydate').on('click', function () {
            var sort = false;
            hungitUploadFile.GetImgLib('', sort);
        });
        $('#btn-upload').off('click').on('click', function () {
            hungitUploadFile.uploadImage();
        });
    },
    uploadImage: function () {
        var formData = new FormData();
        formData.append('file', $('#txtFileUpload')[0].files[0]);
        $.ajax({
            url: '/admin/UploadFileManager/UploadImage',
            data: formData,
            type: 'post',
            dataType: 'json',
            processData: false,
            contentType: false,
            success: function (res) {
                if (res.status) {
                    toastr.success("Upload file thành công");
                    hungitUploadFile.GetImgLib();
                }
            }
        });
    },
    removeImg: function (imgUrl) {
        $.ajax({
            url: '/admin/UploadFileManager/RemoveFileImage',
            data: { path: imgUrl },
            type: 'post',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    toastr.success("Xóa ảnh thành công!");
                    hungitUploadFile.GetImgLib();
                } else {
                    toastr.error("Không có ảnh được tìm thấy!");
                }
            }
        });
    },
    GetImgLib: function (filter, sort) {
        $.ajax({
            url: '/admin/UploadFileManager/GetImgLib',
            type: 'get',
            data: { filter: filter, sort: sort },
            dataType: 'json',
            success: function (res) {
                var data = res.data;
                var count = res.count;
                var capacity = res.capacity;
                $('#capacity').html(capacity);
                $('#count').html(count);
                var html = '';
                var template = $('#template-img').html();
                $.each(data, function (i, item) {
                    html += Mustache.render(template, {
                        Id: i,
                        image: item,
                    });
                });
                $('.img-frame').html(html);
                hungitUploadFile.RegisterEvent();
            }
        });
    }
};
hungitUploadFile.Init();