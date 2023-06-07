namespace GroupHeist
{

    public class Muscle : IRobber
    {


        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialist { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= this.SkillLevel;
            System.Console.WriteLine($"{this.Name} is beating up the security guards. Decreased security guard score by {this.SkillLevel} points.");
            if (bank.SecurityGuardScore <= 0)
            {
                System.Console.WriteLine($"{this.Name} has disabled the security guards!");
            }

        }

        // constructor
        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
            Specialist = "Muscle";
        }
    }

}