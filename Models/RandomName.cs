namespace TMPS_Labs.Models;

public static class RandomName {
  private static Random _rand = new();

  private static readonly string[] GameNames = {
    "The Legend of Zelda: Breath of the Wild",
    "The Witcher 3: Wild Hunt",
    "Red Dead Redemption 2",
    "Grand Theft Auto V",
    "Fortnite",
    "Minecraft",
    "Overwatch",
    "Call of Duty: Warzone",
    "Among Us",
    "League of Legends",
    "Valorant",
    "Cyberpunk 2077",
    "Apex Legends",
    "Animal Crossing: New Horizons",
    "Fall Guys",
    "Doom Eternal",
    "Hades",
    "Rainbow Six Siege",
    "Sekiro: Shadows Die Twice",
    "Death Stranding"
  };

  private static readonly string[] PersonNames = {
    "John Smith",
    "Emily Johnson",
    "Michael Williams",
    "Sophia Brown",
    "Daniel Davis",
    "Emma Jones",
    "Olivia Martinez",
    "William Jackson",
    "Ava Taylor",
    "James White",
    "Mia Lee",
    "Benjamin Harris",
    "Isabella Clark",
    "Ethan Lewis",
    "Oliver Hall",
    "Amelia Young",
    "Liam Walker",
    "Charlotte Turner",
    "Noah Moore"
  };

  private static readonly string[] CpuNames = {
    "Intel Core i9-11900K",
    "AMD Ryzen 9 5950X",
    "Intel Core i7-11700K",
    "AMD Ryzen 7 5800X",
    "Intel Core i5-11600K",
    "AMD Ryzen 5 5600X",
    "Intel Core i9-10900K",
    "AMD Ryzen 9 5900X",
    "Intel Core i7-10700K",
    "AMD Ryzen 7 5700X",
    "Intel Core i5-10600K",
    "AMD Ryzen 5 3600X",
    "Intel Core i9-9900K",
    "AMD Ryzen 9 3950X",
    "Intel Core i7-9700K",
    "AMD Ryzen 7 3800X",
    "Intel Core i5-9600K",
    "AMD Ryzen 5 3600",
    "Intel Core i9-11980HK",
    "AMD Ryzen 9 6900HX"
  };

  private static readonly string[] GpuNames = {
    "NVIDIA GeForce RTX 3090",
    "AMD Radeon RX 6900 XT",
    "NVIDIA GeForce RTX 3080",
    "AMD Radeon RX 6800 XT",
    "NVIDIA GeForce RTX 3070",
    "AMD Radeon RX 6700 XT",
    "NVIDIA GeForce RTX 3060 Ti",
    "AMD Radeon RX 6600 XT",
    "NVIDIA GeForce RTX 2080 Ti",
    "AMD Radeon RX 5700 XT",
    "NVIDIA GeForce RTX 2080 Super",
    "AMD Radeon RX 5600 XT",
    "NVIDIA GeForce RTX 2070 Super",
    "AMD Radeon RX 5500 XT",
    "NVIDIA GeForce GTX 1660 Ti",
    "AMD Radeon RX 590",
    "NVIDIA GeForce GTX 1080 Ti",
    "AMD Radeon RX Vega 64",
    "NVIDIA GeForce GTX 980 Ti",
    "AMD Radeon RX Vega 56"
  };

  private static readonly string[] SoftwareNames = {
    "Microsoft Office",
    "Adobe Photoshop",
    "AutoCAD",
    "Final Cut Pro",
    "Adobe Premiere Pro",
    "QuickBooks",
    "Logic Pro",
    "SketchUp Pro",
    "SolidWorks",
    "Pro Tools",
    "Adobe Illustrator",
    "CorelDRAW",
    "FL Studio",
    "Matlab",
    "Cinema 4D",
    "Zbrush",
    "VMware Workstation",
    "Rhino",
    "Ableton Live",
    "Toon Boom Harmony"
  };

  private static readonly string[] RamNames = {
    "Corsair Vengeance LPX 16GB DDR4",
    "G.Skill Ripjaws V 32GB DDR4",
    "Kingston HyperX Fury 8GB DDR4",
    "Crucial Ballistix 16GB DDR4",
    "Team T-Force Vulcan 32GB DDR4",
    "ADATA XPG Z1 16GB DDR4",
    "Patriot Viper Steel 16GB DDR4",
    "HyperX Predator RGB 32GB DDR4",
    "Corsair Dominator Platinum 32GB DDR4",
    "Crucial Ballistix MAX 64GB DDR4",
    "G.Skill Trident Z Neo 32GB DDR4",
    "Corsair Vengeance RGB Pro 32GB DDR4",
    "ADATA XPG Spectrix D60G 16GB DDR4",
    "TeamGroup T-Force Dark Za 32GB DDR4",
    "Kingston HyperX Predator 64GB DDR4",
    "G.Skill Sniper X 16GB DDR4",
    "Patriot Viper 4 16GB DDR4",
    "Corsair Vengeance LPX 8GB DDR4",
    "Crucial Ballistix Sport 16GB DDR4",
    "HyperX FURY 8GB DDR4"
  };

  private static readonly string[] MotherboardNames = {
    "ASUS ROG Strix B550-F Gaming",
    "MSI MPG B450 TOMAHAWK MAX",
    "GIGABYTE Z590 AORUS ULTRA",
    "ASRock B550M-ITX/ac",
    "MSI MAG B550M MORTAR",
    "ASUS TUF Gaming X570-Plus",
    "GIGABYTE B450 AORUS PRO WIFI",
    "ASRock X570 Taichi",
    "MSI MPG X570 GAMING EDGE WIFI",
    "ASUS PRIME B450M-A/CSM",
    "GIGABYTE B550M DS3H",
    "ASRock B450 PRO4",
    "MSI B450 TOMAHAWK",
    "ASUS ROG Strix X570-E Gaming",
    "GIGABYTE X570 AORUS ELITE",
    "ASRock B450M-HDV R4.0",
    "MSI MPG B550 GAMING EDGE WIFI",
    "ASUS ROG Crosshair VIII Hero",
    "GIGABYTE Z390 AORUS PRO WIFI",
    "ASRock B460 Steel Legend"
  };

  private static readonly string[] JobNames = {
    "Software Developer",
    "Data Scientist",
    "Registered Nurse",
    "Marketing Manager",
    "Accountant",
    "Mechanical Engineer",
    "Graphic Designer",
    "Financial Analyst",
    "Teacher",
    "Project Manager",
    "Dental Hygienist",
    "Civil Engineer",
    "Human Resources Manager",
    "Pharmacist",
    "Physical Therapist",
    "Electrical Engineer",
    "Web Developer",
    "Nurse Practitioner",
    "Operations Manager",
    "Lawyer",
    "Unemployeed"
  };

  public static string RandomPersonName      => PersonNames[_rand.Next(0,      PersonNames.Length)];
  public static string RandomVideoGameName   => GameNames[_rand.Next(0,        GameNames.Length)];
  public static string RandomCpuName         => CpuNames[_rand.Next(0,         CpuNames.Length)];
  public static string RandomGpuName         => GpuNames[_rand.Next(0,         GpuNames.Length)];
  public static string RandomRamName         => RamNames[_rand.Next(0,         RamNames.Length)];
  public static string RandomMotherboardName => MotherboardNames[_rand.Next(0, MotherboardNames.Length)];
  public static string RandomSoftwareName    => SoftwareNames[_rand.Next(0,    SoftwareNames.Length)];
  public static string RandomJobName         => JobNames[_rand.Next(0,         JobNames.Length)];
}
