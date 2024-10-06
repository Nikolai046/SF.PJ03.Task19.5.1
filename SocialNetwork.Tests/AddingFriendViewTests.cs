using Moq;
using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Extencions;
using SocialNetwork.PLL.Views;

namespace SocialNetwork.Tests;

[TestFixture]
public class AddingFriendViewTests
{
    private Mock<IUserService> userServiceMock;
    private Mock<IConsoleReader> consoleReaderMock;
    private AddingFriendView addingFriendView;
    private User user;

    [SetUp]
    public void Setup()
    {
        userServiceMock = new Mock<IUserService>();
        consoleReaderMock = new Mock<IConsoleReader>();
        addingFriendView = new AddingFriendView(userServiceMock.Object, consoleReaderMock.Object);
        user = new User(1, "Иван", "Иванов", "12345678", "1@mail.ru", "", "", "", null, null, null);
    }

    [Test]
    public void Show_ShouldDisplaySuccessMessage_WhenFriendIsAddedSuccessfully()
    {
        userServiceMock.Setup(p => p.AddFriendBy(It.IsAny<UserFriendData>()));

        var output = new StringWriter();
        Console.SetOut(output);

        addingFriendView.Show(user);

        Assert.That(output.ToString(), Contains.Substring("Пользователь успешно добавлен в друзья"));
    }

    [Test]
    public void Show_ShouldDisplayUserNotFoundMessage_WhenUserNotFoundException()
    {
        userServiceMock.Setup(p => p.AddFriendBy(It.IsAny<UserFriendData>()))
            .Throws(new UserNotFoundException());

        var output = new StringWriter();
        Console.SetOut(output);

        addingFriendView.Show(user);

        Assert.That(output.ToString(), Contains.Substring("Пользователь с таким email не найден."));
    }

    [Test]
    public void Show_ShouldDisplayFriendAlreadyExistMessage_WhenFriendAlreadyExistException()
    {
        userServiceMock.Setup(p => p.AddFriendBy(It.IsAny<UserFriendData>()))
            .Throws(new FriendAlreadyExistException());

        var output = new StringWriter();
        Console.SetOut(output);

        addingFriendView.Show(user);

        Assert.That(output.ToString(), Contains.Substring("Пользователь уже добавлен в друзья."));
    }

    [Test]
    public void Show_ShouldDisplayCannotAddYourselfMessage_WhenCannotAddYourselfException()
    {
        userServiceMock.Setup(p => p.AddFriendBy(It.IsAny<UserFriendData>()))
            .Throws(new CannotAddYourselfException());

        var output = new StringWriter();
        Console.SetOut(output);

        addingFriendView.Show(user);

        Assert.That(output.ToString(), Contains.Substring("Нельзя добавить самого себя"));
    }
}