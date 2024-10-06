using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс UserMenuView предоставляет интерфейс меню для авторизованного пользователя в социальной сети.
/// Пользователь может просмотреть свои сообщения, редактировать профиль, добавлять друзей, отправлять сообщения и взаимодействовать с друзьями.
/// В зависимости от выбора пользователя, вызываются соответствующие действия через другие представления.
/// </summary>
public class UserMenuView
{
    private IUserService userService;

    public UserMenuView(IUserService userService)
    {
        this.userService = userService;
    }

    public void Show(User user)
    {
        while (true)
        {
            //user = userService.FindById(user.Id);

            Console.WriteLine("\nВходящие сообщения: {0}", user.IncomingMessages.Count());
            Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
            Console.WriteLine("Количество друзей: {0}", user.Friends.Count());

            Console.WriteLine("\nПосмотреть информацию о моём профиле (нажмите 1)");
            Console.WriteLine("Редактировать мой профиль (нажмите 2)");
            Console.WriteLine("Добавить в друзья (нажмите 3)");
            Console.WriteLine("Написать сообщение (нажмите 4)");
            Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
            Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
            Console.WriteLine("Посмотреть друзей (нажмите 7)");
            Console.WriteLine("Выйти из профиля (нажмите 8)");

            string keyValue = Console.ReadLine();

            if (keyValue == "8") break;

            switch (keyValue)
            {
                case "1":
                    {
                        Program.userInfoView.Show(user);
                        break;
                    }
                case "2":
                    {
                        Program.userDataUpdateView.Show(user);
                        break;
                    }
                case "3":
                    {
                        Program.addinFriendView.Show(user);
                        user = userService.FindById(user.Id);
                        break;
                    }

                case "4":
                    {
                        Program.messageSendingView.Show(user);
                        user = userService.FindById(user.Id);
                        break;
                    }

                case "5":
                    {
                        Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    }

                case "6":
                    {
                        Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                        break;
                    }
                case "7":
                    {
                        Program.userFriendsView.Show(user);
                        break;
                    }
            }
        }
    }
}