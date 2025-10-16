using HerosAndGuilds.MenuAndManagement;
using Spectre.Console;
using System.ComponentModel.Design;

namespace HerosAndGuilds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var panel = new Panel("[bold yellow]Heroes & Guilds[/]") // ändra till https://spectreconsole.net/widgets/figlet? 
               .Border(BoxBorder.Rounded)
               .BorderColor(Color.Yellow);

            AnsiConsole.Write(panel);

            Manager manager = new Manager();     
            Startmeny startProgram = new Startmeny(manager);

            startProgram.Menu(); 
            // recive return from ^ to start next menu.
        }
    }
}
