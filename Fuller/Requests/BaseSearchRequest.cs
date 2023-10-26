using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fuller.Requests
{
    public abstract class BaseSearchRequest : BaseRequest
    {
        private Dictionary<string, string> _options;

        protected BaseSearchRequest(string hostname, string token) : base(hostname, token)
        {
            _options = new Dictionary<string, string>();
        }

        protected void setOption(string key, string value)
        {
            _options[key] = value;
        }

        protected dynamic SearchInternal(string endpoint)
        {
            return Execute(endpoint, _options);
        }
    }
}