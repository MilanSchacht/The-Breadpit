namespace The_Breadpit.Models
{
    public class AccountRepository
    {
        private static List<Account> accountResponses = new();
        public static IEnumerable<Account> AccountResponses => accountResponses;
        public static void AddAccount(Account response)
        {
            accountResponses.Add(response);
        }
        public static void ClearAccount()   
        {
            accountResponses.Clear();
        }
    }
}
