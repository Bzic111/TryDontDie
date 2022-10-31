namespace BuilderForWorker.Classes;

public abstract class Worker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Patronimic { get; set; }
    public ISalary Salary { get; set; }
    public Worker(int id, string name, string lastName, string patronimic, ISalary salary)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Patronimic = patronimic;
        Salary = salary;
    }
}
