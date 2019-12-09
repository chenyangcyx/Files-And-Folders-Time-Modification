namespace Files_And_Folders_Time_Modification
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_addfolder = new System.Windows.Forms.Button();
            this.groupBox_folder_list = new System.Windows.Forms.GroupBox();
            this.listView_folder = new System.Windows.Forms.ListView();
            this.groupBox_countinfo = new System.Windows.Forms.GroupBox();
            this.listView_countinfo = new System.Windows.Forms.ListView();
            this.groupBox_settingbox = new System.Windows.Forms.GroupBox();
            this.label_setting_accessing_time_label = new System.Windows.Forms.Label();
            this.label_setting_modifying_time_label = new System.Windows.Forms.Label();
            this.label_setting_creating_time_label = new System.Windows.Forms.Label();
            this.textBox_setting_accessing_time = new System.Windows.Forms.TextBox();
            this.textBox_setting_modifying_time = new System.Windows.Forms.TextBox();
            this.textBox_setting_creating_time = new System.Windows.Forms.TextBox();
            this.textBox_default_setting_label = new System.Windows.Forms.TextBox();
            this.radioButton_specific_setting = new System.Windows.Forms.RadioButton();
            this.radioButton_default_setting = new System.Windows.Forms.RadioButton();
            this.groupBox_logoutput = new System.Windows.Forms.GroupBox();
            this.textBox_logoutput = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_program_start = new System.Windows.Forms.Button();
            this.button_clear_folder_list = new System.Windows.Forms.Button();
            this.button_reset_program = new System.Windows.Forms.Button();
            this.groupBox_folder_list.SuspendLayout();
            this.groupBox_countinfo.SuspendLayout();
            this.groupBox_settingbox.SuspendLayout();
            this.groupBox_logoutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_addfolder
            // 
            this.button_addfolder.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_addfolder.Location = new System.Drawing.Point(12, 12);
            this.button_addfolder.Name = "button_addfolder";
            this.button_addfolder.Size = new System.Drawing.Size(90, 25);
            this.button_addfolder.TabIndex = 0;
            this.button_addfolder.Text = "添加文件夹";
            this.button_addfolder.UseVisualStyleBackColor = true;
            this.button_addfolder.Click += new System.EventHandler(this.button_addfolder_Click);
            // 
            // groupBox_folder_list
            // 
            this.groupBox_folder_list.Controls.Add(this.listView_folder);
            this.groupBox_folder_list.Location = new System.Drawing.Point(12, 43);
            this.groupBox_folder_list.Name = "groupBox_folder_list";
            this.groupBox_folder_list.Size = new System.Drawing.Size(387, 239);
            this.groupBox_folder_list.TabIndex = 1;
            this.groupBox_folder_list.TabStop = false;
            this.groupBox_folder_list.Text = "文件夹列表";
            // 
            // listView_folder
            // 
            this.listView_folder.AllowDrop = true;
            this.listView_folder.HideSelection = false;
            this.listView_folder.Location = new System.Drawing.Point(6, 20);
            this.listView_folder.Name = "listView_folder";
            this.listView_folder.Size = new System.Drawing.Size(375, 213);
            this.listView_folder.TabIndex = 0;
            this.listView_folder.UseCompatibleStateImageBehavior = false;
            this.listView_folder.View = System.Windows.Forms.View.Details;
            this.listView_folder.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_folder_DragDrop);
            this.listView_folder.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_folder_DragEnter);
            // 
            // groupBox_countinfo
            // 
            this.groupBox_countinfo.Controls.Add(this.listView_countinfo);
            this.groupBox_countinfo.Location = new System.Drawing.Point(12, 289);
            this.groupBox_countinfo.Name = "groupBox_countinfo";
            this.groupBox_countinfo.Size = new System.Drawing.Size(252, 150);
            this.groupBox_countinfo.TabIndex = 2;
            this.groupBox_countinfo.TabStop = false;
            this.groupBox_countinfo.Text = "统计信息";
            // 
            // listView_countinfo
            // 
            this.listView_countinfo.HideSelection = false;
            this.listView_countinfo.Location = new System.Drawing.Point(7, 21);
            this.listView_countinfo.Name = "listView_countinfo";
            this.listView_countinfo.Size = new System.Drawing.Size(239, 123);
            this.listView_countinfo.TabIndex = 0;
            this.listView_countinfo.UseCompatibleStateImageBehavior = false;
            this.listView_countinfo.View = System.Windows.Forms.View.Details;
            // 
            // groupBox_settingbox
            // 
            this.groupBox_settingbox.Controls.Add(this.label_setting_accessing_time_label);
            this.groupBox_settingbox.Controls.Add(this.label_setting_modifying_time_label);
            this.groupBox_settingbox.Controls.Add(this.label_setting_creating_time_label);
            this.groupBox_settingbox.Controls.Add(this.textBox_setting_accessing_time);
            this.groupBox_settingbox.Controls.Add(this.textBox_setting_modifying_time);
            this.groupBox_settingbox.Controls.Add(this.textBox_setting_creating_time);
            this.groupBox_settingbox.Controls.Add(this.textBox_default_setting_label);
            this.groupBox_settingbox.Controls.Add(this.radioButton_specific_setting);
            this.groupBox_settingbox.Controls.Add(this.radioButton_default_setting);
            this.groupBox_settingbox.Location = new System.Drawing.Point(405, 43);
            this.groupBox_settingbox.Name = "groupBox_settingbox";
            this.groupBox_settingbox.Size = new System.Drawing.Size(319, 239);
            this.groupBox_settingbox.TabIndex = 3;
            this.groupBox_settingbox.TabStop = false;
            this.groupBox_settingbox.Text = "相关设置";
            // 
            // label_setting_accessing_time_label
            // 
            this.label_setting_accessing_time_label.AutoSize = true;
            this.label_setting_accessing_time_label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_setting_accessing_time_label.Location = new System.Drawing.Point(6, 212);
            this.label_setting_accessing_time_label.Name = "label_setting_accessing_time_label";
            this.label_setting_accessing_time_label.Size = new System.Drawing.Size(77, 14);
            this.label_setting_accessing_time_label.TabIndex = 8;
            this.label_setting_accessing_time_label.Text = "访问时间：";
            // 
            // label_setting_modifying_time_label
            // 
            this.label_setting_modifying_time_label.AutoSize = true;
            this.label_setting_modifying_time_label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_setting_modifying_time_label.Location = new System.Drawing.Point(6, 184);
            this.label_setting_modifying_time_label.Name = "label_setting_modifying_time_label";
            this.label_setting_modifying_time_label.Size = new System.Drawing.Size(77, 14);
            this.label_setting_modifying_time_label.TabIndex = 7;
            this.label_setting_modifying_time_label.Text = "修改时间：";
            // 
            // label_setting_creating_time_label
            // 
            this.label_setting_creating_time_label.AutoSize = true;
            this.label_setting_creating_time_label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_setting_creating_time_label.Location = new System.Drawing.Point(6, 156);
            this.label_setting_creating_time_label.Name = "label_setting_creating_time_label";
            this.label_setting_creating_time_label.Size = new System.Drawing.Size(77, 14);
            this.label_setting_creating_time_label.TabIndex = 6;
            this.label_setting_creating_time_label.Text = "创建时间：";
            // 
            // textBox_setting_accessing_time
            // 
            this.textBox_setting_accessing_time.Location = new System.Drawing.Point(84, 210);
            this.textBox_setting_accessing_time.Name = "textBox_setting_accessing_time";
            this.textBox_setting_accessing_time.Size = new System.Drawing.Size(229, 21);
            this.textBox_setting_accessing_time.TabIndex = 5;
            // 
            // textBox_setting_modifying_time
            // 
            this.textBox_setting_modifying_time.Location = new System.Drawing.Point(84, 182);
            this.textBox_setting_modifying_time.Name = "textBox_setting_modifying_time";
            this.textBox_setting_modifying_time.Size = new System.Drawing.Size(229, 21);
            this.textBox_setting_modifying_time.TabIndex = 4;
            // 
            // textBox_setting_creating_time
            // 
            this.textBox_setting_creating_time.Location = new System.Drawing.Point(84, 154);
            this.textBox_setting_creating_time.Name = "textBox_setting_creating_time";
            this.textBox_setting_creating_time.Size = new System.Drawing.Size(229, 21);
            this.textBox_setting_creating_time.TabIndex = 3;
            // 
            // textBox_default_setting_label
            // 
            this.textBox_default_setting_label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_default_setting_label.Enabled = false;
            this.textBox_default_setting_label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_default_setting_label.Location = new System.Drawing.Point(22, 43);
            this.textBox_default_setting_label.Multiline = true;
            this.textBox_default_setting_label.Name = "textBox_default_setting_label";
            this.textBox_default_setting_label.Size = new System.Drawing.Size(291, 82);
            this.textBox_default_setting_label.TabIndex = 2;
            this.textBox_default_setting_label.Text = "设置文件夹的“创建时间”为文件夹中所有文件最早的“创建时间”\r\n设置文件夹的“修改时间”为文件夹中所有文件最晚的“修改时间”\r\n设置文件夹的“访问时间”为之前经过" +
    "修改的文件夹的修改时间";
            // 
            // radioButton_specific_setting
            // 
            this.radioButton_specific_setting.AutoSize = true;
            this.radioButton_specific_setting.Location = new System.Drawing.Point(6, 131);
            this.radioButton_specific_setting.Name = "radioButton_specific_setting";
            this.radioButton_specific_setting.Size = new System.Drawing.Size(71, 16);
            this.radioButton_specific_setting.TabIndex = 1;
            this.radioButton_specific_setting.Text = "统一设置";
            this.radioButton_specific_setting.UseVisualStyleBackColor = true;
            this.radioButton_specific_setting.CheckedChanged += new System.EventHandler(this.radioButton_specific_setting_CheckedChanged);
            // 
            // radioButton_default_setting
            // 
            this.radioButton_default_setting.AutoSize = true;
            this.radioButton_default_setting.Checked = true;
            this.radioButton_default_setting.Location = new System.Drawing.Point(7, 21);
            this.radioButton_default_setting.Name = "radioButton_default_setting";
            this.radioButton_default_setting.Size = new System.Drawing.Size(71, 16);
            this.radioButton_default_setting.TabIndex = 0;
            this.radioButton_default_setting.TabStop = true;
            this.radioButton_default_setting.Text = "默认设置";
            this.radioButton_default_setting.UseVisualStyleBackColor = true;
            this.radioButton_default_setting.CheckedChanged += new System.EventHandler(this.radioButton_default_setting_CheckedChanged);
            // 
            // groupBox_logoutput
            // 
            this.groupBox_logoutput.Controls.Add(this.textBox_logoutput);
            this.groupBox_logoutput.Location = new System.Drawing.Point(295, 289);
            this.groupBox_logoutput.Name = "groupBox_logoutput";
            this.groupBox_logoutput.Size = new System.Drawing.Size(429, 150);
            this.groupBox_logoutput.TabIndex = 4;
            this.groupBox_logoutput.TabStop = false;
            this.groupBox_logoutput.Text = "日志输出";
            // 
            // textBox_logoutput
            // 
            this.textBox_logoutput.Location = new System.Drawing.Point(68, 21);
            this.textBox_logoutput.Multiline = true;
            this.textBox_logoutput.Name = "textBox_logoutput";
            this.textBox_logoutput.Size = new System.Drawing.Size(395, 123);
            this.textBox_logoutput.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 511);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(624, 31);
            this.progressBar.TabIndex = 5;
            // 
            // button_program_start
            // 
            this.button_program_start.Location = new System.Drawing.Point(643, 511);
            this.button_program_start.Name = "button_program_start";
            this.button_program_start.Size = new System.Drawing.Size(81, 31);
            this.button_program_start.TabIndex = 6;
            this.button_program_start.Text = "启动";
            this.button_program_start.UseVisualStyleBackColor = true;
            // 
            // button_clear_folder_list
            // 
            this.button_clear_folder_list.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_clear_folder_list.Location = new System.Drawing.Point(108, 12);
            this.button_clear_folder_list.Name = "button_clear_folder_list";
            this.button_clear_folder_list.Size = new System.Drawing.Size(75, 25);
            this.button_clear_folder_list.TabIndex = 7;
            this.button_clear_folder_list.Text = "清空列表";
            this.button_clear_folder_list.UseVisualStyleBackColor = true;
            this.button_clear_folder_list.Click += new System.EventHandler(this.button_clear_folder_list_Click);
            // 
            // button_reset_program
            // 
            this.button_reset_program.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_reset_program.Location = new System.Drawing.Point(189, 12);
            this.button_reset_program.Name = "button_reset_program";
            this.button_reset_program.Size = new System.Drawing.Size(75, 25);
            this.button_reset_program.TabIndex = 8;
            this.button_reset_program.Text = "重置程序";
            this.button_reset_program.UseVisualStyleBackColor = true;
            this.button_reset_program.Click += new System.EventHandler(this.button_reset_program_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 549);
            this.Controls.Add(this.button_reset_program);
            this.Controls.Add(this.button_clear_folder_list);
            this.Controls.Add(this.button_program_start);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox_logoutput);
            this.Controls.Add(this.groupBox_settingbox);
            this.Controls.Add(this.groupBox_countinfo);
            this.Controls.Add(this.groupBox_folder_list);
            this.Controls.Add(this.button_addfolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "文件与文件夹时间修改";
            this.groupBox_folder_list.ResumeLayout(false);
            this.groupBox_countinfo.ResumeLayout(false);
            this.groupBox_settingbox.ResumeLayout(false);
            this.groupBox_settingbox.PerformLayout();
            this.groupBox_logoutput.ResumeLayout(false);
            this.groupBox_logoutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_addfolder;
        private System.Windows.Forms.GroupBox groupBox_folder_list;
        private System.Windows.Forms.GroupBox groupBox_countinfo;
        private System.Windows.Forms.GroupBox groupBox_settingbox;
        private System.Windows.Forms.GroupBox groupBox_logoutput;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_program_start;
        private System.Windows.Forms.Button button_clear_folder_list;
        private System.Windows.Forms.Button button_reset_program;
        private System.Windows.Forms.RadioButton radioButton_specific_setting;
        private System.Windows.Forms.RadioButton radioButton_default_setting;
        private System.Windows.Forms.TextBox textBox_logoutput;
        private System.Windows.Forms.TextBox textBox_default_setting_label;
        private System.Windows.Forms.TextBox textBox_setting_accessing_time;
        private System.Windows.Forms.TextBox textBox_setting_modifying_time;
        private System.Windows.Forms.TextBox textBox_setting_creating_time;
        private System.Windows.Forms.Label label_setting_modifying_time_label;
        private System.Windows.Forms.Label label_setting_creating_time_label;
        private System.Windows.Forms.Label label_setting_accessing_time_label;
        private System.Windows.Forms.ListView listView_folder;
        private System.Windows.Forms.ListView listView_countinfo;
    }
}

