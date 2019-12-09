using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project1
{
    class GetFileInfo
    {
        public void GetInfo(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            DirectoryInfo[] folders = root.GetDirectories();
            foreach(FileInfo fi in files)
            {
                System.Console.WriteLine(fi.Name);
                System.Console.WriteLine(fi.FullName);
                System.Console.WriteLine(fi.Extension);
                System.Console.WriteLine(fi.Length);
                System.Console.WriteLine(fi.Directory);
            }
            System.Console.WriteLine("\n\n文件夹\n\n");
            foreach (DirectoryInfo di in folders)
            {
                System.Console.WriteLine(di.Name);
                System.Console.WriteLine(di.FullName);
                System.Console.WriteLine(di.Parent.FullName);
            }
        }

        public string GetParentPath(string path,string parent_path_name)
        {
            return path.Substring(0, path.LastIndexOf(parent_path_name) + parent_path_name.Length);
        }

        public void TestGetFileTime(string path)
        {
            FileInfo fi = new FileInfo(path);
            System.Console.WriteLine(fi.CreationTime);
            System.Console.WriteLine(fi.CreationTimeUtc);
            System.Console.WriteLine(fi.LastAccessTime);
            System.Console.WriteLine(fi.LastAccessTimeUtc);
            System.Console.WriteLine(fi.LastWriteTime);
            System.Console.WriteLine(fi.LastWriteTimeUtc);
        }
    }
}
