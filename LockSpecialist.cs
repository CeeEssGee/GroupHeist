namespace GroupHeist
{

    public class LockSpecialist : IRobber
    {


        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialist { get; set; }


        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= this.SkillLevel;
            System.Console.WriteLine($"{this.Name} is hacking the vault. Decreased vault score by {this.SkillLevel} points.");
            if (bank.VaultScore <= 0)
            {
                System.Console.WriteLine($"{this.Name} has opened the vault!");
            }

        }

        // constructor
        public LockSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
            Specialist = "Lock Specialist";
        }

    }

}