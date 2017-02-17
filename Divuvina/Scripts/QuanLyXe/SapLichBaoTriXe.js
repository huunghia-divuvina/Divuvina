﻿var tableXeChuaSapLich = null;
var tableXeChoSapLich = null;
var listThongTinXeChuaSapLich = null;
var listThongTinXeChoSapLich = null;

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
    $.ajax({
        type: "POST",
        dataType: "JSON",
        url: '/QuanLyXe/GetThongTinXeChuaSapLich',
        //---------------------------
        //=> Không mở đoạn code này. Vì mở đoạn code này sẽ không truyền được toàn bộ dữ liệu từ Form lên Controller
        //Phần gắng thuộc tính từ model đến selector control không truyền được.
        //contentType: "application/json; charset=utf-8", 
        //---------------------------
        data: $('#formTimXeSapLich').serialize(),
        async: true,
        processData: false,
        cache: false,
        success: function (result) {
            //---------------------------
            //if (listThongTinXeChoSapLich == null) KhoiTaoDuLieuComboBox();
            if (result != null && result.ListXeChuaSapLich != null) listThongTinXeChuaSapLich = result.ListXeChuaSapLich;
            return listThongTinXeChuaSapLich;
            //---------------------------
        },
        //---------------------------
        //error: function (xhr, exception) {
        //    if (xhr.status != 0) alert('error');
        //}
        //---------------------------
        error: function (xhr, ajaxOptions, thrownError) {
            //alert(xhr.status);
            //alert(xhr.responseText);
            //alert(thrownError);
            ShowMessageFailure("Tìm danh sách xe chưa sắp lịch không thành công.");
        }
    });

}

//===================================================

//---------------------------------------------------
var dataList = [
{ 'XeKey': 1, 'BangSoXe': 'Hristo Stoichkov', 'SoSan': 'Plovdiv, Bulgaria', 'NgayCapPhep': '20-2-2017', 'TenLoaiXe': 'sdfdsaf', 'TenHangSanXuatXe': 'qerqwerewqr', 'CoWifi': true, 'CoTivi': false, 'CoCameraHanhTrinh': true, 'GhiChu': 'sdfdsg', 'Mau':'Xanh' },
{ 'XeKey': 2, 'BangSoXe': 'dsafsad', 'SoSan': 'dsafsaf', 'NgayCapPhep': '2017-01-20', 'TenLoaiXe': 'sdfdsaf', 'TenHangSanXuatXe': 'qerqwerewqr', 'CoWifi': true, 'CoTivi': false, 'CoCameraHanhTrinh': true, 'GhiChu': 'sdfdsg', 'Mau': 'Xanh' },
{ 'XeKey': 3, 'BangSoXe': 'dsafsad', 'SoSan': 'dsafsaf', 'NgayCapPhep': '2017-01-20', 'TenLoaiXe': 'sdfdsaf', 'TenHangSanXuatXe': 'qerqwerewqr', 'CoWifi': false, 'CoTivi': true, 'CoCameraHanhTrinh': false, 'GhiChu': 'sdfdsg', 'Mau': 'Xanh' },
];

//===================================================
function KhoiTaoCauTrucDuLieuBang() {
    //if (listThongTinXeChuaSapLich == null) {
    //    listThongTinXeChuaSapLich = [{
    //        'XeKey': -1, 'BangSoXe': '', 'SoSan': '', 'NgayCapPhep': '', 'TenLoaiXe': '', 'TenHangSanXuatXe': '', 'CoWifi': false, 'CoTivi': false, 'CoCameraHanhTrinh': false, 'GhiChu': '', 'Mau': ''
    //    }];
    //}
    //if (listThongTinXeChoSapLich == null) {
    //    listThongTinXeChoSapLich = [{
    //        'XeKey': -1, 'BangSoXe': '', 'SoSan': '', 'NgayCapPhep': '', 'TenLoaiXe': '', 'TenHangSanXuatXe': '', 'CoWifi': false, 'CoTivi': false, 'CoCameraHanhTrinh': false, 'GhiChu': '', 'Mau': ''
    //    }];
    //}

}
//===================================================
function CauHinhBangDuLieuXeChuaSapLich()
{

    var tableName = '#tableXeChuaSapLich';
    //---------------------------------------------------
    //var listThongTinXeChuaSapLich = GetThongTinXeChuaSapLich();
    //---------------------------------------------------
    tableXeChuaSapLich = $(tableName).DataTable({
        //data: listThongTinXeChuaSapLich
        //data: dataList,
        //ajax: {
        //    url: '/QuanLyXe/GetThongTinXeChuaSapLich',
        //    dataSrc: $('#formTimXeSapLich').serialize()
        //}
        //,
        columns: [
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
            , { data: 'Mau', visible: false }
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
    tableXeChuaSapLich.on('order.dt search.dt', function () {
        tableXeChuaSapLich.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //_______________________________________________
    $(tableName+' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            tableXeChuaSapLich.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    
}//EndFunction
//===================================================
function CauHinhBangDuLieuXeChoSapLich() {
    var tableName = '#tableXeChoSapLich';
    //---------------------------------------------------
    tableXeChoSapLich = $(tableName).DataTable({

        data: listThongTinXeChoSapLich
        ,
        columns: [
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
            //, { data: 'Mau' }
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
    tableXeChoSapLich.on('order.dt search.dt', function () {
        tableXeChoSapLich.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //_______________________________________________
    $(tableName + ' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            tableXeChoSapLich.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });


}//EndFunction
//===================================================

//===================================================
$("#btTimThongTinXe").on('click', function (e) {
    e.preventDefault();
   
    //tableXeChuaSapLich.clear().draw();
    //tableXeChuaSapLich.rows.add(dataList);
    GetThongTinXeChuaSapLich();

    //dataList.clear();

    tableXeChuaSapLich.rows.add(listThongTinXeChuaSapLich);
    tableXeChuaSapLich.columns.adjust().draw();
});

$("#ckTimTheoNgayCapPhep").on('click', function (e) {
    //e.preventDefault();

    if (this.checked) {
        //$("#NgayCapPhep").attr("disable", true);
        $("#TimTheoNgayCapPhep").val(true);
    }
    else {
        //$("#NgayCapPhep").attr("disable", false);
        $("#TimTheoNgayCapPhep").val(false);
    }
});
//===================================================
jQuery(function ($) {

    $('#ckNgayCapPhep').attr("checked", true);
    //_______________________________________________
    KhoiTaoDuLieuComboBox();
    
    //_______________________________________________
    SettingDatepicker('divFrmGrpNgayCapPhep');
    //SetDateForDatepicker('NgayCapPhep', null);

    //_______________________________________________
    KhoiTaoCauTrucDuLieuBang();
    CauHinhBangDuLieuXeChuaSapLich();
    CauHinhBangDuLieuXeChoSapLich();

    //CauHinhBangDuLieuXeChuaSapLich('#tableXeChuaSapLich');
    //CauHinhBangDuLieuXeChuaSapLich('#tableXeChoSapLich');
    //tableXeChuaSapLich.data = dataList;
    //tableXeChoSapLich.data = dataList;

});//EndFunction$