namespace NotePadPlus
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileActions = new System.Windows.Forms.ToolStripMenuItem();
            this.Create = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_As = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_Z = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Ctrl_X = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_C = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_V = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Ctrl_A = new System.Windows.Forms.ToolStripMenuItem();
            this.DateAndTime = new System.Windows.Forms.ToolStripMenuItem();
            this.Format = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeAllFont = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.GetBackUps = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLinesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusWordsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCharsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Note1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Ctrl_A_Context = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_X_Context = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_C_Context = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctrl_V_Context = new System.Windows.Forms.ToolStripMenuItem();
            this.Format_Context = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.notifyIconSave = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileActions,
            this.Edit,
            this.Format,
            this.Settings,
            this.GetBackUps});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileActions
            // 
            this.FileActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create,
            this.Open,
            this.toolStripMenuItem1,
            this.Save,
            this.Save_As,
            this.SaveAllNotes,
            this.toolStripSeparator1,
            this.CloseTab,
            this.Exit});
            this.FileActions.Name = "FileActions";
            this.FileActions.Size = new System.Drawing.Size(48, 19);
            this.FileActions.Text = "Файл";
            // 
            // Create
            // 
            this.Create.Image = global::NotePadPlus.Properties.Resources.file_text_icon_PNG;
            this.Create.Name = "Create";
            this.Create.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.Create.Size = new System.Drawing.Size(315, 22);
            this.Create.Text = "Создать";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Open
            // 
            this.Open.Image = global::NotePadPlus.Properties.Resources.folder_documents_icon;
            this.Open.Name = "Open";
            this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open.Size = new System.Drawing.Size(315, 22);
            this.Open.Text = "Открыть...";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::NotePadPlus.Properties.Resources.copy_icon;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(315, 22);
            this.toolStripMenuItem1.Text = "Открыть NotePadPlus  в новом окне";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // Save
            // 
            this.Save.Image = global::NotePadPlus.Properties.Resources.save_icon;
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(315, 22);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Save_As
            // 
            this.Save_As.Image = global::NotePadPlus.Properties.Resources.save_icon;
            this.Save_As.Name = "Save_As";
            this.Save_As.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.Save_As.Size = new System.Drawing.Size(315, 22);
            this.Save_As.Text = "Сохранить как...";
            this.Save_As.Click += new System.EventHandler(this.Save_As_Click);
            // 
            // SaveAllNotes
            // 
            this.SaveAllNotes.Image = global::NotePadPlus.Properties.Resources.save_icon;
            this.SaveAllNotes.Name = "SaveAllNotes";
            this.SaveAllNotes.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllNotes.Size = new System.Drawing.Size(315, 22);
            this.SaveAllNotes.Text = "Сохранить все...";
            this.SaveAllNotes.Click += new System.EventHandler(this.SaveAllNotes_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(312, 6);
            // 
            // CloseTab
            // 
            this.CloseTab.Image = global::NotePadPlus.Properties.Resources.trash_2_icon;
            this.CloseTab.Name = "CloseTab";
            this.CloseTab.Size = new System.Drawing.Size(315, 22);
            this.CloseTab.Text = "Закрыть вкладку";
            this.CloseTab.Click += new System.EventHandler(this.CloseTab_Click);
            // 
            // Exit
            // 
            this.Exit.Image = global::NotePadPlus.Properties.Resources.log_out_icon;
            this.Exit.Name = "Exit";
            this.Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Exit.Size = new System.Drawing.Size(315, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Edit
            // 
            this.Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ctrl_Z,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.Ctrl_X,
            this.Ctrl_C,
            this.Ctrl_V,
            this.Delete,
            this.toolStripSeparator3,
            this.Ctrl_A,
            this.DateAndTime});
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(59, 19);
            this.Edit.Text = "Правка";
            // 
            // Ctrl_Z
            // 
            this.Ctrl_Z.Image = global::NotePadPlus.Properties.Resources.chevrons_left_icon;
            this.Ctrl_Z.Name = "Ctrl_Z";
            this.Ctrl_Z.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Ctrl_Z.Size = new System.Drawing.Size(212, 22);
            this.Ctrl_Z.Text = "Отменить";
            this.Ctrl_Z.Click += new System.EventHandler(this.Ctrl_Z_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::NotePadPlus.Properties.Resources.chevrons_right_icon;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItem2.Text = "Повторить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.Ctrl_Shift_Z_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // Ctrl_X
            // 
            this.Ctrl_X.Image = global::NotePadPlus.Properties.Resources.bookmark_favourite_icon;
            this.Ctrl_X.Name = "Ctrl_X";
            this.Ctrl_X.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Ctrl_X.Size = new System.Drawing.Size(212, 22);
            this.Ctrl_X.Text = "Вырезать";
            this.Ctrl_X.Click += new System.EventHandler(this.Ctrl_X_Click);
            // 
            // Ctrl_C
            // 
            this.Ctrl_C.Image = global::NotePadPlus.Properties.Resources.copy_icon;
            this.Ctrl_C.Name = "Ctrl_C";
            this.Ctrl_C.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Ctrl_C.Size = new System.Drawing.Size(212, 22);
            this.Ctrl_C.Text = "Копировать";
            this.Ctrl_C.Click += new System.EventHandler(this.Ctrl_C_Click);
            // 
            // Ctrl_V
            // 
            this.Ctrl_V.Image = global::NotePadPlus.Properties.Resources.log_in_icon;
            this.Ctrl_V.Name = "Ctrl_V";
            this.Ctrl_V.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.Ctrl_V.Size = new System.Drawing.Size(212, 22);
            this.Ctrl_V.Text = "Вставить";
            this.Ctrl_V.Click += new System.EventHandler(this.Ctrl_V_Click);
            // 
            // Delete
            // 
            this.Delete.Image = global::NotePadPlus.Properties.Resources.trash_2_icon;
            this.Delete.Name = "Delete";
            this.Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.Delete.Size = new System.Drawing.Size(212, 22);
            this.Delete.Text = "Удалить";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // Ctrl_A
            // 
            this.Ctrl_A.Image = global::NotePadPlus.Properties.Resources.smile_icon;
            this.Ctrl_A.Name = "Ctrl_A";
            this.Ctrl_A.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.Ctrl_A.Size = new System.Drawing.Size(212, 22);
            this.Ctrl_A.Text = "Выделить все";
            this.Ctrl_A.Click += new System.EventHandler(this.Ctrl_A_Click);
            // 
            // DateAndTime
            // 
            this.DateAndTime.Image = global::NotePadPlus.Properties.Resources.clock_watch_icon;
            this.DateAndTime.Name = "DateAndTime";
            this.DateAndTime.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.DateAndTime.Size = new System.Drawing.Size(212, 22);
            this.DateAndTime.Text = "Время и дата";
            this.DateAndTime.Click += new System.EventHandler(this.DateAndTime_Click);
            // 
            // Format
            // 
            this.Format.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.ChangeAllFont});
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(62, 19);
            this.Format.Text = "Формат";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::NotePadPlus.Properties.Resources.type_text_icon;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem3.Text = "Форматировать фрагмент...";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.Format_Click);
            // 
            // ChangeAllFont
            // 
            this.ChangeAllFont.Image = global::NotePadPlus.Properties.Resources.italic_text_icon;
            this.ChangeAllFont.Name = "ChangeAllFont";
            this.ChangeAllFont.Size = new System.Drawing.Size(227, 22);
            this.ChangeAllFont.Text = "Выбрать основной шрифт";
            this.ChangeAllFont.Click += new System.EventHandler(this.ChangeAllFont_Click);
            // 
            // Settings
            // 
            this.Settings.Image = global::NotePadPlus.Properties.Resources.sliders_icon;
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(95, 20);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // GetBackUps
            // 
            this.GetBackUps.Name = "GetBackUps";
            this.GetBackUps.Size = new System.Drawing.Size(116, 19);
            this.GetBackUps.Text = "Журналирование";
            this.GetBackUps.Click += new System.EventHandler(this.GetBackUps_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLinesCount,
            this.toolStripStatusLabel3,
            this.statusWordsCount,
            this.toolStripStatusLabel5,
            this.statusCharsCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 579);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1110, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel1.Text = "Строк: ";
            // 
            // statusLinesCount
            // 
            this.statusLinesCount.Name = "statusLinesCount";
            this.statusLinesCount.Size = new System.Drawing.Size(13, 17);
            this.statusLinesCount.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel3.Text = "Слов: ";
            // 
            // statusWordsCount
            // 
            this.statusWordsCount.Name = "statusWordsCount";
            this.statusWordsCount.Size = new System.Drawing.Size(13, 17);
            this.statusWordsCount.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel5.Text = "Символов: ";
            // 
            // statusCharsCount
            // 
            this.statusCharsCount.Name = "statusCharsCount";
            this.statusCharsCount.Size = new System.Drawing.Size(13, 17);
            this.statusCharsCount.Text = "0";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Note1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1102, 527);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вкладка 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Note1
            // 
            this.Note1.AcceptsTab = true;
            this.Note1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Note1.ContextMenuStrip = this.contextMenuStrip1;
            this.Note1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Note1.Location = new System.Drawing.Point(3, 3);
            this.Note1.Name = "Note1";
            this.Note1.Size = new System.Drawing.Size(1096, 521);
            this.Note1.TabIndex = 0;
            this.Note1.Text = "";
            this.Note1.WordWrap = false;
            this.Note1.TextChanged += new System.EventHandler(this.MyNote_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ctrl_A_Context,
            this.Ctrl_X_Context,
            this.Ctrl_C_Context,
            this.Ctrl_V_Context,
            this.Format_Context});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(228, 114);
            // 
            // Ctrl_A_Context
            // 
            this.Ctrl_A_Context.Image = global::NotePadPlus.Properties.Resources.smile_icon;
            this.Ctrl_A_Context.Name = "Ctrl_A_Context";
            this.Ctrl_A_Context.Size = new System.Drawing.Size(227, 22);
            this.Ctrl_A_Context.Text = "Выделить все";
            this.Ctrl_A_Context.Click += new System.EventHandler(this.Ctrl_A_Click);
            // 
            // Ctrl_X_Context
            // 
            this.Ctrl_X_Context.Image = global::NotePadPlus.Properties.Resources.bookmark_favourite_icon;
            this.Ctrl_X_Context.Name = "Ctrl_X_Context";
            this.Ctrl_X_Context.Size = new System.Drawing.Size(227, 22);
            this.Ctrl_X_Context.Text = "Вырезать";
            this.Ctrl_X_Context.Click += new System.EventHandler(this.Ctrl_X_Click);
            // 
            // Ctrl_C_Context
            // 
            this.Ctrl_C_Context.Image = global::NotePadPlus.Properties.Resources.copy_icon;
            this.Ctrl_C_Context.Name = "Ctrl_C_Context";
            this.Ctrl_C_Context.Size = new System.Drawing.Size(227, 22);
            this.Ctrl_C_Context.Text = "Копировать";
            this.Ctrl_C_Context.Click += new System.EventHandler(this.Ctrl_C_Click);
            // 
            // Ctrl_V_Context
            // 
            this.Ctrl_V_Context.Image = global::NotePadPlus.Properties.Resources.log_in_icon;
            this.Ctrl_V_Context.Name = "Ctrl_V_Context";
            this.Ctrl_V_Context.Size = new System.Drawing.Size(227, 22);
            this.Ctrl_V_Context.Text = "Вставить";
            this.Ctrl_V_Context.Click += new System.EventHandler(this.Ctrl_V_Click);
            // 
            // Format_Context
            // 
            this.Format_Context.Image = global::NotePadPlus.Properties.Resources.type_text_icon;
            this.Format_Context.Name = "Format_Context";
            this.Format_Context.Size = new System.Drawing.Size(227, 22);
            this.Format_Context.Text = "Форматировать фрагмент...";
            this.Format_Context.Click += new System.EventHandler(this.Format_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1110, 555);
            this.tabControl.TabIndex = 3;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 601);
            this.panel1.TabIndex = 1;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 100000000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Enabled = true;
            this.Timer2.Interval = 100000000;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // notifyIconSave
            // 
            this.notifyIconSave.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconSave.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSave.Icon")));
            this.notifyIconSave.Text = "NotePadPlus";
            this.notifyIconSave.Visible = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 601);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "NotePadPlus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem FileActions;
        private System.Windows.Forms.ToolStripMenuItem Create;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Save_As;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_Z;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_X;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_C;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_V;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_A;
        private System.Windows.Forms.ToolStripMenuItem DateAndTime;
        private System.Windows.Forms.ToolStripMenuItem Format;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.RichTextBox Note1;
        private System.Windows.Forms.ToolStripMenuItem CloseTab;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLinesCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusWordsCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel statusCharsCount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_A_Context;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_X_Context;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_C_Context;
        private System.Windows.Forms.ToolStripMenuItem Ctrl_V_Context;
        private System.Windows.Forms.ToolStripMenuItem Format_Context;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ChangeAllFont;
        private System.Windows.Forms.ToolStripMenuItem SaveAllNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.ToolStripMenuItem GetBackUps;
        private System.Windows.Forms.NotifyIcon notifyIconSave;
    }
}
