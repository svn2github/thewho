//所有的方法/函数都将以 “;” 结尾。
//所有方法都必须返回 jQuery 对象
//插件将命名为 “jquery.numberformatter.js”。
//将仅使用 “this” 引用 jQuery 对象。
//方法需要附加到 jQuery.fn 对象，函数需要附加到 jQuery 对象
//


/* 全局参数 */
var ParamSize; //参数数量

$(function() {
    $("body").append($("<div/>").attr("id", "cover_div"));
    
});





//遮盖层       Color -> 颜色(#333)  Filter -> 透明度(1-10的数字)  IsLock -> 是否锁定(true为锁定,false为不锁定)
function FullCover(Color, Filter,IsLock) {
        
    //参数数量(重载)
    ParamSize = arguments.length;
    
    //遮盖层对象
    var CoverDiv = $("#cover_div").bind("dblclick", function() { $(this).hide(); });
    
    if (ParamSize == 0) {
        CoverDiv.css({ "background-color": "#333", "filter": "alpha(opacity = 50)", "opacity": "0.5" });
    }

    else if (ParamSize == 1) {
        CoverDiv.css({ "background-color": Color, "filter": "alpha(opacity = 50)", "opacity": "0.5" });
    }

    else if (ParamSize == 2) {
        CoverDiv.css({ "background-color": Color, "filter": "alpha(opacity = " + Filter + "0)", "opacity": "0." + Filter + "" });
    }
    else if (ParamSize == 3) {
        if (IsLock == true || IsLock == "true") {
            CoverDiv.css({ "background-color": Color, "filter": "alpha(opacity = " + Filter + "0)", "opacity": "0." + Filter + "" }).unbind("dblclick");
            
        }
        else if (IsLock == false || IsLock == "false") {
            CoverDiv.css({ "background-color": Color, "filter": "alpha(opacity = " + Filter + "0)", "opacity": "0." + Filter + "" });
        }
        else {
            //传入参数有误!
            alert('参数传入有误');
        }
    }
    
    CoverDiv.addClass("cover_full").width($(window).width()).height($(window).height()).show();
}
//遮盖层
function EasyCover() {
    //遮盖层对象
    $("#cover_div").addClass("cover_easy").width($(window).width()).height($(window).height()).show().dblclick(function() { $(this).hide(); });
}




//盒子容器   宽度   高度    类型  标题   文本内容
function box(iWidth,iHeight,iType,iTitle,iText) { 
    var len = arguments.length;
    if (len = 0) {

    }
    else if(len = 1)
    {

    }
    else if (len = 2) {

    }
    else if (len = 3) {

    }
    else if (len = 4) {

    }
    else if (len = 5) {

    }
}





//弹出一个DIV
function dialog() {
    $("#zg").width($(window).width() + "px");
    $("#zg").height($(window).height() + "px");
    $("select").hide();
    $("#zg").css("display", "");
    $(window).bind("resize", function() {
        Dialog();
    });
}

