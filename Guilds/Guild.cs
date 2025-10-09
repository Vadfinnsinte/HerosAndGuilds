
using HerosAndGuilds.Quests;
using HerosAndGuilds.UserAndHero;

namespace HerosAndGuilds.Guilds
{
    public class Guild
    {
        public string Name;
        public User[] Members;
        public int NumberOfMembers;
        public Quest[] ActiveQuests;
        public int NumberOfFailedQuests;
        public User GuildOwner;

        public void ShowMembers()
        {
            // a list of username and their level.
        }
        public void AddNewMember()
        {
            
            // Move to a manager?
        }
        public void CreateGuild()
        {

           
        }
    }
}
