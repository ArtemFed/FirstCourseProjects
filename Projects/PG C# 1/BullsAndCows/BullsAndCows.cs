using System;

namespace PeerGrade1
{
    /// <summary>
    /// Класс для реализации игры "Bulls and Cows"
    /// </summary>
    class Program
    {

        /// <summary>
        /// Основной метод, объединение информации полученной с помощью других методов.
        /// </summary>
        static void Main()
        {
            TextRules();

            // Цикл ответственный за то, чтобы можно было перезапускать игру по её завершении.
            do
            {
                // Число, которок случайно сгенерировал Компьютер.
                string compNumberStr;

                // Обращение к методу "Difficulty". Получение длинны числа (сложности игры) от Пользователя .
                Difficulty(out int difficultyLength, out bool limitOfTry);

                // Обращение к методу "RandomCompStr". Получение случайного числа от Компьютера.
                compNumberStr = RandomCompStr(difficultyLength);

                // Время отгадывания
                DateTime timeStart = DateTime.Now;

                // Обращение к методу "CalcBullsAndCows".Обратоботка попыток и получение итогового числа попыток.
                CalcBullsAndCows(difficultyLength, compNumberStr, limitOfTry, out int finalCountTry, out bool flagTry);

                // Зафиксировали время отгадывания
                DateTime timeEnd = DateTime.Now;
                double totalTime = Math.Round((timeEnd - timeStart).TotalSeconds);

                if (flagTry)
                    Console.WriteLine($"\n Поздравляю! Вы угадали моё число всего с {finalCountTry} попытки!" +
                        $"\n Вы справились за " + totalTime + " секунд(ы)! " +
                        $"\n Это было число:  {compNumberStr}");
                else Console.WriteLine($"\n Печально... Вы не справились с заданием, у вас кончились попытки. " +
                        $"\n Это было число:  {compNumberStr}");

                Console.WriteLine("\n Хотите начать заново? Нажмите любую кнопку, иначе \"Escape\" \n\n");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }   // Конец метода "Main".


        /// <summary>
        /// Общение с Пользователем (правила и пояснения).
        /// </summary>
        static void TextRules()
        {
            Console.WriteLine("\t\tИгра \"Bulls and Cows\".\n" +
                "\n Общие правила игры \"Bulls and Cows\":" +
                "\n   1. Компьютер загадывает случайное число, состоящее из неповторяющихся цифр." +
                "\n   2. Пользователь пытаеться угадать это число, называя свои." +
                "\n   3. Компьютер отвечает количеством \"Быков\" (Bull) и \"Коров\" (Cow). " +
                "\n Хотите ознакомиться с дополительными правилами и пояснениями к игре? " +
                "\n Тогда нажмите кнопку \"I\" (information) или \"И\" (информация), иначе любую другую клавишу.");

            // Считываю нажатую кнопку
            var buttonPress1 = Console.ReadKey(true).Key;

            if (buttonPress1 == ConsoleKey.I | buttonPress1 == ConsoleKey.B)
                Console.WriteLine("\n Дополительные правила и пояснения к игре:" +
                    "\n   1) \"Корова\" означает то, что цифра есть, но стоит не на том месте, " +
                    "\n   2) \"Бык\" говорит о том, что цифра полностью совпала." +
                    "\n      Напрмер, если будет две \"Коровы\" и один \"Бык\"," +
                    "\n       то это значит, что какие-то две цифры присутствуют в числе, но не на своих местах," +
                    "\n       и одна полность совпала и значением и местом." +
                    "\n   3) В начале игры Вы сами задаёте длину числа от 1 до 10." +
                    "\n   4) Число Компьютера не может начинаться с \"0\"," +
                    "\n       но вы, угадывая число, можете его писать, главное не запутайтесь." +
                    "\n   5) При введении чисел Вы можете добавлять к ним незначащие нули." +
                    "\n   6) Если Вы хотите сдаться, то в любой момент можете нажать Alt + F4 или Ctrl + C." +
                    "\n   7) Вы можете вводить число, состоящее из одинаковых цифр. " +
                    "\n       Так Вам будет проще отгадывать числа на высокой сложности" +
                    "\n   8) Вы можете включить ограничение на количество попыток, (далее Вас спросят об этом)" +
                    "\n       для каждой сложности оно разное и вычисляется по формуле \"Ваша сложность * 4 + 5\" .");

        }  // Конец метода "TextRules".


        /// <summary>
        /// Получение от пользователя длины числа (сложности игры).
        /// </summary>
        /// <returns>Значение длины числа.</returns>
        static int Difficulty(out int difficultyLength, out bool limitOfTry)
        {
            string difficultyLengthStr;
            limitOfTry = false;

            Console.WriteLine("\n Хотите ли Вы включить ограничение на количество попыток?" +
                "Если да, то нажмите кнопку \"Y\" (Yes) или \"Д\" (Да)");

            // Считываю нажатую кнопку
            var buttonPress2 = Console.ReadKey(true).Key;
            if (buttonPress2 == ConsoleKey.Y | buttonPress2 == ConsoleKey.L)
            {
                limitOfTry = true;
                Console.WriteLine(" Ограничение на количество попыток включено!");
            }
            else
            {
                Console.WriteLine(" Ограничение на количество попыток НЕ включено.");
            }

            Console.WriteLine("\n Перед началом игры выберите(введите) уровень сложности от 1 до 10! \n " +
                "(Сложность - это длина числа, которое вам предстоит угадать)");

            // Получение длины числа (сложности) от Пользователя и проверка её на правильность (число от 1 до 10),
            // Пока данные не будут корректны, к следующему шагу не перейти.
            do
            {
                Console.Write("\n Ваша сложность: ");
                difficultyLengthStr = Console.ReadLine();
                if (!(int.TryParse(difficultyLengthStr, out difficultyLength)))
                {
                    Console.WriteLine("\n Вы вели не число!(либо оно слишком большое/маленькое)\n Попробуйте ещё раз");
                }
                else
                {
                    if (!(difficultyLength >= 1) && (difficultyLength <= 10))
                    {
                        Console.WriteLine("\n Сложность превосходит 10 или меньше 1 \n Попробуй ещё раз");
                    }
                }

            } while (!(int.TryParse(difficultyLengthStr, out difficultyLength)
                && (difficultyLength >= 1) && (difficultyLength <= 10)));

            ReactionOnDiff(difficultyLength);

            return difficultyLength;
        }   // Конец метода "Difficulty".


        /// <summary>
        /// Просто реакция на ввод сложности от Пользователя.
        /// </summary>
        /// <param name="difficultyLength">Значение длины числа.</param>
        static void ReactionOnDiff(int difficultyLength)
        {
            switch (difficultyLength)
            {
                case < 3:
                    Console.WriteLine(" Пффф, слишком просто...");
                    break;
                case < 6:
                    Console.WriteLine(" Хороший выбор!");
                    break;
                case < 9:
                    Console.WriteLine(" Смелый поступок!");
                    break;
                case >= 9:
                    Console.WriteLine(" Ух ты, уважаю!");
                    break;
            }

        }


        /// <summary>
        /// Получение от Компьютера случайного числа заданной Пользователем длины.
        /// </summary>
        /// <param name="difficultyLength">Длина числа заданная Пользователем</param>
        /// <returns></returns>
        static string RandomCompStr(int difficultyLength)
        {
            // Получение первой цифры для числа Компьютера от 1 до 9 (без 0).
            var rnd = new Random();
            int indexRandom, firstCharacter = rnd.Next(1, 9);

            // "compNumber" - Строковая переменная, в которой будет "собираться" число.
            string compNumber = firstCharacter.ToString(), numbers = "0123456789";
            char character;

            // Цикл, в котором будет собираться число именно такой длинны,
            // Которую в свою очередь задал Пользователь, без одинаковых цифр (повторений).
            for (int i = 1; i < difficultyLength; i++)
            {
                // Получение случайного индекса для строки со всеми цифрами.
                indexRandom = rnd.Next(0, 10);

                // Получение цифры по случайному индексу.
                character = numbers[indexRandom];

                // Проверка на то, чтобы такая цифра ещё не встречалась, если это не так,
                // То заново получаю цифру по случайному индексу.
                while (compNumber.IndexOf(character) != -1)
                    character = numbers[rnd.Next(0, 10)];

                // Получаю число от компьютера в формате строки.
                compNumber = compNumber + character;

                // P.S. Делал с помощью индексов, чтобы можно было вместо цифр использовать буквы.
                // P.S.S. Чтобы было вообще максимально сложно.
            }
            // Число компьютера(если самому лень думать, то можно раскомментировать)
            //Console.WriteLine(CompNumber);    

            return compNumber;
        }   // Конец метода "RandomCompStr".
        

        /// <summary>
        /// Обработка числа Пользователя и высчитывание на нём значений "Быков" и "Коров".
        /// </summary>
        /// <param name="difficultyLength">Сложность (длина числа), которую задал сам Пользователь.</param>
        /// <param name="compNumberStr">Число, которое случайно сгенерировал Компьютер.</param>
        /// <returns>Число попыток.</returns>
        static int CalcBullsAndCows
            (int difficultyLength, string compNumberStr, bool limitOfTry, out int countTry, out bool flagTry)
        {
            int bull, cow;
            string numberStr;
            countTry = 0;
            flagTry = true;

            // Происходит получение числа от Пользователя, выявление значений Коров и быков.
            // Пока Пользователь польность не угадает число, игра не закончится.
            do
            {
                if (limitOfTry)
                {
                    if (countTry >= (difficultyLength * 4 + 5))
                    {
                        flagTry = false;
                        break;
                    }
                }
                ++countTry;
                // Для каждого нового числа попыток количество "Быков" и "Коров" будет высчитываться заново.
                bull = 0;
                cow = 0;
                Console.WriteLine($"\n Ваша попытка номер - {countTry}");

                // Получение числа от пользователя.
                numberStr = UserNumber(difficultyLength);
                // Проверка каждой цифры в числе с помощью цикла.
                for (int i = 0; i < difficultyLength; i++)
                {
                    // Если такой цифры в числе нет, то индекс будет равен "-1",
                    // Поэтому, если он не равен "-1", то цифра присутствует.
                    if (compNumberStr.IndexOf(numberStr[i]) != -1)
                    {
                        // Если по этому индексу значения совпали, то это "Бык", иначе это "Корова".
                        if (compNumberStr[i] == numberStr[i]) ++bull;
                        else ++cow;
                    }
                }
                Console.WriteLine($" \t Коров: {cow} из {difficultyLength}\n \t Быков: {bull} из {difficultyLength}");
            } while (bull != difficultyLength);
            return countTry;
        }   // Конец метода "CalcBullsAndCows".


        /// <summary>
        /// Получение числа от пользователя.
        /// </summary>
        /// <param name="difficultyLength">Сложность (длина числа), которую задал сам Пользователь.</param>
        /// <returns>Число, которое ввёл пользователь в своей попытке.</returns>
        static string UserNumber(int difficultyLength)
        {
            // Number - Число Пользвателя.
            ulong number;
            // NumberStr - Число Пользвателя в формате строки.
            string numberStr;

            // Ввод числа от Пользвателя и проверка его (числа) на корректность.
            do
            {
                Console.Write(" Введите число, чтобы угадать моё: ");
                numberStr = Console.ReadLine();
                if (!(ulong.TryParse(numberStr, out number)))
                {
                    Console.WriteLine("\n Вы вели не число! (либо оно слишком большое, либо оно отрицательное) " +
                        $"\n Напоминаю, длина Вашего числа должна быть: {difficultyLength}");
                }
                else
                {
                    if (!(difficultyLength == numberStr.Length))
                    {
                        Console.WriteLine("\n Длина вашего числа не совпадает со сложностью " +
                            $"\n Напоминаю, длина Вашего числа должна быть: {difficultyLength} \n");
                    }
                }

            } while (!(ulong.TryParse(numberStr, out number) && (difficultyLength == numberStr.Length)));

            return numberStr;
        }   // Конец метода "UserNumber".
    }
}