$(function () {
    $(".saveBtn").click(function () {
        var user = new Object();
        user.Email = $('#emailTxt').val();
        user.Password = $('#passwordTxt').val();
        user.RoleId = $('#roleSelect').val();  

        $.ajax({
            type: "POST",
            url: "/user/Create",
            data: JSON.stringify(user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#exampleModal").hide();
                location.reload(true);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });  
    });
});