namespace SocialNetwork.BLL.Models;

/// <summary>
/// Модель данных для аутентификации пользователя.
/// </summary>
public class UserAuthenticationData
{
    public string Email { get; set; }
    public string Password { get; set; }
}