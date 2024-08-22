namespace Api.Service.Repository.Auth.LoginService
{
    public interface ILoginService
    {
        Task<string> Login(string email, string password);
    }
}
