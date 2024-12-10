#Leeloo Schaff

#This program will allow users to create a new user account, log in and view the existing accounts.

symbols = "~`!@#$%^&*()_-+={[}]|\:;"

requirements = '''
\nThere is no specific requirement for the username.
Password length should be at least 10 characters long.
It must contain at least one number and one symbol.\n
'''

#Admin credentials
admin_name = "admin"
admin_pw = "AdminPassword"

#MENU
menu = '''
\nLogin Program.

**********************************
1. Register
2. Log in
3. View the existing accounts
4. Exit
**********************************\n
'''

#Function converting the .txt file into a dictionary: usernames as keys, and passwords as values.
def get_credentials():
    credentials = {}
    try: 
        with open("accounts.txt", "r") as accounts_file:
            for line in accounts_file:
                username, password = line.strip().split(",")
                credentials[username] = password
    except FileNotFoundError:
        pass
    return credentials

#OPTIONS
#1. Register
#Create a new account following the password requirements; the credentials will be appended to the exitsting .txt file.
def register(): 
    with open("accounts.txt", "a") as accounts_file:
        print(requirements)
        username = input("Enter a new username: ")
        password = input("Enter a new password: ")

        #Checks password requirements
        while True:
            if len(password) < 10:
                print("Your password should be at least 10 characters long.")
            elif not any(char in symbols for char in password): 
                print("Your password should contain at least one symbol.")
            elif not any(char.isdigit() for char in password): 
                print("Your password should contain at least one number.")
            else:
                break
            password = input("Enter your password again: ")

        accounts_file.write(username + "," + password + "\n")
        print("User created successfully.")

#2. Log in
def login(): 
    # SET NUMBER OF ATTEMPTS: Uncomment and indent accordingly if necessary ↓
    # attempts = 0
    # while attempts < 3: 

    #Checks if the login credentials match the credentials in the file/dictionary. 
    while True:
        #Calls the function converting the .txt file into a dictionary for easier access.
        credentials = get_credentials()

        login_username = input("Enter your username: ")
        login_password = input("Enter your password: ")

        if login_username in credentials:
            if login_password == credentials[login_username]:
                print("Login successful.")
                return
            else:
                print("\nIncorrect password. Please try again.")
        else:
            print("\nUsername not found. Please try again.")
            
# 3. View the existing accounts
def display_accounts():
    #Set number of attempts?
    
    #Calls the function converting the .txt file into a dictionary for easier access.
    credentials = get_credentials()

    #If the login is successful, displays the other accounts' usernames by only printing the keys found in the dictionary.
    while True:
        print("\nLog in with the admin credentials.\n")
        viewacc_username = input("Enter your username: ")
        viewacc_pw = input("Enter your password: ")

        if (viewacc_username == admin_name) and (viewacc_pw == admin_pw):
            print("Login successful.\n\nExisting accounts: \n")
            for username in credentials:
                print(username)
            print("\nTotal users =", len(credentials))
            return
        else: 
            print("\nLog in not successful.")
                

#MENU CHOICE OPTIONS
while True:
    print(menu)
    choice = input("Please choose one of the option above (1, 2, 3, 4): ")
    print("My choice:", choice)

    if choice == "1":
        print("Register: create a new account.")
        register()
    elif choice == "2":
        print("Log in.\n")
        login() 
        pass
    elif choice == "3":
        print("View the existing accounts (admin only).\n")
        display_accounts()
    elif choice == "4":
        print("Exiting...")
        break
    else:
        print("Invalid choice, please try again.")
