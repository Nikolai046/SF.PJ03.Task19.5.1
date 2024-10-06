using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Extencions;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс AddingFriendView предоставляет интерфейс для добавления друга в социальной сети.
/// Он запрашивает у пользователя ввод email друга и обрабатывает добавление через UserService.
/// В зависимости от результата, отображаются соответствующие сообщения об успехе или ошибке.
/// </summary>
public class AddingFriendView
{
    private IUserService userService;
    private IConsoleReader consoleReader;

    public AddingFriendView(IUserService userService, IConsoleReader consoleReader)
    {
        this.userService = userService;
        this.consoleReader = consoleReader;
    }

    public void Show(User user)
    {
        Console.WriteLine("Введите e-mail пользователя, которого хотите добавить в друзья:");
        var friendEmail = consoleReader.ReadLine();
        try
        {
            userService.AddFriendBy(new UserFriendData(user.Id, friendEmail));
            SuccessMessage.Show("Пользователь успешно добавлен в друзья");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь с таким email не найден.");
        }
        catch (CannotAddYourselfException)
        {
            AlertMessage.Show("Нельзя добавить самого себя");
        }
        catch (FriendAlreadyExistException)
        {
            AlertMessage.Show("Пользователь уже добавлен в друзья.");
        }
        catch (Exception)
        {
            AlertMessage.Show($"Произошла ошибка при добавлении друга");
        }

        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
        // Console.ReadKey();
    }
}