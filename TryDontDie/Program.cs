using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

public sealed class Order
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public long TotalMoney { get; set; }
}
public interface IOrdersRepository
{
    IReadOnlyList<Order> GetAll();
}
public interface ICalculation
{
    long CalculateByDate(DateTime from, DateTime To);
}
public sealed class Calculation : ICalculation
{
    private readonly IOrdersRepository _repository;
    public Calculation(IOrdersRepository repo)
    {
        _repository = repo;
    }
    public long CalculateByDate(DateTime from, DateTime to)
    {
        return _repository
                    .GetAll()
                    .Where(x => x.CreationDate >= from && x.CreationDate <= to)
                    .Sum(x => x.TotalMoney);
    }
}

public sealed class Period
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public long Total { get; set; }
}
public sealed class AdvancedCalculation : ICalculation
{
    private readonly Calculation _calc;
    public AdvancedCalculation(Calculation calc)
    {
        _calc = calc;
    }
    public long CalculateByDate(DateTime from, DateTime to)
    {
        return _calc is null ? 0 : _calc.CalculateByDate(from, to);
    }
    public Period CalculateByDate(Period period)
    {
        if (_calc is not null && period is not null)
        {
            period.Total = CalculateByDate(period.From, period.To);
        }
        return period;
    }
    public IEnumerator<Period> CalculateByPeriods(IEnumerable<Period> periods)
    {
        if (periods is null)
        {
            yield break;
        }
        foreach (var period in periods)
        {
            yield return CalculateByDate(period);
        }
    }
}