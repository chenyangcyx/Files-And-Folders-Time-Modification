using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Folders_Time_Modification.Code
{
    class FileFolderInfoNode
    {
        public string type;        //文件/文件夹的类型（file/folder）
        public FileInfo file_info;      //文件信息的对象引用
        public DirectoryInfo folder_info;       //文件夹信息的对象引用
        public FileFolderInfoNode father_node;      //父节点对象引用
        public List<FileFolderInfoNode> children_node;     //子节点的列表
    }
}
