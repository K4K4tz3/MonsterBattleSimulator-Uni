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
            if (this.ap < defender.dp) return;
            else defender.hp = defender.hp - (this.ap - defender.dp);
            if (defender.hp < .0f) defender.hp = .0f;
        }
    }
    enum MonsterType
    {
        Ork = 1,
        Troll = 2,
        Goblin = 3,
    }
}

