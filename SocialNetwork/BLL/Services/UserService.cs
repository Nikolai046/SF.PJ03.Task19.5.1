using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services;

/// <summary>
/// Класс UserService предоставляет сервис для управления пользователями в социальной сети.
/// Обрабатывает логику регистрации, аутентификации, обновления данных пользователя, а также добавления друзей.
/// </summary>
public class UserService : IUserService
{
    /// <summary>
    /// Сервис для работы с сообщениями.
    /// </summary>
    private MessageService messageService;

    /// <summary>
    /// Репозиторий для работы с пользователями.
    /// </summary>
    private IUserRepository userRepository;

    /// <summary>
    /// Репозиторий для работы с друзьями.
    /// </summary>
    private IFriendRepository friendRepository;

    /// <summary>
    /// Конструктор UserService, который инициализирует необходимые репозитории и сервисы для работы с пользователями.
    /// </summary>
    public UserService()
    {
        userRepository = new UserRepository();
        messageService = new MessageService();
        friendRepository = new FriendRepository();
    }

    /// <summary>
    /// Регистрирует нового пользователя в системе.
    /// Проверяет корректность введенных данных, таких как имя, фамилия, пароль, и email.
    /// </summary>
    /// <param name="userRegistrationData">Данные для регистрации нового пользователя</param>
    /// <exception cref="ArgumentNullException">Исключение выбрасывается, если одно из обязательных полей не заполнено</exception>
    /// <exception cref="Exception">Исключение выбрасывается, если произошла ошибка при сохранении данных пользователя</exception>
    public void Register(UserRegistrationData userRegistrationData)
    {
        if (String.IsNullOrEmpty(userRegistrationData.FirstName))
            throw new ArgumentNullException();

        if (String.IsNullOrEmpty(userRegistrationData.LastName))
            throw new ArgumentNullException();

        if (String.IsNullOrEmpty(userRegistrationData.Password))
            throw new ArgumentNullException();

        if (String.IsNullOrEmpty(userRegistrationData.Email))
            throw new ArgumentNullException();

        if (userRegistrationData.Password.Length < 8)
            throw new ArgumentNullException();

        if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            throw new ArgumentNullException();

        if (userRepository.FindByEmail(userRegistrationData.Email) != null)
            throw new ArgumentNullException();

        var userEntity = new UserEntity()
        {
            firstname = userRegistrationData.FirstName,
            lastname = userRegistrationData.LastName,
            password = userRegistrationData.Password,
            email = userRegistrationData.Email
        };

        if (this.userRepository.Create(userEntity) == 0)
            throw new Exception();
    }

    /// <summary>
    /// Аутентифицирует пользователя на основе его email и пароля.
    /// </summary>
    /// <param name="userAuthenticationData">Данные для аутентификации</param>
    /// <returns>Объект User с данными пользователя</returns>
    /// <exception cref="UserNotFoundException">Исключение выбрасывается, если пользователь с указанным email не найден</exception>
    /// <exception cref="WrongPasswordException">Исключение выбрасывается, если пароль неверный</exception>
    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
        if (findUserEntity is null) throw new UserNotFoundException();

        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(findUserEntity);
    }

    /// <summary>
    /// Находит пользователя по его email.
    /// </summary>
    /// <param name="email">Email пользователя</param>
    /// <returns>Объект User с данными пользователя</returns>
    /// <exception cref="UserNotFoundException">Исключение выбрасывается, если пользователь с таким email не найден</exception>
    public User FindByEmail(string email)
    {
        var findUserEntity = userRepository.FindByEmail(email);
        if (findUserEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    /// <summary>
    /// Находит пользователя по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Объект User с данными пользователя</returns>
    /// <exception cref="UserNotFoundException">Исключение выбрасывается, если пользователь с таким идентификатором не найден</exception>
    public User FindById(int id)
    {
        var findUserEntity = userRepository.FindById(id);
        if (findUserEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    /// <summary>
    /// Проверяет, есть ли друг в списке друзей пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="friendId">Идентификатор друга</param>
    /// <returns>true, если друг уже добавлен, иначе false</returns>
    public bool CheckFriendExist(int userId, int friendId)
    {
        var existingFriends = FindById(userId).Friends;
        foreach (var friend in existingFriends)
        {
            if (friend.friend_id == friendId)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Добавляет друга по email для пользователя.
    /// </summary>
    /// <param name="userFriendData">Данные о друге и пользователе</param>
    /// <exception cref="CannotAddYourselfException">Исключение выбрасывается, если пользователь пытается добавить самого себя</exception>
    /// <exception cref="FriendAlreadyExistException">Исключение выбрасывается, если друг уже добавлен</exception>
    public void AddFriendBy(UserFriendData userFriendData)
    {
        var friendId = FindByEmail(userFriendData.FriendEmail).Id;

        if (friendId == userFriendData.UserId)
            throw new CannotAddYourselfException();

        if (CheckFriendExist(userFriendData.UserId, friendId))
            throw new FriendAlreadyExistException();

        var friendEntity = new FriendEntity()
        {
            user_id = userFriendData.UserId,
            friend_id = friendId,
        };

        if (friendRepository.Create(friendEntity) == 0)
            throw new Exception();
    }

    /// <summary>
    /// Обновляет данные пользователя.
    /// </summary>
    /// <param name="user">Объект User с обновленными данными</param>
    /// <exception cref="Exception">Исключение выбрасывается, если произошла ошибка при обновлении данных</exception>
    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favorite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };

        if (this.userRepository.Update(updatableUserEntity) == 0)
            throw new Exception();
    }

    /// <summary>
    /// Преобразует объект UserEntity в объект User.
    /// </summary>
    /// <param name="userEntity">Объект UserEntity</param>
    /// <returns>Объект User с данными пользователя</returns>
    private User ConstructUserModel(UserEntity userEntity)
    {
        var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
        var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);
        IEnumerable<FriendEntity> friends = friendRepository.FindAllByUserId(userEntity.id);

        return new User(userEntity.id,
                        userEntity.firstname,
                        userEntity.lastname,
                        userEntity.password,
                        userEntity.email,
                        userEntity.photo,
                        userEntity.favorite_movie,
                        userEntity.favorite_book,
                        incomingMessages,
                        outgoingMessages,
                        friends);
    }
}

/// <summary>
/// Определяет контракт для сервиса, управляющего пользователями в социальной сети.
/// </summary
public interface IUserService
{
    void Register(UserRegistrationData userRegistrationData);

    User Authenticate(UserAuthenticationData userAuthenticationData);

    User FindByEmail(string email);

    User FindById(int id);

    void Update(User user);

    void AddFriendBy(UserFriendData userFriendData);

    bool CheckFriendExist(int userId, int friendId);
}