function ShowMessage(response) {
    toastr.options = {
        closeButton: true
        , timeOut: 7000
    };
    if (response.Result == true)
        toastr.success(response.Message, response.Title);
    else
        toastr.error(response.Message, response.Title);
}//EndFunction