public class ComplexObject
{
    public int Value { get; set; }
    public List<string> Items { get; set; }
    public Details? MoreDetails { get; set; }

    public class Details
    {
        public string Name { get; set; } // Referans tipli bir değişken...
        public Details(string name) { Name = name; } // Constructor
        public Details DeepClone() { return new Details(this.Name); } // Deep Copy

    }

    public ComplexObject(int value, List<string> items, Details? details)
    {
        Value = value;
        Items = items;
        MoreDetails = details;
    }

    public ComplexObject DeepCopy()
    {
        int clonedValue = this.Value;

        List<string> clonedItems = new List<string>(this.Items);

        Details? clonedDetails = this.MoreDetails?.DeepClone(); // Null kontolü...

        ComplexObject clone = new ComplexObject(clonedValue, clonedItems, clonedDetails);

        return clone;
    }

    public ComplexObject DeepCopyWithMemberwiseClone()
    {
        return (ComplexObject)this.MemberwiseClone();
    }

}