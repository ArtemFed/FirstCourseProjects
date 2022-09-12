namespace EKRLib
{
    public abstract class Transport
    {
        /// <summary>
        /// Приватное поле - модель транспорта.
        /// </summary>
        private string model;

        /// <summary>
        /// Свойство - модель транспорта.
        /// </summary>
        private protected string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value.Length != 5)
                {
                    throw new TransportException($"Недопустимая модель {value}");
                }
                foreach (char ch in value)
                {
                    if (!(ch < 48 || ch >= 58) && !(ch < 65 || ch >= 91))
                    {
                        throw new TransportException($"Недопустимая модель {value}");
                    }
                }
                model = value;
            }
        }

        /// <summary>
        /// Приватное поле - мощность транспорта.
        /// </summary>
        private uint power;

        /// <summary>
        /// Свойство - Мощность в лошадиных силах,
        /// </summary>
        private protected uint Power
        {
            get
            {
                return power;
            }
            private set
            {
                if (value < 20)
                {
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                }
                power = value;
            }
        }

        /// <summary>
        /// Общий конструктор транспорта.
        /// </summary>
        /// <param name="model">Модель транспорта.</param>
        /// <param name="power">Мощность транспорта.</param>
        private protected Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }


        /// <summary>
        /// Метод для получения звука издаваемого транспортным средством.
        /// </summary>
        /// <returns>Звук</returns>
        public abstract string StartEngine();


        /// <summary>
        /// Получение всей информации о транспорте.
        /// </summary>
        /// <returns>Вся информация о транспорте в виде Model: {M}, Power: {P}</returns>
        public override string ToString() => $"Model: {Model}, Power: {Power} ";
    }
}
