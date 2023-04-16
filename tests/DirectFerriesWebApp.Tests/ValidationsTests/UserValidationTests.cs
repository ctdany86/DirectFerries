using DirectFerriesWebApp.Services;
using DirectFerriesWebApp.Validations;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace DirectFerriesWebApp.Tests.ValidationsTests
{
    public class UserValidationTests
    {
        private UserValidation _userValidation;
        private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();

        [SetUp]
        public void SetUp()
        {
            _userValidation = new UserValidation(_dateTimeProvider);
        }

        [Test]
        public void GivenAValidFullNameAndDateOfBirth_WhenValidateUserIsCalled_ThenShouldReturnValidResult()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2022, 1, 1));
            string fullName = "Daniele Morina";
            DateTime dob = new DateTime(1990, 1, 1);

            // Act
            var result = _userValidation.ValidateUser(fullName, dob);

            // Assert
            result.IsValid.ShouldBeTrue();
            result.Message.ShouldBeNull();
            result.ErrorCode.ShouldBeNull();
        }

        [Test]
        public void GivenAnInvalidFullNameAndDateOfBirth_WhenValidateUserIsCalled_ThenShouldReturnInvalidResultWithErrorCode()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2022, 1, 1));
            string fullName = "";
            DateTime dob = DateTime.MinValue;

            // Act
            var result = _userValidation.ValidateUser(fullName, dob);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Message.ShouldBe("Invalid full name and date of birth");
            result.ErrorCode.ShouldBe("INVALID_FULL_NAME_AND_DOB");
        }

        [Test]
        public void GivenAnInvalidFullName_WhenValidateUserIsCalled_ThenShouldReturnInvalidResultWithErrorCode()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2022, 1, 1));
            string fullName = "";
            DateTime dob = new DateTime(1990, 1, 1);

            // Act
            var result = _userValidation.ValidateUser(fullName, dob);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Message.ShouldBe("Invalid full name");
            result.ErrorCode.ShouldBe("INVALID_FULL_NAME");
        }

        [Test]
        public void GivenAnInvalidDateOfBirth_WhenValidateUserIsCalled_ThenShouldReturnInvalidResultWithErrorCode()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2022, 1, 1));
            string fullName = "Daniele Morina";
            DateTime dob = new DateTime(2023, 1, 1);

            // Act
            var result = _userValidation.ValidateUser(fullName, dob);

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Message.ShouldBe("Invalid date of birth");
            result.ErrorCode.ShouldBe("INVALID_DOB");
        }
    }
}
