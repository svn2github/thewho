$(function() {
    boxAF = new box({ "id": "box1","width":"200","height":"50","text":"hello world~" });
    //s.hide();
});
function boxA() {
    boxAF.show();
    s.show();
}

function box(param_cover) {
    this.id = param_cover.id;
    this.width = param_cover.width;
    this.height = param_cover.height;
    this.text = param_cover.text;

    var div_box = $("<div/>").attr("id", "div_" + this.id).addClass("div_box").appendTo($("body")).css({
            "background-color": "#333333",
            "width" : this.width,
            "height" : this.height
        }).appendTo($("body"));
        this.show = function() {
            div_box.show();
        }
}
