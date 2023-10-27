using System.Collections.Generic;
namespace Fuller.Requests
{
    public class CountdownSearchRequest : BaseSearchRequest
    {
        
        public CountdownSearchRequest(string hostname, string token) : base(hostname, token)
        {
            SetOption("queryKey", "upcoming");
            SetOption("order", "newest");
        }

        public dynamic Execute()
        {
            return SearchInternal("countdown.search");
        }
    }
}