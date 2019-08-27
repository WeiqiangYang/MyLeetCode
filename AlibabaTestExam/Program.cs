using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaTestExam
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static bool Question(int x,int y,List<int> xCoord, List<int> yCoord, out double distance)
        {
            //思路就是把每条线的函数算出来，写成ax+b-y=0的形式
            //然后把x=0，y=0带进去算ax+b-y大于0还是小于0还是等于0
            //然后根据已知的xy来算ab+b-y是否与（0，0）的结果一样

            //先假设可以到达
            bool result = true;
            //但是要预设一个无法到达最近值，然后dictance=根号下（b^2+(-b/a)^2）/（b*b/a)
            distance = 0;
            for(int i = 0;i<xCoord.Count-1;i++)
            {
                double a = (double)(yCoord[i + 1] - yCoord[i]) / (double)(xCoord[i + 1] - xCoord[i]);
                double b = (double)yCoord[i] - (double)a * (double)xCoord[i];

                distance = distance == 0 ? (Math.Pow(b, 2) + Math.Pow(b / a, 2)) / (b * b / 2) : Math.Min((Math.Pow(b, 2) + Math.Pow(b / a, 2)) / (b * b / 2), distance);
                if (b == 0)//如果有一条线正好经过原点，那么这条线没什么参考意义
                {

                }
                else if (b > 0)//如果b》0则ax+b-y大于0
                {
                    result = result && (a * x + b - y) > 0;
                }
                else if (b < 0)
                {
                    result = result && (a * x + b - y) < 0;
                }
                
            }
            //最终全部符合，才返回true，否则返回false
            if (result)
            {

            }
            return result;
        }
    }
}
