//===================================================
function CauHinhBangDuLieu() {
    //_______________________________________________
    var table = $('#dtSource').DataTable({
        ajax: {
            url: '/DanhMucXe/LayHangSanXuatXe'
            , dataSrc: ''
        }
        , columns: [
                    {
                        data: null,
                        searchable: false
                        , orderable: false
                        , targets: 0
                    },
                    { data: 'Key', visible: false },
                    { data: 'Ten' },
                    { data: 'GhiChu' },
                    {
                        data: null,
                        defaultContent: '<a class="edit"><center><i class="glyphicon glyphicon-pencil" aria-hidden="true"></i></center></a>',
                        orderable: false
                    }
                    , {
                        data: null,
                        defaultContent: '<a class="delete"><center><i class="glyphicon glyphicon-trash" aria-hidden="true"></i></center></a>',
                        orderable: false
                    }
        ]
                , order: [1, 'asc']
                , language: {
                    lengthMenu: 'Hiển thị _MENU_ dòng mỗi trang'
                    , info: 'Hiển thị dòng _START_ đến dòng _END_ trên tổng số _TOTAL_ dòng'
                    , infoEmpty: 'Hiển thị dòng _START_ đến dòng _END_ trên tổng số _TOTAL_ dòng'
                    , zeroRecords: "Xin lỗi không có dữ liệu hiển thị"
                    , search: 'Tìm kiếm'
                    , decimal: ","
                    , thousands: "."
                    , paginate: {
                        first: "Trang đầu",
                        last: "Trang cuối",
                        next: "Sau",
                        previous: "Trước"
                    }
                }
    });

    //_______________________________________________
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //_______________________________________________
    $('#dtSource tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    //_______________________________________________
    $('#dtSource').on('click', 'a.edit', function (e) {
        e.preventDefault();
        var row = $('#dtSource').DataTable().data()[$('#dtSource').DataTable().row('.selected')[0][0]];
        $('#Key').val(row.Key);
        $('#Ten').val(row.Ten);
        $('#GhiChu').val(row.GhiChu);
    });//EndFunction

    //_______________________________________________
    $('#dtSource').on('click', 'a.delete', function (e) {
        e.preventDefault();
        var row = $('#dtSource').DataTable().data()[$('#dtSource').DataTable().row('.selected')[0][0]];
        $.ajax({
            type: "POST",
            url: "/DanhMucXe/XoaHangSanXuatXe",
            data: "{ \"Key\" : \"" + row.Key + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#dtSource').DataTable().ajax.reload();
                onNewClick();

                ShowMessage(response);
            },
            failure: function (msg) {
                $('#output').text(msg);
            }
        });
    });//EndFunction
}//EndFunction

//===================================================
jQuery(function ($) {

    //_______________________________________________
    CauHinhBangDuLieu();

});//EndFunction$

//===================================================
function onSaveClick() {
    if (($('#Key').val() == -1 || $('#Key').val() == "")
                && ($('#Ten').val() == "")) {
        toastr.error("Vui lòng nhập đủ thông tin !", "Thông báo !");
        return;
    }

    if ($('#Key').val() == "")
        $('#Key').val(-1);

    $.ajax({
        type: "POST",
        url: "/DanhMucXe/LuuHangSanXuatXe",
        data: "{ \"Key\" : \"" + $('#Key').val()
            + "\",\"ten\" : \"" + $('#Ten').val()
            + "\",\"ghiChu\" : \"" + $('#GhiChu').val()
            + "\" }",
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: function (response) {
            $('#dtSource').DataTable().ajax.reload();
            onNewClick();
            ShowMessage(response);
        },
        failure: function (msg) {
            $('#output').text(msg);
        }
    });
}//EndFunction

//===================================================
function onNewClick() {
    $('#Key').val("-1");
    $('#Ten').val("");
    $('#GhiChu').val("");
}//EndFunction