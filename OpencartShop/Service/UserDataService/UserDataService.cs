namespace OpencartShop.Service.UserDataService
{
    public class UserDataService : IUserDataService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserDataService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext
                                                 ?.User
                                                 .Identities
                                                 .FirstOrDefault()
                                                 ?.Claims.FirstOrDefault(x => x.Type == "userId")?.Value ?? "0");
        }
    }
}
