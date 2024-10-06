using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Extencions;
using SocialNetwork.PLL.Views;

namespace SocialNetwork;

internal class Program
{
    private static MessageService messageService;
    public static IUserService userService;
    public static IConsoleReader consoleReader;
    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserFriendsView userFriendsView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendingView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutcomingMessageView userOutcomingMessageView;

    public static AddingFriendView addinFriendView;

    private static void Main(string[] args)
    {
        userService = new UserService();
        messageService = new MessageService();
        consoleReader = new ConsoleReader();
        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userFriendsView = new UserFriendsView(userService);
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendingView = new MessageSendingView(messageService, userService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutcomingMessageView = new UserOutcomingMessageView();

        addinFriendView = new AddingFriendView(userService, consoleReader);

        while (true)
        {
            mainView.Show();
        }
    }
}