using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWorld.Models;

namespace HelloWorld.Interfaces;

public interface IPersonStore
{
    static List<Person> Store { get; set; }
    
    void AddPersons(Person person);
}