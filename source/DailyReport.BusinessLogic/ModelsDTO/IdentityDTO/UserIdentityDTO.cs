namespace DailyReport.BusinessLogic.ModelsDTO.IdentityDTO
{
    public class UserIdentityDTO
    {
        public string? Id { get; set; }

        public string? Password { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public bool RememberMe { get; set; }
    }
}
