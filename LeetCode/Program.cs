using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //NofQueen(5);
            //var vvv = array;
            //Console.ReadKey();

            //Program p = new Program();
            //p.output = new List<List<string>>();
            //var vvv =  p.solveNQueens(4);
            //Console.ReadKey();

            //Program p = new Program();
            //int[] i = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 100 };
            //bool vvv = p.canPartition(i);
            //Console.WriteLine(vvv.ToString());
            //Console.ReadKey();

            //Program p = new Program();
            //int[] value = new int[] { 1,6,18,22,28 };
            //int[] weight = new int[] { 1,2,5,6,7 };
            //int i = p.BagProblem(weight,value,11);
            //p.DivisorGame(100);
            //Console.WriteLine(i);
            //Console.ReadKey();

            //Program p = new Program();
            //int[] i = new int[] { 7, 1, 5, 3, 6, 4 };
            //int ii = p.MaxProfit(i);
            //Console.ReadKey();

            //Program p = new Program();
            //int[] i = new int[] { -2,-1,-2};
            //int ii = p.MaxSubArray(i);
            //Console.ReadKey();

            //Program p = new Program();
            //int[] i =p.CountBits(5);
            //Console.ReadKey();

            //Program p = new Program();
            //int[] i = new int[] { 3, 7, 2, 3 };
            //bool b = p.StoneGame(i);
            //Console.ReadKey();

            //Program p = new Program();
            //int[][] i = new int[2][] ;
            //i[0] = new int[3] { 1, 2, 5 };
            //i[1] = new int[3] { 3, 2, 1 };
            //int b = p.MinPathSum(i);
            //Console.ReadKey();

            //Program p = new Program();
            //ListNode2 t1 = new ListNode2(1);
            //ListNode2 t2 = new ListNode2(8);
            //ListNode2 t3 = new ListNode2(3);
            //ListNode2 ta = new ListNode2(0);
            //ListNode2 tb = new ListNode2(6);
            //ListNode2 tc = new ListNode2(4);
            //t1.next = t2;
            ////t2.next = t3;
            ////ta.next = tb;
            ////tb.next = tc;
            //ListNode2 b = p.AddTwoNumbers(t1,ta);
            //Console.ReadKey();

            // Program p = new Program();
            //int i = p.MaxSubArrayMethodZhengShuZengYi(new int[] { -1, 1, 2, 1 });
            // Console.ReadKey();
            int i = 2147483647;
            int j = 1;
            Program p = new Program();
           int result =  p.Divide(i, j);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        #region 题257：二叉树的所有路径

        //打印树的所有路径（从根节点到叶节点）
        //输入一个树的根节点
        public class TreeNode257
        {
            public int val;
            public TreeNode257 left;
            public TreeNode257 right;
            public TreeNode257(int x) { val = x; }
        }
        static public IList<string> BinaryTreePaths(TreeNode257 root)
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
        static private List<List<int>> PrintAllPath(TreeNode257 rootNode)
        {
            List<List<int>> returnList = new List<List<int>>();
            List<int> fatherData = new List<int>();

            FindNextNode(rootNode, ref returnList, fatherData);
            return returnList;

        }
        static private void FindNextNode(TreeNode257 fatherNode, ref List<List<int>> returnList, List<int> fatherData)
        {


            List<int> temp = new List<int>();
            temp = fatherData.ToList();
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
        #endregion
        #region 题51：N皇后问题
        static List<int[]> array;
        static void NofQueen(int n)
        {
            array = new List<int[]>();
            Helper(ref n, 0);

            //输入是什么？输出是什么？



        }

        //传入一个x坐标，传入一个y坐标，传入深度N，传入一个根据历史皇后位置，导致以后的空位里，无法成为皇后位的坐标集。
        //回溯时坐标+1，需要维护一个冲突坐标集

        //结束条件：冲突或数组已到尽头。
        //这好像还是一个全遍历问题，只不过有剪枝，提前发现错误之后就不用继续往下走
        //输入一个列深度y(即当前行数)，输入一个y-1列上的皇后分布
        //然后循环看此列上每一个点与之前y -1列的皇后冲突
        //如果不冲突进递归
        //如果冲突就是结束条件直接return
        //如果到底了就输出一个结果
        static void Helper(ref int n, int yCoord)
        {
            if (yCoord > n)
            { return; }
            //int[] iarray = new int[2];
            for (int i = 0; i < n; i++)
            {
                foreach (int[] intArray in array)
                {
                    if (intArray[0] == i || Math.Abs(intArray[0] - yCoord) == Math.Abs(intArray[1] - i))
                    {
                        return;
                    }
                }
                //如果不冲突
                array.Add(new int[2] { yCoord, i });
                Helper(ref n, yCoord + 1);
            }
            //return iarray
        }
        #endregion
        #region N皇后官方结题
        int[] rows;
        // "hill" diagonals
        int[] hills;
        // "dale" diagonals
        //hill存放反对角线，dales存放正对角线

        //dales是横纵坐标相加，不会超过2n-2。但是hills是横纵坐标相减，最小为0-(n-1)，为了防止出现数组负数下标，扩大了数组下标，所以其他用到hills的地方都是（row-col +2*n）
        //hills是对负值取反的
        //首先hills长度为4*n-1
        //然后在放置皇后和取消皇后时，把hills[row - col + 2 * n]置1或置0因为row - col区间为[-（n-1）,n-1]
        int[] dales;
        int n;
        // output
        List<List<string>> output;
        // queens positions
        int[] queens;
        public List<List<string>> solveNQueens(int n)
        {
            this.n = n;
            rows = new int[n];
            hills = new int[4 * n - 1];
            dales = new int[2 * n - 1];
            queens = new int[n];

            backtrack(0);
            return output;
        }
        public void backtrack(int row)
        {
            for (int col = 0; col < n; col++)
            {
                if (isNotUnderAttack(row, col))
                {
                    placeQueen(row, col);
                    // if n queens are already placed
                    if (row + 1 == n) addSolution();
                    // if not proceed to place the rest
                    else backtrack(row + 1);
                    // backtrack

                    //回溯：当递归方法backtrack返回时，把当前层的backtrack添加的queen移除掉，然后继续for循环，寻找同列下一个queen或者如果col到头了返回上一层
                    removeQueen(row, col);
                }
            }
        }
        /// <summary>
        /// 传入一个坐标，判断这个坐标是否会被已有的皇后攻击？
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool isNotUnderAttack(int row, int col)
        {
            int res = rows[col] + hills[row - col + 2 * n] + dales[row + col];
            return (res == 0) ? true : false;
        }
        public void placeQueen(int row, int col)
        {
            queens[row] = col;
            rows[col] = 1;
            hills[row - col + 2 * n] = 1;  // "hill" diagonals
            dales[row + col] = 1;   //"dale" diagonals
        }
        public void removeQueen(int row, int col)
        {
            queens[row] = 0;
            rows[col] = 0;
            hills[row - col + 2 * n] = 0;
            dales[row + col] = 0;
        }
        public void addSolution()
        {
            List<string> solution = new List<string>();
            for (int i = 0; i < n; ++i)
            {
                int col = queens[i];
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < col; ++j) sb.Append(".");
                sb.Append("Q");
                for (int j = 0; j < n - col - 1; ++j) sb.Append(".");
                solution.Add(sb.ToString());
            }
            output.Add(solution);
        }
        #endregion
        #region 题416：分隔等和子集

        //先排序，按从大到小排序
        //排序之后从，最大数一定包括在结果里，开始
        public bool CanPartition(int[] nums)
        {

            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            if (sum % 2 != 0)
            {
                return false;
            }

            //找到一个集合，集合元素和等于fenGeSum
            int target = sum / 2;

            //对于nums[i]而言
            bool[,] result = new bool[target + 1, nums.Length];



            return true;
            //return true;

        }



        #endregion


        #region 322. 零钱兑换
        public int CoinChange(int[] coins, int amount)
        {
            //对于第i个coin，可以加可以不加
            //如果加上第i个coin就能=amount，那么其他N-1个coin必有一个组合=amount-coins[i]
            //如果不加第i个coin就能=amount
            return 1;
        }
        #endregion


        #region 经典背包问题
        int[] weight;
        int[] value;
        public int BagProblem(int[] weight, int[] value, int cap)
        {
            this.weight = weight;
            this.value = value;
            //首先总weight要小于cap
            //设f[count][cap]代表有count个weight，总weight小于cap的最大值
            //对于weight[i]，最大值为max{ f[count-1][cap] , f[count-1][cap-weight[i]]+weight[i] }
            //分别代表忽略weight[i]和加入weight[i]


            int[,] result = new int[weight.Length + 1, cap + 1];
            for (int i = 0; i < weight.Length; i++)
            {
                result[i, 0] = 0;
            }
            for (int i = 0; i < cap + 1; i++)
            {
                result[0, i] = 0;
            }
            for (int i = 1; i < weight.Length + 1; i++)
            {

                for (int j = 1; j < cap + 1; j++)
                {
                    if (weight[i - 1] > j)
                        result[i, j] = result[i - 1, j];
                    else
                        result[i, j] = Math.Max(result[i - 1, j], result[i - 1, j - weight[i - 1] >= 0 ? j - weight[i - 1] : 0] + value[i - 1]);
                }
            }

            return result[weight.Length, cap];


            //return 1;
            //return BagProblemHelper(weight.Length-1, cap);
        }

        //返回的是最大总value值
        private int BagProblemHelper(int number, int cap)
        {
            //终止条件
            if (number == 0)
            {
                if (weight[number] < cap)
                    return value[number];
                else return 0;
            }
            return Math.Max(BagProblemHelper(number - 1, cap), BagProblemHelper(number - 1, cap - weight[number]) + value[number]);
        }
        #endregion
        #region 1025：除数博弈
        //爱丽丝先开局
        //设进行到N步后剩下的数值为Y，此时该X选了，X选完XX选。
        //当Y为2时，X再进行2步选择结束,所以X的对手输，无法更改
        //当Y为3时，X再进行3步游戏结束，所以X输，无法更改
        //当Y为4时，X为了使自己赢，要选择1，剩3，此时XX必输
        //当Y为5时，X只能选1，X必输
        //当Y为6时，X选2，X对手必输
        //当Y=7时，X只能选1，然后XX选2，X必输
        //当Y=8时，X选1，XX只能选1，然后X选2，XX必输
        //当Y=9时，X选3，XX从6里选，X必输；


        //总结：X做的选择要使下一步他的对手只能从3里选
        //第一步：选出能整除N的数
        public bool DivisorGame(int N)
        {
            if (N < 2)
                return false;
            bool[] dp = new bool[N + 1];
            dp[0] = false;
            dp[1] = false;
            for (int i = 2; i <= N; i++)
                for (int j = 1; j < i; j++)
                {
                    if (!dp[i - j] && i % j == 0)
                    {//j能被i整除且bob拿到i-j会输
                        dp[i] = true;
                        break;
                    }
                }
            return dp[N];
        }
        #endregion

        #region 121. 买卖股票的最佳时机
        //从后往前，维护一个当前最大数，，对于第i个数，最大利润等于当前最大数-i。比较每个最大利润即可
        //currentMaxValue[1]代表最大利润差出现时，最大price的下标，currentMaxValue[0]代表最大利润差
        public int MaxProfit(int[] prices)
        {
            int currentMaxXiaBiao = prices.Length - 1;//当前最大price的下标，初试为数组最后一位
            int[] currentMaxValue = new int[2] { 0, prices.Length - 1 };                  //当前最大利润差
            int[] maxPrice = new int[prices.Length];
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                //currentMaxValue = prices[currentMaxXiaBiao] - prices[i];

                //第一种可能，遇到一个比max还大的数，则更新最大值下标
                if (prices[currentMaxXiaBiao] < prices[i])
                {
                    currentMaxXiaBiao = i;
                }

                //第二种可能，遇到一个比max小的数，则计算利润差与最大利润差对比，若大于最大利润差则更新最大利润差
                else if (currentMaxValue[0] < prices[currentMaxXiaBiao] - prices[i])
                {
                    currentMaxValue[0] = prices[currentMaxXiaBiao] - prices[i];
                    currentMaxValue[1] = currentMaxXiaBiao;
                }
            }
            return currentMaxValue[0];
        }
        #endregion
        #region 53.最大子序和
        //这题可转化为求一次股票问题，但是一次股票必须有买入和抛售，这题不需要，所以要考虑①：单个最大值，②：从头到尾直接最大不用减。
        //而且这个有负数，很麻烦，首先考虑不用减， currentMaxValue等于sum[]的最大值，其次考虑最后一位减倒数第二位
        //剩下的和股票差不多
        //目前这个方法有点傻逼应该换个方法做
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
            { return nums[0]; }


            int[] sums = new int[nums.Length];
            int currentMaxValue = nums[0];
            sums[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sums[i] = sums[i - 1] + nums[i];
                if (sums[i] > nums[i])
                    //这里取nums，sums，currentMaxValue三者的最大值
                    //①：单个最大值，②：从头到尾直接最大不用减
                    currentMaxValue = currentMaxValue < sums[i] ? sums[i] : currentMaxValue;
                else currentMaxValue = currentMaxValue < nums[i] ? nums[i] : currentMaxValue;
            }

            int max = sums[sums.Length - 1];
            currentMaxValue = currentMaxValue > sums[sums.Length - 1] - sums[sums.Length - 2] ? currentMaxValue : sums[sums.Length - 1] - sums[sums.Length - 2];
            for (int i = sums.Length - 2; i >= 0; i--)
            {
                if (sums[i] > max)
                { max = sums[i]; }
                else if (max - sums[i] > currentMaxValue)
                { currentMaxValue = max - sums[i]; }
            }
            return currentMaxValue;
        }

        //更好的方法：正数增益
        //假设你是一个选择性遗忘的赌徒，数组表示你这几天来赢钱或者输钱， 你用sum来表示这几天来的输赢， 用ans来存储你手里赢到的最多的钱，

        //如果昨天你手上还是输钱（sum< 0），你忘记它，明天继续赌钱； 如果你手上是赢钱(sum > 0), 你记得，你继续赌钱； 你记得你手气最好的时候
        //public int MaxSubArrayMethodTwo(int[] nums)
        //{

        //}
        private int MaxSubArrayMethodFenZhi(int[] intArray)
        {
            if (intArray.Length == 1)
            {
                return intArray[0];
            }
            int leftCount = intArray.Length / 2;
            //计算包含了左边界数字的最大值
            int leftBord = 0, leftBordMax = intArray[leftCount - 1];
            for (int i = leftCount - 1; i >= 0; i--)
            {
                leftBord += intArray[i];
                if (leftBordMax < leftBord)
                {
                    leftBordMax = leftBord;
                }
            }
            //计算包含了右边界数字的最大值
            int rightBord = 0, rightBordMax = 0;
            for (int i = leftCount; i < intArray.Length; i++)
            {
                rightBord += intArray[i];
                if (rightBordMax < rightBord)
                {
                    rightBordMax = rightBord;
                }
            }
            //递归计算左边和右边的最大子数组的值
            int leftMax, rightMax;
            leftMax = MaxSubArrayMethodFenZhi(intArray.Take(leftCount).ToArray());
            rightMax = MaxSubArrayMethodFenZhi(intArray.Skip(leftCount).ToArray());
            //返回三个数里最大的一个
            return Math.Max(Math.Max(leftMax, rightMax), leftBordMax + rightBordMax);
        }

        //分治法：这个数组要么在最左边要么在最右边，要么在包含左右的中间

            /// <summary>
            /// 正数增益法，比速度第一的慢24MS，看了下速度第一的发现我的想法还是有一丢丢问题，总想着为负数要特殊处理，实际上为负数还是返回更大值，也不用把Temp值置为0
            /// </summary>
            /// <param name="intArray"></param>
            /// <returns></returns>
         private int MaxSubArrayMethodZhengShuZengYi(int[] intArray)
        {
            int Max = intArray[0];
            int tempResult = intArray[0];
            if (tempResult <= 0)
            {
                tempResult = 0;
            }
            for (int i = 1; i < intArray.Length; i++)
            {
                if ((tempResult += intArray[i]) <= 0)
                {
                    tempResult = 0;
                    Max = Math.Max(Max, intArray[i]);
                }
                else
                {
                    Max = Math.Max(Max, tempResult);
                }

            }

            return Max;
        }
        #endregion

        #region 70.爬楼梯

        public int ClimbStairs(int n)
        {
            if (n == 1)
            { return 1; }
            if (n == 2)
            { return 2; }
            int[] result = new int[n];
            result[0] = 1;
            result[1] = 2;
            for (int i = 2; i < n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
            return result[n - 1];
        }
        #endregion

        #region 746.使用最小花费爬楼梯
        //有0——n-1个楼梯，当爬到n的时候结束，
        //①那么爬到n可以从n-1爬1格也可以从 n-2爬两格，肯定选花费较小的那个
        //②那么爬到n-1可以从n-2爬1格也可以从 n-3爬两格，肯定选花费较小的那个
        //③那么爬到n-2可以从n-3爬1格也可以从 n-4爬两格，肯定选花费较小的那个

        //根据以上分析写出递归公式：F(n) = Min(F(n-1)+cost[n-1],F(n-2)+cost[n-2])
        //然后确定初试条件：F(0)和F(1)都为0，因为可以免费选择从0还是从1跳，所以到达0或1的代价是0；然后到达N的代价是  Min（到达N-1的代价+从N-1离开的代价，到达N-2的代价+从N-2离开的代价）
        //根据递归公式从头进行迭代：首先F(2) =Min(F(0)+cost[0],F(1)+cost[1]); 然后F(3) = Min(F(1)+cost[1],F(2)+cost[2])
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 1)
                return cost[0];
            if (cost.Length == 2)
                return Math.Min(cost[0], cost[1]);

            int[] result = new int[cost.Length + 1];
            result[0] = 0;
            result[1] = 0;
            for (int i = 2; i < cost.Length + 1; i++)
            {
                result[i] = Math.Min(result[i - 1] + cost[i - 1], result[i - 2] + cost[i - 2]);
            }
            return result[cost.Length];
        }
        #endregion


        #region 198.打家劫舍

        //有0——i-1家房子，最后一次一定是打劫i-2和i-1这两家之中的一家。
        //设最后打劫第N家（注意不一定打劫这一家，因为有可能不打劫这一家而打劫第N-1家，反而收益更高），
        //设每家有钱money[]，则总打劫金额为F(N) =Max（ F(N-2)+money[N] ，F(N-1)）
        //初始条件:F(0) = money(0);F(1) = Max（+money[1] ，F(0)）
        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);
            int[] result = new int[nums.Length];
            result[0] = nums[0];
            result[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                result[i] = Math.Max(result[i - 2] + nums[i], result[i - 1]);
            }
            return result[nums.Length - 1];
        }
        #endregion

        #region 338.比特位计数

        //对于数字i的二进制i[]，最高位一定是1
        //从第0位到第N-1位，每一位都代表2的n次方，一个数可以拆解为2的0——n-1次方相加
        public int[] CountBits(int num)
        {
            int[] result = new int[num + 1];
            int[] level = new int[32];
            for (int i = 0; i < 32; i++)
            { level[i] = (int)Math.Pow(2, i); }
            for (int i = 2; i < num + 1; i++)
            {
                int temp = i;
                for (int j = 31; j >= 0; j--)
                {
                    temp = temp - level[j];
                    if (temp >= 0)
                    {
                        result[i]++;
                    }
                    else { temp = temp + level[j]; }
                }
            }
            result[0] = 0;
            if (num > 0)
                result[1] = 1;
            return result;
        }
        #endregion

        #region 877.石子游戏
        //X先选Y后选，选择要当前最优并对对方最劣，也就是说，选左或右之后，保证对方再选完时，选择的差值偏小。
        //对于F(1)，看选左之后，剩下的两端最大值减去左，和选右之后，剩下的两端减去右，二者哪个更小。
        //对于F(2)也是这样。
        //一直持续到F(N-1)，然后F(N)没得选
        //大于小于都没问题，等于之后继续比较，再等于再继续比较

        //动态规划：设dp[i][j]存储一个长度为2的数组，代表对于第i——j这一堆石子，先手拿的最大值和后手拿的最大值
        public bool StoneGame(int[] piles)
        {
            return false;
        }
        #endregion

        #region 64.最小路径和
        //动态规划，设dp[i][j]为到达坐标(i,j)的最小值，dp[i][j]=Min(dp[i-1][j]+grid[i-1,j],dp[i][j-1]+grid[i,j-1])
        //dp[0][j]和dp[i][0]都是固定已知的
        public int MinPathSum(int[][] grid)
        {
            //grid.Length //代表多少行
            //grid[0].Length 代表一行多少列
            int[,] result = new int[grid.Length, grid[0].Length];
            //初始状态赋值
            result[0,0] = 0;
            for (int i=1; i < grid[0].Length;i++)
            {
                result[0,i] = result[0,i - 1] + grid[0][i - 1];
            }
            for (int i = 1; i < grid.Length; i++)
            {
                result[i,0] = result[i - 1,0] + grid[i - 1][0];
            }

            //依次给每一行赋值
            for(int i =1;i<grid.Length;i++)
            {
                for(int j=1;j<grid[0].Length;j++)
                {
                    result[i,j] = Math.Min(result[i - 1,j] + grid[i - 1][j], result[i,j - 1] + grid[i][j - 1]);
                }
            }
            return result[grid.Length - 1,grid[0].Length - 1] + grid[grid.Length - 1][grid[0].Length - 1];
        }
        #endregion
        #region 2.两数相加
        public class ListNode2
        {
            public int val;
            public ListNode2 next;
            public ListNode2(int x) { val = x; }
        }
        public ListNode2 AddTwoNumbers(ListNode2 l1, ListNode2 l2)
        {
            ListNode2 result = new ListNode2(0);
            int isOverTen = 0;//如果某两个数相加需要进位，那么把这个变量置为true//这里是用bool好还是用int好？
            //初值：如果大于等于十要减去十
            if (l1.val + l2.val >= 10)
            {
                result.val = l1.val + l2.val - 10 +isOverTen;
                isOverTen = 1;
            }
            else
            {
                result.val = l1.val + l2.val+isOverTen;
                isOverTen = 0;
            }


            ListNode2 tempResultNode,tempOneNode,tempTwoNode;
            tempResultNode = result;
            tempOneNode = l1;tempTwoNode = l2;

            while (tempOneNode.next!=null||tempTwoNode.next!=null)
            {
                tempResultNode.next = new ListNode2(0);
                if ((tempOneNode.next == null ? 0 : tempOneNode.next.val)
                        + (tempTwoNode.next == null ? 0 : tempTwoNode.next.val) >= 10)
                {
                    tempResultNode.next.val 
                        = (tempOneNode.next == null ? 0 : tempOneNode.next.val) 
                        + (tempTwoNode.next == null ? 0 : tempTwoNode.next.val) 
                        - 10 + isOverTen;
                    //完成了一次运算，指针向后移动一位
                    isOverTen = 1;
                    tempResultNode = tempResultNode.next;
                    tempOneNode = tempOneNode.next;
                    tempTwoNode = tempTwoNode.next;
                }
                else
                {
                    tempResultNode.next.val 
                        = (tempOneNode.next == null ? 0 : tempOneNode.next.val)
                        + (tempTwoNode.next == null ? 0 : tempTwoNode.next.val)
                        + isOverTen;

                    isOverTen = 0;
                    tempResultNode = tempResultNode.next;
                    tempOneNode = tempOneNode.next;
                    tempTwoNode = tempTwoNode.next;
                }
            }
            return result;
        }
        #endregion

        #region 29.两数相除
        public int Divide(int dividend, int divisor)
        {
          
            if (dividend == 0)
                return 0;
            bool isZhengShu = (dividend > 0&&divisor>0)||(dividend<0&divisor<0);
            int result = 0;

            if (dividend== int.MinValue)
            {
                result++;
                dividend = dividend + Math.Abs(divisor);
                if(Math.Abs(divisor)==1)
                {
                    return (int)Math.Pow(2, 31) - 1;
                }
            }
            
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);
            
            
            while(dividend>=divisor)
            {
                dividend = dividend - divisor;
                ++result;
            }
            if(!isZhengShu)
            {
                return -result;
            }
            return  result;
        }

        #endregion

    }

}
