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
    //返回
    $('.btn-action-back').click(function () {
        history.back(-1);
    });
    $('.dual-select').bootstrapDualListbox({
        nonSelectedListLabel: '未选中',//未选中list的label，默认false；
        selectedListLabel: '已选中',//已选中list的label，默认false；
        showFilterInputs: true,//是否显示过滤的input输入框，默认true显示；为false则过滤相关的内容不起作用、不显示；
        filterTextClear: '清空过滤条件',//清空过滤条件按钮的文本，默认'show all'，可替换为其他文本；
        filterPlaceHolder: '过滤条件',//过滤条件input框的placeholder，可自定义内容，默认为'Filter',
        moveOnSelect: false,//是否移动选中的option；为false时，moveSelected和removeSelected的按钮显示、生效；默认为true；为true只能光标连续选取，松开鼠标，选中的项会移动；为false则可配合键盘的Ctrl和Shift使用，点击moveSelectedLabel和removeSelectedLabel的按钮，option才会移动；
        moveAllLabel: '添加全部option',//添加全部option按钮的label，默认'Move all'
        moveSelectedLabel: '添加选中的option',//添加选中option按钮的label，默认'Move selected'
        removeAllLabel: '移除全部option',//移除全部option按钮的label，默认'Remove all'
        removeSelectedLabel: '移除选中option',//移除选中option按钮的label，默认'Remove selected'
        preserveSelectionOnMove: 'moved',//'moved'或'all'时，展示移动到target列表中的元素（背景色显示），默认false，不展示；没看到'moved'和'all'的区别；
        helperSelectNamePostfix: '_ast',//为selector的name的后缀为'_helper'，未选中的list后面拼接1，已选中的拼接2；也可通过setHelperSelectNamePostfix(value, refresh)方法修改；
        selectorMinimalHeight: 260,//selector的最小height，大概小于260px时，为默认值固定高度，更大值则selector高度会增大；不知道默认值的的大小及height的单位
        infoText: '选中/未选中option共 {0} 项',//不过滤时，选中/未选中option共几项；默认为'Showing all {0}'；
        infoTextFiltered: '从 {1} 项 筛选 {0} 项',//过滤信息，默认'<span class="label label-warning">Filtered</span> {0} from {1}'。从m项中筛选n项；
        infoTextEmpty: 'Empty list',//当筛选条件为 '' ，且选中/未选中列表无option时显示的内容；默认为'Empty list'；
    });
});