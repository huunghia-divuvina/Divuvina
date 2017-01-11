function ShowMessage() {
    if (arguments.length == 1) {
        // One-parameters avialble.
        //return (
        //    ShowMessage.oneParams.apply(this, arguments)
        //);
        ShowMessage.oneParams.apply(this, arguments);
    }
    else if (arguments.length == 2) {
        // Two-parameters available.
        //return(
        //    ShowMessage.twoParams.apply(this, arguments)
        //);
        ShowMessage.twoParams.apply(this, arguments);
    }
    else if (arguments.length == 3) {
        // Three-parameters avialble.
        //return (
        //    ShowMessage.threeParams.apply(this, arguments)
        //);
        ShowMessage.threeParams.apply(this, arguments);
    }
}//EndFunction

//===============================================
ShowMessage.threeParams = function (message, title, typeMessage) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    if (typeMessage == "success")
        toastr.success(message, title);
    else if (typeMessage == "info")
        toastr.info(message, title);
    else if (typeMessage == "warning")
        toastr.warning(message, title);
    else
        toastr.error(message, title);
}//EndFunction

//===============================================
ShowMessage.twoParams = function (message, title) {
    ShowMessage.threeParams(message, title, "info");
}//EndFunction

//===============================================
ShowMessage.oneParams = function (response) {
    if (response != undefined && response.Result != undefined)
    {
        if (response.Result == true)
            ShowMessage.threeParams(response.Message, response.Title, "success");
        else
            ShowMessage.threeParams(response.Message, response.Title, "error");
    }
    else if (response != undefined) {
        ShowMessage.threeParams(response, "Thông báo", "info");
    }
}//EndFunction

//===============================================
function ShowMessageFailure(message) {
    ShowMessage(message, "Thực hiện không thành công", "error");
}