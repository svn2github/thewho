<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Thewho.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form action="Login.aspx" method="post">
        帐号：<input type="text" id="txtUserName" name="txtUserName" />
        密码：<input type="password" id="txtPassword" name="txtPassword" />
        <input type="submit" value="提交" />
    </form>
    <br />
    
</body>
</html>
