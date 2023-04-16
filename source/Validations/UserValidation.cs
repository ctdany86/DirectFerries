using DirectFerriesWebApp.Services;
using System.ComponentModel.DataAnnotations;

namespace DirectFerriesWebApp.Validations
{
    public class UserValidation : IUserValidation
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public UserValidation(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public ValidationResult ValidateUser(string fullName, DateTime dateOfBirth)
        {
            var result = new ValidationResult();

            if (IsDateOfBirthInvalid(dateOfBirth) && IsFullNameInvalid(fullName))
            {
                result.IsValid = false;
                result.Message = "Invalid full name and date of birth";
                result.ErrorCode = "INVALID_FULL_NAME_AND_DOB";
            }
            else if (IsDateOfBirthInvalid(dateOfBirth))
            {
                result.IsValid = false;
                result.Message = "Invalid date of birth";
                result.ErrorCode = "INVALID_DOB";
            }
            else if (IsFullNameInvalid(fullName))
            {
                result.IsValid = false;
                result.Message = "Invalid full name";
                result.ErrorCode = "INVALID_FULL_NAME";
            }
            else
            {
                result.IsValid = true;
            }

            return result;
        }

        private bool IsFullNameInvalid(string fullName)
        {
            return string.IsNullOrEmpty(fullName) || fullName.Any(c => char.IsDigit(c));
        }

        private bool IsDateOfBirthInvalid(DateTime dateOfBirth)
        {
            return dateOfBirth >= _dateTimeProvider.DateTimeNow || dateOfBirth == DateTime.MinValue;
        }
    }
}
