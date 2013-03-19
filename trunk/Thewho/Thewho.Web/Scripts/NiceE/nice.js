//对象级别的开发
; (function($) {
    var defaults = {};

    //thisBody.click(function() {
    //    $(".nice-ops").hide();
    //});

    $.fn.extend({
        NiceSelect: function(params) {

            defaults.NiceSelect = { "width": 0, "height": 0, "listHeight": 160, "overflow": "auto", "isSlide": true, "border": 2 };

            //真正使用的参数
            var options = jQuery.extend(defaults.NiceSelect, params);

            var thisBody = $("body");
            var thisSelectList = $(this);

            for (var i = 0; i < thisSelectList.length; i++) {
                var thisSelect = $(thisSelectList[i]);
                var thisSelectId = thisSelect.attr("id");
                DivInit(thisSelect, thisSelectId);
            }

            function DivInit(scobj, scid) {
                var boxid = "box" + scid;
                var scid = "sc" + scid;
                var ifaid = "ifa" + scid;
                var opsid = "ops" + scid;
                var opid = "op" + scid;

                var boxwidth = options.width == 0 ? scobj.width() + 12 : options.width + 12;
                var boxheight = options.height == 0 ? scobj.height() + 8 : options.height + 12;

                var box = $("<div/>").attr("id", boxid).css(
                {
                    "width": boxwidth + (options.border * 2),
                    "height": boxheight + (options.border * 2)
                }).addClass("nice-sc-box");
                scobj.wrap(box);

                //new出div 
                var sc = $("<div/>").attr("id", scid).css(
                {
                    "width": boxwidth,
                    "height": boxheight,
                    "top": scobj.offset().top,
                    "left": scobj.offset().left,
                    "border-width": options.border + "px"
                }).addClass("nice-sc");
                sc.appendTo(thisBody);


                //new出iframe 遮盖住select
                var ifa = $("<iframe/>").attr("id", ifaid).css(
                {
                    "width": boxwidth,
                    "height": boxheight,
                    "top": scobj.offset().top,
                    "left": scobj.offset().left
                }).addClass("nice-ifa");
                ifa.appendTo(thisBody);


                //new出装项的集合 并定位到遮盖select的div的下面
                var ops = $("<div/>").attr("id", opsid).css({
                    "width": boxwidth,
                    "height": options.listHeight,
                    "overflow-y": options.overflow,
                    "top": sc.offset().top + 26 + options.border,
                    "left": sc.offset().left,
                    "border-width": options.border + "px",
                    "border-top": "0px"
                }).addClass("nice-ops");
                ops.appendTo(thisBody);

                //new出对应option的div项
                scobj.children("option").each(function(index, it) {
                    var item = $(it);
                    $("<div/>").attr("id", opid + item.val()).attr("value", item.val()).text(item.text()).addClass("nice-op").appendTo(ops);
                });

                //绑定sdiv单击事件
                sc.click(function() {
                    if (ops.is(":hidden")) {
                        $("#" + opsid + " div").removeClass("nice-op-check").removeClass("nice-op-in");
                        $("#" + opid + scobj.val()).addClass("nice-op-check").addClass("nice-op-in");
                        show();
                        sc.addClass("nice-sc-in");
                    }
                    else {
                        hide();
                        sc.removeClass("nice-sc-in");
                    }
                });

                //绑定option的事件
                ops.find("div").mouseover(function() {
                    $(this).addClass("nice-op-in");
                }).mouseout(function() {
                    $(this).removeClass("nice-op-in");
                }).click(function() {
                    var thisop = $(this);
                    scobj.val(thisop.attr("value"));
                    sc.text(thisop.text()).removeClass("nice-sc-in");
                    hide();
                });

                //绑定select change事件
                scobj.change(function() {
                    var thisop = $("#" + opid + scobj.val());
                    sc.text(thisop.text()).removeClass("nice-sc-in");
                });


                function show() {
                    options.isSlide ? ops.slideDown() : ops.show();
                }
                function hide() {
                    options.isSlide ? ops.slideUp() : ops.hide();
                }

                //默认值
                $("#" + opid + scobj.val()).click();

                //隐藏原始控件
                //scobj.hide();
                //scobj.css("height", "0px");


                $(document).keydown(function(event) {
                    if (event.which === 37) {
                        //alert("左");
                    }
                    if (event.which === 38) {
                        //alert("上");
                    }
                    if (event.which === 39) {
                        //alert("右");
                    }
                    if (event.which === 40) {
                        //alert("下");
                        if (ops.is(":hidden")) {
                            sc.click();
                        }
                        else {
                            //$("#" + opid + scobj.val()).mouseover();
                            //$(ops.find("div").get(ops.index($(".nice-op-check")) + 1)).mouseover();
                            //alert(ops.index($(".nice-op-check")[0]));
                            //scobj.find("option:selected")

                            //var thisop = $(ops.find("div").get(scobj.get(0).selectedIndex + 1)).mouseover();
                            //$(".nice-op-check").next().mouseover();
                            //$(".nice-op-in").next().mouseover();


                        }
                    }
                });
            }
        },
        NiceCheckBox: function(params) {
            //默认参数
            defaults.NiceCheckBox = {};
            var thisBody = $("body");

            //真正使用的参数
            var options = jQuery.extend(defaults.NiceCheckBox, params);

            var thisCheckBoxList = $(this);

            for (var i = 0; i < thisCheckBoxList.length; i++) {
                var thisCheckBox = $(thisCheckBoxList[i]);
                var thisCheckBoxId = thisCheckBox.attr("id");
                var thisCheckBoxTitle = thisCheckBox.attr("title");
                DivInit(thisCheckBox, thisCheckBoxId, thisCheckBoxTitle);
            }

            function DivInit(ckobj, ckid, cktext) {

                var boxid = "ckbox" + ckid;
                var ckid = "ck" + ckid;
                var cklength = cktext.length * 14;

                var boxwidth = ckobj.width() + 14 + cklength;
                var boxheight = ckobj.height() + 8;
                var boxtop = ckobj.offset().top;
                var boxleft = ckobj.offset().left;


                var box = $("<div/>").attr("id", boxid).css(
                {
                    "width": boxwidth,
                    "height": boxheight
                }).addClass("nice-ck-box");
                ckobj.wrap(box);

                var ck = $("<div/>").attr("id", ckid).css(
                {
                    "height": 14,
                    "top": ckobj.offset().top,
                    "left": ckobj.offset().left
                }).addClass("nice-ck").text(ckobj.attr("title"));
                ck.appendTo(thisBody);

                ck.click(function() {
                    ckobj.click();
                    if (ckobj.attr("checked")) {
                        ck.addClass("nice-ck-in");
                    }
                    else {
                        ck.removeClass("nice-ck-in");
                    }
                });

                defaultValue(ckobj, ck);

                //隐藏原始控件
                //ckobj.hide();
                ckobj.css("width", "0px");
            }

            //默认值
            function defaultValue(ckobj, ck) {
                if (ckobj.attr("checked")) {
                    ck.addClass("nice-ck-in");
                }
                else {
                    ck.removeClass("nice-ck-in");
                }
            }
        },
        NiceRadio: function(params) {
            //默认参数
            defaults.NiceRadio = {};

            //真正使用的参数
            var options = jQuery.extend(defaults.NiceRadio, params);

            var thisBody = $("body");
            var thisRadioList = $(this);

            for (var i = 0; i < thisRadioList.length; i++) {
                var thisRadio = $(thisRadioList[i]);
                var thisRadioId = thisRadio.attr("id");
                DivInit(thisRadio, thisRadioId);
            }

            function DivInit(rdobj, rdid) {

                var rd = $("<div/>").attr("id", rdid).css(
                {
                    "height": 14,
                    "top": rdobj.offset().top,
                    "left": rdobj.offset().left
                }).addClass("nice-rd").text(rdobj.attr("title"));
                rd.appendTo(thisBody);

                rd.click(function() {
                    $(".nice-rd-in").removeClass("nice-rd-in");
                    rdobj.click();
                    rd.addClass("nice-rd-in");
                });

                defaultValue(rdobj, rd);

                //隐藏原始控件
                //rdobj.hide();
                rdobj.css("width", "0px");
            }

            //默认值
            function defaultValue(rdobj, rd) {
                if (rdobj.attr("checked")) {
                    rd.addClass("nice-rd-in");
                }
                else {
                    rd.removeClass("nice-rd-in");
                }
            }
        }
    });
})(jQuery);