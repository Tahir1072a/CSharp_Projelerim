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

// Record yapılanması c#'da nesne runtime'da değiştirilmesini istemediğimiz durumlarda kullanırız. Yani nesnenin tüm field'ları ve propertyleri init-only property olur...
// Class ile aynı işlevi görür ancak değerler ön plandadır. Mesela '=' operatörü ile karşılaştırma yaparsak, recordlar da nesne içindeki değerlere göre karşılaştırma
// yaparken, class'lar  da ise referans tabanlı karşılaştırma yapar.

public record Book // => Nominal Record Yapılanması
{
    public string? Author { get; init; }
    public int Position { get; init; }
}