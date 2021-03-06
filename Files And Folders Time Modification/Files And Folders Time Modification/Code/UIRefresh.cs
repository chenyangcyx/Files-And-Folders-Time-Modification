﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace Files_And_Folders_Time_Modification.Code
{
    class UIRefresh
    {
        OverAllData all = OverAllData.alldata;

        //添加listView_folder的标题
        public void AddFileListViewTitle(ListView lv)
        {
            lv.Columns.Add(OverAllData.LISTVIEW_FILELIST_XUHAO_STRING, OverAllData.LISTVIEW_FILELIST_XUHAO_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_FILELIST_NAME_STRING, OverAllData.LISTVIEW_FILELIST_NAME_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_FILELIST_PATH_STRING, OverAllData.LISTVIEW_FILELIST_PATH_WIDTH, HorizontalAlignment.Left);
        }

        //根据List列表的项目更新listView_folder的内容
        public void RefreshFileListView(ListView lv, List<string> list)
        {
            lv.BeginUpdate();
            lv.Clear();
            AddFileListViewTitle(lv);
            int i = 1;
            foreach (string str in list)
            {
                ListViewItem it = new ListViewItem();
                it.Text = "" + (i++);
                if (!string.IsNullOrEmpty(System.IO.Path.GetFileName(str)))
                    it.SubItems.Add(System.IO.Path.GetFileName(str));
                else
                    it.SubItems.Add(str);
                it.SubItems.Add(str);
                lv.Items.Add(it);
            }
            lv.EndUpdate();
        }

        //添加listView_countinfo的标题
        public void AddCountInfoListTitle(ListView lv)
        {
            lv.Columns.Add(OverAllData.LISTVIEW_COUNTINFO_COLOUMN1_STRING, OverAllData.LISTVIEW_COUNTINFO_COLOUMN1_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_COUNTINFO_COLOUMN2_STRING, OverAllData.LISTVIEW_COUNTINFO_COLOUMN2_WIDTH, HorizontalAlignment.Center);
            lv.Columns.Add(OverAllData.LISTVIEW_COUNTINFO_COLOUMN3_STRING, OverAllData.LISTVIEW_COUNTINFO_COLOUMN3_WIDTH, HorizontalAlignment.Center);
        }

        //更新listView_countinfo的内容
        public void RefreshCountInfo(ListView lv, bool if_ok)
        {
            lv.BeginUpdate();
            lv.Clear();
            AddCountInfoListTitle(lv);
            //文件及文件夹 数量
            ListViewItem it1 = new ListViewItem();
            it1.Text = OverAllData.LISTVIEW_COUNTINFO_INFO1_STRING;
            it1.SubItems.Add("" + all.count_all_filefolder_count);
            ListViewItem it1_1 = new ListViewItem();
            it1_1.Text = OverAllData.LISTVIEW_COUNTINFO_INFO1_FILENUM_STRING;
            it1_1.SubItems.Add("" + all.count_all_file_count);
            ListViewItem it1_2 = new ListViewItem();
            it1_2.Text = OverAllData.LISTVIEW_COUNTINFO_INFO1_FOLDERNUM_STRING;
            it1_2.SubItems.Add("" + all.count_all_folder_count);
            ListViewItem it1_3 = new ListViewItem();
            it1_3.Text = OverAllData.LISTVIEW_COUNTINFO_INFO1_FILEANDFOLDERNUM_STRING;
            it1_3.SubItems.Add("" + all.count_all_filefolder_count);
            if (if_ok)
            {
                it1.SubItems.Add("√");
                it1_1.SubItems.Add("√");
                it1_2.SubItems.Add("√");
                it1_3.SubItems.Add("√");
            }
            else
            {
                it1.SubItems.Add("×");
                it1_1.SubItems.Add("×");
                it1_2.SubItems.Add("×");
                it1_3.SubItems.Add("×");
            }
            //中间的空行
            ListViewItem it_middle_blank = new ListViewItem();

            //已完成设置 数量
            ListViewItem it2 = new ListViewItem();
            it2.Text = OverAllData.LISTVIEW_COUNTINFO_INFO2_STRING;
            it2.SubItems.Add("" + all.count_setted_filefolder_count);
            ListViewItem it2_1 = new ListViewItem();
            it2_1.Text = OverAllData.LISTVIEW_COUNTINFO_INFO2_FILENUM_STRING;
            it2_1.SubItems.Add("" + all.count_setted_file_count);
            ListViewItem it2_2 = new ListViewItem();
            it2_2.Text = OverAllData.LISTVIEW_COUNTINFO_INFO2_FOLDERNUM_STRING;
            it2_2.SubItems.Add("" + all.count_setted_folder_count);
            ListViewItem it2_3 = new ListViewItem();
            it2_3.Text = OverAllData.LISTVIEW_COUNTINFO_INFO2_FILEANDFOLDERNUM_STRING;
            it2_3.SubItems.Add("" + all.count_setted_filefolder_count);
            //检查是否完成设置
            if (all.count_setted_filefolder_count == all.count_all_filefolder_count && all.count_all_filefolder_count != 0)
            {
                it2.SubItems.Add("√");
                it2_1.SubItems.Add("√");
                it2_2.SubItems.Add("√");
                it2_3.SubItems.Add("√");
            }
            else
            {
                if (all.count_setted_filefolder_count < all.count_all_filefolder_count || all.count_setted_filefolder_count == 0)
                {
                    it2.SubItems.Add("×");
                    it2_3.SubItems.Add("×");
                }
                else
                {
                    it2.SubItems.Add("√");
                    it2_3.SubItems.Add("√");
                }
                if (all.count_setted_file_count < all.count_all_file_count || all.count_setted_file_count == 0)
                    it2_1.SubItems.Add("×");
                else
                    it2_1.SubItems.Add("√");
                if (all.count_setted_folder_count < all.count_all_folder_count || all.count_setted_folder_count == 0)
                    it2_2.SubItems.Add("×");
                else
                    it2_2.SubItems.Add("√");
            }

            lv.Items.Add(it1);
            lv.Items.Add(it1_1);
            lv.Items.Add(it1_2);
            lv.Items.Add(it1_3);
            lv.Items.Add(it_middle_blank);
            lv.Items.Add(it2);
            lv.Items.Add(it2_1);
            lv.Items.Add(it2_2);
            lv.Items.Add(it2_3);
            lv.EndUpdate();
        }
    }
}
