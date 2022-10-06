using System.Collections.Generic;
using HelloWorld.Interfaces;
using HelloWorld.Models;

namespace HelloWorld.Services;

public class PersonsStore : IPersonStore
{
    public static List<Person> Store { get; set; } = new();

    public void AddPersons(Person person)
    {
        Store.Add(person);
    }
}