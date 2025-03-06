function bindFormSubmission() {
    $(document).on('submit', 'form', function (e) {
        e.preventDefault();
        alert("Form submit is being handled by AJAX instead of default form submission");

        var form = $(this);
        $.ajax({
            url: '/Home/UpdateProductFromModal',
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                alert(response);

                var productId = form.find('input[name="Id"]').val();
                console.log("Product ID being sent:", productId);


                $('div[data-id="' + productId + '"] card').replaceWith(response);

                var modal = bootstrap.Modal.getInstance(document.getElementById('editProductModal'));
                modal.hide();
            },
            error: function () {
                console.error('An error has occured while updating the product');
            }
        });
    });
}