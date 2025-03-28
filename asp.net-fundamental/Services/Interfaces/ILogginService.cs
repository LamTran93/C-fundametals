namespace asp.net_fundamental.Services.Interfaces
{
    public interface ILogginService<T>
    {
        public void Log(T data);
    }
}
