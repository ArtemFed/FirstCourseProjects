namespace MessageService.Models
{
    /// <summary>
    /// Класс сообщения (письма).
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Тема.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Номер отправитель (Id).
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        /// Номер получателя (Id).
        /// </summary>
        public string ReceiverId { get; set; }

        /// <summary>
        /// Конструктор сообщения (письма).
        /// </summary>
        /// <param name="subject">Тема.</param>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="senderId">Почта отправитель.</param>
        /// <param name="receiverId">Почта получателя.</param>
        public Letter(string subject, string message, string senderId, string receiverId)
        {
            Subject = subject;
            Message = message;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}