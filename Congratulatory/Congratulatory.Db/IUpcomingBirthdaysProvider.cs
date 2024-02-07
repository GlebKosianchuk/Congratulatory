namespace Congratulatory.Db;

public interface IUpcomingBirthdaysProvider
{
    Person[] GetPersonsWithUpcomingBirthdays(DateOnly today, DateOnly dateLimit, int topCount);
}