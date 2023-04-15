using DirectFerriesWebApp.Helpers;
using DirectFerriesWebApp.Services;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace DirectFerriesWebApp.Tests.HelpersTests
{
    public class UserHelperTest
    {
        private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAValidFullName_WhenGetNameFromFullNameIsCalled_ThenShouldReturnTheNameOnly()
        {
            // arrange
            var fullName = "Daniele Morina";

            // act
            var result = UserHelper.GetNameFromFullName(fullName);

            // assert
            result.ShouldBe("Daniele");
        }

        [Test]
        public void GivenAValidName_WhenGetNumberOfVowelsInTheNameIsCalled_ThenShouldReturnTheNumberOfVowelFromTheName()
        {
            // arrange
            var name = "Daniele";

            // act
            var result = UserHelper.GetNumberOfVowelsInTheName(name);

            // assert
            result.ShouldBe(4);
        }

        [Test]
        public void GivenAValidDateOfBirth_WhenGetAgeFromDateOfBirthIsCalled_ThenShouldReturnTheCorrectAge()
        {
            // arrange
            _dateTimeProvider.DateTimeNow.Returns(new DateTime(2023, 04,15));
            var dateTimeNow = _dateTimeProvider.DateTimeNow;
            var dayOfBirth = new DateTime(1986, 09, 28);

            // act
            var result = UserHelper.GetAgeFromDateOfBirth(dayOfBirth, dateTimeNow);

            // assert
            result.ShouldBe(36);
        }
    }
}
