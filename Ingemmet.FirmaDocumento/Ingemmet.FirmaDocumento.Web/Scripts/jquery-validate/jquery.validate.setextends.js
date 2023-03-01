$.validator.setDefaults({
    errorElement: "span",
    errorClass: "help-block",
    errorPlacement: function (error, element) {
        if (element.attr("type") === "radio" || element.attr("type") === "checkbox") {
            error.insertAfter($(element).closest('.form-group').children('div').children().last());
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
    },
    ignore: '*:not([name])',
    //invalidHandler: function (event, validator) { 
    //    successHandler2.hide();
    //    errorHandler2.show();
    //},
    highlight: function (element) {
        $(element).closest('.help-block').removeClass('valid');
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error');
    },
    success: function (label, element) {
        label.addClass('help-block valid');
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
    },
    //highlight: function (element, errorClass, validClass) {
    //    $(element).addClass('is-invalid');
    //},
    //unhighlight: function (element, errorClass, validClass) {
    //    $(element).removeClass('is-invalid');
    //},
    //errorPlacement: function (error, element) {
    //    error.addClass('invalid-feedback');
    //    element.closest('.form-group').append(error);
    //}
});