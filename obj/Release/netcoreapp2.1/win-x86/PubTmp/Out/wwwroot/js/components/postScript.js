var config = {
    pageSize: 16,
    pageIndex: 1
};
var postScripts = {
    Init: function () {
        postScripts.loadData();
        postScripts.registerEvent();
    },
    registerEvent: function () {
        $('.btn-search').off('click').on('click', function () {
            postScripts.loadData(true);
        });
        $('#txtSearch').keypress(function (event) {
            if (event.keyCode === 13) {
                postScripts.loadData(true);
            }
        });
        $('#txtSearch').on('click', function () {
            $('#txtSearch').val('');
        });
       
    },
    loadData: function (changePageSize) {
        var search = $('#txtSearch').val();

        $.ajax({
            url: '/post/getall',
            type: 'POST',
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
                        var url = "/khuyen-mai/" + item.metaName + "/" + item.id + "/";
                        html += Mustache.render(template, {
                            url: url,
                            name: item.name,
                            thumbnailUrl: item.avatar,
                            TimePost:item.timePost
                        });
                    });
                    $('#data-render').html(html);
                    if (response.total > config.pageSize) {
                        postScripts.paging(response.total, response.page, function () {
                            postScripts.loadData();
                        }, changePageSize);
                    } else {
                        $('.pagination').hide();
                    }
                   
                }
            }
        });
    },
    paging: function (totalRow, page, callback) {
        if ($('#pagination a').length === 0) {
            $('#pagination').empty();
            $('#pagination').removeData("pagination");
            $('#pagination').unbind("page");
        }
        $('#pagination').pagination({
            items: totalRow,
            itemsOnPage: config.pageSize,
            currentPage: page,
            hrefTextPrefix: '#trang-',
            prevText: "&lt",
            nextText: "&gt;",
            cssStyle: 'light-theme',
            onPageClick: function (page, event) {
                config.pageIndex = page;
                currentPage = page;
                setTimeout(callback, 0);
            }
        });
    }
};
postScripts.Init();