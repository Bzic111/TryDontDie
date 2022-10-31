namespace BuilderForWorker.Classes;
public class HumanResources
{
    private static int Counter = 1;
    public static Worker GetSpecialist(string name, string lastName, string patronimic, decimal salary)
    {
        return new Specialist(Counter++, name, lastName, patronimic, salary);
    }
    public static Worker GetTemporaryWorker(string name, string lastName, string patronimic, decimal salary)
    {
        return new TemporaryWorker(Counter++, name, lastName, patronimic, salary);
    }
}