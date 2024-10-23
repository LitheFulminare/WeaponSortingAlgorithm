using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WeaponSorting
{
    internal class SortData
    {
        /*------------------------------------ MERGE SORT ------------------------------------*/

        // chamado por program
        // lida com o loop para orgazinar usando 3 parametros diferentes
        // a organização de fato é feita pelo metodo privado 'Merge'
        public static List<List<Weapon>> MergeSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            Weapon[] weaponArray = weaponList.ToArray();

            for (int i = 0; i < 3; i++)
            {              
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

                // compara as propriedades das duas armas
                if (Comparator.CompareProperties(left[il], right[ir], weaponProperty))
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


        /*------------------------------------ QUICK SORT ------------------------------------*/


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
                // Partition retorna o index do pivô
                int pi = Partition(arr, low, high, weaponProperty);

                // dá sort nos subarrays cortados pelo pivô
                Quick(arr, low, pi - 1, weaponProperty);
                Quick(arr, pi + 1, high, weaponProperty);
            }
        }
        
        // partição do quick sort
        static int Partition(Weapon[] arr, int low, int high, WeaponProperty weaponProperty)
        {
            Weapon pivot = arr[high];

            // index do menor elemento
            int i = low - 1;

            // aqui que é comparação acontece
            // geralmente, aqui os elementos menores que o pivô seriam movidos pra esquerda
            // aqui a ordem alfabética é crescente, mas raridade e dano é decrescente

            for (int j = low; j <= high - 1; j++)
            {
                // compara as propriedades das duas armas
                if (Comparator.CompareProperties(arr[j], pivot, weaponProperty))
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1; // retorna o index pra ser usado nas calls recursivas
        }

        // usada pelo quick sort
        static void Swap(Weapon[] arr, int i, int j)
        {
            Weapon temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
