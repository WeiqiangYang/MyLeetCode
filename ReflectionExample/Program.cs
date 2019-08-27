using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[6] { -2, 11, -4, 13, -5, -2 };
            Console.WriteLine(MaxSubArray(array));
            Console.ReadKey();
        }
        static void DisplayHelp()
        { }
        static void test()
        {
            ThreadStart threadStart = DoWork;
            Thread t = new Thread(threadStart);
            t.Start();

            for (int count = 0; count < 10; count++)
            {
                Console.Write('_');
            }
            //t.Join();

        }
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    int newTarget = target - nums[i];
                    result[0] = i;
                    if (nums[j] == newTarget)
                    {
                        result[1] = j;
                        if (result[0] != result[1])
                        { return result; }
                    }
                }
            }
            
            { return new int[2] { 0, 0 }; }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public static int RangeSumBST(TreeNode root, int L, int R)
        {
           
            return 0;
        }
        public static string RemoveOuterParentheses(string S)
        {
            char[] charArray = S.ToArray();
            int temp = 0;
            for(int i =0;i<charArray.Length;i++)
            {
                if(charArray[i]=='(')
                {
                    temp++;
                    //if(temp ==0)
                    //{

                    //}
                }
                else if (charArray[i] == ')')
                {
                    temp--;
                    if (temp == 0)
                    {
                        //char[] newChar = charArray.Skip(1).Take();

                    }
                }
            }
            return null;
        }
        public static int qingwadigui(int n )
        {
            if(n<=0)
            { return 0; }
            if (n == 1)
            { return 1; }
            else if (n == 2)
            { return 2; }
            else { return qingwadigui(n - 1) + qingwadigui(n - 2); }
           
        }
        public const int Repetitions = 1000;
        static void DoWork()
        {
            for (int count = 0; count < Repetitions; count++)
            {
                Console.Write('+');
            }
        }
        private static void ThreadFuncOne()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "   i =  " + i);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " has finished");
        }
        //传入一个数组，求此数组中的一个子数组，这个子数组的累加和最大。
        private static int MaxSubArray(int[] intArray)
        {
            if (intArray.Length == 1)
            {
                return intArray[0];
            }
            int leftCount = intArray.Length / 2;
            //计算包含了左边界数字的最大值
            int leftBord = 0,leftBordMax= intArray[leftCount - 1];
            for (int i = leftCount-1; i >= 0; i--)
            {
                leftBord += intArray[i];
                if(leftBordMax< leftBord)
                {
                    leftBordMax = leftBord;
                }
            }
            //计算包含了右边界数字的最大值
            int rightBord = 0, rightBordMax = 0;
            for (int i = leftCount; i <intArray.Length; i++)
            {
                rightBord += intArray[i];
                if (rightBordMax < rightBord)
                {
                    rightBordMax = rightBord;
                }
            }
            //递归计算左边和右边的最大子数组的值
            int leftMax, rightMax;
            leftMax = MaxSubArray(intArray.Take(leftCount).ToArray());
            rightMax= MaxSubArray(intArray.Skip(leftCount).ToArray());
            //返回三个数里最大的一个
            return Math.Max(Math.Max(leftMax, rightMax), leftBordMax + rightBordMax);
        }
    }

    public class PiCalculator
    {
        public static string Calculate(int digits = 100)
        {
            return digits.ToString();
        }
    }
    public class Utility
    {
        public static IEnumerable<char> BusySymbols()
        {
            string busySymbols = "1234567";//@"-\|/-\|/";
            int next = 0;
            while (true)
            {
                yield return busySymbols[next];
                next = (next + 1) % busySymbols.Length;
                yield return '\b';
            }
        }
    }
    class CommandLineInfo
    {
        public bool Help { get; set; }
        public string Out { get; set; }
        public ProcessPriorityClass Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        private ProcessPriorityClass _Priority = ProcessPriorityClass.Normal;
    }
        class CommandLineHeader
        {
        public static void Parse(string[] args, object commandLine)
        {
            string errorMessage;
            if (!TryParse(args, commandLine, out errorMessage))
            {
                throw new ApplicationException(errorMessage);
            }
        }
        public static bool TryParse(string[] args, object commandLine, out string errorMessage)
        {
            bool success = false;
            errorMessage = null;
            foreach (string arg in args)
            {
                string option;
                if (arg[0] == '/' || arg[0] == '-')
                {
                    string[] optionParts = arg.Split(new char[] { ':' }, 2);
                    option = optionParts[0].Remove(0, 1);
                    PropertyInfo property = commandLine.GetType().GetProperty(option, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(bool))
                        {
                            property.SetValue(commandLine, true, null);
                            success = true;
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(commandLine, optionParts[1], null);
                            success = true;
                        }
                        else if (property.PropertyType.IsEnum)
                        {
                            try
                            {
                                property.SetValue(commandLine, Enum.Parse(typeof(ProcessPriorityClass), optionParts[1], true), null);
                                success = true;
                            }
                            catch (ArgumentException)
                            {
                                success = false;
                                errorMessage = string.Format("The option '{0}' is invalid for '{1}'", optionParts[1], option);
                            }
                        }
                        else
                        {
                            success = false;
                            errorMessage = string.Format("The option '{0}' on '{1}' is not" + " supported.", property.PropertyType.ToString(), commandLine.GetType().ToString());
                        }
                    }
                    else
                    { success = false;
                        errorMessage = string.Format("option '{0}' is not supported", option);
                    }
                }
            }
            return success;
        }
    }
}
