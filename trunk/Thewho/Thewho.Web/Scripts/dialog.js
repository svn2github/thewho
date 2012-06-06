jQuery(function() {
    s = new cover({ "id": "111" });
    s2 = new cover({ "id": "222", "color": "#FF3333" });
    s3 = new cover({ "id": "333", "color": "blue", "filter": "3", "islock": true });
    s4 = new cover({ "id": "444", "color": "#FF3300", "filter": "3","islock": true });
    //s.hide();
});

function aaa() {

    s.show();
    
}
function bbb() {
    //var s = new cover({ "id": "222","color":"blue" });
    s2.show();
    jQuery("#div_222").append("<div class='yesorno' onclick='s2.hide();' id='floater_service'>111</div>")
}
function ccc() {
    s3.show();
}
function ddd() {
    s4.show();
}


/* 遮盖层类 */
function cover(params) {

    //默认参数初始化
    //var default_params = { "id": "cover", "type": "full", "color": "#000", "filter": "3", "islock": false };
    var options = jQuery.extend(defaults.cover, params);
    
    //对象属性初始化
    this.id = options.id;           //遮盖层的ID
    this.type = options.type;       //遮盖层类型(readonly)
    this.color = options.color;     //背景颜色
    this.filter = options.filter;   //透明度
    this.islock = options.islock;   //双击是否无效;
    
    //层创建初始化
    var div_cover = jQuery("<div/>").attr("id", "div_" + this.id).addClass("div_cover_" + this.type).appendTo(jQuery("body")).css({
            "background-color": this.color,
            "filter": "alpha(opacity = " + this.filter + "0)",
            "opacity": "0." + this.filter + ""
        }).appendTo(jQuery("body"));
        var iframe_cover = jQuery("<iframe/>").attr({ "id": "iframe_" + this.id, "frameborder": "0" }).addClass("iframe_cover_" + this.type).appendTo(jQuery("body"));
    //var iframe_cover = $("<iframe/>").attr({ "id": "iframe_" + this.id, "frameborder": "0", "vspace": "0", "hspace": "0", "marginwidth": "0", "marginheight": "0", "framespacing": "0", "frameborder": "0", "scrolling": "no" }).addClass("iframe_cover_" + this.type).appendTo($("body"));
    //是否启用层锁定
    if (this.islock == "false" || this.islock == false) {
        div_cover.bind("dblclick", function() {
            hide();
        });
    }
    
    //弹出方法
    this.show = function() {
        //iframe弹出
        iframe_cover.show();
        //div弹出
        div_cover.show();
        //设置宽度和高度
        resize();
        //绑定改变窗口大小改变事件
        jQuery(window).bind("resize", function() {
            resize();
        });
        //if (this.type == "time") {
        //setTimeout(hide, 3000);
        //}
    }
    //隐藏方法
    this.hide = function() {
        div_cover.hide();
        iframe_cover.hide();
        //卸载改变窗口大小改变事件
        jQuery(window).unbind("resize");
    };
    //隐藏方法(内部使用)
    var hide = this.hide;

    //适应窗口大小改变方法
    this.resize = function() {
    div_cover.width(jQuery(window).width()).height(jQuery("body").height());
    iframe_cover.width(jQuery(window).width()).height(jQuery("body").height());
    }
    //适应窗口大小改变方法(内部使用)
    var resize = this.resize;
}

//function easy_cover(id) {
//    //遮盖层对象
//    $("<div/>").attr("id", "div_" + id).addClass("cover_easy").width($(window).width()).height($("body").height()).show().dblclick(function() { $(this).hide(); }).appendTo($("body"));
//}