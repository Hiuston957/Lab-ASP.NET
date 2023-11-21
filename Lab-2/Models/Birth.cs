namespace Labolatorium2.Models
{
    public class Birth
    {
        public DateTime Age { get; set; }
        public string? First_name { get; set; }

        public bool IsValid()
        {
            return Age != null && First_name != null;
        }
        public int Years_Old()
        {
            return DateTime.Now.Year - Age.Year;
        }
    }
}
