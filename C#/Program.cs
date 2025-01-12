//Leeloo Schaff

//This program will allow users to create a new user account, log in and view the existing accounts.

namespace LogInProject;

class Program
{
    static void Main(string[] args)
    {
        //MENU CHOICE OPTIONS
        int option;

        do
        {
            Console.WriteLine(@"
    Login Program.

    **********************************
    1. Register
    2. Log in (view the existing accounts)
    3. Exit
    **********************************
    ");

            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    //Register
                    AccountCreator.RegisterUser();
                    break;
                case 2:
                    //Log in
                    AccountManager.LogIn();
                    break;
                case 3:
                    //Exit
                    Console.WriteLine("Exiting...\n");
                    Thread.Sleep(2000);
                    Console.WriteLine("Thank you.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter 1, 2 or 3.");
                    break;
            }
        } while (option != 3);
    }
}
