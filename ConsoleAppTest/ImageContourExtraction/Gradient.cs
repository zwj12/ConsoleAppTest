using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public enum GradientTypeEnum
    {
        Lapacian,

        /// <summary>
        /// Sobel算子-水平
        /// </summary>
        Sobel_Horizontal,

        /// <summary>
        /// Sobel算子-垂直
        /// </summary>
        Sobel_Vertical,

        /// <summary>
        /// Sobel算子-对角线1
        /// </summary>
        Sobel_Diagonal1,

        /// <summary>
        /// Sobel算子-对角线2
        /// </summary>
        Sobel_Diagonal2,

        /// <summary>
        /// Prewitt算子-水平
        /// </summary>
        Prewitt_Horizontal,

        /// <summary>
        /// Prewitt算子-垂直
        /// </summary>
        Prewitt_Vertical,

        /// <summary>
        /// Prewitt算子-对角线1
        /// </summary>
        Prewitt_Diagonal1,

        /// <summary>
        /// Prewitt算子-对角线2
        /// </summary>
        Prewitt_Diagonal2
    }

    /// <summary>
    /// 梯度
    /// </summary>
    public class Gradient
    {
        #region 常量
        public static int[,] Lapacian =
        {
            { 1,1,1},
            { 1,-8,1},
            { 1,1,1}
        };

        /// <summary>
        /// Sobel算子-水平
        /// </summary>
        public static int[,] Sobel_Horizontal =
        {
             { -1,-2,-1},
            { 0,0,0},
            { 1,2,1}
        };

        /// <summary>
        /// Sobel算子-垂直
        /// </summary>
        public static int[,] Sobel_Vertical =
        {
            { -1,0,1},
            { -2,0,2},
            { -1,0,1}
        };

        /// <summary>
        /// Sobel算子-对角线1
        /// </summary>
        public static int[,] Sobel_Diagonal1 =
        {
             { 0,1,2},
            { -1,0,1},
            { -2,-1,0}
        };

        /// <summary>
        /// Sobel算子-对角线2
        /// </summary>
        public static int[,] Sobel_Diagonal2 =
        {
            { -2,-1,0},
            { -1,0,1},
            { 0,1,2}
        };

        /// <summary>
        /// Prewitt算子-水平
        /// </summary>
        public static int[,] Prewitt_Horizontal =
        {
            { -1,-1,-1},
            { 0,0,0},
            { 1,1,1}
        };

        /// <summary>
        /// Prewitt算子-垂直
        /// </summary>
        public static int[,] Prewitt_Vertical =
        {
            { -1,0,1},
            { -1,0,1},
            { -1,0,1}
        };


        /// <summary>
        /// Prewitt算子-对角线1
        /// </summary>
        public static int[,] Prewitt_Diagonal1 =
        {
            { 0,1,1},
            { -1,0,1},
            { -1,-1,0}
        };

        /// <summary>
        /// Prewitt算子-对角线2
        /// </summary>
        public static int[,] Prewitt_Diagonal2 =
        {
            { -1,-1,0},
            { -1,0,1},
            { 0,1,1}
        };
        #endregion

        public static int[,] GetGradientTemplate(GradientTypeEnum gradientType)
        {
            int[,] gradientTemplate = null;
            switch (gradientType)
            {
                case GradientTypeEnum.Lapacian:
                    {
                        gradientTemplate = Lapacian;
                        break;
                    }
                case GradientTypeEnum.Sobel_Horizontal:
                    {
                        gradientTemplate = Sobel_Horizontal;
                        break;
                    }
                case GradientTypeEnum.Sobel_Vertical:
                    {
                        gradientTemplate = Sobel_Vertical;
                        break;
                    }
                case GradientTypeEnum.Sobel_Diagonal1:
                    {
                        gradientTemplate = Sobel_Diagonal1;
                        break;
                    }
                case GradientTypeEnum.Sobel_Diagonal2:
                    {
                        gradientTemplate = Sobel_Diagonal2;
                        break;
                    }
                case GradientTypeEnum.Prewitt_Horizontal:
                    {
                        gradientTemplate = Prewitt_Horizontal;
                        break;
                    }
                case GradientTypeEnum.Prewitt_Vertical:
                    {
                        gradientTemplate = Prewitt_Vertical;
                        break;
                    }
                case GradientTypeEnum.Prewitt_Diagonal1:
                    {
                        gradientTemplate = Prewitt_Diagonal1;
                        break;
                    }
                case GradientTypeEnum.Prewitt_Diagonal2:
                    {
                        gradientTemplate = Prewitt_Diagonal2;
                        break;
                    }
                default:
                    break;
            }
            return gradientTemplate;
        }
    }
}
