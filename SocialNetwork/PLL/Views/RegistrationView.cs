using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс RegistrationView предоставляет интерфейс для регистрации нового пользователя в социальной сети.
/// Пользователь вводит свои данные (имя, фамилию, пароль и email), которые затем передаются в UserService для создания нового профиля.
/// В случае успеха отображается сообщение об успешной регистрации, в противном случае выводятся ошибки (например, некорректные данные).
/// </summary>
public class RegistrationView
{
    private IUserService userService;

    public RegistrationView(IUserService userService)
    {
        this.userService = userService;
    }

    public void Show()
    {
        var userRegistrationData = new UserRegistrationData();

        Console.WriteLine("\nДля создания нового профиля введите:");

        Console.Write("Ваше имя: ");
        userRegistrationData.FirstName = Console.ReadLine();

        Console.Write("Вашу фамилию: ");
        userRegistrationData.LastName = Console.ReadLine();

        Console.Write("Пароль:");
        userRegistrationData.Password = Console.ReadLine();

        Console.Write("Почтовый адрес:");
        userRegistrationData.Email = Console.ReadLine();

        try
        {
            this.userService.Register(userRegistrationData);

            SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение.");
        }
        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при регистрации.");
        }
    }
}