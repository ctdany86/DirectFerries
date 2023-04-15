﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using DirectFerriesWebApp.Helpers;
using DirectFerriesWebApp.Models;
using DirectFerriesWebApp.Services;

namespace DirectFerriesWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public UserController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        [Route("get-user-welcome-page")]
        public IActionResult GetUserWelcomePage([FromQuery] string fullName, DateTime dateOfBirth)
        {
            if (dateOfBirth >= _dateTimeProvider.DateTimeNow)
            {
                return BadRequest(new
                {
                    Message = "Invalid date of birth",
                    ErrorCode = "INVALID_FULL_NAME"
                });
            }

            if (string.IsNullOrEmpty(fullName))
            {
                return BadRequest(new
                {
                    Message = "Invalid full name",
                    ErrorCode = "INVALID_FULL_NAME"
                });
            }

            var name = UserHelper.GetNameFromFullName(fullName);
            var numberOfVowelsInName = UserHelper.GetNumberOfVowelsInTheName(name);
            var age = UserHelper.GetAgeFromDateOfBirth(dateOfBirth, _dateTimeProvider.DateTimeNow);

            try
            {
                var result = new UserDetail
                {
                    Name = name,
                    NumberOfVowelsInName = numberOfVowelsInName,
                    Age = age
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
