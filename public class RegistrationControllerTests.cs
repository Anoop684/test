public class RegistrationControllerTests
{
    [Fact]
    public async Task Register_WithValidModel_RedirectsToHomeIndex()
    {
        // Arrange
        var userManager = MockUserManager();
        var signInManager = MockSignInManager();
        var controller = new RegistrationController(userManager.Object, signInManager.Object);
        var model = new RegisterViewModel
        {
            FullName = "John Doe",
            Email = "johndoe@example.com",
            Password = "Password123",
            DateOfBirth = new DateTime(1990, 1, 1)
        };

        // Act
        var result = await controller.Register(model);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Equal("Home", redirectResult.ControllerName);
    }

    // Write more tests to cover different scenarios like invalid models, duplicate emails, etc.

    private Mock<UserManager<User>> MockUserManager()
    {
        var userStore = new Mock<IUserStore<User>>();
        var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null, null, null, null, null, null);
        
        userManager.Setup(u => u.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        
        userManager.Setup(u => u.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((User)null);
        
        return userManager;
    }

    private Mock<SignInManager<User>> MockSignInManager()
    {
        var userManager = MockUserManager();
        var signInManager = new Mock<SignInManager<User>>(userManager.Object,
            new HttpContextAccessor(), new Mock<IUserClaimsPrincipalFactory<User>>().Object, null, null, null, null);

        signInManager.Setup(s => s.SignInAsync(It.IsAny<User>(), It.IsAny<bool>(), null))
            .Returns(Task.CompletedTask);

        return signInManager;
    }

    public void test{
        a=10;
        b=2;
        a+b;
       int sum= q+c;
    }
}
