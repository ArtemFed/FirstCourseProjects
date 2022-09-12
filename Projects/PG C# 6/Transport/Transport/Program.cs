using EKRLib;
using System;
using System.IO;
using System.Text;

namespace TransportPG6
{
    internal class Program
    {
        /// <summary>
        /// Рандом.
        /// </summary>
        private static readonly Random random = new();

        /// <summary>
        /// Массив всех транспортов.
        /// </summary>
        private static Transport[] transports;

        /// <summary>
        /// Метод с реализацией основной программы.
        /// </summary>
        public static void Main()
        {
            ConsoleKey buttonPressEnd;
            do
            {
                Console.Clear();

                transports = new Transport[random.Next(6, 10)];

                try
                {
                    CreateAndWrite();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message +
                        "\nПроизошла ошибка при получении доступа к файлу! " +
                        "Попробуйте закрыть все остальные приложения, которые используют файл!");
                }
                catch
                {
                    Console.WriteLine("Произошла ошибка, пропробуйте ещё раз)");
                }

                Console.WriteLine("\n\nТранспорт создан и записан!" +
                       "\nХотите создать новый набор транспорта? Нажмите любую кнопку, иначе Escape.");
                buttonPressEnd = Console.ReadKey(true).Key;

                // Задержка в 500мс, чтобы у пользователя было время подумать).
                System.Threading.Thread.Sleep(500);

            } while (buttonPressEnd != ConsoleKey.Escape);
        }


        /// <summary>
        /// Метод для создания одного транспорта и записи его информации на экран и в файл.
        /// </summary>
        /// <exception cref="TransportException">Ошибка при создании транспорта.</exception>
        private static void CreateAndWrite()
        {
            char altSep = Path.DirectorySeparatorChar;
            string path = $"{altSep}..{altSep}..{altSep}..{altSep}..{Path.DirectorySeparatorChar}";
            using (StreamWriter fileForCar =
                new(File.Create($"{Directory.GetCurrentDirectory()}{path}Cars.txt"),
                new UnicodeEncoding()),
                fileForMotorBoat =
                new(File.Create($"{Directory.GetCurrentDirectory()}{path}MotorBoats.txt"),
                new UnicodeEncoding()))
            {
                Console.WriteLine("Созданный транспорт:");
                for (int i = 0; i < transports.Length; i++)
                {
                    try
                    {
                        transports[i] = random.Next(2) switch
                        {
                            0 => new Car(GetRandomModel(), (uint)random.Next(10, 100)),
                            1 => new MotorBoat(GetRandomModel(), (uint)random.Next(10, 100)),
                            _ => throw new TransportException(),
                        };

                        Console.WriteLine(transports[i].StartEngine());

                        if (transports[i] is Car)
                            fileForCar.WriteLine(transports[i].ToString());
                        else
                            fileForMotorBoat.WriteLine(transports[i].ToString());

                    }
                    catch (TransportException ex)
                    {
                        Console.WriteLine(ex.Message);
                        --i;
                    }
                }
            }
        }


        /// <summary>
        /// Создать случайную модель.
        /// </summary>
        /// <returns></returns>
        private static string GetRandomModel()
        {
            StringBuilder sBuilder = new();
            for (int i = 0; i < 5; i++)
            {
                // Случайная генерация символов. Вероятность 50% на выбор между цифрой и латинской буквой.
                // Затем генерируется случайное значение кода символа для char.
                sBuilder.Append(random.Next(2) == 0 ? (char)random.Next(48, 58) : (char)random.Next(65, 91));
            }
            return sBuilder.ToString();
        }
    }
}
