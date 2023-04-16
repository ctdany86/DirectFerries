using DirectFerriesWebApp.Helpers;
using DirectFerriesWebApp.Services;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace DirectFerriesWebApp.Tests.HelpersTests
{
    public class UserHelperTest
    {
        private IDateTimeProvider _dateTimeProvider;

        [SetUp]
        public void Setup()
        {
            _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        }

        [Test]
        public void GivenAValidFullName_WhenGetNameFromFullNameIsCalled_ThenShouldReturnTheNameOnly()
        {
            // Arrange
            var fullName = "Daniele Morina";

            // Act
            var result = UserHelper.GetNameFromFullName(fullName);

            // Assert
            result.ShouldBe("Daniele");
        }

        [Test]
        public void GivenAValidName_WhenGetNumberOfVowelsInTheNameIsCalled_ThenShouldReturnTheNumberOfVowelFromTheName()
        {
            // Arrange
            var name = "Daniele";

            // Act
            var result = UserHelper.GetNumberOfVowelsInTheName(name);

            // Assert
            result.ShouldBe(4);
        }

        [Test]
        public void GivenAValidDateOfBirth_WhenGetAgeFromDateOfBirthIsCalled_ThenShouldReturnTheCorrectAge()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 04,15));
            var dateTimeNow = _dateTimeProvider.DateTimeNow;
            var dayOfBirth = new DateTime(1986, 09, 28);

            // Act
            var result = UserHelper.GetAgeFromDateOfBirth(dayOfBirth, dateTimeNow);

            // Assert
            result.ShouldBe(36);
        }

        [Test]
        public void GivenAValidDateOfBirth_WhenGetDaysUntilNextBirthdayIsCalled_ThenShouldReturnTheCorrectNumberOfDays()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 04, 15));
            var dateTimeNow = _dateTimeProvider.DateTimeNow;
            var dayOfBirth = new DateTime(1986, 09, 28);

            // Act
            var result = UserHelper.GetDaysUntilNextBirthday(dayOfBirth, dateTimeNow);

            // Assert
            result.ShouldBe(166);
        }


        [Test]
        public void GivenAValidDateOfBirth_WhenGetDatesBeforeNextBirthdayIsCalled_ThenShouldReturnTheCorrectDates()
        {
            // Arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 04, 15));
            var dateTimeNow = _dateTimeProvider.DateTimeNow;
            var dayOfBirth = new DateTime(1986, 09, 28);
            var expectedDates = new List<DateTime>
            {
                new(2023, 09, 15),
                new(2023, 09, 16),
                new(2023, 09, 17),
                new(2023, 09, 18),
                new(2023, 09, 19),
                new(2023, 09, 20),
                new(2023, 09, 21),
                new(2023, 09, 22),
                new(2023, 09, 23),
                new(2023, 09, 24),
                new(2023, 09, 25),
                new(2023, 09, 26),
                new(2023, 09, 27),
                new(2023, 09, 28)
            };

            // Act
            var result = UserHelper.GetDatesBeforeNextBirthday(dayOfBirth, dateTimeNow);

            // Assert
            result.ShouldBe(expectedDates);
        }
    }
}
