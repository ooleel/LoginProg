namespace LogInProject
{
    public class AccountManager
    {
        //2.1 Log in
        //Checks if the login credentials match the credentials in the file/dictionary.
        public static void LogIn()
        {
            //View the accounts
            Console.WriteLine("Login and view the existing accounts.\n");

            //Calls the method converting the .txt file into a dictionary for easier access.
            var credentials = GetCredentials();

            Console.WriteLine("Enter your username: ");
            string loginUsername = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string loginPassword = Console.ReadLine();

            //Checks if the credentials used for logging in match any entry in the file / key/value pair in the dictionary.
            if (credentials.ContainsKey(loginUsername))
            {
                if (loginPassword == credentials[loginUsername])
                {
                    Console.WriteLine("Login successful.");
                    DisplayAccounts();
                }
                else
                {
                    Console.WriteLine("\nIncorrect password. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("\nUsername not found. Please try again.");
            }
        }

        //Method converting the .txt file into a dictionary: usernames as keys, and passwords as values.
        public static Dictionary<string, string> GetCredentials()
        {
            var credentials = new Dictionary<string, string>();

            try
            {
                var lines = File.ReadAllLines("accounts.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        credentials[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                //Returns an empty dictionary.
                Console.WriteLine("No accounts found. The file does not exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the accounts file: {ex.Message}");
            }

            return credentials;
        }

        //2.2 View the existing accounts
        //If the login is successful, displays the other accounts' usernames by only printing the keys found in the dictionary.
        static void DisplayAccounts()
        {
            //Calls the function converting the .txt file into a dictionary for easier access.
            var credentials = GetCredentials();

            Console.WriteLine("Existing accounts: \n");
            foreach (var username in credentials.Keys)
            {
                Console.WriteLine(username);
            }

            Console.WriteLine($"\nTotal users = {credentials.Count}");
        }
    }
}
