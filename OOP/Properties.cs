using System;



class PropertyExample
{   
    private string? name; // private field, ? işareti ilgili field'ın null olabileceğini işaret eder.

    public string? Name
    {
        get { return name; }
        set { name = "Tahiri"; }
    } // Full property yapısıdır. 
}