$().ready(function () {

    $("#sendIdentification").on("click", function () {

        var mesDataChiffrees = new Object();
        mesDataChiffrees.Login = encryptData($("#login").val());
        mesDataChiffrees.Pass = encryptData($("#pass").val());

        console.log(mesDataChiffrees.Login);
        console.log(mesDataChiffrees.Pass);

        $.ajax({
            url: "Home/Connect/",
            data: JSON.stringify(mesDataChiffrees),
            method:"POST",
            datatype: mesDataChiffrees, // type de retour
            contentType: 'application/json; charset=utf-8',
            success: function (retour) {
                console.log(retour);
            },
            error: function (retour) {
                console.log(retour);
            }
        });

    });

});


function encryptData(maData) {

    var rsaPublicKey = $("#pubKeyRsa").val();

    var rsa = new JSEncrypt();
    rsa.setPublicKey(rsaPublicKey);
    return rsa.encrypt(maData);

}





