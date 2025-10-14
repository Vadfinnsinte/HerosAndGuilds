using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HerosAndGuilds.UserAndHero;
using Spectre.Console;

namespace HerosAndGuilds.MenuAndManagement
{
    public class Startmeny
    {
        string Choice;

        public void Menu()
        {
            // Add an about option? 
            Choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[blue]Chose if you want to Login, Create a User or Exit[/]")
                .HighlightStyle(new Style(Color.Yellow))
                .AddChoices(new[]
                {
                        "Login", "Create User", "[red]Exit[/]"
                }));

            Manager UserChoises = new Manager();
            switch (Choice)
            {
                case "Create User":
                    UserChoises.CreateUser(); // Add so it doesent close on Wrong password.
                    break;
                case "Login":
                    UserChoises.LoginUser();
                    break;
                case "[red]Exit[/]":
                    Console.WriteLine("Exiting program...");

                    break;

                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }


        }


    }
}
