using WeaponSorting;

string weaponsPath = "data/weapons.txt";

List<Weapon> weapons = new List<Weapon>();

weapons.AddRange(FileReader.CreateWeaponList(weaponsPath));

//PrintAllWeapons();

// criar um while que repete essas frases até o user colocar um input valido
Console.WriteLine("Digite qual algorítimo deve ser usado para ordenar as armas");
Console.WriteLine("1 - Merge Sort");
Console.WriteLine("2 - Quick Sort");
string userInputStr = Console.ReadLine();
void PrintAllWeapons()
{
    foreach (Weapon weapon in weapons)
    {
        Console.WriteLine(weapon);
    }
}

