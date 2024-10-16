using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponSorting
{
    internal class Weapon
    {
        // dados extraidos do arquivo 'weapons.txt'
        private string _name;
        private string _rarity;
        private int _damage;

        public Weapon(string name, string rarity, int damage)
        {
            this._name = name;
            this._rarity = rarity;
            this._damage = damage;
        }

        // propriedades
        public string Name => _name;
        public string Rarity => _rarity;
        public int Damage => _damage; 

        // agora é usado pra debug, talvez não tenha uso mais tarde
        public override string ToString()
        {
            return $"{_name} {_rarity} {_damage}";
        }
    }
}
