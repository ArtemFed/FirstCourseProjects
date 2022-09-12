using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotePadPlus
{
    /// <summary>
    /// Форма для выбора настроек.
    /// </summary>
    public partial class FormSettings : Form
    {
        /// <summary>
        /// Private Значение положения (Вкл/выкл) для CheckBoxForStatusStrip.
        /// </summary>
        private static bool s_statusStripVisible;

        /// <summary>
        /// Public Значение положения (Вкл/выкл) для CheckBoxForStatusStrip.
        /// </summary>
        public static bool StatusStripVisible { get => s_statusStripVisible; set => s_statusStripVisible = value; }

        /// <summary>
        /// Private Значение положения (Вкл/выкл) для CheckBoxForWordWrap.
        /// </summary>
        private static bool s_rTBWordWrap;

        /// <summary>
        /// Public Значение положения (Вкл/выкл) для CheckBoxForWordWrap.
        /// </summary>
        public static bool RTBWordWrap { get => s_rTBWordWrap; set => s_rTBWordWrap = value; }

        /// <summary>
        /// Private Значение положения (Вкл/выкл) для СheckBoxForNotify.
        /// </summary>
        private static bool s_notifications;

        /// <summary>
        /// Public Значение положения (Вкл/выкл) для СheckBoxForNotify.
        /// </summary>
        public static bool Notifications { get => s_notifications; set => s_notifications = value; }


        /// <summary>
        /// Метод при запуске окна. Расставляет нужное положение кнопок.
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();

            SettingsName.BackColor = Color.Transparent;

            // CheckBox'ы
            CheckBoxForStatusStrip.Checked = StatusStripVisible;
            CheckBoxForWordWrap.Checked = RTBWordWrap;
            СheckBoxForNotify.Checked = Notifications;

            // Текстовые поля
            textBoxForPeriod.Text = Properties.Settings.Default.autoSaveInSec.ToString();
            textBoxForBackUp.Text = Properties.Settings.Default.autoBackUpMin.ToString();

            switch (Properties.Settings.Default.theme)
            {
                case 1:
                    ThemeLightRB.Checked = true;
                    break;
                case 2:
                    ThemeDarkRB.Checked = true;
                    break;
                case 3:
                    ThemeRandomRB.Checked = true;
                    Responsibility.Visible = true;
                    break;
            }

            // Меняем тему на тему основного окна.
            BackColor = Properties.Settings.Default.colorOfTheme;
        }


        /// <summary>
        /// Метод при закрытии. Для сохранения настроек
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ErrorPeriod.Visible == true)
            {
                MessageBox.Show("Вы ввели некорректные данные для интервала автосохранений в секундах! " +
                    "Значение должно быть целым числом от 10 до 1000. Пожалуйста, исправьте его.");
                e.Cancel = true;
            }

            if (ErrorPeriod2.Visible == true)
            {
                MessageBox.Show("Вы ввели некорректные данные для интервала создания в минутах! " +
                    "Значение должно быть целым числом от 1 до 60. Пожалуйста, исправьте его.");
                e.Cancel = true;
            }

            Properties.Settings.Default.statusStripVisible = StatusStripVisible;
            Properties.Settings.Default.WordWrapSet = RTBWordWrap;
            Properties.Settings.Default.notifyBool = Notifications;
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// Изменение положения ChB'a StatusStripVisible на противоположное.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        public void CheckBoxForStatusStrip_Click(object sender, EventArgs e) => StatusStripVisible = !StatusStripVisible;


        /// <summary>
        /// Изменение положения ChB'a RTBWordWrap на противоположное.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CheckBoxForWordWrap_Click(object sender, EventArgs e) => RTBWordWrap = !RTBWordWrap;


        /// <summary>
        /// Изменение положения ChB'a СheckBoxForNotify на противоположное.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void СheckBoxForNotify_Click(object sender, EventArgs e) => Notifications = !Notifications;


        /// <summary>
        /// Постоянный анализ поля с периодом на корректное значение.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TextBoxForPeriod_TextChanged(object sender, EventArgs e)
        {
            // ограничить ввод символов!
            string strPeriod = textBoxForPeriod.Text;
            if (!(int.TryParse(strPeriod, out int num) && num >= 10 && num <= 1000))
            {
                ErrorPeriod.Visible = true;
                ErrorPeriod_PNG.Visible = true;
            }
            else
            {
                ErrorPeriod.Visible = false;
                ErrorPeriod_PNG.Visible = false;
                Properties.Settings.Default.autoSaveInSec = (uint)num;
            }
        }


        /// <summary>
        /// Постоянный анализ поля с периодом журналирования.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TextBoxForBackUp_TextChanged(object sender, EventArgs e)
        {
            // ограничить ввод символов!
            string strPeriod = textBoxForBackUp.Text;
            if (!(int.TryParse(strPeriod, out int num) && num >= 1 && num <= 60))
            {
                ErrorPeriod2.Visible = true;
                ErrorPeriod2_PNG.Visible = true;
            }
            else
            {
                ErrorPeriod2.Visible = false;
                ErrorPeriod2_PNG.Visible = false;
                Properties.Settings.Default.autoBackUpMin = (uint)num;
            }
        }

        /// <summary>
        /// Метод для выбор одного варианта из трёх тем и изменение положения кнопок.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            var random = new Random();
            Color color = Color.FromArgb(255, 255, 255);
            if (radioButton.Checked)
            {
                switch (radioButton.Name)
                {
                    case "ThemeLightRB":
                        color = Color.FromArgb(255, 255, 255);
                        Properties.Settings.Default.theme = 1;
                        Responsibility.Visible = false;
                        break;
                    case "ThemeDarkRB":
                        color = Color.FromArgb(75, 75, 75);
                        Properties.Settings.Default.theme = 2;
                        Responsibility.Visible = false;
                        break;
                    case "ThemeRandomRB":
                        // Такая формула для того, чтобы генерировались только светлые цвета (пастельные)
                        color = Color.FromArgb(random.Next(127) + 127, random.Next(127) + 127, random.Next(127) + 127);
                        Properties.Settings.Default.theme = 3;
                        Responsibility.Visible = true;
                        break;
                }
            }
            Color colorOfText;
            if (color.R < 100)
                colorOfText = Color.FromArgb(0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
            else
                colorOfText = Color.FromArgb(0, 0, 0);

            ForeColor = colorOfText;
            BackColor = color;

            Properties.Settings.Default.colorOfTheme = color;
            Properties.Settings.Default.Save();
        }
    }
}
