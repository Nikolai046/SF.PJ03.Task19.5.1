﻿namespace SocialNetwork.PLL.Extencions;

/// <summary>
/// Этот класс инкапсулирует логику чтения данных из консоли, обеспечивая
/// удобный и последовательный интерфейс для получения пользовательского ввода.
/// ConsoleReader может включать дополнительную функциональность, такую как
/// валидация ввода или форматирование, сохраняя при этом простоту использования.
///
/// Использование этого класса позволяет абстрагировать прямые вызовы Console.ReadLine()
/// и Console.Read(), что упрощает модульное тестирование и позволяет легко
/// заменить источник ввода в будущем, если это потребуется.
/// </summary>
public interface IConsoleReader
{
    string ReadLine();
}

/// <summary>
/// Определяет контракт для чтения пользовательского ввода из консоли.
/// </summary>
public class ConsoleReader : IConsoleReader
{
    public string ReadLine() => Console.ReadLine();
}