using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponSorting
{
    internal class Comparator
    {
        // usado para facilmente comparar raridade de duas armas
        private static Dictionary<string, int> rarityStringToInt = new Dictionary<string, int>
        {
            { "common", 0 },
            { "rare", 1 },
            { "epic", 2 },
            { "legendary", 3 }
        };

        public static bool CompareProperties(Weapon firstWeapon, Weapon secondWeapon, WeaponProperty weaponProperty)
        {
            switch (weaponProperty)
            {
                // organiza em ordem alfabética crescente (de A para Z)
                case WeaponProperty.Name: return GetFirstInAlfabeticalOrder(firstWeapon.Name, secondWeapon.Name);

                // organiza por raridade em ordem decrescente (comparação feita pelo dicionario)
                case WeaponProperty.Rarity: return rarityStringToInt[firstWeapon.Rarity] >= rarityStringToInt[secondWeapon.Rarity];

                // organiza por dano em ordem decrescente
                default: return (firstWeapon.Damage > secondWeapon.Damage);
            }
        }

        private static bool GetFirstInAlfabeticalOrder(string firstName, string secondName)
        {
            for (int i = 0; i < firstName.Length; i++)
            {
                if (i < secondName.Length)
                {
                    if (firstName[i] < secondName[i])
                    {
                        return true;
                    }

                    if (firstName[i] > secondName[i])
                    {
                        return false;
                    }

                    // caso as letras sejam iguais ele continua comparando
                }
            }

            return false;
        }
    }
}
