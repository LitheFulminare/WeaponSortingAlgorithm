using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// usado pra facilmente definir qual propriedade deve ser usada para comparar dentro de um for loop
public enum WeaponProperty
{ 
    Name = 0,
    Rarity = 1,
    Damage = 2,
}

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

        public string Name => _name;
        public string Rarity => _rarity;
        public int Damage => _damage; 

        public override string ToString()
        {
            return $"{_name} - {_rarity} - {_damage}";
        }
    }
}
