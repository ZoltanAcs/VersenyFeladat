using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


string[] telepulesek = File.ReadAllLines("C:\\Users\\b0acszol\\Dolgozat");
string[] megyek = File.ReadAllLines("megyek.txt");

Dictionary<string, int> megyeLakossag = new Dictionary<string, int>();
foreach (string telepules in telepulesek)
{
    string[] telepulesAdatok = telepules.Split();
    string megye = telepulesAdatok[1];
    int lakossag = int.Parse(telepulesAdatok[5]);
    if (megyeLakossag.ContainsKey(megye))
    {
        megyeLakossag[megye] += lakossag;
    }
    else
    {
        megyeLakossag[megye] = lakossag;
    }
}

var rendezettMegyek = megyeLakossag.OrderBy(x => x.Value).ToList();

string masodikLegkisebbMegye = rendezettMegyek[1].Key;
int masodikLegkisebbLakossag = rendezettMegyek[1].Value;

string megyeNeve = "";
foreach (string sor in megyek)
{
    string[] sorAdatok = sor.Split();
    if (sorAdatok[0] == masodikLegkisebbMegye)
    {
        megyeNeve = sorAdatok[1];
        break;
    }
}


List<string> rendezettTelepulesek = telepulesek.OrderBy(x =>
{
    string[] adatok = x.Split();
    return double.Parse(adatok[2]);
}).ToList();

string legeszakibbTelepulesSora = rendezettTelepulesek.FirstOrDefault();

string[] legeszakibbTelepulesAdatok = legeszakibbTelepulesSora.Split();
string legeszakibbTelepulesNev = legeszakibbTelepulesAdatok[6];

string valasz = $"{megyeNeve}-{masodikLegkisebbLakossag}";
Console.WriteLine("A második legkisebb népességgel bíró megyénk: " + valasz);

Console.WriteLine("A legészakibb településünk: " + legeszakibbTelepulesNev);

Console.WriteLine("Honorable mention: Dömsöd");
