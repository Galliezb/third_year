// verification par regex
//var pat = /^[a-zA-Z|{\-|\s}]+$/g;
var regName = new RegExp(/^[a-zA-Z|{\-|\s}]+$/, "g");
var regDigit = new RegExp(/^[\d|.]+$/, "g");


$().ready(function () {

    $('#preview').click(function () {


        var mesData = new FormData();
        var files = $("#fileToUpload").get(0).files;

        if (files.length > 0) {

            mesData.append("monImageUploaded", files[0]);

            $.ajax({
                url: '/Home/UploadImage',
                type: "POST",
                processData: false,
                data: mesData,
                dataType: 'json',
                contentType: false,
                success: function (response) {
                    if (response != null || response != '')
                        alert(response);
                    $("#file").val('');
                    //$("imgPreview").attr("src", response);
                },
                error: function (er) {
                    alert("Error => " + er);
                },
                statusCode: {
                    200: function () {

                    }
                }

            });

        } else {
            alert("file lengt == 0");
        }

    });

});


$(function () {



});