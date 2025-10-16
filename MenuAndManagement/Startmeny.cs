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
        private Manager _manager;
        string Choice;

        public Startmeny(Manager manager)
        {
            _manager = manager;
        }


        public void Menu() // add a return for logged in.
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[blue]Choose if you want to Login, Create a User or Exit[/]")
                    .HighlightStyle(new Style(Color.Yellow))
                    .AddChoices(new[]
                    {
                "Login", "Create User", "[red]Exit[/]"
                    }));

                switch (Choice)
                {
                    case "Create User":
                        _manager.CreateUser();
                        break;
                    case "Login":
                        _manager.LoginUser(); // add logic to send user from this menu.
                        keepRunning = false;
                        break;
                    case "[red]Exit[/]":
                        Console.WriteLine("Exiting program...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
                
            }
        }
    }
}