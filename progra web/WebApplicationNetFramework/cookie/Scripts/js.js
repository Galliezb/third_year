console.log("Script loaded");
document.getElementById("effacer").addEventListener("click", delCookie );
document.getElementById("sauvegarder").addEventListener("click", Save);



function Save() {
    console.log("Save cookie");
    var value = document.getElementById("contenuCookie").value;
    console.log("Valeur à sauvegarder => " + value);
    setCookie("test", value, 5 );
}

function getCookie(NameOfCookie) {

    if (document.cookie.length > 0) {

        begin = document.cookie.indexOf(NameOfCookie + "=");

        if (begin != -1) {
            begin += NameOfCookie.length + 1;
            end = document.cookie.indexOf(";", begin);
            if (end == -1) end = document.cookie.length;
            return unescape(document.cookie.substring(begin, end));
        }

    }
    return null;

}

function setCookie(NameOfCookie, value, expiredays) {
    var ExpireDate = new Date();
    ExpireDate.setTime(ExpireDate.getTime() + (expiredays * 24 * 3600 * 1000));
    document.cookie = NameOfCookie + "=" + escape(value) +
        ((expiredays == null) ? "" : "; expires=" + ExpireDate.toGMTString());
}

function delCookie() {
    console.log("delete cookie");
    document.cookie = "test" + "=" +"; expires=Thu, 01-Jan-70 00:00:01 GMT";
}

function ReadCookie() {
    console.log("ReadCookie");

    var value = getCookie("test");
    console.log("Cookie lu => " + value);
    var element = document.getElementById("contenuCookie");

    if (value == null) {
        element.value = "Cookie non trouvé";
        element.style.color = "red";
    } else {
        element.value = value;
    }

}