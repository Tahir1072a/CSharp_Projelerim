using System.Xml.Linq;
int[] intarr = new int[100];
LinkedList<int> list = new();
LinkedList<int> list1 = new();
list1.AddLast(0);
LinkedList<int> list2 = new();
list2.AddLast(0);
LinkedList<int> list3 = new();
LinkedList<LinkedList<int>> list4 = new();
list4.AddFirst(list);
list4.AddFirst(list1);
list4.AddFirst(list2);
list4.AddFirst(list3);
list.AddFirst(1);
list.AddFirst(0);
list.AddFirst(2);
list.AddFirst(0);
list.AddFirst(4);
list.AddFirst(0);
list.AddFirst(10);

/*
var temp = list.Find(0); // => Bir değer alır ve bu değeri içeren ilk node'u return eder.
var temp2 = list.FindLast(0); // => Bir değer alır ve bu değeri içeren son node'u return eder.
#region Find kontolu
if (temp.Equals(temp2))
{
    Console.WriteLine("Bu iki node eşittir");
}
else
{
    Console.WriteLine("Bu iki node eşit değildir.");
}
Console.WriteLine($"temp.Next : {temp.Next.Value}" + "   " + $"temp2.Next : {temp2.Next.Value}");
#endregion
*/
/*
list.Clear(); // => Tüm listeyi temizler.
list.AddLast();
list.AddFirst();
list.AddBefore(); //=> 2 tane overload
list.AddAfter(); // => 2 tane overload
*/
Console.WriteLine(list.Contains(10)); //=> ilgili caluenun içerip içermediğini söyler.
list.CopyTo(intarr, 0); //=> belirtilen arraya belirtilen indexten başlayarak, linked listi kopyalar.
//list.Equals(); //=> bu metot yazılacak ancak bu metot c# dilinde object nesneleri içn hazır olarak vardır bunu kulnacazğız.
list.GetEnumerator(); // => bize ilgili listenin elemanlarını bir itera edilebilir liste olarak döner. BUrada kendi enumaretor sınıfımızı yazmamız gerekiyor. Bu konu araştırılarak yapıalcak.
list.GetHashCode();
list.OnDeserialization(null); // incelneecek.
list.Clear();
//removlarda yazılacak bu kadar.