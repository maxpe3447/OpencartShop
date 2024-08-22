namespace Api.Model
{
    public class RegistrationUserModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
