using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndGuilds.UserAndHero
{
    internal class User
    {
        public string Name; 
        public string Username;
        private string Password;
        public string Heroes;  // change to list
        public string Email;
        public int PhoneNumer;
        public string Quest; // change to list
        public int NumberOfCompletedQuest;
        public int NumberOfFailedQuest;
        public int NumberOfQuestCloseToDeadline;
        public string GuildAffiliation; 


        public void CreateUser() // Add so it doesent close on Wrong password.
        {
           var panel = new Panel("[bold green]Create User[/]")
          .Border(BoxBorder.Rounded)
          .BorderColor(Color.Pink1);
            AnsiConsole.Write(panel);
           
            string name = AnsiConsole.Prompt(
                    new TextPrompt<string>("Name?"));
            string username = AnsiConsole.Prompt(
                    new TextPrompt<string>("Username?"));
            string password = AnsiConsole.Prompt(
                    new TextPrompt<string>("Password?"));
            string email = AnsiConsole.Prompt(
                    new TextPrompt<string>("Email?"));
            int phonenumber = AnsiConsole.Prompt(
                    new TextPrompt<int>("Phonenumber?"));

            bool testPassword = CheckPassword(password); 
            
            if (testPassword)
            {
                Password = password;
                Username = username;
                Email = email;
                PhoneNumer = phonenumber;
                Heroes = ""; // change to List 
                Quest = ""; // change to List
                NumberOfCompletedQuest = 0;
                NumberOfFailedQuest = 0;
                NumberOfQuestCloseToDeadline = 0;
                GuildAffiliation = "None";


            } else
            {
                Console.WriteLine("Password must be 10 charakters and contain lower case, upper case and specials(*/!) ");
            }

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

    }
}
