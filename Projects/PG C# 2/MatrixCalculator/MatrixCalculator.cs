using System;

namespace MatrixCalculator
{
    /// <summary>
    /// Основной класс для реализации матричного калькулятора.
    /// </summary>
    public partial class MainMatrixCalculator
    {

        /// <summary>
        /// Основной метод, объединяет информацию полученную с помощью других методов.
        /// </summary>
        public static void Main()
        {

            // Вывод заготовленного текста 1.
            Creation.TextAndRule2();
            ConsoleKey buttonPressEnd;
            // Цикл ответственный за то, чтобы можно было перезапускать игру по её завершении.
            do
            {
                Console.Clear();
                GetTask();

                Console.WriteLine("\n\n\t\t Калькулятор закончил работу.\n" +
                    "\n\t Хотите дать ему новое задание? Нажмите любую кнопку, иначе Escape.");
                buttonPressEnd = Console.ReadKey(true).Key;

            } while (buttonPressEnd != ConsoleKey.Escape);

        }   // Конец метода "Main".


        /// <summary>
        /// Общение с Пользователем (правила и пояснения). 
        /// Получение задания от Пользователя.
        /// </summary>
        static void GetTask()
        {
            bool flag1;
            do
            {
                Console.WriteLine("\n\t Что матричный калькулятор должен сделать для вас?");
                flag1 = true;
                // Вывод заготовленного текста 3.
                Creation.TextAndRule(3);
                ConsoleKey buttonPress1 = Console.ReadKey(true).Key;
                Console.Clear();
                Console.WriteLine();
                // Распределение по задачам.
                if (buttonPress1 == ConsoleKey.D1 || buttonPress1 == ConsoleKey.NumPad1)
                    Task1();
                else if (buttonPress1 == ConsoleKey.D2 || buttonPress1 == ConsoleKey.NumPad2)
                    Task2();
                else if (buttonPress1 == ConsoleKey.D3 || buttonPress1 == ConsoleKey.NumPad3)
                    Task34(true);
                else if (buttonPress1 == ConsoleKey.D4 || buttonPress1 == ConsoleKey.NumPad4)
                    Task34(false);
                else if (buttonPress1 == ConsoleKey.D5 || buttonPress1 == ConsoleKey.NumPad5)
                    Task5();
                else if (buttonPress1 == ConsoleKey.D6 || buttonPress1 == ConsoleKey.NumPad6)
                    Task6();
                else if (buttonPress1 == ConsoleKey.D7 || buttonPress1 == ConsoleKey.NumPad7)
                    Task7();
                else if (buttonPress1 == ConsoleKey.D8 || buttonPress1 == ConsoleKey.NumPad8)
                    Task8();
                else flag1 = false;
            } while (flag1 == false);

        }  // Конец метода "TextRules".


        /// <summary>
        /// Нахождение следа матрицы.
        /// </summary>
        private static void Task1()
        {
            Console.WriteLine("\t\t Нахождение следа матрицы.\n");
            Console.WriteLine("\t Совет: Для нахождения следа матрицы, она должна быть квадратной " +
                "(кол-во строк = кол-ву столбцов).");
            double[,] matrix1;
            // Переменная для подсчёта следа.
            double trace;
            // Отправляем значение true, так как для следа нужна квадроатная матрица.
            matrix1 = Creation.GetMatrix(true);
            trace = 0;

            for (var i = 0; i < matrix1.GetLength(0); i++)
                trace += matrix1[i, i];

            Console.Write("\t\t Ваш результат:  ");
            Console.WriteLine($" {Math.Round(trace, 2)}\n");
        }   // Конец метода Task1.


        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        private static void Task2()
        {
            Console.WriteLine("\t\t Транспонирование матрицы.\n");
            double[,] matrix1, matrix2;
            // matrix1 - матрица Пользователя.
            matrix1 = Creation.GetMatrix(false);
            // matrix2 - Транспонированная матрица Пользователя.
            matrix2 = new double[matrix1.GetLength(1), matrix1.GetLength(0)];

            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix1.GetLength(1); j++)
                    matrix2[j, i] = matrix1[i, j];
            }

            Console.WriteLine("\t\t Ваш результат:");
            PrintMatrix(matrix2);

        }   // Конец метода Task2.


        /// <summary>
        /// Сумма двух матриц и Разность двух матриц.
        /// </summary>
        /// <param name="flagPlusMinus">bool для определения Суммы или Разности.</param>
        private static void Task34(bool flagPlusMinus)
        {
            if (flagPlusMinus)
                Console.WriteLine("\t\t Сумма двух матриц.\n");
            else Console.WriteLine("\t\t Разность двух матриц.\n");
            Console.WriteLine("\t Совет: Для вычисления Суммы и Разности матриц, они должны быть одного размера.");
            double[,] matrix1, matrix2;
            do
            {
                Console.WriteLine("\n\t\tСоздайте две матрицы.");
                matrix1 = Creation.GetMatrix(false);
                // Можно было и передать фиксированные значения для размеров второй матрицы, но я решил сделать так...
                Console.WriteLine($"\n\t Создайте вторую матрицу размером {matrix1.GetLength(0)} на {matrix1.GetLength(1)}.");
                matrix2 = Creation.GetMatrix(false);
                // Проверка на одинаковый размер матриц.
                if (!((matrix1.GetLength(0) == matrix2.GetLength(0))
                    && (matrix1.GetLength(1) == matrix2.GetLength(1))))
                    Console.WriteLine("\t При вычислении Суммы или Разности матриц, они должны быть одного размера.");

            } while (!(matrix1.GetLength(0) == matrix2.GetLength(0)));

            double[,] matrix3 = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

            // Поэлементовое вычисление значений для результирующей матрицы.
            for (var i = 0; i < matrix3.GetLength(0); i++)
            {
                for (var j = 0; j < matrix3.GetLength(1); j++)
                {
                    if (flagPlusMinus)
                        matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    else
                        matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            Console.WriteLine("\t\t Ваш результат:");
            PrintMatrix(matrix3);
        }   // Конец метода Task34.


        /// <summary>
        /// Произведение двух матриц.
        /// </summary>
        private static void Task5()
        {
            Console.WriteLine("\t\t Произведение двух матриц.\n");
            Console.WriteLine("\n\t Совет: Для вычисления Произведения матриц, количество столбцов первой " +
                "\n\t\t\tдолжно быть равно количеству строк второй.");
            double[,] matrix1, matrix2;
            do
            {
                Console.WriteLine("\n\t\tСоздайте две матрицы.");
                matrix1 = Creation.GetMatrix(false);
                Console.WriteLine($"\t Создайте вторую матрицу с {matrix1.GetLength(1)} строками.");
                matrix2 = Creation.GetMatrix(false);

                if (!(matrix1.GetLength(1) == matrix2.GetLength(0)))
                    Console.WriteLine("\t При вычислении Произведения матриц, количество столбцов первой " +
                        "должно быть равно количеству строк второй.");

            } while (!(matrix1.GetLength(1) == matrix2.GetLength(0)));

            double[,] matrix3 = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

            // Цикл по строкам.
            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                // Цикл по столбцам.
                for (var j = 0; j < matrix2.GetLength(1); j++)
                {
                    // Цикл по столбцам первой матрицы или по строкам второй.
                    // Попарно перемножаем значения строк и столбцов (k - отвечает за поэлементовое передвижение).
                    for (var k = 0; k < matrix1.GetLength(1); k++)
                    {
                        matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            Console.WriteLine("\t\t Ваш результат:");
            PrintMatrix(matrix3);
        }   // Конец метода Task5.


        /// <summary>
        /// Умножение матрицы на число.
        /// </summary>
        private static void Task6()
        {
            Console.WriteLine("\t\t Умножение матрицы на число.\n");

            double[,] matrix1 = Creation.GetMatrix(false);

            Console.Write("\n\t Вы должны ввести число, на которое вы хотите умножить Вашу матрицу: ");
            double coefficient = ValidDouble();
            Console.WriteLine();

            // Поэлементовое умножение матрицы на число.
            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = matrix1[i, j] * coefficient;
                }
            }

            Console.WriteLine("\t\t Ваш результат:");
            PrintMatrix(matrix1);
        }   // Конец метода Task6.


        /// <summary>
        /// Нахождение определителя матрицы.
        /// </summary>
        private static void Task7()
        {
            Console.WriteLine("\t\t Нахождение определителя матрицы.\n" +
                "\t Совет: Для Нахождение определителя матрицы, она должны быть квадратной.\n");
            double[,] matrix1 = Creation.GetMatrix(true);

            // determinant - определитель матрицы.
            double determinant = 1;
            int line = matrix1.GetLength(0), column = matrix1.GetLength(1);

            TheGaussMethod(line, column, ref matrix1, out double determinantCoeff);

            for (var i = 0; i < matrix1.GetLength(0); i++)
                determinant *= matrix1[i, i];

            // determinantCoeff - если мы меняли строки местами, то знак determinant'а может изменится.
            determinant *= determinantCoeff;
            if (Math.Abs(determinant) == 0)
                determinant = 0;
            Console.Write("\n\t\t Определитель матрицы равен: ");
            Console.WriteLine(Math.Round(determinant, 2));
        }   // Конец метода Task7.


        /// <summary>
        /// Решение Системы Линейных Алгебраических Уравнений (СЛАУ)
        /// С помощью метода Гаусса.
        /// </summary>
        private static void Task8()
        {
            // Вывод заготовленного текста 4.
            Creation.TextAndRule(4);
            double[,] matrix1;
            do
            {
                matrix1 = Creation.GetMatrix(false);
                if (!((matrix1.GetLength(1) - matrix1.GetLength(0)) == 1))
                    Console.WriteLine("\t Ваша матрица не верна, кол-во строк должно быть на один короче столбцов.");
            } while (!((matrix1.GetLength(1) - matrix1.GetLength(0)) == 1));

            int line = matrix1.GetLength(0), column = matrix1.GetLength(1);

            // Приводим к Ступенчатому виду по Методу Гаусса.
            TheGaussMethod(line, column, ref matrix1, out double determinantCoeff);

            bool flagZeroLine = false;
            // Проверяем.
            CheckZeroLine(matrix1, line, column, ref flagZeroLine);

            GetSolution(flagZeroLine, line, matrix1);
        }   // Конец метода Task8.


        /// <summary>
        /// Метод для приведения матрицы к ступенчатому виду с помощью "Метода Гаусса".
        /// </summary>
        /// <param name="line">Количество строк.</param>
        /// <param name="column">Количество столбцов.</param>
        /// <param name="matrix1">Матрица.</param>
        /// <param name="determinantCoeff">Переменная, чтобы отследить знак определителя, 
        /// так как мы могли менять строки местами.</param>
        static void TheGaussMethod(int line, int column, ref double[,] matrix1, out double determinantCoeff)
        {
            determinantCoeff = 1;
            for (var k = 0; k < line - 1; k++)
            {
                // Если ведущий элемент равен нулю, то нужно поменять две строки местами и их свободные коэффициенты.
                ChangeZeroLine(ref matrix1, ref determinantCoeff, line, column, k, out bool flagZero);

                if (!flagZero)
                {
                    continue;
                }

                for (var i = k + 1; i < line; i++)
                {
                    // Поэлементово отнимаем от не первых строк первую, умноженную на нужный коэффициент.
                    for (var j = k + 1; j < line; j++)
                    {
                        matrix1[i, j] -= Math.Round(matrix1[k, j] * (matrix1[i, k] / matrix1[k, k]), 12);
                    }

                    // Делаем то же самое, только со свободными коэффициентами. (Для решения СЛАУ)
                    if (line == column - 1)
                    {
                        matrix1[i, column - 1] -= Math.Round(matrix1[k, column - 1] * (matrix1[i, k] / matrix1[k, k]), 12);
                    }
                    matrix1[i, k] = 0;
                }                
            }
            Console.WriteLine("\n\t\t Ступенчатый вид вашей матрицы:");
            PrintMatrix(matrix1);
        }   // Конец метода TheGaussMethod.


        /// <summary>
        /// Метод, который меняет строки местами, если ведущий элемент равен нулю.
        /// </summary>
        /// <param name="matrix1">Матрица.</param>
        /// <param name="determinantCoeff">Переменная, чтобы отследить знак определителя, 
        /// так как мы могли менять строки местами.</param>
        /// <param name="line">Количество строк.</param>
        /// <param name="column">Количество столбцов.</param>
        /// <param name="k">Переменная из цикла for, отвечающая за перемещение по матрице.</param>
        /// <param name="flagZero"></param>
        private static void ChangeZeroLine(ref double[,] matrix1, ref double determinantCoeff, int line, int column, int k, out bool flagZero)
        {
            flagZero = false;
            int countZeroInColumn = 0;
            if (matrix1[k, k] == 0)
            {
                for (var r = line - k - 1; r > 0; r--)
                {
                    if (matrix1[k + r, k] != 0)
                    {
                        double helpVariable;
                        // k - старая строка, k + r - новая строка, меняем их местами.   
                        for (var q = 0; q < line; q++)
                        {
                            helpVariable = matrix1[k, q];
                            matrix1[k, q] = matrix1[k + r, q];
                            matrix1[k + r, q] = helpVariable;
                        }
                        // Делаем то же самое, только со свободными коэффициентами. (Для решения СЛАУ)
                        if (line == column - 1)
                        {
                            helpVariable = matrix1[k, column - 1];
                            matrix1[k, column - 1] = matrix1[k + r, column - 1];
                            matrix1[k + r, column - 1] = helpVariable;
                        }
                        flagZero = true;
                        determinantCoeff *= -1;
                        break;
                    }
                    else countZeroInColumn++;
                }
                if (countZeroInColumn == line - 1)
                    flagZero = false;
            }
            else flagZero = true;
        }


        /// <summary>
        /// Метод, проверяющий на наличие нулевых строк и столбцов.
        /// </summary>
        /// <param name="matrix1">Матрица.</param>
        /// <param name="line">Количество строк.</param>
        /// <param name="column">Количество столбцов.</param>
        /// <param name="flagZeroLine">bool, есть ли полность нулевая строка или нулевой столбец.</param>
        static void CheckZeroLine(double[,] matrix1, int line, int column, ref bool flagZeroLine)
        {
            // Проверка строк на нули.
            for (var i = 0; i < line; i++)
            {
                int countZero = 0;
                for (var j = 0; j < line; j++)
                {
                    if (Math.Abs(matrix1[i, j]) == 0)
                    {
                        countZero++;
                    }
                    else break;
                }
                if (countZero == column - 1)
                {
                    flagZeroLine = true;                    
                    if (Math.Abs(matrix1[i, line]) != 0)
                    {
                        Console.WriteLine("\n\t\t Решений нет!");
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t Решений бесконечное множество!");
                    }
                    break;
                }
            }

        }

        /// <summary>
        /// Метод для 8 задания, который вычисляет корни уравнения.
        /// </summary>
        /// <param name="flagZeroLine">bool есть ли линия из нулей.</param>
        /// <param name="line">Количество строк.</param>
        /// <param name="matrix1">Матрица Ступенчатого вида.</param>
        private static void GetSolution(bool flagZeroLine, int line, double[,] matrix1)
        {
            double[] solutionEquation = new double[line];
            if (!flagZeroLine)
            {
                for (var k = line - 1; k >= 0; k--)
                {
                    double freeEquation = 0;
                    // Подставляются все известные корни значения переменных + свободный коэффициент.
                    for (var j = k + 1; j < line; j++)
                        freeEquation += matrix1[k, j] * solutionEquation[j];
                    // Находим корень, как в линейном уравнении и избавляемся от -0.
                    solutionEquation[k] = (matrix1[k, line] - freeEquation) / matrix1[k, k];
                    if (Math.Round(Math.Abs(solutionEquation[k]), 12) == 0)
                        solutionEquation[k] = 0;
                }
                bool flagInfinity = false, flagNan = false;
                for (int g = 0; g < line; g++)
                {
                    // Проверка на бесконечность среди решений.
                    if (double.IsInfinity(solutionEquation[g]))
                    {
                        flagInfinity = true;
                        flagNan = false;
                        Console.WriteLine("\n\t\t Решений нет!");
                        break;
                    }
                    // Проверка значения на "не число" среди решений.
                    if (double.IsNaN(solutionEquation[g]))
                        flagNan = true;
                }
                if (flagNan)
                    Console.WriteLine("\n\t\t Решений бесконечное множество!");
                else
                {
                    if (!flagInfinity)
                    {
                        Console.WriteLine("\n\t\t Система имеет следующие корни:\n");
                        for (var i = 0; i < solutionEquation.Length; i++)
                            Console.WriteLine($"\t\t\t x{i + 1} = {Math.Round(solutionEquation[i], 3)}");
                    }
                }                
            }
        }   // Конец метода Solution.


        /// <summary>
        /// Метод для печати матриц.
        /// </summary>
        /// <param name="matrix">Матрица для печати.</param>
        public static void PrintMatrix(double[,] matrix)
        {
            // Поэлементовая печать матрицы.
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("\n\t\t");
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + "{0,6}", Math.Round(matrix[i, j], 2), " ");
                }
            }
            Console.WriteLine();
        }   // Конец метода PrintMatrix.


        /// <summary>
        /// Метод для получения числа типа uint.
        /// </summary>
        /// <returns>Полученное число типа uint.</returns>
        public static uint ValidUint()
        {
            uint number;
            string numberStr;
            do
            {
                numberStr = Console.ReadLine();
                if (!(uint.TryParse(numberStr, out number)))
                {
                    Console.WriteLine("\n\t   Вы вели не целое число! ( либо оно слишком большое, либо отрицательное)");
                    Console.Write("\n\t Напоминаю, вы должны ввести целое число от 0 до 20: ");
                }
                else if (!(number > 0 & number <= 20))
                {
                    Console.WriteLine("\n\t   Вы ввели целое число не принадлежащее промежутку от 0 до 20!");
                    Console.Write("\n\t Напоминаю, вы должны ввести целое число от 0 до 20: ");
                }

            } while (!(uint.TryParse(numberStr, out number) && number > 0 && number <= 20));

            return number;
        }   // Конец метода ValidUint.


        /// <summary>
        /// Метод для получения числа типа double.
        /// </summary>
        /// <returns>Полученное число типа double.</returns>
        public static double ValidDouble()
        {
            double number;
            string numberStr;
            do
            {
                numberStr = Console.ReadLine();
                if (!double.TryParse(numberStr, out number))
                {
                    Console.WriteLine("\n\t   Вы ввели не число! (либо оно слишком большое)");
                    Console.Write("\n\t Напоминаю, вы должны ввести целое или дробное число от -2000 до 2000: ");
                }
                else if (!(number >= -2000 && number <= 2000))
                {
                    Console.WriteLine("\n\t   Вы ввели число не принадлежащее промежутку от -2000 до 2000.");
                    Console.Write("\n\t Напоминаю, вы должны ввести целое или дробное число от -2000 до 2000: ");
                }

            } while (!(double.TryParse(numberStr, out number) && number >= -2000 && number <= 2000));
            Console.WriteLine();

            return number;
        }   // Конец метода ValidDouble.
    }
}