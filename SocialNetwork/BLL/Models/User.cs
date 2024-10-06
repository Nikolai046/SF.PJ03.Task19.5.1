using SocialNetwork.DAL.Entities;

namespace SocialNetwork.BLL.Models;

/// <summary>
/// Класс User представляет модель пользователя в социальной сети.
/// Содержит основные свойства, такие как имя, фамилия, пароль, почта, фото,
/// любимый фильм и книга, а также коллекции входящих и исходящих сообщений и друзей.
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Электронная почта пользователя.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Ссылка на фотографию пользователя.
    /// </summary>
    public string Photo { get; set; }

    /// <summary>
    /// Любимый фильм пользователя.
    /// </summary>
    public string FavoriteMovie { get; set; }

    /// <summary>
    /// Любимая книга пользователя.
    /// </summary>
    public string FavoriteBook { get; set; }

    /// <summary>
    /// Коллекция входящих сообщений пользователя.
    /// </summary>
    public IEnumerable<Message> IncomingMessages { get; }

    /// <summary>
    /// Коллекция исходящих сообщений пользователя.
    /// </summary>
    public IEnumerable<Message> OutgoingMessages { get; }

    /// <summary>
    /// Коллекция друзей пользователя.
    /// </summary>
    public IEnumerable<FriendEntity> Friends { get; }

    /// <summary>
    /// Конструктор класса User, инициализирующий все основные свойства.
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <param name="firstName">Имя пользователя</param>
    /// <param name="lastName">Фамилия пользователя</param>
    /// <param name="password">Пароль пользователя</param>
    /// <param name="email">Электронная почта пользователя</param>
    /// <param name="photo">Ссылка на фотографию</param>
    /// <param name="favoriteMovie">Любимый фильм</param>
    /// <param name="favoriteBook">Любимая книга</param>
    /// <param name="incomingMessages">Коллекция входящих сообщений</param>
    /// <param name="outgoingMessages">Коллекция исходящих сообщений</param>
    /// <param name="friends">Коллекция друзей</param>
    public User(int id, string firstName, string lastName, string password, string email,
                string photo, string favoriteMovie, string favoriteBook,
                IEnumerable<Message> incomingMessages, IEnumerable<Message> outgoingMessages,
                IEnumerable<FriendEntity> friends)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Password = password;
        this.Email = email;
        this.Photo = photo;
        this.FavoriteMovie = favoriteMovie;
        this.FavoriteBook = favoriteBook;
        this.IncomingMessages = incomingMessages;
        this.OutgoingMessages = outgoingMessages;
        this.Friends = friends;
    }
}