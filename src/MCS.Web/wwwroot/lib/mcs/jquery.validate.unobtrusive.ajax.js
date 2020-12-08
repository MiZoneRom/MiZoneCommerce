$.validator.setDefaults({
    submitHandler: function () {
        var form = $(this.currentForm);
        var button = $(this.submitButton);
        var url = form.attr('action');
        button.find('i').hide();
        button.prepend('<i class="fas fa-circle-notch fa-spin load-tip"></i>');
        button.attr("disabled", true);

        $.ajax({
            url: url,
            type: "POST",
            data: $(form).serialize(),
            dataType: "json",
            success: function (result) {
                button.find('.load-tip').remove();
                button.attr("disabled", false);
                button.find('i').show();
                var code = result.code;
                if (result.success) {

                } else {
                    $(document).Toasts('create', {
                        class: 'bg-danger',
                        title: '提醒',
                        body: result.msg,
                        autohide: true,
                        delay: 750,
                    });
                }
                if (code == 302) {
                    window.location.href = result.data.url;
                }
            },
            complete: function (xhr, TS) {
            },
            error: function (xhr) {
            }
        });

    }
});