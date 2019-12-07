using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Folders_Time_Modification.Code
{
    class FileFolderInfoNode
    {
        public string path;        //文件/文件夹的路径
        public string type;        //文件/文件夹的类型（file/folder）
        public DateTime create_time;       //创建时间
        public DateTime modificate_time;   //修改时间
        public DateTime access_time;       //访问时间
        public FileFolderInfoNode father_node; //父节点对象引用
        public List<FileFolderInfoNode> children_node;     //子节点的列表
    }
}
