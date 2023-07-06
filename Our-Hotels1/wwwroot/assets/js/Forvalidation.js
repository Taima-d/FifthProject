function validate() {
    var manegerName = document.getElementById("manegername").value;
    var Numberofstars = document.getElementById("Numberofstars").value;
    var Phone1 = document.getElementById("Phone1").value;
    var Phone2 = document.getElementById("Phone2").value;
    var ManegerPhone = document.getElementById("ManegerPhone").value;
    var HotelAddress = document.getElementById("HotelAddress").value;


    if (manegerName.value.trim() === " ") {
        document.getElementById("manegernameV").innerHTML = "Maneger Name is required";
    }
    if (Numberofstars.value.trim() === " ") {
        document.getElementById("NumberofstarsV").innerHTML = "Number of stars is required";
    }
    if (Phone1.value.trim() === " " || Phone2.value.trim()== " ") {
        document.getElementById("PhoneV").innerHTML = "Please enter one of phones ";
    }

    if (ManegerPhone.value.trim() === " " ) {
        document.getElementById("ManegerPhoneV").innerHTML = "Please enter one of phones ";
    }
    if (HotelAddress.value.trim() === " ") {
        document.getElementById("HotelAddressV").innerHTML = "Please your hotel address";
    }
}