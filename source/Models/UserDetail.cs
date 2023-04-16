namespace DirectFerriesWebApp.Models
{
    public class UserDetail
    {
        public string Name { get; set; }
        public int NumberOfVowelsInName { get; set; }
        public int Age { get; set; }
        public int DaysUntilNextBirthday { get; set; }
        public List<DateTime> DatesBeforeNextBirthday { get; set; }
    }
}
