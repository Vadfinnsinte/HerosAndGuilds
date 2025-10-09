using HerosAndGuilds.MenyAndManagement;
using Spectre.Console;
using System.ComponentModel.Design;

namespace HerosAndGuilds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var panel = new Panel("[bold green]Heroes & Guilds[/]")
               .Border(BoxBorder.Rounded)
               .BorderColor(Color.Green);

            AnsiConsole.Write(panel);
            Startmeny StartProgram = new Startmeny();

            StartProgram.Menu(); 
        }
    }
}
