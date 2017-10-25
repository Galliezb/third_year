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
                // on va recevoir un string en retour, plus de Json nécessaire
                //dataType: 'json',
                contentType: false,
                success: function (reponse) {
                    $("#file").val('');
                    $("#imgPreview").attr("src", reponse);
                },
                error: function (resultat, statut, erreur) {
                    alert("Error 1 => " + resultat);
                    alert("Error 2 => " + statut);
                    alert("Error 3 => " + erreur);
                }

            });

        } else {
            alert("file lengt == 0");
        }

    });

});


$(function () {



});