using Files_And_Folders_Time_Modification.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_And_Folders_Time_Modification
{
    public partial class MainForm : Form
    {
        OverAllData all = OverAllData.alldata;
        UIRefresh uir = new UIRefresh();
        LogOutput lop;
        Utils ut = new Utils();
        FileAndFolderFunction faff = new FileAndFolderFunction();

        public MainForm()
        {
            InitializeComponent();
            InitAll();
            //LogOutput类的初始化
            lop = new LogOutput(textBox_logoutput);
            //设置选项
            all.setting_choice = OverAllData.SETTING_DEFAULT;
            radioButton_default_setting.Checked = true;
            radioButton_specific_setting.Checked = false;
            textBox_setting_creating_time.Text = "";
            textBox_setting_modifying_time.Text = "";
            textBox_setting_accessing_time.Text = "";
            textBox_setting_creating_time.Enabled = false;
            textBox_setting_modifying_time.Enabled = false;
            textBox_setting_accessing_time.Enabled = false;
        }

        //初始化程序
        private void InitAll()
        {
            //初始化filelist列表
            all.listview_file_list.Clear();
            //更新listview列表视图
            uir.RefreshFileListView(listView_folder, all.listview_file_list);
            //设置选项的更新写在构造函数中
            //重置统计信息
            all.count_all_file_count = OverAllData.COUNT_ALL_FILE_COUNT_INTI;
            all.count_all_folder_count = OverAllData.COUNT_ALL_FOLDER_COUNT_INTI;
            all.count_all_filefolder_count = OverAllData.COUNT_ALL_FILEFOLDER_COUNT_INIT;
            all.count_setted_file_count = OverAllData.COUNT_SETTED_FILE_COUNT_INIT;
            all.count_setted_folder_count = OverAllData.COUNT_SETTED_FOLDER_COUNT_INIT;
            all.count_setted_filefolder_count = OverAllData.COUNT_SETTED_FILEFOLDER_COUNT_INIT;
            uir.RefreshCountInfo(listView_countinfo, false);
            //输出日志
            textBox_logoutput.Clear();
        }

        //按钮“添加文件夹”操作
        private void button_addfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_choose_dialog = new FolderBrowserDialog();

            folder_choose_dialog.Description = "请选择要设置的文件夹";
            if (folder_choose_dialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(this, "文件夹路径不能为空！", "提示");
                return;
            }
            else
            {
                //添加到文件列表
                all.listview_file_list.Add(folder_choose_dialog.SelectedPath);
                //输出日志
                lop.AddFileAndFolder(folder_choose_dialog.SelectedPath);
                //列表的去重操作
                all.listview_file_list = all.listview_file_list.Distinct().ToList();
                //更新UI的图表
                uir.RefreshFileListView(listView_folder, all.listview_file_list);
                //更新统计信息
                faff.RefreshCountInfoByFileList(all.listview_file_list, out all.count_all_filefolder_count, out all.count_all_file_count, out all.count_all_folder_count);
                uir.RefreshCountInfo(listView_countinfo, true);
            }
        }

        //按钮“清空列表”操作
        private void button_clear_folder_list_Click(object sender, EventArgs e)
        {
            all.listview_file_list.Clear();
            lop.ClearFileList();
            uir.RefreshFileListView(listView_folder, all.listview_file_list);
            //重置统计信息
            all.count_all_file_count = OverAllData.COUNT_ALL_FILE_COUNT_INTI;
            all.count_all_folder_count = OverAllData.COUNT_ALL_FOLDER_COUNT_INTI;
            all.count_all_filefolder_count = OverAllData.COUNT_ALL_FILEFOLDER_COUNT_INIT;
            all.count_setted_file_count = OverAllData.COUNT_SETTED_FILE_COUNT_INIT;
            all.count_setted_folder_count = OverAllData.COUNT_SETTED_FOLDER_COUNT_INIT;
            all.count_setted_filefolder_count = OverAllData.COUNT_SETTED_FILEFOLDER_COUNT_INIT;
            uir.RefreshCountInfo(listView_countinfo, false);
        }

        //按钮“重置程序”操作
        private void button_reset_program_Click(object sender, EventArgs e)
        {
            InitAll();
        }

        //ListView_folder拖入时的检查
        private void listView_folder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        //ListView_folder拖入后操作
        private void listView_folder_DragDrop(object sender, DragEventArgs e)
        {
            foreach(object ob in (Array)e.Data.GetData(DataFormats.FileDrop))
            {
                all.listview_file_list.Add(ob.ToString());
                lop.AddFileAndFolder(ob.ToString());
            }
            //列表的去重操作
            all.listview_file_list = all.listview_file_list.Distinct().ToList();
            //更新UI的图表
            uir.RefreshFileListView(listView_folder, all.listview_file_list);
            //更新统计信息
            faff.RefreshCountInfoByFileList(all.listview_file_list, out all.count_all_filefolder_count, out all.count_all_file_count, out all.count_all_folder_count);
            uir.RefreshCountInfo(listView_countinfo, true);
        }

        //相关设置-默认设置
        private void radioButton_default_setting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_default_setting.Checked)
            {
                radioButton_specific_setting.Checked = false;
                textBox_setting_creating_time.Enabled = false;
                textBox_setting_modifying_time.Enabled = false;
                textBox_setting_accessing_time.Enabled = false;
                all.setting_choice = OverAllData.SETTING_DEFAULT;
                lop.ChangeSettingToDefaultSetting();
            }
        }

        //相关设置-统一设置
        private void radioButton_specific_setting_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_specific_setting.Checked)
            {
                radioButton_default_setting.Checked = false;
                textBox_setting_creating_time.Enabled = true;
                textBox_setting_modifying_time.Enabled = true;
                textBox_setting_accessing_time.Enabled = true;
                all.setting_choice = OverAllData.SETTING_SPECIFIC;
                lop.ChangeSettingToSpecificSetting();
            }
        }

        //按钮“启动”操作
        private void button_program_start_Click(object sender, EventArgs e)
        {
            lop.StartSettingInfo();
            //检查文件列表
            lop.StartSettingCheck("文件列表内容");
            if (all.listview_file_list.Count != 0)
                lop.StartSettingCheckResultShow(true);
            else
            {
                lop.StartSettingCheckResultShow(false);
                return;
            }
            //检查设置
            lop.StartSettingCheck("设置内容，");
            int     year_create = 0, month_create = 0, day_create = 0, hour_create = 0, minute_create = 0, second_create = 0,
                    year_modify = 0, month_modify = 0, day_modify = 0, hour_modify = 0, minute_modify = 0, second_modify = 0,
                    year_access = 0, month_access = 0, day_access = 0, hour_access = 0, minute_access = 0, second_access = 0;
            if (radioButton_default_setting.Checked)
            {
                lop.StartSettingCheckSettings(1);
                lop.StartSettingCheckResultShow(true);
            }
            else
            {
                lop.StartSettingCheckSettings(2);
                //检查输入的时间格式
                lop.StartSettingCheck("时间格式");
                if (ut.CheckTimeString(textBox_setting_creating_time.Text) && ut.CheckTimeString(textBox_setting_modifying_time.Text)
                    && ut.CheckTimeString(textBox_setting_accessing_time.Text))
                    lop.StartSettingCheckResultShow(true);
                else
                    return;
                ut.GetDateTimeValueFromString(textBox_setting_creating_time.Text, out year_create, out month_create, out day_create,
                    out hour_create, out minute_create, out second_create);
                ut.GetDateTimeValueFromString(textBox_setting_modifying_time.Text, out year_modify, out month_modify, out day_modify,
                    out hour_modify, out minute_modify, out second_modify);
                ut.GetDateTimeValueFromString(textBox_setting_accessing_time.Text, out year_access, out month_access, out day_access,
                    out hour_access, out minute_access, out second_access);
                lop.CommonStringOutput("创建时间：" + textBox_setting_creating_time.Text);
                lop.CommonStringOutput("修改时间：" + textBox_setting_modifying_time.Text);
                lop.CommonStringOutput("访问时间：" + textBox_setting_accessing_time.Text);
            }

            /*开始执行*/
            //指定设置
            if (radioButton_specific_setting.Checked)
            {
                //创建设置的时间类型
                DateTime dt_create = new DateTime(year_create, month_create, day_create, hour_create, minute_create, second_create, DateTimeKind.Local);
                DateTime dt_modify = new DateTime(year_modify, month_modify, day_modify, hour_modify, minute_modify, second_modify, DateTimeKind.Local);
                DateTime dt_access = new DateTime(year_access, month_access, day_access, hour_access, minute_access, second_access, DateTimeKind.Local);
                foreach (string path in all.listview_file_list)
                {
                    //重置存储数据的链表
                    all.list_all_filefolder.Clear();
                    all.list_all_folder.Clear();
                    //输出信息
                    lop.CheckFileAndFolder(path);
                    //检查这个路径是文件还是文件夹
                    int file_type = faff.CheckIfFileOrFolder(path);
                    //如果是文件
                    if (file_type == OverAllData.FILETYPE_FILE)
                    {
                        faff.SetFileORFolderTime(path, OverAllData.FILETYPE_FILE, dt_create, dt_modify, dt_access, ref all.count_setted_file_count, ref all.count_setted_folder_count, ref all.count_setted_filefolder_count);
                        lop.FileORFolderHandleOver(path, true);
                    }
                    //如果是文件夹
                    else if (file_type == OverAllData.FILETYPE_FOLDER)
                    {
                        //获取该目录下的所有文件/文件夹
                        faff.GetFileFolderListFromFolder(path, all.list_all_filefolder);
                        //翻转链表
                        all.list_all_filefolder.Reverse();
                        //遍历链表，逐个修改
                        foreach(FileFolderInfoNode ffin in all.list_all_filefolder)
                        {
                            //是文件类型
                            if (ffin.type == OverAllData.FILETYPE_FILE)
                                faff.SetFileORFolderTime(ffin.file_info.FullName, OverAllData.FILETYPE_FILE, dt_create, dt_modify, dt_access, ref all.count_setted_file_count, ref all.count_setted_folder_count, ref all.count_setted_filefolder_count);
                            //是文件夹类型
                            else if (ffin.type == OverAllData.FILETYPE_FOLDER)
                                faff.SetFileORFolderTime(ffin.folder_info.FullName, OverAllData.FILETYPE_FOLDER, dt_create, dt_modify, dt_access, ref all.count_setted_file_count, ref all.count_setted_folder_count, ref all.count_setted_filefolder_count);
                        }
                        lop.FileORFolderHandleOver(path, true);
                    }
                    //更新统计窗口的信息
                    uir.RefreshCountInfo(listView_countinfo, true);
                }
            }
            //默认设置
            else
            {
                foreach (string path in all.listview_file_list)
                {
                    //重置存储数据的链表
                    all.list_all_filefolder.Clear();
                    all.list_all_folder.Clear();
                    //输出信息
                    lop.CheckFileAndFolder(path);
                    //检查这个路径是文件还是文件夹
                    int file_type = faff.CheckIfFileOrFolder(path);
                    //如果是文件夹
                    if (file_type == OverAllData.FILETYPE_FOLDER)
                    {
                        //获取该目录下的所有文件夹
                        faff.GetFolderListFromFolder(path, all.list_all_folder);
                        //翻转链表
                        all.list_all_folder.Reverse();
                        //开始修改文件夹
                        faff.RefreshTimeInFileFolderListWithDefaultSetting(all.list_all_folder, ref all.count_setted_file_count, ref all.count_setted_folder_count, ref all.count_setted_filefolder_count);
                        lop.FileORFolderHandleOver(path, true);
                    }
                    //如果是文件
                    else if (file_type == OverAllData.FILETYPE_FILE)
                    {
                        //没什么需要做的
                        //计数自增
                        faff.SettedFileAndFolderNumSelfAdd(OverAllData.FILETYPE_FILE, ref all.count_setted_file_count, ref all.count_setted_folder_count, ref all.count_setted_filefolder_count);
                        lop.FileORFolderHandleOver(path, true);
                    }
                    else
                        lop.FileORFolderHandleOver(path, false);
                    //更新统计窗口的信息
                    uir.RefreshCountInfo(listView_countinfo, true);
                }
            }
        }
    }
}
