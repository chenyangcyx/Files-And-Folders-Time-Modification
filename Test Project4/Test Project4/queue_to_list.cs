using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project4
{
    class queue_to_list
    {
        public void test1()
        {
            List<string> str1 = new List<string>();
            str1.Add("1");
            str1.Add("2");
            str1.Add("3");
            str1.Add("4");
            str1.Add("5");
            str1.Add("6");
            str1.Add("7");
            str1.Add("8");
            str1.Add("9");
            str1.Add("10");
            //输出链表
            foreach (string str in str1)
                Console.WriteLine(str);

            //翻转
            str1.Reverse();
            foreach (string str in str1)
                Console.WriteLine(str);

            //转换成队列
            Console.WriteLine();
            Console.WriteLine();
            Queue<string> que1 = new Queue<string>(str1);
            while (que1.Count > 0)
                Console.WriteLine(que1.Dequeue());
        }
    }
}
