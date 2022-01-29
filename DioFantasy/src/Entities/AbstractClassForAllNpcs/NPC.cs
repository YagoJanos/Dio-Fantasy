using System;

namespace ProjetoRPG.src.Entities
{
    public abstract class NPC
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }
        public int Experience { get; protected set; }
        public string CombatType { get; protected set; }
        public string NPCType { get; protected set; }

        public int BodyAttackDamage { get; protected set; }
        public int BodyAttackEnergyCost { get; protected set; }

        public int MagicAttackDamage { get; protected set; }
        public int MagicAttackMagicCost { get; protected set; }

        public int MaxHealthPoints { get; protected set; }
        public int HealthPoints { get; protected set; }
        public int BonusClassHealthPointsPerLevel { get; protected set; }

        public int MaxEnergyPoints { get; protected set; }
        public int EnergyPoints { get; protected set; }
        public int EnergyPointsRecoveredPerRound { get; protected set; }
        public int BonusClassEnergyPointsPerLevel { get; protected set; }

        public int MaxMagicPoints { get; protected set; }
        public int MagicPoints { get; protected set; }
        public int MagicPointsRecoveredPerRound { get; protected set; }
        public int BonusClassMagicPointsPerLevel { get; protected set; }

        public int Shield { get; protected set; }
        
        public bool IsDead { get; protected set; }



        public NPC()
        {
            NewLevelAttributesCalculator();

            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
            MagicPoints = MaxMagicPoints;

            IsDead = false;
        }

        public NPC(string name) //Constructor that we use to create default heroes
        {
            Name = name;

            Experience = 0;
            Level = 0;

            NewLevelAttributesCalculator();

            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
            MagicPoints = MaxMagicPoints;

            IsDead = false;
        }

        public NPC(string name, int level) //We can use this constructor to create enemies
        {
            Name = name;
            Level = level;

            NewLevelAttributesCalculator();

            HealthPoints = MaxHealthPoints;
            EnergyPoints = MaxEnergyPoints;
            MagicPoints = MaxMagicPoints;

            IsDead = false;
        }

        public override string ToString()
        {
            return this.Name + " " + this.Level + " " + this.CombatType;
        }



        public virtual void MeleeAttack(NPC enemy)
        {
            if (IsDead)
            {
                return;
            }

            if (EnergyPoints < BodyAttackEnergyCost)
            {
                Console.WriteLine("Insufficient Energy to Attack, wait your character to rest.");
                Console.WriteLine();
                return;
            }

            Random random = new Random();
            int probabilityGenerator = random.Next(0, 11);
            
            int damage = 1;
            int bonusDamage = 0;

            if (probabilityGenerator < 5)
            {
                bonusDamage = 15;
            }
            else if (probabilityGenerator < 8)
            {
                bonusDamage = 25;
            }
            else if (probabilityGenerator < 9)
            {
                bonusDamage = 40; //critical hit
            }
            else if (probabilityGenerator < 10)
            {
                damage = 0; //miss
            }

            Console.WriteLine(this.Name + " attacked" + enemy.Name + " with a melee atack");
            Console.WriteLine();

            if (damage == 0)
            {
                Console.WriteLine("Missed");
                Console.WriteLine();
            } else
            {
                damage = bonusDamage + BodyAttackDamage;
                EnergyPoints -= BodyAttackEnergyCost;

                enemy.GetHurt(damage);

                if(enemy.IsDead == true)
                    IncreaseExperienceByKillingAnEnemy(enemy);
            }


        }

        public virtual void MagicAttack(NPC enemy)
        {
            if (IsDead)
            {
                return;
            }

            if (MagicPoints < MagicAttackMagicCost)
            {
                Console.WriteLine("Insufficient MP, wait your wizard to rest.");
                Console.WriteLine();
                return;
            }

            Random random = new Random();
            int probabilityGenerator = random.Next(10);

            int damage = 1;
            int bonusDamage = 0;

            if (probabilityGenerator < 5)
            {
                bonusDamage = 15;
            }
            else if (probabilityGenerator < 8)
            {
                bonusDamage = 25;
            }
            else if (probabilityGenerator < 9)
            {
                bonusDamage = 40; //critical hit
            }
            else if (probabilityGenerator < 10)
            {
                damage = 0; //miss
            }

            Console.WriteLine(this.Name + " attacked" + enemy.Name + " with a spell");
            Console.WriteLine();

            if (damage == 0)
            {
                Console.WriteLine("Missed");
                Console.WriteLine();
            }
            else
            {
                damage = bonusDamage + MagicAttackDamage;
                MagicPoints -= MagicAttackMagicCost;

                enemy.GetHurt(damage);



                if (enemy.IsDead == true)
                    IncreaseExperienceByKillingAnEnemy(enemy);
            }


        }

        public void GetHurt(int damage)
        {
            if (IsDead)
            {
                return;
            }
            
            int HealthDecreased = damage - Shield;

            if (HealthDecreased < 0)
            {
                HealthDecreased = 0;
            }

            HealthPoints -= HealthDecreased;
                
            Console.WriteLine(Name + $" lost {HealthDecreased} HP");
            Console.WriteLine();

            CheckIfIsDead();
        }

        public void IncreaseExperienceByKillingAnEnemy(NPC victim)
        {
            Experience += victim.Level * 10;
            Console.WriteLine(Name + " gained " + Experience + " by killing " + victim.Name);
            Console.WriteLine();

            CheckExperienceAndChangeLevelIfEnough();
        }

        public void IncreaseExperienceByWinningAFight(int fightLevel)
        {
            Experience += fightLevel * 100;
            Console.WriteLine(Name + " gained " + Experience + " by winning the fight");
            Console.WriteLine();

            CheckExperienceAndChangeLevelIfEnough();
        }

        public void NewLevelAttributesCalculator() //Devo arrumar um jeito de fazer com que os atributos mudem sem atrapalhar a batalha
        {
            MaxHealthPoints = 100 + (10 * Level) + (BonusClassHealthPointsPerLevel * Level);
            MaxMagicPoints = 100 + (10 * Level) + (BonusClassMagicPointsPerLevel * Level);
            MaxEnergyPoints = 100 + (10 * Level) + (BonusClassEnergyPointsPerLevel * Level);
        }
        public void CheckExperienceAndChangeLevelIfEnough()
        {
            int currentLevel = Level;
            int expectedLevel = 0;
            if(Experience >= 0 && Experience <= 100)
            {
                expectedLevel = 1;
            } 
            else if (Experience > 100 && Experience <= 300)
            {
                expectedLevel = 2;
            }
            else if (Experience > 300 && Experience <= 600)
            {
                expectedLevel = 3; 
            }
            else if (Experience > 600 && Experience <= 1000)
            {
                expectedLevel = 4;
            }
            else if (Experience > 1000 && Experience <= 1500)
            {
                expectedLevel = 5;
            }
            else if (Experience > 1500)
            {
                expectedLevel = 6;
            }

            if (currentLevel == expectedLevel)
            {
                return;
            } else
            {
                Level = expectedLevel;
                NewLevelAttributesCalculator();
                Console.WriteLine(Name + " has leveled up: Level " + Level + " reached!");
                Console.WriteLine();
            }
        }

        public bool CheckIfIsDead()
        {
            if (HealthPoints <= 0)
            {
                IsDead = true;
                Console.WriteLine(Name + " was obliterated");
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public void PrintStatus()
        {
            Console.WriteLine(Name + ": ");
            Console.WriteLine("HP: " + HealthPoints + "/" + MaxHealthPoints);
            Console.WriteLine("EP: " + EnergyPoints + "/" + MaxEnergyPoints);
            Console.WriteLine("MP: " + MagicPoints + "/" + MaxMagicPoints);
            Console.WriteLine();
        }

        public void ChangeStatusPerRound()
        {
            if(EnergyPoints + EnergyPointsRecoveredPerRound <= MaxEnergyPoints)
            {
                EnergyPoints += EnergyPointsRecoveredPerRound;
            } else
            {
                EnergyPoints = MaxEnergyPoints;
            }

            if(MagicPoints + MagicPointsRecoveredPerRound <= MaxMagicPoints)
            {
                MagicPoints += MagicPointsRecoveredPerRound;
            } else
            {
                MagicPoints = MaxMagicPoints;
            }
        }
    }
}