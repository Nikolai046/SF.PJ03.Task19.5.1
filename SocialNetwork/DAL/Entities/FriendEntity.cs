namespace SocialNetwork.DAL.Entities;

/// <summary>
/// Класс FriendEntity представляет сущность дружбы в базе данных.
/// Содержит информацию о связи между пользователем и его другом.
/// </summary>
public class FriendEntity
{
    /// <summary>
    /// Идентификатор записи дружбы.
    /// </summary>
    public int id { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который добавил друга.
    /// </summary>
    public int user_id { get; set; }

    /// <summary>
    /// Идентификатор друга, которого добавил пользователь.
    /// </summary>
    public int friend_id { get; set; }
}