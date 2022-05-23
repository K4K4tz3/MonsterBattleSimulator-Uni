using System;
using System.Collections.Generic;
using System.Threading;

namespace MonsterBattleSimulator
{
    class Program
    {
        private static List<MonsterType> monsterTypes = new List<MonsterType>() { MonsterType.Ork, MonsterType.Troll, MonsterType.Goblin };
        private static bool fight = true;
        private static int rounds = 0;
        private static bool choice = false;
        private static int turn; // 0 -> Player/Monster1, 1 -> Enemy/Monster2
        internal static void Main(string[] args)
        {
            Console.WriteLine("Dear Challenger");
            Thread.Sleep(500);
            Console.WriteLine("I welcome you to the glorious Monster Battle Arenaaa");
            Thread.Sleep(500);
            showFight();
            Console.WriteLine("Please customize your Monster!");
            Thread.Sleep(1000);
            Console.Clear();
            Monster player = new Monster();
            create_Character(player, "players");

            Console.WriteLine("Please customize your opponents Monster!");
            Thread.Sleep(1000);
            Console.Clear();
            Monster enemy = new Monster();
            create_Character(enemy, "opponents");

            if (player.s > enemy.s) turn = 0; //the player starts the fight
            else if (player.s < enemy.s) turn = 1; //the enemy starts the fight

            Fight(player, enemy);
        }
        internal static void create_Character(Monster currentMonster, string character)
        {
            Console.WriteLine($"Choose your {character} monster:");
            for (int i = 0; i < monsterTypes.Count; i++) Console.WriteLine($"{i + 1}. {monsterTypes[i]}");
            int type = Convert.ToInt16(Console.ReadLine());
            currentMonster.type = (MonsterType)type;
            monsterTypes.RemoveAt(type - 1);
            Console.WriteLine("How high are his attributes?");
            Console.Write("Health: ");
            currentMonster.hp = checkInput(Console.ReadLine(), "Health");
            Console.Write("Attack Power: ");
            currentMonster.ap = checkInput(Console.ReadLine(), "Attack Power");
            Console.Write("Defence Power: ");
            currentMonster.dp = checkInput(Console.ReadLine(), "Defence Power");
            Console.Write("Speed: ");
            currentMonster.s = checkInput(Console.ReadLine(), "Speed");
            Thread.Sleep(500);
            Console.Clear();
        }
        internal static float checkInput(string Input, string attribute = "")
        {
            float output;

            try
            {
                if (float.Parse(Input) <= .0f) throw new ArgumentOutOfRangeException();
                return output = float.Parse(Input);
            }
            catch
            {
                Console.WriteLine("That wasn't a valid input.");
                Thread.Sleep(500);
                Console.WriteLine("Please enter a positive number which is bigger than 0.");
                Thread.Sleep(1000);
                Console.Clear();
                Console.Write($"{attribute}: ");
                checkInput(Console.ReadLine(), attribute);
            }
            return .0f;
        }
        internal static void showFight()
        {
            Console.WriteLine("Do you want to be shown the fight? y/yes or n/no:");
            string c = Console.ReadLine();
            if (c == "y" || c == "yes" || c == "Y" || c == "Yes") choice = true;
        }
        internal static void Fight(Monster player, Monster enemy)
        {
            while (fight)
            {
                if (player.hp == .0f | enemy.hp == .0f)
                {
                    if (player.hp == .0f) Winner(enemy.type, rounds, enemy.hp);
                    if (enemy.hp == .0f) Winner(player.type, rounds, player.hp);
                    fight = false;
                }
                if (rounds == 100) aDraw();
                else
                {
                    switch (turn, choice)
                    {
                        case (0, false):
                            player.Attack(enemy);
                            turn = 1;
                            break;
                        case (1, false):
                            enemy.Attack(player);
                            turn = 0;
                            break;
                        case (0, true):
                            player.AttackPremium(enemy);
                            turn = 1;
                            break;
                        case (1, true):
                            enemy.AttackPremium(player);
                            turn = 0;
                            break;
                    }
                    rounds++;
                }
            }
        }
        internal static void Winner(MonsterType winner, int roundsNeeded, float remainingHP)
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine($"The fight ended after {roundsNeeded} rounds.");
            Thread.Sleep(500);
            Console.WriteLine($"Our winner survived with {remainingHP} HP left.");
            Thread.Sleep(500);
            Console.WriteLine("But i know, you all are curious who the winner is.");
            Thread.Sleep(500);
            Console.Write($"Anndddd our winner is......");
            Thread.Sleep(500);
            Console.WriteLine($" the glorious {winner}!");
            Console.ReadLine();
        }
        internal static void aDraw()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("After countless rounds...");
            Thread.Sleep(500);
            Console.WriteLine("Of brutal fights....");
            Thread.Sleep(500);
            Console.WriteLine("We sadly announce that we dont have a winner....");
            Thread.Sleep(500);
            Console.WriteLine("Both monsters presented huge power.");
            Thread.Sleep(500);
            Console.WriteLine("But they are on equal powerlevels.");
            Thread.Sleep(500);
        }
    }
}