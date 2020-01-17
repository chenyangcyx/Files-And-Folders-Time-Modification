using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_And_Folders_Time_Modification.Code
{
    class LogOutput
    {
        private TextBox box;

        public LogOutput(TextBox textbox)
        {
            box = textbox;
        }

        //普通消息的输出
        public void CommonStringOutput(string str)
        {
            box.AppendText(str + Environment.NewLine);
        }

        //添加文件/文件夹事件
        public void AddFileAndFolder(string path)
        {
            box.AppendText("添加了文件/文件夹：" + path + Environment.NewLine);
        }

        //清空文件列表
        public void ClearFileList()
        {
            box.AppendText("清空了文件/文件夹列表！" + Environment.NewLine);
        }

        //修改设置-“默认设置”
        public void ChangeSettingToDefaultSetting()
        {
            box.AppendText("更改了设置：默认设置" + Environment.NewLine);
        }

        //修改设置-“统一设置”
        public void ChangeSettingToSpecificSetting()
        {
            box.AppendText("更改了设置：统一设置" + Environment.NewLine);
        }

        //启动程序通知
        public void StartSettingInfo()
        {
            box.AppendText("启动程序！" + Environment.NewLine);
        }

        //启动程序检查
        public void StartSettingCheck(string check_content)
        {
            box.AppendText("检查：" + check_content);
        }

        //程序检查-设置内容
        public void StartSettingCheckSettings(int setting_num)
        {
            if (setting_num == 1)
                box.AppendText("默认设置");
            else
                box.AppendText("统一设置");
        }

        //程序检查结果显示
        public void StartSettingCheckResultShow(bool result)
        {
            if (result)
                box.AppendText("...............OK" + Environment.NewLine);
            else
                box.AppendText("...............Fail" + Environment.NewLine);
        }

        //检索文件夹内的文件和文件夹
        public void CheckFileAndFolder(string path)
        {
            box.AppendText("开始检查文件/文件夹：" + path + Environment.NewLine);
        }

        //文件、文件夹处理完成
        public void FileORFolderHandleOver(string name,bool result)
        {
            if (result)
                box.AppendText(name + " 处理成功！" + Environment.NewLine);
            else
                box.AppendText(name + " 处理失败！" + Environment.NewLine);
        }
    }
}
