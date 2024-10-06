namespace SocialNetwork.BLL.Exceptions;

/// <summary>
/// Исключение, возникающее при попытке добавить самого себя в друзья.
/// </summary>
public class CannotAddYourselfException : Exception
{
}