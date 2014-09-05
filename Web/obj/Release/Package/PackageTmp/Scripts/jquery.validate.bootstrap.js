$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest(".form-group").addClass("has-error").addClass("has-feedback");
    },
    unhighlight: function (element) {
        $(element).closest(".form-group").removeClass("has-error").removeClass("has-feedback");
    }
});