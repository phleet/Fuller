using Newtonsoft.Json;

namespace Fuller.Requests
{
    public class PassphraseSearchRequest: BaseSearchRequest
    {
        public PassphraseSearchRequest(string hostname, string token) : base(hostname, token)
        {
            
        }

        public dynamic Execute()
        {
            return SearchInternal("passphrase.query");
        }
    }
}