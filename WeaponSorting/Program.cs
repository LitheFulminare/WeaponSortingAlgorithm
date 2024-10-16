using WeaponSorting;

string weaponsPath = "data/weapons.txt";

List<Weapon> weapons = new List<Weapon>();

weapons.AddRange(FileReader.CreateWeaponList(weaponsPath));

foreach (Weapon weapon in weapons)
{
    Console.WriteLine(weapon);
}