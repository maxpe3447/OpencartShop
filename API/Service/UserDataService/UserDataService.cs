namespace Api.Service.UserDataService
{
    public class UserDataService : IUserDataService
    {
        private int userId { get; set; }
        public int GetUserId()
        {
            return userId;
        }

        public void SetUserId(int userId)
        {
            this.userId = userId;
        }
    }
}
