const btn = document.getElementById('btn1');
const viewBag = document.getElementById('yaziEkleDurumu');

function getValue() {
    if (viewBag.innerText == "İşlem Başarısız !") {
        if (viewBag.classList.value == "") {
            viewBag.classList.toggle('yaziEkleDurumBasarisiz');
        }
    }
    if (viewBag.innerText == "İşlem Başarılı") {
        if (viewBag.classList.value == "") {
            viewBag.classList.toggle("yaziEkleDurumBasarili");
        }
    }
    else {
    }
};
getValue();
/*-----------------------------*/
