using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zijietiaodong1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int count = Convert.ToInt32(str);
            List<cord> cords = new List<cord>();
            while (count!=0)
            {
                string str1 = Console.ReadLine();
                string[] strs = str1.Split(' ');
                cord c = new cord(Convert.ToInt32(strs[0]), Convert.ToInt32(strs[1]));
                cords.Add(c);
                --count;
                
            }
            //先按x大小排序，然后拿其他值与x最大的值对比，若其他值的y大于x则被比较值变为新值
            List<cord> newCords = cords.OrderBy(cord => cord.x).ToList();
            cord compareNumber = newCords[newCords.Count - 1];
            Stack<cord> qCord = new Stack<cord>();
            qCord.Push(compareNumber);
            for (int i = newCords.Count - 1; i > 1; i--)
            {
                if (newCords[i - 1].y > compareNumber.y)
                {
                    compareNumber = newCords[i - 1];
                    qCord.Push(compareNumber);
                }
            }
           while(qCord.Count!=0)
            {
                cord temCord = qCord.Pop();
                Console.WriteLine(temCord.x + " " + temCord.y);
            }
            Console.ReadKey();
        }
        
    }
    public class cord
        {
            public cord(int _x, int _y)
            {
                x = _x;y = _y;
            }
            public int x;public int y;
        }
}
