$.validator.setDefaults({
    ignore: '*:not([name])',
    errorElement: "span",
    errorClass: "help-block invalid-feedback",
    errorPlacement: function (error, element) {
        if (element.attr("type") === "radio" || element.attr("type") === "checkbox") {
            error.appendTo($(element).closest('.form-group'));
        } else if (element.hasClass("ckeditor")) {
            error.appendTo($(element).closest('.form-group'));
        } if (element.hasClass("select2") || element.hasClass('select2-hidden-accessible')) {
            $(element).parent().append(error);
        } else {
            if (element.attr("type") === "radio" || element.attr("type") === "checkbox")
                error.insertAfter($(element).closest('.form-group').children('div').children().last());
            else if (element.parent().hasClass('input-group'))
                error.insertAfter(element.parent());
            else
                error.insertAfter(element);
        }
        $(element).closest('.form-group').addClass('has-error');
    },
    highlight: function (element, errorClass, validClass) {
        $(element).addClass('is-invalid').removeClass('is-valid');
        $(element).closest('.form-group').addClass('has-error');
    },
    unhighlight: function (element, errorClass, validClass) {
        $(element).removeClass('is-invalid').addClass('is-valid');
        $(element).closest('.form-group').removeClass('has-error');
    },
    success: function (label, element) {
        $(element).removeClass('is-invalid').addClass('has-error');
    }
});