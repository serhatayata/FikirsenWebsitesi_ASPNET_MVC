//Session Storage
function sessionTrigger() {
    var sessionValue = document.getElementsByClassName("name_Giris")[0].value;
    console.log(sessionValue);
    if (typeof (Storage) !== "undefined") {
        sessionStorage.setItem("KullaniciAd", sessionValue);
    }
}
