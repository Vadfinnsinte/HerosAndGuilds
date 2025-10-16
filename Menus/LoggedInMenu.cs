using HerosAndGuilds.Managers;
using Spectre.Console;


namespace HerosAndGuilds.Menus
{
    internal class LoggedInMenu
    {
        private UserManager _manager;
        string Choice;

        public LoggedInMenu(UserManager manager)
        {
            _manager = manager;
        }
        public void Menu()
        {
            var titlepanel = new Panel("[bold yellow]Heroes & Guilds[/]") // ändra till https://spectreconsole.net/widgets/figlet? 
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Yellow);

            AnsiConsole.Write(titlepanel);
            AnsiConsole.MarkupLine($"[bold green]Welcome {_manager.LoggedInUserName}![/]");
            Choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("[blue]What would you like to do?[/]")
                        .HighlightStyle(new Style(Color.Yellow))
                        .AddChoices(new[]
                        {
                "Go to quests", "Create New Quest", "See your Heros", "Create New Hero", "Se Your guild alt Join a guild", "See your profile", "[red]Log Out[/]"
                        }));
            switch (Choice)
            {
                case "Go to quests":
                    Console.WriteLine("Coming Soon...");
                    //_manager.CreateUser();
                    break;
                case "Create New Quest":
                    Console.WriteLine("Coming Soon...");
                    //_manager.LoginUser();
                    break;
                case "Create New Hero":
                    Console.WriteLine("Coming Soon...");
                    //_manager.LoginUser();
                    break;
                case "Se Your guild alt Join a guild":
                    Console.WriteLine("Coming Soon...");
                    //_manager.LoginUser();
                    break;
                case "See your profile":
                    Console.WriteLine("Coming Soon...");
                    //_manager.LoginUser();
                    break;
                case "[red]Log Out[/]":
                    Console.WriteLine("Exiting program...");

                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        }
    }
}
