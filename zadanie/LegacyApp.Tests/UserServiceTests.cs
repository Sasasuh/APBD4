namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseIfEmailIsInvalid()
    {
        var userService = new UserService();

        var result = userService.AddUser("Andrzej",
            "Kowalski",
            "kowalskigmailcom",
            DateTime.Parse("2000-01-01"),
            1
        );

        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseIfUserIsUnder21()
    {
        var userService = new UserService();
        var dateOfBirth = DateTime.Now.AddYears(-5);

        var user = new User { DateOfBirth = dateOfBirth };
        var result = user.isValidAge(dateOfBirth);


        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenCreditLimitLessThen500()
    {
        var userService = new UserService();
        User user = new User { HasCreditLimit = true, CreditLimit = 400 };

        var result = userService.checkCreditLimit(user);

        Assert.False(result);
    }


    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(null,
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsArgumentExceptionIfKlientDoesNotExist()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser("Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1000
        );
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}