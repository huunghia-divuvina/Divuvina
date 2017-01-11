function isNullOrUndefined(value) {
    return (typeof (value) === 'undefined' || value === null);
}

function validateValueControlsOnForm() {
    $('.input-group input[required], .input-group textarea[required], .input-group select[required]').on('keyup change', function () {
        var $form = $(this).closest('form'),
            $group = $(this).closest('.input-group'),
			$addon = $group.find('.input-group-addon'),
			$icon = $addon.find('span'),
			state = false;

        if (!$group.data('validate')) {
            state = $(this).val() ? true : false;
        } else if ($group.data('validate') == "email") {
            state = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test($(this).val())
        } else if ($group.data('validate') == 'phone') {
            state = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/.test($(this).val())
        } else if ($group.data('validate') == "length") {
            state = $(this).val().length >= $group.data('length') ? true : false;
        } else if ($group.data('validate') == "number") {
            state = !isNaN(parseFloat($(this).val())) && isFinite($(this).val());
        }

        if (state) {
            $addon.removeClass('danger');
            $addon.addClass('success');
            $icon.attr('class', 'glyphicon glyphicon-ok');
        } else {
            $addon.removeClass('success');
            $addon.addClass('danger');
            $icon.attr('class', 'glyphicon glyphicon-remove');
        }

        if ($form.find('.input-group-addon.danger').length == 0) {
            $form.find('[type="submit"]').prop('disabled', false);
        } else {
            $form.find('[type="submit"]').prop('disabled', true);
        }
    });

    $('.input-group input[required], .input-group textarea[required], .input-group select[required]').trigger('change');
}

//=============================================================================
//=============================================================================


//jQuery.extend(jQuery.validator.messages, {
//    required: "This field is required.",
//    remote: "Please fix this field.",
//    email: "Please enter a valid email address.",
//    url: "Please enter a valid URL.",
//    date: "Please enter a valid date.",
//    dateISO: "Please enter a valid date (ISO).",
//    number: "Please enter a valid number.",
//    digits: "Please enter only digits.",
//    creditcard: "Please enter a valid credit card number.",
//    equalTo: "Please enter the same value again.",
//    accept: "Please enter a value with a valid extension.",
//    maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
//    minlength: jQuery.validator.format("Please enter at least {0} characters."),
//    rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
//    range: jQuery.validator.format("Please enter a value between {0} and {1}."),
//    max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
//    min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
//});

jQuery.extend(jQuery.validator.messages, {
    required: "Thông tin này không được để trống.",
    remote: "Please fix this field.",
    email: "Vui lòng nhập một địa chỉ email hợp lệ.",
    url: "Vui lòng nhập địa chỉ URL hợp lệ.",
    date: "Vui lòng nhập ngày hợp lệ.",
    dateISO: "Vui lòng nhập ngày hợp lệ theo chuẩn (ISO).",
    number: "Vui lòng nhập một số hợp lệ.",
    digits: "Vui lòng chỉ nhập chữ số.",
    creditcard: "Please enter a valid credit card number.",
    equalTo: "Vui lòng nhập đúng giá trị một lần nữa.",
    accept: "Vui lòng nhập giá trị với một giá trị mở rộng.",
    maxlength: jQuery.validator.format("Vui lòng nhập không nhiều hơn {0} ký tự."),
    minlength: jQuery.validator.format("Vui lòng nhập không ít hơn {0} ký tự."),
    rangelength: jQuery.validator.format("Vui lòng nhập một giá trị từ {0} đến {1} ký tự."),
    range: jQuery.validator.format("Vui lòng nhập một giá trị từ {0} đến {1}."),
    max: jQuery.validator.format("Vui lòng nhập một giá trị nhỏ hơn hoặc bằng {0}."),
    min: jQuery.validator.format("Vui lòng nhập một giá trị lớn hơn hoặc bằng {0}.")
});