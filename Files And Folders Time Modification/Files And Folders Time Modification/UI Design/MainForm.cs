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
        OverAllData all = new OverAllData();
        UIRefresh uir = new UIRefresh();

        public MainForm()
        {
            InitializeComponent();
            InitAll();
        }

        //初始化程序
        private void InitAll()
        {
            //初始化filelist列表
            all.file_list.Clear();
            //更新listview列表视图
            uir.RefreshFileListView(listView_folder, all.file_list);

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
                all.file_list.Add(folder_choose_dialog.SelectedPath);
                //列表的去重操作
                all.file_list = all.file_list.Distinct().ToList();
                //更新UI的图表
                uir.RefreshFileListView(listView_folder, all.file_list);
            }
        }

        //按钮“清空列表”操作
        private void button_clear_folder_list_Click(object sender, EventArgs e)
        {
            all.file_list.Clear();
            uir.RefreshFileListView(listView_folder, all.file_list);
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
            int file_num = ((Array)e.Data.GetData(DataFormats.FileDrop)).Length;
            string[] all_folder = new string[file_num];
            foreach(object ob in (Array)e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(ob.ToString()))
                    all.file_list.Add(ob.ToString());
            }
            //列表的去重操作
            all.file_list = all.file_list.Distinct().ToList();
            //更新UI的图表
            uir.RefreshFileListView(listView_folder, all.file_list);
        }

        //按钮“重置程序”操作
        private void button_reset_program_Click(object sender, EventArgs e)
        {
            InitAll();
        }
    }
}
