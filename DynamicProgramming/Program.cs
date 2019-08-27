using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] i = new int[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 };
            //Console.WriteLine(LengthOfLIS(i));
            //Console.ReadKey();

            //int[] i = new int[] { 1, 1, 0, 0, 0, 1, 0 };
            //MaxDistToClosest(i);
            //Console.ReadKey();
            TreeNode root = new TreeNode(1);
            TreeNode root1 = new TreeNode(2);
            TreeNode root2 = new TreeNode(3);
            TreeNode root3 = new TreeNode(5);

            root.left = root1;root.right = root2;
            root1.right = root3;

            var o = BinaryTreePaths(root);
            Console.ReadKey();
        } 

        //最长上升子序列
        //输入：一串int[] 输出：最大子序列长度
        static public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;



            int outputResult = 1;
            int[] allOutput = new int[nums.Length];
            allOutput[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                int j = 1;


                while (i - j >= 0 && nums[i] <= nums[i - j])
                {
                    j++;
                }
                if (i - j >= 0)
                {
                    allOutput[i] = allOutput[i - j] + 1;
                }
                else { allOutput[i] = 1; }
                //allOutput[i]=1;
                if (allOutput[i] > outputResult)
                {
                    outputResult = allOutput[i];
                }
            }
            return outputResult;
        }
        static public int MaxDistToClosest(int[] seats)
        {
            int maxResult = 1;
            //先找到第一个和最后一个1
            int firstOne = 0;
            while (seats[firstOne] != 1)
            {
                firstOne++;
            }
            maxResult = maxResult > firstOne ? maxResult : firstOne;


            int lastOne = seats.Length - 1;
            while (seats[lastOne] != 1)
            {
                lastOne--;
            }
            maxResult = maxResult > seats.Length - lastOne - 1 ? maxResult : seats.Length - lastOne - 1;


            int temp = firstOne;
            for (int i = firstOne + 1; i < lastOne+1; i++)
            {
                if (seats[i] == 1)
                {
                    maxResult = maxResult > ((i - temp) / 2 ) ? maxResult : ((i - temp) / 2 );
                    temp = i;
                }
            }
            return maxResult;
        }
        #region
        //打印树的所有路径（从根节点到叶节点）
        //输入一个树的根节点
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        static public IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> result = new List<string>();
            if (root == null)
            {
                return null;
            }
            List<List<int>> resultList = PrintAllPath(root);
            foreach (List<int> l in resultList)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < l.Count; j++)
                {
                    sb.Append(l[j] + "->");
                }
                result.Add(sb.Remove(sb.Length - 2, 2).ToString());
            }
            return result;
        }
        static private List<List<int>> PrintAllPath(TreeNode rootNode)
        {
            List<List<int>> returnList = new List<List<int>>();
            List<int> fatherData = new List<int>();

            FindNextNode(rootNode, ref returnList, fatherData);
            return returnList;

        }
        static private void FindNextNode(TreeNode fatherNode, ref List<List<int>> returnList,List<int> fatherData)
        {


            List<int> temp = new List<int>();
            temp = fatherData.ToList();
            temp.Add(fatherNode.val);
            List<int> leftFatherData = temp;
            List<int> rightFatherData = temp;
            //结束条件
            if (fatherNode.left == null&&fatherNode.right==null)
            {
                returnList.Add(temp);
                return;
            }


            if(fatherNode.left != null)
            {
               
                FindNextNode(fatherNode.left, ref returnList, leftFatherData);
            }

            if (fatherNode.right != null)
            {
                FindNextNode(fatherNode.right, ref returnList, rightFatherData);
            }


            
        }
        #endregion

        static void test()
        {
            int i; 
        }
    }
}
