using System;

// Class içinde class tanımlarsan sadece ilgili class'ın namespace'i ile oynamış olursun. Yani ilgili class o sınıfın bir field'ı olmaz.

// var example = new PropertyExample(); 
/// <summary>
/// Bu kodlarımızı dökümante edebilmemizi sağlayan bir özelliktir.
/// </summary>
class PropertyExample
{
    private string? name; // private field, ? işareti ilgili field'ın null olabileceğini işaret eder.
    private string? lastName;
    private int? age;
    private int? number;

    private List<int> numbers = new List<int> { };

    public string? Name
    {
        get { return name; }
        set { name = value; }
    } // Full property yapısıdır. 

    public string? LastName // Readonly
    {
        get { return lastName; }
    }

    public int Age { get; set; } = 12; // Auto Property Initializer

    public ref readonly int? Number => ref number;
    // Burada ilgili field'ın referansını return ederiz. Bu her nesne için ayrı ayrı nesne oluşturulmasını engeller. 
    // Static ile farkı, değer tiplerin kopyalanmasını engelleyip bellek optimizasyonu sağlamasıdır.

    public string cinsiyet => "Erkek"; //Expresiion bodied property olarak geçer. Readonly'dir.

    //INDEXER 
    public int this[int abc]
    {
        get
        {
            try
            {
                return numbers[abc];
            }
            catch
            {
                throw new Exception("Hatali bir indeksleme yaptınız!!");
            }
        }

        set
        {
            try
            {
                numbers[abc] = value;
            }
            catch
            {
                throw new Exception("Hatali bir indeksleme yaptınız!!");
            }
        }
    }

    class MyClass
    {
        public int Age2 { get; set; }
    }

    public void X()
    {
        Console.WriteLine($"Age: {this.Age}");
    }
}   