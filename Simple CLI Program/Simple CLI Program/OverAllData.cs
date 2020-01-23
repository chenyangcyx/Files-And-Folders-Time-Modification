using System;

namespace Simple_CLI_Program
{
    class OverAllData
    {
        public static OverAllData alldata = new OverAllData();

        //文件/文件夹的标识
        public const int FILETYPE_FILE = 1;
        public const int FILETYPE_FOLDER = 2;
        //时间参考基准
        public DateTime reference_time = new DateTime(0);
    }
}
