using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project2
{
    class TestDateTimeUtil
    {
        //从字符串中获取年、月、日、小时、分钟、秒钟
        public void GetDateTimeValueFromString(string str, out int year, out int month, out int day, out int hour, out int minute, out int second)
        {
            string[] str_split = str.Split(" ".ToCharArray());
            string[] date_str = str_split[0].Split("/".ToCharArray());
            string[] time_str = str_split[1].Split(":".ToCharArray());

            year = int.Parse(date_str[0]);
            month = int.Parse(date_str[1]);
            day = int.Parse(date_str[2]);
            hour = int.Parse(time_str[0]);
            minute = int.Parse(time_str[1]);
            second = int.Parse(time_str[2]);
        }

        //测试DateTime的直接输出形式
        public void OutputDateTimeInConsole(int year, int month, int day, int hour, int minute, int second)
        {
            DateTime dt = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Local);
            Console.WriteLine("时间：" + dt + Environment.NewLine);
        }
    }
}
