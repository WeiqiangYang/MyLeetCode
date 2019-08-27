using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode(1);
            TreeNode root1 = new TreeNode(2);
            TreeNode root2 = new TreeNode(3);
            TreeNode root3 = new TreeNode(5);
            root.left = root1; root.right = root2;
            //root1.right = root3;

            List<List<int>> returnList = PrintAllPath(root);
            Console.ReadKey();
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        private List<List<int>> PrintAllPath(TreeNode rootNode)
        {
            List<List<int>> returnList = new List<List<int>>();
            List<int> fatherData = new List<int>();

            FindNextNode(rootNode, ref returnList, fatherData);
            return returnList;

        }
         private void FindNextNode(TreeNode fatherNode, ref List<List<int>> returnList, List<int> fatherData)
        {


            List<int> temp = fatherData;
            temp.Add(fatherNode.val);
            List<int> leftFatherData = temp;
            List<int> rightFatherData = temp;
            //结束条件
            if (fatherNode.left == null && fatherNode.right == null)
            {
                returnList.Add(temp);
                return;
            }


            if (fatherNode.left != null)
            {

                FindNextNode(fatherNode.left, ref returnList, leftFatherData);
            }

            if (fatherNode.right != null)
            {
                FindNextNode(fatherNode.right, ref returnList, rightFatherData);
            }
        }


    }
}
