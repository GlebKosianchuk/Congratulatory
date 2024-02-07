using Microsoft.EntityFrameworkCore;

namespace Congratulatory.Db;

public class PersonRepository : IPersonRepository
{
    public CongratulatoryDbContext context;

    public PersonRepository(CongratulatoryDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Person[] GetAll()
    {
        return context.Persons.OrderBy(x => x.Date).ToArray();
    }

    public void Add(Person person)
    {
        context.Persons.Add(person);
        context.SaveChanges();
    }

    public void Remove(int id)
    {
        context.Persons.Where((x) => x.Id == id).ExecuteDelete();
        context.SaveChanges();
    }

    public void Update(Person person)
    {
        context.Persons.Update(person);
        context.SaveChanges();
    }

    public Person GetById(int id)
    {
        return context.Persons.Single(x => x.Id == id);
    }
}