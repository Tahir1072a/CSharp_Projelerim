using MyDataStructures.MyArrayList;
using System.Collections;


MyList<int> values = new MyList<int>();
//MyList<int> values = new MyList<int>(arrayList); // Hata alırız çünkü Bu bir IEnumerable ınterfacene sahip bir koleksiyon değil ve tip güvenli bir yapıaya da sahip değil.
values.Add(129);
values.Add(1);
values.Add(2);
//values.Remove();
//Console.WriteLine((int)values.Remove());

MyList<int> temp = (MyList<int>)values.Clone();
//temp[0] = 129;  // => clone metodunun tamamen deep copy üzerinde çalıştığını gösterir.
temp.Add(129);
temp.Add(120);
temp.Add(120);
temp.Add(120);
temp.Add(120);
temp.Add(120);
temp.Add(120);
temp.RemoveAll(129);
temp.Add(120);
temp.Add(120);
temp.Add(120);
temp.Add(12);
temp.Add(12);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
temp.RemoveAt(1);
foreach (int i in temp)
{
    Console.WriteLine(i);
}
Console.WriteLine($"{temp.Count} / {temp.Capacity}");
/* indexer kullanarak diziyi bu şekilde de dönebiliriz.
for (int i = 0; i < values.Count; i++)
{
    Console.WriteLine(values[i]);
}
*/

//Console.WriteLine($"{values.Count} / {values.Capacity}");

