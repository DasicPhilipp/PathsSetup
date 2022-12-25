namespace PathsSetup;

public interface IPathsResolver
{
    public void Resolve<T>(T obj);
}