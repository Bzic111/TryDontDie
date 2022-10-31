namespace BuilderForWorker.Interfaces;
public interface ISalary
{
    decimal BaseSalary { get; set; }
    decimal Calculate();
}
