using System; // Genellikle en üste eklenir

Console.WriteLine("Tahiri Fidan");
var example = new MyClass();
Console.WriteLine(example.b);

public class MyClass
{
    public int a;
    public int b { get; set; } = 10;

    public MyClass()
    {
        a = 5; // Başlangıç değeri verelim
    }

    public void MesajGoster()
    {
        Console.WriteLine($"MyClass nesnesi: a = {a}");
    }
}