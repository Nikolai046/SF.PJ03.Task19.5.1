using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

/// <summary>
/// Этот класс обеспечивает функциональность для работы с сообщениями, включая
/// сохранение новых сообщений, получение истории сообщений, обновление статуса сообщений
/// и их удаление. MessageRepository взаимодействует с базой данных или другим хранилищем
/// для выполнения операций с сообщениями.
/// Класс инкапсулирует всю логику доступа к данным, связанную с сообщениями,
/// обеспечивая единый интерфейс для работы с сообщениями в рамках приложения.
/// </summary>
public class MessageRepository : BaseRepository, IMessageRepository
{
    public int Create(MessageEntity messageEntity)
    {
        return Execute(@"insert into messages(content, sender_id, recipient_id)
                             values(:content,:sender_id,:recipient_id)", messageEntity);
    }

    public IEnumerable<MessageEntity> FindBySenderId(int senderId)
    {
        return Query<MessageEntity>("select * from messages where sender_id = :sender_id", new { sender_id = senderId });
    }

    public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
    {
        return Query<MessageEntity>("select * from messages where recipient_id = :recipient_id", new { recipient_id = recipientId });
    }

    public int DeleteById(int messageId)
    {
        return Execute("delete from messages where id = :id", new { id = messageId });
    }
}

/// <summary>
/// Определяет контракт для репозитория, управляющего сообщениями между пользователями.
/// </summary>
public interface IMessageRepository
{
    int Create(MessageEntity messageEntity);

    IEnumerable<MessageEntity> FindBySenderId(int senderId);

    IEnumerable<MessageEntity> FindByRecipientId(int recipientId);

    int DeleteById(int messageId);
}