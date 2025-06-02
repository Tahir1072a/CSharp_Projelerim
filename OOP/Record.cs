// Init - Only Properties Nedir?
// Bu özellik nesnenin sadece ilk oluşturulduğu anda nesneye ait fieldlara değer atanmasını sağlar
// Runtime'da değişikliklik yapmasına olanak tanımaz...

class Car
{
    public int Year { get; } = 2003; // readonly property - ilk değer sadece burada verilebilir.
    public string? Model { get; init; } // Init only property haline geldi...

    public string Author { get; set; }

    public Car()
    {
        Author = "Hasan Basri";
    }
}