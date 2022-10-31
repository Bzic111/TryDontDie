using BuilderForWorker.Classes;
using BuilderForWorker.Interfaces;
using System;
using System.Text;
/*
 1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников 
с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
Для «повременщиков» формула для расчета такова: 
«среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»,
для работников с фиксированной оплатой
«среднемесячная заработная плата = фиксированная месячная оплата».
б) Создать на базе абстрактного класса массив сотрудников и заполнить его,
вывести список сотрудников на экран.
 */

Worker specialist = HumanResources.GetSpecialist("Alexandr", "Alexandrov", "Alexandrovich", 1000);
Worker temporaryWorker = HumanResources.GetTemporaryWorker("Ivan", "Ivanov", "Ivanovich", 10);

Console.WriteLine(specialist.Salary.Calculate());
Console.WriteLine(temporaryWorker.Salary.Calculate());
List<Worker> workers = new();
for (int i = 0; i < 10; i++)
{
    workers.Add(HumanResources.GetSpecialist(GetRandomString(), GetRandomString(), GetRandomString(), i * 100));
    workers.Add(HumanResources.GetTemporaryWorker(GetRandomString(), GetRandomString(), GetRandomString(), i * 10));
}

foreach (var item in workers)
{
    System.Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Patronimic}\t{item.LastName}\t{item.Salary.Calculate()}");
}

Console.ReadKey(false);
string GetRandomString()
{
    Random rnd = new Random();
    StringBuilder sb = new();
    for (int i = 0; i < 8; i++)
        sb.Append((char)rnd.Next('a', 'z'));

    return sb.ToString();
}
