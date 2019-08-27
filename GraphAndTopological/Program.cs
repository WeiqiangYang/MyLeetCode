using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAndTopological
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = Convert.ToInt32(Console.ReadLine());
            string[] str = new string[i];
            for (int j = 0; j < i; j++)
            {
               str[j] = Console.ReadLine();
            }
            for (int j = 0; j < i; j++)
            {
                char[] array = str[j].ToArray();//str.Split(' ');
            Console.WriteLine( test(array));
            }
           
            Console.ReadKey();
        }
       static  int test(char[] intArray)
        {
            int str = 0;
            
           for(int i =0;i<intArray.Length;i++)
            {
                bool isChongfu = false;
                for (int j = intArray.Length-1; j > 0; j--)
                {
                    if (i!=j&&intArray[j].Equals(intArray[i]))
                    { isChongfu = true; }
                }
                if (isChongfu ==false)
                {
                    if(intArray[i])
                    return i;
                }
            }
            return str;
        }
    }
   // 2 1 2 3 1
   //1 3 5 7 9 2 4 6 8 8 4 1 3 7 5 2 6
}
