//===================================================
function CauHinhBangDuLieu() {
    //_______________________________________________
    var table = $('#dtSource').DataTable({
        ajax: {
            //url: '@Url.Action("LayDanhMucLoaiXe", "DanhMucXe")'
            url: '/DanhMucXe/LayDanhMucLoaiXe'
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
            { data: 'MoTa' },
            { data: 'HangSanXuatXe' },
            { data: 'Model' },
            { data: 'MayChayDau' },
            { data: 'MayChayXang' },
            { data: 'SoGhe' },
            { data: 'LoaiGhe' },
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
            , info: '_START_ - _END_ (tổng _TOTAL_ dòng)'
            , infoEmpty: 'Không có dữ liệu'
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
        $('#MoTa').val(row.MoTa);
        $('#HangSanXuatXeKey').val(row.HangSanXuatXeKey).change();
        $('#Model').val(row.Model);
        $('#MayChayDau').prop('checked', row.MayChayDau);
        $('#MayChayXang').prop('checked', row.MayChayXang);
        $('#SoGhe').val(row.SoGhe);
        $('#LoaiGheKey').val(row.LoaiGheKey).change();
        $('#GhiChu').val(row.GhiChu);
    });//EndFunction

    //_______________________________________________
    $('#dtSource').on('click', 'a.delete', function (e) {
        e.preventDefault();
        var row = $('#dtSource').DataTable().data()[$('#dtSource').DataTable().row('.selected')[0][0]];
        $.ajax({
            type: "POST",
            //url: '@Url.Action("XoaDanhMucLoaiXe", "DanhMucXe")',
            url: "/DanhMucXe/XoaDanhMucLoaiXe",
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

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
function KhoiTaoDuLieuComboBox() {

    //$("#HangSanXuatXeKey").append("<option  value='0' disabled='disabled'>Chọn hãng sản xuất xe</option>");
    //$('#HangSanXuatXeKey').val(0);
    //===================================================
    $.ajax({
        url: '/DanhMucXe/LayHangSanXuatXeChoSelect',
        dataType: "JSON",
        success: function (response) {
            $("#HangSanXuatXeKey").empty();
            $('#HangSanXuatXeKey').append("<option  value='0' disabled='disabled' selected='selected'>Chọn hãng sản xuất xe</option>");
            if (response != null) {
                $.each(response, function (index, OptionItem) {
                    $('#HangSanXuatXeKey').append("<option  value=" + OptionItem.id + " >" + OptionItem.text + "</option>");
                });
            }
            $("#HangSanXuatXeKey").val(null).trigger("change");
            $('#HangSanXuatXeKey').val(0);
        },
        failure: function (msg) {
        }
    });//EndLoadDataForLoaiGheSelector

    //===================================================
    $.ajax({
        url: '/DanhMucXe/LayDanhMucLoaiGhe',
        dataType: "JSON",
        success: function (response) {
            $("#LoaiGheKey").empty();
            $('#LoaiGheKey').append("<option  value='0' disabled='disabled' selected='selected'>Chọn loại ghế</option>");
            if (response != null) {
                $.each(response, function (index, OptionItem) {
                    $('#LoaiGheKey').append("<option  value=" + OptionItem.id + " >" + OptionItem.text + "</option>");
                });
            }
            $("#LoaiGheKey").val(null).trigger("change");
            $('#LoaiGheKey').val(0);
        },
        failure: function (msg) {
        }
    });//EndLoadDataForLoaiGheSelector
}//EndFunction

//Load dữ liệu Danh Mục Hãng Sản Xuất Xe
//===================================================//Thay bằng hàm gộp chung ở trên khi sử dụng layout Metronic.
function LayHangSanXuatXeChoSelect()
{
    $.ajax({
        type: "POST",
        //url: '@Url.Action("LayHangSanXuatXeChoSelect", "DanhMucXe")',
        url: '/DanhMucXe/LayHangSanXuatXeChoSelect',
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: function (response) {
            $("#HangSanXuatXeKey").select2({
                data: response
                , placeholder: "Chọn hãng sản xuất xe"
                , allowClear: true
            });
            $("#HangSanXuatXeKey").val(null).trigger("change");
        },
        failure: function (msg) {
        }
    });//EndLoadDataForHangSanXuatXeSelector
}//EndFunction

//Load dữ liệu Danh Mục Loai Ghế
//===================================================//Thay bằng hàm gộp chung ở trên khi sử dụng layout Metronic.
function LayDanhMucLoaiGhe() {
    
    $.ajax({
        type: "POST",
        //url: '@Url.Action("LayDanhMucLoaiGhe", "DanhMucXe")',
        url: '/DanhMucXe/LayDanhMucLoaiGhe',
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        success: function (response) {
            $("#LoaiGheKey").select2({
                data: response
                , placeholder: "Chọn loại ghế"
                , allowClear: true
            });
            $("#LoaiGheKey").val(null).trigger("change");
        },
        failure: function (msg) {
        }
    });//EndLoadDataForLoaiGheSelector
}//EndFunction

//===================================================
jQuery(function ($) {

    //_______________________________________________
    $(".touchspin3").TouchSpin({
        verticalbuttons: true,
        verticalupclass: 'glyphicon glyphicon-plus',
        verticaldownclass: 'glyphicon glyphicon-minus',
        min: 2,
        max: 50,
        initval: 2
    });

    CauHinhBangDuLieu();

    //LayHangSanXuatXeChoSelect();
    //LayDanhMucLoaiGhe();

    KhoiTaoDuLieuComboBox();
});//EndFunction$

//===================================================
function onSaveClick() {
    if (($('#Key').val() == -1 || $('#Key').val() == "")
        && ($('#Ten').val() == "" || $('#MoTa').val() == "" ||
        $('#HangSanXuatXeKey').val() == "" || $('#Model').val() == "" ||
         $('#SoGhe').val() == "" || $('#LoaiGheKey').val() == "")) {
        toastr.error("Vui lòng nhập đủ thông tin !", "Thông báo !");
        return;
    }

    if ($('#Key').val() == "")
        $('#Key').val(-1);

    $.ajax({
        type: "POST",
        //url: '@Url.Action("LuuDanhMucLoaiXe", "DanhMucXe")',
        url: '/DanhMucXe/LuuDanhMucLoaiXe',
        data: "{ \"Key\" : \"" + $('#Key').val()
            + "\",\"ten\" : \"" + $('#Ten').val()
            + "\",\"moTa\" : \"" + $('#MoTa').val()
            + "\",\"hangSanXuatXeKey\" : \"" + $('#HangSanXuatXeKey').val()
            + "\",\"model\" : \"" + $('#Model').val()
            + "\",\"mayChayDau\" : \"" + document.getElementById('MayChayDau').checked
            + "\",\"mayChayXang\" : \"" + document.getElementById('MayChayXang').checked
            + "\",\"soGhe\" : \"" + $('#SoGhe').val()
            + "\",\"loaiGheKey\" : \"" + $('#LoaiGheKey').val()
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
    $('#MoTa').val("");
    $('#HangSanXuatXeKey').val("");
    $('#Model').val("");
    $('#MayChayDau').prop('checked', false);
    $('#MayChayXang').prop('checked', true);
    $('#SoGhe').val("2");
    $('#LoaiGheKey').val("");
    $('#GhiChu').val("");
}//EndFunction