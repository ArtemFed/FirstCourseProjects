namespace EKRLib
{
    /// <summary>
    /// Автомобиль - наследник транспорта.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор автомобиля.
        /// </summary>
        /// <param name="model">Модель автомобиля.</param>
        /// <param name="power">Мощность автомобиля.</param>
        public Car(string model, uint power) : base(model, power)
        {
        }

        /// <summary>
        /// Метод для создания автомобиля.
        /// </summary>
        /// <param name="model">Модель автомобиля.</param>
        /// <param name="power">Мощность автомобиля.</param>
        /// <returns>Созданный автомобиль</returns>
        public static Car CreateCar(string model, uint power) => new Car(model, power);

        /// <summary>
        /// Вернуть звук автомобиля.
        /// </summary>
        /// <returns>Звук.</returns>
        public override string StartEngine() => $"{Model}: Vroom";

        /// <summary>
        /// Вернуть информацию об автомобиле.
        /// </summary>
        /// <returns>Информация.</returns>
        public override string ToString() => $"Car. {base.ToString()}";
    }
}
