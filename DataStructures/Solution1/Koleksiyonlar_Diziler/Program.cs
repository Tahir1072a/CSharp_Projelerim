//Koleksiyonlar-Arrays
using System.Collections;
using System.Collections.Generic;

//Arrays
char[] chars = new char[3] { 'A', 'B', 'C' };
//Dii oluşturmanın başka bir yolu Array sınıfını kullanmaktır.
var crr = Array.CreateInstance(typeof(int),5);
crr.SetValue(0, 0);
Console.WriteLine(crr.GetValue(0));

//ArrayList
// ArrayList elemanları object olarak tuttuğu için Type-Safety yoktur.
var arrObj = new ArrayList();
arrObj.Add("Tahiri"); // No Type-Safe
arrObj.Add(100); // -> boxing

var c = (int)arrObj[1] + 20; // -> Açık bir şekilde gözükmektedir. burada unboxing yapılması gerekir.
Console.WriteLine(c);

//Generic List -> List<T>  Type-Safe mevtur.
var arrInt = new List<int>();
arrInt.Add(1);
//arrInt.Add("Tahiri"); //-> Kabul etmez
arrInt.AddRange(new int[] { 1, 2, 3 });
arrInt.Remove(0);

for (int i = 0; i < arrInt.Count; i++)
{
    Console.WriteLine(arrInt[i]);
}