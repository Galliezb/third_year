$(document).ready(function(){

    // pour éviter les soucis de visibility VS display ( height box )
    // on cache les textes depuis le JS
    // il reste le bon vieux display none en CSS
    // Jquery gère très bien ensuite via le slide
    //$("#menuDepliant").find("div").each(function(){
        //$(this).hide();
    //});

    // toggleslide sur chaque div présent dans le parent
    // et on dépli forcément celui en dessous du click
    $("#menuDepliant").on("click","h1" , function(){
        
        $("#menuDepliant").find("div").each(function(){
            $(this).slideUp("slow");
        });
        $(this).next().slideToggle("slow");

    });

});