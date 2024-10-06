using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

/// <summary>
/// Класс MessageService предоставляет сервис для управления сообщениями в социальной сети.
/// Обрабатывает логику отправки сообщений, а также выборки входящих и исходящих сообщений.
/// </summary>
public class MessageService
{
    /// <summary>
    /// Репозиторий для работы с сообщениями.
    /// </summary>
    private IMessageRepository messageRepository;

    /// <summary>
    /// Репозиторий для работы с пользователями.
    /// </summary>
    private IUserRepository userRepository;

    /// <summary>
    /// Конструктор MessageService, который инициализирует репозитории для работы с сообщениями и пользователями.
    /// </summary>
    public MessageService()
    {
        userRepository = new UserRepository();
        messageRepository = new MessageRepository();
    }

    /// <summary>
    /// Получает список входящих сообщений для пользователя по его идентификатору.
    /// </summary>
    /// <param name="recipientId">Идентификатор получателя</param>
    /// <returns>Коллекция входящих сообщений</returns>
    public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
    {
        var messages = new List<Message>();

        messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindById(m.sender_id);
            var recipientUserEntity = userRepository.FindById(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });

        return messages;
    }

    /// <summary>
    /// Получает список исходящих сообщений для пользователя по его идентификатору.
    /// </summary>
    /// <param name="senderId">Идентификатор отправителя</param>
    /// <returns>Коллекция исходящих сообщений</returns>
    public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
    {
        var messages = new List<Message>();

        messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
        {
            var senderUserEntity = userRepository.FindById(m.sender_id);
            var recipientUserEntity = userRepository.FindById(m.recipient_id);

            messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
        });

        return messages;
    }

    /// <summary>
    /// Отправляет сообщение от пользователя другому пользователю по предоставленным данным.
    /// </summary>
    /// <param name="messageSendingData">Данные для отправки сообщения</param>
    /// <exception cref="ArgumentNullException">Исключение выбрасывается, если контент сообщения пустой или длина больше 5000 символов</exception>
    /// <exception cref="UserNotFoundException">Исключение выбрасывается, если пользователь с указанным email не найден</exception>
    /// <exception cref="Exception">Общее исключение, если произошла ошибка при сохранении сообщения</exception>
    public void SendMessage(MessageSendingData messageSendingData)
    {
        if (String.IsNullOrEmpty(messageSendingData.Content))
            throw new ArgumentNullException();

        if (messageSendingData.Content.Length > 5000)
            throw new ArgumentOutOfRangeException();

        var findUserEntity = this.userRepository.FindByEmail(messageSendingData.RecipientEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var messageEntity = new MessageEntity()
        {
            content = messageSendingData.Content,
            sender_id = messageSendingData.SenderId,
            recipient_id = findUserEntity.id
        };

        if (this.messageRepository.Create(messageEntity) == 0)
            throw new Exception();
    }
}