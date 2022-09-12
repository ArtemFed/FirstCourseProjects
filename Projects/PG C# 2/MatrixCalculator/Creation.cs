using System;
using System.IO;

namespace MatrixCalculator
{
    /// <summary>
    /// Класс для создания матриц и вывода текста в консоль.
    /// </summary>
    public partial class Creation
    {
        /// <summary>
        /// Метод для полного создания матрицы.
        /// <para> Входные данные для матрицы.</para>
        /// <para> true - квадратная, false - прямоугольная.</para>
        /// </summary>
        /// <param name="flagCube">bool для квадратной матрицы или обычной.</param>
        /// <returns>Готовая Матрица.</returns>
        public static double[,] GetMatrix(bool flagCube)
        {
            bool flagTxtWork;
            double[,] matrix;
            do
            {
                MatrixSize(out uint line, out uint column, flagCube);
                matrix = new double[line, column];
                flagTxtWork = true;            
                ConsoleKey buttonPress2 = Console.ReadKey(true).Key;
                if (buttonPress2 == ConsoleKey.D1 || buttonPress2 == ConsoleKey.NumPad1)
                    RandomMatrix(line, column, matrix);
                else if (buttonPress2 == ConsoleKey.D2 || buttonPress2 == ConsoleKey.NumPad2)
                {
                    try
                    {
                        TxtMatrix(line, column, matrix);
                    }
                    catch
                    {
                        Console.WriteLine("\n\t Файл не был обнаружен!\n\t Попробуйте ещё раз.\n");
                        flagTxtWork = false;
                    }
                }
                else
                {
                    for (var i = 0; i < line; i++)
                    {
                        for (var j = 0; j < column; j++)
                        {
                            Console.Write($"\t Введите значение для элемента [{i + 1},{j + 1}]: ");
                            matrix[i, j] = MainMatrixCalculator.ValidDouble();
                        }
                    }
                }
            } while (!flagTxtWork);
            Console.WriteLine("\t\t Ваша Матрица:");
            MainMatrixCalculator.PrintMatrix(matrix);
            Console.WriteLine();
            return matrix;
        }   // Конец метода GetMatrix.


        /// <summary>
        /// Метод для получения размеров матрицы.
        /// </summary>
        /// <param name="line">Количесво строк.</param>
        /// <param name="column">Количество стобцов.</param>
        /// <param name="flagCube">bool для квадратной матрицы или обычной.</param>
        static void MatrixSize(out uint line, out uint column, bool flagCube)
        {
            if (flagCube)
            {
                Console.Write("\n\t Введите количество строк (столбцов) в квадратной матрице: ");
                line = MainMatrixCalculator.ValidUint();
                column = line;
                Console.WriteLine();
            }
            else
            {
                Console.Write("\n\t Введите количество строк в матрице: ");
                line = MainMatrixCalculator.ValidUint();
                Console.Write("\n\t Введите количество столбцов в матрице: ");
                column = MainMatrixCalculator.ValidUint();
                Console.WriteLine();
            }
            if (line >= 15 || column >= 15)
                Console.WriteLine("\t Совет: Для введённого размера матрцы лучше войдите в полноэкранный режим.\n");

            Console.WriteLine("\t Как вы хотите создать матрицу?" +
                "\n\t  1) Сгенерировать случайную матрицу (значения от -20 до +20) - нажмите кнопку \"1\" " +
                "\n\t  2) Ввести матрицу с файла - нажмите кнопку \"2\"" +
                "\n\t  3) Для ручного ввода матрицы - нажмите любую другую кнопку\n");

        }   // Конец метода MatrixSize.


        /// <summary>
        /// Метод для генерации случайной матрицы.
        /// </summary>
        /// <param name="line">Количесво строк.</param>
        /// <param name="column">Количество стобцов.</param>
        /// <param name="matrix">Матрица.</param>
        /// <returns>Готовая Матрица.</returns>
        static double[,] RandomMatrix(uint line, uint column, double[,] matrix)
        {
            var rand = new Random();
            for (var i = 0; i < line; i++)
            {
                for (var j = 0; j < column; j++)
                {
                    matrix[i, j] = rand.Next(-20, 21);
                }
            }

            return matrix;
        }   // Конец метода RandomMatrix.


        /// <summary>
        /// Метод для чтения матрицы с файла.
        /// </summary>
        /// <param name="line">Количесво строк.</param>
        /// <param name="column">Количество стобцов.</param>
        /// <param name="matrix">Матрица.</param>
        /// <returns>Готовая Матрица.</returns>
        static double[,] TxtMatrix(uint line, uint column, double[,] matrix)
        {
            bool flagTxtIn;
            TextAndRule(2);
            do
            {
                int flagTxtI = 0, flagTxtJ = 0;
                flagTxtIn = true;
                Console.WriteLine("\n\t Вы закончили ввод матрицы? Тогда нажмите любую кнопку для продолжения.\n");
                if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    StreamReader matRead = new StreamReader(@"..\..\..\MatrixReader.txt");
                    for (var i = 0; i < line; i++)
                    {
                        for (var j = 0; j < column; j++)
                        {
                            string lineStr = matRead.ReadLine();
                            double number;
                            if (!(double.TryParse(lineStr, out number) & number >= -2000 & number <= 2000))
                            {
                                flagTxtI = i;
                                flagTxtJ = j;
                                flagTxtIn = false;
                                break;
                            }
                            matrix[i, j] = number;
                        }
                        if (!flagTxtIn)
                        {
                            Console.WriteLine("\t Вы должны исправить значения в файле!" +
                                $"\n\t - Значение в строке под номером {flagTxtI * column + flagTxtJ + 1} неверно" +
                                "\n\t - У вас могут быть только дробные или целые числа от -2000 до 2000" +
                                $"\n\t - Либо вы ввели недостаточно значений, всего должно быть {matrix.Length} цифр");
                            break;
                        }
                    }
                    matRead.Close();
                }
                else flagTxtIn = false;
            } while (!flagTxtIn);
            return matrix;
        }   // Конец метода TxtMatrix.


        /// <summary>
        /// Метод, который по запросу выводит текст в консоль.
        /// </summary>
        /// <param name="distrib">Распределяющая переменная для текста.</param>
        public static void TextAndRule(int distrib)
        {
            switch (distrib)
            {

                case 2:
                    Console.WriteLine("\n\t Введите вашу матрицу в файл \"MatrixReader.txt\" (отредактируйте его)." +
                        "\n\t - Он расположен ...MatrixCalculator/MatrixReader.txt" +
                        "\n\t Если вы хотите посмотреть инструкцию (рекомендую), то" +
                        "\n\t Нажмите кнопку \"I\" (information) или \"И\" (информация), иначе любую другую клавишу.");
                    ConsoleKey buttonPress1 = Console.ReadKey(true).Key;
                    if (buttonPress1 == ConsoleKey.I | buttonPress1 == ConsoleKey.B)
                        Console.WriteLine("\n\t Правила и пояснения к \"Калькулятору матриц\": " +
                            "\n\t  1) Вводите каждое значение (поэлементово) с новой строки, начиная с первой." +
                            "\n\t  2) Ограничение на значения в матрице от -2000 до 2000." +
                            "\n\t  3) При первом запуске программы в MatrixReader.txt будет пример ввода матрицы.");
                    break;
                case 3:
                    Console.WriteLine("\n\t Выбирает операцию, которую хотите выполнить с матрицами:\n" +
                        "\n\t Нажмите кнопку от 1 до 8 (на NumPad'e тоже можно)." +
                        "\n\t\t1. Найти след матрицы." +
                        "\n\t\t2. Транспонировать матрицу." +
                        "\n\t\t3. Вычислить Сумму двух матриц." +
                        "\n\t\t4. Вычислить Разность двух матриц." +
                        "\n\t\t5. Вычислить Произведение двух матриц." +
                        "\n\t\t6. Умножить матрицу на число." +
                        "\n\t\t7. Найти определитель матрицы." +
                        "\n\t\t8. Решить Систему Линейных Алгебраических Уравнений (СЛАУ)\n");
                    break;
                case 4:
                    Console.WriteLine("\t\t Решение Системы Линейных Алгебраических Уравнений (СЛАУ).\n\n" +
                        "\n\t Важно! Для того, чтобы можно было решить СЛАУ нужно, " +
                        "чтобы кол-во строк было на один короче кол-ва столбцов." +
                        "\n\t Cоздайте матрицу из коэффициентов уравнения и свободных членов." +
                        "\n\t Например: ( 2x + 3y = 4 )  ==>  ( 2 3 4 ) (только каждое значение с новой строки).");
                    break;
            }
        }   // Конец метода TextAndRule.


        /// <summary>
        /// Часть 2.
        /// Метод, который по запросу выводит текст в консоль.
        /// (для декомпозирования)
        /// </summary>
        public static void TextAndRule2()
        {
            Console.WriteLine("\n\t\t\t Добро пожаловать в \"Калькулятор матриц\"!\n");
            Console.WriteLine("\t\t\t   Хотите ознакомиться с правилами? \n\t Тогда нажмите кнопку \"I\"." +
                " (information) или \"И\" (информация), иначе любую другую клавишу.");

            ConsoleKey buttonPress1 = Console.ReadKey(true).Key;
            if (buttonPress1 == ConsoleKey.I | buttonPress1 == ConsoleKey.B)
                Console.WriteLine("\n\t Инструкция к «Калькулятору матриц»:" +
                    "\n\t\t1) Ограничение на размер матриц 20 на 20. " +
                    "\n\t\t2) Ограничение на значения в матрице от -2000 до 2000 (только на ввод, вывод любой)." +
                    "\n\t\t3) Если вы выбираете случайную генерацию матрицы, " +
                    "то её значениями будут целые числа от -20 до +20. \n\t\t4) Перед случайной генерацией " +
                    "или чтением матрицы с файла вы обязаны задать её размер.\n\t\t5) Для красоты и удобства " +
                    "происходит округление ответов на выводе (до двух цифр после запятой),\n\t\t\tиз-за чего очень" +
                    "редко может появляться маленькая неточность, ещё вы можете увидеть значение \"-0\"" +
                    "\n\t\t\t(очень маленькое отрицательное число), также вы можете вводить значения начинающиеся" +
                    "\n\t\t\tс плюса (+10 == 10) или с нуля (007 == 7)." +
                    "\n\t\t6) Размеры матриц вы всегда будете вводить в консоль, чтобы избежать путаницы." +
                    "\n\t\t7) Ввод матрицы осуществляется поэлементово, потому что при вводе значений в строку " +
                    "\n\t\t\t(через пробелы) теряется отцентровка (столбцы могут не совпадать)." +
                    "\n\t\t8) Вы можете решать системы только таких Линейных Уравнений, у которых " +
                    "\n\t\t\tколичество столбцов на один больше количества строк.");

            Console.WriteLine("\n\t Для продолжениянажмите нажмите любую кнопку:");
            ConsoleKey skip = Console.ReadKey(true).Key;
        }   // Конец метода TextAndRule2.

    }
}
