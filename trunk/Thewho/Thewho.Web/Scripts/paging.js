//url 页面地址 如 list.aspx
//urlpara  参数  如 &id=123  直接跟& 不要跟?
//pagewidth 页宽度  一行显示多少个页码  
//pageindex //当前页码
//pagesize 页尺寸  每页显示多少条数据
//count 数据总数

function paging(url, urlpara, pagewidth, pageindex, pagesize, count) {

    
    var pagehtml = ""; //最后输出的html

    var pagenumber = 0;  //总页数
    
    //转为整型
    pageindex = ~ ~pageindex;
    pagesize = ~ ~pagesize;
    count = ~ ~count;

    if (!!count == 0) {
        return "";
    }
    
    if ((count % pagesize) == 0) {
        //parseInt((count / pagesize));
        pagenumber = ~ ~(count / pagesize);
    }
    else {
        pagenumber = ~ ~((count / pagesize) + 1);
    }
    
    //输出首页
    pagehtml += "<a href=\"" + url + "?pageindex=1" + urlpara + "\">首页</a>";

    //输出 "上一页"
    if (pageindex > 1) {
        
        pagehtml += "<a href=\"" + url + "?pageindex=" + (pageindex - 1) + urlpara + "\">上一页</a>";
    
    }
    else {
        
        pagehtml += "<a href=\"" + url + "?pageindex=" + 1 + urlpara + "\">上一页</a>";
    
    }

    //当页总数小页宽度的时候 直接全部输出
    if (pagenumber < pagewidth) {

        pagehtml += paging_a(0, pagenumber,pageindex, url, urlpara);
        
    }
    //当页总数大于页宽度的时候
    else {
        //当前页小于页(宽度除2加1)的时候
        if (pageindex < 6) {

            pagehtml += paging_a(0, pagewidth,pageindex, url, urlpara);

        }
        //否则
        else {
            if ((pagenumber - pageindex) < 6) {

                pagehtml += paging_a((pagenumber - 10), pagenumber, pageindex,url, urlpara);

            }
            else {

                pagehtml += paging_a((pageindex - 5), (pageindex + 5),pageindex, url, urlpara);
            }
        }
    }

    //输出下一页
    if (pageindex >= pagenumber) {
        pagehtml += "<a href=\"" + url + "?pageindex=" + pageindex + urlpara + "\">下一页</a>";
    }
    else {
        pagehtml += "<a href=\"" + url + "?pageindex=" + (pageindex + 1) + urlpara + "\">下一页</a>";
    }

    //输出尾页
    pagehtml += "<a href=\"" + url + "?pageindex=" + pagenumber + urlpara + "\">尾页</a>";

    //输出Go按钮
//    pagehtml += "<input id='txtgo' type=\"text\" style=\"width:22px\" maxlength=\"3\" /><input type=\"button\" value=\"GO\" onclick=\"window.location.href='" + url + "?pageindex=" + $("#txtgo").val() + urlpara + "'; \" />";
    
    return pagehtml;
}

//循环输出a
function paging_a(sta, end,pageindex, url, urlpara) {

    var h = "";
    
    for (var i = sta; i < end; i++) {
        //不知为何直接用 class= "vis" 无效?  改写成了style 
        h += "<a " + (pageindex == (i+1) ? "style=\"color:#fff; border:1px solid #CBDCE4; background:#369;\"" : "") + " href=\"" + url + "?pageindex=" + (i + 1) + urlpara + "\">" + (i + 1) + "</a>";   
    }
    return h;
}

//---------------------AJAX版本
//url 页面地址 如 list.aspx
//urlpara  参数  如 &id=123  直接跟& 不要跟?
//pagewidth 页宽度  一行显示多少个页码  
//pageindex //当前页码
//pagesize 页尺寸  每页显示多少条数据
//count 数据总数

function paging_ajax(funname, pageindex, pagesize,parmstr, pagewidth, count) {


    var pagehtml = ""; //最后输出的html

    var pagenumber = 0;  //总页数

    //转为整型
    pageindex = ~ ~pageindex;
    pagesize = ~ ~pagesize;
    count = ~ ~count;

    if (!!count == 0) {
        return "";
    }

    if ((count % pagesize) == 0) {
        //parseInt((count / pagesize));
        pagenumber = ~ ~(count / pagesize);
    }
    else {
        pagenumber = ~ ~((count / pagesize) + 1);
    }

    //输出首页
    pagehtml += "<a href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, 1, pagesize, parmstr) + "\">首页</a>";

    //输出 "上一页"
    if (pageindex > 1) {

        pagehtml += "<a href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, (pageindex - 1), pagesize, parmstr) + "\">上一页</a>";

    }
    else {

        pagehtml += "<a href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, 1, pagesize, parmstr) + "\">上一页</a>";

    }

    //当页总数小页宽度的时候 直接全部输出
    if (pagenumber < pagewidth) {

        pagehtml += paging_a_ajax(0, pagenumber, funname,pageindex, pagesize, parmstr);

    }
    //当页总数大于页宽度的时候
    else {
        //当前页小于页(宽度除2加1)的时候
        if (pageindex < 6) {

            pagehtml += paging_a_ajax(0, pagewidth, funname, pageindex, pagesize, parmstr);

        }
        //否则
        else {
            if ((pagenumber - pageindex) < 6) {

                pagehtml += paging_a_ajax((pagenumber - 10), pagenumber, funname, pageindex, pagesize, parmstr);

            }
            else {

                pagehtml += paging_a_ajax((pageindex - 5), (pageindex + 5), funname, pageindex, pagesize, parmstr);
            }
        }
    }

    //输出下一页
    if (pageindex >= pagenumber) {
        pagehtml += "<a href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, pageindex,pagesize, parmstr) + "\">下一页</a>";
    }
    else {
        pagehtml += "<a href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, (pageindex + 1), pagesize, parmstr) + "\">下一页</a>";
    }

    //输出尾页
    pagehtml += "<a href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, pagenumber, pagesize, parmstr) + "\">尾页</a>";

    //输出Go按钮
    //    pagehtml += "<input id='txtgo' type=\"text\" style=\"width:22px\" maxlength=\"3\" /><input type=\"button\" value=\"GO\" onclick=\"window.location.href='" + url + "?pageindex=" + $("#txtgo").val() + urlpara + "'; \" />";

    return pagehtml;
}

//返回方法
function returnFun(funName, pageindex, pagesize, parmStr) {
    //alert(funName + "(" + pageindex + "," + pagesize + "," + parmStr + ");");
    return funName + "(" + pageindex + "," + pagesize + "," + parmStr + ");";
}



//循环输出a
function paging_a_ajax(sta, end,funname, pageindex, pagesize, parmstr) {

    var h = "";

    for (var i = sta; i < end; i++) {
        //不知为何直接用 class= "vis" 无效?  改写成了style
        h += "<a " + (pageindex == (i + 1) ? "style=\"color:#fff; border:1px solid #CBDCE4; background:#369;\"" : "") + " href=\"javascript:void(0);\" onclick=\"" + returnFun(funname, (i + 1), pagesize, parmstr) + "\">" + (i + 1) + "</a>";
    }
    return h;
}