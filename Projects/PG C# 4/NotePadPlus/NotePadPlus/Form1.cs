using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotePadPlus
{
    /// <summary>
    /// Класс главного окна приложения.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// bool Нужно ли закрыть всю программу.
        /// </summary>
        private bool closeApp = true;

        /// <summary>
        /// Текущий RichTextBox.
        /// </summary>
        private RichTextBox myNote;

        /// <summary>
        /// List с путями к файлам, содедержание которых открыто во вкладках (соответствуют по индексам  с вкладками).
        /// </summary>
        private List<string> notes = new();

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private string filePath = Properties.Settings.Default.nameOfNewDoc;

        /// <summary>
        /// List с bool Есть ли изменение у каждого файла (соответствуют по индексам с вкладками).
        /// </summary>
        private List<bool> notesChanges = new();

        /// <summary>
        /// bool Есть ли изменения в блокноте.
        /// </summary>
        private bool noteChange = false;

        /// <summary>
        /// Главный цвет темы приложения.
        /// </summary>
        private Color color;

        /// <summary>
        /// Дополнительный цвет для темы приложения.
        /// </summary>
        private Color color2;

        /// <summary>
        /// bool Вкл/выкл перенос по словам.
        /// </summary>
        private bool setWordWrap;

        /// <summary>
        /// bool Вкл/выкл уведомлений об автосохранениях и резервных копиях.
        /// </summary>
        private bool setNotifications;

        /// <summary>
        /// bool Открыта ли второй раз главная(первая) форма.
        /// </summary>
        private static bool s_mainForm1Opened = false;

        /// <summary>
        /// Текущее количество открытых окон.
        /// </summary>
        private int countOfOpenWindows = 0;

        /// <summary>
        /// Текущее количество открытых "Новых файлов".
        /// </summary>
        private int countOfNewFiles = 0;


        /// <summary>
        /// Запуск главной Формы.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            myNote = Note1;
        }


        /// <summary>
        /// Метод для получения сохраненных данных с прошлого запуска при загрузке.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

            // Выставляем значения с прошлого запуска.
            Width = Properties.Settings.Default.formWidth;
            Height = Properties.Settings.Default.formHeight;
            setWordWrap = Properties.Settings.Default.WordWrapSet;

            countOfOpenWindows++;


            // Открываем старые существующие вкладки, если после этого пусто, то запрашиваем новый файл
            OpenOldTab();
            CreateFirstTab();

            // Удаление первой (всегда пустой) вкладки.
            if (tabControl.TabPages.Count != 1)
            {
                tabControl.Controls.RemoveAt(0);
            }

            // Обновляем все поля для CheckBox'ов в Окне Настроек.
            FormSettings.StatusStripVisible = Properties.Settings.Default.statusStripVisible;
            FormSettings.RTBWordWrap = setWordWrap;
            FormSettings.Notifications = Properties.Settings.Default.notifyBool;

            ChangeColorTheme();

            // Запускаем таймеры для автосохранения и журналирования с заданным периодом.
            Timer1.Interval = (int)Properties.Settings.Default.autoSaveInSec * 1000;
            Timer1.Start();

            Timer2.Interval = (int)Properties.Settings.Default.autoBackUpMin * 60000;
            Timer2.Start();

            // Скрыть папку с резервными копиями.
            DirectoryInfo infoBackUps = Directory.CreateDirectory("backups");
            infoBackUps.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }


        /// <summary>
        /// Метод для открыия старых вкладок.
        /// </summary>
        private void OpenOldTab()
        {
            if (Properties.Settings.Default.historyOfOpenFiles != "" || !s_mainForm1Opened)
            {
                // Были открытые вкладки, поэтому достаём их из памяти проекта и открываем.
                notes = Properties.Settings.Default.historyOfOpenFiles.Split(@"|").ToList();
                notes.RemoveAt(notes.Count - 1);
                int fixedNoteCount = notes.Count;
                for (var i = 0; i < fixedNoteCount; i++)
                {
                    try
                    {
                        filePath = notes[0];
                        notes.RemoveAt(0);
                        if (File.Exists(filePath))
                            CreateTabAndRTBox(filePath);
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка при добавлении ранее открытой вкладки", "Ошибка!");
                    }
                }
            }

        }



        /// <summary>
        /// Метод для отркытия файла путём запроса к Пользователю, если нет вкладок.
        /// </summary>
        private void CreateFirstTab()
        {
            if (notes.Count == 0)
            {
                try
                {
                    bool flag = false;
                    do
                    {
                        flag = false;
                        DialogResult message = MessageBox.Show($"Пожалуйста, в начале работы выберите или" +
                            $" создайте файл в следующем окне.", $"Начало работы с " +
                            $"{Properties.Settings.Default.programmName}", MessageBoxButtons.OKCancel);
                        if (message == DialogResult.OK)
                        {
                            OpenFile();
                            if (notes.Count == 0)
                            {
                                // Если Пользователь не выбрал файл.
                                MessageBox.Show("Для работы с " +
                                    $"{Properties.Settings.Default.programmName} вы обязаны выбрать файл.");
                                flag = true;
                                continue;
                            }
                        }
                        else if (message == DialogResult.Cancel)
                        {
                            throw new Exception();
                        }
                    }
                    while (flag);
                }
                catch
                {
                    MessageBox.Show("Вы не выбрали файл или он неверен. Работать не с чем, поэтому окно программы закроется.");
                    Close();
                }
            }
        }

        /// <summary>
        /// Метод, который вызывается при закрытии окна.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Сохраняем все окна, которые захочет пользователь.
            Exit_Click();
            if (!closeApp)
            {
                closeApp = true;
                e.Cancel = true;
                return;
            }

            s_mainForm1Opened = false;

            string strForHistoryOfOpenFiles = "";
            try
            {
                // Удаляем одинаковые вкладки, чтобы избежать дублирования.
                var NotesNew = notes.Distinct();

                foreach (var item in NotesNew)
                {
                    strForHistoryOfOpenFiles += item.ToString() + "|";
                }
            }
            catch
            {

            }
            // Сохраняем настройки, которые задал пользователь
            Properties.Settings.Default.formWidth = Width;
            Properties.Settings.Default.formHeight = Height;

            Properties.Settings.Default.statusStripVisible = statusStrip.Visible;
            Properties.Settings.Default.historyOfOpenFiles = strForHistoryOfOpenFiles;
            Properties.Settings.Default.Save();

            countOfOpenWindows--;
        }


        /// <summary>
        /// Метод для открытия окна настроек.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Settings_Click(object sender, EventArgs e)
        {
            var formSettings = new FormSettings();
            formSettings.ShowDialog();

            // Изменить всё, что было выбрано в настройках.
            ViewStatusStrip1_Click();
            SetWordWrap_Click();
            Notifucations_Click();
            ChangeColorTheme();

            Timer1.Interval = (int)Properties.Settings.Default.autoSaveInSec * 1000;
            Timer2.Interval = (int)Properties.Settings.Default.autoBackUpMin * 60000;
        }


        /// <summary>
        /// Метод для отображения или скрытия меню со статусом 
        /// </summary>
        private void ViewStatusStrip1_Click() => statusStrip.Visible = FormSettings.StatusStripVisible;

        /// <summary>
        /// Метод для включения или выключения переноса текста
        /// </summary>
        private void SetWordWrap_Click()
        {
            setWordWrap = FormSettings.RTBWordWrap;

            for (var i = 0; i < notes.Count; i++)
            {
                RichTextBox richTextBoxInTab = (RichTextBox)tabControl.TabPages[i].Controls[0];
                richTextBoxInTab.WordWrap = setWordWrap;
            }
        }


        /// <summary>
        /// Метод для отображения или скрытия меню со статусом 
        /// </summary>
        private void Notifucations_Click() => setNotifications = FormSettings.Notifications;


        /// <summary>
        /// Метод для изменения темы приложения.
        /// </summary>
        private void ChangeColorTheme()
        {
            color = Properties.Settings.Default.colorOfTheme;
            color2 = Color.FromArgb(color.R - 40, color.G - 40, color.B - 40);
            Color colorOfText;

            if (color2.R < 60)
            {
                // Берём обратный цвет от фона.
                colorOfText = Color.FromArgb(0xFF - color2.R, 0xFF - color2.G, 0xFF - color2.B);
            }
            else
            {
                colorOfText = Color.FromArgb(0, 0, 0);
            }

            BackColor = color2;
            statusStrip.BackColor = color;
            menuStrip1.BackColor = color;
            tabControl.BackColor = color;

            statusStrip.ForeColor = colorOfText;
            menuStrip1.ForeColor = colorOfText;

            for (var i = 0; i < notes.Count; i++)
            {
                if (color2.R < 60)
                {
                    tabControl.TabPages[i].Controls[0].BackColor = Color.FromArgb(color.R + 40, color.G + 40, color.B + 40); ;
                }
                else
                {
                    tabControl.TabPages[i].Controls[0].BackColor = color;
                }
            }
        }


        /// <summary>
        /// Метод для создания файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Create_Click(object sender, EventArgs e) => CreateFile();


        /// <summary>
        /// Метод для открытия файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Open_Click(object sender, EventArgs e) => OpenFile();


        /// <summary>
        /// Метод для добавления новой вкладки, а в неё RichTextBox.
        /// </summary>
        /// <param name="pathToFile">Путь к файлу или его имя</param>
        private void CreateTabAndRTBox(string pathToFile)
        {
            if (tabControl.TabPages.Count <= 9)
            {
                try
                {
                    string title;
                    if (File.Exists(pathToFile))
                    {

                        var directoryInfo = new FileInfo(pathToFile);
                        if (!(directoryInfo.Length <= 128 * 1024 * 1024))
                        {
                            MessageBox.Show("Файл имеет слишком большой размер, программа не будет его открывать!");
                            return;
                        }
                        else
                        {
                            title = Path.GetFileName(pathToFile);
                        }

                    }
                    else
                    {
                        title = "Новый файл " + ++countOfNewFiles;
                    }

                    AddBoxOnTab(title, pathToFile);
                }
                catch
                {
                    MessageBox.Show("Программа не может открыть файл! Возможно у неё нет доступа к нему.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Открыто максимальное количество вкладок - 10, " +
                    "пожалуйста, закройте ненужные и попробуйте снова", "Блокнот");
            }
        }


        /// <summary>
        /// Метод для добавления новой вкладки, а в неё RichTextBox.
        /// </summary>
        /// <param name="pathToFile">Путь к файлу или его имя</param>
        /// <param name="title">Имя вкладки</param>
        private void AddBoxOnTab(string title, string pathToFile)
        {
            var myTabPage = new TabPage(title);
            // Создаём для новой вкладки RichTextBox.
            var textBoxInTab = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ContextMenuStrip = contextMenuStrip1,
                WordWrap = setWordWrap
            };

            Color color = Properties.Settings.Default.colorOfTheme;
            if (color.R < 60)
                textBoxInTab.BackColor = Color.FromArgb(color.R + 40, color.G + 40, color.B + 40);
            else
                textBoxInTab.BackColor = color;
            try
            {
                // Загружаем текст из файла и Открываю новую вкладку.
                LoadTextFromFile(ref textBoxInTab, pathToFile);
                textBoxInTab.TextChanged += new EventHandler(MyNote_TextChanged);

                myTabPage.Controls.Add(textBoxInTab);
                tabControl.TabPages.Add(myTabPage);
                tabControl.SelectTab(myTabPage);
                myNote = textBoxInTab;

                // Изменяем строку состояния.
                myNote = (RichTextBox)tabControl.SelectedTab.Controls[0];
                StatusAnalize(myNote);
                notes.Add(pathToFile);
                notesChanges.Add(false);
                CheckChanges();
                // Сохраняем данные.
                filePath = pathToFile;
                noteChange = false;
            }
            catch
            {
                MessageBox.Show("Программа не может открыть файл! Возможно у неё нет доступа к нему.");
            }
        }


        /// <summary>
        /// Метод для загрузки текста из файла, если он есть.
        /// </summary>
        /// <param name="richTextBox">RichTextBox, в который нужно загрузить текст из файла</param>
        /// <param name="pathToFile">Путь к фалйлу, текст из которого нужно загрузить в RichTextBox</param>
        private static void LoadTextFromFile(ref RichTextBox richTextBox, string pathToFile)
        {
            try
            {
                if (File.Exists(pathToFile))
                {
                    if (Path.GetExtension(pathToFile).ToLower() == ".txt")
                    {
                        var file = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
                        var reader = new StreamReader(file, Encoding.Default);
                        richTextBox.Text = reader.ReadToEnd();
                        reader.Close();
                        richTextBox.Font = Properties.Settings.Default.textFont;
                    }
                    else if (Path.GetExtension(pathToFile).ToLower() == ".rtf")
                    {
                        richTextBox.LoadFile(pathToFile, RichTextBoxStreamType.RichText);
                    }
                    else if (Path.GetExtension(pathToFile).ToLower() == ".cs"
                        || Path.GetExtension(pathToFile).ToLower() == ".csproj"
                        || Path.GetExtension(pathToFile).ToLower() == ".sln")
                    {
                        var file = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
                        var reader = new StreamReader(file, Encoding.Default);
                        richTextBox.Text = reader.ReadToEnd();
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неизвестный тип файла, возможен некорректный вывод данных!");
                        var file = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
                        var reader = new StreamReader(file, Encoding.Default);
                        richTextBox.Text = reader.ReadToEnd();
                        reader.Close();
                        richTextBox.Font = Properties.Settings.Default.textFont;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Программа не смогла прочитать файл!");
            }
        }


        /// <summary>
        /// Метод для удаления пояснительной звёздочки об несохранённых изменениях, если она не нужна.
        /// </summary>
        private void CheckChanges()
        {
            for (var i = 0; i < notesChanges.Count; i++)
            {
                if (!notesChanges[i])
                {
                    if (tabControl.SelectedTab.Text[0] == '*')
                    {
                        tabControl.SelectedTab.Text = tabControl.SelectedTab.Text[1..];
                    }
                }
            }
        }


        /// <summary>
        /// Метод, выполняющийся при закрытии окна и отвечающий за сохранение всего.
        /// </summary>
        private void Exit_Click()
        {
            if (notesChanges.IndexOf(true) != -1)
            {
                DialogResult message = MessageBox.Show("Хотите сохранить изменения в файлах перед закрытием приложения?",
                    "Последний шанс...", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {
                    for (var i = 0; i < notes.Count; i++)
                    {
                        try
                        {
                            if (notesChanges[i] == true)
                            {
                                filePath = notes[i];
                                DialogResult message2 = MessageBox.Show($"Сохранить изменения в {filePath}?",
                                    "Последний шанс...", MessageBoxButtons.YesNo);
                                if (message2 == DialogResult.Yes)
                                {
                                    noteChange = notesChanges[i];
                                    myNote = (RichTextBox)tabControl.TabPages[i].Controls[0];
                                    if (File.Exists(filePath))
                                    {
                                        SaveFile(myNote, ref noteChange, filePath);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Файл {filePath} некуда сохранить, пожалуйста, выберите путь.");
                                        SaveAsFile(ref myNote, ref noteChange, ref filePath);
                                        notes[i] = filePath;
                                        tabControl.TabPages[i].Text = Path.GetFileName(filePath);
                                    }
                                    if (tabControl.TabPages[i].Text[0] == '*' && !noteChange)
                                        tabControl.TabPages[i].Text = tabControl.TabPages[i].Text[1..];
                                    notesChanges[i] = noteChange;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show($"Произошла ошибка при сохранении \"{filePath}\"!");
                        }
                    }
                }
                else if (message == DialogResult.No)
                {
                    closeApp = true;
                }
                else if (message == DialogResult.Cancel)
                {
                    closeApp = false;
                }
            }
            else
            {
                closeApp = true;
            }
        }


        /// <summary>
        /// Метод для закрытия вкладки.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CloseTab_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.TabCount > 1)
                {
                    if (notesChanges[tabControl.SelectedIndex] == true)
                    {
                        DialogResult message3 = MessageBox.Show("" +
                            $"Сохранить изменения в {notes[tabControl.SelectedIndex]}?",
                            "Последний шанс...", MessageBoxButtons.YesNo);

                        if (message3 == DialogResult.Yes)
                        {
                            Save_Click(sender, e);
                        }
                    }

                    notes.RemoveAt(tabControl.SelectedIndex);
                    notesChanges.RemoveAt(tabControl.SelectedIndex);
                    tabControl.Controls.RemoveAt(tabControl.SelectedIndex);
                }
                else
                {
                    DialogResult messege3 = MessageBox.Show("" +
                        "Закрытие последней вкладки повлечёт за собой закрытие программы! " +
                        "Вы хотите её закрыть?", "Блокнот", MessageBoxButtons.OKCancel);

                    if (messege3 == DialogResult.OK)
                    {
                        notes.Clear();
                        notesChanges.Clear();
                        Properties.Settings.Default.historyOfOpenFiles = "";
                        this.Close();
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Метод при нажатии кнопки "Выход", он закрывает приложение
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Exit_Click(object sender, EventArgs e) => Application.Exit();


        /// <summary>
        /// Метод, отвечающий за изменение меню со статусом по строкам, словам и символам.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MyNote_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab != null)
                {
                    notesChanges[tabControl.SelectedIndex] = true;

                    if (tabControl.SelectedTab.Text[0] != '*')
                    {
                        tabControl.SelectedTab.Text = "*" + tabControl.SelectedTab.Text;
                    }

                    myNote = (RichTextBox)tabControl.SelectedTab.Controls[0];
                    StatusAnalize(myNote);
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Метод, вызывающийся при выборе вкладки, изменяет меню со статусом и текущие данные.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab != null)
                {
                    myNote = (RichTextBox)tabControl.SelectedTab.Controls[0];
                    filePath = notes[tabControl.SelectedIndex];
                    StatusAnalize(myNote);
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Меню со статусом по строкам, словам и символам.
        /// </summary>
        /// <param name="myNote">Текущий блокнот</param>
        private void StatusAnalize(RichTextBox myNote)
        {
            try
            {
                string text = myNote.Text;
                // Количество строк в тексте
                statusLinesCount.Text = myNote.Lines.Count().ToString();
                // Количество слов в тексте
                statusWordsCount.Text = text.Split(new char[] {
                ' ', '\t', '\n', '\r', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-',
                '_', '+', '=', '[', '{', ']', '}', '/', '\\', '|', '"', ':', ';', '.', ',', '>', '<' },
                    StringSplitOptions.RemoveEmptyEntries).Length.ToString();
                // Количество символов с пробелами
                statusCharsCount.Text = text.ToCharArray().Length.ToString();
            }
            catch
            {
            }
        }


        /// <summary>
        /// Открытие нового окна для создание документа в нём.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (countOfOpenWindows >= Properties.Settings.Default.maxOfWindowsCount)
                {
                    MessageBox.Show("Открыто максимальное количество новых окон - 5, пожалуйста, пользуйтесь вкладками", "Блокнот");
                }
                else
                {
                    s_mainForm1Opened = true;
                    var newMainForm = new FormMain();
                    newMainForm.Show();
                }
            }
            catch
            {
            }
        }



        /// <summary>
        /// Метод для форматирования фрагмента текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Format_Click(object sender, EventArgs e)
        {
            var fontDialog1 = new FontDialog
            {
                ShowColor = true,
                Font = myNote.SelectionFont,
                Color = myNote.SelectionColor
            };

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                myNote.SelectionFont = fontDialog1.Font;
                myNote.SelectionColor = fontDialog1.Color;
            }

        }


        /// <summary>
        /// Метод для выбор основного стиля текста у .txt файлов.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ChangeAllFont_Click(object sender, EventArgs e)
        {
            try
            {
                var fontDialog2 = new FontDialog
                {
                    Font = myNote.Font
                };

                if (fontDialog2.ShowDialog() != DialogResult.Cancel)
                {
                    for (var i = 0; i < notes.Count; i++)
                    {
                        if (Path.GetExtension(notes[i]).ToLower() != ".rtf"
                            && Path.GetExtension(notes[i]).ToLower() != ".cs"
                            && Path.GetExtension(notes[i]).ToLower() != ".csproj"
                            && Path.GetExtension(notes[i]).ToLower() != ".sln")
                        {
                            RichTextBox richTextBox = (RichTextBox)tabControl.TabPages[i].Controls[0];
                            richTextBox.Font = fontDialog2.Font;
                        }
                    }

                    Properties.Settings.Default.textFont = fontDialog2.Font;
                    Properties.Settings.Default.Save();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при изменении шрифта!");
            }
        }


        /// <summary>
        /// Метод для отмены действия с текстом.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Ctrl_Z_Click(object sender, EventArgs e) => myNote.Undo();


        /// <summary>
        /// Метод для повтора действия с текстом.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Ctrl_Shift_Z_Click(object sender, EventArgs e) => myNote.Redo();


        /// <summary>
        /// Метод для вырезания фрагмента текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Ctrl_X_Click(object sender, EventArgs e)
        {
            if (myNote.SelectionLength > 0)
            {
                myNote.Cut();
            }
        }


        /// <summary>
        /// Метод для сохранения фрагмента текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Ctrl_C_Click(object sender, EventArgs e)
        {
            if (myNote.SelectionLength > 0)
            {
                myNote.Copy();
            }
        }


        /// <summary>
        /// Метод для добавления сохранённого фрагмента текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Ctrl_V_Click(object sender, EventArgs e) => myNote.Paste();


        /// <summary>
        /// Метод для удаления сохранённого фрагмента текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Delete_Click(object sender, EventArgs e)
        {
            if (myNote.SelectionLength > 0)
            {
                myNote.SelectedText = "";
            }
        }


        /// <summary>
        /// Метод для выделения всего текста в одном блокноте.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Ctrl_A_Click(object sender, EventArgs e) => myNote.SelectAll();


        /// <summary>
        /// Метод для добавления текущей даты и времени на блокнот.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void DateAndTime_Click(object sender, EventArgs e)
        {
            myNote.SelectedText = Environment.NewLine + Convert.ToString(DateTime.Now);
        }



        /// <summary>
        /// Метод для сохранения всех блокнотов.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void SaveAllNotes_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < notes.Count; i++)
            {
                try
                {
                    if (notesChanges[i] == true)
                    {
                        noteChange = notesChanges[i];
                        filePath = notes[i];
                        myNote = (RichTextBox)tabControl.TabPages[i].Controls[0];

                        if (File.Exists(notes[tabControl.SelectedIndex]))
                        {
                            SaveFile(myNote, ref noteChange, filePath);
                        }
                        else
                        {
                            MessageBox.Show($"Файл \"{filePath}\" некуда сохранить, пожалуйста, выберите путь.");
                            SaveAsFile(ref myNote, ref noteChange, ref filePath);
                            notes[tabControl.SelectedIndex] = filePath;
                        }

                        notesChanges[i] = noteChange;
                        NameAfterSave();
                    }
                }
                catch
                {
                    MessageBox.Show($"Произошла ошибка при сохранении файла {notes[i]} !");
                }
            }
        }


        /// <summary>
        /// Метод для вызова сохранения текущего блокнота.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                noteChange = notesChanges[tabControl.SelectedIndex];
                if (File.Exists(notes[tabControl.SelectedIndex]))
                {
                    SaveFile(myNote, ref noteChange, filePath);
                }
                else
                {
                    MessageBox.Show($"Файл \"{filePath}\" некуда сохранить, пожалуйста, выберите путь.");
                    SaveAsFile(ref myNote, ref noteChange, ref filePath);
                    notes[tabControl.SelectedIndex] = filePath;
                }

                notesChanges[tabControl.SelectedIndex] = noteChange;
                NameAfterSave();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении файла!");
            }
        }


        /// <summary>
        /// Метод для вызова сохранения текущего блокнота в новый файл.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Save_As_Click(object sender, EventArgs e)
        {
            try
            {
                noteChange = notesChanges[tabControl.SelectedIndex];

                SaveAsFile(ref myNote, ref noteChange, ref filePath);

                notesChanges[tabControl.SelectedIndex] = noteChange;
                notes[tabControl.SelectedIndex] = filePath;

                NameAfterSave();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении файла!");
            }
        }


        /// <summary>
        /// Удалить метку (*) в названии, если несохраненных изменений нет.
        /// </summary>
        private void NameAfterSave()
        {
            if (notesChanges[tabControl.SelectedIndex])
            {
                if (tabControl.SelectedTab.Text[0] != '*')
                {
                    tabControl.SelectedTab.Text = "*" + Path.GetFileName(filePath);
                }
            }
            else
            {
                tabControl.TabPages[tabControl.SelectedIndex].Text = Path.GetFileName(filePath);
            }
        }


        /// <summary>
        /// Метод для открытия файла из проводника.
        /// </summary>
        private void OpenFile()
        {
            try
            {
                // Запрашиваю файл с помощью Windows с параметрами Title и  Filter
                var openDocument = new OpenFileDialog()
                {
                    Title = "Открыть текстовый документ",
                    Filter = "Текстовые файлы (*.txt)|*.txt" +
                    "| Расширенные текстовые файлы (*.rtf)|*.rtf" +
                    "| Файлы C# (*.cs)|*.cs" +
                    "| Все файлы (*.*)|*.*"
                };

                if (openDocument.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openDocument.FileName;
                    CreateTabAndRTBox(fileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при открытии файла!", "Ошибка!");
            }

        }


        /// <summary>
        /// Метод для Создания фкладки с новым несуществующим файлом.
        /// </summary>
        private void CreateFile()
        {
            try
            {
                CreateTabAndRTBox("Новый файл");
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при создании файла!", "Ошибка!");
            }
        }


        /// <summary>
        /// Метод для сохранения текущего блокнота.
        /// </summary>
        /// <param name="MyNote">Текущий блокнот.</param>
        /// <param name="NoteChange">Текущий статус изменения в блокноте.</param>
        /// <param name="filePath">Текущий путь к файлу в блокноту.</param>
        private static void SaveFile(RichTextBox MyNote, ref bool NoteChange, string filePath)
        {
            try
            {
                if (Path.GetExtension(filePath).ToLower() == ".txt")
                {
                    File.WriteAllText(filePath, MyNote.Text);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".rtf")
                {
                    MyNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".cs"
                    || Path.GetExtension(filePath).ToLower() == ".csproj"
                    || Path.GetExtension(filePath).ToLower() == ".sln")
                {
                    File.WriteAllText(filePath, MyNote.Text);
                }
                else
                {
                    MessageBox.Show($"Неизвестный тип файла \"{filePath}\", возможно некорректное сохранение данных!");
                    File.WriteAllText(filePath, MyNote.Text);
                }
                NoteChange = false;

            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при сохранения файла!", "Ошибка!");
            }
        }


        /// <summary>
        /// Метод для сохранения текущего блокнота в новый файл.
        /// </summary>
        /// <param name="myNote">Текущий блокнот.</param>
        /// <param name="noteChange">Текущий статус изменения в блокноте.</param>
        /// <param name="filePath">Текущий путь к файлу в блокноту.</param>
        private static void SaveAsFile(ref RichTextBox myNote, ref bool noteChange, ref string filePath)
        {
            try
            {
                var saveAsDocument = new SaveFileDialog()
                {
                    Title = "Сохранить документ как...",
                    FileName = "Текстовый документ",
                    Filter = "Текстовые файлы (*.txt)|*.txt" +
                    "| Расширенные текстовые файлы (*.rtf)|*.rtf" +
                    "| Файлы C# (*.cs)|*.cs" +
                    "| Все файлы (*.*)|*.*"
                };

                if (saveAsDocument.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveAsDocument.FileName;
                    if (Path.GetExtension(filePath).ToLower() == ".txt")
                    {
                        File.WriteAllText(saveAsDocument.FileName, myNote.Text);
                    }
                    else if (Path.GetExtension(filePath).ToLower() == ".rtf")
                    {
                        myNote.SaveFile(saveAsDocument.FileName, RichTextBoxStreamType.RichText);
                    }
                    else if ((Path.GetExtension(filePath).ToLower() == ".cs"
                            || Path.GetExtension(filePath).ToLower() == ".csproj"
                            || Path.GetExtension(filePath).ToLower() == ".sln"))
                    {
                        File.WriteAllText(saveAsDocument.FileName, myNote.Text);
                    }
                    else
                    {
                        MessageBox.Show($"Неизвестный тип файла \"{filePath}\", возможно некорректное сохранение данных!");
                        File.WriteAllText(saveAsDocument.FileName, myNote.Text);
                    }
                    noteChange = false;
                }
                else
                {
                    noteChange = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при сохранении файла без существующего пути!", "Ошибка");
            }
        }


        /// <summary>
        /// Метод для автосохранения всех файлов.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (notesChanges.IndexOf(true) != -1)
            {
                for (var i = 0; i < notes.Count; i++)
                {
                    try
                    {
                        myNote = (RichTextBox)tabControl.TabPages[i].Controls[0];
                        if (File.Exists(filePath))
                        {
                            noteChange = notesChanges[i];
                            SaveFile(myNote, ref noteChange, notes[i]);
                            notesChanges[i] = noteChange;

                            if (tabControl.TabPages[i].Text[0] == '*' && !noteChange)
                            {
                                tabControl.TabPages[i].Text = tabControl.TabPages[i].Text[1..];
                            }
                        }
                    }
                    catch
                    {

                    }
                }

                // Кинуть уведомление о автоматическом сохранении.
                if (setNotifications)
                {
                    // Устанавливаем зголовк и текст уведомления.
                    notifyIconSave.BalloonTipText = "Произошло автоматическое сохранение";

                    // Отображаем уведомление 1 секунду
                    notifyIconSave.ShowBalloonTip(1);
                }
            }
        }


        /// <summary>
        /// Метод для создания резервной копии всех файлов.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < notes.Count; i++)
            {
                try
                {
                    string DirectoryAndFilePath, fileNameWithoutExt, filePath = notes[i];
                    fileNameWithoutExt = Path.GetFileName(filePath)[0..^4];
                    if (fileNameWithoutExt.Length <= 150)
                    {
                        RichTextBox MyNote = (RichTextBox)tabControl.TabPages[i].Controls[0];
                        string nameOfBackUp = fileNameWithoutExt + "-" +
                            DateTime.Now.ToUniversalTime().ToString("dd.MM.yyyy-HH.mm.ss") +
                            "." + DateTime.Now.Ticks.ToString()[^3..];
                        // Если нет папки, то создаём.
                        if (!Directory.Exists($"backups\\{fileNameWithoutExt}"))
                            Directory.CreateDirectory($"backups\\{fileNameWithoutExt}");
                        DirectoryAndFilePath = $"backups\\{fileNameWithoutExt}" +
                            $"\\{nameOfBackUp + Path.GetExtension(notes[i])}";
                        // Если количество резервных копий достигло лимита, то находим самый старый и удалаяем его.
                        if (Directory.GetFiles($"backups\\{fileNameWithoutExt}").Length
                            == Properties.Settings.Default.maxOfBackUpsCount)
                        {
                            var timeOfCreate = new List<DateTime>();
                            foreach (var file in Directory.GetFiles($"backups\\{fileNameWithoutExt}"))
                                timeOfCreate.Add(File.GetCreationTime(file));
                            int index = timeOfCreate.IndexOf(timeOfCreate.Min());
                            File.Delete(Directory.GetFiles($"backups\\{fileNameWithoutExt}")[index]);
                        }
                        if (Path.GetExtension(filePath).ToLower() == ".rtf")
                            MyNote.SaveFile(DirectoryAndFilePath, RichTextBoxStreamType.RichText);
                        else
                            File.WriteAllText(DirectoryAndFilePath, MyNote.Text);
                    }
                }
                catch { }
            }
            // Кидаем уведомление о резервном копировании.
            if (setNotifications)
            {
                // Устанавливаем зголовк и текст уведомления.
                notifyIconSave.BalloonTipText = "Произошло резервное копирование";
                // Отображаем уведомление 1 секунду
                notifyIconSave.ShowBalloonTip(1);
            }
        }


        /// <summary>
        /// Метод для получения резервной копии текущего файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void GetBackUps_Click(object sender, EventArgs e)
        {
            try
            {
                string pathOfDirectory = $"backups\\{Path.GetFileName(notes[tabControl.SelectedIndex])[0..^4]}";
                if (!Directory.Exists(pathOfDirectory))
                {
                    MessageBox.Show("Резервных копий не обнаружено!", "Журналирование");
                    return;
                }
                else
                {
                    string[] allFiles = Directory.GetFiles(pathOfDirectory);
                    if (allFiles.Length == 0)
                    {
                        MessageBox.Show("Резервных копий не обнаружено!", "Журналирование");
                        return;
                    }
                    else
                    {
                        var form3 = new FormForBackups(pathOfDirectory);
                        DialogResult dialogOfBackupsResult = form3.ShowDialog();

                        if (dialogOfBackupsResult == DialogResult.OK)
                        {
                            DateTime dateTimeOfBackUp = FormForBackups.CreationDateTime;
                            foreach (var file in allFiles)
                            {
                                if (File.GetCreationTime(file).ToString() == dateTimeOfBackUp.ToString())
                                {
                                    CreateTabAndRTBox(file);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при открытии резервных копий.");
            }
        }
    }
}
