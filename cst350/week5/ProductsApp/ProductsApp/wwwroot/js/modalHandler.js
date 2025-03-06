function bindEditProductEvent(taxRate) {
    $(document).on('click', '.edit-product', function (e) {
        e.preventDefault();

        var productId = $(this).data('id');
        $.ajax({
            url: '/Home/ShowUpdateModal',
            data: { id: productId },
            success: function (result) {

                $('#editProductModal .modal-content').html(result);

                var currentImage = $('div[data-id="' + productId + '"] img').attr('src');
                if (currentImage) {
                    currentImage = currentImage.replace("/images/", "").trim();
                    $("#ImageURL").val(currentImage);
                } else {
                    console.warn("No image found for product ID:", productId);
                }

                var modal = new bootstrap.Modal(document.getElementById('editProductModal'));
                modal.show();

                initializeForm(taxRate);
            },
            error: function () {
                console.error('Error occured while loading this form');
            }
        })
    })
}