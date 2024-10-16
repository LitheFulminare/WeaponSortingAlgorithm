using WeaponSorting;

string weaponsPath = "weapons.txt";

List<Weapon> weapons = new List<Weapon>();

weapons.AddRange(FileReader.CreateWeaponList(weaponsPath));