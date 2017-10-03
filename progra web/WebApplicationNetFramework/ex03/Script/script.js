
var interval;
var couleur = [0, 0, 0, 0, 0, 0];
var hex = [0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F'];

document.getElementById("btStart").addEventListener("click", toggleFlash);
document.getElementById("btResetBackground").addEventListener("click", resetBackground);

function toggleFlash() {

    if (interval != null) {
        clearInterval(interval);
        interval = null;
        console.debug("clearInterval");
    } else {
        interval = setInterval(flashouille, 50);
        console.debug("startInterval");

    }

}

function flashouille() {
    var sortie = "";

    for (var i = 0; i < 6; i++) {

        console.debug(i + " == 0 && couleur de i => " + couleur[i] + " soit = " + (i == 0 && couleur[i] < 9));

        if (i == 0 && couleur[i] < 9) {
            couleur[0]++;
            //alert(couleur[0]);
        } else if ( couleur[i] == 9 && couleur[i+1] < 9 ) {
            couleur[i+1]++;
        } else if (couleur[5] == 9 ){
            couleur = [0, 0, 0, 0, 0, 0];
        }

        sortie += hex[couleur[i]];
    }
    console.debug("#" + sortie);

    document.body.style.backgroundColor = "#" + sortie;
}

function resetBackground() {
    document.body.style.backgroundColor = "#FFF";
}