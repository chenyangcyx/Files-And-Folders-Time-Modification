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
        List<FileNode> all_filefolder = new List<FileNode>();
        List<FileNode> all_folder = new List<FileNode>();
        Queue<FileNode> temp_folder = new Queue<FileNode>();
        //处理一个文件夹中的所有子文件和子文件夹
        public void HandleAllFileAndFolderInFolder(string path)
        {
            
            FileNode temp = new FileNode();
            temp.isFile = false;
            temp.di = new DirectoryInfo(path);
            all_filefolder.Add(temp);
            all_folder.Add(temp);
            temp_folder.Enqueue(temp);
            int file_folder_num = 1;
            int folder_num = 1;
            int file_num = 0;
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
            OutputListContent(all_filefolder);
            Console.WriteLine("文件+文件夹：" + file_folder_num + Environment.NewLine);
            Console.WriteLine("文件：" + file_num + Environment.NewLine);
            Console.WriteLine("文件夹：" + folder_num + Environment.NewLine);
        }

        //输出list中的所有元素
        public void OutputListContent(List<FileNode> all)
        {
            foreach(FileNode fn in all)
            {
                if (fn.isFile)
                    Console.WriteLine("文件：" + fn.fi.FullName + Environment.NewLine);
                else
                    Console.WriteLine("文件夹：" + fn.di.FullName + Environment.NewLine);
            }
        }
    }
}
