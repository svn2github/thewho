////参考地址http://www.iteye.com/topic/545971

////类级别的开发
//jQuery.dialog = {
//    alert: function() {
//        alert("弹出层");
//    },
//    info: function(v) {
//        alert(v);
//    }
//};


////对象级别的开发
//(function($) {
//    $.fn.extend({
//        haha: function() {
//            alert($(this).attr("ID"));
//        }
//    })
//})(jQuery);

/*
1、始终将您的插件放在一个闭包中： (function( $ ){ })( jQuery );

2、在你的插件function的作用域里不要重复封装this关键字

3、除非你的插件要返回一个固定值，否则使插件总是返回this关键字以保持连续性

4、与其使用大量的参数，不如将你的设置传入一个可扩展你插件默认值的object对象中。

5、不要使一个插件具有超过1个命名空间，导致jquery.fn对象混乱。

6、始终命名（namespace）你的方法、事件和数据。

*/


/*
（1）插件的推荐命名方法为：jquery.[插件名].js

（2）所有的对象方法都应当附加到JQuery.fn对象上面，而所有的全局函数都应当附加到JQuery对象本身上。

（3）在插件内部，this指向的是当前通过选择器获取的JQuery对象，而不像一般方法那样，内部的this指向的是DOM元素。

（4）可以通过this.each 来遍历所有的元素

（5）所有方法或函数插件，都应当以分号结尾，否则压缩的时候可能会出现问题。为了更加保险写，可以在插件头部添加一个分号（；），以免他们的不规范代码给插件带来 影响。

（6）插件应该返回一个JQuery对象，以便保证插件的可链式操作。

（7）避免在插件内部使用$作为JQuery对象的别名，而应当使用完整的JQuery来表示。这样可以避免冲突。

*/

/*   插件名：tbox   */
// defaults:默认参数
//var tboxConfig = {};
//tboxConfig.defaults = { "id": "cover", "type": "full", "color": "#000", "filter": "3", "islock": false };
// tip:弹出小提示 自动消失;  alert:弹出提示; open:打开iframe页面;
//jQuery.tbox = {
//    tip: function() {
//        //$.cover.show({ "id": "c_tip", "color": "red" });
//        $.cover.show({ "color": "red" });
//        setTimeout(" $.cover.hide()", 3000);
//    },
//    alert: function() {
//        //$.cover.show({ "id": "c_alert", "color": "#000", "lock": false});

//        $.dialog.tip("日志删除成功！");
//    },
//    open: function() {
//        //$.cover.show({ "id": "c_open", "color": "#000", "lock": false});
//    }
//};


/*   插件名：cover  版本1: 这个版本会创建多个遮盖层(根据ID)  */
// defaults:默认参数
//var coverConfig = {};    //cache 缓存: 如果为true 代表如果之前有过一个id为xxx的层 就不再重新new层(会继续继承之前的属性)
//coverConfig.defaults = { "id": "cover", "type": "full", "color": "#000", "filter": "3", "lock": false, "cache": true };
// 插件的函数 show:显示弹出层; hide:隐藏弹出层
//(function($) {
//    jQuery.cover1 = {
//        show: function(params) {

//            var coverConfig = {};
//            coverConfig.defaults = { "id": "cover", "type": "full", "color": "#000", "filter": "3", "lock": false };

//            var options = jQuery.extend(coverConfig.defaults, params);
//            //对象属性初始化
//            this.id = options.id;           //遮盖层的ID
//            this.type = options.type;       //遮盖层类型(readonly)
//            this.color = options.color;     //背景颜色
//            this.filter = options.filter;   //透明度
//            this.lock = options.lock;   //锁定(如果为假,代表双击会隐藏);
//            
//            //层创建初始化
//            var div_cover = jQuery("<div/>").attr("id", "div_" + this.id).addClass("div_cover_" + this.type).css({
//                "background-color": this.color,
//                "filter": "alpha(opacity = " + this.filter + "0)",
//                "opacity": "0." + this.filter + ""
//            }).appendTo(jQuery("body"));
//            var iframe_cover = jQuery("<iframe/>").attr({ "id": "iframe_" + this.id, "frameborder": "0" }).addClass("iframe_cover_" + this.type).appendTo(jQuery("body"));

//            //是否启用层锁定
//            if (this.lock == "false" || this.lock == false) {
//                div_cover.bind("dblclick", function() {
//                    div_cover.hide();
//                    iframe_cover.hide();
//                    //卸载改变窗口大小改变事件
//                    jQuery(window).unbind("resize");
//                });
//            }
//            //        //隐藏方法
//            //        this.hide = function() {
//            //            div_cover.hide();
//            //            iframe_cover.hide();
//            //            //卸载改变窗口大小改变事件
//            //            jQuery(window).unbind("resize");
//            //        };
//            //        //隐藏方法(内部使用)
//            //        var hide = this.hide;


//            //适应窗口大小改变方法
//            this.resize = function() {
//                div_cover.width(jQuery(window).width()).height(jQuery("body").height());
//                iframe_cover.width(jQuery(window).width()).height(jQuery("body").height());
//            }
//            //适应窗口大小改变方法(内部使用)
//            var resize = this.resize;
//            //绑定改变窗口大小改变事件
//            jQuery(window).bind("resize", function() {
//                resize();
//            });


//            //iframe弹出
//            iframe_cover.show();
//            //div弹出
//            div_cover.show();
//            //将div平铺到body
//            resize();
//        }
//    };
//})(jQuery);



/*   插件名：cover  版本2: 这个版本会只会创建一个遮盖层 需要打开时可以传入参数来达到不同的显示效果  */
; (function($) {
    //层创建初始化 遮盖层永远只存在一个的特性  所以层就在此处new出
    var div_cover = jQuery("<div/>").addClass("div_cover").appendTo(jQuery("body"));
    var iframe_cover = jQuery("<iframe/>").addClass("iframe_cover").appendTo(jQuery("body"));

    //适应窗口大小改变方法
    var resize = function() {
        div_cover.width(jQuery(window).width()).height(jQuery(document).height());
        iframe_cover.width(jQuery(window).width()).height(jQuery(document).height());
    }

    //绑定改变窗口大小改变事件
    jQuery(window).bind("resize", function() {
        resize();
    });

    jQuery.cover = {
        show: function(params) {

            defaults.cover = { "id": "cover", "color": "#000", "filter": "3" };
            //真正使用的参数
            var options = jQuery.extend(defaults.cover, params);

            //对象属性初始化
            this.id = options.id;           //遮盖层的ID
            this.color = options.color;     //背景颜色
            this.filter = options.filter;   //透明度

            //层创建初始化
            div_cover.attr("id", "div_" + this.id).css({
                "background-color": this.color,
                "filter": "alpha(opacity = " + this.filter + "0)",
                "opacity": "0." + this.filter + ""
            });
            iframe_cover.attr({ "id": "iframe_" + this.id, "frameborder": "0" });

            //平铺div和iframe
            resize();
            //div和iframe显示
            iframe_cover.show();
            //iframe_cover.fadeIn(1000);
            //div_cover.fadeIn(1000);
            div_cover.show();
        },
        close: function(timeout) {
            if (timeout > 0) {
                setTimeout("$('#" + div_cover.attr("id") + "').hide();$('#" + iframe_cover.attr("id") + "').hide();", timeout);
            }
            else {
                iframe_cover.hide();
                div_cover.hide();
            }
        },
        resize: function() {
            resize();
        }
    }
})(jQuery);

/*   插件名：dialog   function中的$符号 其实只是在对象级别插件有用处?  毕竟$代表当调用的对象*/ 
; (function($) {

    // var div_dialog = jQuery("<div/>").appendTo(jQuery("body"));

    /* 私有参数 */
    //创建div
    function newdiv() {
        return jQuery("<div/>").appendTo(jQuery("body"));
    }

    //创建按钮
    function newbutton(thisdiv, buttons) {
        jQuery.each(buttons, function(index, item) {
            //jQuery("<input/>").attr({ "type": "button", "value": item.text }).click(function() { eval(item.fun + "();"); }).appendTo(jQuery("#tip"));
            jQuery("<input/>").attr({ "type": "button", "value": item.text }).click(function() {
                item.click(thisdiv);
                if (item.close) {
                    jQuery.dialog.close(thisdiv, 0);
                }
            }).appendTo(thisdiv);
        });
    }

    //适应窗口大小改变方法
    function resize(e) {
        //e.css({ "top": ((jQuery(window).height()  - (e.height()*2))/ 2) + "px", "left": ((jQuery(window).width() - e.width()) / 2) + "px" });
        e.css({ "top": ((jQuery(window).height() - e.height()) / 2) + "px", "left": ((jQuery(window).width() - e.width()) / 2) + "px" });
    }
    //绑定改变窗口大小改变事件
    function bindresize(e) {
        jQuery(window).bind("resize", function() {
            resize(e);
        });
    }
    //dialog跟随滚动条滚动的方法
    function bindscroll(e) {
        //如果是IE6的话 窗体跟随滚动的就需要写事件了
        if ($.browser.msie && $.browser.version == "6.0") {
            $(window).scroll(function() {
                var bodyTop = 0;
                if (typeof window.pageYOffset != 'undefined') {
                    bodyTop = window.pageYOffset;
                } else if (typeof document.compatMode != 'undefined' && document.compatMode != 'BackCompat') {
                    bodyTop = document.documentElement.scrollTop;
                } else if (typeof document.body != 'undefined') {
                    bodyTop = document.body.scrollTop;
                }
                e.css("top", 250 + bodyTop);
            });
        }
    }

    //dialog拖动方法
    function mousedown(e) {
        var isdown = false;
        var offsetX = 0;
        var offsetY = 0;
        e.mousedown(function() {
            offsetX = event.offsetX;
            offsetY = event.offsetY;
            isdown = true;
            $(document).mousemove(function() {
                if (isdown) {
                    var x = event.clientX - offsetX;
                    var y = event.clientY - offsetY;
                    e.css("left", x);
                    e.css("top", y);
                } else {
                    return;
                }
            });
        });
        e.mouseup(function() {
            isdown = false;
        });
    }

    //关闭div
    //e 是需要关闭的div    cover 是否有需要关闭的遮盖   timeout 自动延迟关闭 0是立刻关闭
    function close(e, cover, timeout) {
        //setTimeout("$('#" + e.attr("id") + "').hide();", timeout);//隐藏
        setTimeout("$('#" + e.attr("id") + "').remove();", timeout); //销毁
    }



    //参数 title:弹出层标题(tip可以没有)  content:内容(text或者html) params:参数集合
    //id 为弹出层div的id
    //timeout 为消失时间 以毫秒为单位 如果为0 就永运不消失 需要手动关闭
    //position 出现的位置 正中间:middle  页面头部:top  页面底部:bottom  右侧: right 左侧left
    //drag 弹出层是否可以拖动  true为可以 false为不可以
    //scroll 弹出成是否可以跟随浏览器滚动 true为可以 false为不可以
    //icon 默认的图标 info error success warning loading
    //width　宽度
    //height 高度
    //buttons 按钮  buttons:{"确定":"yes","下一步":"next","取消":"no"}

    jQuery.dialog = {
        //tip原型 用来弹出提示信息 轻便的弹出层  一般情况下会自动隐藏
        tip: function(content, params) {
            //$.cover.show();
            defaults.tips = { "id": "tip", "timeout": "3000" };
            //真正使用的参数
            var options = jQuery.extend(defaults.tips, params);

            this.div = newdiv();
            this.id = options.id;
            this.timeout = options.timeout;
            this.cover = options.cover;

            this.div.attr("id", this.id).addClass("div_tip").css({ "height": "400px" });

            this.div.html(content);
            resize(this.div);
            bindresize(this.div);
            //mousedown(this.div);

            this.div.show();
            //newbutton(this.div, options.buttons);

            if (this.timeout > 0) {
                close(this.div, false, this.timeout);
            }
        },
        //alert原型 用来弹出对话框 普通弹出层 默认带样式  默认带关闭按钮等 
        alert: function(title, content, params) {
            defaults.alerts = { "id": "alert", "timeout": "0", "buttons": [{ "text": "确定", "click": qd, "close": true }, { "text": "取消", "click": qx, "close": true}] };
            //真正使用的参数
            var options = jQuery.extend(defaults.alerts, params);
            this.div = newdiv();
            this.id = options.id;
            this.timeout = options.timeout;
            this.cover = options.cover;

            this.div.attr("id", this.id).addClass("div_alert").css({ "height": "400px" });
            this.div.html(title + content);
            resize(this.div);
            bindresize(this.div);
            mousedown(this.div);

            this.div.show();
            newbutton(this.div, options.buttons);

            if (this.timeout > 0) {
                close(this.div,this.timeout);
            }
        },
        //open原型 用来弹出iframe 默认带样式  默认带关闭按钮等 
        open: function() {

        },
        close: function(e, timeout) {
            close(e, timeout);
        }
    }
})(jQuery);