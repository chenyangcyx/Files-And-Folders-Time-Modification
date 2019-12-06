using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Folders_Time_Modification.Code
{
    class OverAllData
    {
        public static OverAllData alldata = new OverAllData();

        //文件列表
        public List<string> file_list = new List<string>();
        //相关设置--设置的选择
        public const int SETTING_DEFAULT = 1;
        public const int SETTING_SPECIFIC = 2;
        public int setting_num = 1;
        //相关设置--时间的设置
        public const string SETTING_CREATETIME_INIT = "";
        public const string SETTING_MODIFICATETIME_INIT = "";
        public const string SETTING_VISISTIME_INTI = "";
        public string setting_createtime = SETTING_CREATETIME_INIT;
        public string setting_modificatetime = SETTING_MODIFICATETIME_INIT;
        public string setting_visittime = SETTING_VISISTIME_INTI;
        //统计信息
        //日志输出
        public string output_log = "";
    }
}
