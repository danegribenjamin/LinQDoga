using System.ComponentModel.Design;

List<Videogames> videogames = [];

const string FilePath = "C:\\Users\\dan-egri.benjamin\\Desktop\\LINQ DOGA\\LinQDoga\\LinQDoga\\bin\\Debug\\videogames.csv";
using StreamReader sr = new StreamReader(FilePath);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(',');
    videogames.Add(new()
    {
        Cim = tmp[0],
        Mufaj = tmp[1],
        KiadasDatum = DateTime.Parse(tmp[2]),
        AktivJatekosok = int.Parse(tmp[3]),
        Ertekeles = float.Parse(tmp[4].Replace('.', ','))
    });
}

//1. feladat
var hanyjatek = videogames.Count(p => p.Ertekeles > 4.5);
Console.WriteLine("Hány olyan játék van a listában, aminek az értékelése szigorúan nagyobb, mint 4.5?: " + hanyjatek);
Console.WriteLine();
//2.feladat
var legtobben = videogames.MaxBy(p => p.AktivJatekosok);
Console.WriteLine("Melyik az a játék a teljes kínálatból, amellyel a legtöbben játszanak?: " + legtobben.Cim);
Console.WriteLine();
//3. feladat
var Any = videogames.Any(p => p.KiadasDatum.Year == 2020 && p.KiadasDatum.Month == 01 && p.KiadasDatum.Day == 01);
Console.WriteLine($" Van-e egyáltalán olyan játék a listában, amit 2020. január 1. előtt adtak ki?: {(Any ? "van" : "nincs")}");
Console.WriteLine();
//4. feladat
var avg = videogames.Average(p => p.Ertekeles);
Console.WriteLine("Mennyi a listában szereplő összes játék értékelésének az átlaga?: " + avg);
Console.WriteLine();
//5. feladat
var single = videogames.Single(p=> p.Cim == "Cyber City 2077");
Console.WriteLine($"Keresd meg a listában azt az EGYETLEN játékot, aminek a címe pontosan \"Cyber City 2077\":  \t\n{single}");
Console.WriteLine();
//6. feladat
var listaki = videogames.Where(p => p.Mufaj == "RPG").OrderByDescending(p => p.KiadasDatum);
Console.WriteLine($"Listázd ki az összes \"RPG\" műfajú játékot, majd rendezd őket a kiadás dátuma szerint csökkenő sorrendbe!: {listaki}");
Console.WriteLine();
//7.feladat
//8.feladat
//9.feladat
var groupby = videogames.GroupBy(p => p.Mufaj);
Console.WriteLine("műfajokban játékok:");
foreach (var grp in groupby)
{
    Console.WriteLine($"\t{grp.Key} ({grp.Count()} db):");
    foreach (var product in grp)
    {
        Console.WriteLine($"\t\t{product.Mufaj,-24} {product.Cim,10:C0}");
    }
}
//10
var stat = videogames.GroupBy(p => p.Mufaj).Select(g => new
{
CategoryName = g.Key,
NuberOfProducts = g.Count(),
BestModel = $"{g.MaxBy(p => p.Ertekeles).Cim} ({g.Max(p => p.Ertekeles):0.0}/5.0)",
}).OrderBy(g => g.NuberOfProducts);
Console.WriteLine("legmagasabb értékelések: ");
foreach (var item in stat)
{
    Console.WriteLine($"{item.CategoryName}\n" +
    $"\tlegjobb termék: {item.BestModel}");
}
