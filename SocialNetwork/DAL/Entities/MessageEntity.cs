namespace SocialNetwork.DAL.Entities;

/// <summary>
/// Класс MessageEntity представляет сущность сообщения в базе данных.
/// Содержит информацию о сообщении, включая его содержимое, идентификатор отправителя и получателя.
/// </summary>
public class MessageEntity
{
    /// <summary>
    /// Идентификатор сообщения.
    /// </summary>
    public int id { get; set; }

    /// <summary>
    /// Содержимое сообщения.
    /// </summary>
    public string content { get; set; }

    /// <summary>
    /// Идентификатор отправителя сообщения.
    /// </summary>
    public int sender_id { get; set; }

    /// <summary>
    /// Идентификатор получателя сообщения.
    /// </summary>
    public int recipient_id { get; set; }
}