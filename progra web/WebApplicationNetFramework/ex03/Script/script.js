
var interval;
var couleur = [0, 0, 0, 0, 0, 0];
var hex = [0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F'];

document.getElementById("btStart").addEventListener("click", toggleFlash);
document.getElementById("btResetBackground").addEventListener("click", resetBackground);
//document.getElementById("resetForm").addEventListener("click", monReset);
document.getElementById("sendButton").addEventListener("click", verifyData, false);

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

        if (i == 0 && couleur[i] < 15) {
            couleur[0]++;
            //alert(couleur[0]);
        } else if ( couleur[i] == 15 && couleur[i+1] < 15 ) {
            couleur[i+1]++;
        } else if (couleur[5] == 15 ){
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

function verifyData() {

    var sDate = document.getElementById("ibornDate").value;

    //var reg = new RegExp("^(\d{4})\-(\d{2})\-(\d{2})");
    var reg = /(\d{2})/;
    //reg.flags = "g";
    var patt = reg.test(sDate);
    console.log(sDate +" / match => "+sDate.match(reg) +" patt => "+patt);


    return false;
}

//function monReset() {
//    document.getElementById("monForm").reset();
//}