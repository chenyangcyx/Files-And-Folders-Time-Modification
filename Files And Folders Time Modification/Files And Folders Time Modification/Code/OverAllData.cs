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

        //UI设置
        public const string LISTVIEW_FILELIST_XUHAO_STRING = "序号";
        public const int LISTVIEW_FILELIST_XUHAO_WIDTH = 40;
        public const string LISTVIEW_FILELIST_NAME_STRING = "名称";
        public const int LISTVIEW_FILELIST_NAME_WIDTH = 120;
        public const string LISTVIEW_FILELIST_PATH_STRING = "路径";
        public const int LISTVIEW_FILELIST_PATH_WIDTH = 400;

        //文件列表
        public List<string> file_list = new List<string>();
        //相关设置--设置的选择
        public const int SETTING_DEFAULT = 1;
        public const int SETTING_SPECIFIC = 2;
        public int setting_num = SETTING_DEFAULT;
        //相关设置--时间的设置
        public const string SETTING_CREATETIME_INIT = "";
        public const string SETTING_MODIFICATETIME_INIT = "";
        public const string SETTING_VISISTIME_INTI = "";
        public string setting_createtime = SETTING_CREATETIME_INIT;
        public string setting_modificatetime = SETTING_MODIFICATETIME_INIT;
        public string setting_visittime = SETTING_VISISTIME_INTI;
        //统计信息
        public const int COUNT_ALL_FILE_COUNT_INTI=-1;
        public const int COUNT_ALL_FOLDER_COUNT_INTI = -1;
        public const int COUNT_ALL_FILEFOLDER_COUNT_INIT = -1;
        public const int COUNT_SETTED_FILE_COUNT_INIT = -1;
        public const int COUNT_SETTED_FOLDER_COUNT_INIT = -1;
        public const int COUNT_SETTED_FILEFOLDER_COUNT_INIT = -1;
        public int count_all_file_count = COUNT_ALL_FILE_COUNT_INTI;
        public int count_all_folder_count = COUNT_ALL_FOLDER_COUNT_INTI;
        public int count_all_filefolder_count = COUNT_ALL_FILEFOLDER_COUNT_INIT;
        public int count_setted_file_count = COUNT_SETTED_FILE_COUNT_INIT;
        public int count_setted_folder_count = COUNT_SETTED_FOLDER_COUNT_INIT;
        public int count_setted_filefolder_count = COUNT_SETTED_FILEFOLDER_COUNT_INIT;
        //日志输出
        public string output_log = "";

        //运行时变量
        Queue<FileFolderInfoNode> folder_info_temp_queue = new Queue<FileFolderInfoNode>();
        List<FileFolderInfoNode> filefolder_info_temp_list = new List<FileFolderInfoNode>();
    }
}
