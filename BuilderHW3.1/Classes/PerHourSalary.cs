using BuilderForWorker.Interfaces;

namespace BuilderForWorker.Classes;
public class PerHourSalary : ISalary
{
    public decimal BaseSalary { get; set; }
    public decimal Calculate() => (decimal)20.8 * 8 * BaseSalary;
}
