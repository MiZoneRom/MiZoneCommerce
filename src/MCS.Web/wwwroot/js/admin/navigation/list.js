$(function () {
    $.ajax({
        url: './ListResult',
        type: 'post',
        data: {},
        dataType: 'json',
        success: function (result) {
            loadNav(result.data);
        }
    });
});

function loadNav(result) {
    var _html = '';
    $.each(result, function (i, item) {
        _html += `<tr>
                            <td class="border-0"><i class="fas fa-caret-right fa-fw"></i>${item.name}</td>
                        </tr>`;
    });
    $('.nav-list').html(_html);
}