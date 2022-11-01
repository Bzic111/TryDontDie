using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;


//Pattern Strategy
public interface IScannerDevice
{
    Stream Scan();
}
public interface IScanOutputStrategy
{
    void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
}
public sealed class ScannerContext
{
    private readonly IScannerDevice _device;
    private IScanOutputStrategy _currentStrategy;
    public ScannerContext(IScannerDevice device)
    {
        _device = device;
    }
    public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
    {
        _currentStrategy = strategy;
    }
    public void Execute(string outputFileName = "")
    {
        if (_device is null)
        {
            throw new ArgumentNullException("Device is null");
        }
        if (_currentStrategy is null)
        {
            throw new ArgumentNullException("Strategy is null");
        }
        if (string.IsNullOrWhiteSpace(outputFileName))
        {
            outputFileName = Guid.NewGuid().ToString();
        }
        _currentStrategy.ScanAndSave(_device, outputFileName);
    }
}
public sealed class PdfScanOutputStrategy : IScanOutputStrategy
{
    public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
    {//pdf
    }
}
public sealed class ImageScanOutputStrategy : IScanOutputStrategy
{
    public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName) { }//jpg
}

//Pattern Chain of Responsibility

public interface IMonitorData
{
    int Cpu { get; }
    int Voltage { get; }
    bool TurnedOn { get; }
}
public interface IMonitorSystemDevice
{
    IEnumerator<IMonitorData> GetMonitorData();
}

public interface IMonitorPipelineItem
{
    void SetNextItem(IMonitorPipelineItem pipelineItem);
    void ProcessData(IMonitorData data);
}