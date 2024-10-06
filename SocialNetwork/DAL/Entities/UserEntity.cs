namespace SocialNetwork.DAL.Entities;

/// <summary>
/// Класс UserEntity представляет сущность пользователя в базе данных.
/// Содержит основные данные о пользователе, такие как имя, фамилия, пароль, почта, фото, любимый фильм и книга.
/// </summary>
public class UserEntity
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string firstname { get; set; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string lastname { get; set; }

    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string password { get; set; }

    /// <summary>
    /// Электронная почта пользователя.
    /// </summary>
    public string email { get; set; }

    /// <summary>
    /// Ссылка на фотографию пользователя.
    /// </summary>
    public string photo { get; set; }

    /// <summary>
    /// Любимый фильм пользователя.
    /// </summary>
    public string favorite_movie { get; set; }

    /// <summary>
    /// Любимая книга пользователя.
    /// </summary>
    public string favorite_book { get; set; }
}