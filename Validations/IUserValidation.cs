namespace DirectFerriesWebApp.Validations
{
    public interface IUserValidation
    {
        public bool IsFullNameValid(string fullName);

        public bool IsDateOfBirthValid(string dateOfBirth);
    }
}
