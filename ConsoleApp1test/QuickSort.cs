using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1test
{        //未实现：选开头结尾中间三值中的中值
    class QuickSort
    {
        //如何在不占用其他内存空间的情况下使用快速排序。
        //数组一直不变，只改变需要对比的值和start，end的位置，对比值就是子数组第一个值,start是去掉对比值的第一个值下标，end是子数组最后下标






        //划分实现1 （枢轴跳来跳去法）：
        //设两个指针low和high，设枢轴记录的关键字为pivotkey，
        //则首先从high所指位置起向前搜索找到第一个关键字小于pivotkey的记录和枢轴记录互相交换，
        //然后从low所指位置起向后搜索，找到第一个关键字大于pivotkey的记录和枢轴记录互相交换，重复这两步直至low==high为止。
       public static void QuickSortMethodOne(ref int[] intArray,int start,int end)
        {
           int nextStart = start,nextEnd = end;
           if(start >= end)
            { return; }
           // start = 0;target = 0;end = intArray.Length - 1;
           while (start < end)
            {
                while (start < end && intArray[start] < intArray[end])
                {
                    end--;
                }
                
                if (start < end)
                {
                    int temp = intArray[start];
                    intArray[start] = intArray[end];
                    intArray[end] = temp;
                    start++;
                }

                while (start < end && intArray[start] < intArray[end])
                {
                    start++;
                }

                if (start < end)
                {
                    int temp = intArray[start];
                    intArray[start] = intArray[end];
                    intArray[end] = temp;
                    end--;
                }
            }
            //Console.WriteLine("start为：" + start + "end为："+end);
            //这个时候start应该等于end了，接下来开始递归
            //if (start > 1)
            {
                QuickSortMethodOne(ref intArray, nextStart, start - 1);
            }
           // if (intArray.Length > 1)
            {
                QuickSortMethodOne(ref intArray, start + 1, nextEnd);
            }
            //return intArray;
        }
        //划分实现2 （枢轴一次到位法）
        //从上面的实现可以看出，枢轴元素（即最开始选的“中间”元素（其实往往是拿第一个元素作为“中间”元素））
        //在上面的实现方法中需要不断地和其他元素交换位置，而每交换一次位置实际上需要三次赋值操作。
        //实际上，只有最后low=high的位置才是枢轴元素的最终位置，
        //所以可以先将枢轴元素保存起来，排序过程中只作元素的单向移动，直至一趟排序结束后再将枢轴元素移至正确的位置上。
        public static void QuickSortMethodTwo(ref int[] intArray, int start, int end)
        {
            int nextStart = start, nextEnd = end;
            int target = intArray[start];
            if (start >= end)
            { return; }
            // start = 0;target = 0;end = intArray.Length - 1;
            while (start < end)
            {
                while (start < end && intArray[start] < intArray[end])
                {
                    end--;
                }

                if (start < end)
                {
                    intArray[start] = intArray[end];
                    start++;
                }

                while (start < end && intArray[start] < intArray[end])
                {
                    start++;
                }

                if (start < end)
                {
                    intArray[start] = intArray[end];
                    end--;
                }
            }
            intArray[start] = target; 
            //Console.WriteLine("start为：" + start + "end为："+end);
            //这个时候start应该等于end了，接下来开始递归
            //if (start > 1)
            {
                QuickSortMethodOne(ref intArray, nextStart, start - 1);
            }
            // if (intArray.Length > 1)
            {
                QuickSortMethodOne(ref intArray, start + 1, nextEnd);
            }
            //return intArray;
        }
        static int[] QuickSortRecursiveMethodTwo(int[] intArray)
        {

            return null;
        }
    }
//        static void Main(string[] args)
//        {
//            int[] array = { 49, 38, 65, 97, 76, 13, 27 };
//            sort(array, 0, array.Length - 1);
//            Console.ReadLine();
//        }
//        /**一次排序单元，完成此方法，key左边都比key小，key右边都比key大。


    //**@param array排序数组 


    //**@param low排序起始位置 


    //**@param high排序结束位置


    //**@return单元排序后的数组 */
    //        private static int sortUnit(int[] array, int low, int high)
    //        {
    //            int key = array[low];
    //            while (low < high)
    //            {
    //                /*从后向前搜索比key小的值*/
    //                while (array[high] >= key && high > low)
    //                    --high;
    //                /*比key小的放左边*/
    //                array[low] = array[high];
    //                /*从前向后搜索比key大的值，比key大的放右边*/
    //                while (array[low] <= key && high > low)
    //                    ++low;
    //                /*比key大的放右边*/
    //                array[high] = array[low];
    //            }
    //            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
    //            array[low] = key;
    //            foreach (int i in array)
    //            {
    //                Console.Write("{0}\t", i);
    //            }
    //            Console.WriteLine();
    //            return high;
    //        }
    //        /**快速排序 
    //*@paramarry 
    //*@return */
    //        public static void sort(int[] array, int low, int high)
    //        {
    //            if (low >= high)
    //                return;
    //            /*完成一次单元排序*/
    //            int index = sortUnit(array, low, high);
    //            /*对左边单元进行排序*/
    //            sort(array, low, index - 1);
    //            /*对右边单元进行排序*/
    //            sort(array, index + 1, high);
    //        }
    //    }
    
}
