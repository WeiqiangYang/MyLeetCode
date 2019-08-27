using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJI
{
    
 // Definition for a binary tree node.
  public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }

    class Program
    {
        public TreeNode target;
        static void Main(string[] args)
        {

        }
        
        /// <summary>
        /// 这个node如果是公共父节点，那么这个node的左节点下面有p或q，这个node的右节点下面有q或p
        /// </summary>
        /// <param name="node"></param>
        public bool recurseTree(TreeNode currentNode, TreeNode p,TreeNode q)
        {
            // If reached the end of a branch, return false.
            if (currentNode == null)
            {
                return false;
            }

            // Left Recursion. If left recursion returns true, set left = 1 else 0
            int left = this.recurseTree(currentNode.left, p, q) ? 1 : 0;

            // Right Recursion
            int right = this.recurseTree(currentNode.right, p, q) ? 1 : 0;

            // If the current node is one of p or q
            int mid = (currentNode == p || currentNode == q) ? 1 : 0;


            // If any two of the flags left, right or mid become True
            if (mid + left + right >= 2)
            {
                this.target = currentNode;
            }
            // Return true if any one of the three bool values is True.
            return (mid + left + right > 0);
            
        }
    }
}
