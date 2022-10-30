public sealed class ClassicPullItem : PullItem
{
    //public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public Thread? _thread { get => base._thread; private set => base._thread = value; }
    public override void Reset()
    {
        Id = 0;
        //Name = string.Empty;
    }
    public Thread Run(Action act)
    {
        _thread = new Thread(new ThreadStart(act));
        _thread.Start();
        return _thread;
    }
}