var _navList = [];
var _level = 0;
$(function () {
    $.ajax({
        url: './ListResult',
        type: 'post',
        data: {},
        dataType: 'json',
        success: function (result) {
            _navList = result.data;
            var childList = _navList.filter(a => a.parentId == 0);
            var html = loadNav(childList);
            $('.nav-list').html(html);
        }
    });
});

function loadNav(result) {
    if (result.length <= 0) {
        _level = 0;
        return '';
    }
    var _html = '';
    $.each(result, function (i, item) {
        var childList = _navList.filter(a => a.parentId == item.id);
        _html += `<li class="nav-item">`;
        _html += `<a class="nav-link">`;
        if (childList.length > 0) {
            _html += `     <i class="fas fa-caret-right fa-fw"></i>`;
        } else {
            _html += `${getSpaceStr()}`;
        }
        _html += `${item.name}<button type="button" class="btn btn-primary float-right">Primary</button>`;
        _html += '</a>';
        _html += `</li>`;
        if (childList.length > 0) {
            _html += `<li class="nav-item">`;
            _html += `<ul class="nav nav-pills flex-column nav-list">`;
            _html += `     ${loadNav(childList)}`;
            _html += `</ul>`;
            _html += `</li>`;
        }
    });
    _level++;
    return _html;
}

function getSpaceStr() {
    var str = '';
    for (var i = 0; i < _level; i++) {
        str += '&nbsp;&nbsp;';
    }
    return str;
}