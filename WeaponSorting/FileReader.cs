using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponSorting
{
    internal class FileReader
    {
        public static List<Weapon> CreateWeaponList(string filepath)
        {
            List<Weapon> weapons = new List<Weapon>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string? name;

                // lê a linha que contém o nome da arma
                while ((name = reader.ReadLine()) != null)
                {

                    // lê a proxima linha, a raridade
                    string? rarity = reader.ReadLine();

                    // lê a próxima linha, o dano
                    string? damageStr = reader.ReadLine();

                    // tenta transformar a string 'damageStr' num 'int'
                    int damage = 0;
                    if (damageStr != null) { damage = int.Parse(damageStr); }

                    // cria nova intancia do obj 'Weapon' usando os dados q acabou de ler e adciona a lista
                    Weapon weapon = new Weapon(name, rarity, damage);
                    weapons.Add(weapon);
                }
            }
            return weapons;
        }
    }
}
