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