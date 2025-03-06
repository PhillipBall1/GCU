function updateComputedFields(taxRate) {
    var price = parseFloat($("#Price").val());

    if (!isNaN(price)) {
        var tax = price * taxRate;
        var formattedTax = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(tax);

        $("#FormattedEstimatedTax").val(formattedTax);
    } else {
        $("#FormattedEstimatedTax").val("");
    }
}

function toggleImageInput() {
    var imageFile = $("#ImageFile");
    var imageURL = $("#ImageURL");

    if (imageFile.val()) {
        imageURL.prop('disabled', true);
        imageURL.val(""); 
    } else {
        imageURL.prop('disabled', false);
    }

    if (imageURL.val()) {
        imageFile.prop('disabled', true);
        imageFile.val("");
    } else {
        imageFile.prop('disabled', false);
    }
}

function bindDynamicEvents(taxRate) {
    $("#Price").on("input change", function () {
        updateComputedFields(taxRate);
    });

    $("#ImageFile, #ImageURL").on("input change", toggleImageInput);
}

function initializeForm(taxRate) {
    updateComputedFields(taxRate);
    toggleImageInput();
    bindDynamicEvents(taxRate);
}