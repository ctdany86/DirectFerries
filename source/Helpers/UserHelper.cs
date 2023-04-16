
namespace DirectFerriesWebApp.Helpers
{
    public static class UserHelper
    {
        public static string GetNameFromFullName(string fullName) => fullName.Split(' ')[0];

        public static int GetNumberOfVowelsInTheName(string name) => name.Count(letter => "aeiou".Contains(char.ToLower(letter)));

        public static int GetAgeFromDateOfBirth(DateTime dateOfBirth, DateTime dateTimeNow) => (int)(dateTimeNow - dateOfBirth).TotalDays / 365;

        public static int GetDaysUntilNextBirthday(DateTime dateOfBirth, DateTime dateTimeNow)
        {
            var nextBirthday = GetNextBirthday(dateOfBirth, dateTimeNow);

            if (nextBirthday < dateTimeNow)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            return (nextBirthday - dateTimeNow).Days;
        }

        public static List<DateTime> GetDatesBeforeNextBirthday(DateTime dateOfBirth, DateTime dateTimeNow)
        {
            var nextBirthday = GetNextBirthday(dateOfBirth, dateTimeNow);
            int daysUntilNextBirthday = GetDaysUntilNextBirthday(dateOfBirth, dateTimeNow);

            if (daysUntilNextBirthday <= 14)
            {
                return Enumerable.Range(0, daysUntilNextBirthday)
                    .Select(i => dateTimeNow.AddDays(i))
                    .OrderBy(date => date)
                    .ToList();
            }

            return Enumerable.Range(0, 14)
                .Select(i => nextBirthday.AddDays(-i))
                .OrderBy(date => date)
                .ToList();
        }

        private static DateTime GetNextBirthday(DateTime dateOfBirth, DateTime dateTimeNow)
        {
            return new DateTime(dateTimeNow.Year, dateOfBirth.Month, dateOfBirth.Day);
        }
    }
}
