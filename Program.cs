using HerosAndGuilds.Database;
using HerosAndGuilds.Managers;
using HerosAndGuilds.Menus;
using Spectre.Console;
using System.ComponentModel.Design;

namespace HerosAndGuilds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserManager manager = new UserManager();
            Startmeny startProgram = new Startmeny(manager);

            bool isloggedIn = startProgram.Menu();


            if (isloggedIn)
            {

                LoggedInMenu loggedInMenu = new LoggedInMenu(manager);
                loggedInMenu.Menu();

            }
        }
    }
}
