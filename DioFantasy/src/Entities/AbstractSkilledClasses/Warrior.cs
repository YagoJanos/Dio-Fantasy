using System;
using System.Collections.Generic;


namespace ProjetoRPG.src.Entities
{
    internal abstract class Warrior : NPC
    {
        public string CombatType { get; protected set; } = "Melee";

        public Warrior()
        {

        }

        public Warrior(string name) : base(name)
        {

        }

        public Warrior(string name, int level) : base(name, level)
        {

        }


    }
}
