using System.Threading.Channels;

namespace LogInProject
{
    /// <summary>
    /// Creates new Accounts, with password
    /// </summary>
    public static class AccountCreator
    {
        /// <summary>
        /// Create a new account following the password requirements; the credentials will be appended to the existing .txt file.
        /// </summary>
        public static void RegisterUser()
        {
            PrintRequirements();

            string username = ValidateUsername();
            string password = ValidatePassword();

            AppendToFile(username, password);
        }

        private static void PrintRequirements()
        {
            string requirements = @"
Register: create a new account.
There is no specific requirement for the username.
Password length should be at least 10 characters long.
It must contain at least one number and one symbol.
";
            Console.WriteLine(requirements);
        }

        /// <returns>Valid Username</returns>
        private static string ValidateUsername()
        {
            //Calls the method converting the .txt file into a dictionary for easier access.
            var credentials = AccountManager.GetCredentials();
            
            Console.WriteLine("Enter a new username: ");
            string username = Console.ReadLine();
            //TODO: validate username a little bit
            // edge case 1: username is blank
            // edge case 2: username is already registered

            while (true)
            {
                if (String.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Invalid username: the username cannot be blank. Please try again.");
                }
                else if (credentials.ContainsKey(username))
                {
                    Console.WriteLine("The username already exists. Please try again.");
                }
                else
                {
                    break;
                }
                Console.WriteLine("Enter your username again: ");
                username = Console.ReadLine();  
            }
            return username;
        }
        
        /// <returns>Valid Password</returns>
        private static string ValidatePassword()
        {
            Console.WriteLine("Enter a new password: ");
            string password = Console.ReadLine();
            string symbols = @" ~`!@#$%^&*():;_-+={[}]|\";
            //blank space counted in symbols!

            while (true)
            {
                if (password.Length < 10)
                {
                    Console.WriteLine("\nYour password should be at least 10 characters long.");
                }
                else if (!password.Any(ch => symbols.Contains(ch)))
                //if does NOT contain any symbol
                {
                    Console.WriteLine("\nYour password should contain at least one symbol.");
                }
                else if (!password.Any(char.IsDigit))
                //if does NOT contain any number
                {
                    Console.WriteLine("\nYour password should contain at least one number.");
                }
                else
                {
                    break;
                }
                Console.WriteLine("Enter your password again: ");
                password = Console.ReadLine();
            }

            return password;
        }

        private static void AppendToFile(string username, string password)
        {
            try
            {
                using (StreamWriter accountsFile = new StreamWriter("accounts.txt", true))
                //append mode true
                {
                    accountsFile.WriteLine($"{username},{password}");
                }
                Console.WriteLine("User created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occured while saving the credentials: \n{ex.Message}\n");
            }
        }
    }
}
