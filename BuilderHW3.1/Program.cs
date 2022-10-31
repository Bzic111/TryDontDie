using BuilderForWorker.Classes;
using BuilderForWorker.Interfaces;
using System;

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

Console.WriteLine(specialist.Salary.Calculate());
Console.WriteLine(temporaryWorker.Salary.Calculate());
Console.ReadKey(false);
