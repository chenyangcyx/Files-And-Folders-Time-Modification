using System;
using System.Collections.Generic;
using System.IO;

namespace Simple_CLI_Program
{
    class SpecialNeed
    {
        OverAllData all = OverAllData.alldata;
        Utils utils = new Utils();

        //修改文件夹中的所有子文件和文件夹的时间
        //规则：
        //1、对于单个文件：
        //  创建时间：若早于'参考基准时间'，则不修改；否则修改为earlier(原有创建时间，修改时间)
        //  访问时间：earlier(原有访问时间，later(创建时间，修改时间))
        //2、对于文件夹：
        //  创建时间：若早于'参考基准时间'，则不修改；否则将[earlier(所有文件创建时间、修改时间 + 所有文件夹创建时间、修改时间)] 与其自身原有的创建时间比较，取较早的那个
        //  修改时间：若早于'参考基准时间'，则不修改；否则将[later(所有文件修改时间 + 所有文件夹修改时间)] 与其自身原有的创建时间比较，取较早的那个
        //  访问时间：若早于'参考基准时间'，则不修改；否则修改为：later(创建时间，修改时间)
        public void ChangeFolderTimeWithSpecialNeed(string path)
        {
            //转换基准时间
            if (!utils.CheckTimeString(OverAllData.alldata.reference_time))
            {
                Console.WriteLine("基准时间格式设置错误！");
                return;
            }
            DateTime reference_time = utils.GetDateTimeFromString(all.reference_time);
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
                //获取文件夹节点
                DirectoryInfo di = ffi.folder_info;
                //对于其中的所有文件
                foreach (FileInfo fi_in in di.GetFiles())
                {
                    List<DateTime> list_temp1 = new List<DateTime>();
                    //设置创建时间
                    if (DateTime.Compare(fi_in.CreationTime, reference_time) > 0)
                    {
                        list_temp1.Add(fi_in.CreationTime);
                        list_temp1.Add(fi_in.LastWriteTime);
                        fi_in.CreationTime = utils.GetMostEarlyTimeFromList(list_temp1);
                    }
                    //设置访问时间
                    list_temp1.Clear();
                    list_temp1.Add(fi_in.CreationTime);
                    list_temp1.Add(fi_in.LastWriteTime);
                    DateTime dt1 = utils.GetMostLateTimeFromList(list_temp1);
                    list_temp1.Clear();
                    list_temp1.Add(fi_in.LastAccessTime);
                    list_temp1.Add(dt1);
                    fi_in.LastAccessTime = utils.GetMostEarlyTimeFromList(list_temp1);
                }
                //设置该文件夹的信息
                if (!(di.GetFiles().Length == 0 && di.GetDirectories().Length == 0))
                {
                    //设置创建时间
                    if (DateTime.Compare(di.CreationTime, reference_time) > 0)
                    {
                        //收集：所有文件创建时间、修改时间 + 所有文件夹创建时间、修改时间
                        List<DateTime> list_temp2 = new List<DateTime>();
                        foreach (FileInfo fi_in in di.GetFiles())
                        {
                            list_temp2.Add(fi_in.CreationTime);
                            list_temp2.Add(fi_in.LastWriteTime);
                        }
                        foreach (DirectoryInfo di_in in di.GetDirectories())
                        {
                            list_temp2.Add(di_in.CreationTime);
                            list_temp2.Add(di_in.LastWriteTime);
                        }
                        DateTime dt2 = utils.GetMostEarlyTimeFromList(list_temp2);
                        list_temp2.Clear();
                        list_temp2.Add(di.CreationTime);
                        list_temp2.Add(dt2);
                        di.CreationTime = utils.GetMostEarlyTimeFromList(list_temp2);
                    }
                    //设置修改时间
                    if (DateTime.Compare(di.LastWriteTime, reference_time) > 0)
                    {
                        //收集：所有文件修改时间 + 所有文件夹修改时间
                        List<DateTime> list_temp3 = new List<DateTime>();
                        foreach (FileInfo fi_in in di.GetFiles())
                            list_temp3.Add(fi_in.LastWriteTime);
                        foreach (DirectoryInfo di_in in di.GetDirectories())
                            list_temp3.Add(di_in.LastWriteTime);
                        DateTime dt3 = utils.GetMostLateTimeFromList(list_temp3);
                        list_temp3.Clear();
                        list_temp3.Add(di.LastWriteTime);
                        list_temp3.Add(dt3);
                        di.LastWriteTime = utils.GetMostEarlyTimeFromList(list_temp3);
                    }
                    //设置访问时间
                    if (DateTime.Compare(di.LastAccessTime, reference_time) > 0)
                    {
                        List<DateTime> list_temp4 = new List<DateTime>();
                        list_temp4.Add(di.CreationTime);
                        list_temp4.Add(di.LastWriteTime);
                        di.LastAccessTime = utils.GetMostLateTimeFromList(list_temp4);
                    }
                }
            }
            Console.WriteLine("文件夹：" + path + "设置成功！");
        }

        public void ChangeFolderTimeWithSpecialNeed(DirectoryInfo directoryInfo)
        {
            //转换基准时间
            if (!utils.CheckTimeString(OverAllData.alldata.reference_time))
            {
                Console.WriteLine("基准时间格式设置错误！");
                return;
            }
            DateTime reference_time = utils.GetDateTimeFromString(all.reference_time);
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
                //获取文件夹节点
                DirectoryInfo di = ffi.folder_info;
                //对于其中的所有文件
                foreach (FileInfo fi_in in di.GetFiles())
                {
                    List<DateTime> list_temp1 = new List<DateTime>();
                    //设置创建时间
                    if (DateTime.Compare(fi_in.CreationTime, reference_time) > 0)
                    {
                        list_temp1.Add(fi_in.CreationTime);
                        list_temp1.Add(fi_in.LastWriteTime);
                        fi_in.CreationTime = utils.GetMostEarlyTimeFromList(list_temp1);
                    }
                    //设置访问时间
                    list_temp1.Clear();
                    list_temp1.Add(fi_in.CreationTime);
                    list_temp1.Add(fi_in.LastWriteTime);
                    DateTime dt1 = utils.GetMostLateTimeFromList(list_temp1);
                    list_temp1.Clear();
                    list_temp1.Add(fi_in.LastAccessTime);
                    list_temp1.Add(dt1);
                    fi_in.LastAccessTime = utils.GetMostEarlyTimeFromList(list_temp1);
                }
                //设置该文件夹的信息
                if (!(di.GetFiles().Length == 0 && di.GetDirectories().Length == 0))
                {
                    //设置创建时间
                    if (DateTime.Compare(di.CreationTime, reference_time) > 0)
                    {
                        //收集：所有文件创建时间、修改时间 + 所有文件夹创建时间、修改时间
                        List<DateTime> list_temp2 = new List<DateTime>();
                        foreach (FileInfo fi_in in di.GetFiles())
                        {
                            list_temp2.Add(fi_in.CreationTime);
                            list_temp2.Add(fi_in.LastWriteTime);
                        }
                        foreach (DirectoryInfo di_in in di.GetDirectories())
                        {
                            list_temp2.Add(di_in.CreationTime);
                            list_temp2.Add(di_in.LastWriteTime);
                        }
                        DateTime dt2 = utils.GetMostEarlyTimeFromList(list_temp2);
                        list_temp2.Clear();
                        list_temp2.Add(di.CreationTime);
                        list_temp2.Add(dt2);
                        di.CreationTime = utils.GetMostEarlyTimeFromList(list_temp2);
                    }
                    //设置修改时间
                    if (DateTime.Compare(di.LastWriteTime, reference_time) > 0)
                    {
                        //收集：所有文件修改时间 + 所有文件夹修改时间
                        List<DateTime> list_temp3 = new List<DateTime>();
                        foreach (FileInfo fi_in in di.GetFiles())
                            list_temp3.Add(fi_in.LastWriteTime);
                        foreach (DirectoryInfo di_in in di.GetDirectories())
                            list_temp3.Add(di_in.LastWriteTime);
                        DateTime dt3 = utils.GetMostLateTimeFromList(list_temp3);
                        list_temp3.Clear();
                        list_temp3.Add(di.LastWriteTime);
                        list_temp3.Add(dt3);
                        di.LastWriteTime = utils.GetMostEarlyTimeFromList(list_temp3);
                    }
                    //设置访问时间
                    if (DateTime.Compare(di.LastAccessTime, reference_time) > 0)
                    {
                        List<DateTime> list_temp4 = new List<DateTime>();
                        list_temp4.Add(di.CreationTime);
                        list_temp4.Add(di.LastWriteTime);
                        di.LastAccessTime = utils.GetMostLateTimeFromList(list_temp4);
                    }
                }
            }
            Console.WriteLine("文件夹：" + directoryInfo.FullName + "设置成功！");
        }
    }
}
