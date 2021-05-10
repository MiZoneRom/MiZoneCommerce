$(function () {
    $('.btn-add-action').click(function () {
        var html = `                                    <tr>
                                        <th>名称</th>
                                        <th>代号</th>
                                        <th>操作</th>
                                    </tr>`;
        $('.table-actions tbody').append(html);
    });
});