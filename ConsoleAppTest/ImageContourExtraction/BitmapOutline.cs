using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;


namespace ConsoleAppTest
{
    public class BitmapOutline
    {
        #region 内部变量
        private Bitmap _bitmap = null;
        #endregion

        public BitmapOutline(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        #region Calculate
        public Bitmap Calculate(GradientTypeEnum gradientType, int threshold)
        {
            Bitmap grayBitmap = new Bitmap(_bitmap.Width, _bitmap.Height);
            for (int i = 0; i < _bitmap.Width; i++)
            {
                for (int j = 0; j < _bitmap.Height; j++)
                {
                    //得到像素的原始色彩        
                    var oColor = _bitmap.GetPixel(i, j);
                    //得到该色彩的亮度
                    var brightness = oColor.GetBrightness();
                    //用该亮度计算灰度
                    var gRGB = (int)(brightness * 255);
                    //组成灰度色彩
                    var gColor = Color.FromArgb(gRGB, gRGB, gRGB);
                    //最后将该灰度色彩赋予该像素
                    grayBitmap.SetPixel(i, j, gColor);
                }
            }

            var gradientTemplate = Gradient.GetGradientTemplate(gradientType);


            var destBitmap = EdgeDectect(grayBitmap, gradientTemplate, threshold);
            return destBitmap;
        }

        //template为模板，nThreshold是一个阈值，
        //用来将模板游历的结果（也就是梯度）进行划分。
        //大于阈值的和小于阈值的分别赋予两种颜色，白或黑来标志边界和背景
        private Bitmap EdgeDectect(Bitmap grayBitmap, int[,] template, int nThreshold)
        {
            var destBitmap = new Bitmap(grayBitmap.Width, grayBitmap.Height);
            //取出和模板等大的原图中的区域
            int[,] gRGB = new int[3, 3];
            //模板值结果，梯度
            int templateValue = 0;
            //遍历灰度图中每个像素            
            for (int i = 1; i < grayBitmap.Width - 1; i++)
            {
                for (int j = 1; j < grayBitmap.Height - 1; j++)
                {
                    //取得模板下区域的颜色，即灰度
                    gRGB[0, 0] = grayBitmap.GetPixel(i - 1, j - 1).R;
                    gRGB[0, 1] = grayBitmap.GetPixel(i - 1, j).R;
                    gRGB[0, 2] = grayBitmap.GetPixel(i - 1, j + 1).R;
                    gRGB[1, 0] = grayBitmap.GetPixel(i, j - 1).R;
                    gRGB[1, 1] = grayBitmap.GetPixel(i, j).R;
                    gRGB[1, 2] = grayBitmap.GetPixel(i, j + 1).R;
                    gRGB[2, 0] = grayBitmap.GetPixel(i + 1, j - 1).R;
                    gRGB[2, 1] = grayBitmap.GetPixel(i + 1, j).R;
                    gRGB[2, 2] = grayBitmap.GetPixel(i + 1, j + 1).R;
                    //按模板计算
                    for (int m = 0; m < 3; m++)
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            templateValue += template[m, n] * gRGB[m, n];
                        }
                    }
                    //将梯度之按阈值分类，并赋予不同的颜色
                    if (templateValue > nThreshold)
                    {
                        destBitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255)); //白
                    }
                    else
                    {
                        destBitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0)); //黑
                    }
                    templateValue = 0;
                }
            }
            return destBitmap;
        }
        #endregion
    }


}
