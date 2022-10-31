namespace BuilderForWorker.Classes;

public class TemporaryWorker : Worker
{
    public TemporaryWorker(int id, string name, string lastName, string patronimic, decimal salary)
    : base(id, name, lastName, patronimic, new PerHourSalary() { BaseSalary = salary }) { }
}
