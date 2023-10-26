using System;

namespace Fuller.Requests
{
    public class ConduitPingRequest : BaseRequest
    {

        public ConduitPingRequest(String hostname, string token) : base(hostname, token)
        {
            
        }

        public dynamic Execute()
        {
            return base.Execute("conduit.ping");
        }
    }
}
