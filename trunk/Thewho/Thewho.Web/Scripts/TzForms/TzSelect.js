//对象级别的开发
; (function($) {
    var defaults = {};

    $.fn.extend({
        TzSelect: function(params) {

            defaults.TzSelect = { "width": 0, "height": 0, "listHeight": 160, "fontSize": 14, "isBold": true, "border": 2, "overflow": "auto", "isSlide": true };

            //真正使用的参数
            var options = jQuery.extend(defaults.TzSelect, params);

            var thisBody = $("body");
            var thisSelectList = $(this);

            for (var i = 0; i < thisSelectList.length; i++) {
                var thisSelect = $(thisSelectList[i]);
                var thisSelectId = thisSelect.attr("id");
                //如果这个select连id都没有 那就给他一个tz + 当前时间戳 + i 为id
                if (thisSelectId === "") {
                    thisSelectId = "tz" + new Date().getTime() + i
                    thisSelect.attr("id", thisSelectId);
                }

                var zIndex = 10000 - i;
                DivInit(thisSelect, thisSelectId, zIndex);
            }

            function DivInit(scobj, scid, zIndex) {
                var divid = "div_" + scid;
                var spantitleid = "span_title_" + scid;
                var ullistid = "ul_list_" + scid;
                var liid = "li_" + scid + "_";
                var spanbtnid = "span_btn_" + scid;
                var inx = inx;

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

                scobj.change(function() {
                    $("#" + spantitleid).text($("#li_" + scobj.val()).text());
                });

                lis.click(function(event) {
                    event.stopPropagation(); //阻止事件向上冒泡
                    var thisli = $(this);
                    scobj.val(thisli.attr("value"));
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
            }
        },
        UnTzSelect: function(params) {
        $("select").prependTo($(".divli").parent()).show();
            $(".divli").remove();
        }
    });
})(jQuery);