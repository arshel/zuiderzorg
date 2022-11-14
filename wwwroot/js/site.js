// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("body").on("click", "#LoginPartial", function () {
    var url = "/?handler=" + $(this).attr("id");
    console.log(url)
    $.ajax({
        url: url,
        success: function (data) {
            $("#exampleModal .modal-dialog").html(data);
            $("#exampleModal").modal("show");
        }
    });
});