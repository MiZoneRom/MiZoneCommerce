﻿$(function () {
    $('.btn-add-action').click(function () {
        var html = `
                    <tr>
                        <th><input class="form-control" name="Name" type="text" value="" readonly="readonly" /></th>
                        <th><input class="form-control" name="AccessKey" type="text" value="" readonly="readonly" /></th>
                        <th><input class="form-control" name="Id" type="hidden" value="0" /> <input class="btn btn-danger" type="button" value="删除" /></th>
                    </tr>`;
        $('.table-actions tbody').append(html);
    });
});