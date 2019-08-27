using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huawei
{
    class Program
    {
        static void Main(string[] args)
        {
            //long t1 = GetTickCount();//程序段开始前取得系统运行时间(ms)        
            //while (true) 

           // if ((string str = Console.ReadLine() )!=null)

            string line;
            while ( (line = Console.ReadLine()) != null)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                if (N == 0)
                {
                    Console.WriteLine("don't input 0");
                    // continue;
                }
                if (N == 1)
                {
                    Console.WriteLine(1);
                    //continue;
                }
                //List<ListNode> listArray = new List<ListNode>();
                ListNode[] listNodes = new ListNode[N];
                for (int i = 0; i < N; i++)
                {
                    listNodes[i] = new ListNode();
                }
                //listNodes[0].value = 0;
                //listNodes[0].next
                for (int i = 0; i < N; i++)
                {
                    listNodes[i].value = i;
                }
                listNodes[0].next = listNodes[1];
                listNodes[0].before = listNodes[N - 1];
                listNodes[N - 1].next = listNodes[0];
                listNodes[N - 1].before = listNodes[N - 2];
                for (int i = 1; i < N - 1; i++)
                {
                    listNodes[i].next = listNodes[i + 1];
                    listNodes[i].before = listNodes[i - 1];
                }



                //List<ListNode> listArray = listNodes.ToList();
                //N个数删N-1次
                ListNode l = listNodes[0];
                while (l.next != l)
                {
                    l = l.next.next.delete();
                }
                Console.WriteLine(l.value);
                Console.ReadKey();
            }
        }

    }
    class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode before;
        public ListNode delete()
        {
            next.before = before;
            before.next = next;
            return next;
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string str = Console.ReadLine();
    //        Console.WriteLine(test(str));
    //        Console.ReadKey();
    //    }
    //    static string test(string str)
    //    {
    //       char[] cArray= str.ToArray();
    //        List<char> cList = new List<char>();
    //        bool isChongfu = false;

    //        for (int i = 0; i < cArray.Length; i++)
    //        {
    //            if (cList.Count == 52)
    //            { break; }
    //             foreach (char c in cList)
    //            {
    //                if (cArray[i] == c)
    //                    isChongfu = true;
    //            }
    //            if (isChongfu)
    //            { isChongfu = false; }
    //            else { cList.Add(cArray[i]); }
    //        }
    //        StringBuilder sb = new StringBuilder();
    //        foreach (char c in cList)
    //        {
    //            sb.Append(c);
    //        }
    //        return sb.ToString();
    //    }
    //}
}
