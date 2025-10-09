using HerosAndGuilds.MenuAndManagement;
using Spectre.Console;
using System.ComponentModel.Design;

namespace HerosAndGuilds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var panel = new Panel("[bold yellow]Heroes & Guilds[/]")
               .Border(BoxBorder.Rounded)
               .BorderColor(Color.Yellow);

            AnsiConsole.Write(panel);
            Startmeny StartProgram = new Startmeny();

            StartProgram.Menu(); 
        }
    }
}
