using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试INT的最大值
            Console.WriteLine("最大值："+int.MaxValue);
            //测试INT的最大值
            Console.WriteLine("最小值："+int.MinValue);

            //测试long的最大值
            Console.WriteLine("最大值：" + Int64.MaxValue);
            //测试long的最大值
            Console.WriteLine("最小值：" + Int64.MinValue);
            //int i = 0;
            //while (true)
            //{
            //    //测试i的最大值
            //    Console.WriteLine(i++);
            //}


            int year, month, day, hour, minute, second;
            TestDateTimeUtil tdtu = new TestDateTimeUtil();
            tdtu.GetDateTimeValueFromString("2019/12/11 23:20:11", out year, out month, out day, out hour, out minute, out second);
            Console.WriteLine("year = " + year);
            Console.WriteLine("month = " + month);
            Console.WriteLine("day = " + day);
            Console.WriteLine("hour = " + hour);
            Console.WriteLine("minute = " + minute);
            Console.WriteLine("second = " + second);
        }
    }
}
