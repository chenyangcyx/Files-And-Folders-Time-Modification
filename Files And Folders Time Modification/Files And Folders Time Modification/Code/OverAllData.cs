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

        //UI设置-文件夹列表
        public const string LISTVIEW_FILELIST_XUHAO_STRING = "序号";
        public const int LISTVIEW_FILELIST_XUHAO_WIDTH = 40;
        public const string LISTVIEW_FILELIST_NAME_STRING = "名称";
        public const int LISTVIEW_FILELIST_NAME_WIDTH = 120;
        public const string LISTVIEW_FILELIST_PATH_STRING = "路径";
        public const int LISTVIEW_FILELIST_PATH_WIDTH = 400;
        //UI设置-统计信息列表
        public const string LISTVIEW_COUNTINFO_COLOUMN1_STRING = "项目";
        public const int LISTVIEW_COUNTINFO_COLOUMN1_WIDTH = 120;
        public const string LISTVIEW_COUNTINFO_COLOUMN2_STRING = "数据";
        public const int LISTVIEW_COUNTINFO_COLOUMN2_WIDTH = 55;
        public const string LISTVIEW_COUNTINFO_COLOUMN3_STRING = "进度";
        public const int LISTVIEW_COUNTINFO_COLOUMN3_WIDTH = 40;
        public const string LISTVIEW_COUNTINFO_INFO1_STRING = "文件及文件夹 数量";
        public const string LISTVIEW_COUNTINFO_INFO1_FILENUM_STRING = "文件";
        public const string LISTVIEW_COUNTINFO_INFO1_FOLDERNUM_STRING = "文件夹";
        public const string LISTVIEW_COUNTINFO_INFO1_FILEANDFOLDERNUM_STRING = "文件及文件夹";
        public const string LISTVIEW_COUNTINFO_INFO2_STRING = "已完成设置 数量";
        public const string LISTVIEW_COUNTINFO_INFO2_FILENUM_STRING = "文件";
        public const string LISTVIEW_COUNTINFO_INFO2_FOLDERNUM_STRING = "文件夹";
        public const string LISTVIEW_COUNTINFO_INFO2_FILEANDFOLDERNUM_STRING = "文件及文件夹";

        //文件列表
        public List<string> listview_file_list = new List<string>();
        //相关设置--设置的选择
        public const int SETTING_DEFAULT = 1;
        public const int SETTING_SPECIFIC = 2;
        public int setting_choice = SETTING_DEFAULT;
        //相关设置--时间的设置
        public const string SETTING_CREATETIME_INIT = "";
        public const string SETTING_MODIFICATETIME_INIT = "";
        public const string SETTING_VISISTIME_INTI = "";
        public string setting_createtime = SETTING_CREATETIME_INIT;
        public string setting_modificatetime = SETTING_MODIFICATETIME_INIT;
        public string setting_visittime = SETTING_VISISTIME_INTI;
        //统计信息
        public const int COUNT_ALL_FILE_COUNT_INTI = 0;
        public const int COUNT_ALL_FOLDER_COUNT_INTI = 0;
        public const int COUNT_ALL_FILEFOLDER_COUNT_INIT = 0;
        public const int COUNT_SETTED_FILE_COUNT_INIT = 0;
        public const int COUNT_SETTED_FOLDER_COUNT_INIT = 0;
        public const int COUNT_SETTED_FILEFOLDER_COUNT_INIT = 0;
        public int count_all_file_count = COUNT_ALL_FILE_COUNT_INTI;
        public int count_all_folder_count = COUNT_ALL_FOLDER_COUNT_INTI;
        public int count_all_filefolder_count = COUNT_ALL_FILEFOLDER_COUNT_INIT;
        public int count_setted_file_count = COUNT_SETTED_FILE_COUNT_INIT;
        public int count_setted_folder_count = COUNT_SETTED_FOLDER_COUNT_INIT;
        public int count_setted_filefolder_count = COUNT_SETTED_FILEFOLDER_COUNT_INIT;
        //文件/文件夹的标识
        public const int FILETYPE_FILE = 1;
        public const int FILETYPE_FOLDER = 2;

        //运行时变量
        public List<FileFolderInfoNode> list_all_filefolder = new List<FileFolderInfoNode>();         //统计的所有文件和文件夹的列表
        public List<FileFolderInfoNode> list_all_folder = new List<FileFolderInfoNode>();             //统计的所有文件夹的列表
    }
}
