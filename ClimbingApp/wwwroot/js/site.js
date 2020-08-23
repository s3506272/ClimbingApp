// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var Log_Boulder_Area = $("#Log_Boulder_Area ");
var Log_Type = $("#Log_Type");



    $('.climbupdate').ready(function () {

        var type = Log_Type.val();
        var area = Log_Boulder_Area.val();


        $.ajax({
            //type: "GET",
            url: "/test/getAreaByType/",
            data: {
                type: type,
                area: area
            },
            cache: false,
            type: "POST",
            success: function (data) {
                var markup = "<option>Select Climb</option>";

                for (var x = 0; x < data.length; x++) {

                    markup += "<option value=" + data[x].id + ">" + data[x].name + "</option>";
                }
                $("#climbID").html(markup).show();
            }
        });

    });


$('.climbupdate').change(function () {

    var type = Log_Type.val();
    var area = Log_Boulder_Area.val();

    var procemessage = "<option> Please wait...</option>";
    $("#climbID").html(procemessage).show();

    $.ajax({
        //type: "GET",
        url: "/test/getAreaByType/",
        data: {
            type: type,
            area: area
        },
        cache: false,
        type: "POST",
        success: function (data) {
            var markup = "<option>Select Climb</option>";

            for (var x = 0; x < data.length; x++) {

                markup += "<option value=" + data[x].id + ">" + data[x].name + "</option>";
            }
            $("#climbID").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });

});