function dynamicMask(id) {

    $(id).keydown(function () {
        try {
            $(id).unmask();
        } catch (e) { }

        var tamanho = $(id).val().length;

        if (tamanho < 11) {
            $(id).mask("999.999.999-99");
        } else {
            $(id).mask("99.999.999/9999-99");
        }

        // ajustando foco
        var elem = this;
        setTimeout(function () {
            // mudo a posição do seletor
            elem.selectionStart = elem.selectionEnd = 10000;
        }, 0);
        // reaplico o valor para mudar o foco
        var currentValue = $(this).val();
        $(this).val('');
        $(this).val(currentValue);
    });
}

function maskCNPJ(id) {
    $(id).mask("00.000.000/0000-00");
}

function maskCPF(id) {
    $(id).mask("000.000.000-00");
}