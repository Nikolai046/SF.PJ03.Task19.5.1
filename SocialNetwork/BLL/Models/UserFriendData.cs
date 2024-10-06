namespace SocialNetwork.BLL.Models;

/// <summary>
/// Модель данных для добавления друга.
/// </summary>
public class UserFriendData
{
    public int UserId { get; set; }
    public string FriendEmail { get; set; }

    /// <summary>
    /// Конструктор для создания данных о добавлении друга.
    /// </summary>
    /// <param name="userId">ID пользователя, добавляющего друга</param>
    /// <param name="friendEmail">Email добавляемого друга</param>
    public UserFriendData(
        int userId,
        string friendEmail
        )
    {
        UserId = userId;
        FriendEmail = friendEmail;
    }
}