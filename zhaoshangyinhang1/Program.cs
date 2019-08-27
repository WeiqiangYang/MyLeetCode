using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhaoshangyinhang1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = Console.ReadLine();
            //char[] cArray =  str.ToArray();
            //int i = Test1(cArray);
            //if (i == 0)
            //{ Console.WriteLine("false"); }
            //else
            //{
            //    Console.WriteLine(str.Substring(0,i));
            //}
            //Console.ReadKey();

            Int64 count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Test3(count));
            Console.ReadKey();
        }
        //分解为2，3是最优解
        static private Int64 Test3(Int64 target)
        {
            Int64 i  = target / 3;
            switch(target%3)
            {
                case 0 :
                    return (Int64)Math.Pow(3, i);
                    break;
                case 1:
                    return (Int64)Math.Pow(3, i-1)*4;
                    break;
                case 2:
                    return (Int64)Math.Pow(3, i) * 2;
                    break;
                default:
                    return 0;
                    break;
            }
         }
        //static private string[] Test2(int count)
        //{
        //    //int flag = 0;//此标志位代表，还可以允许出现几个“)”符号。
        //    //char[] cArray = new char[2 * count];
        //    //cArray[0] = '(';
        //    //for(int())
        //}
        static private int Test1(char[] cArray)
        {
            int lengh = 0;
            for (int i = cArray.Length-1; i >0; i--)
            {
                lengh = i;
                if(cArray[i] == cArray[0])//如果c[i]=c[0]，那么c[0]到c[i-1]就有可能是最长重复子串,子串长度为i
                {
                    if(cArray.Length%i==0)//如果c的长度能被i整除，那么c[0]到c[i-1]就有可能是最长重复子串,子串长度为i
                    {
                        int j = 0;
                        int count = cArray.Length / i;//如果符合要求，应该有count个子串。那么下一步是对比这些子串是否与第一个串相同。
                        for (int repeatCount = 1; repeatCount < count; repeatCount++)
                        {
                            for (int m = repeatCount*i; m < repeatCount* (i+1)-1; m++)
                            {
                                if (cArray[j] == cArray[m])
                                { j++; }
                                else break;
                            }
                        }
                        return i;
                    }
                }

            }
            return 0;
        }
    }
}
