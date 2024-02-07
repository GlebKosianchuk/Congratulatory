namespace Congratulatory.Db;

public class UpcomingBirthdaysProvider : IUpcomingBirthdaysProvider
{
    public CongratulatoryDbContext context;

    public UpcomingBirthdaysProvider(CongratulatoryDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Person[] GetPersonsWithUpcomingBirthdays(DateOnly today, DateOnly dateLimit, int topCount)
    {
        return context.Persons
                        .Where(x =>
                            today <= x.Date.AddYears(today.Year - x.Date.Year) &&
                            x.Date.AddYears(today.Year - x.Date.Year) <= dateLimit)
                        .OrderBy(x => x.Date)
                        .Take(topCount)
                        .ToArray();
    }
}