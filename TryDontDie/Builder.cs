using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDontDie
{
    public interface IPrintDevice
    {

    }
    public interface IReport
    {
        void Print(IPrintDevice printDevice);
    }
    internal sealed class BigReport : IReport
    {
        private readonly IList<string> _blocks = new List<string>();

        public void AddBlockInfo(string info)
        {
            _blocks.Add(info);
        }
        public void Print(IPrintDevice printDevice)
        {

        }
    }
    public sealed class ReportBuilder
    {
        private BigReport _report;
        public void AddHeader()
        {
            _report.AddBlockInfo("Adding Header");
        }
        public void AddFooter()
        {
            _report.AddBlockInfo("Adding footer");
        }

        public void AddBody()
        {
            _report.AddBlockInfo("Adding body");
        }
        public void AddExInfo(string info)
        {
            _report.AddBlockInfo(info);
        }
        public void Reset()
        {
            _report = new BigReport();
        }
        public IReport BuildReport()
        {
            BigReport report = _report;
            Reset();
            return report;
        }
    }
}
