


namespace SocialNetworkApp.UnitTests.Systems.Controllers;

public class TestUserController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnCode200()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServicesExactlyOnce()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUsers()
    {
        // Arrange 
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers()); 
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.Get();
        // Assert

        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_NoUsersFound_Returns404()
    {
        // Arrange 
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.Get();
    
        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        // Arrange 
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}