using DirectFerriesWebApp.Controllers;
using DirectFerriesWebApp.Services;
using DirectFerriesWebApp.Validations;
using NSubstitute;
using NUnit.Framework;
using DirectFerriesWebApp.Models;
using Shouldly;
using Microsoft.AspNetCore.Mvc;

namespace DirectFerriesWebApp.Tests.ControllersTests
{
    public class UserControllerTests
    {
        private UserController _userController;
        private IUserValidation _userValidation;
        private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();

        [SetUp]
        public void SetUp()
        {
            _userValidation = new UserValidation(_dateTimeProvider);
            _userController = new UserController(_dateTimeProvider, _userValidation);
        }

        [Test]
        public void GivenAValidFullNameAndDateOfBirth_WhenGetUserWelcomePageIsCalled_ThenShouldReturnOkResult()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 4, 16));
            string fullName = "Daniele Morina";
            DateTime dob = new DateTime(1986, 9, 28);

            // Act
            var result = _userController.GetUserWelcomePage(fullName, dob);

            // Assert
            result.ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public void GivenAValidFullNameAndDateOfBirth_WhenGetUserWelcomePageIsCalled_ThenShouldReturnOkResultWithUserDetail()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 4, 16));
            string fullName = "Daniele Morina";
            DateTime dob = new DateTime(1986, 9, 28);

            // Act
            var result = _userController.GetUserWelcomePage(fullName, dob) as OkObjectResult;
            var userDetail = result.Value as UserDetail;

            // Assert
            userDetail.Name.ShouldBe("Daniele");
            userDetail.NumberOfVowelsInName.ShouldBe(4);
            userDetail.Age.ShouldBe(36);
        }

        [Test]
        public void GivenAnInvalidFullNameAndDateOfBirth_WhenGetUserWelcomePageIsCalled_ThenShouldReturnBadRequestResult()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 4, 16));
            string fullName = "";
            DateTime dob = DateTime.MinValue;

            // Act
            var result = _userController.GetUserWelcomePage(fullName, dob);

            // Assert
            result.ShouldBeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void GivenAnInvalidFullNameAndDateOfBirth_WhenGetUserWelcomePageIsCalled_ThenShouldReturnBadRequestResultWithMessageAndErrorCode()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 4, 16));
            string fullName = "";
            DateTime dob = DateTime.MinValue;

            // Act
            var result = _userController.GetUserWelcomePage(fullName, dob) as BadRequestObjectResult;
            var validationResult = result.Value as ValidationResult;
            
            // Assert
            validationResult.Message.ShouldBe("Invalid full name and date of birth");
            validationResult.ErrorCode.ShouldBe("INVALID_FULL_NAME_AND_DOB");
        }
    }
}
