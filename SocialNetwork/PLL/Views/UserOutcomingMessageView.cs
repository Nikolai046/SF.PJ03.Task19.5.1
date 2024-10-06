using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс UserOutcomingMessageView предоставляет интерфейс для отображения списка исходящих сообщений пользователя в социальной сети.
/// Если у пользователя есть исходящие сообщения, они выводятся с указанием получателя и содержимого сообщения.
/// Если исходящих сообщений нет, выводится сообщение об их отсутствии.
/// </summary>
public class UserOutcomingMessageView
{
    public void Show(IEnumerable<Message> outcomingMessages)
    {
        Console.WriteLine("\nИсходящие сообщения:");

        if (outcomingMessages.Count() == 0)
        {
            Console.WriteLine("Исходящих сообщений нет");
            return;
        }

        outcomingMessages.ToList().ForEach(message =>
        {
            Console.WriteLine("\nКому: {0}.\nТекст сообщения: {1}", message.RecipientEmail, message.Content);
        });
    }
}