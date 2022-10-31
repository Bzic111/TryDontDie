namespace BuilderForWorker.Classes;

public class Specialist : Worker
{
    public Specialist(int id, string name, string lastName, string patronimic, decimal salary)
    : base(id, name, lastName, patronimic, new FixedSalary() { BaseSalary = salary }) { }

}
