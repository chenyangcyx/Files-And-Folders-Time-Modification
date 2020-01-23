using System;
using System.Collections.Generic;
using System.IO;

namespace Simple_CLI_Program
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

        //从字符串中获取时间的返回值
        public DateTime GetDateTimeFromString(string str)
        {
            string[] str_split = str.Split(" ".ToCharArray());
            string[] date_str = str_split[0].Split("/".ToCharArray());
            string[] time_str = str_split[1].Split(":".ToCharArray());

            int year = int.Parse(date_str[0]);
            int month = int.Parse(date_str[1]);
            int day = int.Parse(date_str[2]);
            int hour = int.Parse(time_str[0]);
            int minute = int.Parse(time_str[1]);
            int second = int.Parse(time_str[2]);

            return new DateTime(year, month, day, hour, minute, second, DateTimeKind.Local);
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

        //根据传入的路径判断是文件/文件夹
        public int CheckIfFileOrFolder(string path)
        {
            if (File.Exists(path))
                return OverAllData.FILETYPE_FILE;
            else if (Directory.Exists(path))
                return OverAllData.FILETYPE_FOLDER;
            else
                return OverAllData.FILETYPE_FILE + OverAllData.FILETYPE_FOLDER;
        }
    }
}
