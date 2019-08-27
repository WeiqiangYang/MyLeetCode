using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTree
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine( ConstructMaximumBinaryTree(new int[10] { 3, 4, 65, 1, 4, 6, 12, 4, 6, 3 }).val);
        }
        //给定一个不含重复元素的整数数组。一个以此数组构建的最大二叉树定义如下：
        //二叉树的根是数组中的最大元素。
        //左子树是通过数组中最大值左边部分构造出的最大二叉树。
        //右子树是通过数组中最大值右边部分构造出的最大二叉树。
        //通过给定的数组构建最大二叉树，并且输出这个树的根节点。
        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if(nums.Length<1)
            { return null; }
            int max = nums[0], maxXiaBiao = 0;
            for(int i =1;i<nums.Length; i++)
            {
                if(nums[i]>max)
                {
                    max = nums[i];
                    maxXiaBiao = i;
                }
            }
            TreeNode treeNode = new TreeNode(max);
            treeNode.left = ConstructMaximumBinaryTree(nums.Take(maxXiaBiao).ToArray());
            treeNode.right = ConstructMaximumBinaryTree(nums.Skip(maxXiaBiao + 1).ToArray());
            return treeNode;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
