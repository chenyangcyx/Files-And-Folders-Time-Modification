using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Folders_Time_Modification.Code
{
    class FileAndFolderFunction
    {
        OverAllData all = OverAllData.alldata;

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

        //根据存储地址的List链表中的值更新统计信息总数
        public void RefreshCountInfoByFileList(List<string> file_list)
        {
            all.count_all_file_count = 0;
            all.count_all_folder_count = 0;
            foreach(string path in file_list)
            {
                int file_type = CheckIfFileOrFolder(path);
                if (file_type == OverAllData.FILETYPE_FILE)
                    all.count_all_file_count++;
                else if (file_type == OverAllData.FILETYPE_FOLDER)
                {
                    //待写
                }
            }
            all.count_all_filefolder_count = all.count_all_file_count + all.count_all_folder_count;
        }

        //设置某文件/文件夹的时间
        public void SetFileORFolderTime(string path, int type, DateTime dt_create, DateTime dt_modify, DateTime dt_access)
        {
            //传入的路径为文件
            if(type==OverAllData.FILETYPE_FILE)
            {
                FileInfo fi = new FileInfo(path);
                fi.CreationTime = dt_create;
                fi.LastWriteTime = dt_modify;
                fi.LastAccessTime = dt_access;
            }
            //传入的路径为文件夹
            else if (type == OverAllData.FILETYPE_FOLDER)
            {
                DirectoryInfo di = new DirectoryInfo(path);
                di.CreationTime = dt_create;
                di.LastWriteTime = dt_modify;
                di.LastAccessTime = dt_access;
            }
        }
    }
}
