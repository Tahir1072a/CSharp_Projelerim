namespace OOP;

public class CustomClassFunctions
{
    // This keywordü ile constructorlar arasında geçiş yapabiliriz.
    
    public CustomClassFunctions() // Nesne ilk ayağa kaldırılırken otomatik olarak çağrılan fonksiyon...
    {
        Console.WriteLine("Constructor called");
    }
    // Overload
    public CustomClassFunctions(int number)
    {
        Console.WriteLine($"Number: {number}");
    }

    public CustomClassFunctions(string name)
    {
        Console.WriteLine($"Name: {name}");
    }
    // this keywordü ile geçiş işlemleri...
    public CustomClassFunctions(string name, int number) : this(name)
    {
        Console.WriteLine($"Number: {number}");
    }

    ~CustomClassFunctions()
    {
        Console.WriteLine("Destructor called");
    }
}