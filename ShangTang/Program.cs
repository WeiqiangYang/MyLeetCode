using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShangTang
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] c = Console.ReadLine().ToArray();
            int[] iArray = new int[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                iArray[i] = Convert.ToInt32(c[i].ToString());
            }
            Console.WriteLine(Test1(iArray) );
            Console.ReadKey();
        }
        //思路：F(N)=F(N-1)+F(N-2);F(N-1)代表F(N)在最后一位永远单独列出的所有情况，F(N-2)代表F(N)最后两位永远单独列出的所有情况。
        static int Test1(int[] intArray)
        {
            //先判断整个字符串是否符合要求，如果某一位为0并且无法与上一位组成10，20;或者开头为0，则整个字符串无法编码
            //字符串合规后在进行递归。
            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i] == 0 && (intArray[i - 1] > 2||intArray[i-1]==0))
                {
                    return 0;
                }
            }
            if (intArray[0] == 0)
            { return 0; }


            //结束条件：Length=1 or 2;
            if (intArray.Length == 1)
            {
                return 1;
            }
            if (intArray.Length == 2)
            {
                if (intArray[intArray.Length - 1] != 0)
                {
                    if (intArray[1] + intArray[0] * 10 <= 26)
                    { return 2; }
                    else { return 1; }
                }
                else { return 1; }
            }

            //递归：
            if (intArray[intArray.Length - 1] != 0)
            {
                //如果最后两位小于26则F(N) = F(N-1)+F(N-2)
                if (intArray[intArray.Length - 1] + intArray[intArray.Length - 2] * 10 <= 26)
                {
                    return Test1(intArray.Take(intArray.Length - 1).ToArray()) + Test1(intArray.Take(intArray.Length - 2).ToArray());
                }
                //如果最后两位大于26则F(N) = F(N-1)——————因为最后两位无法组合编码
                else
                {
                    return Test1(intArray.Take(intArray.Length - 1).ToArray());
                }
            }
            //如果最后一位为0，则必须与前一位组合编码，F(N) = F(N-2)
            else { return Test1(intArray.Take(intArray.Length - 2).ToArray()); }
        }
    }
}
