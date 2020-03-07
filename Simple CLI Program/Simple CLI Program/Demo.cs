using System;
using System.Collections.Generic;
using System.IO;

namespace Simple_CLI_Program
{
    class Demo
    {
        Utils utils = new Utils();
        FileAndFolderFunction faff = new FileAndFolderFunction();

        //示例1，修改单个文件的时间
        public void demo1()
        {
            //创建时间
            string str_create = "2020/01/01 00:00:00";
            if (!utils.CheckTimeString(str_create))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_create = utils.GetDateTimeFromString(str_create);
            //修改时间
            string str_modify = "2020/01/02 01:01:01";
            if (!utils.CheckTimeString(str_modify))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_modify = utils.GetDateTimeFromString(str_modify);
            //访问时间
            string str_access = "2020/02/01 02:02:02";
            if (!utils.CheckTimeString(str_access))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_access = utils.GetDateTimeFromString(str_access);
            //要修改的文件路径
            string path = "D:\\test_folder\\test_file1.txt";

            //调用函数-方式1
            faff.ChangeOneFileTime(path, dt_create, dt_modify, dt_access);
            //调用函数-方式2
            //FileInfo fi = new FileInfo(path);
            //faff.ChangeOneFileTime(fi, dt_create, dt_modify, dt_access);
        }

        //示例2，修改单个文件夹的时间（指定+不遍历）
        public void demo2()
        {
            //创建时间
            string str_create = "2020/01/01 00:00:00";
            if (!utils.CheckTimeString(str_create))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_create = utils.GetDateTimeFromString(str_create);
            //修改时间
            string str_modify = "2020/01/02 01:01:01";
            if (!utils.CheckTimeString(str_modify))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_modify = utils.GetDateTimeFromString(str_modify);
            //访问时间
            string str_access = "2020/02/01 02:02:02";
            if (!utils.CheckTimeString(str_access))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_access = utils.GetDateTimeFromString(str_access);
            //要修改的文件夹路径
            string path = "D:\\test_folder";

            //调用函数-方式1
            faff.ChangeOneFolderTimeWithSettingNoTraversal(path, dt_create, dt_modify, dt_access);
            //调用函数-方式2
            //DirectoryInfo di = new DirectoryInfo(path);
            //faff.ChangeOneFolderTimeWithSettingNoTraversal(di, dt_create, dt_modify, dt_access);
        }

        //示例3，修改单个文件夹的时间（指定+遍历）
        public void demo3()
        {
            //创建时间
            string str_create = "2020/01/01 00:00:00";
            if (!utils.CheckTimeString(str_create))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_create = utils.GetDateTimeFromString(str_create);
            //修改时间
            string str_modify = "2020/01/02 01:01:01";
            if (!utils.CheckTimeString(str_modify))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_modify = utils.GetDateTimeFromString(str_modify);
            //访问时间
            string str_access = "2020/02/01 02:02:02";
            if (!utils.CheckTimeString(str_access))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_access = utils.GetDateTimeFromString(str_access);
            //要修改的文件夹路径
            string path = "D:\\test_folder";

            //调用函数-方式1
            faff.ChangeOneFolderTimeWithSettingWithTraversal(path, dt_create, dt_modify, dt_access);
            //调用函数-方式2
            //DirectoryInfo di = new DirectoryInfo(path);
            //faff.ChangeOneFolderTimeWithSettingWithTraversal(di, dt_create, dt_modify, dt_access);
        }

        //示例4，修改单个文件夹的时间（默认+遍历）
        public void demo4()
        {
            //要修改的文件路径
            string path = "D:\\test_folder";

            //调用函数-方式1
            faff.ChangeOneFolderTimeNoSettingWithTraversal(path);
            //调用函数-方式2
            //DirectoryInfo di = new DirectoryInfo(path);
            //faff.ChangeOneFolderTimeNoSettingWithTraversal(di);
        }

        //示例5，修改列表中的所有项目的时间（指定+文件夹不遍历）
        public void demo5()
        {
            //构造列表
            List<string> all_path = new List<string>();
            string file_path1 = "D:\\test_folder\\test_file1.txt";
            string file_path2 = "D:\\test_folder\\test_file2.txt";
            string file_path3 = "D:\\test_folder\\test_file3.txt";
            string file_path4 = "D:\\test_folder\\test_file4.txt";
            string file_path5 = "D:\\test_folder\\test_file5.txt";
            string folder_path1 = "D:\\test_folder\\child_folder1";
            string folder_path2 = "D:\\test_folder\\child_folder2";
            string folder_path3 = "D:\\test_folder\\child_folder3";
            string folder_path4 = "D:\\test_folder\\child_folder4";
            string folder_path5 = "D:\\test_folder\\child_folder5";
            all_path.Add(file_path1);
            all_path.Add(file_path2);
            all_path.Add(file_path3);
            all_path.Add(file_path4);
            all_path.Add(file_path5);
            all_path.Add(folder_path1);
            all_path.Add(folder_path2);
            all_path.Add(folder_path3);
            all_path.Add(folder_path4);
            all_path.Add(folder_path5);
            //创建时间
            string str_create = "2020/01/01 00:00:00";
            if (!utils.CheckTimeString(str_create))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_create = utils.GetDateTimeFromString(str_create);
            //修改时间
            string str_modify = "2020/01/02 01:01:01";
            if (!utils.CheckTimeString(str_modify))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_modify = utils.GetDateTimeFromString(str_modify);
            //访问时间
            string str_access = "2020/02/01 02:02:02";
            if (!utils.CheckTimeString(str_access))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_access = utils.GetDateTimeFromString(str_access);
            //调用函数-方式1
            faff.ChangeListTimeWithSettingNoTraversal(all_path, dt_create, dt_modify, dt_access);
            //调用函数-方式2
            //List<FileFolderInfoNode> all_node = new List<FileFolderInfoNode>();
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path5)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path5)));
            //faff.ChangeListTimeWithSettingNoTraversal(all_node, dt_create, dt_modify, dt_access);
        }

        //示例6，修改列表中的所有项目的时间（指定+文件夹遍历）
        public void demo6()
        {
            //构造列表
            List<string> all_path = new List<string>();
            string file_path1 = "D:\\test_folder\\test_file1.txt";
            string file_path2 = "D:\\test_folder\\test_file2.txt";
            string file_path3 = "D:\\test_folder\\test_file3.txt";
            string file_path4 = "D:\\test_folder\\test_file4.txt";
            string file_path5 = "D:\\test_folder\\test_file5.txt";
            string folder_path1 = "D:\\test_folder\\child_folder1";
            string folder_path2 = "D:\\test_folder\\child_folder2";
            string folder_path3 = "D:\\test_folder\\child_folder3";
            string folder_path4 = "D:\\test_folder\\child_folder4";
            string folder_path5 = "D:\\test_folder\\child_folder5";
            all_path.Add(file_path1);
            all_path.Add(file_path2);
            all_path.Add(file_path3);
            all_path.Add(file_path4);
            all_path.Add(file_path5);
            all_path.Add(folder_path1);
            all_path.Add(folder_path2);
            all_path.Add(folder_path3);
            all_path.Add(folder_path4);
            all_path.Add(folder_path5);
            //创建时间
            string str_create = "2020/01/01 00:00:00";
            if (!utils.CheckTimeString(str_create))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_create = utils.GetDateTimeFromString(str_create);
            //修改时间
            string str_modify = "2020/01/02 01:01:01";
            if (!utils.CheckTimeString(str_modify))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_modify = utils.GetDateTimeFromString(str_modify);
            //访问时间
            string str_access = "2020/02/01 02:02:02";
            if (!utils.CheckTimeString(str_access))
            {
                Console.WriteLine("时间格式错误！");
                return;
            }
            DateTime dt_access = utils.GetDateTimeFromString(str_access);
            //调用函数-方式1
            faff.ChangeListTimeWithSettingWithTraversal(all_path, dt_create, dt_modify, dt_access);
            //调用函数-方式2
            //List<FileFolderInfoNode> all_node = new List<FileFolderInfoNode>();
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path5)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path5)));
            //faff.ChangeListTimeWithSettingWithTraversal(all_node, dt_create, dt_modify, dt_access);
        }

        //示例7，修改列表中的所有项目的时间（默认+文件夹不遍历）
        public void demo7()
        {
            //构造列表
            List<string> all_path = new List<string>();
            string file_path1 = "D:\\test_folder\\test_file1.txt";
            string file_path2 = "D:\\test_folder\\test_file2.txt";
            string file_path3 = "D:\\test_folder\\test_file3.txt";
            string file_path4 = "D:\\test_folder\\test_file4.txt";
            string file_path5 = "D:\\test_folder\\test_file5.txt";
            string folder_path1 = "D:\\test_folder\\child_folder1";
            string folder_path2 = "D:\\test_folder\\child_folder2";
            string folder_path3 = "D:\\test_folder\\child_folder3";
            string folder_path4 = "D:\\test_folder\\child_folder4";
            string folder_path5 = "D:\\test_folder\\child_folder5";
            all_path.Add(file_path1);
            all_path.Add(file_path2);
            all_path.Add(file_path3);
            all_path.Add(file_path4);
            all_path.Add(file_path5);
            all_path.Add(folder_path1);
            all_path.Add(folder_path2);
            all_path.Add(folder_path3);
            all_path.Add(folder_path4);
            all_path.Add(folder_path5);
            //调用函数-方式1
            faff.ChangeListTimeNoSettingNoTraversal(all_path);
            //调用函数-方式2
            //List<FileFolderInfoNode> all_node = new List<FileFolderInfoNode>();
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path5)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path5)));
            //faff.ChangeListTimeNoSettingNoTraversal(all_node);
        }

        //示例8，修改列表中的所有项目的时间（默认+文件夹遍历）
        public void demo8()
        {
            //构造列表
            List<string> all_path = new List<string>();
            string file_path1 = "D:\\test_folder\\test_file1.txt";
            string file_path2 = "D:\\test_folder\\test_file2.txt";
            string file_path3 = "D:\\test_folder\\test_file3.txt";
            string file_path4 = "D:\\test_folder\\test_file4.txt";
            string file_path5 = "D:\\test_folder\\test_file5.txt";
            string folder_path1 = "D:\\test_folder\\child_folder1";
            string folder_path2 = "D:\\test_folder\\child_folder2";
            string folder_path3 = "D:\\test_folder\\child_folder3";
            string folder_path4 = "D:\\test_folder\\child_folder4";
            string folder_path5 = "D:\\test_folder\\child_folder5";
            all_path.Add(file_path1);
            all_path.Add(file_path2);
            all_path.Add(file_path3);
            all_path.Add(file_path4);
            all_path.Add(file_path5);
            all_path.Add(folder_path1);
            all_path.Add(folder_path2);
            all_path.Add(folder_path3);
            all_path.Add(folder_path4);
            all_path.Add(folder_path5);
            //调用函数-方式1
            faff.ChangeListTimeNoSettingWithTraversal(all_path);
            //调用函数-方式2
            //List<FileFolderInfoNode> all_node = new List<FileFolderInfoNode>();
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FILE, new FileInfo(file_path5)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path1)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path2)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path3)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path4)));
            //all_node.Add(new FileFolderInfoNode(OverAllData.FILETYPE_FOLDER, new DirectoryInfo(folder_path5)));
            //faff.ChangeListTimeNoSettingWithTraversal(all_node);
        }

        //示例9，特殊示例
        public void demo9()
        {
            Console.WriteLine("目前demo：demo9 Special Need\n");
            SpecialNeed sn = new SpecialNeed();
            //要修改的文件路径
            Console.WriteLine("请输入 要修改的文件路径：");
            string path = Console.ReadLine();
            //时间参考基准
            Console.WriteLine("请输入 参考基准时间：");
            string reference_time = Console.ReadLine();
            Console.WriteLine("请输入 筛选创建时间不早于的时间：");
            string not_early_than_this_time = Console.ReadLine();

            //调用函数-方式1
            sn.ChangeFolderTimeWithSpecialNeed(path, reference_time, not_early_than_this_time);
            //调用函数-方式2
            //DirectoryInfo di = new DirectoryInfo(path);
            //sn.ChangeFolderTimeWithSpecialNeed(di, reference_time, not_early_than_this_time);

            Console.ReadLine();
        }
    }
}
