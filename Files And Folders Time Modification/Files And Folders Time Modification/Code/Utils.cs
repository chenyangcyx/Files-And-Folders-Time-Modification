using System;
using System.Collections.Generic;

namespace Files_And_Folders_Time_Modification.Code
{
    class Utils
    {
        //检查输入时间格式是否正确
        public bool CheckTimeString(string content)
        {
            //检查是否有空格分割，
            if (!content.Contains(" "))
                return false;
            //分别取日期和时间
            string[] str = content.Split(" ".ToCharArray());
            //检查日期是否有“/”符号
            if (!str[0].Contains("/"))
                return false;
            //检查时间是否有“:”符号
            if (!str[1].Contains(":"))
                return false;
            //获取年月日
            string[] date_str = str[0].Split("/".ToCharArray());
            //检查年
            if (int.Parse(date_str[0]) < 1970)
                return false;
            //检查月
            if (int.Parse(date_str[1]) > 12 || int.Parse(date_str[1]) < 1)
                return false;
            //检查日
            if (int.Parse(date_str[2]) > 31 || int.Parse(date_str[2]) < 1)
                return false;
            //获取时间
            string[] time_str = str[1].Split(":".ToCharArray());
            //检查小时
            if (int.Parse(time_str[0]) > 23 || int.Parse(time_str[0]) < 0)
                return false;
            //检查分钟
            if (int.Parse(time_str[0]) > 59 || int.Parse(time_str[0]) < 0)
                return false;
            //检查秒钟
            if (int.Parse(time_str[0]) > 59 || int.Parse(time_str[0]) < 0)
                return false;

            return true;
        }

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

        //从一个DateTime链表中获取最小的时间
        public DateTime GetMostEarlyTimeFromList(List<DateTime> all_time)
        {
            DateTime result = all_time[0];
            foreach (DateTime dt in all_time)
            {
                if (DateTime.Compare(result, dt) > 0)
                    result = dt;
            }
            return result;
        }

        //从一个DateTime链表中获取最晚的时间
        public DateTime GetMostLateTimeFromList(List<DateTime> all_time)
        {
            DateTime result = all_time[0];
            foreach (DateTime dt in all_time)
            {
                if (DateTime.Compare(result, dt) < 0)
                    result = dt;
            }
            return result;
        }
    }
}
