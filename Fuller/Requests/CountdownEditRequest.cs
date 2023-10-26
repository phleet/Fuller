namespace Fuller.Requests
{
    public class CountdownEditRequest : BaseEditRequest
    {
        
        
        public CountdownEditRequest(string hostname, string token) : base(hostname, token)
        {

        }

        public void SubmitTransactions(string phid)
        {
            SubmitTransactionsInternal("countdown.edit", phid);
        }
    }
}