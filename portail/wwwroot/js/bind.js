$('#value').bind("input", function () {
    var value = $(this).val();
    $('#deltaChoice').val(value);
})