
namespace DirectFerriesWebApp.Helpers
{
    public static class UserHelper
    {
        public static string GetNameFromFullName(string fullName) => fullName.Split(' ')[0];

        public static int GetNumberOfVowelsInTheName(string name) => 
            name.Count(letter => "aeiou".Contains(char.ToLower(letter)));

        public static int GetAgeFromDateOfBirth(DateTime dateOfBirth, DateTime dateTimeNow) => (dateTimeNow.Year - dateOfBirth.Year) - 1;
    }
}
