
//===================================================
function KhoiTaoDuLieuComboBox() {
    //Load dữ liệu Danh Mục Hãng sảng xuất xe
    //===================================================
    $.ajax({
        url: '/QuanLyXe/LayHangSanXuatXeChoSelect',
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
    });//EndLoadDataForLoaiGheSelector

    $("#LoaiXeKey").select2({
        placeholder: "Chọn loại xe"
    });

    //===================================================
    $('#HangSanXuatXeKey').change(function () {
        var id = $(this).val();
        //Load dữ liệu Danh mục loai xe
        if (id != null) {
            var url = '/QuanLyXe/LayLoaiXeChoSelect';
            $.getJSON(url, { hangSanXuatXeKey: id }, function (data) {
                $('#LoaiXeKey').empty();
                $("#LoaiXeKey").select2({
                    data: data
                , placeholder: "Chọn loại xe"
                , allowClear: true
                });
                $("#LoaiXeKey").val(null).trigger("change");
                $('#LoaiXeKey').val($('#KeyLoaiXe').val()).change();
            });
        }
    });
}//EndFunction

//===================================================
function GetThongTinXeChuaSapLich() {
    //---------------------------------------------------
    var listThongTinXeChuaSapLich = null;
    //---------------------------------------------------
    var HangSanXuatXeKey = '0';
    var LoaiXeKey = '0';
    var BangSoXe = '';
    var SoSan = '';
    var NgayCapPhep = null;
    if ($('#HangSanXuatXeKey').val() != null && $('#HangSanXuatXeKey').val() != '') HangSanXuatXeKey = $('#HangSanXuatXeKey').val();
    if ($('#LoaiXeKey').val() != null && $('#LoaiXeKey').val() != '') LoaiXeKey = $('#LoaiXeKey').val();
    if ($('#BangSoXe').val() != null && $('#BangSoXe').val() != '') BangSoXe = $('#BangSoXe').val();
    if ($('#SoSan').val() != null && $('#SoSan').val() != '') SoSan = $('#SoSan').val();
    if ($('#NgayCapPhep').val() != null && $('#NgayCapPhep').val() != '') HangSanXuatXeKey = $('#NgayCapPhep').val();
    else NgayCapPhep = "1900-01-01";
    
    //---------------------------------------------------
    $.ajax({
        type: "POST",
        url: '/QuanLyXe/GetThongTinXeChuaSapLich',
        contentType: "application/json; charset=utf-8",
        dataType: "JSON",
        data: "{ \"HangSanXuatXeKey\" : \"" + HangSanXuatXeKey
                        + "\",\"LoaiXeKey\" : \"" + LoaiXeKey
                        + "\",\"BangSoXe\" : \"" + BangSoXe
                        + "\",\"SoSan\" : \"" + SoSan
                        + "\",\"NgayCapPhep\" : \"" + NgayCapPhep
                        + "\" }",
        cache: false,
        success: function (data) {
            listThongTinXeChuaSapLich = data;
        }
    });

    return listThongTinXeChuaSapLich;
}
//===================================================
function CauHinhBangDuLieuXeChuaSapLich()
{
    var tableName = '#tableXeChuaSapLich';
    //---------------------------------------------------
    var HangSanXuatXeKey = '0';
    var LoaiXeKey = '0';
    var BangSoXe = '';
    var SoSan = '';
    var NgayCapPhep = null;
    if ($('#HangSanXuatXeKey').val() != null && $('#HangSanXuatXeKey').val() != '') HangSanXuatXeKey = $('#HangSanXuatXeKey').val();
    if ($('#LoaiXeKey').val() != null && $('#LoaiXeKey').val() != '') LoaiXeKey = $('#LoaiXeKey').val();
    if ($('#BangSoXe').val() != null && $('#BangSoXe').val() != '') BangSoXe = $('#BangSoXe').val();
    if ($('#SoSan').val() != null && $('#SoSan').val() != '') SoSan = $('#SoSan').val();
    //if ($('#NgayCapPhep').val() != null && $('#NgayCapPhep').val() != '') HangSanXuatXeKey = $('#NgayCapPhep').val();
    //---------------------------------------------------
    //var listThongTinXeChuaSapLich = 
    //---------------------------------------------------
    var table = $(tableName).DataTable({
        
        ajax: {
            url: '/QuanLyXe/GetThongTinXeChuaSapLich',
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            data: "{ \"HangSanXuatXeKey\" : \"" + HangSanXuatXeKey
                            + "\",\"LoaiXeKey\" : \"" + LoaiXeKey
                            + "\",\"BangSoXe\" : \"" + BangSoXe
                            + "\",\"SoSan\" : \"" + SoSan
                            + "\",\"NgayCapPhep\" : \"" + NgayCapPhep
                            + "\" }",
            dataSrc: ''
        }
        , columns: [
            {
                //Index Column.
                data: null,
                searchable: false
                , orderable: false
                , targets: 0
            }
            , {
                className: 'details-control',
                orderable: false,
                data: null,
                defaultContent: '<div class="checkbox checkbox-primary"><input type="checkbox" id="XeDuocChon" value="XeDuocChon" checked="" aria-label="Single checkbox Two"><label></label></div>'
            }
            , { data: 'XeKey', visible: false }
            , { data: 'BangSoXe' }
            , { data: 'SoSan' }
            , {
                data: 'NgayCapPhep'
                , render: function (data, type, full, meta) {
                    if (full != null && full.NgayCapPhep != null) {
                        return formatDateToString(full.NgayCapPhep, 'DD/MM/YYYY');
                    }
                    return '';
                }//EndRender
            }
            , { data: 'Mau' }
            , {
                data: 'CoWifi'
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoWifi != null) {
                        if (full.CoWifi) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender
            }
            , {
                data: 'CoTivi'
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoTivi != null) {
                        if (full.CoTivi) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender 
            }
            , {
                data: 'CoCameraHanhTrinh'
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoCameraHanhTrinh != null) {
                        if (full.CoCameraHanhTrinh) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender 
            }
            , { data: 'GhiChu' }
            , { data: 'TenLoaiXe' }
            , { data: 'TenHangSanXuatXe' }

        ]//EndColumns
        , order: [5, 'asc']
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

    //Index columns.
    //_______________________________________________
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //_______________________________________________
    $(tableName+' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    
}//EndFunction
//===================================================

//===================================================
jQuery(function ($) {

    //_______________________________________________
    KhoiTaoDuLieuComboBox();
    
    //_______________________________________________
    SetDateForDatepicker('NgayCapPhep', new Date());

    //_______________________________________________
    GetThongTinXeChuaSapLich();

});//EndFunction$