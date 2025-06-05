using System;
using OOP;

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

MyClass2 example_1 = new MyClass2();
MyClass2 example_2 = example_1; // Shallow Copy

Console.WriteLine($"Example 1: {example_1.Age}");
Console.WriteLine($"Example 2: {example_2.Age}");

example_2.Age = 20;

Console.WriteLine("Değiştirilmiş property....");
Console.WriteLine($"Example 1: {example_1.Age}");
Console.WriteLine($"Example 2: {example_2.Age}");

int number1 = 10;
ref int number2 = ref number1; // Shallow Copy

Console.WriteLine($"Number 1: {number1}\nNumber 2: {number2}");

number2 = 100;

Console.WriteLine($"Number 1: {number1}\nNumber 2: {number2}");


MyClass2 object1 = new MyClass2();
MyClass2 object2 = object1.Clone(); // Deep Copy

object2.Age = 90;

Console.WriteLine($"Object 1: {object1.Age}\nObject 2: {object2.Age}");

var orginalItems = new List<string> { "Item A", "Item B" };
var orginalDetails = new ComplexObject.Details("orginal name");

var orginalObject = new ComplexObject(10, orginalItems, orginalDetails);

ComplexObject deepCopy = orginalObject.DeepCopy();
ComplexObject deepCopyWithmemberwise = orginalObject.DeepCopyWithMemberwiseClone();

Console.WriteLine($"Orignal Object More Details Value: {orginalObject.MoreDetails.Name}");

deepCopy.MoreDetails.Name = "Cloned Name";
deepCopyWithmemberwise.MoreDetails.Name = "Cloned Memberwise Name";

Console.WriteLine($"Orignal Object More Details Value: {orginalObject.MoreDetails.Name}");
Console.WriteLine($"Deep Copy Object More Details Value: {deepCopy.MoreDetails.Name}");
Console.WriteLine($"Deep Copy Memberwise Object More Details Value: {deepCopyWithmemberwise.MoreDetails.Name}");


var car1 = new Car() { Model = "Mercedes" }; // Burada year özelliği gelmez...
var car2 = new Car() { Model = "Mercedes" };

Console.WriteLine($"Car 1 Model: {car1.Model}");
Console.WriteLine($"Car 2 Model: {car2.Model}");

var book1 = new Book() { Author = "Michael", Position = 1, Age = 20 };
var book2 = book1 with { Position = 2 }; // With deyimi ile bu şekilde kopyalama işlemi yapabiliriz.
var book3 = new Book() { Author = "Michael", Position = 1, Age = 20 };

Console.WriteLine($"Book 1 == Book 3: {book1 == book3}"); // True, Değer karşılaştırması yapar.
Console.WriteLine($"Car 1 == Car 2: {car1 == car2}"); // False, Referans karşılaştırması yapar.

Console.WriteLine($"Book 1: {book1}");

var person1 = new Person("Hasan", "Basri", 23);
var person2 = new Person("Hasan", "Uzun", 25);

Console.WriteLine($"Person 1: {person1}");
Console.WriteLine($"Person 2: {person2}");


var example22 = new CustomClassFunctions();
var (x, y) = example22; // Nesne deconstruct metoduna sahip olduğu için içindeki değerleri dışarı kusabilir.
Console.WriteLine($"Example 22: Name: {x}, Age: {y}");

Database dbContext = Database.GetInstance;
Database dbContext2 = Database.GetInstance;
dbContext.Hello();

dbContext.ConnectionString = "Orginal Connection String"; // Sadece bir nesne oluştuğunun kanıtı...
Console.WriteLine($"dbContext connection string: {dbContext.ConnectionString} and dbContext2: {dbContext2.ConnectionString}");

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

class MyClass2
{
    public int Age { get; set; } = 10; // Auto Property Initializer

    public MyClass2 Clone()
    {
        return (MyClass2)this.MemberwiseClone(); // Unboxing
    }
}