using Files_And_Folders_Time_Modification.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_And_Folders_Time_Modification.Code
{
    class UIRefresh
    {
        //添加listView_folder的标题
        public void AddFileListViewTitle(ListView lv)
        {
            lv.Columns.Add(OverAllData.LISTVIEW_FILELIST_XUHAO_STRING, OverAllData.LISTVIEW_FILELIST_XUHAO_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_FILELIST_NAME_STRING, OverAllData.LISTVIEW_FILELIST_NAME_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_FILELIST_PATH_STRING, OverAllData.LISTVIEW_FILELIST_PATH_WIDTH, HorizontalAlignment.Left);
        }

        //根据List列表的项目更新listView_folder的内容
        public void RefreshFileListView(ListView lv,List<string> list)
        {
            lv.BeginUpdate();
            lv.Clear();
            AddFileListViewTitle(lv);
            int i = 1;
            foreach(string str in list)
            {
                ListViewItem it = new ListViewItem();
                it.Text = "" + (i++);
                it.SubItems.Add(System.IO.Path.GetFileName(str));
                it.SubItems.Add(str);
                lv.Items.Add(it);
            }
            lv.EndUpdate();
        }

        //添加listview_countinfo的标题
        public void AddCountInfoListTitle(ListView lv)
        {
            lv.Columns.Add(OverAllData.LISTVIEW_COUNTINFO_COLOUMN1_STRING, OverAllData.LISTVIEW_COUNTINFO_COLOUMN1_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_COUNTINFO_COLOUMN2_STRING, OverAllData.LISTVIEW_COUNTINFO_COLOUMN2_WIDTH, HorizontalAlignment.Left);
            lv.Columns.Add(OverAllData.LISTVIEW_COUNTINFO_COLOUMN3_STRING, OverAllData.LISTVIEW_COUNTINFO_COLOUMN3_WIDTH, HorizontalAlignment.Left);
        }
    }
}
