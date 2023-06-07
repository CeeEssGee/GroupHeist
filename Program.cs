using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker Adam = new Hacker("Adam", 50, 15);
            Hacker Sergey = new Hacker("Sergey", 30, 15);
            Muscle Cullen = new Muscle("Cullen", 25, 15);
            Muscle Ace = new Muscle("Ace", 30, 15);
            LockSpecialist Courtney = new LockSpecialist("Courtney", 50, 15);

            List<IRobber> rolodex = new List<IRobber>() { Adam, Sergey, Cullen, Ace, Courtney };

            System.Console.WriteLine($"There are {rolodex.Count} operatives.");

            NewTeamMember();

            void NewTeamMember()
            {
                System.Console.WriteLine($"Who is your new crew member?");
                string newCrewMember = Console.ReadLine();
                if (newCrewMember == "")
                {
                    return;
                }
                System.Console.WriteLine($"Pick your specialty\n\t1) Hacker\n\t2) Muscle\n\t3) Lock Specialist");
                int specialty = int.Parse(Console.ReadLine());
                System.Console.WriteLine("What is your skill level between 1 and 100?");
                int newCMSkillLevel = int.Parse(Console.ReadLine());
                System.Console.WriteLine("What is your cut?");
                int newCMCut = int.Parse(Console.ReadLine());

                switch (specialty)
                {
                    case 1:
                        rolodex.Add(new Hacker(newCrewMember, newCMSkillLevel, newCMCut));
                        break;
                    case 2:
                        rolodex.Add(new Muscle(newCrewMember, newCMSkillLevel, newCMCut));
                        break;
                    case 3:
                        rolodex.Add(new LockSpecialist(newCrewMember, newCMSkillLevel, newCMCut));
                        break;
                    default:
                        break;


                }

                System.Console.WriteLine($"There are now {rolodex.Count} operatives.");
                addAnotherTeamMember();
            }

            void addAnotherTeamMember()
            {
                NewTeamMember();
            }

            Random random = new Random();
            int theAlarmScore = random.Next(0, 101);
            int theVaultScore = random.Next(0, 101);
            int theSecurityGuardScore = random.Next(0, 101);
            int theCashOnHand = random.Next(50000, 1000000001);

            Bank theBank = new Bank(theCashOnHand, theAlarmScore, theVaultScore, theSecurityGuardScore);

            Dictionary<string, int> Scores = new Dictionary<string, int>();
            Scores.Add("Alarm Score", theAlarmScore);
            Scores.Add("Vault Score", theVaultScore);
            Scores.Add("Security Guard Score", theSecurityGuardScore);

            // System.Console.WriteLine($"Alarm Score = {theAlarmScore}\nVault ={theVaultScore}\nSecurity = {theSecurityGuardScore}");


            var maxValueKey = Scores.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            Console.WriteLine($"Most Secure: {maxValueKey}");

            var minValueKey = Scores.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;

            Console.WriteLine($"Least Secure: {minValueKey}");


            System.Console.WriteLine($"Select your crew:");
            for (int i = 1; i < rolodex.Count; i++)
            {
                IRobber robber = rolodex[i];
                System.Console.WriteLine($"\t{i}) {robber.Name}\n\tSpecialist: {robber.Specialist}\n\tSkill Level: {robber.SkillLevel}\n\tPercentage Cut: {robber.PercentageCut}\n");

            }

        }
    }
}
