using System;
using System.Collections.Generic;
using System.IO;

namespace Simple_CLI_Program
{
    class FileAndFolderFunction
    {
        Utils utils = new Utils();

        //修改单个文件的时间（传入path）
        public void ChangeOneFileTime(string path, DateTime create, DateTime modify, DateTime access)
        {
            FileInfo fi = new FileInfo(path);
            fi.CreationTime = create;
            fi.LastWriteTime = modify;
            fi.LastAccessTime = access;
            Console.WriteLine("文件" + path + "时间修改成功！");
        }

        //修改单个文件的时间（传入FileInfo）
        public void ChangeOneFileTime(FileInfo fi, DateTime create, DateTime modify, DateTime access)
        {
            fi.CreationTime = create;
            fi.LastWriteTime = modify;
            fi.LastAccessTime = access;
            Console.WriteLine("文件" + fi.FullName + "时间修改成功！");
        }

        //修改单个文件夹的时间（指定+不遍历）（传入path）
        public void ChangeOneFolderTimeWithSettingNoTraversal(string path, DateTime create, DateTime modify, DateTime access)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            di.CreationTime = create;
            di.LastWriteTime = modify;
            di.LastAccessTime = access;
            Console.WriteLine("文件夹" + path + "时间修改成功！（指定时间+不遍历）");
        }

        //修改单个文件夹的时间（指定+不遍历）（传入DirectoryInfo）
        public void ChangeOneFolderTimeWithSettingNoTraversal(DirectoryInfo di, DateTime create, DateTime modify, DateTime access)
        {
            di.CreationTime = create;
            di.LastWriteTime = modify;
            di.LastAccessTime = access;
            Console.WriteLine("文件夹" + di.FullName + "时间修改成功！（指定时间+不遍历）");
        }

        //修改单个文件夹的时间（指定+遍历）（传入path）
        public void ChangeOneFolderTimeWithSettingWithTraversal(string path, DateTime create, DateTime modify, DateTime access)
        {
            //获取所有文件和文件夹的列表
            List<FileFolderInfoNode> all_filefolder = new List<FileFolderInfoNode>();
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
            //开始修改文件+文件夹的时间
            all_filefolder.Reverse();
            foreach (FileFolderInfoNode ffin in all_filefolder)
            {
                //文件类型
                if (ffin.type == OverAllData.FILETYPE_FILE)
                    ChangeOneFileTime(ffin.file_info, create, modify, access);
                //文件夹类型
                else if (ffin.type == OverAllData.FILETYPE_FOLDER)
                    ChangeOneFolderTimeWithSettingNoTraversal(ffin.folder_info, create, modify, access);
            }

            Console.WriteLine("文件夹" + path + "时间修改成功！（指定时间+遍历）");
        }

        //修改单个文件夹的时间（指定+遍历）（传入DirectoryInfo）
        public void ChangeOneFolderTimeWithSettingWithTraversal(DirectoryInfo directoryInfo, DateTime create, DateTime modify, DateTime access)
        {
            //获取所有文件和文件夹的列表
            List<FileFolderInfoNode> all_filefolder = new List<FileFolderInfoNode>();
            Queue<FileFolderInfoNode> temp_folder = new Queue<FileFolderInfoNode>();
            FileFolderInfoNode temp = new FileFolderInfoNode();
            temp.type = OverAllData.FILETYPE_FOLDER;
            temp.folder_info = directoryInfo;
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
            //开始修改文件+文件夹的时间
            all_filefolder.Reverse();
            foreach (FileFolderInfoNode ffin in all_filefolder)
            {
                //文件类型
                if (ffin.type == OverAllData.FILETYPE_FILE)
                    ChangeOneFileTime(ffin.file_info, create, modify, access);
                //文件夹类型
                else if (ffin.type == OverAllData.FILETYPE_FOLDER)
                    ChangeOneFolderTimeWithSettingNoTraversal(ffin.folder_info, create, modify, access);
            }

            Console.WriteLine("文件夹" + directoryInfo.FullName + "时间修改成功！（指定时间+遍历）");
        }

        //修改单个文件夹的时间（默认+遍历）（传入path）
        //规则：
        //1、对于单个文件：
        //    如果创建时间晚于修改时间，则修改创建时间=修改时间，访问时间=修改时间
        //2、对于文件夹：
        //    创建时间=最早创建时间（子文件+子文件夹），修改时间=最晚修改时间（子文件+子文件夹）
        //    如果为空，则时间不变
        //3、设置文件夹的访问时间=修改时间
        public void ChangeOneFolderTimeNoSettingWithTraversal(string path)
        {
            //获取所有文件夹的列表
            List<FileFolderInfoNode> all_folder = new List<FileFolderInfoNode>();
            Queue<FileFolderInfoNode> temp_folder = new Queue<FileFolderInfoNode>();
            FileFolderInfoNode temp = new FileFolderInfoNode();
            temp.type = OverAllData.FILETYPE_FOLDER;
            temp.folder_info = new DirectoryInfo(path);
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
                    all_folder.Add(fn_t);
                    temp_folder.Enqueue(fn_t);
                }
            }
            //开始修改文件+文件夹的时间
            all_folder.Reverse();
            foreach (FileFolderInfoNode ffi in all_folder)
            {
                //记录所有文件+文件夹的链表
                List<DateTime> all_time = new List<DateTime>();
                //获取文件夹节点
                DirectoryInfo di = ffi.folder_info;
                //对于其中的所有文件
                foreach (FileInfo fi_in in di.GetFiles())
                {
                    all_time.Add(fi_in.LastWriteTime);
                    DateTime file_create = fi_in.CreationTime;
                    DateTime file_modify = fi_in.LastWriteTime;
                    if (DateTime.Compare(file_create, file_modify) > 0)
                        fi_in.CreationTime = file_modify;
                    fi_in.LastAccessTime = file_modify;
                }
                //对于该文件夹，获取最早的创建时间，最晚的修改时间
                if (!(di.GetFiles().Length == 0 && di.GetDirectories().Length == 0))
                {
                    //获取最早的创建时间
                    foreach (DirectoryInfo di_in in di.GetDirectories())
                        all_time.Add(di_in.LastWriteTime);
                    DateTime most_early = utils.GetMostEarlyTimeFromList(all_time);
                    //获取最晚的修改时间
                    DateTime most_late = utils.GetMostLateTimeFromList(all_time);
                    //修改创建时间=最早时间
                    di.CreationTime = most_early;
                    //修改修改时间=最晚时间
                    di.LastWriteTime = most_late;
                    //修改访问时间=修改时间
                    di.LastAccessTime = di.LastWriteTime;
                }
            }
        }

        //修改单个文件夹的时间（默认+遍历）（传入DirectoryInfo）
        //规则：
        //1、对于单个文件：
        //    如果创建时间晚于修改时间，则修改创建时间=修改时间，访问时间=修改时间
        //2、对于文件夹：
        //    创建时间=最早创建时间（子文件+子文件夹），修改时间=最晚修改时间（子文件+子文件夹）
        //    如果为空，则时间不变
        //3、设置文件夹的访问时间=修改时间
        public void ChangeOneFolderTimeNoSettingWithTraversal(DirectoryInfo directoryInfo)
        {
            //获取所有文件夹的列表
            List<FileFolderInfoNode> all_folder = new List<FileFolderInfoNode>();
            Queue<FileFolderInfoNode> temp_folder = new Queue<FileFolderInfoNode>();
            FileFolderInfoNode temp = new FileFolderInfoNode();
            temp.type = OverAllData.FILETYPE_FOLDER;
            temp.folder_info = directoryInfo;
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
                    all_folder.Add(fn_t);
                    temp_folder.Enqueue(fn_t);
                }
            }
            //开始修改文件+文件夹的时间
            all_folder.Reverse();
            foreach (FileFolderInfoNode ffi in all_folder)
            {
                //记录所有文件+文件夹的链表
                List<DateTime> all_time = new List<DateTime>();
                //获取文件夹节点
                DirectoryInfo di = ffi.folder_info;
                //对于其中的所有文件
                foreach (FileInfo fi_in in di.GetFiles())
                {
                    all_time.Add(fi_in.LastWriteTime);
                    DateTime file_create = fi_in.CreationTime;
                    DateTime file_modify = fi_in.LastWriteTime;
                    if (DateTime.Compare(file_create, file_modify) > 0)
                        fi_in.CreationTime = file_modify;
                    fi_in.LastAccessTime = file_modify;
                }
                //对于该文件夹，获取最早的创建时间，最晚的修改时间
                if (!(di.GetFiles().Length == 0 && di.GetDirectories().Length == 0))
                {
                    //获取最早的创建时间
                    foreach (DirectoryInfo di_in in di.GetDirectories())
                        all_time.Add(di_in.LastWriteTime);
                    DateTime most_early = utils.GetMostEarlyTimeFromList(all_time);
                    //获取最晚的修改时间
                    DateTime most_late = utils.GetMostLateTimeFromList(all_time);
                    //修改创建时间=最早时间
                    di.CreationTime = most_early;
                    //修改修改时间=最晚时间
                    di.LastWriteTime = most_late;
                    //修改访问时间=修改时间
                    di.LastAccessTime = di.LastWriteTime;
                }
            }
        }

        //修改列表中的所有项目的时间（指定+文件夹不遍历）（传入path）
        public void ChangeListTimeWithSettingNoTraversal(List<string> all_path, DateTime create, DateTime modify, DateTime access)
        {
            foreach (string path in all_path)
            {
                int type = utils.CheckIfFileOrFolder(path);
                if (type == OverAllData.FILETYPE_FILE)
                    ChangeOneFileTime(path, create, modify, access);
                else if (type == OverAllData.FILETYPE_FOLDER)
                    ChangeOneFolderTimeWithSettingNoTraversal(path, create, modify, access);
            }
        }

        //修改列表中的所有项目的时间（指定+文件夹遍历）（传入FileFolderInfoNode）
        public void ChangeListTimeWithSettingNoTraversal(List<FileFolderInfoNode> all_node, DateTime create, DateTime modify, DateTime access)
        {
            foreach (FileFolderInfoNode node in all_node)
            {
                int type = node.type;
                if (type == OverAllData.FILETYPE_FILE)
                    ChangeOneFileTime(node.file_info, create, modify, access);
                else if (type == OverAllData.FILETYPE_FOLDER)
                    ChangeOneFolderTimeWithSettingNoTraversal(node.folder_info, create, modify, access);
            }
        }

        //修改列表中的所有项目的时间（默认+文件夹不遍历）（传入path）
        public void ChangeListTimeNoSettingNoTraversal(List<string> all_path)
        {
            Console.WriteLine("在默认方式+文件夹不遍历方式下，没什么可以做的！");
        }

        //修改列表中的所有项目的时间（默认+文件夹遍历）（传入FileFolderInfoNode）
        public void ChangeListTimeNoSettingNoTraversal(List<FileFolderInfoNode> all_node)
        {
            foreach (FileFolderInfoNode node in all_node)
            {
                int type = node.type;
                if (type == OverAllData.FILETYPE_FOLDER)
                    ChangeOneFolderTimeNoSettingWithTraversal(node.folder_info);
            }
        }

        //
    }
}
