using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project3
{
    class test1
    {
        //处理一个文件夹中的所有子文件和子文件夹
        public void HandleAllFileAndFolderInFolder(string path,List<FileNode> all_filefolder, List<FileNode> all_folder,out int file_folder_num,out int folder_num,out int file_num)
        {
            Queue<FileNode> temp_folder = new Queue<FileNode>();
            FileNode temp = new FileNode();
            temp.isFile = false;
            temp.di = new DirectoryInfo(path);
            all_filefolder.Add(temp);
            all_folder.Add(temp);
            temp_folder.Enqueue(temp);
            file_folder_num = 1;
            folder_num = 1;
            file_num = 0;
            while (temp_folder.Count!=0)
            {
                FileNode fn = temp_folder.Dequeue();
                foreach(DirectoryInfo di in fn.di.GetDirectories())
                {
                    FileNode fn_t = new FileNode();
                    fn_t.isFile = false;
                    fn_t.di = new DirectoryInfo(di.FullName);
                    all_filefolder.Add(fn_t);
                    all_folder.Add(fn_t);
                    temp_folder.Enqueue(fn_t);
                    file_folder_num++;
                    folder_num++;
                }
                foreach(FileInfo fi in fn.di.GetFiles())
                {
                    FileNode fn_t = new FileNode();
                    fn_t.isFile = true;
                    fn_t.fi = new FileInfo(fi.FullName);
                    all_filefolder.Add(fn_t);
                    file_folder_num++;
                    file_num++;
                }
            }
        }

        //处理一个文件夹中的所有子文件和子文件夹
        public void HandleAllFileAndFolderInFolder2(string path, out int folder_num, out int file_num, out int file_folder_num)
        {
            List<FileNode> all_filefolder = new List<FileNode>();
            List<FileNode> all_folder = new List<FileNode>();
            Queue<FileNode> temp_folder = new Queue<FileNode>();
            FileNode temp = new FileNode();
            temp.isFile = false;
            temp.di = new DirectoryInfo(path);
            all_filefolder.Add(temp);
            all_folder.Add(temp);
            temp_folder.Enqueue(temp);
            folder_num = 1;
            file_num = 0;
            while (temp_folder.Count != 0)
            {
                FileNode fn = temp_folder.Dequeue();
                foreach (DirectoryInfo di in fn.di.GetDirectories())
                {
                    FileNode fn_t = new FileNode();
                    fn_t.isFile = false;
                    fn_t.di = new DirectoryInfo(di.FullName);
                    all_filefolder.Add(fn_t);
                    all_folder.Add(fn_t);
                    temp_folder.Enqueue(fn_t);
                    folder_num++;
                }
                file_num += fn.di.GetFiles().Length;
            }
            file_folder_num = file_num + folder_num;
        }
    }
}
