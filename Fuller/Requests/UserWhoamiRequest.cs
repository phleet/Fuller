namespace Fuller.Requests
{
    public class UserWhoamiRequest : BaseRequest
    {
        public UserWhoamiRequest(string hostnane, string token) : base(hostnane, token)
        {
            
        }

        public dynamic Execute()
        {
            return base.Execute("user.whoami");
        }

    }
}