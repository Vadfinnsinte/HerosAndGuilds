using HerosAndGuilds.Guilds;
using HerosAndGuilds.UserAndHero;
using Spectre.Console;
using System.Globalization;
using System.Xml.Linq;


namespace HerosAndGuilds.MenuAndManagement
{
    public class Manager
    {
        public List<User> Users;
        public List<Guild> Guilds;
        // also quests ? 

        public Manager()
        {
            Users = new List<User>();
            Guilds = new List<Guild>();
        }

        public void CreateUser() // add go back to main menu .
        {
            User makeUser = new User();
            bool isPasswordOk = false;
            var panel = new Panel("[bold green]Create User[/]")
           .Border(BoxBorder.Ascii)
           .BorderColor(Color.Green);
            AnsiConsole.Write(panel);

            string name = AnsiConsole.Prompt(
                    new TextPrompt<string>("Name?"));
            string username = AnsiConsole.Prompt(
                    new TextPrompt<string>("Username?"));
            while (!isPasswordOk)
            {

                string password = AnsiConsole.Prompt(
                        new TextPrompt<string>("Password?"));



                bool testPassword = CheckPassword(password);

                if (testPassword)
                {
                    makeUser.Name = name;
                    makeUser.Password = password;
                    makeUser.Username = username; // add check to make sure it is Uniqe



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

            AnsiConsole.MarkupLine($"[green]User '{makeUser.Username}' created successfully![/]"); // add a confirm?

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
        public void AddUserToList(User user)
        {
            Users.Add(user);
            // add save to Json. 
        }
        public void LoginUser()
        {
            var panel = new Panel("[bold green]Login[/]")
                .Border(BoxBorder.Double)
                .BorderColor(Color.Green);
            AnsiConsole.Write(panel);

            string username = AnsiConsole.Prompt(
             new TextPrompt<string>("Username:"));

            string password = AnsiConsole.Prompt(
             new TextPrompt<string>("Password:"));

            User found = Users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                if(found.Password == password)
                {
                    Console.WriteLine($"Welcome {username}");
                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                }
            }

        }
    }
}
