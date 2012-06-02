var show;   //所见即所得
var source; //源码

var select_show; //所选择的显示文本
var select_source;//所选择的源码文本

var browser;  //记录浏览器类型
 





//编辑器
function editor(params) {
    var thisvalue = "";
    //事件初始化
//    $(".editor").mouseup(function(event) {
//        alert(event.valueOf());
//    });
    $(".editor").mouseup(function() {
        //var sTextRange= document.selection.createRange();

        var userSelection;
        if (window.getSelection) { //现代浏览器 
            userSelection = window.getSelection();
        } else if (document.selection) { //IE浏览器 考虑到Opera，应该放在后面 
            userSelection = document.selection.createRange();
        }
        texts = userSelection.text;
    });

    //样式属性初始化
    var default_styles = {
        "width": "600px",
        "height": "140px",
        "background-color": "#fff",
        "border": "1px solid #999"
    };
    this.styles = jQuery.extend(default_styles, params.styles);

    //标识属性初始化
    var default_ids = {
        "id": "default_editor"
    };
    this.ids = jQuery.extend(default_ids, params.ids);
    
    //功能属性初始化
    var default_functions = {
        "Bold": "none"
    };
    this.functions = jQuery.extend(default_functions, params.functions);


    var my_editor = $(".editor");

    my_editor.css(styles);

    //var div_editor = jquery("<div/>");
    var htmlstr = "";

    htmlstr += (functions.Bold == "none" ? "" : "<span onclick=\"Bold();\" style=\"cursor:pointer;\">" + functions.Bold + "</span>");
    $("#dc").html(htmlstr);
    //alert(functions.C);
}


//加粗的方法
function Bold() {
    alert(texts);

}


function iframe