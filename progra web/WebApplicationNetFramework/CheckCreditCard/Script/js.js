document.getElementById("subForm").addEventListener("click", function (event) {
    //return false;
    event.preventDefault();
    return false;
});
//document.getElementById("subForm").addEventListener("click", checkCreditCardValidity() );
document.getElementById("subForm").addEventListener("click", function () { checkCreditCardValidity(); });
//document.getElementById("subForm").addEventListener("click", function () { return false; });


function checkCreditCardValidity() {

    var creditCard = document.getElementById("creditCard").value;
    var total = 0;

    var reg = "/^\d{16}$/";
    var regex = new RegExp(reg);
    if (regex.test(creditCard)) {
        for (var i = 0; i < 15; i += 2) {

            var tmpNumber = parseInt(creditCard[i]);

            tmpNumber = tmpNumber * 2;

            if (tmpNumber > 9) {
                tmpNumber -= 9;
            }

            total += tmpNumber;

        }
    } else {
        document.getElementById("mess").innerHTML = 'Error :  need 16 number';
        return false;
    }

    console.log("total => " + total);

    var mess;
    if (total % 10 == 0) {
        mess = "Credit Card Ok";
    } else {
        mess = "Error : Credit card number not ok";
    }

    document.getElementById("mess").innerHTML = mess;

    return false;
}