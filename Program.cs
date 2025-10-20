using HerosAndGuilds.Database;
using HerosAndGuilds.Managers;
using HerosAndGuilds.Menus;
using Spectre.Console;
using System.ComponentModel.Design;

namespace HerosAndGuilds
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UserManager manager = new UserManager();
            Startmeny startProgram = new Startmeny(manager);

            bool isloggedIn = await startProgram.Menu();


            if (isloggedIn)
            {

                LoggedInMenu loggedInMenu = new LoggedInMenu(manager);
                loggedInMenu.Menu();

            }
        }
    }
}
