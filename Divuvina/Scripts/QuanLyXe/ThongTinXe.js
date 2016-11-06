jQuery(function ($) {
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
                    //alert('Thực hiện thành công.');
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

});//EndFunction$