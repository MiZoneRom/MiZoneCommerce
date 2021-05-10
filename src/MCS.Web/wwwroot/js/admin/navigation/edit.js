$(function () {
    $('.table-actions').on('click', '.btn-delete', function () {
        $(this).parents('tr').remove();
    });

    $('.btn-add-action').click(function () {
        var index = $('.table-actions tbody tr').last();
        if (index.length > 0) {
            index = $(index).data('index')+1;
        } else {
            index = 0;
        }
        var html = `
                    <tr data-index='${index}'>
                        <th><input class="form-control" name="Actions[${index}].Name" type="text" value="" /></th>
                        <th><input class="form-control" name="Actions[${index}].AccessKey" type="text" value="" /></th>
                        <th><input class="form-control" name="Actions[${index}].Id" type="hidden" value="0" /> <input class="btn btn-danger btn-delete" type="button" value="删除" /></th>
                    </tr>`;
        $('.table-actions tbody').append(html);
    });
});