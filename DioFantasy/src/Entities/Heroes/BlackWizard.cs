using System;

namespace ProjetoRPG.src.Entities
{
    internal class BlackWizard : Wizard
    {
        public string Name { get; protected set; } = "BlackWizard";
        public string NPCType { get; protected set; } = "Black Wizard";

        public int BodyAttackDamage { get; protected set; } = 5;
        public int BodyAttackEnergyCost { get; protected set; } = 10;

        public int MagicAttackDamage { get; protected set; } = 40;
        public int MagicAttackMagicCost { get; protected set; } = 50;

        public int MaxHealthPoints { get; protected set; } = 100;
        public int HealthPoints { get; protected set; }
        public int BonusClassHealthPointsPerLevel { get; protected set; } = 10;

        public int MaxEnergyPoints { get; protected set; } = 30;
        public int EnergyPoints { get; protected set; }
        public int EnergyPointsRecoveredPerRound { get; protected set; } = 3;
        public int BonusClassEnergyPointsPerLevel { get; protected set; } = 1;

        public int MaxMagicPoints { get; protected set; } = 300;
        public int MagicPoints { get; protected set; }
        public int MagicPointsRecoveredPerRound { get; protected set; } = 15;
        public int BonusClassMagicPointsPerLevel { get; protected set; } = 30;

        public int Shield { get; protected set; } = 0;

        public BlackWizard()
        {

        }

        public BlackWizard(string name) : base(name)
        {

        }
    }
}
