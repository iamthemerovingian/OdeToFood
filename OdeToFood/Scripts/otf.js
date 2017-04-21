$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("method"),
            type: $form.attr("method"),
            data: $form.serialize()
        }

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"))
            $target.replaceWith(data)
        })

        return false
    }
    $("form[dataa-otf-ajax='true']").submit(ajaxFormSubmit)
})