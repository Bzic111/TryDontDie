public abstract class PullItem
{
    public int Id { get; set; }
    public Thread? _thread { get; set; }
    public abstract void Reset();
}
