
public interface IState
{
    public string Name { get; }
    public void Start();
    public void Update();
    public void Stop();
}

