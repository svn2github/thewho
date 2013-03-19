//对象级别的开发
; (function($) {
    var defaults = {};
    $.fn.extend({
        NewSelect: function(params) {

            defaults.NewSelect = { "overflow": "auto", "isSlide": true };

            var options = jQuery.extend(defaults.NewSelect, params);

            var thisBody = $("body");
            var thisSelectList = $(this);

            for (var i = 0; i < thisSelectList.length; i++) {
                var thisSelect = $(thisSelectList[i]);
                var thisSelectId = thisSelect.attr("id");
                DivInit(thisSelect, thisSelectId);
            }

            function DivInit(sobj, sid) {
                var boxid = "box" + sid;
                var scid = "sc" + sid;
                var ifaid = "ifa" + sid;
                var opsid = "ops" + sid;
                var opid = "op" + sid;

                var boxwidth = 57;
                var boxheight = 26;

                var box = $("<div/>").attr("id", boxid).css(
                {
                    "width": "77px",
                    "height": "26px"
                }).addClass("select_box");
                sobj.wrap(box);

                var sc = $("<div/>").attr("id", scid).css(
                {
                    "width": boxwidth,
                    "height": boxheight,
                    "top": sobj.offset().top - 5,
                    "left": sobj.offset().left
                }).addClass("tag_select");
                sc.appendTo(thisBody);

                var ifa = $("<iframe/>").attr("id", ifaid).css(
                {
                    "width": boxwidth,
                    "height": boxheight,
                    "top": sobj.offset().top - 5,
                    "left": sobj.offset().left
                }).addClass("nice-ifa");
                ifa.appendTo(thisBody);

                var ops = $("<ul/>").attr("id", opsid).css({
                    "overflow-y": options.overflow,
                    "top": sc.offset().top + 24,
                    "left": sc.offset().left
                }).addClass("tag_options");
                ops.appendTo(thisBody);


                sobj.children("option").each(function(index, it) {
                    var item = $(it);
                    $("<li/>").attr("id", opid + item.val()).attr("value", item.val()).text(item.text()).addClass("open").appendTo(ops);
                });

                sc.click(function() {
                    if (ops.is(":hidden")) {
                        ops.find("li").removeClass("open_selected").removeClass("open_hover");

                        $("#" + opid + sobj.val()).addClass("open_selected");

                        show();
                        sc.addClass("tag_select_open");
                    }
                    else {
                        hide();
                        sc.removeClass("tag_select_open");
                    }
                });

                var opli = ops.find("li");
                opli.mouseover(function() {
                    $(this).addClass("open_hover");
                }).mouseout(function() {
                    $(this).removeClass("open_hover");
                }).click(function() {

                    opli.removeClass("open_selected").removeClass("open_hover");

                    $(this).removeClass("open_hover").addClass("open_selected");

                    var thisop = $(this);
                    sobj.val(thisop.attr("value"));
                    sc.text(thisop.text()).removeClass("tag_select_open");
                    hide();
                });




                sobj.change(function() {
                    var thisop = $("#" + opid + sobj.val());
                    sc.text(thisop.text());
                });


                function show() {
                    options.isSlide ? ops.slideDown() : ops.show();
                }
                function hide() {
                    options.isSlide ? ops.slideUp() : ops.hide();
                }

                //默认值
                $("#" + opid + sobj.val()).click();

                //隐藏原始控件
                sobj.hide();
            }
        }
    });
})(jQuery);