using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFileInfo gfi = new GetFileInfo();
            gfi.GetInfo("D:\\Code\\Files-And-Folders-Time-Modification");
            //DirectoryInfo fi = new DirectoryInfo("D:\\Code\\Files-And-Folders-Time-Modification");
            //gfi.GetParentPath(fi.FullName, fi.Parent);
        }
    }
}
