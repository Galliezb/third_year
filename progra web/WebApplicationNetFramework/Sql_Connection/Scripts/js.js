console.log("JS loaded");
$().ready(function () {

    //$.ajax({
    //    URL: "/Home/Etudiant/GetAllAMtricules",
    //    type:"POST",
    //    statusCode: {
    //        200: function (msg) {
    //            console
    //        }
    //    }
    //});


    $("#matSelect").change(function () {

        var mat = $("#matSelect").val();

        $.ajax({
            url: "/Home/GetAllFromMatricule/"+mat,
            type: "POST",
            dataType: "Json",
            statusCode: {
                200: function (msg) {
                    console.log("REMPLIR TD " + msg.ID);
                    $("#colId").html(msg.ID);
                    $("#colMatricule").html(msg.Matricule);
                    $("#colNom").html(msg.Nom);
                    $("#colPrenom").html(msg.Prenom);
                    $("#colLocalite").html(msg.Localite);
                }
            }
        });
    });

});