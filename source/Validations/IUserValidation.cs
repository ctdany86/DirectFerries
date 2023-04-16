namespace DirectFerriesWebApp.Validations
{
    public interface IUserValidation
    {
        public ValidationResult ValidateUser(string fullName, DateTime dateOfBirth);
    }
}
