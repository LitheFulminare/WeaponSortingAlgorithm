/* LOGICA DO SORTING

// SortData recebe a lista de armas

 -loop 1-
 cria uma copia da original
 ordena pela ordem alfabetica
 armazena ela em sortedLists<List>
-loop 2-
 cria uma copia da original
 ordena por raridade
 armazena ela em sortedLists<List>
-loop 3-
 cria uma copia da original
 ordena por dano
 armazena ela em sortedLists<List>

 retorna sortedLists<List>

 program:
 printa todos os elementos da primeira, dps todos da segunda, etc */

using WeaponSorting;

string weaponsPath = "data/weapons.txt";

List<Weapon> weapons = new List<Weapon>();

weapons.AddRange(FileReader.CreateWeaponList(weaponsPath));

//PrintAllWeapons();

Console.WriteLine("Digite qual algorítimo deve ser usado para ordenar as armas");
Console.WriteLine("1 - Merge Sort");
Console.WriteLine("2 - Quick Sort\n");
string? userInputStr = Console.ReadLine();

if (userInputStr == "1")
{
    Console.WriteLine("\nMergeSort selecionado");
    PrintSortedWeapons(SortData.MergeSort(weapons));
}

else if (userInputStr == "2")
{
    Console.WriteLine("\nQuickSort selecionado"); 
    PrintSortedWeapons(SortData.QuickSort(weapons));
}

void PrintAllWeapons()
{
    foreach (Weapon weapon in weapons)
    {
        Console.WriteLine(weapon);
    }
}

void PrintSortedWeapons(List<List<Weapon>> weaponList)
{
    for (int i = 0; i < weaponList.Count; i++)
    {
        switch (i)
        {
            case 0: Console.WriteLine("\n------------------ ORDEM ALFABÉTICA ------------------\n"); break;
            case 1: Console.WriteLine("\n---------------------- RARIDADE ----------------------\n"); break;
            case 2: Console.WriteLine("\n------------------------ DANO ------------------------\n"); break;
                
            default : Console.WriteLine("Index inválidó"); break;
        }

        for (int j = 0; j < weaponList[i].Count; j++)
        {
            Console.WriteLine("Teste");
            //Console.WriteLine(weaponList[i][j]);
        }
    } 
}
