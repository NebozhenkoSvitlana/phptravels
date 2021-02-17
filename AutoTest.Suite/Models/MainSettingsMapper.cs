namespace AutoTest.Suite.Models
{
    public static class MainSettingsMapper
    {
        public static MainSettingsDto GetMainSettingsDto()
        {
            return new MainSettingsDto()
            {
                Status = "Disabled",
                Comission = "222.33",
                CountOfAdd = 3,
                CountOfEdit = 2,
                CountOfDelete = 4
            };
        }
    }
}
