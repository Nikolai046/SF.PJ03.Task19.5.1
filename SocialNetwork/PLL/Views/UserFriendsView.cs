using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс UserFriendsView предоставляет интерфейс для отображения списка друзей пользователя в социальной сети.
/// Если у пользователя есть друзья, они выводятся в виде списка с именем и email каждого друга.
/// Если у пользователя нет друзей, выводится сообщение о том, что друзья отсутствуют.
/// </summary>
public class UserFriendsView
{
    private IUserService userService;

    public UserFriendsView(IUserService userService)
    {
        this.userService = userService;
    }

    public void Show(User user)
    {
        Console.WriteLine("\nВаши друзья:\n");

        if (!user.Friends.Any())
        {
            AlertMessage.Show("У вас нет друзей.");
        }
        else
        {
            foreach (var friend in user.Friends)
            {
                var friendInfo = userService.FindById(friend.friend_id);
                Console.WriteLine($"- пользователь: {friendInfo.FirstName} {friendInfo.LastName}, e-mail: {friendInfo.Email}");
            }
        }

        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
}