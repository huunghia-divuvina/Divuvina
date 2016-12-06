jQuery(function ($) {
    //Load dữ liệu Danh Mục Hãng sảng xuất xe
    //===================================================
    $.ajax({
        //type: "POST",
        //url: '@Url.Action("LayHangSanXuatXeChoSelect", "QuanLyXe")',
        //contentType: "application/json; charset=utf-8",
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

    $('#HangSanXuatXeKey').change(function () {
        var id = $(this).val();
        //Load dữ liệu Danh mục loai xe
        if (id != null) {
            //var url = '@Url.Action("LayLoaiXeChoSelect", "QuanLyXe")';
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
                    $('#tableThongTinXe').DataTable().ajax.reload();
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

    $('#btNew').on('click', function (e) {
        e.preventDefault();
        $('#XeKey').val('');
        $('#HangSanXuatXeKey').change();
        $('#LoaiXeKey').change();
        $('#KeyLoaiXe').val('');
        $('#BangSoXe').val('');
        $('#SoSan').val('');
        $('#Mau').val('');
        $('#NgayCapPhep').val(Date);
        $('#CoWifi').prop('checked', true);
        $('#CoTivi').prop('checked', true);
        $('#CoCameraHanhTrinh').prop('CoCameraHanhTrinh', true);
        $('#hdCoWifi').attr("value", true);
        $('#hdCoTivi').attr("value", true);
        $('#hdCoCameraHanhTrinh').attr("value", true);

        $('#GhiChuThongTinXe').val('');
        $('#GiaMua').val(0);
        $('#TongTienKhauHao').val(0);
        $('#SoThangKhauHao').val(12);
        $('#TienKhauHaoHangThang').val(0);
        $('#NgayBatDauKhauHao').val(Date);
        $('#NgayKetThucKhauHao').val(Date);
        $('#GhiChuKhauHaoXe').val('');
    });//EndFunction

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
            }
            , {
                data: null,
                defaultContent: '<a class="edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a>',
                orderable: false
            }
            , {
                data: null,
                defaultContent: '<a class="delete"><i class="fa fa-trash" aria-hidden="true"></i> Xóa</a>',
                orderable: false
            }
            , { data: 'XeKey', visible: false }
            , { data: 'HangSanXuatXeKey', visible: false }
            , { data: 'LoaiXeKey', visible: false }
            , { data: 'BangSoXe' }
            , { data: 'SoSan' }
            , { data: 'LoaiXe' }
            , { data: 'HangSanXuatXe' }
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
            , { data: 'GiaMua', render: $.fn.dataTable.render.number(',', '.', 0, '', ' VNĐ') }
            , { data: 'TongTienKhauHao', render: $.fn.dataTable.render.number(',', '.', 0, '', ' VNĐ') }
            , { data: 'SoThangKhauHao' }
            , { data: 'TienKhauHaoHangThang', render: $.fn.dataTable.render.number(',', '.', 0, '', ' VNĐ') }
            , {
                data: 'NgayBatDauKhauHao'
                , render: function (data, type, full, meta) {
                    if (full != null && full.NgayBatDauKhauHao != null)
                    {
                        return formatDateToString(full.NgayBatDauKhauHao, 'DD/MM/YYYY');
                    }
                    return '';
                }//EndRender
            }
            , {
                data: 'NgayKetThucKhauHao'
                , render: function (data, type, full, meta) {
                    if (full != null && full.NgayKetThucKhauHao != null) {
                        return formatDateToString(full.NgayKetThucKhauHao, 'DD/MM/YYYY');
                        //var date = eval(("new " + full.NgayKetThucKhauHao).replace(/\//g, ""));
                        //return date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
                    }
                    return '';
                }//EndRender
            }
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
                , render: function (data, type, full, meta) 
                {
                    if (full != null && full.CoTivi != null) {
                        if (full.CoTivi) return "Có";
                        return "Không";
                    }
                    return 'Không';
                }//EndRender 
            }
            , { data: 'CoCameraHanhTrinh'
                , render: function (data, type, full, meta) {
                    if (full != null && full.CoCameraHanhTrinh != null) {
                        if (full.CoCameraHanhTrinh) return "Có";
                    return "Không";
                    }
                return 'Không';
                }//EndRender 
            }
            , { data: 'GhiChuThongTinXe' }
            , { data: 'GhiChuKhauHaoXe' }
            
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

    //===================================================
    $('#tableThongTinXe').on('click', 'a.edit', function (e) {
        var row = $('#tableThongTinXe').DataTable().data()[$('#tableThongTinXe').DataTable().row('.selected')[0][0]];
        $('#XeKey').val(row.XeKey);
        $('#HangSanXuatXeKey').val(row.HangSanXuatXeKey).change();
        //$('#LoaiXeKey').val(row.LoaiXeKey).change();
        $('#KeyLoaiXe').val(row.LoaiXeKey);
        $('#BangSoXe').val(row.BangSoXe);
        $('#SoSan').val(row.SoSan);
        $('#Mau').val(row.Mau);
        var ngayCapPhep = eval(("new " + row.NgayCapPhep).replace(/\//g, ""));
        $('#NgayCapPhep').val(ngayCapPhep.getDate() + "/" + (ngayCapPhep.getMonth() + 1) + "/" + ngayCapPhep.getFullYear());
        $('#CoWifi').prop('checked', row.CoWifi);
        $('#CoTivi').prop('checked', row.CoTivi);
        $('#CoCameraHanhTrinh').prop('CoCameraHanhTrinh', row.CoCameraHanhTrinh);
        $('#hdCoWifi').attr("value", row.CoWifi);
        $('#hdCoTivi').attr("value", row.CoTivi);
        $('#hdCoCameraHanhTrinh').attr("value", row.CoCameraHanhTrinh);

        $('#GhiChuThongTinXe').val(row.GhiChuThongTinXe);
        $('#GiaMua').val(row.GiaMua);
        $('#TongTienKhauHao').val(row.TongTienKhauHao);
        $('#SoThangKhauHao').val(row.SoThangKhauHao);
        $('#TienKhauHaoHangThang').val(row.TienKhauHaoHangThang);
        var ngayBatDauKhauHao = eval(("new " + row.NgayBatDauKhauHao).replace(/\//g, ""));
        $('#NgayBatDauKhauHao').val(ngayBatDauKhauHao.getDate() + "/" + (ngayBatDauKhauHao.getMonth() + 1) + "/" + ngayBatDauKhauHao.getFullYear());
        var ngayKetThucKhauHao = eval(("new " + row.NgayKetThucKhauHao).replace(/\//g, ""));
        $('#NgayKetThucKhauHao').val(ngayKetThucKhauHao.getDate() + "/" + (ngayKetThucKhauHao.getMonth() + 1) + "/" + ngayKetThucKhauHao.getFullYear());
        $('#GhiChuKhauHaoXe').val(row.GhiChuKhauHaoXe);
    });//EndFunction

    //===================================================
    $('#tableThongTinXe').on('click', 'a.delete', function (e) {
        var row = $('#tableThongTinXe').DataTable().data()[$('#tableThongTinXe').DataTable().row('.selected')[0][0]];
        $.ajax({
            type: "POST",
            dataType: "JSON",
            contentType: "application/json; charset=utf-8",
            url: '/QuanLyXe/XoaThongTinXeVaKhauHao',
            data: { xeKey : row.XeKey},
            success: function (response) {
                $('#tableThongTinXe').DataTable().ajax.reload();
                onNewClick();
                ShowMessage(response);
            },
            failure: function (msg) {
                $('#output').text(msg);
            }
        });
    });//EndFunction
});//EndFunction$