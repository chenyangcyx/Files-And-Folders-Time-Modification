using System.IO;

namespace Simple_CLI_Program
{
    class FileFolderInfoNode
    {
        //文件/文件夹的类型（file/folder）
        public int type { get; set; }

        //文件信息的对象引用
        public FileInfo file_info { get; set; }

        //文件夹信息的对象引用
        public DirectoryInfo folder_info { get; set; }

        public FileFolderInfoNode()
        {
            type = OverAllData.FILETYPE_FILE + OverAllData.FILETYPE_FOLDER;
            file_info = null;
            folder_info = null;
        }

        public FileFolderInfoNode(int type, FileInfo fi)
        {
            this.type = type;
            file_info = fi;
            folder_info = null;
        }

        public FileFolderInfoNode(int type, DirectoryInfo di)
        {
            this.type = type;
            folder_info = di;
            file_info = null;
        }
    }
}
