console.log("JS loaded");
$("#sub").on("click", function () {

    var monObjet = new Object();
    monObjet.Identite = $("#identite").val();
    monObjet.Prenom = $("#prenom").val();

    // POST + JSON
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        // @url.acton("traitement") avec razo pour récupérer l'url
        url: "Home/Traitement/",
        data: JSON.stringify(monObjet),
        sucess: function (msg) {
            //console.log(msg);
            console.log("Succes => "+ JSON.stringify(msg));
        },
        error: function (msg) {
            //console.log(msg);
            console.log("ERROR => " + msg);
        },
        statusCode: {
            200: function (msg) {
                console.log("Execution ok. Objet retourné => "+ JSON.stringify(msg));
            },
            404: function () {
                console.log("ERROR => Page de destination non trouvée");
            }
        }
    });
    // GET
    //$.ajax({
    //    type: "GET",
    //    dataType:"json",
    //    contentType:"application/json",
    //    // @url.acton("traitement") avec razo pour récupérer l'url
    //    url: "Home/Traitement/" + $("#identite").val(),
    //    // en méthod POST
    //    //data: { identitie: $("#identite").val()},
    //    // pour une info
    //    // data : 'identite='+data,
    //    sucess: function (msg) {
    //        //console.log(msg);
    //    }
    //});
});