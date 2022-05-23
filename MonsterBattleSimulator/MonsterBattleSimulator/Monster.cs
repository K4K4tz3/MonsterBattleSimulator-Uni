using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterBattleSimulator
{
    internal class Monster
    {
        internal float hp, ap, dp, s;
        internal MonsterType type;
        internal void Attack(Monster defender)
        {
            float damage = this.ap - defender.dp;
            if (this.ap < defender.dp) return;
            else defender.hp = defender.hp - damage;
            if (defender.hp < .0f) defender.hp = .0f;
        }
        internal void AttackPremium(Monster defender)
        {
            float damage = this.ap - defender.dp;
            if (this.ap < defender.dp) return;
            else defender.hp = defender.hp - damage;
            Console.WriteLine($"{this.type} attacked {defender.type} and made {damage} damage.");
            if (defender.hp < .0f)
            {
                defender.hp = .0f;
                return;
            }
            Thread.Sleep(500);
            Console.WriteLine($"{defender.type} remains with {defender.hp} health");
            Thread.Sleep(1250);
        }
    }
    enum MonsterType
    {
        Ork = 1,
        Troll = 2,
        Goblin = 3,
    }
}

