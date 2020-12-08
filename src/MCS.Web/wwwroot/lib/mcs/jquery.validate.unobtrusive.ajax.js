$.validator.setDefaults({
    submitHandler: function () {
        var form = $(this.currentForm);
        var button = $(this.submitButton);
        var url = form.attr('action');
        button.find('i').hide();
        button.prepend('<i class="fas fa-circle-notch fa-spin load-tip"></i>');
        button.attr("disabled", true);

        var card = $(form).find('.card');
        if (card.length > 0) {
            card.prepend('<div class="overlay"><i class="fas fa-2x fa-circle-notch fa-spin"></i></div>');
        }

        $.ajax({
            url: url,
            type: "POST",
            data: $(form).serialize(),
            dataType: "json",
            success: function (result) {
                button.find('.load-tip').remove();
                button.attr("disabled", false);
                if (button.find('.success-icon').length <= 0)
                    button.prepend('<i class="fas fa-check-circle success-icon"></i>');
                else
                    button.find('.success-icon').show();
                if (card.length > 0)
                    card.find('.overlay').remove();
                var code = result.code;
                if (result.success) {
                    button.removeClass('btn-default').addClass('btn-success');
                } else {
                    button.removeClass('btn-default').addClass('btn-danger');
                    $(document).Toasts('create', {
                        class: 'bg-danger',
                        title: '提醒',
                        body: result.msg,
                        autohide: true,
                        delay: 750,
                    });
                    button.find('i').show();
                }
                if (code == 302) {
                    window.location.href = result.data.url;
                }
            },
            complete: function (xhr, TS) {
            },
            error: function (xhr) {
                button.find('.load-tip').remove();
                button.attr("disabled", false);
                button.find('i').show();
            }
        });

    }
});