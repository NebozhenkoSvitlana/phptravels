namespace AutoTest.Suite.Models
{
    //this class can be split with the selenium locators from 'AdminItemComponent'
    public class AdminAccountDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool EmailNewsletterSubstriber { get; set; }
    }
}
