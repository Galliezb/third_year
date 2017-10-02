var nbrSeconde = 10;
document.getElementById("seconde").innerText = nbrSeconde;
var inter = setInterval(intervalSeconde, 1000);
setInterval(relancePopupPub, 30000);

function intervalSeconde() {
    if (nbrSeconde > 0) {
        nbrSeconde--;
        document.getElementById("seconde").innerText = nbrSeconde;
    } else {
        nbrSeconde = 10;
        clearInterval(inter);
        hidePub();
    }

}

function relancePopupPub() {
    document.getElementById("seconde").innerText = 10;
    if (nbrSeconde == 10) {
        displayPub();
        setInterval(intervalSeconde, 1000);
    }
}

function displayPub() {
    document.getElementById("popupPub").style.visibility = "visible";
    document.getElementById("transparence").style.visibility = "visible";
}

function hidePub() {
    document.getElementById("popupPub").style.visibility = "hidden";
    document.getElementById("transparence").style.visibility = "hidden";
}