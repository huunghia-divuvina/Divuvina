
//===================================================
function LuuThongTinXe() {
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
        failure: function (message) {
            ShowMessageFailure(message);
            //$('#output').text(msg);
        },
        //----------------------------------
        //error: function (jqXhr, exception) {
        //    ShowMessage(response);
        //    //if (jqXhr.status != 0) ShowMessage(response); //alert('Thực hiện không thành công');
        //}
    });//End ajax
}//EndFunction


//===================================================
function KhoiTaoCheckBoxThietBiTheoXe()
{
    //===================================================
    var coWifi = true;
    if (String("@(Model.CoWifi)") == "False") { coWifi = false };
    var coTivi = true;
    if (String("@(Model.CoTivi)") == "False") { coTivi = false };
    var coCameraHanhTrinh = true;
    if (String("@(Model.CoCameraHanhTrinh)") == "False") { coCameraHanhTrinh = false };
    $('#CoWifi').attr("checked", coWifi);
    $('#CoTivi').attr("checked", coTivi);
    $('#CoCameraHanhTrinh').attr("checked", coCameraHanhTrinh);
    $('#hdCoWifi').val(coWifi);
    $('#hdCoTivi').val(coTivi);
    $('#hdCoCameraHanhTrinh').val(coCameraHanhTrinh);

    //===================================================
    $('#CoWifi').change(function () {
        if (this.checked) {
            $(this).attr("checked", true);
            $('#hdCoWifi').attr("value", true);
        }
        else {
            $(this).attr("checked", false);
            $('#hdCoWifi').attr("value", false);
        }
    });
    $('#CoTivi').change(function () {
        if (this.checked) {
            $(this).attr("checked", true);
            $('#hdCoTivi').attr("value", true);
        }
        else {
            $(this).attr("checked", false);
            $('#hdCoTivi').attr("value", false);
        }
    });
    $('#CoCameraHanhTrinh').change(function () {
        if (this.checked) {
            $(this).attr("checked", true);
            $('#hdCoCameraHanhTrinh').attr("value", true);
        }
        else {
            $(this).attr("checked", false);
            $('#hdCoCameraHanhTrinh').attr("value", false);
        }
    });

}//EndFunction

//===================================================
function KhoiTaoDuLieuComboBox()
{
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

    $("#LoaiXeKey").select2({
        placeholder: "Chọn loại xe"
    });

    //===================================================
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
}//EndFunction

//===================================================
function CauHinhBangDuLieu()
{
    var tableName = '#tableThongTinXe';
    //===================================================
    var table = $(tableName).DataTable({

        ajax: {
            //type: "GET",
            //datatype: "JSON",
            url: '/QuanLyXe/LayThongTinXe',
            //contentType: "application/json; charset=utf-8",
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
                defaultContent: ''
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
            , { data: 'GhiChuThongTinXe' }
            //, { data: 'GhiChuKhauHaoXe' }
            , {
                //Button Edit
                data: null,
                defaultContent: '<a class="edit"><center><i class="glyphicon glyphicon-pencil" aria-hidden="true"></i></center></a>',
                orderable: false
            }
            , {
                //Button Delete
                data: null,
                defaultContent: '<a class="delete"><center><i class="glyphicon glyphicon-trash" aria-hidden="true"></i></center></a>',
                orderable: false
            }
            

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
    //===================================================
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //===================================================
    $(tableName+' tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });

    //===================================================
    $(tableName).on('click', 'a.edit', function (e) {
        e.preventDefault();
        var row = $(tableName).DataTable().data()[$(tableName).DataTable().row('.selected')[0][0]];
        if (row != null) {
            $('#XeKey').val(row.XeKey);
            $(tableName).val(row.HangSanXuatXeKey).change();
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
        }
    });//EndFunction

    //===================================================
    $(tableName).on('click', 'a.delete', function (e) {
        e.preventDefault();
        var row = $(tableName).DataTable().data()[$(tableName).DataTable().row('.selected')[0][0]];
        if (row != null) {
            $('#XeKey').val(row.XeKey);
            $.ajax({
                type: "POST",
                dataType: "JSON",
                contentType: "application/json; charset=utf-8",
                url: '/QuanLyXe/XoaThongTinXeVaKhauHao',
                data: { xeKey: $('#XeKey').val() },
                success: function (response) {
                    $(tableName).DataTable().ajax.reload();
                    onNewClick();
                    ShowMessage(response);
                },
                failure: function (msg) {
                    $('#output').text(msg);
                }
            });
        }
    });//EndFunction

    //Add Child Table.
    //===================================================
    function format(d) {
        // `d` is the original data object for the row
        return '<table class="table table-striped table-bordered"  cellpadding="5" cellspacing="0" border="0" style="padding-left:80px;"  width="100%">' +
            '<tr>' +
                '<td width="30%" height="15px">Tổng tiền khấu hao:</td>' +
                '<td width="70%" height="15px">' + d.TongTienKhauHao + '</td>' +
            '</tr>' +
            '<tr>' +
                '<td width="30%" height="15px">Số tháng khấu hao:</td>' +
                '<td width="70%" height="15px">' + d.SoThangKhauHao + '</td>' +
            '</tr>' +
            '<tr>' +
                '<td width="30%" height="15px">Tiền khấu hao hàng tháng:</td>' +
                '<td width="70%" height="15px">' + d.TienKhauHaoHangThang + '</td>' +
            '</tr>' +
            '<tr>' +
                '<td width="30%" height="15px">Ngày bắt đầu khấu hao:</td>' +
                '<td width="70%" height="15px">' + formatDateToString(d.NgayBatDauKhauHao, 'DD/MM/YYYY') + '</td>' +
            '</tr>' +
            '<tr>' +
                '<td width="30%" height="15px">Ngày kết thúc khấu hao:</td>' +
                '<td width="70%" height="15px">' + formatDateToString(d.NgayKetThucKhauHao, 'DD/MM/YYYY') + '</td>' +
            '</tr>' +
            '<tr>' +
                '<td width="30%" height="15px">Ghi chú khấu hao:</td>' +
                '<td width="70%" height="15px">' + d.GhiChuKhauHaoXe + '</td>' +
            '</tr>' +
        '</table>';
    };

    // Add event listener for opening and closing details
    //===================================================
    $(tableName + ' tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            if (!tr.hasClass('selected')) tr.removeClass('selected');
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
            if (!tr.hasClass('selected')) tr.addClass('selected');
            tr.addClass('shown');
        }
    });
}//EndFunction

//===================================================
function SuKienThayDoiGiaMua_TienChietKhau_SoThangKhauHao()
{
    //Sự kiện thay đổi giá mua xe.
    //===================================================
    $('#GiaMua').change(function () {

        var stringGiaMua = $('#GiaMua').val();
        var giaMua = convertStringWithCommasToNumber(stringGiaMua,true);
        stringGiaMua = addThousandSeperator(giaMua,false);
        $('#GiaMua').val(stringGiaMua);
        $('#TongTienKhauHao').val(stringGiaMua);

        var soThangKhauHao = $('#SoThangKhauHao').val();

        if (soThangKhauHao > 0) {
            var tienKhauHaoHangThang = (giaMua / soThangKhauHao);
            $('#TienKhauHaoHangThang').val(addThousandSeperator(tienKhauHaoHangThang));
        }
    });

    //Sự kiện thay đổi số tháng khấu hao.
    //===================================================
    $('#SoThangKhauHao').change(function () {
        var soThangKhauHao = $('#SoThangKhauHao').val();
        var tongTienKhauHao = convertStringWithCommasToNumber($('#TongTienKhauHao').val(),true);
        if (soThangKhauHao > 0) {
            //$('#TienKhauHaoHangThang').val((tongTienKhauHao / soThangKhauHao).toFixed(2));
            var tienKhauHaoHangThang = (tongTienKhauHao / soThangKhauHao);
            $('#TienKhauHaoHangThang').val(addThousandSeperator(tienKhauHaoHangThang));

            var ngayBatDauKhauHao = new Date($('#NgayBatDauKhauHao').val());
            SetDateForDatepicker('NgayKetThucKhauHao', new Date(ngayBatDauKhauHao.setMonth(soThangKhauHao)));
        }
    });
}//EndFunction.

//===================================================
//function SuKienThayDoiGiaTriSoThangKhauHao() {
//    $('#SoThangKhauHao').change(function () {
//        var soThangKhauHao = $('#SoThangKhauHao').val();
//        var tongTienKhauHao = convertStringWithCommasToNumber($('#TongTienKhauHao').val(), true);
//        if (soThangKhauHao > 0) {
//            //$('#TienKhauHaoHangThang').val((tongTienKhauHao / soThangKhauHao).toFixed(2));
//            var tienKhauHaoHangThang = (tongTienKhauHao / soThangKhauHao);
//            $('#TienKhauHaoHangThang').val(addThousandSeperator(tienKhauHaoHangThang));

//            var ngayBatDauKhauHao = new Date($('#NgayBatDauKhauHao').val());
//            //$('#NgayKetThucKhauHao').val(convertDateToString(new Date(ngayBatDauKhauHao.setMonth(soThangKhauHao))));
//            SetDateForDatepicker('NgayKetThucKhauHao', new Date(ngayBatDauKhauHao.setMonth(soThangKhauHao)));
//        }
//    });
//}//EndFunction.

//===================================================
function CauHinhSmartWizard()
{
    var idForm = "#formThongTinXe";

    // Smart Wizard
    //===================================================
    $('#smartwizard').smartWizard({
        selected: 0, //Specify the selected step on the first load, 0 = first step
        keyNavigation: true, // Enable/Disable key navigation(left and right keys are used if enabled).
        enableAllSteps: false,  // Enable/Disable all steps on first load
        disableSteps: [], //Array Steps disable.
        autoAdjustHeight: false, //Automatically adjust content height.
        contentURL: null, //Content url, Enables Ajax content loading. can set as data data-content-url on anchor.
        contentURLData: null, // override ajax query parameters
        contentCache: true, // cache step contents, if false content is fetched always from ajax url
        transitionEffect: 'slide', // Effect on navigation, none/fade/slide
        enableFinishButton: false, // makes finish button enabled always
        cycleSteps: false, //Allows to cycle the navigation of steps.
        hideButtonsOnDisabled: false, // when the previous/next/finish buttons are disabled, hide them instead

        backButtonSupport: true, //Enable the back button support.
        errorSteps: [], // array of step numbers to highlighting as error steps
        theme: 'arrows',
        transitionSpeed: 400,
        //noForwardJumping: false,
        ajaxType: 'POST',

        toolbarSettings: {
            toolbarPosition: 'bottom',//none/top/bottom/both
            toolbarPosition: 'right', //left/right
            showNextButton: true,
            showPreviousButton: true,
            toolbarExtraButtons: [
                    {
                        label: 'Lưu', css: 'btn-info disabled btn-finish', onClick: function () {
                            //alert('Finish Clicked');
                            if (!$(this).hasClass('disabled')) {

                                ////---------------------------------------
                                ////var elmForm = $("#form-step-" + stepNumber);
                                //var elmForm = $(idForm);
                                //if (elmForm) {
                                //////    //elmForm.validator('validate');
                                //    elmForm.validate({
                                //        rules: {
                                //            HangSanXuatXeKey: "required"
                                //            , LoaiXeKey: "required"
                                //            , BangSoXe: "required"
                                //            //, confirm_password: {
                                //            //    required: true,
                                //            //    minlength: 5,
                                //            //    equalTo: "#password"
                                //            //}
                                //        },
                                //        messages: {
                                //            HangSanXuatXeKey: "Vui lòng chọn một hãng sản xuất."
                                //            , LoaiXeKey: "Vui lòng chọn một loại xe."
                                //            , BangSoXe: "Vui lòng nhập bảng số xe."
                                //            //,confirm_password: {
                                //            //    required: "Please provide a password",
                                //            //    minlength: "Your password must be at least 5 characters long",
                                //            //    equalTo: "Please enter the same password as above"
                                //            //},
                                //        }
                                //    });
                                //}//EndelmForm

                                //if ($(idForm).validator('check') < 1) {
                                //    alert('Hurray, your information will be saved!');
                                //}

                                //Save
                                //==================================
                                LuuThongTinXe();
                            }
                        }
                    },
                    {
                        label: 'Tạo mới', css: 'btn-danger', onClick: function () {
                            var today = new Date();
                            var soThangKhauHao = 12;
                            
                            $('#XeKey').val('');
                            $('#HangSanXuatXeKey').change();
                            $('#LoaiXeKey').change();
                            $('#KeyLoaiXe').val('');
                            $('#BangSoXe').val('');
                            $('#SoSan').val('');
                            $('#Mau').val('');
                            $('#NgayCapPhep').val(convertDateToString(today));
                            $('#CoWifi').prop('checked', true);
                            $('#CoTivi').prop('checked', true);
                            $('#CoCameraHanhTrinh').prop('CoCameraHanhTrinh', true);
                            $('#hdCoWifi').attr("value", true);
                            $('#hdCoTivi').attr("value", true);
                            $('#hdCoCameraHanhTrinh').attr("value", true);

                            $('#GhiChuThongTinXe').val('');
                            $('#GiaMua').val(0);
                            $('#TongTienKhauHao').val(0);
                            $('#SoThangKhauHao').val(soThangKhauHao);
                            $('#TienKhauHaoHangThang').val(0);
                            $('#NgayBatDauKhauHao').val(convertDateToString(today));
                            $('#NgayKetThucKhauHao').val(convertDateToString(new Date(today.setMonth(soThangKhauHao))));
                            $('#GhiChuKhauHaoXe').val('');

                        }
                    }
            ]
        },//End-toolbarSettings
        //anchorSettings: {
        //    anchorClickable: false, //Enable or disable the click option on the step header anchors.
        //    enableAllAnchors: false, //Enable all anchors on load
        //    markDoneStepp: true, //Make already visited steps as done.
        //    enableAnchorOnDoneStep: true //Enable or disable the done steps navigation.
        //},//End-anchorSettings
        lang: {
            next: 'Tiếp theo',
            previous: 'Quay lại'
        }
    });

    //===================================================
    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        // Enable finish button only on last step
        if (stepNumber == 1) {
            $('.btn-finish').removeClass('disabled');
        } else {
            $('.btn-finish').addClass('disabled');
        }
    });

    //===================================================
    //var currentStep = $('#smartwizard').smartWizard('currentStep');
    //$('#smartwizard').smartWizard('enableStep', 0);
    //$('#smartwizard').smartWizard('goToStep', 0);
    //$('#smartwizard').smartWizard('disableStep', 1);

    //===================================================
    $("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {
        //var elmform = $("#form-step-" + stepNumber);
        //// stepdirection === 'forward' :- this condition allows to do the form validation 
        //// only on forward navigation, that makes easy navigation on backwards still do the validation when going next
        //if (stepDirection === 'forward' && elmform) {
        //    elmform.validator('validate');
        //    var elmerr = elmform.children('.has-error');
        //    if (elmerr && elmerr.length > 0) {
        //        // form validation failed
        //        return false;
        //    }
        //}
        //return true;
        
        //---------------------------------------
        //var elmForm = $("#form-step-" + stepNumber);
        ////var elmForm = $(idForm);
        //if (stepDirection === 'forward' && elmForm) {
        ////    //elmForm.validator('validate');
        //    elmForm.validate({
        //        rules: {
        //            HangSanXuatXeKey: "required"
        //            , LoaiXeKey: "required"
        //            , BangSoXe: "required"
        //            //, confirm_password: {
        //            //    required: true,
        //            //    minlength: 5,
        //            //    equalTo: "#password"
        //            //}
        //        },
        //        messages: {
        //            HangSanXuatXeKey: "Vui lòng chọn một hãng sản xuất."
        //            , LoaiXeKey: "Vui lòng chọn một loại xe."
        //            , BangSoXe: "Vui lòng nhập bảng số xe."
        //            //,confirm_password: {
        //            //    required: "Please provide a password",
        //            //    minlength: "Your password must be at least 5 characters long",
        //            //    equalTo: "Please enter the same password as above"
        //            //},
        //        }
        //    });
        //}//EndelmForm

        //---------------------------------------
        //$(idForm).validate();
        ValidateForm();
    });
}//EndFunction

function ValidateForm() {
    $('#formThongTinXe').formValidation({
        framework: 'bootstrap',
        err: {
            container: 'help-block with-errors'
        },
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            HangSanXuatXeKey: {
                validators: {
                    notEmpty: {
                        message: 'Vui lòng chọn một hãng sản xuất.'
                    }
                }
            }
            , LoaiXeKey: {
                validators: {
                    notEmpty: {
                        message: 'Vui lòng chọn một loại xe.'
                    }
                }
            }
            , BangSoXe: {
                validators: {
                    notEmpty: {
                        message: 'Vui lòng nhập bảng số xe.'
                    }
                }
            }
            //email: {
            //    validators: {
            //        notEmpty: {
            //            message: 'The email address is required and cannot be empty'
            //        },
            //        emailAddress: {
            //            message: 'The email address is not valid'
            //        }
            //    }
            //},
            //title: {
            //    validators: {
            //        notEmpty: {
            //            message: 'The title is required and cannot be empty'
            //        },
            //        stringLength: {
            //            max: 100,
            //            message: 'The title must be less than 100 characters long'
            //        }
            //    }
            //},
        }
    });
}
//===================================================
jQuery(function ($) {

    //===================================================

    $('[data-toggle="tooltip"]').tooltip();
    //===================================================
    KhoiTaoDuLieuComboBox();

    KhoiTaoCheckBoxThietBiTheoXe();

    CauHinhBangDuLieu();

    //===================================================
    SettingDatepicker('divFrmGrpNgayCapPhep');
    SetDateForDatepicker('NgayCapPhep', new Date());
    SettingDatepicker('divFrmGrpNgayBatDauKhauHao');
    SetDateForDatepicker('NgayBatDauKhauHao', new Date());
    SettingDatepicker('divFrmGrpNgayKetThucKhauHao');
    SetDateForDatepicker('NgayKetThucKhauHao', new Date((new Date).setMonth(12)));

    $(".touchspin3").TouchSpin({
        verticalbuttons: true,
        verticalupclass: 'glyphicon glyphicon-plus',
        verticaldownclass: 'glyphicon glyphicon-minus',
        min:0,
        max: 100,
        initval: 0
    });

    //===================================================
    CauHinhSmartWizard();

    //===================================================
    //$("#btSave").on('click', function (e) {
    //    e.preventDefault();

    //    $('#KeyHangSanXuatXe').val($('#HangSanXuatXeKey').val());
    //    $('#KeyLoaiXe').val($('#LoaiXeKey').val());
        
    //    //Save 
    //    //==================================
    //    $.ajax({
    //        type: "POST",
    //        datatype: "JSON",
    //        url: '/QuanLyXe/LuuThongTinXe',
    //        data: $('#formThongTinXe').serialize(),
    //        //----------------------------------
    //        success: function (response) {
    //            if (response != null) {
    //                //XoaDuLieuForm();
    //                $('#tableThongTinXe').DataTable().ajax.reload();
    //                ShowMessage(response);
    //            }//End If
    //            else {
    //                $('#output').text(msg);
    //            }
    //        },
    //        //----------------------------------
    //        //complete: function () {

    //        //},
    //        //----------------------------------
    //        failure: function (msg) {
    //            $('#output').text(msg);
    //        },
    //        //----------------------------------
    //        //error: function (jqXhr, exception) {
    //        //    ShowMessage(response);
    //        //    //if (jqXhr.status != 0) ShowMessage(response); //alert('Thực hiện không thành công');
    //        //}
    //    });//End ajax
    //});

    //$('#btNew').on('click', function (e) {
    //    e.preventDefault();
    //    $('#XeKey').val('');
    //    $('#HangSanXuatXeKey').change();
    //    $('#LoaiXeKey').change();
    //    $('#KeyLoaiXe').val('');
    //    $('#BangSoXe').val('');
    //    $('#SoSan').val('');
    //    $('#Mau').val('');
    //    $('#NgayCapPhep').val(Date);
    //    $('#CoWifi').prop('checked', true);
    //    $('#CoTivi').prop('checked', true);
    //    $('#CoCameraHanhTrinh').prop('CoCameraHanhTrinh', true);
    //    $('#hdCoWifi').attr("value", true);
    //    $('#hdCoTivi').attr("value", true);
    //    $('#hdCoCameraHanhTrinh').attr("value", true);

    //    $('#GhiChuThongTinXe').val('');
    //    $('#GiaMua').val(0);
    //    $('#TongTienKhauHao').val(0);
    //    $('#SoThangKhauHao').val(12);
    //    $('#TienKhauHaoHangThang').val(0);
    //    $('#NgayBatDauKhauHao').val(Date);
    //    $('#NgayKetThucKhauHao').val(Date);
    //    $('#GhiChuKhauHaoXe').val('');
    //});//EndFunction

    
    //===================================================
    validateValueControlsOnForm();

    //===================================================
    SuKienThayDoiGiaMua_TienChietKhau_SoThangKhauHao();

    //Sự kiện thay đổi số tháng khấu hao.
    //===================================================
    //$('#SoThangKhauHao').change(function () {
    //    var soThangKhauHao = $('#SoThangKhauHao').val();
    //    var tongTienKhauHao = convertStringWithCommasToNumber($('#TongTienKhauHao').val(), true);
    //    if (soThangKhauHao > 0) {
    //        //$('#TienKhauHaoHangThang').val((tongTienKhauHao / soThangKhauHao).toFixed(2));
    //        var tienKhauHaoHangThang = (tongTienKhauHao / soThangKhauHao);
    //        $('#TienKhauHaoHangThang').val(addThousandSeperator(tienKhauHaoHangThang));

    //        var ngayBatDauKhauHao = new Date($('#NgayBatDauKhauHao').val());
    //        SetDateForDatepicker('NgayKetThucKhauHao', new Date(ngayBatDauKhauHao.setMonth(soThangKhauHao)));
    //    }
    //});

});//EndFunction$