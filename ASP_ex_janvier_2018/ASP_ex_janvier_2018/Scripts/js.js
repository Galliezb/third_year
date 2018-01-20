$().ready(function () {

    $("div[id^=Genre]").each(function () {

        $(this).on("click", function () {

            var s = $(this).attr("id")
            $("#Cont" + s).slideToggle(1000);

        });



    });

    $("div[id^=article_]").each(function () {

        $(this).on("click", function () {


            var genre = $("#genre_" + $(this).attr("id")).val();
            var descriptif = $("#desc_" + $(this).attr("id")).val();

            var collection = $("#CollId_" + $(this).attr("id")).val();
            var nom = $("#nom_" + $(this).attr("id")).text();
            var articleId =$(this).attr("id").substr(8);

            console.log(articleId);

            $("#guid").val(articleId);
            $("#dnom").val(nom);
            $("#ddesc").val(descriptif);
            $("#genre").val(genre);
            $("#collection").val(collection);

        });




    });


    $("#sauvegarde").on("click", function () {

        if ( $("#dnom").val().length == 0) {
            $("#Error").html("Le nom ne peut-être vide");
        } else {

            var monObjet = new Object();
            monObjet.guid = $("#guid").val();
            console.log($("#guid").val());
            console.log(monObjet.guid);
            monObjet.dnom = $("#dnom").val();
            monObjet.ddesc = $("#ddesc").val();
            monObjet.genre = $("#genre").val();
            monObjet.collection = $("#collection").val();


            $.ajax({
                
                url: "/Home/Update",
                data: monObjet

            }).done(function () {
                alert("update effectuée");
                window.location = "/Home/Index";
                }).fail(function () {
                    console.log("ajax update info failed");
                });

        }

    });
});