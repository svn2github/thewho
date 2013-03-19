<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thewho.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Default</title>
    <link href="Styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="Styles/base.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

        .test-grid{ background-color:#fff;}
        
    </style>
</head>

<script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
<script src="Scripts/NiceE/nice.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {
        $(".textlogin").focusin(function() {
            if ($(this).val() == "") {
                $(this).addClass("textlogin-in");
            }
        }).focusout(function() {
            if ($(this).val() == "") {
                $(this).removeClass("textlogin-in");
            }
        });
        $(".selectdiv").click(function() {
            //if ($(this).val() == "") {
            $(this).addClass("selectdiv-in");
            //}
        });
        $("#btnlogin").click(function() {
            $(this).hide();
            $("#btnsd").show();
            //$(this).addClass("sd").val("登录中");
            //$(".textlogin").attr("disabled", "true");
            //$("#tishi").show();
            //document.forms["form_login"].submit();
        });
        $("#imgcaptcha").click(function() {
            $(this).attr("src", "Captcha/Default.ashx?r=" + +Math.random() * 999);
        });
    });
   
</script>
<body>
    <div class="page">
        <div class="grid-1">
		    <div class="test-grid h200">
		    <select id="sl">
		                <option value="1">人族</option>
		                <option value="2">精灵族</option>
		                <option value="3">兽族</option>
		                <option value="4">不死族</option>
		            </select>
		    </div>
		</div>
		<div class="grid-1">
		    <div class="test-grid h300">
		        <div class="box-left w220 h30 lh30 text-right">
		            
		            <input id="Text1" name="txtusername" type="text" class="textlogin w80"/>
		            <div id="div_sl" name="txtusername" type="text" class="selectdiv w100" style=" cursor:pointer; text-align:left;" v=""></div>
		            <script type="text/javascript">
		                var div_sl = $("#div_sl");
		                var topVal = div_sl.offset().top + div_sl.height() + 2;
		                var leftVal = div_sl.offset().left;

		                var d = $("<div/>").attr("id", "listdiv").css(
		                { "width": div_sl.width(), "border": "2px solid #999","border-top":"0", "top": topVal, "left": leftVal, "position": "absolute", "z-index": "999", "display": "none" }
		                );
		            
		                var sl = $("#sl");
		                $("option").each(function(index, item) {
		                var newdiv = $("<div/>").attr("id", +$(item).val()).text($(item).text()).css({ "height": "22", "cursor": "pointer", "border-top": "1px solid #999", "line-height": "22px", "text-indent": "4" }).addClass("divitem");
		                    newdiv.appendTo(d);
		                });

		                d.appendTo($("body"));


		                sl.change(function() {
		                    div_sl.text(sl.find("option:selected").text()).attr("v", sl.val());
		                    $("#" + sl.val()).css("background", "#FFFACD");
		                });

		                $(".divitem").live("click", function() {
		                    sl.val($(this).attr("id"));
		                    d.hide();
		                    div_sl.text($(this).text()).attr("v", sl.val());
		                    if (div_sl.attr("v") == "") {
		                        $(this).removeClass("selectdiv-in");
		                        $("#listdiv").hide();

		                    }
		                });

		                div_sl.click(function() {
		                if (d.is(":hidden")) {
		                        d.show();
		                    }
		                    else {
		                        d.hide();
		                    }
		                });

		                $("#listdiv div").live("mouseover", function() {
		                    $(this).css("background", "#FFFACD");
		                }).live("mouseout", function() {
		                    $(this).css("background", "#fff");
		                });
		            </script>
		        </div>
		        <div class="box-right w240 h30 lh30">
		            <form id="form_login" name="form_login" action="Default.aspx" method="post">
		                <table border="0" cellpadding="0" cellspacing="0">
		                    <tr>
		                        <td colspan="2" width="200" height="40">
		                            <input id="txtusername" name="txtusername" type="text" class="textlogin w200"/>
		                        </td>
		                    </tr>
		                    <tr>
		                        <td colspan="2" width="200" height="40">
		                            <input id="txtpassword" name="txtpassword" type="password" class="textlogin w200" style="letter-spacing:1px;color:#ccc"/>
		                        </td>
		                    </tr>
		                    <tr style="display:none;">
		                        <td width="100" height="40" valign="middle">
		                            <img src="Captcha/Default.ashx" class="imgcaptcha" id="imgcaptcha" title="点击更换验证码"/>
		                        </td>
		                        <td width="100" height="40" valign="middle">
		                            <input id="Password1" name="txtpassword" type="text" class="textlogin w100" />
		                        </td>
		                    </tr>
		                    <tr>
		                        <td width="100" height="40">
		                            <input type="button" class="button login w100" value="登录" id="btnlogin"/>
		                            <input type="button" class="button sd w100" value="登录中..." id="btnsd" style="display:none;"/>
		                        </td>
		                        <td width="100" height="40">
		                            
		                        </td>
		                    </tr>
		                </table>
		            </form>
		        </div>
		    </div>
		</div>
		<div class="grid-1">
		    <div class="test-grid h100">
		        <div class="box-left w600 h100">
		        </div>
		        <div class="box-right w340 h100"></div>
		    </div>
		</div>
    </div>
</body>
</html>
