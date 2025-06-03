
using MyDataStructures.Tree.Trie;

CST badWorths = new CST();
badWorths.Add("Aptal");
badWorths.Add("Salak");
badWorths.Add("Mal");
var str = badWorths.Censor("Tahiri test yapiyor ve tahiri soru cozmekten nefret ediyor.Onun mal oldugunu dusunuyorum. TAM BİR MAL");
Console.WriteLine(str);
Console.ReadLine();