using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HerosAndGuilds.UserAndHero;
using Spectre.Console;

namespace HerosAndGuilds.MenyAndManagement
{
    public class Startmeny
    {
        string Choice; 

        public void Menu()
        {

            Choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Chose if you want to Login, Create a User och Exit")
                .AddChoices(new[]
                {
                        "Login", "Create User", "Exit"
                }));

            switch (Choice)
            {
                case "Create User":
                    var login = new User();
                    login.CreateUser(); // Add so it doesent close on Wrong password.
                        break;
                default:
                    Console.WriteLine("Coming soon..");
                    break;
            }
        }

        
    }
}
