namespace SocialNetwork.PLL.Views;

/// <summary>
/// Класс MainView предоставляет главный интерфейс (меню) для взаимодействия с пользователем в социальной сети.
/// Позволяет пользователю выбрать один из доступных вариантов: войти в профиль или зарегистрироваться.
/// В зависимости от выбранного варианта, вызывает соответствующие методы для дальнейших действий.
/// </summary>
public class MainView
{
    public void Show()
    {
        Console.WriteLine("\nВойти в профиль (нажмите 1)");
        Console.WriteLine("Зарегистрироваться (нажмите 2)");
        // Console.WriteLine("Посмотреть всю базу (нажмите 3)");

        switch (Console.ReadLine())
        {
            case "1":
                {
                    Program.authenticationView.Show();
                    break;
                }

            case "2":
                {
                    Program.registrationView.Show();
                    break;
                }
                //case "3":
                //{
                //    for (int i = 1; ; i++)
                //    {
                //        try
                //        {
                //            Program.userInfoView.Show(Program.userService.FindById(i));
                //            Console.WriteLine();
                //        }
                //        catch
                //        {
                //            if (i == 1 )Console.WriteLine($"База пуста");
                //            break;
                //            }
                //    }
                //    break;
                //}
        }
    }
}