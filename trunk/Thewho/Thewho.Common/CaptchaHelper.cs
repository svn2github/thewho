using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Thewho.Common
{
    /// <summary>
    /// 验证码帮助类
    /// </summary>
    public class CaptchaHelper
    {
        public static System.IO.MemoryStream Create(int textLength, int textColor, int imgWidth, int imgHeight, int fonzSize, string fontFamily, bool isBold, bool isItalic, 
                string bgColor, string bgImage, int borderColor, int borderWidth)
        {
            //获取随机字符
            string captchaStr = Thewho.Common.Text.GetRandomStr(textLength);

            Bitmap image = new Bitmap(imgWidth, imgHeight);
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.White);

            //生成随机生成器
            Random random = new Random();

            //画图片的背景噪音线
            for (int i = 0; i < 5; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            

            Font font = new System.Drawing.Font("微软雅黑", fonzSize, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);
            g.DrawString(captchaStr, font, brush, 12,2);



            ////定义颜色
            //Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            ////定义字体 
            //string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            //Random rand = new Random();
            ////随机输出噪点
            //for (int i = 0; i < 50; i++)
            //{
            //    int x = rand.Next(image.Width);
            //    int y = rand.Next(image.Height);
            //    g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            //}

            ////输出不同字体和颜色的验证码字符
            //for (int i = 0; i < checkCode.Length; i++)
            //{
            //    int cindex = rand.Next(7);
            //    int findex = rand.Next(5);

            //    Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
            //    Brush b = new System.Drawing.SolidBrush(c[cindex]);
            //    int ii = 4;
            //    if ((i + 1) % 2 == 0)
            //    {
            //        ii = 2;
            //    }
            //    g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
            //}
            ////画一个边框
            //g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

            ////输出到浏览器
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //HttpContext.Current.Response.ClearContent();
            ////Response.ClearContent();
            //HttpContext.Current.Response.ContentType = "image/Jpeg";
            //HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            //g.Dispose();
            //image.Dispose();



            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms;
        }
        
    }
}
