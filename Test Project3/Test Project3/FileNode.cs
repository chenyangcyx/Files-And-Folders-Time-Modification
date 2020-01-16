using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project3
{
    class FileNode
    {
        public bool isFile { get; set; }

        public FileInfo fi { get; set; }

        public DirectoryInfo di { get; set; }
    }
}
