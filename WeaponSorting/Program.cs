using WeaponSorting;

string weaponsPath = "data/weapons.txt";

List<Weapon> weapons = new List<Weapon>();

weapons.AddRange(FileReader.CreateWeaponList(weaponsPath));

Console.WriteLine(weapons.Count);

foreach (Weapon weapon in weapons)
{
    Console.WriteLine(weapon);
}