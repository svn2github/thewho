﻿//对象级别的开发
; (function($) {
    var defaults = {};

    //公共方法
    var TzMethods = {
        initSelect: function(scobj, scid, zIndex, options) {
            var divid = "div_" + scid;
            //表示这个divselect已经存在了 不要重复创建
            if ($("#" + divid).length > 0) {
                alert("该元素已经存在了，不要对一个对象重复调用美化功能");

                //覆盖
                //                var newSelect = scobj.clone(true);
                //                newSelect.val(scobj.val()).insertAfter(scobj.parent().parent()).show();
                //                $("#div_" + scobj.attr("id")).remove();
                //                scobj = newSelect;
                return false;
            }

            var spantitleid = "span_title_" + scid;
            var ullistid = "ul_list_" + scid;
            var liid = "li_" + scid + "_";
            var spanbtnid = "span_btn_" + scid;

            var divwidth = options.width == 0 ? scobj.width() + 32 : options.width + 32;
            var divheight = options.height == 0 ? scobj.height() + 8 : options.height + 12;
            var ulheight = options.listHeight == 0 ? 160 : options.listHeight;

            var listr = '';
            scobj.children("option").each(function(index, it) {
                var item = $(it);
                listr += '<li id="' + liid + item.val() + '" class="li" value="' + item.val() + '">' + item.text() + '</li>';

            });

            var scdiv = $("<div/>").attr("id", divid + "temp").addClass("divli").css({
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

            scdiv.html(spanold + spantitle + ullist + spanbtn);
            scdiv.find(".subnav")

            scobj.hide();
            scobj.wrap(scdiv);

            //将id设置回正确
            $("#" + divid + "temp").attr("id", divid);
            /*--------------------------------------------------*/
            scdiv = $("#" + divid);
            spantitle = $("#" + spantitleid);
            ullist = $("#" + ullistid);
            var lis = ullist.find("li");
            spanbtn = $("#" + spanbtnid);

            $("#" + scid).live("change", function() {
                spantitle.text($("#li_" + scid + "_" + scobj.val()).text());
            });

            //绑定自定义事件
            //            $("#" + scid).bind('SetValue', function(e, data) {
            //                scobj.val(data);
            //                spantitle.text($("#li_" + scid + "_" + data).text());
            //            });

            lis.click(function(event) {
                event.stopPropagation(); //阻止事件向上冒泡
                var thisli = $(this);
                scobj.val(thisli.attr("value"));
                //spantitle.text(thisli.text());
                scobj.change();

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

            scdiv.click(function() {
                spanbtn.click();
            }).hover(function() {
                scdiv.addClass("divlihover");
            }, function() {
                scdiv.removeClass("divlihover");
            });

            //默认值
            $("#" + liid + scobj.val()).click();

            function show() {
                options.isSlide ? ullist.slideDown() : ullist.show();
            }
            function hide() {
                options.isSlide ? ullist.slideUp() : ullist.hide();
            }
            function toggle() {
                options.isSlide ? ullist.slideToggle() : ullist.toggle();
            }
        },
        val: function(scid, value) {
            $("#" + scid).val(value);
            $("#span_title_" + scid).text($("#li_" + scid + "_" + value).text());
        },
        destroy: function() {
            $("select").prependTo($(".divli").parent()).show();
            $(".divli").remove();
        }
    };

    $.fn.extend({
        TzSelect: function(params) {
            defaults.TzSelect = { "width": 0, "height": 0, "listHeight": 160, "fontSize": 14, "isBold": true, "border": 2, "overflow": "auto", "isSlide": true };
            //真正使用的参数
            var options = jQuery.extend(defaults.TzSelect, params);

            this.each(function(index, item) { //这里可以写成 return this.each(function(index, item) { 加return  使方法可链
                var thisSelect = $(item);
                var thisSelectId = item.id;
                //如果这个select连id都没有 那就给他一个tz + 当前时间戳 + index 为id
                if (thisSelectId === "") {
                    thisSelectId = "tz" + new Date().getTime() + index;
                    thisSelect.attr("id", thisSelectId);
                }
                var zIndex = 10000 - index;
                TzMethods.initSelect(thisSelect, thisSelectId, zIndex, options);
            });
            return this; //也是为了可链
        },
        SetTzSelect: function(value) {
            $("#li_" + this.attr("id") + "_" + value).click();
            return this; //也是为了可链
        },
        UnTzSelect: function() {
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
        },
        TzCheckBox: function(params) {

        },
        TzRadio: function(params) {

        },
        TzFile: function(params) {

        }
    });

    // 定义暴露format函数
    $.fn.TzSelect.SetValue = function(val) {
        alert(txt);

    };
})(jQuery);
