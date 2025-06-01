using System;

MyClass example = new MyClass(); // Class Example türünde bir referans oluşturduk.
Console.WriteLine($"Example b: {example.b}"); // Referans üzerinden ilgili nesneye ait field'lara erişiyoruz.
example.MesajGoster(); // Aynı şekilde metotlara eriişim bu şekilde yapılıyor.

MyClass example2 = new MyClass(); // Yeni bir referans noktası oluşturduk. Ve new ile örneklediğimiz nesneyi işaret ettik.
// Buradaki example2 ile example tamamen farklı nesneleri işaret ediyor.
example.a = 120;
example2.a = 100;

Console.WriteLine($"Example a: {example.a}");
Console.WriteLine($"Example2 a: {example2.a}");

// Object Initializer
MyClass example3 = new MyClass() { a = 20, b = 90 };
Console.WriteLine($"Example 3: {example3.a}");

public class MyClass
{
    public int a; // Field
    public int b { get; set; } = 10; // Property

    public MyClass() // Constructor
    {
        a = 5; // Başlangıç değeri verelim
    }

    public void MesajGoster()
    {
        Console.WriteLine($"MyClass nesnesi: a = {a}");
    }
}