using HerosAndGuilds.Quests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Spectre.Console;



namespace HerosAndGuilds.UserAndHero
{
    public class User
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id;
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
