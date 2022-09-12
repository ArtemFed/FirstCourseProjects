namespace MessageService.Models
{
    /// <summary>
    /// Класс пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        public string Email { get; set; }
                

        /// <summary>
        /// Конструктор пользователя.
        /// </summary>
        /// <param name="userName">Имя.</param>
        /// <param name="email">Почта.</param>
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;            
        }
    }
}