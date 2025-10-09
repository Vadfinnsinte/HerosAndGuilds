using HerosAndGuilds.UserAndHero;


namespace HerosAndGuilds.Quests
{
    public class Quest
    {
        public string Title;
        public string Description;
        public DateTime ExpireDateTime;
        public string FailCondition;
        public int XP;
        public string Priority;
        public bool IsCompleted;
        public User QuestOwner;
        public Hero HeroOnQuest;

        public void CreateQuest()
        {

        }
        public void ShowAllQuests()
        {

        }
        public void UpdateQuest()
        {

        }
        public void DoQuest() 
        {

        }
        public void SendNotification() 
        {

        }
 
        // make a questManager class? 
    }
}
