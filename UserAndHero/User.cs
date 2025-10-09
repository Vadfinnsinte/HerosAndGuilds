using HerosAndGuilds.Quests;
using Spectre.Console;


namespace HerosAndGuilds.UserAndHero
{
    public class User
    {
        public string Name; 
        public string Username;
        private string Password;
        public Hero[] Heroes;  
        public string Email;
        public int PhoneNumer;
        public Quest[] Quest; 
        public int NumberOfCompletedQuest;
        public int NumberOfFailedQuest;
        public int NumberOfQuestCloseToDeadline;
        public string GuildAffiliation;
        public int Level;

        public void CreateUser() // add go back to main menu .
        {
            bool isPasswordOk = false; 
           var panel = new Panel("[bold green]Create User[/]")
          .Border(BoxBorder.Rounded)
          .BorderColor(Color.Pink1);
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
                    Name = name;
                Password = password;
                Username = username; // add check to make sure it is Uniqe

                
              
                NumberOfCompletedQuest = 0;
                NumberOfFailedQuest = 0;
                NumberOfQuestCloseToDeadline = 0;
                GuildAffiliation = "None";
                isPasswordOk = true;


            } else
            {
                Console.WriteLine("Password must be 10 charakters and contain lower case, upper case and specials(*/!) ");
            }
            }
            string email = AnsiConsole.Prompt(
             new TextPrompt<string>("Email?")); // add check for email 
            int phonenumber = AnsiConsole.Prompt(
                    new TextPrompt<int>("Phonenumber?")); // add check to make sure its a phoneNUmber
            Email = email;
            PhoneNumer = phonenumber;
        }
        private bool CheckPassword(string password)
        {
            if( password.Length > 11) return false;

                bool hasUpper = false;

                bool hasLower = false;
                bool hasDigit = false;
                bool hasSpecial = false;
                foreach ( char character in password)
                {
                // change to switch? 
                    if(char.IsUpper(character))
                    {
                        hasUpper = true;
                    }
                    else if (char.IsLower(character))
                    {
                        hasLower = true;
                    }
                    else if (char.IsDigit(character))
                    {
                        hasDigit = true;
                    }
                    else if (!char.IsLetterOrDigit(character))
                    {
                        hasSpecial = true;

                    }
                }
            if (hasUpper && hasDigit && hasSpecial && hasLower) return true;
                
                return false ;
            
        }

        public void LoginUser()
        {
            Console.WriteLine("Coming soon...");
        }
        public void LogOut()
        {
            Console.WriteLine("Coming soon...");
        }


    }
}
