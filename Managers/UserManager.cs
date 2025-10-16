using HerosAndGuilds.Database;
using HerosAndGuilds.Guilds;
using HerosAndGuilds.UserAndHero;
using Spectre.Console;
using System.Globalization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace HerosAndGuilds.Managers
{
    public class UserManager
    {
        public List<User> Users;
        public List<Guild> Guilds;
        public string LoggedInUserName;
        // also quests ? 

        public UserManager()
        {
            Users = new List<User>();
            Guilds = new List<Guild>();
        }

        public async Task CreateUser() // add go back to main menu .
        {

            User makeUser = new User();
            bool isPasswordOk = false;
            bool isUsernameOk = false;
            var panel = new Panel("[bold green]Create User[/]")
           .Border(BoxBorder.Ascii)
           .BorderColor(Color.Green);
            AnsiConsole.Write(panel);

            string name = AnsiConsole.Prompt(
                    new TextPrompt<string>("Name?"));

            while (!isUsernameOk)
            {

                string username = AnsiConsole.Prompt(
                        new TextPrompt<string>("Username?"));
                bool testUsername = IsUserNameUniqe(username);
                if (testUsername)
                {
                    makeUser.Username = username;
                    isUsernameOk = true;
                }
                else
                {
                    Console.WriteLine("Username is in use");

                }

            }
            while (!isPasswordOk)
            {

                string password = AnsiConsole.Prompt(
                        new TextPrompt<string>("Password?"));




                bool testPassword = CheckPassword(password);

                if (testPassword)
                {
                    makeUser.Name = name;
                    makeUser.Password = password;
                    makeUser.NumberOfCompletedQuest = 0;
                    makeUser.NumberOfFailedQuest = 0;
                    makeUser.NumberOfQuestCloseToDeadline = 0;
                    makeUser.GuildAffiliation = "None";
                    isPasswordOk = true;

                }
                else
                {
                    Console.WriteLine("Password must be 10 charakters and contain lower case, upper case and specials(*/!) ");
                }

            }
            string email = AnsiConsole.Prompt(
             new TextPrompt<string>("Email?")); // add check for email 
            int phonenumber = AnsiConsole.Prompt(
                    new TextPrompt<int>("Phonenumber?")); // add check to make sure its a phoneNUmber
            makeUser.Email = email;
            makeUser.PhoneNumer = phonenumber;

            AddUserToList(makeUser);
            var db = new ConnectionDB();
            await db.AddUserDB(makeUser);
            AnsiConsole.MarkupLine($"[bold green]User '{makeUser.Username}' created successfully![/]");

        }

        private bool CheckPassword(string password)
        {
            if (password.Length < 6 || password.Length > 20) return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                switch (c)
                {
                    case char _ when char.IsUpper(c):
                        hasUpper = true;
                        break;
                    case char _ when char.IsLower(c):
                        hasLower = true;
                        break;
                    case char _ when char.IsDigit(c):
                        hasDigit = true;
                        break;
                    case char _ when !char.IsLetterOrDigit(c):
                        hasSpecial = true;
                        break;

                }
            }

            if (hasUpper && hasLower && hasDigit && hasSpecial) return true;
            else return false;



        }
        public bool IsUserNameUniqe(string username)
        {
            User uniqeuser = Users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (uniqeuser == null)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public void AddUserToList(User user)
        {
            Users.Add(user);
            // add save to Json. 
        }
        public bool LoginUser()
        {
            var panel = new Panel("[bold green]Login[/]")
                .Border(BoxBorder.Double)
                .BorderColor(Color.Green);
            AnsiConsole.Write(panel);

            string username = AnsiConsole.Prompt(
             new TextPrompt<string>("Username:"));

            string password = AnsiConsole.Prompt(
             new TextPrompt<string>("Password:"));

            User found = Users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)); // add null handle

            if (found != null)
            {
                if (found.Password == password)
                {
                    Console.WriteLine($"Welcome {username}");
                    LoggedInUserName = username;
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                    return false;
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red]User not found![/]");
                return false;
            }

        }
    }
}
