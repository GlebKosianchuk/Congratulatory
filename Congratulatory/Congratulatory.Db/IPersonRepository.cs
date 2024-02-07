namespace Congratulatory.Db;

public interface IPersonRepository
{
    Person[] GetAll();

    void Add(Person person);

    void Remove(int id);

    void Update(Person person);

    Person GetById(int id);
}
