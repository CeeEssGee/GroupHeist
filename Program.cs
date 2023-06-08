using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> crew = new List<IRobber>();

            Hacker Adam = new Hacker("Adam", 50, 15);
            Hacker Sergey = new Hacker("Sergey", 40, 15);
            Muscle Cullen = new Muscle("Cullen", 40, 15);
            Muscle Ace = new Muscle("Ace", 40, 15);
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

            // System.Console.WriteLine($"Alarm Score = {theAlarmScore}\nVault Score ={theVaultScore}\nSecurity Guard Score = {theSecurityGuardScore}");

            var maxValueKey = Scores.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            Console.WriteLine($"Most Secure: {maxValueKey}");

            var minValueKey = Scores.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;

            Console.WriteLine($"Least Secure: {minValueKey}");

            CrewSelection();

            void CrewSelection()
            {

                System.Console.WriteLine($"Select your crew:");
                for (int i = 0; i < rolodex.Count; i++)
                {
                    IRobber robber = rolodex[i];
                    // if totalPercentageCut() + robber.PercentageCut <= 100, show robber info                  
                    int totalPercentageGiven = totalPercentageCut();
                    if ((totalPercentageGiven + rolodex[i].PercentageCut <= 100))
                    {
                        System.Console.WriteLine($"\t{i + 1}) {robber.Name}\n\tSpecialist: {robber.Specialist}\n\tSkill Level: {robber.SkillLevel}\n\tPercentage Cut: {robber.PercentageCut}\n");
                    }


                }

                System.Console.WriteLine($"The total percentage cut is {totalPercentageCut()}");
                System.Console.WriteLine("Select the number for the member you want to add to your crew.");
                string selectedCrewString = Console.ReadLine();

                if (selectedCrewString == "")
                {
                    return;
                }
                int selectedCrew = int.Parse(selectedCrewString);

                if (selectedCrew >= 0 && selectedCrew < rolodex.Count)
                {
                    System.Console.WriteLine(rolodex[selectedCrew - 1].Name);
                }

                crew.Add(rolodex[selectedCrew - 1]);
                rolodex.RemoveAt(selectedCrew - 1);
                System.Console.WriteLine($"The total percentage cut is {totalPercentageCut()}");


                addAnotherCrewMember();

            }

            void addAnotherCrewMember()
            {
                CrewSelection();
            }

            int totalPercentageCut()
            {

                int totalPercentageCut = 0;
                {
                    foreach (IRobber member in crew)
                    {
                        totalPercentageCut += member.PercentageCut;
                    }
                }

                // System.Console.WriteLine($"Total Percentage Cut: {totalPercentageCut}");
                return totalPercentageCut;
            }

            void runHeist()
            {

                foreach (IRobber member in crew)
                {
                    member.PerformSkill(theBank);
                }

                if (theBank.AlarmScore + theBank.VaultScore + theBank.SecurityGuardScore <= 0)
                {
                    System.Console.WriteLine($"You robbed the bank and walked away with ${theBank.CashOnHand}");
                    foreach (IRobber member in crew)
                    {
                        int memberCut = member.PercentageCut * (theBank.CashOnHand / 100);

                        System.Console.WriteLine($"{member.Name} walked away with ${memberCut}.");

                    }
                    if (totalPercentageCut() < 100)
                    {
                        int yourCut = ((100 - totalPercentageCut()) * (theBank.CashOnHand / 100));

                        System.Console.WriteLine($"And you (the brains behind the operation) take ${yourCut}.");
                    }

                }
                else
                {
                    System.Console.WriteLine($"Go directly to jail - do not past go, do not collect $200");
                }
            }
            runHeist();


        }





    }




}


