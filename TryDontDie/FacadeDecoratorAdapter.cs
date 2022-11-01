
namespace TryDontDie.FDA;

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
public interface IPerson
{
    int Id { get; set; }
    string Name { get; set; }

}
public interface IPersonService
{
    IReadOnlyList<IPerson> GetPersonByThisYear();
}
public interface IOrdersService
{
    IReadOnlyList<IOrder> GetOrderByPerson(IPerson person);
}
public interface ICalculationService
{
    long CalculateOrders(IReadOnlyList<IOrder> orders);
}
public sealed class ReportService
{
    private readonly IOrdersService _orderService;
    private readonly ICalculationService _calculationService;
    private readonly IPersonService _personService;
    public ReportService(IOrdersService ordersService, ICalculationService calculationService, IPersonService personService)
    {
        _orderService = ordersService;
        _calculationService = calculationService;
        _personService = personService;
    }
    public void CreateReportForThisYear()
    {
        IReadOnlyList<IPerson> persons = _personService.GetPersonByThisYear();
        List<IOrder> orders = new();
        foreach (IPerson person in persons)
        {
            IReadOnlyList<IOrder> ordersByPersons = _orderService.GetOrderByPerson(person);
            orders.AddRange(ordersByPersons);
        }
        _calculationService.CalculateOrders(orders);
    }
}
public interface IOrder
{
    int Id { get; set; }
    int PersonalId { get; set; }
    long Total { get; set; }
}
public interface IOrder2
{
    int Id { get; set; }
    long Total { get; set; }
}
public interface IOrderReportService
{
    void CalculateReportByOrders(IReadOnlyList<IOrder> orders);
}
public sealed class ComplexOrder
{
    public int Id { get; set; }
    public long TotalFirstPart { get; set; }
    public long TotalSecondPart { get; set; }
}
public sealed class ComplexOrderAdapter : IOrder2
{
    public int Id
    {
        get => _order.Id;
        set => _order.Id = value;
    }
    public long Total
    {
        get => _order.TotalFirstPart + _order.TotalSecondPart;
        set { }
    }
    private readonly ComplexOrder _order;
    public ComplexOrderAdapter(ComplexOrder order)
    {
        _order = order;
    }
}