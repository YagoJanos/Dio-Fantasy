using System;

namespace ProjetoRPG.src.Entities
{
    public abstract class Wizard : NPC
    { 
        public string CombatType { get; protected set; } = "Magic";

        public Wizard()
        {

        }

        public Wizard(string name) : base(name)
        {

        }

        public Wizard(string name, int level) :base(name, level)
        {

        }

    }
}