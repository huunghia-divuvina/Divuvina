
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

/*=== Cập nhật ngày cho Datepicker._____________________________________*/
function SetDateForDatepicker(idDatepicker, dateObj) {
    if (dateObj != null || dateObj != '')
        $('#'+ idDatepicker).val(convertDateToString(dateObj));
}