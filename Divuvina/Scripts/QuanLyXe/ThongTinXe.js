jQuery(function ($) {
    //===================================================
    $("#btSave").on('click', function (e) {
        e.preventDefault();

        $('#KeyHangSanXuatXe').val($('#HangSanXuatXeKey').val());
        $('#KeyLoaiXe').val($('#LoaiXeKey').val());

        //Save 
        //==================================
        $.ajax({
            type: "POST",
            datatype: "JSON",
            url: '/QuanLyXe/LuuThongTinXe',
            data: $('#formThongTinXe').serialize(),
            //----------------------------------
            success: function (response) {
                if (response != null) {
                    //XoaDuLieuForm();
                    //alert('Thực hiện thành công.');
                    ShowMessage(response);
                }//End If
                else {
                    $('#output').text(msg);
                }
            },
            //----------------------------------
            //complete: function () {

            //},
            //----------------------------------
            failure: function (msg) {
                $('#output').text(msg);
            },
            //----------------------------------
            //error: function (jqXhr, exception) {
            //    ShowMessage(response);
            //    //if (jqXhr.status != 0) ShowMessage(response); //alert('Thực hiện không thành công');
            //}
        });//End ajax
    });

    

    //===================================================
    var table = $('#tableThongTinXe').DataTable({
        ajax: {
            //type: "GET",
            //datatype: "JSON",
            url: '/QuanLyXe/LayThongTinXe',
            //contentType: "application/json; charset=utf-8",
            dataSrc: ''
        }
        , columns: [
            {
                data: null,
                searchable: false
                , orderable: false
                , targets: 0
            },
            { data: 'XeKey', visible: false },
            { data: 'HangSanXuatXeKey', visible: false },
            { data: 'LoaiXeKey', visible: false },
            { data: 'BangSoXe' },
            { data: 'SoSan' },
            { data: 'LoaiXe' },
            { data: 'HangSanXuatXe' },
            { data: 'NgayCapPhep' },
            { data: 'Mau' },
            { data: 'GiaMua' },
            { data: 'TongTienKhauHao' },
            { data: 'SoThangKhauHao' },
            { data: 'TienKhauHaoHangThang' },
            { data: 'NgayBatDauKhauHao' },
            { data: 'NgayKetThucKhauHao' },
            { data: 'CoWifi' },
            { data: 'CoTivi' },
            { data: 'CoCameraHanhTrinh' },
            { data: 'GhiChuThongTinXe' },
            { data: 'GhiChuKhauHaoXe' },
            {
                data: null,
                defaultContent: '<a class="edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a>',
                orderable: false
            }
            , {
                data: null,
                defaultContent: '<a class="delete"><i class="fa fa-trash" aria-hidden="true"></i> Xóa</a>',
                orderable: false
            }
        ]//EndColumns
        , order: [1, 'asc']
        , language: {
            lengthMenu: 'Hiển thị _MENU_ dòng mỗi trang'
            , info: 'Hiển thị dòng _START_ đến dòng _END_ trên tổng số _TOTAL_ dòng'
            , infoEmpty: 'Hiển thị dòng _START_ đến dòng _END_ trên tổng số _TOTAL_ dòng'
            , search: 'Tìm kiếm'
            , paginate: {
                first: "Trang đầu",
                last: "Trang cuối",
                next: "Sau",
                previous: "Trước"
            }
        }
    });

    //===================================================
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //===================================================
    $('#tableThongTinXe tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    $('#tableThongTinXe').on('click', 'a.edit', function (e) {
        var row = $('#tableThongTinXe').DataTable().data()[$('#tableThongTinXe').DataTable().row('.selected')[0][0]];
        $('#XeKey').val(row.XeKey);
        $('#HangSanXuatXeKey').val(row.HangSanXuatXeKey).change();
        $('#LoaiXeKey').val(row.LoaiXeKey).change();
        $('#BangSoXe').val(row.BangSoXe);
        $('#SoSan').val(row.SoSan);
        $('#Mau').val(row.Mau);
        $('#NgayCapPhep').val(row.NgayCapPhep);
        $('#CoWifi').prop('checked', row.CoWifi);
        $('#CoTivi').prop('checked', row.CoTivi);
        $('#CoCameraHanhTrinh').prop('CoCameraHanhTrinh', row.CoTivi);
        $('#GhiChuThongTinXe').val(row.GhiChuThongTinXe);
        $('#GiaMua').val(row.GiaMua);
        $('#TongTienKhauHao').val(row.TongTienKhauHao);
        $('#SoThangKhauHao').val(row.SoThangKhauHao);
        $('#TienKhauHaoHangThang').val(row.TienKhauHaoHangThang);
        $('#NgayBatDauKhauHao').val(row.NgayBatDauKhauHao);
        $('#NgayKetThucKhauHao').val(row.NgayKetThucKhauHao);
        $('#GhiChuKhauHaoXe').val(row.GhiChuKhauHaoXe);
    });//EndFunction

    //$('#tableThongTinXe').on('click', 'a.delete', function (e) {
    //    var row = $('#tableThongTinXe').DataTable().data()[$('#tableThongTinXe').DataTable().row('.selected')[0][0]];
    //    $.ajax({
    //        type: "POST",
    //        url: '/QuanLyXe/XoaThongTinXe)',
    //        data: "{ \"Key\" : \"" + row.Key + "\" }",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (response) {
    //            $('#dtSource').DataTable().ajax.reload();
    //            onNewClick();

    //            ShowMessage(response);
    //        },
    //        failure: function (msg) {
    //            $('#output').text(msg);
    //        }
    //    });
    //});//EndFunction
});//EndFunction$