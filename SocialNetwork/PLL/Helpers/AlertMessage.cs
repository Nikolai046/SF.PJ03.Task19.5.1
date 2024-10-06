namespace SocialNetwork.PLL.Helpers;

/// <summary>
/// Предоставляет функциональность для отображения форматированных сообщений пользователю.
/// </summary>
public class AlertMessage
{
    public static void Show(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }
}