using HerosAndGuilds.Quests;
using Spectre.Console;



namespace HerosAndGuilds.UserAndHero
{
    public class User
    {
        public string Name; 
        public string Username;
        public string Password;
        public List<Hero> Heroes;  
        public string Email;
        public int PhoneNumer;
        public List<Quest> Quest; 
        public int NumberOfCompletedQuest;
        public int NumberOfFailedQuest;
        public int NumberOfQuestCloseToDeadline;
        public string GuildAffiliation;
        public int Level;

       

   
        public void LogOut()
        {
            Console.WriteLine("Coming soon...");
        }


    }
}
