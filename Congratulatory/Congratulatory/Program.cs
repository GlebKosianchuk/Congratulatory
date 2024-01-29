using Congratulatory.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congratulatory;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new CongratulatoryDbContext();
        var person1 = new Person()
        {
            Name = "Michael",
            Surname = "Ballack",
            Date = new DateOnly(1974, 7, 12)
        };

        var person2 = new Person()
        {
            Name = "John",
            Surname = "Stones",
            Date = new DateOnly(1994, 4, 16)
        };

        context.Persons.Add(person1);
        context.Persons.Add(person2);
        context.SaveChanges();
    }
}