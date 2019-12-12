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

        //设置某文件的时间
        public void SetFileTime(string path,DateTime dt_create,DateTime dt_modify,DateTime dt_access)
        {
            FileInfo fi = new FileInfo(path);
            fi.CreationTime = dt_create;
            fi.LastWriteTime = dt_modify;
            fi.LastAccessTime = dt_access;
        }

        //创建文件夹的树结构
        public void CreateFolderTree(string path)
        {

        }
    }
}
