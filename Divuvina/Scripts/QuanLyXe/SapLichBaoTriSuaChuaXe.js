// Start Declare GLOBAL VARIABLES.
//===================================================
var tableXeChuaSapLich = null;
var tableXeChoSapLich = null;

var listThongTinXeChuaSapLich = [];
var listThongTinXeChoSapLich = [];

// End Declare GLOBAL VARIABLES.
//___________________________________________________

// Start Declare functions.
//===================================================
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
function KhoiTaoDuLieuComboBox() {

    $("#LoaiXeKey").append("<option  value='0' disabled='disabled'>Chọn loại xe</option>");
    $('#LoaiXeKey').val(0);
    //===================================================
    $.ajax({
        url: '/QuanLyXe/LayHangSanXuatXeChoSelect',
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
    $('#HangSanXuatXeKey').change(function () {
        var id = $(this).val();
        //Load dữ liệu Danh mục loai xe
        if (id != null) {
            var url = '/QuanLyXe/LayLoaiXeChoSelect';
            $.getJSON(url, { hangSanXuatXeKey: id }, function (data) {
                $('#LoaiXeKey').empty();
                $("#LoaiXeKey").append("<option  value='0' disabled='disabled' selected='selected'>Chọn loại xe</option>");
                if (data != null) {
                    $.each(data, function (index, OptionItem) {
                        $('#LoaiXeKey').append("<option  value=" + OptionItem.id + " >" + OptionItem.text + "</option>");
                    });
                }
                $("#LoaiXeKey").val(null).trigger("change");
                $('#KeyLoaiXe').val($('#LoaiXeKey').val()).change();
                $('#LoaiXeKey').val(0);
            });
        }
    });

    //===================================================
    $.ajax({
        url: '/QuanLyXe/LayNoiSuaChuaXeChoSelect',
        dataType: "JSON",
        success: function (response) {
            $("#NoiSuaChuaXeKey").empty();
            $('#NoiSuaChuaXeKey').append("<option  value='0' disabled='disabled' selected='selected'>Chọn nơi sửa chữa</option>");
            if (response != null) {
                $.each(response, function (index, OptionItem) {
                    $('#NoiSuaChuaXeKey').append("<option  value=" + OptionItem.id + " >" + OptionItem.text + "</option>");
                });
            }
            $("#NoiSuaChuaXeKey").val(null).trigger("change");
            $('#NoiSuaChuaXeKey').val(0);
        },
        failure: function (msg) {
        }
    });//EndLoadDataForLoaiGheSelector
}//EndFunction
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
function InitBangXeChuaSapLich() {
    var tableName = '#tableXeChuaSapLich';
    var table = $(tableName);
    //_______________________________________________
    table.dataTable({
        language: {
            aria: {
                //"sortAscending": ": activate to sort column ascending",
                //"sortDescending": ": activate to sort column descending"
                sortAscending: ": kích hoạt để sắp xếp cột tăng dần",
                sortDescending: ": kích hoạt để sắp xếp cột giảm dần"
            },
            emptyTable: "Không có dữ liệu",
            //info: "Từ dòng _START_ đến _END_ trong tổng _TOTAL_ dòng",
            //info: "_START_ - _END_ (tổng _TOTAL_ dòng)",
            info: "",
            //infoEmpty: "Không có dữ liệu",
            infoEmpty: "",
            infoFiltered: "(Tìm kiếm từ _MAX_ tổng sổ dòng)",
            //lengthMenu: "Hiển thị _MENU_ dòng",
            lengthMenu: "Hiển thị _MENU_",
            search: "Tìm kiếm",
            processing: "Đang xử lý...",
            zeroRecords: "Không có dữ liệu",
            paginate: {
                "previous": "Trước",
                "next": "Sau",
                "last": "Trang cuối",
                "first": "Trang đầu"
            }
        },
        bStateSave: true, // save datatable state(pagination, sort, etc) in cookie.
        bProcessing: false,
        bFilter: false, // Show/hide search.
        bLengthChange: true, // Show/hide Entries dropdown.
        lengthMenu: [
            [5, 15, 20, -1],
            [5, 15, 20, "All"] // change per page values here
        ],
        // set the initial value
        scrollY: 300,
        paging: false,
        //pageLength: 5,
        //pagingType: "bootstrap_full_number", //numbers, simple, simple_numbers, full, full_numbers, first_last_numbers
        //ordering: false,
        columns: [
            //{
            //    //Index Column.
            //    data: null,
            //    searchable: false
            //    , orderable: false
            //    , targets: 0
            //},
            {
                orderable: false,
                targets: [0],
                data: null,
                defaultContent: '<label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes"/><span></span></label>'
            }
            , { data: 'XeKey', className: 'XeKey', visible: false }
            , { data: 'BangSoXe' }
            , { data: 'SoSan' }
            , { data: 'NgayCapPhep'
                , className: 'center'
                , render: function (data, type, full, meta) {
                    if (full != null && full.NgayCapPhep != null) {
                        return formatDateToString(full.NgayCapPhep, 'DD/MM/YYYY');
                    }
                    return '';
                }//EndRender
            }
            , { data: 'Mau', visible: false }
            , { data: 'CoWifi'
                , visible: false
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoWifi != null) {
                        if (full.CoWifi) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender
            }
            , { data: 'CoTivi'
                , visible: false
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoTivi != null) {
                        if (full.CoTivi) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender 
            }
            , { data: 'CoCameraHanhTrinh'
                , visible: false
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoCameraHanhTrinh != null) {
                        if (full.CoCameraHanhTrinh) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender 
            }
            , { data: 'GhiChu', visible: false }
            , { data: 'TenLoaiXe' }
            , { data: 'TenHangSanXuatXe' }

        ],//EndColumns
        order: [
            [1, "asc"]
        ] // set first column as a default sort by asc
    });
    //_______________________________________________
    table.find('.group-checkable').change(function () {
        var set = jQuery(this).attr("data-set");
        var checked = jQuery(this).is(":checked");
        jQuery(set).each(function () {
            if (checked) {
                $(this).prop("checked", true);
                $(this).parents('tr').addClass("active");
            } else {
                $(this).prop("checked", false);
                $(this).parents('tr').removeClass("active");
            }
        });
    });
    //_______________________________________________
    table.on('change', 'tbody tr .checkboxes', function () {
        $(this).parents('tr').toggleClass("active");
    });
    //Index columns.
    //_______________________________________________
    //table.on('order.dt search.dt', function () {
    //    tableXeChuaSapLich.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
    //        cell.innerHTML = i + 1;
    //    });
    //}).draw();
    //_______________________________________________
    $(tableName + ' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            tableXeChuaSapLich.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
}//EndFunction
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
function InitBangXeChoSapLich() {
    var tableName = '#tableXeChoSapLich';
    var table = $(tableName);
    //_______________________________________________
    table.dataTable({
        language: {
            aria: {
                //"sortAscending": ": activate to sort column ascending",
                //"sortDescending": ": activate to sort column descending"
                sortAscending: ": kích hoạt để sắp xếp cột tăng dần",
                sortDescending: ": kích hoạt để sắp xếp cột giảm dần"
            },
            emptyTable: "Không có dữ liệu",
            //info: "Từ dòng _START_ đến _END_ trong tổng _TOTAL_ dòng",
            //info: "_START_ - _END_ (tổng _TOTAL_ dòng)",
            info: "",
            //infoEmpty: "Không có dữ liệu nào được tìm thấy",
            infoEmpty: "",
            infoFiltered: "(Tìm kiếm từ _MAX_ tổng sổ dòng)",
            lengthMenu: "Hiển thị _MENU_",
            search: "Tìm kiếm",
            processing: "Đang xử lý...",
            zeroRecords: "Không có dữ liệu",
            paginate: {
                "previous": "Trước",
                "next": "Sau",
                "last": "Trang cuối",
                "first": "Trang đầu"
            }
        },
        bStateSave: true, // save datatable state(pagination, sort, etc) in cookie.
        bProcessing: false,
        bFilter: false, // Show/hide search.
        bLengthChange: true, // Show/hide Entries dropdown.
        lengthMenu: [
            [5, 15, 20, -1],
            [5, 15, 20, "All"] // change per page values here
        ],
        // set the initial value
        scrollY: 300,
        paging: false,
        //pageLength: 5,
        //pagingType: "bootstrap_full_number",
        //ordering: false,
        columns: [
            //{
            //    //Index Column.
            //    data: null,
            //    searchable: false
            //    , orderable: false
            //    , targets: 0
            //},
            {
                orderable: false,
                targets: [0],
                data: null,
                defaultContent: '<label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes"/><span></span></label>'
            }
            , { data: 'XeKey', visible: false }
            , { data: 'BangSoXe' }
            , { data: 'SoSan' }
            , {
                data: 'NgayCapPhep'
                , className: 'center'
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
                , visible: false
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
                , visible: false
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
                , visible: false
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoCameraHanhTrinh != null) {
                        if (full.CoCameraHanhTrinh) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender 
            }
            , { data: 'GhiChu', visible: false }
            , { data: 'TenLoaiXe' }
            , { data: 'TenHangSanXuatXe' }

        ],//EndColumns
        order: [
            [1, "asc"]
        ] // set first column as a default sort by asc
    });
    //_______________________________________________
    table.find('.group-checkable').change(function () {
        var set = jQuery(this).attr("data-set");
        var checked = jQuery(this).is(":checked");
        jQuery(set).each(function () {
            if (checked) {
                $(this).prop("checked", true);
                $(this).parents('tr').addClass("active");
            } else {
                $(this).prop("checked", false);
                $(this).parents('tr').removeClass("active");
            }
        });
    });
    //_______________________________________________
    table.on('change', 'tbody tr .checkboxes', function () {
        $(this).parents('tr').toggleClass("active");
    });
    //Index columns.
    //_______________________________________________
    //table.on('order.dt search.dt', function () {
    //    tableXeChuaSapLich.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
    //        cell.innerHTML = i + 1;
    //    });
    //}).draw();
    //_______________________________________________
    $(tableName + ' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            tableXeChuaSapLich.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
}//EndFunction

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
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
        success: function (ListXeChuaSapLich) {
            //---------------------------
            if (listThongTinXeChuaSapLich != null) {
                listThongTinXeChuaSapLich = [];
                listThongTinXeChuaSapLich.length = 0;
            }
            if (ListXeChuaSapLich != null) {
                $.each(ListXeChuaSapLich, function (index, value) {
                    listThongTinXeChuaSapLich.push(value);
                });
            }
            //---------------------------
            tableXeChuaSapLich = $("#tableXeChuaSapLich").DataTable();
            tableXeChuaSapLich.clear().draw();
            tableXeChuaSapLich.rows.add(listThongTinXeChuaSapLich);
            tableXeChuaSapLich.columns.adjust().draw();
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

}//EndFunction

// End Declare functions.
//___________________________________________________


// Start Declare the events of controls.
//===================================================
$("#ckNgayCapPhep").on('click', function (e) {
    if (this.checked) {
        $("#divNgayCapPhep :input").attr("disabled",false);
    }
    else {
        $("#divNgayCapPhep :input").attr("disabled", true);
    }
});
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$("#btTimThongTinXe").on('click', function (e) {
    e.preventDefault();
    
    GetThongTinXeChuaSapLich();
});
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$("#btChuyenSapLich").on('click', function (e) {
    tableXeChuaSapLich = $("#tableXeChuaSapLich").DataTable();
    listThongTinXeChuaSapLich = tableXeChuaSapLich.rows().data();
    
    //Cach 1
    //---------------------------
    //listThongTinXeChoSapLich = [];
    //$('#tableXeChuaSapLich').DataTable()
    //tableXeChuaSapLich.rows().iterator('row', function (context, index) {
    //    var node = $(this.row(index).node());
    //    if (node.hasClass("active")) {
    //        listThongTinXeChoSapLich.push(listThongTinXeChuaSapLich[index]);
    //    }
    //});

    //Cach 2
    //---------------------------
    if (listThongTinXeChoSapLich == null) listThongTinXeChoSapLich = [];
    tableXeChuaSapLich.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var thongTinChoSapLich = JSON.stringify(this.data());
        var node = $(this.row(rowIdx).node());
        if (node.hasClass("active")) {

            for (var i = 0; i < listThongTinXeChuaSapLich.length; i++) {
                var thongTinChuaSapLich = JSON.stringify(listThongTinXeChuaSapLich[i]);
                if (thongTinChuaSapLich == thongTinChoSapLich) {
                    listThongTinXeChoSapLich.push(listThongTinXeChuaSapLich[i]);
                    listThongTinXeChuaSapLich.splice(i, 1);
                    break;
                }
            }
        }
    });

    //---------------------------
    tableXeChoSapLich = $("#tableXeChoSapLich").DataTable();
    tableXeChoSapLich.clear().draw();
    tableXeChoSapLich.rows.add(listThongTinXeChoSapLich);
    tableXeChoSapLich.columns.adjust().draw();

    //---------------------------
    tableXeChuaSapLich = $("#tableXeChuaSapLich").DataTable();
    tableXeChuaSapLich.clear().draw();
    tableXeChuaSapLich.rows.add(listThongTinXeChuaSapLich);
    tableXeChuaSapLich.columns.adjust().draw();
});
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$("#btHuySapLich").on('click', function (e) {
    tableXeChoSapLich = $("#tableXeChoSapLich").DataTable();
    listThongTinXeChoSapLich = tableXeChoSapLich.rows().data();

    //---------------------------
    if (listThongTinXeChuaSapLich == null) listThongTinXeChuaSapLich = [];
    tableXeChoSapLich.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var thongTinChuaSapLich = JSON.stringify(this.data());
        var node = $(this.row(rowIdx).node());
        if (node.hasClass("active")) {

            for (var i = 0; i < listThongTinXeChoSapLich.length; i++) {
                var thongTinChoSapLich = JSON.stringify(listThongTinXeChoSapLich[i]);
                if (thongTinChuaSapLich == thongTinChoSapLich) {
                    listThongTinXeChuaSapLich.push(listThongTinXeChoSapLich[i]);
                    listThongTinXeChoSapLich.splice(i, 1);
                    break;
                }
            }
        }
    });

    //---------------------------
    tableXeChoSapLich = $("#tableXeChoSapLich").DataTable();
    tableXeChoSapLich.clear().draw();
    tableXeChoSapLich.rows.add(listThongTinXeChoSapLich);
    tableXeChoSapLich.columns.adjust().draw();

    //---------------------------
    tableXeChuaSapLich = $("#tableXeChuaSapLich").DataTable();
    tableXeChuaSapLich.clear().draw();
    tableXeChuaSapLich.rows.add(listThongTinXeChuaSapLich);
    tableXeChuaSapLich.columns.adjust().draw();
});
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$("#btLuu").on('click', function (e) {
    e.preventDefault();

    //---------------------------
    var noiSuaChuaXeKey = $("#NoiSuaChuaXeKey").val();
    if (noiSuaChuaXeKey == undefined || noiSuaChuaXeKey == null || noiSuaChuaXeKey <= 0)
    {
        ShowMessageFailure("Bạn chưa chọn nơi sửa chữa.");
        document.getElementById("NoiSuaChuaXeKey").focus();
        return;
    }
    //---------------------------
    var ngaySapLich = $("#NgaySapLich").val();
    if (ngaySapLich == undefined || ngaySapLich == null || ngaySapLich < new Date()) {
        ShowMessageFailure("Bạn chưa chọn ngày sắp lịch sửa chữa.");
        document.getElementById("NgaySapLich").focus();
        return;
    }
    //---------------------------
    var danhSachXeChuaSapLich = $("#tableXeChuaSapLich").DataTable().rows().data();
    var danhSachXeChoSapLich = $("#tableXeChoSapLich").DataTable().rows().data();
    //---------------------------
    listThongTinXeChuaSapLich = [];
    for (var i = 0; i < danhSachXeChuaSapLich.length; i++) {
        listThongTinXeChuaSapLich.push(danhSachXeChuaSapLich[i]);
    }
    //var jsonThongTinXeChuaSapLich = JSON.parse(JSON.stringify(listThongTinXeChuaSapLich));
    //---------------------------
    listThongTinXeChoSapLich = [];
    for (var i = 0; i < danhSachXeChoSapLich.length; i++) {
        listThongTinXeChoSapLich.push(danhSachXeChoSapLich[i]);
    }
    //---------------------------Test
    //var dataThongTinSapLichBaoTri = JSON.stringify({ 'noiSuaChuaXeKey': noiSuaChuaXeKey, 'ngaySapLich': ngaySapLich, 'ghiChu': '', 'listThongTinXeChuaSapLich': listThongTinXeChuaSapLich, 'listThongTinXeChoSapLich': listThongTinXeChoSapLich });
    //var dataThongTinSapLichBaoTri = JSON.stringify({ 'model': $('#formTimXeSapLich').serialize(), 'listThongTinXeChuaSapLich': listThongTinXeChuaSapLich, 'listThongTinXeChoSapLich': listThongTinXeChoSapLich });
    //---------------------------

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/QuanLyXe/SaveThongTinSapLichBaoTri',
        async: false,
        //data: JSON.stringify({ 'model': $('#formTimXeSapLich').serialize(), 'listThongTinXeChuaSapLich': listThongTinXeChuaSapLich, 'listThongTinXeChoSapLich': listThongTinXeChoSapLich }),
        data: JSON.stringify({ 'noiSuaChuaXeKey': noiSuaChuaXeKey, 'ngaySapLich': ngaySapLich, 'ghiChu': '', 'listThongTinXeChuaSapLich': listThongTinXeChuaSapLich, 'listThongTinXeChoSapLich': listThongTinXeChoSapLich }),
        cache: false,
        success: function () {
            ShowMessage("Bạn chưa chọn ngày sắp lịch sửa chữa.", "Sắp lịch bảo trì sửa chữa xe", "success");
        },
        failure: function (response) {
            ShowMessageFailure("Bạn chưa chọn ngày sắp lịch sửa chữa.");
        }
    });
});
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

// End Declare the events of controls.
//___________________________________________________


// Start Declare function document ready.
//===================================================
jQuery(function ($) {

    $('#ckNgayCapPhep').attr("checked", true);
    //----------------------------
    KhoiTaoDuLieuComboBox();

    //----------------------------
    Initdatepicker();

    //----------------------------
    InitBangXeChuaSapLich();
    InitBangXeChoSapLich();
    GetThongTinXeChuaSapLich();
    //----------------------------


});//EndFunction$

// End Declare function document ready.
//___________________________________________________
