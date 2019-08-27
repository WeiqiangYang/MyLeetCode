using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaDianXin
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = new string[2] ;
            strArray[1] = "a";
            //strArray[1] = null;
            for (int i =0;i<strArray.Length;i++)
            { Console.WriteLine(strArray[i]); }
            Console.ReadKey();
        }
        private static int test(string[] strArray,string targetStr)
        {
            Dictionary<int, string> ddd = strArray.ToDictionary<int, string>(i => strArray.Length , str =>
               {
                   if (str == null)
                   {
                       throw new ArgumentNullException(nameof(str));
                   }

                   return strArray[i];
               });
            return 0;
        }
    }
}
