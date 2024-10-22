using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WeaponSorting
{
    internal class SortData
    {
        static Dictionary<string, int> rarityStringToInt = new Dictionary<string, int>
        {
            { "common", 0 },
            { "rare", 1 },
            { "epic", 2 },
            { "legendary", 3 }
        };

        public static List<List<Weapon>> MergeSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            for (int i = 0; i < 3; i++)
            {
                Weapon[] weaponArray = weaponList.ToArray();
                Merge(weaponArray, (WeaponProperty)i + 1);
                List<Weapon> sortedWeaponList = weaponArray.ToList();
                sortedLists.Add(sortedWeaponList);
            }

            return sortedLists;
        }

        private static void Merge(Weapon[] weaponArray, WeaponProperty weaponProperty)
        {
            // Caso um array tenha 0 ou 1 elementos, ele já está ordenado
            if (weaponArray.Length < 2)
            {
                return;
            }

            // O Merge Sort começa dividindo o problema em pedaços menores. Por isso, é
            //feita a divisão do array em 2 sub-arrays.
            int halfength = weaponArray.Length / 2;
            Weapon[] left = new Weapon[halfength];
            Weapon[] right = new Weapon[weaponArray.Length - halfength];

            // Populando os sub-arrays
            for (int i = 0; i < halfength; i++)
            {
                left[i] = weaponArray[i];
            }
            for (int i = halfength; i < weaponArray.Length; i++)
            {
                right[i - halfength] = weaponArray[i];
            }

            // Ordenação dos sub-arrays com o próprio Merge Sort, recursivamente.
            Merge(left, weaponProperty);
            Merge(right, weaponProperty);

            // Após a ordenação, é feita a mesclagem(merge) dos dois sub-arrays, copiando
            //seus valores para o array principal. A cópia é feita retirando o menor dos
            //valores de cada sub-array, até que um dos sub-arrays fique vazio.
            int il = 0;// índice da esquerda
            int ir = 0;// índice da direita
            int ix = 0;// índice final
            while (il < left.Length && ir < right.Length)
            {
                // é aqui que a magica acontece

                bool value = false; // guarda o resultado comparação (ex.: se o dano da arma da esquerda é maior que o da direita)

                switch (weaponProperty)
                {
                    case WeaponProperty.Name: value = GetFirstInAlfabeticalOrder(left[il].Name, right[ir].Name); break;
                    case WeaponProperty.Rarity: value = rarityStringToInt[left[il].Rarity] <= rarityStringToInt[right[ir].Rarity]; break; // compara usando o dicionario
                    case WeaponProperty.Damage: value = (left[il].Damage < right[ir].Damage); break;
                }

                if (value)
                //if (left[il] < right[ir])
                {
                    weaponArray[ix] = left[il];
                    il++;
                }
                else
                {
                    weaponArray[ix] = right[ir];
                    ir++;
                }
                ix++;
            }

            // Por fim é feita a cópia dos elementos restantes dos sub-arrays
            while (il < left.Length)
            {
                weaponArray[ix] = left[il];
                il++;
                ix++;
            }
            while (ir < right.Length)
            {
                weaponArray[ix] = right[ir];
                ir++;
                ix++;
            }
        }

        public static List<List<Weapon>> QuickSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            return sortedLists;
        }

        private static bool GetFirstInAlfabeticalOrder(string firstName, string secondName)
        {
            bool firstNameComesFirst = false;

            for (int i = 0; i < firstName.Length; i++)
            {
                if (i < secondName.Length)
                {
                    if (firstName[i] < secondName[i])
                    {
                        firstNameComesFirst = true;
                        break;
                    }
                    else if (firstName[i] > secondName[i])
                    {
                        break;
                    }
                    // caso as letras sejam iguais, não dá break e ele continua comparando
                }           
            }

            return firstNameComesFirst;
        }
    }
}
