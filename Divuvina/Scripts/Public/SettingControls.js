
/*=== Cấu hình Datepicker từ div cha liền kề._____________________________________*/
function SettingDatepicker(divId) {
    var idControl = '#' + divId + ' .input-group.date';
    $(idControl).datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true,
        todayHighlight: true
        ,format: 'dd/mm/yyyy'
    });
}

function Initdatepicker() {
    //var idControl = '#' + divId;
    jQuery().datepicker && $(".date-picker").datepicker({
        rtl: App.isRTL(),
        todayBtn: "linked",
        orientation: "left",
        autoclose: !0,
        minDate: "01/01/2012",
        startDate: "01/01/2012",
        todayHighlight: true
        , format: 'dd/mm/yyyy'
        , language: "vi"
    })
	//, $(document).scroll(function () { $(".date-picker").datepicker("place") })
}


/*=== Cập nhật ngày cho Datepicker._____________________________________*/
function SetDateForDatepicker(idDatepicker, dateObj) {
    if (dateObj != null || dateObj != '')
        $('#'+ idDatepicker).val(convertDateToString(dateObj));
}