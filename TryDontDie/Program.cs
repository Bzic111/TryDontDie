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

public interface ISalary
{
    decimal Calculate();
}
public interface IPerHourSalary : ISalary
{
    decimal Calculate();
}
public interface IPerMonthSalary : ISalary
{
    decimal Calculate();
}

abstract class PerHourSalary:ISalary
{
    decimal PerHourPayment { get; set; }
    public decimal Calculate()
    {
        return (decimal)20.8 * 8 * PerHourPayment;
    }
}
abstract class FixedSalary:ISalary
{
    decimal FixedAmount { get; set; }
    public decimal Calculate() => FixedAmount;
}

public abstract class Worker
{
    int id { get; set; }
    string Name { get; set; }
    string LastName { get; set; }
    string Patronimic { get; set; }
    decimal Salary { get; set; }
    protected abstract decimal Payment();
}
public class WorkerPayPerHour : Worker
{
    protected override decimal Payment()
    {
        throw new NotImplementedException();
    }
}