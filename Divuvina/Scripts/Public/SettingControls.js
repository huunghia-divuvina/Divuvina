
/*=== Cấu hình Datepicker từ div cha liền kề._____________________________________*/
function SettingDatepicker(divId) {
    var idControl = '#' + divId + ' .input-group.date';
    $(idControl).datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });
}

/*=== Cập nhật ngày cho Datepicker._____________________________________*/
function SetDateForDatepicker(idDatepicker, dateObj) {
    $('#'+ idDatepicker).val(convertDateToString(dateObj));
}