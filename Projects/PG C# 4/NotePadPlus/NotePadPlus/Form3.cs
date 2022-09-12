using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NotePadPlus
{
    public partial class FormForBackups : Form
    {
        /// <summary>
        /// Private Выбранное время резервной копии в меню журналирования.
        /// </summary>
        private static DateTime s_creationDateTime;

        /// <summary>
        /// Public Выбранное время резервной копии в меню журналирования.
        /// </summary>
        public static DateTime CreationDateTime { get => s_creationDateTime; set => s_creationDateTime = value; }


        /// <summary>
        /// Форма для окна с журналированием (просмотра резервных копий.
        /// </summary>
        /// <param name="pathOfDirectory">Путь к скрытой папке с резервными копиями</param>
        public FormForBackups(string pathOfDirectory)
        {

            InitializeComponent();

            DomainUpDown.DomainUpDownItemCollection collection = DomainUpDown1.Items;

            foreach (var item in Directory.GetFiles(pathOfDirectory))
            {
                collection.Add(File.GetCreationTime(item).ToString());
            }
            DomainUpDown1.Text = "Нажмите на стрелочки";

            Color color = Properties.Settings.Default.colorOfTheme;
            BackColor = color;
            Button1.BackColor = Color.FromArgb(color.R - 40, color.G - 40, color.B - 40);
        }



        /// <summary>
        /// Метод для выбора резервной копии по вызванному событию.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void DomainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            CreationDateTime = new DateTime();
            if (DomainUpDown1.SelectedItem != null)
            {
                CreationDateTime = Convert.ToDateTime(DomainUpDown1.SelectedItem);
            }
        }


        /// <summary>
        /// Кнопка продолжить, просто закрывает окно.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Button1_Click(object sender, EventArgs e) => Close();

        private void DomainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
