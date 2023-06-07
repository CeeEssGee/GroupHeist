namespace GroupHeist
{

    public class Hacker : IRobber
    {


        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialist { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= this.SkillLevel;
            System.Console.WriteLine($"{this.Name} is hacking the alarm system. Decreased alarm score by {this.SkillLevel} points.");
            if (bank.AlarmScore <= 0)
            {
                System.Console.WriteLine($"{this.Name} has disabled the alarm!");
            }
        }

        // constructor
        public Hacker(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
            Specialist = "Hacker";
        }
    }

}