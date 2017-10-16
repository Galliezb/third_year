console.log("JS loaded");
$("#sub").on("click", function () {

    console.log("ajax url => Home/Traitement?identitie=" + $("#identite").val);

    $.ajax(
        type:"GET",
        url:"Home/Traitement?identitie=" + $("#identite").val,
        sucess:function (msg) {
            //console.log(msg);
        });
});