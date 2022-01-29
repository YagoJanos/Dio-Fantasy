using System;



namespace ProjetoRPG.src.Entities
{
    
    internal class Knight : Warrior
    {
        public string Name { get; protected set; } = "Knight";
        public string NPCType { get; protected set; } = "Kight";
        public int BodyAttackDamage { get; protected set; } = 20;
        public int BodyAttackEnergyCost { get; protected set; } = 40;

        public int MagicAttackDamage { get; protected set; } = 0;
        public int MagicAttackMagicCost { get; protected set; } = 100;

        public int MaxHealthPoints { get; protected set; } = 200;
        public int HealthPoints { get; protected set; }
        public int BonusClassHealthPointsPerLevel { get; protected set; } = 15;

        public int MaxEnergyPoints { get; protected set; } = 160;
        public int EnergyPoints { get; protected set; }
        public int EnergyPointsRecoveredPerRound { get; protected set; } = 10;
        public int BonusClassEnergyPointsPerLevel { get; protected set; } = 30;

        public int MaxMagicPoints { get; protected set; } = 0;
        public int MagicPoints { get; protected set; }
        public int MagicPointsRecoveredPerRound { get; protected set; } = 2;
        public int BonusClassMagicPointsPerLevel { get; protected set; } = 5;

        public int Shield { get; protected set; } = 20;



        public Knight(){

        }

        public Knight(string name) : base(name)
        {

        }

        
    }
}