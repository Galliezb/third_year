// verification par regex
//var pat = /^[a-zA-Z|{\-|\s}]+$/g;
var regName = new RegExp(/^[a-zA-Z|{\-|\s}]+$/, "g");
var regDigit = new RegExp(/^[\d|.]+$/, "g");

function displayMessage(message, color, duration) {

    $("#messForm").css("color", color);
    $("#messForm").text(message);
    $("#messForm").fadeOut(duration, function () { $("#messForm").css("display", "block"); $("#messForm").text(""); });

}

$().ready(function () {

    $('#preview').click(function () {


        var mesData = new FormData();
        var files = $("#imgToUpload").get(0).files;

        if (files!="undefined" && files.length > 0) {

            mesData.append("monImageUploaded", files[0]);

            $.ajax({
                url: '/Home/UploadImage',
                type: "POST",
                processData: false,
                data: mesData,
                dataType: 'json',
                contentType: false,
                success: function (response) {
                    if (response != null || response != '') {
                        $("#file").val('');
                        $("#IdImg").val(response.id);
                        $("#imgPreview").attr("src",response.url);
                    }
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
            $("#messImg").text("Veuillez d'abord ajouter une image");
        }

    });


    // envoye du formulaire
    $('#Valider').click(function () {

        var mesData = new Object();
        // pas de bras, pas de chocolat
        // pas d'id pas d'image

        mesData.Nom = $("#Nom").val();
        mesData.Descriptif = $("#Descriptif").val();
        mesData.Promo = $("#Promo")[0].checked; // return true ou false
        if ($("#IdImg").val() != "") {
            mesData.IdImg = $("#IdImg").val();
        } else {
            mesData.IdImg = 0;
        }


        if (mesData.Nom.length > 2 && mesData.Descriptif.length > 5) {
            // vérif info
            console.log("nom=>" + mesData.Nom);
            console.log("Descriptif=>" + mesData.Descriptif);
            console.log("Promo=>" + mesData.Promo);
            console.log("IdImg=>" + mesData.IdImg);

            $.ajax({
                url: '/Home/AddArticle',
                type: "POST",
                data: JSON.stringify(mesData),
                dataType: 'text',
                contentType: "application/json",
                success: function (response) {
                    $("#IdImg").val("");
                    $("#Nom").val("");
                    $("#Descriptif").val("");
                    $("#Promo").val("");
                    $("#messForm").text(response);
                    $("#messForm").fadeOut(1000, function () {
                        $("#messForm").css("display", "block");
                        $("#messForm").text("");
                    });
                    $("#imgPreview").attr("src", "/img/default.png");
                    $("#messForm").css("color","green");
                    displayMessage(response, "green", 2500);
                },
                error: function (er) {
                    console.log("Error ajax addArtcile => " + er);
                }

            });

        } else {
            displayMessage("Le nom doit faire au moins 2 caractères et 5 pour le descriptif", "red", 2500)
        }

    });

});
