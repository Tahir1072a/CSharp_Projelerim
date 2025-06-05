namespace OOP;

public class CustomClassFunctions
{
    // This keywordü ile constructorlar arasında geçiş yapabiliriz.

    public string Name { get; set; } = "Name";
    public int Age { get; set; } = 22;
    // Program boyunca sadece bir kez tetiklenir. O da ilk nesne üretiminde gerçekleşir. Constructor'dan önce çağrılır.
    // Bu yapı ile singleton design pattern deseni uygulanabilir.
    static CustomClassFunctions()
    {
        Console.WriteLine("Static Constructor");
    }
    
    public CustomClassFunctions() // Nesne ilk ayağa kaldırılırken otomatik olarak çağrılan fonksiyon...
    {
        Console.WriteLine("Constructor called");
    }
    // Overload
    public CustomClassFunctions(int age)
    {
        Age = age;
        Name = "Bilinmiyor";
        Console.WriteLine($"Number: {age}");
    }

    public CustomClassFunctions(string name) : this() // Önce bu kısım çalışır.
    {
        Name = name;
        Console.WriteLine($"Name: {name}");
    }
    // this keywordü ile geçiş işlemleri...
    public CustomClassFunctions(string name, int age) : this(name)
    {
        Age = age;
        Console.WriteLine($"Number: {age}");
    }

    ~CustomClassFunctions() // Destructor => Kullanılması pek önerilmez, c# dilinde daha çok IDisposible yapısı öne çıkar.
    {
        Console.WriteLine("Destructor called");
    }
    
    // Out keywordü sayesinde return
    public void Deconstruct(out string a, out int b) // Tuple olarak bu parametrelerin geriye dönmesine olanak sağlar. Geriye değer döndürmez!
    {
        a = Name;
        b = Age;
    }
}

public class Database
{
    private static Database _instance;
    
    public static Database GetInstance
    {
        get => _instance;
    }

    public string ConnectionString { get; set; }
    
    static Database()
    {
        _instance = new Database(); // Bir kereye mahsur tetiklenecektir.
    }
    
    Database()
    {
        
    }

    public void Hello()
    {
        Console.WriteLine("Hello from Database");
    }
}