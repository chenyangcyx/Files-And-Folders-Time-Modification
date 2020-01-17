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
        public void RefreshCountInfoByFileList(List<string> file_list, out int filefolder_num, out int file_num, out int folder_num)
        {
            file_num = 0;
            folder_num = 0;
            foreach (string path in file_list)
            {
                int file_type = CheckIfFileOrFolder(path);
                if (file_type == OverAllData.FILETYPE_FILE)
                    file_num++;
                else if (file_type == OverAllData.FILETYPE_FOLDER)
                {
                    CountAllFileAndFolderNum(path, out int file_num_temp, out int folder_num_temp);
                    file_num += file_num_temp;
                    folder_num += folder_num_temp;
                }
            }
            filefolder_num = file_num + folder_num;
        }

        //统计一个文件夹中的所有子文件及子文件夹数量
        public void CountAllFileAndFolderNum(string path,out int file_num, out int folder_num)
        {
            Queue<FileFolderInfoNode> temp_folder = new Queue<FileFolderInfoNode>();
            FileFolderInfoNode temp = new FileFolderInfoNode();
            temp.type = OverAllData.FILETYPE_FOLDER;
            temp.folder_info = new DirectoryInfo(path);
            temp_folder.Enqueue(temp);
            folder_num = 1;
            file_num = 0;
            while (temp_folder.Count != 0)
            {
                FileFolderInfoNode fn = temp_folder.Dequeue();
                foreach (DirectoryInfo di in fn.folder_info.GetDirectories())
                {
                    FileFolderInfoNode fn_t = new FileFolderInfoNode();
                    fn_t.type = OverAllData.FILETYPE_FOLDER;
                    fn_t.folder_info = new DirectoryInfo(di.FullName);
                    temp_folder.Enqueue(fn_t);
                    folder_num++;
                }
                file_num += fn.folder_info.GetFiles().Length;
            }
        }

        //设置某文件/文件夹的时间
        public void SetFileORFolderTime(string path, int type, DateTime dt_create, DateTime dt_modify, DateTime dt_access,
            ref int count_setted_file_count, ref int count_setted_folder_count, ref int count_setted_filefolder_count)
        {
            //传入的路径为文件
            if (type == OverAllData.FILETYPE_FILE)
            {
                FileInfo fi = new FileInfo(path);
                fi.CreationTime = dt_create;
                fi.LastWriteTime = dt_modify;
                fi.LastAccessTime = dt_access;
                SettedFileAndFolderNumSelfAdd(OverAllData.FILETYPE_FILE, ref count_setted_file_count, ref count_setted_folder_count, ref count_setted_filefolder_count);
            }
            //传入的路径为文件夹
            else if (type == OverAllData.FILETYPE_FOLDER)
            {
                DirectoryInfo di = new DirectoryInfo(path);
                di.CreationTime = dt_create;
                di.LastWriteTime = dt_modify;
                di.LastAccessTime = dt_access;
                SettedFileAndFolderNumSelfAdd(OverAllData.FILETYPE_FOLDER, ref count_setted_file_count, ref count_setted_folder_count, ref count_setted_filefolder_count);
            }
        }

        //设置OverAllData中的值自增
        public void SettedFileAndFolderNumSelfAdd(int type, ref int count_setted_file_count, ref int count_setted_folder_count, ref int count_setted_filefolder_count)
        {
            if (type == OverAllData.FILETYPE_FILE)
                count_setted_file_count++;
            else if (type == OverAllData.FILETYPE_FOLDER)
                count_setted_folder_count++;
            count_setted_filefolder_count = count_setted_file_count + count_setted_folder_count;
        }

        //获取某一个文件夹下所有文件的链表
        public void GetFileFolderListFromFolder(string path,List<FileFolderInfoNode> all_filefolder)
        {
            Queue<FileFolderInfoNode> temp_folder = new Queue<FileFolderInfoNode>();
            FileFolderInfoNode temp = new FileFolderInfoNode();
            temp.type = OverAllData.FILETYPE_FOLDER;
            temp.folder_info = new DirectoryInfo(path);
            all_filefolder.Add(temp);
            temp_folder.Enqueue(temp);
            while (temp_folder.Count != 0)
            {
                FileFolderInfoNode fn = temp_folder.Dequeue();
                foreach (DirectoryInfo di in fn.folder_info.GetDirectories())
                {
                    FileFolderInfoNode fn_t = new FileFolderInfoNode();
                    fn_t.type = OverAllData.FILETYPE_FOLDER;
                    fn_t.folder_info = new DirectoryInfo(di.FullName);
                    all_filefolder.Add(fn_t);
                    temp_folder.Enqueue(fn_t);
                }
                foreach (FileInfo fi in fn.folder_info.GetFiles())
                {
                    FileFolderInfoNode fn_t = new FileFolderInfoNode();
                    fn_t.type = OverAllData.FILETYPE_FILE;
                    fn_t.file_info = new FileInfo(fi.FullName);
                    all_filefolder.Add(fn_t);
                }
            }
        }

        //获取一个文件夹下所有文件+文件夹和文件夹的链表
        public void GetFileFolderAndFolderListFromFolder(string path, List<FileFolderInfoNode> all_filefolder, List<FileFolderInfoNode> all_folder)
        {
            Queue<FileFolderInfoNode> temp_folder = new Queue<FileFolderInfoNode>();
            FileFolderInfoNode temp = new FileFolderInfoNode();
            temp.type = OverAllData.FILETYPE_FOLDER;
            temp.folder_info = new DirectoryInfo(path);
            all_filefolder.Add(temp);
            all_folder.Add(temp);
            temp_folder.Enqueue(temp);
            while (temp_folder.Count != 0)
            {
                FileFolderInfoNode fn = temp_folder.Dequeue();
                foreach (DirectoryInfo di in fn.folder_info.GetDirectories())
                {
                    FileFolderInfoNode fn_t = new FileFolderInfoNode();
                    fn_t.type = OverAllData.FILETYPE_FOLDER;
                    fn_t.folder_info = new DirectoryInfo(di.FullName);
                    all_filefolder.Add(fn_t);
                    all_folder.Add(fn_t);
                    temp_folder.Enqueue(fn_t);
                }
                foreach (FileInfo fi in fn.folder_info.GetFiles())
                {
                    FileFolderInfoNode fn_t = new FileFolderInfoNode();
                    fn_t.type = OverAllData.FILETYPE_FILE;
                    fn_t.file_info = new FileInfo(fi.FullName);
                    all_filefolder.Add(fn_t);
                }
            }
        }
    }
}
