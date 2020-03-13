using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CLI_Program
{
    class Menu
    {
        //显示菜单
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("**********文件时间修改程序 CLI版本**********");
            Console.WriteLine("\n  1. 修改单个文件的时间\t\t\t（修改方式：指定）");
            Console.WriteLine("\n  2. 修改单个文件夹的时间\t\t（修改方式：指定，遍历方式：不遍历）");
            Console.WriteLine("\n  3. 修改单个文件夹的时间\t\t（修改方式：指定，遍历方式：遍历）");
            Console.WriteLine("\n  4. 修改单个文件夹的时间\t\t（修改方式：默认，遍历方式：遍历）");
            Console.WriteLine("\n  5. 修改列表中的所有项目的时间\t\t（修改方式：指定，文件夹不遍历）");
            Console.WriteLine("\n  6. 修改列表中的所有项目的时间\t\t（修改方式：指定，文件夹遍历）");
            Console.WriteLine("\n  7. 修改列表中的所有项目的时间\t\t（修改方式：默认，文件夹不遍历）");
            Console.WriteLine("\n  8. 修改列表中的所有项目的时间\t\t（修改方式：默认，文件夹遍历）");
            Console.WriteLine("\n  9. 特殊时间（针对个人文件）修改");
            GetOperationNum();
        }

        public void GetOperationNum()
        {
            int command = -1;
            Console.Write("\n\n  请输入要执行的操作：");
            string input_string = Console.ReadLine();
            try
            {
                command = int.Parse(input_string);
            }
            catch (Exception e)
            {
                InputErrorHandle();
            }
            if (command < 1 || command > 9)
            {
                InputErrorHandle();
            }

            //针对相应的数字进行处理
            HandleNum(command);
        }

        //输入错误处理
        public void InputErrorHandle()
        {
            Console.WriteLine("输入格式错误！点击回车继续！");
            Console.ReadLine();
            ShowMenu();
        }

        //针对数字进行处理
        public void HandleNum(int command)
        {
            Utils utils = new Utils();
            FileAndFolderFunction faff = new FileAndFolderFunction();
            SpecialNeed sn = new SpecialNeed();

            string str_create,str_modify,str_access,path;
            DateTime dt_create, dt_modify, dt_access;
            List<string> all_path = new List<string>();
            string input_temp;
            switch (command)
            {
                case 1:
                    Console.WriteLine("\n\n目前模式：1  修改单个文件的时间\n");
                    //创建时间
                    Console.WriteLine("请输入创建时间：");
                    str_create = Console.ReadLine();
                    while (!utils.CheckTimeString(str_create))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_create = Console.ReadLine();
                    }
                    dt_create = utils.GetDateTimeFromString(str_create);
                    //修改时间
                    Console.WriteLine("请输入修改时间：");
                    str_modify = Console.ReadLine();
                    while (!utils.CheckTimeString(str_modify))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_modify = Console.ReadLine();
                    }
                    dt_modify = utils.GetDateTimeFromString(str_modify);
                    //访问时间
                    Console.WriteLine("请输入访问时间：");
                    str_access = Console.ReadLine();
                    while (!utils.CheckTimeString(str_access))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_access = Console.ReadLine();
                    }
                    dt_access = utils.GetDateTimeFromString(str_access);
                    //要修改的文件路径
                    Console.WriteLine("请输入要修改的文件/文件夹路径：");
                    path = Console.ReadLine();
                    faff.ChangeOneFileTime(path, dt_create, dt_modify, dt_access);
                    break;
                case 2:
                    Console.WriteLine("\n\n目前模式：2  修改单个文件夹的时间（修改方式：指定，遍历方式：不遍历）\n");
                    //创建时间
                    Console.WriteLine("请输入创建时间：");
                    str_create = Console.ReadLine();
                    while (!utils.CheckTimeString(str_create))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_create = Console.ReadLine();
                    }
                    dt_create = utils.GetDateTimeFromString(str_create);
                    //修改时间
                    Console.WriteLine("请输入修改时间：");
                    str_modify = Console.ReadLine();
                    while (!utils.CheckTimeString(str_modify))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_modify = Console.ReadLine();
                    }
                    dt_modify = utils.GetDateTimeFromString(str_modify);
                    //访问时间
                    Console.WriteLine("请输入访问时间：");
                    str_access = Console.ReadLine();
                    while (!utils.CheckTimeString(str_access))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_access = Console.ReadLine();
                    }
                    dt_access = utils.GetDateTimeFromString(str_access);
                    //要修改的文件路径
                    Console.WriteLine("请输入要修改的文件/文件夹路径：");
                    path = Console.ReadLine();
                    faff.ChangeOneFolderTimeWithSettingNoTraversal(path, dt_create, dt_modify, dt_access);
                    break;
                case 3:
                    Console.WriteLine("\n\n目前模式：3  修改单个文件夹的时间（修改方式：指定，遍历方式：遍历）\n");
                    //创建时间
                    Console.WriteLine("请输入创建时间：");
                    str_create = Console.ReadLine();
                    while (!utils.CheckTimeString(str_create))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_create = Console.ReadLine();
                    }
                    dt_create = utils.GetDateTimeFromString(str_create);
                    //修改时间
                    Console.WriteLine("请输入修改时间：");
                    str_modify = Console.ReadLine();
                    while (!utils.CheckTimeString(str_modify))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_modify = Console.ReadLine();
                    }
                    dt_modify = utils.GetDateTimeFromString(str_modify);
                    //访问时间
                    Console.WriteLine("请输入访问时间：");
                    str_access = Console.ReadLine();
                    while (!utils.CheckTimeString(str_access))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_access = Console.ReadLine();
                    }
                    dt_access = utils.GetDateTimeFromString(str_access);
                    //要修改的文件路径
                    Console.WriteLine("请输入要修改的文件/文件夹路径：");
                    path = Console.ReadLine();
                    faff.ChangeOneFolderTimeWithSettingWithTraversal(path, dt_create, dt_modify, dt_access);
                    break;
                case 4:
                    Console.WriteLine("\n\n目前模式：4  修改单个文件夹的时间（修改方式：默认，遍历方式：遍历）\n");
                    //要修改的文件路径
                    Console.WriteLine("请输入要修改的文件/文件夹路径：");
                    path = Console.ReadLine();
                    faff.ChangeOneFolderTimeNoSettingWithTraversal(path);
                    break;
                case 5:
                    Console.WriteLine("\n\n目前模式：5  修改列表中的所有项目的时间（修改方式：指定，文件夹不遍历）\n");
                    //创建时间
                    Console.WriteLine("请输入创建时间：");
                    str_create = Console.ReadLine();
                    while (!utils.CheckTimeString(str_create))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_create = Console.ReadLine();
                    }
                    dt_create = utils.GetDateTimeFromString(str_create);
                    //修改时间
                    Console.WriteLine("请输入修改时间：");
                    str_modify = Console.ReadLine();
                    while (!utils.CheckTimeString(str_modify))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_modify = Console.ReadLine();
                    }
                    dt_modify = utils.GetDateTimeFromString(str_modify);
                    //访问时间
                    Console.WriteLine("请输入访问时间：");
                    str_access = Console.ReadLine();
                    while (!utils.CheckTimeString(str_access))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_access = Console.ReadLine();
                    }
                    dt_access = utils.GetDateTimeFromString(str_access);
                    //文件列表
                    all_path.Clear();
                    Console.WriteLine("请输入要修改的文件/文件夹路径，以“****”结束：");
                    while (!(input_temp = Console.ReadLine()).Contains("*****"))
                        all_path.Add(input_temp);
                    faff.ChangeListTimeWithSettingNoTraversal(all_path, dt_create, dt_modify, dt_access);
                    break;
                case 6:
                    Console.WriteLine("\n\n目前模式：6  修改列表中的所有项目的时间（修改方式：指定，文件夹遍历）\n");
                    //创建时间
                    Console.WriteLine("请输入创建时间：");
                    str_create = Console.ReadLine();
                    while (!utils.CheckTimeString(str_create))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_create = Console.ReadLine();
                    }
                    dt_create = utils.GetDateTimeFromString(str_create);
                    //修改时间
                    Console.WriteLine("请输入修改时间：");
                    str_modify = Console.ReadLine();
                    while (!utils.CheckTimeString(str_modify))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_modify = Console.ReadLine();
                    }
                    dt_modify = utils.GetDateTimeFromString(str_modify);
                    //访问时间
                    Console.WriteLine("请输入访问时间：");
                    str_access = Console.ReadLine();
                    while (!utils.CheckTimeString(str_access))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        str_access = Console.ReadLine();
                    }
                    dt_access = utils.GetDateTimeFromString(str_access);
                    //文件列表
                    all_path.Clear();
                    Console.WriteLine("请输入要修改的文件/文件夹路径，以“****”结束：");
                    while (!(input_temp = Console.ReadLine()).Contains("*****"))
                        all_path.Add(input_temp);
                    faff.ChangeListTimeWithSettingWithTraversal(all_path, dt_create, dt_modify, dt_access);
                    break;
                case 7:
                    Console.WriteLine("\n\n目前模式：7  修改列表中的所有项目的时间（修改方式：默认，文件夹不遍历）\n");
                    //文件列表
                    all_path.Clear();
                    Console.WriteLine("请输入要修改的文件/文件夹路径，以“****”结束：");
                    while (!(input_temp = Console.ReadLine()).Contains("*****"))
                        all_path.Add(input_temp);
                    faff.ChangeListTimeNoSettingNoTraversal(all_path);
                    break;
                case 8:
                    Console.WriteLine("\n\n目前模式：8  修改列表中的所有项目的时间（修改方式：默认，文件夹遍历）\n");
                    //文件列表
                    all_path.Clear();
                    Console.WriteLine("请输入要修改的文件/文件夹路径，以“****”结束：");
                    while (!(input_temp = Console.ReadLine()).Contains("*****"))
                        all_path.Add(input_temp);
                    faff.ChangeListTimeNoSettingWithTraversal(all_path);
                    break;
                case 9:
                    Console.WriteLine("\n\n目前模式：9  特殊时间（针对个人文件）修改\n");
                    //要修改的文件路径
                    Console.WriteLine("请输入要修改的文件/文件夹路径：");
                    path = Console.ReadLine();
                    //时间参考基准
                    Console.WriteLine("请输入 参考基准时间：");
                    string reference_time = Console.ReadLine();
                    while (!utils.CheckTimeString(reference_time))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        reference_time = Console.ReadLine();
                    }
                    Console.WriteLine("请输入 筛选创建时间不早于的时间：");
                    string not_early_than_this_time = Console.ReadLine();
                    while (!utils.CheckTimeString(not_early_than_this_time))
                    {
                        Console.WriteLine("时间格式错误！请重新输入：");
                        not_early_than_this_time = Console.ReadLine();
                    }
                    sn.ChangeFolderTimeWithSpecialNeed(path, reference_time, not_early_than_this_time);
                    break;
            }
            Console.WriteLine("\n\n操作成功，点击回车继续！");
            Console.ReadLine();
            ShowMenu();
        }
    }
}
