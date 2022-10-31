using BuilderForWorker.Interfaces;

namespace BuilderForWorker.Classes;
    public class FixedSalary : ISalary
{
    public decimal BaseSalary { get; set; }
    public decimal Calculate() => BaseSalary;
}