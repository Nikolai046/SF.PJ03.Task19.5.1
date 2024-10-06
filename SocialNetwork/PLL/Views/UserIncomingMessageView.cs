using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс UserIncomingMessageView предоставляет интерфейс для отображения списка входящих сообщений пользователя в социальной сети.
/// Если у пользователя есть входящие сообщения, они выводятся с указанием отправителя и содержимого сообщения.
/// Если входящих сообщений нет, выводится сообщение об их отсутствии.
/// </summary>
public class UserIncomingMessageView
{
    public void Show(IEnumerable<Message> incomingMessages)
    {
        Console.WriteLine("\n Входящие сообщения:\n");

        if (incomingMessages.Count() == 0)
        {
            Console.WriteLine("Входящих сообщения нет");
            return;
        }

        incomingMessages.ToList().ForEach(message =>
        {
            Console.WriteLine("От кого: {0}. Текст сообщения: {1}", message.SenderEmail, message.Content);
        });
    }
}