using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

public enum WeaponProperty
{
    name = 0,
    rarity = 1,
    damage = 2,
}

namespace WeaponSorting
{
    internal class SortData
    {
        public static List<List<Weapon>> MergeSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            Weapon[] weaponArray = weaponList.ToArray();
            Merge(weaponArray);
            List<Weapon> sortedWeaponList = weaponArray.ToList();
            sortedLists.Add(sortedWeaponList);

            sortedLists.Add(weaponList);
            sortedLists.Add(weaponList);

            return sortedLists;
        }

        private static void Merge(Weapon[] weaponArray)
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
            Merge(left);
            Merge(right);

            // Após a ordenação, é feita a mesclagem(merge) dos dois sub-arrays, copiando
            //seus valores para o array principal. A cópia é feita retirando o menor dos
            //valores de cada sub-array, até que um dos sub-arrays fique vazio.
            int il = 0;// índice da esquerda
            int ir = 0;// índice da direita
            int ix = 0;// índice final
            while (il < left.Length && ir < right.Length)
            {
                if (GetFirstInAlfabeticalOrder(left[il].Name, right[ir].Name))
                //if (left[il].Name < right[ir].Name)
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

            //Console.WriteLine($"Parameters: {firstName} - {secondName}");

            for (int i = 0; i < firstName.Length; i++)
            {
                if (i < secondName.Length)
                {
                    Console.WriteLine($"Comparing {firstName[i]} and {secondName[i]}");
                    if (firstName[i] < secondName[i])
                    {
                        Console.WriteLine($"{firstName[i]} comes before {secondName[i]}");
                        firstNameComesFirst = true;
                        break;
                    }
                    else if (firstName[i] > secondName[i])
                    {
                        Console.WriteLine($"{secondName[i]} comes before {firstName[i]}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{firstName[i]} is the same letter {secondName[i]}");
                    }
                }           
            }

            if (firstNameComesFirst)
            {
                Console.WriteLine($"{firstName} comes before than {secondName}");
            }
            else Console.WriteLine($"{secondName} comes before than {firstName}");

            return firstNameComesFirst;
        }
    }
}
