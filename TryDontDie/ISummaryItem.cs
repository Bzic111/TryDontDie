using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDontDie
{
    public interface ISummaryItem
    {
        long Id { get; set; }
        long TotalMoney { get; }
        void Calculate();
    }
    public interface IMonthSummary : ISummaryItem
    {

    }
    public interface IYearSummary : ISummaryItem
    {

    }
    public interface ISummaryFactory
    {
        ISummaryItem CreateMonthSummary();
        ISummaryItem CreateYearSummary();
    }
    internal sealed class SummaryWorkerService
    {
        public void CalculateSummaryAndSaveTotalMoney(ISummaryItem summaryItem)
        {
            summaryItem.Calculate();
            long totalMoney = summaryItem.TotalMoney;
        }
    }
    internal sealed class SalesDepartmentMonthSummaryItem : IMonthSummary
    {
        public long Id { get; set; }
        public long TotalMoney { get; private set; }

        public void Calculate()
        {
            DateTime Now = DateTime.Now;
            int totalDays = DateTime.DaysInMonth(Now.Year, Now.Month);
            TotalMoney = totalDays * 50;
        }
    }
    internal sealed class SalesDepartmentYearSummaryItem : IYearSummary
    {
        public long Id { get; set; }
        public long TotalMoney { get; private set; }

        public void Calculate()
        {
            TotalMoney = 12 * 500;
        }
    }
    public sealed class SalesDepartmentSummaryFactories : ISummaryFactory
    {
        public ISummaryItem CreateMonthSummary()
        {
            return new SalesDepartmentMonthSummaryItem();
        }

        public ISummaryItem CreateYearSummary()
        {
            return new SalesDepartmentYearSummaryItem();
        }
    }
}
