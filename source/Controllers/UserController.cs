using Microsoft.AspNetCore.Mvc;
using System.Net;
using DirectFerriesWebApp.Helpers;
using DirectFerriesWebApp.Models;
using DirectFerriesWebApp.Services;
using DirectFerriesWebApp.Validations;

namespace DirectFerriesWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserValidation _userValidation;

        public UserController(IDateTimeProvider dateTimeProvider, IUserValidation userValidation)
        {
            _dateTimeProvider = dateTimeProvider;
            _userValidation = userValidation;
        }

        [HttpGet]
        [Route("get-user-welcome-page")]
        public IActionResult GetUserWelcomePage([FromQuery] string fullName, DateTime dateOfBirth)
        {
            var validationResult = _userValidation.ValidateUser(fullName, dateOfBirth);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var name = UserHelper.GetNameFromFullName(fullName);
            var numberOfVowelsInName = UserHelper.GetNumberOfVowelsInTheName(name);
            var age = UserHelper.GetAgeFromDateOfBirth(dateOfBirth, _dateTimeProvider.DateTimeNow);
            var datesBeforeNextBirthday = UserHelper.GetDatesBeforeNextBirthday(dateOfBirth, _dateTimeProvider.DateTimeNow);

            try
            {
                var result = new UserDetail
                {
                    Name = name,
                    NumberOfVowelsInName = numberOfVowelsInName,
                    Age = age,
                    DatesBeforeNextBirthday = datesBeforeNextBirthday
                };

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
