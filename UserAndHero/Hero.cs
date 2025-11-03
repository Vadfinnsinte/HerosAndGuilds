using HerosAndGuilds.Quests;
using Spectre.Console;

namespace HerosAndGuilds.UserAndHero
{

    // add apperences for heroes? 
    public class Hero
    {
        public string Name;
        public string Race;
        public int Level;
        public string SpecialAttack;
        public Quest[] CompeletedQuests; //Remove? 

        public void CreateHero()
        {
            // make selectable choises(for race and their special attack) and input for names.
            Name = AnsiConsole.Prompt(new TextPrompt<string>(" Name of you hero: "));
            Race = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Race")
                .AddChoices(new[] { "Elf", "Human", "Oger", "Dwarf", })
                );



        }
        public void SelectHero()
        {
            // pull heros from logged in user and make selectable choises

        }
    }
}
