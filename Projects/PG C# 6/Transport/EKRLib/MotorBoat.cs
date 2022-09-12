namespace EKRLib
{
    /// <summary>
    /// Моторная лодка - наследник транспорта.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор моторной лодки.
        /// </summary>
        /// <param name="model">Модель автомобиля.</param>
        /// <param name="power">Мощность автомобиля.</param>
        public MotorBoat(string model, uint power) : base(model, power)
        {
        }

        /// <summary>
        /// Вернуть звук моторной лодки.
        /// </summary>
        /// <returns>Звук.</returns>
        public override string StartEngine() => $"{Model}: Brrrbrr";

        /// <summary>
        /// Вернуть информацию о моторной лодке.
        /// </summary>
        /// <returns>Информация.</returns>
        public override string ToString() => $"MotorBoat. {base.ToString()}";
    }
}
