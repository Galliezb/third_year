
var interval;
var couleur = [0,0,0,0,0,0];

document.getElementById("btStart").addEventListener("click", toggleFlash);

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
            couleur[0]+=1;
        } else if ( couleur[i] == 9 && couleur[i+1] < 9 ) {
            couleur[i+1]++;
        } else if ( i == 5 ){
            couleur = [0, 0, 0, 0, 0, 0];
        }

        sortie += couleur[i];
    }
    console.debug("#" + sortie);

    document.body.style.backgroundColor = "#" + sortie;
}