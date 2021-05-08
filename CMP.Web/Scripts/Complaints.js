$(function () {
    var complaintId = 0;

    $(".saveBtn").click(function () {
        var user = new Object();
        user.Title = $('#titleTxt').val();
        user.CategoryId = $('#categorySelect').val();
        user.Description = $('#descriptionTxtArea').val();

        $.ajax({
            type: "POST",
            url: "/complaint/Create",
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

    $(".detailsBtn").click(function () {
        complaintId = $(this).siblings("input:hidden").val();
        $.ajax({
            type: "Get",
            url: "/complaint/Get?complaintId=" + complaintId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#detailsModal").modal('toggle');
                $("#detailsCategorySelect").val(response.CategoryId)
                $("#detailsTitleTxt").val(response.Title);
                $("#detailsDescriptionTxtArea").val(response.Description);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });


    $(".changeStatusBtn").click(function () {
        complaintId = $(this).siblings("input:hidden").val();

        $.ajax({
            type: "Get",
            url: "/complaint/Get?complaintId=" + complaintId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#statusSelect").val(response.LastStatusId);
                $("#changeStatusModal").modal('toggle');
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    $(".saveStatuBtn").click(function () {

        $.ajax({
            type: "POST",
            url: "/complaint/UpdateStatus?complaintId=" + complaintId + "&statusId=" + $("#statusSelect").val(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#changeStatusModal").hide();
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