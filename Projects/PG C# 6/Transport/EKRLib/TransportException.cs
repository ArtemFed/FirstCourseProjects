using System;

namespace EKRLib
{
    /// <summary>
    /// Мой Exception для транспорта.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Конструктор Exception буз параметров.
        /// </summary>
        public TransportException() { }

        /// <summary>
        /// Конструктор Exception с сообщением.
        /// </summary>
        /// <param name="message">Текс сообщения.</param>
        public TransportException(string message) : base(message) { }

        /// <summary>
        /// Конструктор Exception с сообщением и с ссылкой на вызвавшее исключение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="inner">Ссылка на Exception</param>
        public TransportException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Конструктор для сериализации.
        /// </summary>
        /// <param name="info">Информация</param>
        /// <param name="context"></param>
        protected TransportException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
