using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fuller.Requests
{
    public class BaseEditRequest : BaseRequest
    {
        private Dictionary<int, Dictionary<string, string>> _transactions;

        protected BaseEditRequest(string hostname, string token) : base(hostname, token)
        {
            _transactions = new Dictionary<int, Dictionary<string, string>>();
        }
        
        public void AddTransaction(string key, string value)
        {
            Dictionary<string, string> transaction = new Dictionary<string, string>();
            transaction["type"] = key;
            transaction["value"] = value;

            int length = _transactions.Count;
            length += 1;
            
            _transactions.Add(length, transaction);
        }

        protected dynamic SubmitTransactionsInternal(string path, string phid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["objectIdentifier"] = phid, 
                ["transactions"] = JsonConvert.SerializeObject(_transactions)
            };

            dynamic result =  Execute(path, data);

            return result;
        }
    }
}