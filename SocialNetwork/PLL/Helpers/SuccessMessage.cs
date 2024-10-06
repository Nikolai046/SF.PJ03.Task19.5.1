namespace SocialNetwork.PLL.Helpers;

/// <summary>
/// Предоставляет функциональность для отображения форматированных сообщений пользователю.
/// </summary>
public static class SuccessMessage
{
    public static void Show(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }
}