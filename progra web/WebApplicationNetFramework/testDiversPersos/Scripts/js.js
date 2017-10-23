// verification par regex
//var pat = /^[a-zA-Z|{\-|\s}]+$/g;
var regName = new RegExp(/^[a-zA-Z|{\-|\s}]+$/, "g");
var regDigit = new RegExp(/^[\d|.]+$/, "g");


$().ready(function () {

    // cache le popup quand on clic sur le bouton
    $("#btLeavePopup").on("click", togglePopup);

    // soumet un user à la BDD
    $("#AddUserSubmit").on("click", function () {

        var user = new Object();
        user.ID = 0;
        user.Name = $("#AddUserName").val();
        user.Firstname = $("#AddUserFirstname").val();
        user.Solde = $("#AddUserSolde").val().replace(/\D/g, "");
        user.Solde = parseInt(user.Solde);

        // verif du solde
        if (user.Solde == "undefined") { user.Solde = 0; }

        if (user.Name.length < 3) {
            togglePopup("Le nom doit avoir au minimum 3 caractères.");
        } else if (user.Firstname.length < 3) {
            togglePopup("Le nom de famille doit avoir au minimum 3 caractères");
        } else if (user.Solde < 0) {
            togglePopup("Il est impossible de créer un compte avec un solde négatif.");
        } else {

            $.ajax({
                url: "/Ajax/AddUser",
                type: "POST",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(user),
                succes: function (e) {
                    togglePopup("Utilisateur ajouté.");
                    $("#AddUserName").val("").focus();
                    $("#AddUserFirstname").val("");
                    $("#AddUserSolde").val("0");
                    console.log(e[0]);
                },
                error: function (e) {
                    console.log(e[0]);
                }
            });

            //$.ajax({
            //    url: "/TestAvec/TestController",
            //    type: "POST",
            //    dataType: "json",
            //    contentType: "application/json;charset=utf-8",
            //    //data: JSON.stringify(user),
            //    succes: function (e) {
            //        togglePopup("Utilisateur ajouté.");
            //        $("#AddUserName").val("").focus();
            //        $("#AddUserFirstname").val("");
            //        $("#AddUserSolde").val("0");
            //        console.log(e[0]);
            //    },
            //    error: function (e) {
            //        console.log(e[0]);
            //    }
            //});

            //$.ajax({
            //    url: "/TestSans/TestController",
            //    type: "POST",
            //    dataType: "json",
            //    contentType: "application/json;charset=utf-8",
            //    //data: JSON.stringify(user),
            //    succes: function (e) {
            //        togglePopup("Utilisateur ajouté.");
            //        $("#AddUserName").val("").focus();
            //        $("#AddUserFirstname").val("");
            //        $("#AddUserSolde").val("0");
            //        console.log(e[0]);
            //    },
            //    error: function (e) {
            //        console.log(e[0]);
            //    }
            //});

        }

    });


    function togglePopup(str) {

        if (str != "undefined") {
            $("#popupIn").html(str);
        }

        if ($("#backgroundPopup").css("display") == "none") {
            $("#backgroundPopup").css("display", "block");
        } else {
            $("#backgroundPopup").css("display", "none");
        }

    }

});

