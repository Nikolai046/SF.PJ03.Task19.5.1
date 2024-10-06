using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс UserDataUpdateView предоставляет интерфейс для обновления профиля пользователя в социальной сети.
/// Пользователь может обновить свое имя, фамилию, фото, любимый фильм и книгу.
/// Обновленные данные передаются в UserService для сохранения изменений.
/// В случае успешного обновления выводится сообщение об успехе.
/// </summary>
public class UserDataUpdateView
{
    private IUserService userService;

    public UserDataUpdateView(IUserService userService)
    {
        this.userService = userService;
    }

    public void Show(User user)
    {
        Console.Write("\nМеня зовут: ");
        user.FirstName = Console.ReadLine();

        Console.Write("Моя фамилия: ");
        user.LastName = Console.ReadLine();

        Console.Write("Ссылка на моё фото: ");
        user.Photo = Console.ReadLine();

        Console.Write("Мой любимый фильм: ");
        user.FavoriteMovie = Console.ReadLine();

        Console.Write("Моя любимая книга: ");
        user.FavoriteBook = Console.ReadLine();

        this.userService.Update(user);

        SuccessMessage.Show("Ваш профиль успешно обновлён!");
    }
}