using System;
using System.IO;
using System.Text;


namespace FileManager
{
    class Program
    {
        /// <summary>
        /// Текущий путь диска.
        /// </summary>
        static string CurrentDisk = Directory.GetCurrentDirectory();

        /// <summary>
        /// Текущий путь к папке.
        /// </summary>
        static string CurrentFolder = Directory.GetCurrentDirectory();

        /// <summary>
        /// Текущий путь (также путь к файлу).
        /// </summary>
        static string CurrentFile = Directory.GetCurrentDirectory();


        /// <summary>
        /// Основной метод, объединяет информацию полученную с помощью других методов.
        /// </summary>
        public static void Main()
        {
            ConsoleKey buttonPressEnd;
            do
            {
                Console.Clear();
                try
                { Console.OutputEncoding = Encoding.UTF8; }
                catch
                {
                    Console.WriteLine("" +
                        "\n\t Не удалось изменить кодировку текста в консоли. " +
                        "\n\t Возможен неккоректный вывод текста!");
                }

                Console.WriteLine("\n\t\t\t Добро пожаловать в Файловый Менеджер!\n" +
                    "\n\t Перед выполнением некоторых заданий (4 - 8, 11) необходимо выбрать файл." +
                    "\n\t Когда консоль будет перегружена, она будет очищена (каждые 4 задания).");
                GetTask();

                Console.WriteLine("\n\n\t Вы уверены, что хотите выйти? Нажмите \"Escape\" для выхода.");
                buttonPressEnd = Console.ReadKey(true).Key;

            } while (buttonPressEnd != ConsoleKey.Escape);
            Console.WriteLine("\n\n\t\t Файловый менеджер закончил работу.");
        }   // Конец метода "Main".


        /// <summary>
        /// Получение задания от Пользователя и выполнение его.
        /// </summary>
        static void GetTask()
        {
            bool flag1 = false, flagIncorrect = false;

            Console.WriteLine("\n\t Что Файловый менеджер должен сделать для вас?:\n");
            TextAndRule(1);

            int countOfTask = 1;
            do
            {
                if (countOfTask % 4 == 0)
                {
                    Console.WriteLine("\n\t Нажмите любую кнопку для продолжения. (Консоль будет очищена!)");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("\n\t Что Файловый менеджер должен сделать для вас?\n");
                    TextAndRule(1);
                }
                if (!flagIncorrect)
                {
                    if (countOfTask != 1)
                    { Console.WriteLine("\n\t Что Файловый менеджер должен сделать для вас?\n"); }
                }
                Console.WriteLine($"\t Текущая директория: {CurrentFile}");
                countOfTask++;
                Console.Write("\n\t Введите значение соответствующее номеру задания: ");
                flagIncorrect = false;
                try
                {
                    DistributionByTasks(ref flag1, ref flagIncorrect);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("" +
                        "\n\t Произошла ошибка! Не удалось получить доступ к файлу или каталогу! " +
                        "\n\t Попробуйте изменить доступность у файла.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("" +
                        "\n\t Произошла ошибка! Диск/Папка/Файл не был найден! " +
                        "\n\t Попробуйте изменить директорию.");
                }
                catch (DriveNotFoundException)
                {
                    Console.WriteLine("" +
                        "\n\t Произошла ошибка! Диск не был найден! " +
                        "\n\t Попробуйте изменить директорию.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("" +
                        "\n\t Произошла ошибка! Не удалось получить доступ! " +
                        "\n\t Попробуйте изменить параметры доступности.");
                }
                catch (System.Security.SecurityException)
                {
                    Console.WriteLine("" +
                        "\n\t Произошла ошибка! Антивирус не даёт доступ! " +
                        "\n\t Попробуйте изменить директорию.");
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("" +
                       "\n\t Произошла неизвестная ошибка! " +
                       "\n\t Попробуйте ещё раз.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("" +
                        "\n\t Не удалось прочитать Диск/Папку/Файл! " +
                        "\n\t Проверьте его и попробуйте ещё раз.\n");
                }
            } while (!flag1);

        }  // Конец метода "TextRules".


        /// <summary>
        /// Метод для распределения по заданиям
        /// </summary>
        /// <param name="flag1">Флаг: True - Завершить, False - Продолжить</param>
        /// <param name="flagIncorrect">Флаг: True - Данные некоректны, False - Иначе</param>
        private static void DistributionByTasks(ref bool flag1, ref bool flagIncorrect)
        {
            string numOfTask = Console.ReadLine();
            switch (numOfTask)
            {
                case "-":
                    GetUpOnTheWay();
                    break;
                case "0":
                    flag1 = true;
                    break;
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2(CurrentFolder);
                    break;
                case "3":
                    Task3(CurrentFolder);
                    break;
                case "4":
                    if (Path.GetFileName(CurrentFile) != "")
                    { Task4(CurrentFile); }
                    else Console.WriteLine("\n\t Вы должны выбрать файл перед выполнением этого задания!");
                    break;
                case "5":
                    if (Path.GetFileName(CurrentFile) != "")
                    { Task5(CurrentFile); }
                    else Console.WriteLine("\n\t Вы должны выбрать файл перед выполнением этого задания!");
                    break;
                case "6":
                    if (Path.GetFileName(CurrentFile) != "")
                    { Task6(CurrentFile); }
                    else Console.WriteLine("\n\t Вы должны выбрать файл перед выполнением этого задания!");
                    break;
                case "7":
                    if (Path.GetFileName(CurrentFile) != "")
                    { Task7(CurrentFile); }
                    else Console.WriteLine("\n\t Вы должны выбрать файл перед выполнением этого задания!");
                    break;
                case "8":
                    if (Path.GetFileName(CurrentFile) != "")
                    { Task8(CurrentFile); }
                    else Console.WriteLine("\n\t Вы должны выбрать файл перед выполнением этого задания!");
                    break;
                case "9":
                    Task9(CurrentFolder);
                    break;
                case "10":
                    Task10(CurrentFolder);
                    break;
                case "11":
                    if (Path.GetFileName(CurrentFile) != "")
                    { Task11(CurrentFile); }
                    else Console.WriteLine("\n\t Вы должны выбрать файл перед выполнением этого задания!");
                    break;
                case "12":
                    ChangePath();
                    break;
                default:
                    Console.WriteLine("\n\t\t Вы ввели неверное значение, попробуйте ещё раз!");
                    flagIncorrect = true;
                    break;
            }
        }   // Конец метода DistributionByTasks.


        /// <summary>
        /// Метода для изменения теущего пути на путь к проекту.
        /// </summary>
        private static void ChangePath()
        {
            Console.WriteLine("\n\t Вы выбрали текущим путём папку с проектом.");
            CurrentDisk = Directory.GetCurrentDirectory();
            CurrentFolder = Directory.GetCurrentDirectory();
            CurrentFile = Directory.GetCurrentDirectory();
        }


        /// <summary>
        /// Метода для изменения теущего пути на путь к проекту.
        /// </summary>
        private static void GetUpOnTheWay()
        {
            string[] path = CurrentFile.Split("\\");
            if (path.Length == 1 || CurrentFile.Length <= 3)
            { Console.WriteLine("\n\t Нет родительской директории.\n"); }
            else
            {
                CurrentFolder = CurrentFile.Replace(@$"\{path[path.Length - 1]}", "");
                CurrentFile = CurrentFile.Replace(@$"\{path[path.Length - 1]}", "");
                Console.WriteLine("\n\t Вы успешно переместились в родительскую директорию!\n");
            }
            if (!CurrentFile.Contains('\\'))
            {
                CurrentFolder += "\\";
                CurrentFile += "\\";
            }
        }


        /// <summary>
        /// Метод для выполнения первого задания (Работы с дисками).
        /// </summary>
        private static void Task1()
        {

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            if (allDrives.Length > 0)
            {
                Console.WriteLine("\n\n\t\t\t\tРабота с дисками.\n\n");
                Console.WriteLine($"\t\t {0,2}.  Не выбирать. Оставить выбранную директорию.\n");
                for (int i = 0; i < allDrives.Length; i++)
                {
                    DriveInfo driveInform = allDrives[i];
                    Console.WriteLine($"\t\t {i + 1,2}.  Диск:   {driveInform.Name}");
                    if (driveInform.IsReady == true)
                    {
                        Console.WriteLine(
                            $"\t\t\tСвободное место на диске:{driveInform.TotalFreeSpace / 1048576,10} GigaBytes");
                        Console.WriteLine(
                            $"\t\t\tВсего места на диске:    {driveInform.TotalSize / 1048576,10} GigaBytes");
                    }
                }
                Console.Write("\n\t Выберите номер диска для дальнейшей работы:  ");

                uint indexToDisk = ValidUint(0, allDrives.Length);

                if (!(indexToDisk == 0))
                {
                    CurrentDisk = allDrives[indexToDisk - 1].ToString();
                    CurrentFolder = allDrives[indexToDisk - 1].ToString();
                    CurrentFile = allDrives[indexToDisk - 1].ToString();
                    Console.WriteLine($"\n\t\t Вы выбрали диск:  {CurrentDisk} \n");
                }
                else Console.WriteLine("\n\t Вы ничего не выбрали (не изменили).");
            }
            else Console.WriteLine("\t\t Магическим образом у вас нет доступных дисков!");

        }   // Конец метода Task1.


        /// <summary>
        /// Метод для выполнения второго задания (Работы с папками).
        /// </summary>
        /// <param name="pathDisk">Текущий диск.</param>
        private static void Task2(string pathDisk)
        {
            string[] allFolders = Directory.GetDirectories(pathDisk);
            Console.WriteLine("\n\n\t\t\t\tРабота с папками.\n");
            if (allFolders.Length > 0)
            {
                Console.WriteLine("\n\t Просмотрите все доступные папки: \n");
                Console.WriteLine($"\t\t {0,3}.  Не выбирать. Оставить выбранную директорию.");

                for (int i = 0; i < allFolders.Length; i++)
                {
                    Console.WriteLine($"\t\t {i + 1,3}.  {Path.GetFileName(allFolders[i])}");
                }
                Console.Write("\n\t Выберите номер папки для дальнейшей работы:  ");

                uint indexOfFolder = ValidUint(0, allFolders.Length);

                if (!(indexOfFolder == 0))
                {
                    CurrentFolder = allFolders[indexOfFolder - 1].ToString();
                    CurrentFile = allFolders[indexOfFolder - 1].ToString();

                    Console.WriteLine($"\n\t\t Вы выбрали файл:  {CurrentFolder} \n");
                }
                else Console.WriteLine("\n\t Вы ничего не выбрали (не изменили).");
            }
            else Console.WriteLine("\t\t В текущеё директории отсутствуют файлы!");

        }   // Конец метода Task2


        /// <summary>
        /// Метод для выполнения третьего задания (Работы с папками)
        /// </summary>
        /// <param name="pathFolder">Текущая папка (полный путь)</param>
        private static void Task3(string pathFolder)
        {
            Console.WriteLine("\n\n\t\t\t\tРабота с файлами.\n");
            Console.WriteLine("\t Как вывести файлы в этой директории?" +
                "\n\t\t 1. Вывести все файлы отсюда." +
                "\n\t\t 2. Вывести все файлы отсюда по маске." +
                "\n\t\t 3. Вывести все файлы и отсюда, и из всех её поддиреторий по маске.");
            Console.Write("\n\t Выберите номер действия для дальнейшей работы:  ");
            uint indexOfAction = ValidUint(1, 3);

            string[] allFiles = Directory.GetFiles(pathFolder);
            try
            {
                switch (indexOfAction)
                {
                    case 1:
                        Task3AllFiles(pathFolder);
                        break;

                    case 2:
                        Task3FilesByMask(pathFolder, allFiles);
                        break;

                    case 3:
                        allFiles = Directory.GetFiles(pathFolder, ".", SearchOption.AllDirectories);
                        Task3FilesByMask(pathFolder, allFiles);
                        break;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\n\t Среди всех файлов присутствует такой, " +
                    "к которому нет доступа простым смертным программам...");
                Console.WriteLine("" +
                    "\t Попробуйте выбрать файл, избегая получения доступа к системным файлам");
                CurrentFile = null;
            }
        }   // Конец метода Task3


        /// <summary>
        /// ПодМетод для выполнения третьего задания (Работы с папками)
        /// </summary>
        /// <param name="pathFolder">Текущая папка (полный путь)</param>
        private static void Task3AllFiles(string pathFolder)
        {
            string[] allFiles = Directory.GetFiles(pathFolder);
            if (allFiles.Length > 0)
            {
                Console.WriteLine("" +
                    "\n\t Просмотрите все доступные в этой директории файлы: \n" +
                    $"\t\t {0,4}.  Не выбирать. Оставить выбранную директорию");

                for (int i = 0; i < allFiles.Length; i++)
                {
                    Console.WriteLine($"\t\t {i + 1,4}.  {Path.GetFileName(allFiles[i])}");
                }
                Console.Write("\n\t Выберите номер файла для дальнейшей работы:  ");

                uint indexOfFile = ValidUint(0, allFiles.Length);
                if (!(indexOfFile == 0))
                {
                    CurrentFile = allFiles[indexOfFile - 1].ToString();
                    FileInfo fileInf = new FileInfo(CurrentFile);
                    Console.WriteLine($"\n\t\t Вы выбрали файл:  {CurrentFile} \n" +
                        $"\n\t\t Расширение файла:  {fileInf.Extension} \n");

                    if (fileInf.Length / 1024 == 0)
                        Console.WriteLine($"\t\t Размер файла:  < 0 KiloBytes\n");

                    else if (fileInf.Length / 1048576 < 1)
                        Console.WriteLine($"\t\t Размер файла:  {fileInf.Length / 1024,6} KiloBytes\n");

                    else Console.WriteLine($"\t\t Размер файла:  {fileInf.Length / 1048576,6} MegaBytes\n");
                }
                else Console.WriteLine("\n\t Вы ничего не выбрали (не изменили).");
            }
            else Console.WriteLine("\t\t В текущей дериктории отсутствуют файлы!");

        }   // Конец метода Task3AllFiles


        /// <summary>
        /// ПодМетод для выполнения третьего задания (Работы с папками)
        /// </summary>
        /// <param name="pathFolder">Текущая папка (полный путь)</param>
        private static void Task3FilesByMask(string pathFolder, string[] allFiles)
        {
            if (allFiles.Length > 0)
            {
                Console.Write("\n\t Введите значение для маски, чтобы осуществить поиск по ней: ");
                string mask = Console.ReadLine();
                Console.WriteLine("" +
                    "\n\n\t Просмотрите все доступные в этой директории файлы по маске: \n" +
                    $"\t\t {0,4}.  Не выбирать. Оставить выбранную директорию");
                string[] allFilesByMask = new string[allFiles.Length];
                int indexOfNumber = 0;
                for (int i = 0; i < allFiles.Length; i++)
                {
                    string nameOfFile = Path.GetFileName(allFiles[i]);
                    if (nameOfFile.Contains(mask))
                    {
                        allFilesByMask[indexOfNumber] = allFiles[i];
                        Console.WriteLine($"\t\t {indexOfNumber++ + 1,4}.  {nameOfFile}");
                    }
                }
                Console.Write("\n\t Выберите номер файла для дальнейшей работы:  ");

                uint indexOfFile = ValidUint(0, indexOfNumber);
                if (!(indexOfFile == 0))
                {
                    CurrentFile = allFilesByMask[indexOfFile - 1].ToString();
                    FileInfo fileInf = new FileInfo(CurrentFile);
                    Console.WriteLine($"\n\t\t Вы выбрали файл:  {CurrentFile} \n" +
                        $"\n\t\t Расширение файла:  {fileInf.Extension} \n");

                    if (fileInf.Length / 1024 == 0)
                        Console.WriteLine($"\t\t Размер файла:  < 0 KiloBytes\n");
                    else if (fileInf.Length / 1048576 < 1)
                        Console.WriteLine($"\t\t Размер файла:  {fileInf.Length / 1024,6} KiloBytes\n");
                    else Console.WriteLine($"\t\t Размер файла:  {fileInf.Length / 1048576,6} MegaBytes\n");
                }
                else Console.WriteLine("\n\t Вы ничего не выбрали (не изменили).");
            }
            else Console.WriteLine("\t\t В текущей дериктории отсутствуют файлы!");
        }   // Конец метода Task3FilesByMask


        /// <summary>
        /// Метод для выполнения четвёртого задания (Вывода содержимого из файла)
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь)</param>
        private static void Task4(string pathFile)
        {

            Console.WriteLine("\n\n\t\t\t\tВывод содержимого из текстового файла.\n");
            if (File.Exists(pathFile))
            {
                FileInfo fileInf = new FileInfo(pathFile);
                if (fileInf.Extension == ".txt")
                {
                    string readAllTxt = File.ReadAllText(pathFile, Encoding.UTF8);
                    Console.WriteLine("\n\n\t\t Содержание текстового файла в UTF-8 \n" +
                    "-----------------------------------------------------------------------------------------------");
                    Console.WriteLine(readAllTxt, Encoding.UTF8);
                    Console.WriteLine("" +
                    "-----------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\n\n\t\t Текстовый файл должен быть в расширении .txt !" +
                        "\n\t\t Попробуйте изменить файл или выбрать другой.");
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }   // Конец метода Task4


        /// <summary>
        /// Метод для выполнения пятого задания (Вывода содержимого из файла в различных кодировках)
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь)</param>
        private static void Task5(string pathFile)
        {
            Console.WriteLine("\n\n\t\t\t\tВывод содержимого из текстового файла в различных кодировках.\n");

            if (File.Exists(pathFile))
            {
                FileInfo fileInf = new FileInfo(pathFile);
                if (fileInf.Extension == ".txt")
                {
                    TextAndRule(2);
                    PrintTxtInExtens(pathFile);
                }
                else
                {
                    Console.WriteLine("\n\n\t\t Текстовый файл должен быть в расширении .txt !" +
                        "\n\t\t Попробуйте изменить файл или выбрать другой.");
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }   // Конец метода Task5


        /// <summary>
        /// Метод для вывода содержимого из файла в различных кодировках.
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь)</param>
        private static void PrintTxtInExtens(string pathFile)
        {

            string[] encodings = { "UTF-8", "UTF-32", "ASCII", "Unicode" };
            uint indexOf = ValidUint(1, 4);

            Console.WriteLine($"\n\n\t\t Содержание текстового файла в {encodings[indexOf - 1]} \n" +
                "-----------------------------------------------------------------------------------------------");
            switch (indexOf)
            {
                case 1:
                    Console.WriteLine(File.ReadAllText(pathFile, Encoding.UTF8), Encoding.UTF8);
                    break;
                case 2:
                    Console.WriteLine(File.ReadAllText(pathFile, Encoding.UTF32), Encoding.UTF32);
                    break;
                case 3:
                    Console.OutputEncoding = Encoding.ASCII;
                    Console.WriteLine(File.ReadAllText(pathFile, Encoding.ASCII), Encoding.ASCII);
                    break;
                case 4:
                    Console.WriteLine(File.ReadAllText(pathFile, Encoding.Unicode), Encoding.Unicode);
                    break;
                default:
                    Console.WriteLine(File.ReadAllText(pathFile, Encoding.UTF8), Encoding.UTF8);
                    break;
            }
            Console.OutputEncoding = Encoding.Default;
            Console.WriteLine("" +
                "-----------------------------------------------------------------------------------------------");

        }   // Конец метода PrintTxtInExtens

        /// <summary>
        /// Метод для выполнения шестого задания (Копирования файла).
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь).</param>
        private static void Task6(string pathOldFile)
        {
            Console.WriteLine("\n\n\t\t\t\tКопирование файла.\n");


            string allPathToFile = GetName(Path.GetExtension(pathOldFile));

            File.Copy(CurrentFile, allPathToFile);
            Console.Write($"\n\t Файл {allPathToFile} успешно создан!\n");

        }   // Конец метода Task6


        /// <summary>
        /// Метод для выполнения седьмого задания (Перемещения файла).
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь).</param>
        private static void Task7(string pathOldFile)
        {

            Console.WriteLine("\n\n\t\t\t\tПеремещение файла.\n");

            Console.WriteLine($"\n\t Файл {CurrentFile} будет перемещён.");

            (string, string, string) paths = (CurrentDisk, CurrentFolder, CurrentFile);

            while (true)
            {
                try
                {
                    Console.WriteLine("\n\t Выберите полный путь к новой директории файла.");
                    GetNewFile();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\t Произошла ошибка при выборе пути, попробуйте заново!");
                    continue;
                }
            }
            if (!File.Exists(CurrentFolder + "\\" + Path.GetFileName(paths.Item3)))
            {
                File.Move(paths.Item3, CurrentFolder + "\\" + Path.GetFileName(paths.Item3));
                Console.WriteLine($"\n\t Файл {paths.Item3} перемещён в директорию {CurrentFolder}.");
            }
            else
            {
                Console.WriteLine($"\n\t Файл {paths.Item3} Не может быть перемещён в директорию {CurrentFolder}" +
                    $"\n\t Файл с таким же именем уже присутствует в этой директории!");
            }
        }   // Конец метода Task7


        /// <summary>
        /// Метод для выполнения восьмого задания (Удаления файла).
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь).</param>
        private static void Task8(string pathOldFile)
        {

            Console.WriteLine("\n\n\t\t\t\tУдаление файла.\n");

            Console.WriteLine($"\n\t Файл {CurrentFile} будет удалён.");

            Console.WriteLine("\n\t Вы уверены, что хотите удалить файл? Для отмены нажмите Escape.");
            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                File.Delete(pathOldFile);
                Console.WriteLine($"\n\t Файл {CurrentFile} был удалён!");
                CurrentFile = CurrentFolder;
            }
            else Console.WriteLine("\n\t По вашему решению Файл НЕ был удалён.");

        }   // Конец метода Task8


        /// <summary>
        /// Метод для выполнения девятого задания (Создания текстового файла)
        /// </summary>
        /// <param name="pathFile">Текущая папка (полный путь)</param>
        private static void Task9(string pathFolder)
        {

            Console.WriteLine("\n\n\t\t\t\tСоздание текстового файла в UTF-8.\n");

            string allPathToNewFile = GetName(".txt");

            Encoding utf8 = new UTF8Encoding(false);
            StreamWriter newFile = new StreamWriter(allPathToNewFile, false, utf8);
            newFile.Close();

            CurrentFile = allPathToNewFile;

            Console.WriteLine($"\n\t Файл {allPathToNewFile} был создан!");

        }   // Конец метода Task9


        /// <summary>
        /// Метод для выполнения десятого задания (Создания текстового файла в выбранной кодировке.)
        /// </summary>
        /// <param name="pathFile">Текущая папка (полный путь)</param>
        private static void Task10(string pathFolder)
        {
            Console.WriteLine("\n\n\t\t\t\tСоздание текстового файла в выбранной кодировке.\n");

            TextAndRule(3);
            uint indexOf = ValidUint(1, 4);

            string allPathToNewFile = GetName(".txt");
            StreamWriter newFile;
            Encoding enc = new UTF8Encoding(false);
            switch (indexOf)
            {
                case 1:
                    enc = new UTF8Encoding(false);
                    break;
                case 2:
                    enc = new UTF32Encoding();
                    break;
                case 3:
                    enc = new ASCIIEncoding();
                    break;
                case 4:
                    enc = new UnicodeEncoding();
                    break;
            }
            newFile = new StreamWriter(allPathToNewFile, false, enc);
            newFile.Close();

            CurrentFile = allPathToNewFile;

            Console.WriteLine($"\n\t Файл {allPathToNewFile} был создан!");

        }   // Конец метода Task10


        /// <summary>
        /// Метод для выполнения одиннадцатого задания (Конкатенации содержимого текстовых файлов).
        /// </summary>
        /// <param name="pathFile">Текущий файл (полный путь).</param>
        private static void Task11(string pathFile)
        {
            Console.WriteLine("\n\n\t\t\t\tКонкатенация содержимого текстовых файлов.\n");
            Console.WriteLine($"\n\t Файл {pathFile} будет конкатенирован с другим текстовым файлом.");
            if (Path.GetExtension(pathFile) == ".txt")
            {
                (string, string, string) paths = (CurrentDisk, CurrentFolder, CurrentFile);
                GetTxtFileForСoncatenation(out string[] arrOfTxtFiles);
                arrOfTxtFiles[0] = pathFile;

                Console.WriteLine("\n\t Результат отобразится в консоли. Вы хотите создать отдельный файл с ним?" +
                    "\n\t Нажмите \"Enter\" и вы перейдёте к созданию файла.");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("\n\t Выберите папку, в которой нужно создать файл.");
                    GetNewFile();
                    Task9(CurrentFolder);
                    StreamWriter file = new StreamWriter(CurrentFile, true);

                    foreach (var txtFile in arrOfTxtFiles)
                    {
                        file.WriteLine(File.ReadAllText(txtFile, Encoding.UTF8), Encoding.UTF8);
                    }
                    file.Close();
                    Console.WriteLine($"\t В файл {CurrentFile} записан результат!");
                }
                Console.WriteLine("" +
                    "-----------------------------------------------------------------------------------------------");
                for (int i = 0; i < arrOfTxtFiles.Length; i++)
                {
                    Console.WriteLine(File.ReadAllText(arrOfTxtFiles[i], Encoding.UTF8), Encoding.UTF8);
                }
                Console.WriteLine("" +
                "-----------------------------------------------------------------------------------------------");
                CurrentDisk = paths.Item1;
                CurrentFolder = paths.Item2;
                CurrentFile = paths.Item3;
            }
            else Console.WriteLine("\n\n\t\t Текстовый файл должен быть в расширении .txt !" +
                    "\n\t\t Попробуйте изменить файл или выбрать другой.");

        }   // Конец метода Task11


        /// <summary>
        /// Получение путей к новым .txt файлам для конкатенации содержимого.
        /// </summary>
        private static void GetTxtFileForСoncatenation(out string[] arrOfTxtFiles)
        {
            bool flagNextFile;
            arrOfTxtFiles = new string[2];

            do
            {
                flagNextFile = false;
                Console.WriteLine("" +
                    "\n\t Выберите текстовый файл, с которым нужно конкатенировать изначальный.");

                GetNewFile();

                if (CurrentFile != null)
                {
                    if (!(Path.GetExtension(CurrentFile) == ".txt"))
                    {
                        Console.WriteLine("\n\n\t\t Текстовый файл должен быть в расширении .txt !" +
                            "\n\t\t Попробуйте изменить файл или выбрать другой.");
                        continue;
                    }
                }
                else continue;
                arrOfTxtFiles[arrOfTxtFiles.Length - 1] = CurrentFile;

                Console.WriteLine("\n\t Вы хотите сконкатенировать данные с ещё одного файла?" +
                    "\n\t Тогда нажмите кнопку \"Enter\"");

                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    flagNextFile = true;
                    Array.Resize(ref arrOfTxtFiles, arrOfTxtFiles.Length + 1);
                }

            } while (!(Path.GetExtension(CurrentFile) == ".txt") || flagNextFile);

        }   // Конец метода GetTxtFileForСoncatenation


        /// <summary>
        /// Получение пути к новому файлу.
        /// </summary>
        public static void GetNewFile()
        {
            try
            {
                TextAndRule(4);
                bool flag2 = false;
                int countOfTask = 1;
                do
                {
                    if (countOfTask % 4 == 0)
                    {
                        Console.WriteLine("\n\t Нажмите любую кнопку для продолжения. (Консоль будет очищена!)");
                        Console.ReadKey(true);
                        Console.Clear();
                        TextAndRule(4);
                    }
                    Console.WriteLine($"\t Текущая директория: {CurrentFile}");

                    Console.Write("\n\t Введите значение соответствующее номеру задания: ");
                    string numOfTask = Console.ReadLine();
                    switch (numOfTask)
                    {
                        case "-":
                            GetUpOnTheWay();
                            break;
                        case "0":
                            flag2 = true;
                            break;
                        case "1":
                            Task1();
                            break;
                        case "2":
                            Task2(CurrentFolder);
                            break;
                        case "3":
                            Task3(CurrentFolder);
                            break;
                        case "4":
                            ChangePath();
                            break;
                        default:
                            Console.WriteLine("\n\t\t Вы ввели неверное значение, попробуйте ещё раз!");
                            break;
                    }
                } while (!flag2);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n\t Произошла ошибка! Файл не был найден! Попробуйте изменить директорию.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("\n\t Произошла ошибка! Папка не была найдена! Попробуйте изменить директорию.");
            }
            catch (Exception)
            {
                Console.WriteLine("\n\t Произошла ошибка! ");
            }
        }   // Конец метода GetNewFile


        /// <summary>
        /// Получение имени для файла по правилам.
        /// </summary>
        /// <param name="extension">Разрешение файла.</param>
        /// <returns></returns>
        public static string GetName(string extension)
        {
            string nameOfFile, allPathToFile = null, pathToFile = CurrentFolder;
            bool flagCorrect;
            Console.Write("\n\t Введите имя для нового файла (Только латиницей и цифрами!): ");
            do
            {
                flagCorrect = true;

                nameOfFile = Console.ReadLine();
                if (nameOfFile.Length > 0)
                {
                    for (int i = 0; i < nameOfFile.Length; i++)
                    {
                        int iChar = (int)nameOfFile[i];
                        if (!(((iChar >= 65 && iChar <= 90) || (iChar >= 97 && iChar <= 122)) || (iChar >= 48 && iChar <= 57)))
                        {
                            Console.Write("\n\t Вы ввели неверное имя, оно должно быть только из латиницы и цифр: ");
                            flagCorrect = false;
                            break;
                        }
                    }
                    allPathToFile = pathToFile + @"\" + nameOfFile + extension;

                    if (File.Exists(allPathToFile))
                    {
                        Console.Write("\n\t Такое имя уже существует! Введите новое имя: ");
                        flagCorrect = false;
                    }
                }
                else
                {
                    Console.Write("\n\t Вы ввели неверное имя, оно должно быть только из латиницы и цифр: ");
                    flagCorrect = false;
                }
            } while (!flagCorrect);

            return allPathToFile;

        }   // Конец метода GetName


        /// <summary>
        /// Метод для получения числа типа uint.
        /// </summary>
        /// <param name="edgeLow">Нижняя граница</param>
        /// <param name="edgeUp">Верхняя граница</param>
        /// <returns>Полученное число типа uint.</returns>
        public static uint ValidUint(int edgeLow, int edgeUp)
        {

            uint number;
            while (!(uint.TryParse(Console.ReadLine(), out number) && number >= edgeLow && number <= edgeUp))
            {
                Console.WriteLine($"\n\t\tВы ввели неверное число, оно должно принадлежать промежутку от {edgeLow} до {edgeUp}!");
                Console.Write("\n\t Напоминаю, вы должны ввести целое число - номер из списка: ");
            }

            return number;

        }   // Конец метода ValidUint


        /// <summary>
        /// Метод для вывода заготовленного текста.
        /// </summary>
        /// <param name="distrib">Какой текст вывести.</param>
        public static void TextAndRule(int distrib)
        {
            switch (distrib)
            {
                case 1:
                    Console.WriteLine("" +
                        "\n\t\t -.  Переместиться в родительскую директорию. (введите минус)" +
                        "\n\t\t 0.  Закончить выбор." +
                        "\n\t\t 1.  Просмотр списка дисков компьютера и выбор диска." +
                        "\n\t\t 2.  Переход в другую директорию (выбор папки)." +
                        "\n\t\t 3.  Просмотр списка файлов в директории (+ поиск по маске)." +
                        "\n\t\t 4.  Вывод содержимого текстового файла в консоль в кодировке UTF-8." +
                        "\n\t\t 5.  Вывод содержимого текстового файла в консоль в выбранной." +
                        "\n\t\t       пользователем кодировке(предоставляется не менее трех вариантов)." +
                        "\n\t\t 6.  Копирование файла." +
                        "\n\t\t 7.  Перемещение файла в выбранную пользователем директорию." +
                        "\n\t\t 8.  Удаление файла." +
                        "\n\t\t 9.  Создание простого текстового файла в кодировке UTF-8." +
                        "\n\t\t 10. Создание простого текстового файла в выбранной." +
                        "\n\t\t       пользователем кодировке(предоставляется не менее трех вариантов)." +
                        "\n\t\t 11. Конкатенация содержимого двух или более текстовых файлов." +
                        "\n\t\t       и вывод результата в консоль в кодировке UTF-8." +
                        "\n\t\t 12. Выбрать текущим путём папку с проектом.\n\n");
                    break;
                case 2:
                    Console.WriteLine("" +
                        "\n\t\t Выберите кодировку, в которой Вы хотите вывести содержимое текстового файла:" +
                        "\n\t\t\t 1. UTF-8" +
                        "\n\t\t\t 2. UTF-32" +
                        "\n\t\t\t 3. ASCII" +
                        "\n\t\t\t 4. Unicode (UTF-16)");
                    Console.Write("\n\t Выберите номер кодировки:  ");
                    break;
                case 3:
                    Console.WriteLine("" +
                        "\n\t\t Выберите кодировку, в которой Вы хотите создать текстовый файл:" +
                        "\n\t\t\t 1. UTF-8" +
                        "\n\t\t\t 2. UTF-32" +
                        "\n\t\t\t 3. ASCII" +
                        "\n\t\t\t 4. Unicode (UTF-16)");
                    Console.Write("\n\t Выберите номер кодировки:  ");
                    break;
                case 4:
                    Console.WriteLine("" +
                        "\n\t Выберите действие:" +
                        "\n\t\t -.  Переместиться в родительскую директорию. (введите минус)" +
                        "\n\t\t 0.  Закончить выбор." +
                        "\n\t\t 1.  Просмотр списка дисков компьютера и выбор диска." +
                        "\n\t\t 2.  Переход в другую директорию (выбор папки)." +
                        "\n\t\t 3.  Просмотр списка файлов в директории (+ поиск по маске)." +
                        "\n\t\t 4.  Выбрать текущим путём папку с проектом.\n");
                    break;
            }
        }   // Конец метода TextAndRule.
    }
}
