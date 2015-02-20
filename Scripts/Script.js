function getInfo() {
    var dl = document.getElementById("sel");
    var user = dl.options[dl.selectedIndex].value;
    var label = document.getElementById("Label1");
    var v = document.getElementById("sel");
    PageMethods.GetEmail(user, onSucess, onError);
    function onSucces(result) {
        var afisaj = result.split(',');
        var innerText = "";
        for (var i = 0; i < afisaj.length; i++) {
            var opt = document.createElement('option');
            opt.value = afisaj[i];
            opt.innerHTML = afisaj[i];
            sel.appendChild(opt);
        }
    }
    function onError(result) {
        alert('Something wrong.');
    }

}

