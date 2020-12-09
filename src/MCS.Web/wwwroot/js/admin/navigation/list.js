var _navList = [];
var _level = 0;
$(function () {
    loadNavData($('.nav-type .nav-item.active').data('type-id'));
    initClickType();
});

function loadNavData(type) {
    $.ajax({
        url: './ListResult',
        type: 'post',
        data: { type: type},
        dataType: 'json',
        success: function (result) {
            _navList = result.data;
            var childList = _navList.filter(a => a.parentId == 0);
            var html = loadNav(childList, true);
            $('.nav-list').html(html);
            $('.nav-list li i').click(function () {
                var liObj = $(this).parent('.nav-link').parent('.nav-item');
                var id = $(liObj).data('nav-id');
                var isExpanded = $(liObj).attr('tree-expanded') == 'true';
                $(liObj).attr('tree-expanded', !isExpanded);
                if (isExpanded) { $(`#child_${id}`).slideUp(); } else { $(`#child_${id}`).slideDown(); }
            });
        }
    });
}

function loadNav(result, isLevelFirst) {
    if (!isLevelFirst) {
        _level++;
    }
    if (result.length <= 0) {
        return '';
    }
    var _html = '';
    $.each(result, function (i, item) {
        var childList = _navList.filter(a => a.parentId == item.id);
        _html += `<li class="nav-item" data-nav-id="${item.id}" nav-expanded="false">`;
        _html += `<p class="nav-link">`;
        _html += `<div class="icheck-primary">
                        <input type="checkbox" value="" id="check${item.id}">
                        <label for="check${item.id}"></label>
                      </div>`;
        _html += `${getSpaceStr()}`;
        if (childList.length > 0) {
            _html += `<i class="fas fa-caret-right fa-fw"></i>`;
        } else {
            _html += `<i class="fas fa-file-code fa-fw"></i>`;
        }
        _html += `${item.name}<a type="button" class="btn btn-primary btn-xs float-right"  href="./Edit?id=${item.id}">编辑</a>`;
        _html += '</p>';
        _html += `</li>`;
        if (childList.length > 0) {
            _html += `<li class="nav-item" style="display:none;" id="child_${item.id}">`;
            _html += `<ul class="nav nav-pills flex-column nav-list">`;
            _html += `     ${loadNav(childList, false)}`;
            _html += `</ul>`;
            _html += `</li>`;
        }
    });
    if (!isLevelFirst)
        _level = 0;
    return _html;
}

function getSpaceStr() {
    var str = '';
    for (var i = 0; i < _level; i++) {
        str += '<i class="fas fa-ellipsis-h fa-fw" style="color:#e0e0e0"></i>';
    }
    return str;
}

function initClickType() {
    $('.nav-type li').click(function () {
        var type = $(this).data('type-id');
        $(this).addClass('active').siblings().removeClass('active');
        loadNavData(type);
    });

}