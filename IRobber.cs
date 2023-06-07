using GroupHeist;

public interface IRobber
{
    string Name { get; set; }
    int SkillLevel { get; set; }
    int PercentageCut { get; set; }
    string Specialist { get; set; }

    void PerformSkill(Bank bank);
}