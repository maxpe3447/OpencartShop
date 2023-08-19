namespace OpencartShop.Service.Repository.Auth.LoginService
{
    public interface ILoginService
    {
        string Login(string email, string password);
    }
}
