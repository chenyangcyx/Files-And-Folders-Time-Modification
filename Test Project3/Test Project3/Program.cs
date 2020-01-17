using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project3
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试1-1
            test1 t1 = new test1();
            List<FileNode> all_filefolder = new List<FileNode>();
            List<FileNode> all_folder = new List<FileNode>();
            int file_folder_num, folder_num, file_num;
            t1.HandleAllFileAndFolderInFolder("D:\\图片视频\\图片视频", all_filefolder, all_folder, out file_folder_num, out folder_num, out file_num);
            Console.WriteLine("文件+文件夹：" + file_folder_num + Environment.NewLine);
            Console.WriteLine("文件：" + file_num + Environment.NewLine);
            Console.WriteLine("文件夹：" + folder_num + Environment.NewLine);
            //foreach (FileNode fn in all_filefolder)
            //{
            //    if (fn.isFile)
            //        Console.WriteLine("文件：" + fn.fi.FullName + Environment.NewLine);
            //    else
            //        Console.WriteLine("文件夹：" + fn.di.FullName + Environment.NewLine);
            //}

            //测试1-2
            test1 t2 = new test1();
            int filefoldernum2, filenum2, foldernum2;
            t2.HandleAllFileAndFolderInFolder2("D:\\图片视频\\图片视频", out foldernum2, out filenum2, out filefoldernum2);
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "方法2：" + Environment.NewLine);
            Console.WriteLine("文件+文件夹：" + filefoldernum2 + Environment.NewLine);
            Console.WriteLine("文件：" + filenum2 + Environment.NewLine);
            Console.WriteLine("文件夹：" + foldernum2 + Environment.NewLine);
        }
    }
}
