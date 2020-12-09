$(function () {
    //下拉列表
    $.fn.select2.defaults.set('width', '100%');
    $('.single-select').select2({
        theme: 'bootstrap4'
    });
    //全选按钮
    $('.checkbox-toggle.check-all').click(function () {
        var clicks = $(this).data('clicks')
        if (clicks) {
            //Uncheck all checkboxes
            $('.cardbox-body input[type=\'checkbox\']').prop('checked', false)
            $('.checkbox-toggle.check-all .far.fa-check-square').removeClass('fa-check-square').addClass('fa-square')
        } else {
            //Check all checkboxes
            $('.cardbox-body input[type=\'checkbox\']').prop('checked', true)
            $('.checkbox-toggle.check-all .far.fa-square').removeClass('fa-square').addClass('fa-check-square')
        }
        $(this).data('clicks', !clicks)
    })
    $('.btn-action-back').click(function () {
        history.back(-1);
    });
});