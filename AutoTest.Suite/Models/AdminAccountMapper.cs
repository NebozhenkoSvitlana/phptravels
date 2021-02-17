using System;

namespace AutoTest.Suite.Models
{
    public static class AdminAccountMapper
    {
        public static AdminAccountDto GetOnlyRequiredFieldsNewAdminDto()
        {
            int randomNumber = new Random().Next(1, 1000);
            return new AdminAccountDto
            {
                FirstName = "Svitlana"+ randomNumber,
                LastName = "Chukhno"  + randomNumber,
                Email = "snebojenko+" + randomNumber + "@gmail.com",
                Password = "QQQQQQ",
                Country = "Ukraine"
            };
        }
    }
}
