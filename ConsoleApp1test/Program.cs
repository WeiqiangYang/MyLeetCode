using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1test
{
    class Program
    {
        
  public class ListNode
        {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
        
        static void Main(string[] args)
        {
            //int n = Convert.ToInt32( Console.ReadLine());
            //string[] str = Console.ReadLine().Split(' ');
            //int[] intArray = new int[str.Length];
            //for (int i = 0; i < str.Length; i++)
            //{
            //    intArray[i] = Convert.ToInt32(str[i]);
            //}
            //int[] intArray = new int[10] { 1, 3, 7, 9, 10, 4, 3, 6, 77, 2,4,7,2,8, };
            //List<int> l = new List<int>();
            //Random r = new Random();
            //for (int i = 0; i < 300; i++)
            //{
            //    l.Add(r.Next(1, 1000));
            //}

            //int[] iii = l.ToArray();
            //QuickSort.QuickSortMethodTwo(ref iii, 0, iii.Length - 1);
            //for (int i = 0; i < iii.Length; i++)
            //{
            //    Console.Write(iii[i] + ",");
            //}
            //Console.ReadKey();
            //int[] iii = l.ToArray();
            //int[] iii1 = MergerSort(iii);
            //for (int i = 0; i < iii1.Length; i++)
            //{
            //    Console.Write(iii1[i] + ",");
            //}
            //Console.ReadKey();

            Console.Write(fibonac(1, 1, 5));
            Console.ReadKey();
        }
        static int fibonac(int a, int b, int n)
        {
            //n2++;
            if (n > 2)
            {
                
                   return fibonac(a + b, a, n - 1);
            }
            return a;
        }
            static int[] MergerSort(int[] intArray)
        {
            if (intArray.Length <= 1)
                return intArray;
           int[] array1 = MergerSort(intArray.Take(intArray.Length / 2).ToArray());//递归前半部分
           int[] array2 = MergerSort(intArray.Skip(intArray.Length / 2).ToArray());//递归后半部分
           return MSort(array1, array2);
        }
        /// <summary>
        /// 传入2个已排序数组，然后循环对比生成1个新数组
        /// </summary>
        /// <returns></returns>
        static int[] MSort(int[] intArray1, int[] intArray2)
        {
            int[] newArray = new int[intArray1.Length + intArray2.Length];
            int i = 0, j = 0,k = 0;
            while (j < intArray1.Length&&k<intArray2.Length)
            {
                //多么斯巴达西的语句，三元表达式先判断哪个更小，然后返回更小值，利用j++先返回后+1的特性，返回最小值之后，最小值所在数组索引+1，新数组索引也加1
                newArray[i++]=intArray1[j] < intArray2[k] ? intArray1[j++] : intArray2[k++];
            }
            if(j==intArray1.Length)
            {
                for (; i< intArray1.Length +intArray2.Length;i++)
                {
                    newArray[i] = intArray2[k++];
                }
                
            }
            else if (k == intArray2.Length)
            {
                for (; i < intArray1.Length + intArray2.Length; i++)
                {
                    newArray[i] = intArray1[j++];
                }
            }
            return newArray;
        }


        public static List<int> sort(List<int> lst)
        {
            if (lst.Count <= 1)
                return lst;
            int mid = lst.Count / 2;
            List<int> left = new List<int>();  // 定义左侧List
            List<int> right = new List<int>(); // 定义右侧List
                                               // 以下兩個循環把 lst 分為左右兩個 List
            for (int i = 0; i < mid; i++)
                left.Add(lst[i]);
            for (int j = mid; j < lst.Count; j++)
                right.Add(lst[j]);
            left = sort(left);
            right = sort(right);
            return merge(left, right);
        }
        /// <summary>
        /// 合併兩個已經排好序的List
        /// </summary>
        /// <param name="left">左側List</param>
        /// <param name="right">右側List</param>
        /// <returns></returns>
        static List<int> merge(List<int> left, List<int> right)
        {
            List<int> temp = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    temp.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            if (left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                    temp.Add(left[i]);
            }
            if (right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                    temp.Add(right[i]);
            }
            return temp;
        }
        static private int SecondBigNumber(int[] intArray)
        {
            int[] tempArray = new int[2];
            tempArray[0] = intArray[0];
            tempArray[1] = intArray[1];
            if (tempArray[0] < tempArray[1])
            {
                int temp = tempArray[0];
                tempArray[0] = tempArray[1];
                tempArray[1] = temp;
            }
           
            for (int i = 2; i < intArray.Length; i++)
            {
                if (intArray[i] > tempArray[0])
                {
                    int temp = tempArray[0];
                    tempArray[0] = intArray[i];
                    tempArray[1] = temp;
                }
                else if (intArray[i] > tempArray[1])
                {
                    tempArray[1] = intArray[i];
                }
            }
            return tempArray[1];
        }
        static void Print<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            { Console.WriteLine(item); }
        }
        void test()
        {
            
        }
    }
    //class Thermostat
    //{
    //    float _CurrentTemperature;
    //    public Action<float> OnTmeperatureChange { get; set; }
    //    public float CurrentTemperature
    //    {
    //        get { return _CurrentTemperature; }
    //        set
    //        {
    //            if (value != CurrentTemperature)
    //            {
    //                _CurrentTemperature = value;
    //                OnTmeperatureChange(value);
    //            }
    //        }
    //    }
    //}
    //class Thermostat
    //{
    //    public class TemperatureArgs:System.EventArgs    //嵌套类
    //    {
    //        public TemperatureArgs(float newTemperature) //构造器
    //        {
    //            NewTemperature = newTemperature;
    //        }
    //        private float _newTemperature;               //私有字段
    //        public float NewTemperature                  //属性
    //        {
    //            get { return _newTemperature; }
    //            set { _newTemperature = value; }
    //        }
            
    //    }

    //    public event EventHandler<TemperatureArgs> OnTmeperatureChange = delegate { };//为event赋空委托，避免null错误
    //    public float CurrentTemperature
    //    {
    //        get { return _CurrentTemperature; }
    //        set
    //        {
    //            if (value != CurrentTemperature)
    //            {
    //                _CurrentTemperature = value;
    //                //public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
    //                OnTmeperatureChange?.Invoke(this, new TemperatureArgs(value));
    //            }
    //        }
    //    }
    //   private float _CurrentTemperature;
    //}

}
