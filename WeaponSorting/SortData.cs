﻿using System;
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
        // usado para facilmente comparar raridade de duas armas
        static Dictionary<string, int> rarityStringToInt = new Dictionary<string, int>
        {
            { "common", 0 },
            { "rare", 1 },
            { "epic", 2 },
            { "legendary", 3 }
        };

        // chamado por program
        // lida com o loop para orgazinar usando 3 parametros diferentes
        // a organização de fato é feita pelo metodo privado 'Merge'
        public static List<List<Weapon>> MergeSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            for (int i = 0; i < 3; i++)
            {
                Weapon[] weaponArray = weaponList.ToArray();
                Merge(weaponArray, (WeaponProperty)i);
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
                // é aqui que a comparação e organização de dados realmente acontece

                bool value = false; // guarda o resultado comparação (ex.: se o dano da arma da esquerda é maior que o da direita)

                // switch case para pegar qual propriedade deve ser comparada
                // quick sort tem um igual
                switch (weaponProperty)
                {
                    // organiza em ordem alfabética crescente (de A para Z)
                    case WeaponProperty.Name: value = GetFirstInAlfabeticalOrder(left[il].Name, right[ir].Name); break;
                    
                    // organiza por raridade em ordem decrescente (comparação feita pelo dicionario)
                    case WeaponProperty.Rarity: value = rarityStringToInt[left[il].Rarity] >= rarityStringToInt[right[ir].Rarity]; break; 
                    
                    // organiza por dano em ordem decrescente
                    case WeaponProperty.Damage: value = (left[il].Damage > right[ir].Damage); break;
                }

                if (value)
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

        // chamado por program
        // lida com o loop para orgazinar usando 3 parametros diferentes
        // a organização de fato é feita pelo metodo privado 'Quick'
        public static List<List<Weapon>> QuickSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            Weapon[] weaponArray = weaponList.ToArray();
            int len = weaponArray.Length;

            for (int i = 0; i < 3; i++)
            {
                Quick(weaponArray, 0, len - 1, (WeaponProperty)i);
                List<Weapon> sortedWeaponList = weaponArray.ToList();
                sortedLists.Add(sortedWeaponList);
            }

            return sortedLists;
        }

        private static void Quick(Weapon[] arr, int low, int high, WeaponProperty weaponProperty)
        {
            if (low < high)
            {
                // pi is the partition return index of pivot
                int pi = Partition(arr, low, high, weaponProperty);

                // Recursion calls for smaller elements
                // and greater or equals elements
                Quick(arr, low, pi - 1, weaponProperty);
                Quick(arr, pi + 1, high, weaponProperty);
            }
        }
        
        // partição do quick sort
        static int Partition(Weapon[] arr, int low, int high, WeaponProperty weaponProperty)
        {
            Weapon pivot = arr[high];

            // index do menor elemento
            // indica a posição certa do pivô
            int i = low - 1;

            // aqui que é comparação acontece
            // geralmente, aqui os elementos menores que o pivô seriam movidos pra esquerda
            // aqui a ordem alfabética é crescente, mas raridade e dano é decrescente
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j].Damage < pivot.Damage)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1; // retorna o index do pivô pra ser usado nsa calls recursivas
        }

        // usada pelo quick sort
        static void Swap(Weapon[] arr, int i, int j)
        {
            Weapon temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
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

                    // caso as letras sejam iguais, não dá break e ele continua comparando
                }           
            }

            return false;
        }
    }
}
