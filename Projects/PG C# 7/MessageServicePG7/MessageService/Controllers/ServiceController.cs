using MessageService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MessagesService.Controllers
{
    /// <summary>
    /// Класс для реализации сервиса сообщений.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : Controller
    {

        /// <summary>
        /// Путь к Json файлу с пользователями.
        /// </summary>
        private string PathUser { get; } = "users.json";

        /// <summary>
        /// Путь к Json файлу с сообщениями.
        /// </summary>
        private string PathMessage { get; } = "messages.json";

        /// <summary>
        /// Количество сообщений.
        /// </summary>
        private int CountOfUsers { get; set; } = 5;

        /// <summary>
        /// Лист пользователей.
        /// </summary>
        private static List<User> Users { get; set; } = new();

        /// <summary>
        /// Лист писем.
        /// </summary>
        private static List<Letter> Messages { get; set; } = new();

        /// <summary>
        /// Экземпляр рандома.
        /// </summary>
        private readonly Random random = new();


        /// <summary>
        /// Получение пользователей. (ДОП3)
        /// </summary>
        /// <param name="offset">Индекс первого пользователя с нуля.</param>
        /// <param name="limit">Количество пользователей.</param>
        /// <returns>Пользователи</returns>
        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers([Required] int offset, [Required] int limit)
        {
            try
            {
                if (offset < 0 || limit <= 0) return BadRequest();
                if (offset >= Users.Count) return BadRequest("Такой индекс пользователя не существует.");
                limit = offset + limit >= Users.Count ? Users.Count - offset : limit;
                return Ok(Users.GetRange(offset, limit));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение всех сообщений.
        /// </summary>
        /// <returns>Сообщения.</returns>
        [HttpGet("GetMessages")]
        public IActionResult GetAllMessages()
        {
            try
            {
                if (Messages.Count == 0)
                {
                    return NotFound("Сообщений нет!");
                }
                return Ok(Messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение пользователей из JSON файла.
        /// </summary>
        /// <returns>Пользователи.</returns>
        [HttpGet("GetUsersFromFile")]
        public IActionResult GetUsers()
        {
            try
            {
                if (!System.IO.File.Exists(PathUser)) return NotFound();
                return Ok(Users = JsonSerializer.Deserialize<List<User>>(System.IO.File.ReadAllText(PathUser)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение сообщений из JSON файла.
        /// </summary>
        /// <returns>Сообщения.</returns>
        [HttpGet("GetMessagesFromFile")]
        public IActionResult GetMessages()
        {
            try
            {
                if (!System.IO.File.Exists(PathMessage)) return NotFound();
                return Ok(Messages = JsonSerializer.Deserialize<List<Letter>>(System.IO.File.ReadAllText(PathMessage)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение пользователя по его почте.
        /// </summary>
        /// <param name="email">Почта пользователя.</param>
        /// <returns>Пользователь.</returns>
        [HttpGet("GetUserByEmail")]
        public IActionResult GetUser([Required] string email)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound(ModelState);

                var storedProduct = Users.SingleOrDefault(p => p.Email == email);

                if (storedProduct == null) return NotFound();

                return Ok(storedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение сообщений по их получателю и отправителю.
        /// </summary>
        /// <param name="senderId">Почта отправителя.</param>
        /// <param name="receiverId">Почта получателя.</param>
        /// <returns>Сообщения.</returns>
        [HttpGet("GetMessagesBySenderAndReceiverId")]
        public IActionResult GetMessagesBySenderAndReceiverId([Required] string senderId, [Required] string receiverId)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound(ModelState);

                var storedProduct = Messages.Where(mes => mes.SenderId == senderId && mes.ReceiverId == receiverId);

                if (storedProduct.ToList().Count == 0) return NotFound();

                return Ok(storedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение сообщений по их отправителю.
        /// </summary>
        /// <param name="senderId">Почта отправителя.</param>
        /// <returns>Сообщения/</returns>
        [HttpGet("GetMessagesBySenderId")]
        public IActionResult GetMessagesBySenderId([Required] string senderId)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound(ModelState);

                var storedProduct = Messages.Where(mes => mes.SenderId == senderId);

                if (storedProduct.ToList().Count == 0) return NotFound();

                return Ok(storedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Получение сообщений по их получателю.
        /// </summary>
        /// <param name="receiverId">Почта получателя.</param>
        /// <returns>Сообщения.</returns>
        [HttpGet("GetMessagesByReceiverId")]
        public IActionResult GetMessagesByReceiverId([Required] string receiverId)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound(ModelState);

                var storedProduct = Messages.Where(mes => mes.ReceiverId == receiverId);

                if (storedProduct.ToList().Count == 0) return NotFound();

                return Ok(storedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Добавление пользователя. (ДОП1)
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="email">Почта пользователя.</param>
        /// <returns>Сообщения.</returns>
        [HttpPost("PostAddUser")]
        public IActionResult PostAddUser([Required] string name, [Required] string email)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound(ModelState);

                if (Users.SingleOrDefault(pers => pers.Email == email) != null)
                    return BadRequest("Пользователь с такой почтой уже существует!");

                User person = new(name, email);                

                Users.Add(person);
                SortUsers();
                SerializeData(Users);

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Добавление сообщения. (ДОП2)
        /// </summary>
        /// <param name="subject">Тема сообщения.</param>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="senderId">Почта пользователя-отправителя.</param>
        /// <param name="receiverId">Имя пользователя-получателя.</param>
        /// <returns>Сообщения.</returns>
        [HttpPost("PostAddMessage")]
        public IActionResult PostAddMessage(
            [Required] string subject, [Required] string message, [Required] string senderId, [Required] string receiverId)
        {
            try
            {
                if (!ModelState.IsValid) return NotFound(ModelState);

                if (Users.TrueForAll(x => x.Email != senderId) || Users.TrueForAll(x => x.Email != receiverId)) 
                    return BadRequest("Такого отправителя или получателя не существует");

                Letter letter = new(subject, message, senderId, receiverId);

                Messages.Add(letter);
                SerializeData(Messages);

                return Ok(letter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Сортировка пользователей по email.
        /// </summary>
        private static void SortUsers() => Users = Users.OrderBy(x => x.Email).ToList();


        /// <summary>
        /// Генерация случайного имени.
        /// </summary>
        /// <param name="isEmail">Генерировать почту или только имя?</param>
        /// <returns>Имя.</returns>
        private string GetRandomName(bool isEmail)
        {
            var sb = new StringBuilder();
            sb.Append((char)random.Next('A', 'Z' + 1));
            for (int i = 0; i < random.Next(2, 7); i++)
            {
                sb.Append(random.Next(4) == 0 ? (char)random.Next('1', '9' + 1) : random.Next(3) == 0 ?
                    (char)random.Next('A', 'Z' + 1) : (char)random.Next('a', 'z' + 1));
            }

            if (isEmail)
            {
                sb.Append(random.Next(5) switch
                {
                    0 => "@gmail.com",
                    1 => "@yandex.ru",
                    2 => "@rambler.ru",
                    3 => "@edu.hse.ru",
                    _ => "@mail.ru"
                });
            }
            return sb.ToString();
        }


        /// <summary>
        /// Метод для сериализации листа.
        /// </summary>
        /// <typeparam name="T">Тип элементов листа.</typeparam>
        /// <param name="list">Лист объектов для сериализации.</param>
        private void SerializeData<T>(List<T> list) => System.IO.File.WriteAllText(list[0] is User ? PathUser : PathMessage, JsonSerializer.Serialize(list));


        /// <summary>
        /// Post метод для создания случайных пользователей.
        /// </summary>
        /// <returns>Пользователи.</returns>
        [HttpPost("PostRandomUsers")]
        public IActionResult PostUsers()
        {
            // HashSet гарантирует различных пользователей.
            HashSet<User> users = new();
            while (users.Count < CountOfUsers)
            {
                string userName = GetRandomName(false);
                users.Add(new User(userName, userName + "_" + GetRandomName(true)));
            }
            try
            {
                Users = users.ToList();
                SortUsers();
                SerializeData(Users);
                return Ok(Users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Post метод для создания случайных сообщений.
        /// </summary>
        /// <returns>Сообщения.</returns>
        [HttpPost("PostRandomMessage")]
        public IActionResult PostMessage()
        {
            try
            {
                if (Users.Count == 0) return BadRequest("Пользователей нет! Восстания машин пока нет, поэтому писать никто не может.");

                // HashSet гарантирует создание различных сообщений.
                HashSet<Letter> letters = new();
                while (letters.Count < Users.Count * 3)
                {
                    string subject = GetRandomName(false) + GetRandomName(false);
                    string message = GetRandomName(false) + GetRandomName(false)
                        + GetRandomName(false) + GetRandomName(false);

                    letters.Add(new Letter(subject, message,
                        Users[random.Next(0, Users.Count)].Email, Users[random.Next(0, Users.Count)].Email));
                }

                Messages = letters.ToList();
                SerializeData(Messages);

                return Ok(Messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}