using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HerosAndGuilds.Managers;
using HerosAndGuilds.UserAndHero;
using Spectre.Console;

namespace HerosAndGuilds.Menus
{
    public class Startmeny
    {
        private UserManager _manager;
        string Choice;

        public Startmeny(UserManager manager)
        {
            _manager = manager;
        }


        public bool Menu() // add a return for logged in.
        {

            bool keepRunning = true;

            while (keepRunning)
            {
                var panel = new Panel("[bold yellow]Heroes & Guilds[/]") // ändra till https://spectreconsole.net/widgets/figlet? 
              .Border(BoxBorder.Rounded)
              .BorderColor(Color.Yellow);

                AnsiConsole.Write(panel);
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
                        AnsiConsole.Status()
                         .Start("Saving user...", ctx =>
                         {
                             Thread.Sleep(2000); // simulera "loading"
                         });

                        AnsiConsole.MarkupLine("[green]User created successfully![/]");
                        Thread.Sleep(1000);
                        AnsiConsole.Clear();

                        break;
                    case "Login":
                        bool loggedIn = _manager.LoginUser();
                        if (loggedIn)
                        {
                            keepRunning = false;

                            Console.Clear();
                            return true;
                        }
                        break;
                    case "[red]Exit[/]":
                        Console.Clear();
                        Console.WriteLine("Exiting program...");
                        keepRunning = false;

                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

            }
            return false;
        }
    }
}