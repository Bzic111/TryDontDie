using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

/*
 1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников 
с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
Для «повременщиков» формула для расчета такова: 
«среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»,
для работников с фиксированной оплатой
«среднемесячная заработная плата = фиксированная месячная оплата».
 */

Worker specialist = HumanResources.GetSpecialist("Alexandr", "Alexandrov", "Alexandrovich", 1000);
Worker temporaryWorker = HumanResources.GetTemporaryWorker("Ivan", "Ivanov", "Ivanovich", 10);

System.Console.WriteLine(specialist.Salary.Calculate());
System.Console.WriteLine(temporaryWorker.Salary.Calculate());
Console.ReadKey(false);

public interface ISalary
{
    decimal BaseSalary { get; set; }
    decimal Calculate();
}

public class PerHourSalary : ISalary
{
    public decimal BaseSalary { get; set; }
    public decimal Calculate() => (decimal)20.8 * 8 * BaseSalary;
}
public class FixedSalary : ISalary
{
    public decimal BaseSalary { get; set; }
    public decimal Calculate() => BaseSalary;
}

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
public class Specialist : Worker
{
    public Specialist(int id, string name, string lastName, string patronimic, decimal salary)
    : base(id, name, lastName, patronimic, new FixedSalary() { BaseSalary = salary }) { }

}
public class TemporaryWorker : Worker
{
    public TemporaryWorker(int id, string name, string lastName, string patronimic, decimal salary)
    : base(id, name, lastName, patronimic, new PerHourSalary() { BaseSalary = salary }) { }
}
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