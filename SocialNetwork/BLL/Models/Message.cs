namespace SocialNetwork.BLL.Models;

/// <summary>
/// Класс Message представляет модель сообщения в социальной сети.
/// Содержит информацию о контенте сообщения, отправителе и получателе.
/// </summary>
public class Message
{
    /// <summary>
    /// Идентификатор сообщения.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Содержимое сообщения.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Электронная почта отправителя сообщения.
    /// </summary>
    public string SenderEmail { get; }

    /// <summary>
    /// Электронная почта получателя сообщения.
    /// </summary>
    public string RecipientEmail { get; }

    /// <summary>
    /// Конструктор класса Message, инициализирующий все основные свойства.
    /// </summary>
    /// <param name="id">Идентификатор сообщения</param>
    /// <param name="content">Содержимое сообщения</param>
    /// <param name="senderEmail">Электронная почта отправителя</param>
    /// <param name="recipientEmail">Электронная почта получателя</param>
    public Message(int id, string content, string senderEmail, string recipientEmail)
    {
        this.Id = id;
        this.Content = content;
        this.SenderEmail = senderEmail;
        this.RecipientEmail = recipientEmail;
    }
}