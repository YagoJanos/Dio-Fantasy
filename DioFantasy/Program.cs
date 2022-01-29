// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using ProjetoRPG.src.Entities;

class Program 
{

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Dio Fantasy");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();



        Console.WriteLine("Character creation screen");

        Console.Write("Enter a name for you Knight: ");
        string knightName = Console.ReadLine();
        Console.WriteLine();

        NPC knight = new Knight(knightName);

        Console.Write("Enter a name for you Ninja: ");
        string ninjaName = Console.ReadLine();
        Console.WriteLine();

        NPC ninja = new Ninja(ninjaName);

        Console.Write("Enter a name for you White Wizard: ");
        string whiteWizardName = Console.ReadLine();
        Console.WriteLine();

        NPC whiteWizard = new WhiteWizard(whiteWizardName);

        Console.Write("Enter a name for you Black Wizard: ");
        string blackWizardName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        Console.Clear();



        NPC blackWizard = new BlackWizard(blackWizardName);

        List<NPC> listOfHeroes = new List<NPC>() { knight, ninja, whiteWizard, blackWizard};

        
        
        int levelCounter = 0;

        while(knight.IsDead == false && ninja.IsDead == false && whiteWizard.IsDead == false && blackWizard.IsDead == false)
        {
            Console.WriteLine("Level " + levelCounter);
            int enemyLevel = levelCounter;

            NPC enemy = new CapraDemon($"Capra Demon lvl {enemyLevel}", enemyLevel);

            Console.WriteLine("Enemy is " + enemy.Name);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();


            while(enemy.IsDead == false && knight.IsDead == false && ninja.IsDead == false && whiteWizard.IsDead == false && blackWizard.IsDead == false)
            {
                PrintHeroesStatus(listOfHeroes);
                Console.WriteLine();
                PrintEnemyStatus(enemy);
                Console.WriteLine();

                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();

                PlayerAttackMenu(listOfHeroes, enemy);

                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();

                


                if(enemy.IsDead == false)
                {
                    EnemyAttacksHero(listOfHeroes, enemy);
                }
                PrintHeroesStatus(listOfHeroes);

            }

            if(blackWizard.IsDead == true)
            {
                Console.WriteLine("Congratulations, you win the fight");
            }
            else
            {
                Console.WriteLine("You lose");
                return;
            }

            levelCounter++;
        }
    }

    public static void PrintHeroesStatus(List<NPC> heroList)
    {
        Console.WriteLine("Your heroes:");
        Console.WriteLine();

        foreach(NPC hero in heroList)
        {
            hero.PrintStatus();
        }
    }

    public static void PrintEnemyStatus(NPC enemy)
    {
        Console.WriteLine("Enemy: ");
        Console.WriteLine();
        enemy.PrintStatus();
    }

    public static void PlayerAttackMenu(List<NPC> heroList, NPC enemy)
    {
        Console.WriteLine("Choose a hero to attack:");
        int choiceNumber;
        for(int i = 0; i < heroList.Count; i++)
        {
            NPC hero = heroList[i];
            Console.WriteLine(i + " - " + hero.NPCType + " " + hero.Name);
        }

        Console.Write("Your choice: ");
        choiceNumber = int.Parse(Console.ReadLine());

        heroList[choiceNumber].MeleeAttack(enemy);
    }

    public static void DeleteHeroFromListIfHeDies(List<NPC> heroList)
    {
        foreach (NPC hero in heroList)
        {
            if (hero != null && hero.CheckIfIsDead())
            {
                 heroList.Remove(hero);
            }
        }
    }

    public static void EnemyAttacksHero(List<NPC> heroList, NPC enemy)
    {
        Random random = new Random();
        int indexOfHeroChosenByEnemyToBeAttacked = random.Next(0, heroList.Count);

        NPC heroThatWillBeHitByTheEnemy = heroList[indexOfHeroChosenByEnemyToBeAttacked];

        if (enemy.CombatType == "Melee")
        {
            enemy.MeleeAttack(heroThatWillBeHitByTheEnemy);
        } else
        {
            enemy.MagicAttack(heroThatWillBeHitByTheEnemy);
        }
    }

}
