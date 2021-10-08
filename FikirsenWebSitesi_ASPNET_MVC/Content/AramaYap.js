//Select change
function changed1() {
    const data1 = document.getElementById("dataSent");
    const selectOpt = document.getElementById("select1");
    var chosen = selectOpt.value;

    data1.setAttribute("name", chosen);
    console.log(chosen);
}

$(document).ready(function () {
    $('#table1').DataTable();
});