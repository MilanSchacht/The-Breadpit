namespace The_Breadpit.Models
{
    public class AccountRepository
    {
        private static List<AccountLoginResponse> loginResponses = new();
        public static IEnumerable<AccountLoginResponse> LoginResponses => loginResponses;
        public static void AddLogedinAccount(AccountLoginResponse response)
        {
            // For debugging
            Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nA new account has logged in:\r\nUsername = " + response.Username + "\r\n");
            loginResponses.Add(response);
        }
        public static void ClearLogedinAccount()   
        {
            loginResponses.Clear();
        }

        private static List<AccountRegisterResponse> registerResponses = new();
        public static IEnumerable<AccountRegisterResponse> RegisterResponses => registerResponses;
        public static void AddRegisteredAccount(AccountRegisterResponse response)
        {
            // For debugging
            Console.WriteLine("\r\n======\r\nNOTICE\r\n======\r\n\r\nA new account registered:\r\nUsername = " + response.Username + "\r\n");
            registerResponses.Add(response);
        }
        public static void ClearRegisteredAccount()
        {
            registerResponses.Clear();
        }
    }
}
