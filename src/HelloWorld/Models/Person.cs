using System;

namespace HelloWorld.Models;

public class Person
{
    public string Title { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    
    public DateTime? DOB { get; set; }

    public override string ToString()
    {
        return $"{Firstname} {Surname}";
    }
}