using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс UserInfoView предоставляет интерфейс для отображения полной информации о профиле пользователя в социальной сети.
/// Отображаются такие данные, как идентификатор пользователя, имя, фамилия, пароль, email, ссылка на фото, любимый фильм и книга.
/// </summary>
public class UserInfoView
{
    public void Show(User user)
    {
        Console.WriteLine("\nИнформация о моем профиле");
        Console.WriteLine("Мой идентификатор: {0}", user.Id);
        Console.WriteLine("Меня зовут: {0}", user.FirstName);
        Console.WriteLine("Моя фамилия: {0}", user.LastName);
        Console.WriteLine("Мой пароль: {0}", user.Password);
        Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
        Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
        Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
        Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
    }
}