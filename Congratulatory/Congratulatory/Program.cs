using Congratulatory.Db;

namespace Congratulatory;

public class Program
{
    private const int UpcomingBirthdaysNumber = 5;
    private const int UpcomingBirthdaysDaysCount = 5;
    public  const string connectionString = "";

    public static void Main(string[] args)
    {
        using var context = new CongratulatoryDbContext(connectionString);
        var personRepository = new PersonRepository(context);
        var getUpcomingBirthdays = new UpcomingBirthdaysProvider(context);
        var person = new PersonRepository(context);
        GetUpcomingBirthdaysOfAPersons(getUpcomingBirthdays);

        string input;
        do
        {
            Console.WriteLine("Добро пожаловать в приложение ДР!");
            Console.WriteLine("1. Показать список всех ДР");
            Console.WriteLine("2. Показать список сегодняшних и ближайших ДР");
            Console.WriteLine("3. Добавить новый ДР");
            Console.WriteLine("4. Удалить ДР по ID");
            Console.WriteLine("5. Редактировать запись в списке ДР");
            Console.WriteLine("6. Выход");

            input = Console.ReadLine();
            switch (input )
            {
                case "1":
                    GetAllPersons(personRepository);
                    break;
                case "2":
                    GetUpcomingBirthdaysOfAPersons(getUpcomingBirthdays);
                    break;
                case "3":
                    AddNewPerson(personRepository);
                    break;
                case "4":
                    RemovePerson(personRepository);
                    break;
                case "5":
                    UpdatePerson(person);
                    break;
                case "6":
                    return;
            }
        } while (input != "6");
    }

    public static void GetUpcomingBirthdaysOfAPersons(IUpcomingBirthdaysProvider getUpcomingBirthdays)
    {
        var today = DateTime.UtcNow.Date;
        var todayDate = new DateOnly(today.Year, today.Month, today.Day);
        var upcomingBirthdays = getUpcomingBirthdays.GetPersonsWithUpcomingBirthdays(todayDate, todayDate.AddDays(UpcomingBirthdaysDaysCount), UpcomingBirthdaysNumber);
        PrintPersons(upcomingBirthdays);
        Console.WriteLine();
    }

    public static void GetAllPersons(IPersonRepository personRepository)
    {
        var allBirthdays = personRepository.GetAll();
        PrintPersons(allBirthdays);
        Console.WriteLine();
    }

    public static void AddNewPerson(IPersonRepository personRepository)
    {
        var person = new Person();

        Console.WriteLine("Введите имя: ");
        person.Name = Console.ReadLine();

        Console.WriteLine("Введите Фамилию: ");
        person.Surname = Console.ReadLine();

        Console.WriteLine("Введите дату рождения (гггг-мм-дд): ");
        person.Date = DateOnly.Parse(Console.ReadLine());

        personRepository.Add(person);
        Console.WriteLine("День рождения добавлен.");
        Console.WriteLine();
    }

    public static void RemovePerson(IPersonRepository personRepository)
    {
        Console.WriteLine("Введите ID Дня Рождения для удаления:");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            personRepository.Remove(id);
            Console.WriteLine("День рождения удален.");
        }
        else
        {
            Console.WriteLine("Некорректный ID.");
        }
        Console.WriteLine();
    }

    public static void PrintPersons(Person[] birthdays)
    {
        Console.WriteLine($"{"Id",-2} {"Name",-20} {"Surname",-20} {"Birthday",-20}");
        foreach (var birthday in birthdays)
        {
            Console.WriteLine($"{birthday.Id,-2} {birthday.Name,-20} {birthday.Surname,-20} {birthday.Date.ToShortDateString(),-20}");
        }
    }

    public static void UpdatePerson(IPersonRepository personRepository)
    {
        Console.WriteLine("Введите ID Дня Редактирования записи в списке ДР.");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            var person = personRepository.GetById(id);
            Console.WriteLine("Введите новое имя:");
            person.Name = Console.ReadLine();

            Console.WriteLine("Введите новую фамилию:");
            person.Surname = Console.ReadLine();

            Console.WriteLine("Введите новую дату родения:");
            person.Date = DateOnly.Parse(Console.ReadLine());

            personRepository.Update(person);
            Console.WriteLine("Запись в списке ДР изменена.");
        }
        else
        {
            Console.WriteLine("Некорректный ID.");
        }
    }
}