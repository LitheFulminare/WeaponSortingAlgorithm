using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponSorting
{
    internal class SortData
    {
        public static List<List<Weapon>> MergeSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            sortedLists.Add(weaponList);
            sortedLists.Add(weaponList);
            sortedLists.Add(weaponList);

            return sortedLists;
        }

        public static List<List<Weapon>> QuickSort(List<Weapon> weaponList)
        {
            List<List<Weapon>> sortedLists = new List<List<Weapon>>();

            return sortedLists;
        }
    }
}
