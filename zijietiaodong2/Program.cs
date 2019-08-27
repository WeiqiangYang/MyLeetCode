using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zijietiaodong2
{
    class Program
    {
        //把一个数作为当前数组最小值，并尽可能的延伸这个数组
        static void Main(string[] args)
        {
            int count =  Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] strs = str.Split(' ');
            int[] array = new int[strs.Length];
            array = Array.ConvertAll<string, int>(strs, m => int.Parse(m));
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int j = 0, k = 0;
                while (j <= i && array[i - j] >= array[i])
                {
                    j++;
                }
                while ((k+i) <= array.Length-1 && array[i + k] >= array[i])
                {
                    k++;
                }
                int[] tempArray = array.Skip(i - j + 1).Take(j + k - 1).ToArray();
                int tempResult = 0;
                for (int m = 0; m < tempArray.Length; m++)
                {
                    tempResult += tempArray[m];
                }
                tempResult *= array[i];
                if (tempResult > result)
                {
                    result = tempResult;
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
        
    }
}
