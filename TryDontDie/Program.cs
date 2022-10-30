using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;public interface IBill
{
    long Id { get; }
}
public abstract class BillManagament
{
    protected abstract IBill CreateBill();
    public IBill RegisterNewBill()
    {
        IBill bill = CreateBill();
        bool result = CommitBill(bill);
        if (result)
        {
            Console.WriteLine($"Success to commit bill with id {bill.Id}");
            return bill;
        }
        throw new Exception("Failed to commit bill");
    }
    protected abstract bool CommitBill(IBill bill);
}
internal sealed class SalesBill : IBill
{
    private long _id;
    public long Id
    {
        get => _id * 100;
        set => _id = value;
    }
}
internal sealed class FinanceBill:IBill
{
    private long _id;
    public long Id
    {
        get => _id * 1000;
        set => _id = value;
    }
}
public sealed class SalesBillManagement : BillManagament
{
    protected override bool CommitBill(IBill bill)
    {
        Console.WriteLine($"Bill {bill.Id} saved");
        return true;
    }

    protected override IBill CreateBill()
    {
        return new SalesBill();
    }
}
public sealed class FinanceBillManagement : BillManagament
{
    protected override bool CommitBill(IBill bill)
    {
        Console.WriteLine($"Bill {bill.Id} saved");
        return true;
    }

    protected override IBill CreateBill()
    {
        return new FinanceBill();
    }
}