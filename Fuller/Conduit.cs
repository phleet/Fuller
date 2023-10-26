using System;
using System.Collections.Generic;
using System.IO;

namespace Fuller;

public class Conduit
{
    private String _host = "";
    private String _token = "";

    private readonly Dictionary<string, string> _requests = new Dictionary<string, string>
    {
        ["conduit.ping"] = "ConduitPingRequest",
        ["countdown.edit"] = "CountdownEditRequest",
        ["countdown.search"] = "CountdownSearchRequest",
        ["passphrase.query"] = "PassphraseSearchRequest",
        ["user.whoami"] = "UserWhoamiRequest"
    };
    private readonly Dictionary<string, bool> _permissions = new Dictionary<string, bool>()
    {
        ["conduit.ping"] = true,
        ["countdown.edit"] = true,
        ["countdown.search"] = true,
        ["passphrase.query"] = true,
        ["user.whoami"] = true
    };

    public string Host
    {
        get => _host;
        set => _host = value;
    }

    public string Token
    {
        get => _token;
        set => _token = value;
    }

    public dynamic CreateRequest(string path)
    {
        if (!_requests.ContainsKey(path)) throw new FileNotFoundException();

        if (!_permissions.ContainsKey(path) || !_permissions[path]) throw new FileNotFoundException();
        
        Type type = Type.GetType("Phabricator.ConduitAPI.Requests." + _requests[path]);
        if (type == null)
        {
            throw new Exception("Type not found");
        }
        dynamic instance = Activator.CreateInstance(type, _host, _token);
        dynamic t = Convert.ChangeType(instance, type);
        return t;
    }

    public void UpdateCapabilties()
    {
        
    }
    
}
