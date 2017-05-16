function Delete(url,id) {
    $.ajax({
        url: url + id,
        //data:id,
        type: "Post",
        success: function (result) {
            $("#a_" + id).fadeOut();
        }
    })
}