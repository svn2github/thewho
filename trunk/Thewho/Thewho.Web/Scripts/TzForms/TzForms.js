; (function($) {
    /* TzSelect */
    $.fn.TzSelect = function(params) {
        var options = jQuery.extend($.fn.TzSelect.Config, params);
        this.each(function(index, item) { //这里可以写成 return this.each(function(index, item) { 加return  使方法可链
            var thisSelect = $(item);
            var thisSelectId = item.id;
            //如果这个select连id都没有 那就给他一个tz + 当前时间戳 + index 为id
            if (thisSelectId === "") {
                thisSelectId = "tz" + new Date().getTime() + index;
                thisSelect.attr("id", thisSelectId);
            }
            var zIndex = 10000 - index;
            _TzSelect_Init(thisSelect, thisSelectId, zIndex, options);
        });
        return this; //也是为了可链
    };
    //设置选中值 公共函数
    $.fn.TzSelectSet = function(value) {
        this.val(value);
        $("#li_" + this.attr("id") + "_" + value).click();
    };
    //重新加载内容 公共函数
    $.fn.TzSelectAgain = function(value) {

    };
    //卸载 公共函数
    $.fn.TzSelectUnLoad = function() {
        this.each(function(index, item) { //这里可以写成 return this.each(function(index, item) { 加return  使方法可链
            var thisSelect = $(item);
            var thisSelectId = item.id;
            //如果这个select连id都没有 那就给他一个tz + 当前时间戳 + index 为id
            if (thisSelectId === "") {
                thisSelectId = "tz" + new Date().getTime() + index;
                thisSelect.attr("id", thisSelectId);
            }

            var newSelect = thisSelect.clone(true);
            newSelect.val(thisSelect.val()).insertAfter(thisSelect.parent().parent()).show();
            $("#div_" + thisSelect.attr("id")).remove();
            //thisSelect.parent().parent().remove();
        });
        return this; //也是为了可链
    };
    //默认参数 公共函数
    $.fn.TzSelect.Config = {
        "width": 0,
        "height": 0,
        "listHeight": 160,
        "fontSize": 14,
        "isBold": true,
        "border": 2,
        "overflow": "auto",
        "isSlide": true
    };

    //将下面的私有函数 开放公共接口
    $.fn.TzSelect.Init = function() {
        _TzSelect_Init();
    };

    //加载 私有
    function _TzSelect_Init(obj, objid, zIndex, options) {
        var divid = "div_" + objid;
        var spantitleid = "span_title_" + objid;
        var ullistid = "ul_list_" + objid;
        var liid = "li_" + objid + "_";
        var spanbtnid = "span_btn_" + objid;

        var divwidth = options.width == 0 ? obj.width() + 32 : options.width + 32;
        var divheight = options.height == 0 ? obj.height() + 8 : options.height + 12;
        var ulheight = options.listHeight == 0 ? 160 : options.listHeight;

        var listr = '';
        obj.children("option").each(function(index, it) {
            var item = $(it);
            listr += '<li id="' + liid + item.val() + '" class="li" value="' + item.val() + '">' + item.text() + '</li>';

        });

        var div = $("<div/>").attr("id", divid + "temp").addClass("divli").css({
            "width": divwidth + "px",
            "height": divheight + "px",
            "line-height": divheight + "px",
            "border-width": options.border + "px",
            "font-size": options.fontSize + "px",
            "font-weight": options.isBold ? "bold" : "normal",
            "z-index": zIndex
        });

        var spanold = '<span class="oldselect"></span>';
        var spantitle = '<span class="spantitle" id="' + spantitleid + '">Loading...</span>';
        var ullist = '<ul class="subnav" id="' + ullistid + '" style="width:' + divwidth + 'px; height:' + ulheight + 'px;top: ' + divheight + 'px;border-width:' + options.border + 'px;border-top:0px; margin-left:-' + options.border + 'px;overflow-y: ' + options.overflow + ';">' + listr + '</ul>';
        var spanbtn = '<span class="spanbtn" id="' + spanbtnid + '"><span class="spanbtnicon"></span></span>';

        div.html(spanold + spantitle + ullist + spanbtn);

        obj.hide();
        obj.wrap(div);

        //将id设置回正确
        $("#" + divid + "temp").attr("id", divid);
        /*--------------------------------------------------*/
        div = $("#" + divid);
        spantitle = $("#" + spantitleid);
        ullist = $("#" + ullistid);
        var lis = ullist.find("li");
        spanbtn = $("#" + spanbtnid);

        obj.live("change", function() {
            spantitle.text($("#li_" + scid + "_" + obj.val()).text());
        });

        lis.click(function(event) {
            event.stopPropagation(); //阻止事件向上冒泡
            var thisli = $(this);
            obj.val(thisli.attr("value"));
            spantitle.text(thisli.text());

            lis.removeClass("licheck");
            thisli.addClass("licheck");
            hide();
            //return false;//这种也可以阻止事件向上冒泡
        }).hover(function() {
            $(this).addClass("lihover");
        }, function() {
            $(this).removeClass("lihover");
        });

        spanbtn.click(function(event) {
            event.stopPropagation(); //阻止事件向上冒泡
            toggle();
        });

        div.click(function() {
            spanbtn.click();
        }).hover(function() {
            div.addClass("divlihover");
        }, function() {
            div.removeClass("divlihover");
        });

        //默认值
        $("#" + liid + obj.val()).click();

        function show() {
            options.isSlide ? ullist.slideDown() : ullist.show();
        }
        function hide() {
            options.isSlide ? ullist.slideUp() : ullist.hide();
        }
        function toggle() {
            options.isSlide ? ullist.slideToggle() : ullist.toggle();
        }
    }
    /* TzSelect End */

})(jQuery);