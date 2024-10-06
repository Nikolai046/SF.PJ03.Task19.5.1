using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс MessageSendingView предоставляет интерфейс для отправки сообщений в социальной сети.
/// Пользователь вводит email получателя и текст сообщения, которые затем передаются в MessageService для отправки.
/// В зависимости от результата, выводится сообщение об успешной отправке или ошибке (например, получатель не найден).
/// </summary>
public class MessageSendingView
{
    private IUserService userService;
    private MessageService messageService;

    public MessageSendingView(MessageService messageService, IUserService userService)
    {
        this.messageService = messageService;
        this.userService = userService;
    }

    public void Show(User user)
    {
        var messageSendingData = new MessageSendingData();

        Console.Write("\nВведите почтовый адрес получателя: ");
        messageSendingData.RecipientEmail = Console.ReadLine();

        Console.WriteLine("Введите сообщение (не больше 5000 символов): ");
        messageSendingData.Content = Console.ReadLine();

        messageSendingData.SenderId = user.Id;

        try
        {
            messageService.SendMessage(messageSendingData);

            SuccessMessage.Show("Сообщение успешно отправлено!");

            // return userService.FindById(user.Id);
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }
        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при отправке сообщения!");
        }
    }
}